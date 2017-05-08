using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EDLogParser.LogEntries {
    public class LogEntryBase {
        public DateTime TimeStamp;
        public string Event;

        public Dictionary<string, object> RawData;

        public LogEntryBase(Dictionary<string, object> rawdata) {
            RawData = rawdata;
            if (rawdata.ContainsKey("timestamp")) {
                TimeStamp = Convert.ToDateTime(rawdata["timestamp"]);
                rawdata.Remove("timestamp");
            }
            if (rawdata.ContainsKey("event")) {
                Event = (string)rawdata["event"];
                rawdata.Remove("event");
            }

            PopulateProperties(this, rawdata);
        }

        private void PopulateProperties(object target, Dictionary<string, object> rawdata) {
            foreach (var propertyInfo in target.GetType().GetProperties()) {
                if (propertyInfo.PropertyType == typeof(double))
                    propertyInfo.SetValue(target, double.NaN);
            }
            foreach (var rawVar in rawdata) {
                var rawType = rawVar.Value.GetType().Name;
                var prop = target.GetType().GetProperty(rawVar.Key);
                if (prop == null) {
                    Debug.WriteLine($"Missing property '{rawVar.Key}' of type '{rawType}' in '{target.GetType().Name}'.");
                } else {
                    if (rawType.StartsWith("List")) {
                        var list = (List<object>)rawVar.Value;
                        if (list.Count == 0)
                            continue;
                        var listType = list[0].GetType().Name;
                        if (listType.StartsWith("Double"))
                            prop.SetValue(target, list.OfType<double>().ToList());
                        else if (listType.StartsWith("String"))
                            prop.SetValue(target, list.OfType<string>().ToList());
                        else {
                            var genericType = prop.PropertyType.GetGenericArguments()[0];
                            var genericTypeName = genericType.Name;
                            var genericListType = typeof(List<>).MakeGenericType(genericType);
                            var listInstance = (IList)Activator.CreateInstance(genericListType);
                            foreach (var listObj in list) {
                                var type = Type.GetType($"EDLogParser.LogEntries.{genericTypeName}");
                                var obj = Activator.CreateInstance(type);
                                var subRawData = (Dictionary<string, object>)listObj;
                                PopulateProperties(obj, subRawData);
                                listInstance.Add(obj);
                            }
                            prop.SetValue(target, listInstance);
                        }
                        continue;
                    }
                    prop.SetValue(target, rawVar.Value);
                }
            }
        }
    }
}