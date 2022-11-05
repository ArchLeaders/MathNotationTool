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
        public static decimal Query(int id)
        {
            return ViewModel.Calculator.ViewModel.History.Where(x => x.Id == id).FirstOrDefault()?.Value ??
                throw new KeyNotFoundException($"Could not find entry '{id}' in Calculator History.");
        }
    }
}
