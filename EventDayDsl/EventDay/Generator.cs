using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using EventDayDsl.EventDay.Language;
// ReSharper disable AssignNullToNotNullAttribute

namespace EventDayDsl.EventDay
{
    public static class Generator
    {
        public static IEnumerable<string> GenerateFile(string file)
        {
            var name = Path.GetFileNameWithoutExtension(file);
            var directory = Path.GetDirectoryName(file);
            Entities.File representation;

            using (var stream = File.OpenRead(file))
            {
                var lexer = new GrammarLexer(new AntlrInputStream(stream));
                var tokenStream = new CommonTokenStream(lexer);
                var context = new GrammarParser(tokenStream).program();

                var dsl = new Dsl(name);
                dsl.Visit(context);
                representation = dsl.File;
            }

            var outputs = representation.GenerateSource();

            if (outputs.HasMessageContent)
            {
                if (outputs.HasMarkers)
                {
                    var path = Path.Combine(directory, $"{representation.Name}MarkerInterfaces.cs");
                    File.WriteAllText(path, outputs.Markers);
                    yield return path;
                }

                if (outputs.HasMessages)
                {
                    var path = Path.Combine(directory, $"{representation.Name}Messages.cs");
                    File.WriteAllText(path, outputs.Messages);
                    yield return path;
                }

                if (outputs.HasEnumerations)
                {
                    var path = Path.Combine(directory, $"{representation.Name}Enums.cs");
                    File.WriteAllText(path, outputs.Enumerations);
                    yield return path;
                }
            }

            if (outputs.HasStateDefinitions)
            {
                var path = Path.Combine(directory, $"{representation.Name}StateSubscriptions.cs");
                File.WriteAllText(path, outputs.StateDefinitions);
                yield return path;
            }

            if (outputs.HasEntities)
            {
                var path = Path.Combine(directory, $"{representation.Name}Entities.cs");
                File.WriteAllText(path, outputs.Entities);
                yield return path;
            }
        }
    }
}