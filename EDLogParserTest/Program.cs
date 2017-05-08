using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using EDLogParser;
using EDLogParser.LogEntries;

namespace EDLogParserTest {
    class Program {
        static void Main(string[] args) {
            var assemblyLocation = Assembly.GetExecutingAssembly().Location;
            if (assemblyLocation == null)
                return;
            var fi = new FileInfo(assemblyLocation);
            var location = fi.DirectoryName;
            if (location == null)
                return;

            var allData = new List<LogEntryBase>();
            var files = Directory.GetFiles(location + @"\logs", "*.log");
            //var parser = new LogParser(location + @"\logs\Journal.170430071650.01.log");
            var list = new List<string>();
            foreach (var file in files) {
                //Console.WriteLine(file);
                var parser = new LogParser(file);
                while (true) {
                    var temp = parser.ReadEntry();
                    if (temp == null)
                        break;
                    allData.Add(temp);
                    if (!list.Contains(temp.Event)) {
                        list.Add(temp.Event);
                        OutputEventProps(temp);
                    }
                }
            }
            Console.ReadKey(true);
        }

        private static void OutputEventProps(LogEntryBase entry) {
            Console.WriteLine($"public class {entry.Event} : LogEntryBase {{");
            OutputRawData(entry, 0);
            Console.WriteLine();
            Console.WriteLine($"    public {entry.Event}(Dictionary<string, object> rawData) : base(rawData) {{\n    }}");
            Console.WriteLine("}");
            Console.WriteLine();
        }

        private static void OutputRawData(LogEntryBase entry, int depth) {
            var padLeft = new string(' ', 4 + depth);
            foreach (var rawData in entry.RawData) {
                if (rawData.Key == "event" || rawData.Key == "timestamp")
                    continue;
                var typeName = rawData.Value.GetType().Name;
                if (!typeName.StartsWith("List"))
                    typeName = typeName.ToLower();
                else {
                    var list = (List<object>)rawData.Value;
                    if (list.Count > 0) {
                        var type = list[0].GetType();
                        if (!type.Name.StartsWith("Dictionary"))
                            typeName = $"List<{type.Name.ToLower()}>";
                        else
                            typeName = $"List<{rawData.Key}>";
                    }
                }
                Console.WriteLine($"{padLeft}public {typeName} {rawData.Key} {{ get; set; }}");
            }
        }
    }
}
