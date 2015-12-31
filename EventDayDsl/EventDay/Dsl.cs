// Copyright (C) 2015 EventDay, Inc

using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;
using EventDayDsl.EventDay.Entities;
using EventDayDsl.EventDay.Language;

namespace EventDayDsl.EventDay
{
    internal class Dsl : GrammarBaseVisitor<string>
    {
        private string _commandType;
        private string _currentMessageName;
        private string _eventType;

        public Dsl(string name)
        {
            Name = name;
            File = new File(name);
        }

        public string Name { get; set; }
        public File File { get; }

        public override string VisitStateDefinition(GrammarParser.StateDefinitionContext context)
        {
            var stateName = VisitTerminal(context.state_name().ID());

            var definition = new StateDefinition(File.Namespace)
            {
                Name = stateName
            };

            var interfaceContext = context.stateDefinitionInterface();
            if (interfaceContext != null)
                definition.Interface = VisitTerminal(interfaceContext.ID());

            File.StateDefinitions.Add(definition);

            return context.GetText();
        }

        public override string VisitEnumDefinition(GrammarParser.EnumDefinitionContext context)
        {
            var name = VisitTerminal(context.type().ID());

            var @enum = new Enumeration(name);
            foreach (var member in context.enumMemberList().enumMember())
            {
                var valueContext = member.enumMemberValue();
                var memberValue = int.Parse(VisitTerminal(valueContext.INTEGER()));
                var memberName = VisitTerminal(member.name().ID());
                @enum.Values.Add(new EnumerationValue(memberName, memberValue));
            }
            File.Enums.Add(@enum);
            return context.ToString();
        }

        public override string VisitStateApplicationList(GrammarParser.StateApplicationListContext context)
        {
            foreach (var applicationContext in context.stateApplication())
            {
                VisitStateApplication(applicationContext);
            }

            return context.GetText();
        }

        public override string VisitStateApplication(GrammarParser.StateApplicationContext context)
        {
            var stateName = VisitTerminal(context.ID());

            File.StateDefintionReceive(stateName, _currentMessageName);
            return context.GetText();
        }

        public override string VisitImportAssingment(GrammarParser.ImportAssingmentContext context)
        {
            var ns = string.Join(".", context.@namespace().ID().Select(VisitTerminal));
            File.Usings.Add(ns);
            return context.GetText();
        }

        public override string VisitNamespaceAssignment(GrammarParser.NamespaceAssignmentContext context)
        {
            var ns = string.Join(".", context.@namespace().ID().Select(VisitTerminal));
            File.Namespace = ns;
            return context.GetText();
        }

        public override string VisitConstant(GrammarParser.ConstantContext context)
        {
            var name = VisitTerminal(context.name().ID());
            var type = VisitTerminal(context.type().ID());
            var typeArguments = context.type().typeArguments();
            if (typeArguments != null)
            {
                type += typeArguments.GetText();
            }
            var modifier = context.type().typeModifier();
            var isOptional = modifier?.OPTIONAL() != null;

            var optionalName = context.optionalName();
            if (optionalName == null)
                File.AddPropertyDefinition(name, type, isOptional);
            else
                File.AddPropertyDefinition(name, VisitTerminal(optionalName.ID()), type, isOptional);
            return context.GetText();
        }

        public override string VisitCommandAssignment(GrammarParser.CommandAssignmentContext context)
        {
            _commandType = string.Join(", ", context.type().Select(t =>
            {
                var type = VisitTerminal(t.ID());
                if (t.typeArguments() != null)
                {
                    type += t.typeArguments().GetText();
                }
                return type;
            }));
            return context.GetText();
        }

        public override string VisitEventAssignment(GrammarParser.EventAssignmentContext context)
        {
            _eventType = string.Join(", ", context.type().Select(t =>
            {
                var type = VisitTerminal(t.ID());
                if (t.typeArguments() != null)
                {
                    type += t.typeArguments().GetText();
                }
                return type;
            }));
            return context.GetText();
        }

        public override string VisitMarkerDefinition(GrammarParser.MarkerDefinitionContext context)
        {
            var name = VisitTerminal(context.ID());

            var item = new MarkerInterface(name);
            var argumentList = context.argumentList();
            if (argumentList != null)
            {
                foreach (var argument in argumentList.argument())
                {
                    var tuple = ReadProperty(argument);
                    item.AddProperty(tuple.Item1, tuple.Item2, tuple.Item3);
                }
            }
            File.MarkerInterfaces.Add(item);
            return context.GetText();
        }

        public override string VisitEntityDefinition(GrammarParser.EntityDefinitionContext context)
        {
            var interfaces = new HashSet<MarkerInterface>(MarkerInterface.NameComparer);
            var markerList = context.markerList();
            if (markerList != null)
            {
                foreach (var iface in markerList.marker())
                {
                    var iname = VisitTerminal(iface.ID());
                    var definedInterface = File.MarkerInterfaces.First(x => x.Name == iname);
                    if (definedInterface != null)
                        interfaces.Add(definedInterface);
                }
            }

            var name = VisitTerminal(context.type().ID());

            var entity = new Entity(name, interfaces);
            foreach (var argument in context.argumentList().argument())
            {
                if (argument == null)
                    continue;

                var tuple = ReadProperty(argument);
                entity.AddProperty(tuple.Item1, tuple.Item2, tuple.Item3);
            }

            var stringContext = context.toString();
            if (stringContext != null)
            {
                entity.StringFormat = VisitTerminal(stringContext.TO_STRING());
            }

            File.Entities.Add(entity);

            return context.GetText();
        }

        public override string VisitMessageDefinition(GrammarParser.MessageDefinitionContext context)
        {
            var type = "";
            var isEvent = context.EVENT() != null;

            if (isEvent)
            {
                type = _eventType;
            }
            if (context.CMD() != null)
            {
                type = _commandType;
            }

            var interfaces = new HashSet<MarkerInterface>(MarkerInterface.NameComparer) {new MarkerInterface(type)};
            var markerList = context.markerList();
            if (markerList != null)
            {
                foreach (var iface in markerList.marker())
                {
                    var iname = VisitTerminal(iface.ID());
                    var definedInterface = File.MarkerInterfaces.First(x => x.Name == iname);
                    if (definedInterface != null)
                        interfaces.Add(definedInterface);
                }
            }

            var name = VisitTerminal(context.type().ID());
            _currentMessageName = name;
            var message = new Message(name, interfaces);
            File.Messages.Add(message);
            foreach (var argument in context.argumentList().argument())
            {
                if (argument == null)
                    continue;

                var tuple = ReadProperty(argument);
                message.AddProperty(tuple.Item1, tuple.Item2, tuple.Item3);
            }

            if (isEvent)
                message.AddProperty(Globals.EventGenerationDateProperty, "DateTime");

            var stringContext = context.toString();
            if (stringContext != null)
            {
                message.StringFormat = VisitTerminal(stringContext.TO_STRING());
            }

            foreach (var stateApplicationListContext in context.stateApplicationList())
            {
                VisitStateApplicationList(stateApplicationListContext);
            }

            return context.GetText();
        }

        private Tuple<string, string, bool> ReadProperty(GrammarParser.ArgumentContext argument)
        {
            var type = VisitTerminal(argument.type().ID());
            var typeArguments = argument.type().typeArguments();
            if (typeArguments != null)
            {
                type += typeArguments.GetText();
            }
            string name;

            var modifier = argument.type().typeModifier();
            var isOptional = modifier?.OPTIONAL() != null;

            if (argument.name() == null)
            {
                name = VisitTerminal(argument.type().ID());
                var definition = File.FindPropertyDefinition(name);
                if (string.IsNullOrEmpty(definition?.Item1))
                    throw new Exception($"Tried to use an undefined property '{name}'");

                type = definition.Item2;
                name = definition.Item1;
                isOptional = definition.Item3 || isOptional;
            }
            else
            {
                name = VisitTerminal(argument.name().ID());
            }

            return Tuple.Create(name, type, isOptional);
        }

        public override string VisitTerminal(ITerminalNode node)
        {
            return node.GetText();
        }
    }
}