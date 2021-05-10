using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CoreBase.Helpers
{
    public static class ExtensionMethods
    {
        public static string zToString(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return "";

            return obj.ToString();
        }
        public static int zToInt(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return 0;
            int ret = 0;
            try
            {
                ret = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                ErrorProcess.HandleException(ex);

            }
            return ret;
        }
        public static bool zToBool(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return false;
            bool ret = false;
            try
            {
                ret = bool.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                ErrorProcess.HandleException(ex);

            }
            return ret;
        }
        public static DateTime zToDateTime(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return new DateTime(1900, 1, 1);
            DateTime ret = new DateTime(1900, 1, 1);
            try
            {
                ret = (DateTime)obj;
            }
            catch (Exception ex)
            {
                ErrorProcess.HandleException(ex);

            }
            return ret;
        }
        public static decimal zToDecimal(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return 0;
            decimal ret = 0;
            try
            {
                ret = decimal.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                ErrorProcess.HandleException(ex);

            }
            return ret;
        }
        public static void FromHtml(this Color c, string s)
        {
            if (string.IsNullOrEmpty(s))
                return;

            c = ColorTranslator.FromHtml(s);
        }
        public static Color zFromHex(this Color c, string hex)
        {
            int argb = 0;
            if (hex.StartsWith("#"))
            {
                argb = int.Parse("ff" + hex.Substring(1, hex.Length - 1), NumberStyles.HexNumber);
                
            }
            else
                argb = int.Parse("ff" + hex, NumberStyles.HexNumber);
            return Color.FromArgb(argb);
        }
        public static string zToHex(this Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");

        }
        public static Color ToColor(this uint argb)
        {
            return Color.FromArgb((byte)((argb & -16777216) >> 0x18),
                                  (byte)((argb & 0xff0000) >> 0x10),
                                  (byte)((argb & 0xff00) >> 8),
                                  (byte)(argb & 0xff));
        }

    }
}
