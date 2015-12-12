// Copyright (C) 2015 EventDay, Inc

using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using EventDayDsl.EventDay.Language;
using File = EventDayDsl.EventDay.Entities.File;

// ReSharper disable AssignNullToNotNullAttribute

namespace EventDayDsl.EventDay
{
    public static class Generator
    {
        public static IEnumerable<string> GenerateFile(string file)
        {
            var name = Path.GetFileNameWithoutExtension(file);
            var directory = Path.GetDirectoryName(file);
            File representation;

            using (var stream = System.IO.File.OpenRead(file))
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
                    System.IO.File.WriteAllText(path, outputs.Markers);
                    yield return path;
                }

                if (outputs.HasMessages)
                {
                    var path = Path.Combine(directory, $"{representation.Name}Messages.cs");
                    System.IO.File.WriteAllText(path, outputs.Messages);
                    yield return path;
                }

                if (outputs.HasEnumerations)
                {
                    var path = Path.Combine(directory, $"{representation.Name}Enums.cs");
                    System.IO.File.WriteAllText(path, outputs.Enumerations);
                    yield return path;
                }
            }

            if (outputs.HasStateDefinitions)
            {
                var path = Path.Combine(directory, $"{representation.Name}StateSubscriptions.cs");
                System.IO.File.WriteAllText(path, outputs.StateDefinitions);
                yield return path;
            }

            if (outputs.HasEntities)
            {
                var path = Path.Combine(directory, $"{representation.Name}Entities.cs");
                System.IO.File.WriteAllText(path, outputs.Entities);
                yield return path;
            }
        }
    }
}