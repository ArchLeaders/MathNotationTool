﻿using AngouriMath;
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
        public static decimal Query(int index)
        {
            try {
                return ViewModel.Calculator.ViewModel.History[index-1].Value;
            }
            catch {
                throw new KeyNotFoundException($"Could not find entry '{index}' in Calculator History.");
            }
        }
    }
}
