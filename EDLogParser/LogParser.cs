using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

using EDLogParser.LogEntries;

namespace EDLogParser
{
    public class LogParser
    {
        private static readonly List<char> NumberChars = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-', '+' };

        private FileStream fs;
        private BinaryReader br;
        private int currentLinePos;

        public int CurrentLine { get; private set; }

        public int CurrentColumn => (int)fs.Position - currentLinePos;

        public string Path { get; private set; }

        public LogParser(string path) {
            Path = path;
            if (!File.Exists(path))
                throw new FileNotFoundException($"File '{path}' could not be found.");
            fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            br = new BinaryReader(fs);
            CurrentLine = 1;
        }

        public LogEntryBase ReadEntry() {
            var entryData = ReadVariables();
            ConsumeWhiteSpace();
            if (br.PeekChar() == '\r')
                br.ReadChar();
            if (br.PeekChar() == '\n') {
                br.ReadChar();
                CurrentLine++;
                currentLinePos = (int)fs.Position;
            }


            if (entryData.Count == 0)
                return null;

            var typeName = (string)entryData["event"];
            var type = Type.GetType($"EDLogParser.LogEntries.{typeName}");
            LogEntryBase logEntry = null;
            if (type != null) {
                logEntry = (LogEntryBase)Activator.CreateInstance(type, entryData);
            }
            //var entryBase = new LogEntryBase(entryData);
            return logEntry;
        }

        private void ConsumeWhiteSpace() {
            while (br.PeekChar() == ' ' || br.PeekChar() == '\t')
                br.ReadChar();
        }

        private void Ensure(char check, char expected, string message = null) {
            if (check != expected)
                throw new InvalidOperationException($"Got wrong character '{check}' but expected '{expected}' at position {fs.Position} on line {CurrentLine} column {CurrentColumn}{(message == null ? "." : " when " + message)}");
        }

        private Dictionary<string, object> ReadVariables() {
            var result = new Dictionary<string, object>();
            try {
                ConsumeWhiteSpace();
                Ensure(br.ReadChar(), '{', "expecting start of variables entry.");
                ConsumeWhiteSpace();
            } catch (EndOfStreamException) {
                return result;
            }
            var more = true;
            while (more) {
                var name = ReadString();
                ConsumeWhiteSpace();
                Ensure(br.ReadChar(), ':');
                var ch = (char)br.PeekChar();
                switch (ch) {
                    case '{':
                        br.ReadChar();
                        ConsumeWhiteSpace();
                        result.Add(name, ReadVariables());
                        break;
                    case '[':
                        result.Add(name, ReadArray());
                        break;
                    case '"':
                        result.Add(name, ReadString());
                        break;
                    default:
                        if (NumberChars.Contains(ch)) {
                            var number = ReadNumber();
                            if (!double.IsNaN(number))
                                result.Add(name, number);
                            else
                                throw new InvalidOperationException($"Read a non number at position {fs.Position} on line {CurrentLine} column {CurrentColumn}.");
                        } else if (ch == 't' || ch == 'f')
                            result.Add(name, ReadTrueFalse());
                        else {
                            result.Add(name, double.PositiveInfinity);
                            fs.Seek(3, SeekOrigin.Current);
                        }
                        break;
                }
                if (br.PeekChar() != ',') {
                    more = false;
                    ConsumeWhiteSpace();
                    Ensure(br.ReadChar(), '}', "expecting end of variables entry.");
                    ConsumeWhiteSpace();
                } else {
                    br.ReadChar();
                    ConsumeWhiteSpace();
                }
            }
            return result;
        }

        private bool ReadTrueFalse() {
            var data = "";
            for (var i = 0; i < 4; i++)
                data += br.ReadChar();
            if (data == "true")
                return true;
            data += br.ReadChar();
            if (data == "false")
                return false;
            throw new InvalidOperationException($"Attempt to read TRUE/FALSE failed at position {fs.Position} on line {CurrentLine} column {CurrentColumn}.");
        }

        private List<object> ReadArray() {
            var result = new List<object>();
            br.ReadChar();
            ConsumeWhiteSpace();
            var more = true;
            while (more) {
                switch (br.PeekChar()) {
                    case '{':
                        result.Add(ReadVariables());
                        break;
                    case ']':
                        break;
                    case '"':
                        result.Add(ReadString());
                        break;
                    default:
                        result.Add(ReadNumber());
                        break;
                }
                if (br.PeekChar() != ',') {
                    ConsumeWhiteSpace();
                    Ensure(br.ReadChar(), ']', "expecting end of array.");
                    ConsumeWhiteSpace();
                    more = false;
                }
                else {
                    br.ReadChar();
                    ConsumeWhiteSpace();
                }
            }
            return result;
        }

        private double ReadNumber() {
            double result;
            var data = "";
            var peekChar = (char)br.PeekChar();
            while (NumberChars.Contains(peekChar) || peekChar == 'e') {
                data += br.ReadChar();
                peekChar = (char)br.PeekChar();
            }
            return double.TryParse(data, out result) ? result : double.NaN;
        }

        private string ReadString() {
            var result = "";
            Ensure(br.ReadChar(), '"', "expecting string.");
            char ch;
            bool escaped = false;
            while (true) {
                ch = br.ReadChar();
                if (ch == '"' && !escaped)
                    break;
                result += ch;
                escaped = ch == '\\';
            }
            return result;
        }
    }
}
