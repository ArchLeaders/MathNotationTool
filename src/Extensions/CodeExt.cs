using AngouriMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationTool.Extensions
{
    public static class CodeExt
    {
        public static decimal Query(string id)
        {
            return ViewModel.Calculator.ViewModel.History.Where(x => x.Name == id).FirstOrDefault()?.Value ??
                throw new KeyNotFoundException($"Could not find entry '{id}' in Calculator History.");
        }

        public static decimal Query(int index)
        {
            return ViewModel.Calculator.ViewModel.History.Where(x => x.Name == index.ToString()).FirstOrDefault()?.Value ??
                throw new KeyNotFoundException($"Could not find entry '{index}' in Calculator History.");
        }
    }
}
