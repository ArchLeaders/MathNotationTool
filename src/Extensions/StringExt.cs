using MathNotationTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationTool.Extensions
{
    internal static class StringExt
    {
        public static string GetSafe(this string str)
        {
            for (int i = 0; i < CalculatorViewModel.BadChars.Length; i++) {
                str = str.Replace(CalculatorViewModel.BadChars[i][0].ToString(), CalculatorViewModel.BadChars[i][1..]);
            }
            return str;
        }
    }
}
