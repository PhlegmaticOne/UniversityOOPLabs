using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataValidation.Lab5
{
    internal static class StringExtensions
    {
        internal static string Copy(this string source)
        {
            return new string(source.ToCharArray());
        }
    }
}
