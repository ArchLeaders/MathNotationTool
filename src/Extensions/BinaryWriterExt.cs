using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationTool.Extensions
{
    public static class BinaryWriterExt
    {
        public static uint WriteString(this BinaryWriter writer, string value)
        {
            int size = 4 + value.Length;
            writer.Write((uint)value.Length);
            writer.Write(value.ToCharArray());
            return (uint)size;
        }
    }
}
