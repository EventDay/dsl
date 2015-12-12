// Copyright (C) 2015 EventDay, Inc

using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using EventDayDsl.EventDay.Entities;
using Microsoft.CSharp;
using File = EventDayDsl.EventDay.Entities.File;

namespace EventDayDsl.EventDay
{
    internal class OutputFiles
    {
        public string Messages { get; set; }
        public string Markers { get; set; }
        public string StateDefinitions { get; set; }
        public string Enumerations { get; set; }
        public string Entities { get; set; }

        public bool HasMessageContent => HasMessages || HasMarkers || HasEnumerations;
        public bool HasMessages => Messages != null;
        public bool HasEntities => Entities != null;
        public bool HasMarkers => Markers != null;
        public bool HasEnumerations => Enumerations != null;
        public bool HasStateDefinitions => StateDefinitions != null;
    }

    internal static class Extensions
    {
        private static readonly IDictionary<string, string> TypeMappings = new Dictionary<string, string>
        {
            {"string", "String"},
            {"string[]", "String[]"},
            {"bool", "Boolean"},
            {"bool[]", "Boolean[]"},
            {"int", "Int32"},
            {"int[]", "Int32[]"},
            {"long", "Int64"},
            {"long[]", "Int64[]"},
            {"decimal", "Decimal"},
            {"decimal[]", "Decimal[]"},
            {"double", "Double"},
            {"double[]", "Double[]"}
        };

        public static string CamelCased(this string text)
        {
            return string.Concat(char.ToLower(text.First()), text.Substring(1));
        }

        public static string PascalCased(this string text)
        {
            return string.Concat(char.ToUpper(text.First()), text.Substring(1));
        }

        public static string SafeTypeName(this string type)
        {
            string safeType;
            if (TypeMappings.TryGetValue(type, out safeType))
            {
                return safeType;
            }
            return type;
        }

        public static OutputFiles GenerateSource(this File file)
        {
            return new OutputFiles
            {
                Markers = GenerateMarkers(file),
                Messages = GenerateMessages(file),
                StateDefinitions = GenerateStateHandlers(file),
                Enumerations = GenerateEnumerations(file),
                Entities = GenerateEntities(file)
            };
        }

        private static string GenerateEntities(File file)
        {
            if (!file.Entities.Any())
                return null;

            var unit = new CodeCompileUnit();
            var ns = new CodeNamespace($"{file.Namespace}.Entities");

            var globalNs = new CodeNamespace();
            globalNs.Imports.AddRange(file.Usings.OrderBy(x => x).Select(x => new CodeNamespaceImport(x)).ToArray());
            unit.Namespaces.Add(globalNs);
            unit.Namespaces.Add(ns);

            foreach (var entity in file.Entities)
            {
                ns.Types.Add(GenerateEntity(entity));
            }

            return GenerateCode(unit);
        }

        private static string GenerateStateHandlers(File file)
        {
            if (!file.StateDefinitions.Any())
                return null;

            var unit = new CodeCompileUnit();
            var ns = new CodeNamespace($"{file.Namespace}.State");

            var globalNs = new CodeNamespace();
            globalNs.Imports.AddRange(file.Usings.OrderBy(x => x).Select(x => new CodeNamespaceImport(x)).ToArray());
            unit.Namespaces.Add(globalNs);

            ns.Imports.Add(new CodeNamespaceImport($"{file.Namespace}.Messages"));
            unit.Namespaces.Add(ns);

            foreach (var definition in file.StateDefinitions)
            {
                var type = new CodeTypeDeclaration($"{definition.Name}Subscription")
                {
                    TypeAttributes = TypeAttributes.Abstract | TypeAttributes.Public,
                    IsClass = true,
                    BaseTypes = {new CodeTypeReference("IStateHandler")}
                };

                CodeTypeDeclaration iface = null;
                if (definition.GenerateInterface)
                {
                    iface = new CodeTypeDeclaration(definition.Interface)
                    {
                        TypeAttributes = TypeAttributes.Sealed | TypeAttributes.Public | TypeAttributes.Interface
                    };

                    type.BaseTypes.Add(iface.Name);

                    ns.Types.Add(iface);
                }

                var receive = new CodeMemberMethod
                {
                    Name = "Receive",
                    Attributes = MemberAttributes.Public,
                    Parameters =
                    {
                        new CodeParameterDeclarationExpression(typeof (object), "message")
                    },
                    ReturnType = new CodeTypeReference(typeof (bool))
                };

                var matcher = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression("message"), "Match");
                var invoker = definition.Receives.Aggregate(matcher,
                    (current, messageType) =>
                        new CodeMethodInvokeExpression(
                            new CodeMethodReferenceExpression(current, "With", new CodeTypeReference(messageType)),
                            new CodeMethodReferenceExpression
                            {
                                MethodName = "When"
                            }));

                receive.Statements.Add(
                    new CodeMethodReturnStatement(new CodePropertyReferenceExpression(invoker, "WasHandled")));

                type.Members.Add(receive);

                var whens = definition.Receives.Select(messageType => new CodeMemberMethod
                {
                    Name = "When",
                    Attributes =
                        iface != null
                            ? MemberAttributes.Public | MemberAttributes.Abstract
                            : MemberAttributes.Family | MemberAttributes.Abstract,
                    Parameters =
                    {
                        new CodeParameterDeclarationExpression(messageType, "message")
                    }
                }).ToArray();

                iface?.Members.AddRange(whens);
                type.Members.AddRange(whens);

                ns.Types.Add(type);
            }
            return GenerateCode(unit);
        }

        private static string GenerateEnumerations(File file)
        {
            if (!file.Enums.Any())
                return null;

            var globalNs = new CodeNamespace();
            globalNs.Imports.AddRange(file.Usings.OrderBy(x => x).Select(x => new CodeNamespaceImport(x)).ToArray());

            var unit = new CodeCompileUnit();
            var ns = new CodeNamespace($"{file.Namespace}.Messages");

            unit.Namespaces.Add(globalNs);
            unit.Namespaces.Add(ns);

            foreach (var enumeration in file.Enums)
            {
                var type = new CodeTypeDeclaration(enumeration.Name)
                {
                    IsEnum = true
                };

                var fields = enumeration.Values.Select(x => new CodeMemberField(enumeration.Name, x.Name)
                {
                    InitExpression = new CodePrimitiveExpression(x.Value)
                }).ToArray();

                type.Members.AddRange(fields);

                ns.Types.Add(type);
            }

            return GenerateCode(unit);
        }

        private static string GenerateMarkers(File file)
        {
            if (!file.MarkerInterfaces.Any())
                return null;

            var globalNs = new CodeNamespace();
            globalNs.Imports.AddRange(file.Usings.OrderBy(x => x).Select(x => new CodeNamespaceImport(x)).ToArray());

            var unit = new CodeCompileUnit();
            unit.Namespaces.Add(globalNs);
            var ns = new CodeNamespace($"{file.Namespace}.Messages");
            ns.Imports.AddRange(file.Usings.OrderBy(x => x).Select(x => new CodeNamespaceImport(x)).ToArray());
            unit.Namespaces.Add(ns);

            foreach (var marker in file.MarkerInterfaces)
            {
                var type = new CodeTypeDeclaration(marker.Name)
                {
                    TypeAttributes = TypeAttributes.Sealed | TypeAttributes.Public | TypeAttributes.Interface,
                    Attributes = MemberAttributes.Public
                };

                foreach (var property in marker.Properties)
                {
                    type.Members.Add(new CodeMemberProperty
                    {
                        Name = property.Name.PascalCased(),
                        HasGet = true,
                        HasSet = false,
                        Type = new CodeTypeReference(property.Type.SafeTypeName())
                    });
                }

                ns.Types.Add(type);
            }

            return GenerateCode(unit);
        }

        private static string GenerateMessages(File file)
        {
            if (!file.Messages.Any())
                return null;

            var globalNs = new CodeNamespace();
            globalNs.Imports.AddRange(file.Usings.OrderBy(x => x).Select(x => new CodeNamespaceImport(x)).ToArray());

            var unit = new CodeCompileUnit();
            unit.Namespaces.Add(globalNs);
            var ns = new CodeNamespace($"{file.Namespace}.Messages");

            if (file.Entities.Any())
            {
                ns.Imports.Add(new CodeNamespaceImport($"{file.Namespace}.Entities"));
            }
            unit.Namespaces.Add(ns);

            foreach (var message in file.Messages)
            {
                ns.Types.Add(GenerateMessage(message));
            }

            return GenerateCode(unit);
        }


        private static string GenerateCode(CodeCompileUnit unit)
        {
            CodeDomProvider provider = new CSharpCodeProvider();

            using (var writer = new StringWriter())
            {
                provider.GenerateCodeFromCompileUnit(unit, writer, new CodeGeneratorOptions
                {
                    BlankLinesBetweenMembers = false,
                    BracingStyle = "C",
                    VerbatimOrder = false
                });

                return writer.ToString();
            }
        }

        private static CodeTypeDeclaration GenerateEntity(this Entity entity)
        {
            var type = new CodeTypeDeclaration(entity.Name)
            {
                TypeAttributes = TypeAttributes.Public,
                Attributes = MemberAttributes.Public
            };

            var properties = new List<MessageProperty>(entity.Properties);

            foreach (var prop in properties.OrderBy(x => x.Optional))
            {
                var camelCased = prop.Name.CamelCased();
                var pascalCased = prop.Name.PascalCased();

                var property = new CodeSnippetTypeMember
                {
                    Text = $"public {prop.Type.SafeTypeName()} {pascalCased} "
                };
                property.Text += "{ get; set; }\n";
                type.Members.Add(property);
            }

            return type;
        }


        private static CodeTypeDeclaration GenerateMessage(this Message message)
        {
            var type = new CodeTypeDeclaration(message.Name)
            {
                TypeAttributes = TypeAttributes.Public,
                Attributes = MemberAttributes.Public
            };

            foreach (var i in message.Interfaces.Where(x => !string.IsNullOrEmpty(x.Name)))
            {
                type.BaseTypes.Add(new CodeTypeReference(i.Name.Trim()));
            }

            var publicCtor = new CodeConstructor
            {
                Attributes = MemberAttributes.Public
            };

//            type.Members.Add(new CodeConstructor
//            {
//                Attributes = MemberAttributes.Private,
//                CustomAttributes = new CodeAttributeDeclarationCollection
//                {
//                    new CodeAttributeDeclaration("JsonConstructor")
//                }
//            });

            var properties = new List<MessageProperty>(message.Interfaces.SelectMany(i => i.Properties))
                .Union(message.Properties).Distinct(MessageProperty.NameComparer);

            foreach (var prop in properties.OrderBy(x => x.Optional))
            {
                var camelCased = prop.Name.CamelCased();
                var pascalCased = prop.Name.PascalCased();

                var property = new CodeMemberField(prop.Type, pascalCased)
                {
                    Attributes = MemberAttributes.Public
                };
                property.Name += " { get; private set; }//";
                type.Members.Add(property);

                if (pascalCased == Globals.EventGenerationDateProperty)
                {
                    //UtcGenerationDate
                    var properyReferences = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),
                        pascalCased);
                    publicCtor.Statements.Add(new CodeAssignStatement(properyReferences,
                        new CodeSnippetExpression("SystemClock.UtcNow")));
                }
                else
                {
                    var constructorArgument = new CodeParameterDeclarationExpression(prop.Type,
                        prop.Optional ? $"{camelCased} = default({prop.Type})" : camelCased);
                    publicCtor.Parameters.Add(constructorArgument);

                    var propertyReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),
                        pascalCased);
                    publicCtor.Statements.Add(new CodeAssignStatement(propertyReference,
                        new CodeArgumentReferenceExpression(camelCased)));
                }
            }

            var expression = new Regex(@"\{(.+?)\}", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            if (!string.IsNullOrEmpty(message.StringFormat))
            {
                var args = new List<CodeExpression>();
                var index = 0;
                foreach (Match match in expression.Matches(message.StringFormat))
                {
                    message.StringFormat = message.StringFormat.Replace(match.ToString(), "{" + index++ + "}");
                    var propertyName = match.Groups[1].Value.PascalCased();
                    args.Add(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), propertyName));
                }

                args.Insert(0, new CodePrimitiveExpression(message.StringFormat));

                type.Members.Add(new CodeMemberMethod
                {
                    Name = "ToString",
                    ReturnType = new CodeTypeReference(typeof (string)),
                    Attributes = MemberAttributes.Override | MemberAttributes.Public,
                    Statements =
                    {
                        new CodeMethodReturnStatement
                        {
                            Expression =
                                new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(typeof (string)),
                                    "Format", args.ToArray())
                        }
                    }
                });
            }

            type.Members.Add(publicCtor);

            type.Members.Add(message.AddSetPropertiesMethod());

            return type;
        }

        private static CodeMemberMethod AddSetPropertiesMethod(this Message message)
        {
            var type = new CodeTypeReference(message.Name.PascalCased());

            var method = new CodeMemberMethod
            {
                Name = "SetProperties",
                ReturnType = type,
                Attributes = MemberAttributes.Public
            };

            var parameters = new List<CodeExpression>();

            var properties = new List<MessageProperty>(message.Interfaces.SelectMany(i => i.Properties))
                .Union(message.Properties).Distinct(MessageProperty.NameComparer);

            foreach (var property in properties.OrderBy(x => x.Optional))
            {
                var camelCased = property.Name.CamelCased();
                var pascalCased = property.Name.PascalCased();

                if (pascalCased == Globals.EventGenerationDateProperty)
                    continue;

                var typeName = property.Type.SafeTypeName();

                method.Parameters.Add(new CodeParameterDeclarationExpression(typeName,
                    $"{camelCased} = default({typeName})"));

                var variableName = $"local{pascalCased}";
                var argumentReference = new CodeArgumentReferenceExpression(camelCased);
                var variable = new CodeVariableDeclarationStatement(typeName, variableName, argumentReference);

                method.Statements.Add(variable);

                var ifDefaultValue = new CodeBinaryOperatorExpression(argumentReference,
                    CodeBinaryOperatorType.ValueEquality,
                    new CodeDefaultValueExpression(new CodeTypeReference(typeName)));
                var variableReference = new CodeVariableReferenceExpression(variableName);

                parameters.Add(variableReference);

                var condition = new CodeConditionStatement(ifDefaultValue,
                    new CodeAssignStatement(variableReference,
                        new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), pascalCased)));

                method.Statements.Add(condition);
            }


            var create = new CodeObjectCreateExpression(type, parameters.ToArray());
            method.Statements.Add(new CodeMethodReturnStatement(create));
            return method;
        }
    }
}