using AngouriMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationTool.Extensions
{
    public static class CodeExt
    {
        public static decimal Query(int index)
        {
            try {
                return ViewModel.Calculator.ViewModel.History[index-1].Value;
            }
            catch {
                return 0;
            }
        }

        public static decimal Query(string name)
        {
            return ViewModel.Calculator.ViewModel.History.Where(x => x.Name == name).FirstOrDefault()?.Value ?? 0;
        }

        public static decimal Query(char indxchar)
        {
            try {
                return ViewModel.Calculator.ViewModel.History[indxchar-1].Value;
            }
            catch {
                return 0;
            }
        }
    }
}
