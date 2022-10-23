﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

using Chsword;

namespace CSO2_ComboLauncher
{
    static class Json
    {
        public static dynamic Parse(string jsonstring)
        {
            // JDynamic doesn't support \" in json string.
            jsonstring = jsonstring.Replace("\\\"", "'");

            Regex regex = new Regex(@"\\u[a-zA-Z0-9]{4}");
            MatchCollection mc = regex.Matches(jsonstring);
            foreach (Match match in mc)
            {
                string text = match.Value;
                jsonstring = jsonstring.Replace(text, Misc.UnicodeToString(text));
            }

            return new JDynamic(jsonstring);
        }

        public static string ReadValue(dynamic parsedjson, string key)
        {
            return parsedjson[key].ToString();
        }

        public static List<string> ReadArray(dynamic array)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < array.Length; i++)
                result.Add(array[i].ToString());
            return result;
        }
    }
}