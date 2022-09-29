using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MathNotationTool.ViewModels
{
    public class CalculatorViewModel : ReactiveObject
    {

        private string current = "";
        public string Current {
            get => current;
            set => this.RaiseAndSetIfChanged(ref current, value);
        }

        public void Print() => Debug.WriteLine(Current);

        /// <summary>
        /// Clear functions (CE)
        /// </summary>
        /// <param name="_"></param>
        public void Function_CE(string _) => Current = "";

        /// <summary>
        /// Equals functions (=)
        /// </summary>
        /// <param name="_"></param>
        public void Function_Equals(string _) => Current = "";

        /// <summary>
        /// generic calc function
        /// </summary>
        /// <param name="key"></param>
        public void Function_Generic(string key) => Current += $"{(Current == "" || Current.LastOrDefault() == '(' || (int.TryParse(Current.LastOrDefault().ToString(), out int _) && int.TryParse(key.Split('|')[0], out int _)) ? "" : " ")}{key.Split('|')[0]}";
            // var _a1 = Current == "";
            // var _a2 = Current.LastOrDefault() == '(';
            // var _a3 = int.TryParse(Current.LastOrDefault().ToString(), out int _);
            // var _a4 = int.TryParse(key.Split('|')[0], out int _);
            // var _a3_a4 = _a3 && _a4;
            // 
            // Debug.WriteLine($"{_a1} {_a2} {_a3} {_a4} {_a3_a4}");
            // Current += $"{(_a1 || _a2 || (_a3 && _a4) ? "" : " ")}{key.Split('|')[0]}";

        /// <summary>
        /// Common boolean button function
        /// </summary>
        /// <param name="key"></param>
        public void Function_Boolean(string key)
        {
            Dictionary<string, string> unicodeKeys = new() {
                { "\u221A", "sqrt" },
                { "(/)", "" }
            };

            bool state = bool.Parse(key.Split('|')[1]);
            key = key.Split('|')[0];

            foreach (var unicodeKey in unicodeKeys) {
                key = key.Replace(unicodeKey.Key, unicodeKey.Value);
            }

            if (Current.EndsWith($"{key}(")) {
                var len = $"{key}(".Length;
                Current = Current.Remove(Current.Length - len, len);
            }
            else {
                if (state == true) {
                    Current += $"{key}(";
                }
                else {
                    Current += $")";
                }
            }
        }
    }
}
