using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Notifications.Client.Interop
{
    public static class PropertiesManager
    {

        private static Dictionary<string, object> _properties = new Dictionary<string, object>();
        

        public static object GetProperty(string key)
        {
            key = key.ToLower();
            if (!_properties.ContainsKey(key))
                return null;
            else
                try { return _properties[key]; }
                catch (Exception ex) { return null; }
        }

        public static void SetProperty(string key, object value)
        {
            key = key.ToLower();
            if (_properties.ContainsKey(key))
                _properties[key] = value;
            else
                _properties.Add(key, value);
        }

        public static bool ContainsKey(string key)
        {
            key = key.ToLower();
            return _properties.ContainsKey(key);
        }

        public static readonly Dictionary<string, Dictionary<string, string>> InIFile;

        static PropertiesManager()
        {
            InIFile = (from Match m in Regex.Matches(System.IO.File.ReadAllText("settings.ini"), INIpattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline)
                       select new
                       {
                           Section = m.Groups["Section"].Value,

                           kvps = (from cpKey in m.Groups["Key"].Captures.Cast<Capture>().Select((a, i) => new { a.Value, i })
                                   join cpValue in m.Groups["Value"].Captures.Cast<Capture>().Select((b, i) => new { b.Value, i }) on cpKey.i equals cpValue.i
                                   select new KeyValuePair<string, string>(cpKey.Value, cpValue.Value)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value)

                       }).ToDictionary(itm => itm.Section, itm => itm.kvps);
        }

        private static readonly string INIpattern = @"
^                           # Beginning of the line
((?:\[)                     # Section Start
     (?<Section>[^\]]*)     # Actual Section text into Section Group
 (?:\])                     # Section End then EOL/EOB
 (?:[\r\n]{0,}|\Z))         # Match but don't capture the CRLF or EOB
 (                          # Begin capture groups (Key Value Pairs)
  (?!\[)                    # Stop capture groups if a [ is found; new section
  (?<Key>[^=]*?)            # Any text before the =, matched few as possible
  (?:=)                     # Get the = now
  (?<Value>[^\r\n]*)        # Get everything that is not an Line Changes
  (?:[\r\n]{0,4})           # MBDC \r\n
  )+                        # End Capture groups";
    
    }
}
