using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Client.Interop
{
    public static class PropertiesManager
    {

        private static Dictionary<string, object> _properties = new Dictionary<string, object>();
        private static IniFile settingsFile = new IniFile(System.IO.Path.Combine(Environment.CurrentDirectory,"settings.ini"));

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

        public static string getSetting(string group, string key)
        {
            return settingsFile.IniReadValue(group, key);
        }
    }
}
