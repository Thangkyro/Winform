using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreBase.Helpers
{
    public static class StringLibrary
    {
        public static string Right(string param, int len)
        {
            string result = param.Substring(param.Length-len, len);
            return result;
        }

        public static bool IsNumber(string param)
        {
            double number;
            return double.TryParse(param, out number);
        }
    }
}
