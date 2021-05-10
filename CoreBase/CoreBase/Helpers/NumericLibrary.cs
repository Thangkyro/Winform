/* Author: Chungtv # May 11, 2011
 * Purpose: Lớp thư viện chứa các hàm và thủ tục xử lý dữ liệu dạng số
 * Modify log:
 *      Date | Author | Description
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreBase.Helpers
{
    public static class NumericLibrary
    {
        public static bool IsNumeric(object expression)
        {
            return IsNumeric(expression);
        }

        
        /// <summary>
        /// Đổi số chữ tiếng việt với tham số truyền vào kiểu double
        /// </summary>
        /// <param name="dboSo">số kiểu double</param>
        /// <param name="strDVT">chuỗi tên đơn vị tiền</param>
        /// <returns>Chuỗi chữ đọc từ số</returns>
        public static string DOI_SO_CHU(object dboSo, string strDVT)
        {
            int num2;
            int num3;
            string[] strArray = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string str = "";
            string str2 = "";
            string str6 = "";
            string str7 = "";
            string str3 = "";
            string str4 = "";

            double dblSo = Convert.ToDouble(dboSo);

            if (dblSo < 0.0)
            {
                dblSo = -dblSo;
                str2 = str2 + " âm";
            }
            //decimal num = new decimal(dblSo - Convert.ToInt64(dblSo));
            string snum = "0.0";
            if (dblSo.ToString().IndexOf(".") > 0)
                snum = "0" + dblSo.ToString().Substring(dblSo.ToString().IndexOf("."));
            decimal num = Convert.ToDecimal(snum);
            if (dblSo == 0.0)
            {
                str2 = "không.";
            }
            else
            {
                if (dblSo.ToString().IndexOf(".") > 0)
                    str6 = dblSo.ToString().Substring(0, dblSo.ToString().IndexOf("."));
                else
                    str6 = dblSo.ToString();

                if ((str6.Trim().Length % 3) == 1)
                {
                    str6 = "00" + str6.Trim();
                }
                if ((str6.Trim().Length % 3) == 2)
                {
                    str6 = "0" + str6.Trim();
                }
                num2 = (int)Math.Round((double)(((double)str6.Trim().Length) / 3.0));
                for (num3 = num2; num3 >= 1; num3 += -1)
                {
                    str4 = str6.Trim().Substring(str6.Trim().Length - (num3 * 3), 3);
                    if (DOI_SO_CHU_NHOM(str4, num3, num2).Trim().Length > 0)
                    {
                        if (num3 < 5)
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim() + ",";
                        }
                        else
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim();
                        }
                    }
                    else
                    {
                        str2 = str2 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim();
                    }
                }
            }
            str2 = str2.Trim();
            str2 = str2.Substring(0, str2.Length - 1);
            if (decimal.Compare(num, decimal.Zero) > 0)
            {
                str7 = num.ToString("0.######").Trim();
                //str7 = Convert.ToString(num).Trim();
                str7 = str7.Substring(2, str7.Length - 2);
                while (str7.Substring(str7.Length - 1, 1) == "0")
                {
                    str7 = str7.Substring(0, str7.Length - 1);
                }
                if (str7.Substring(0, 1) != "0")
                {
                    if ((str7.Trim().Length % 3) == 1)
                    {
                        str7 = "00" + str7.Trim();
                    }
                    if ((str7.Trim().Length % 3) == 2)
                    {
                        str7 = "0" + str7.Trim();
                    }
                    num2 = (int)Math.Round((double)(((double)str7.Trim().Length) / 3.0));
                    for (num3 = num2; num3 >= 1; num3 += -1)
                    {
                        str4 = str7.Trim().Substring(str7.Trim().Length - (num3 * 3), 3);
                        str3 = str3 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim();
                    }
                }
                else
                {
                    int num5 = str7.Length - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        string expression = str7.Substring(i, 1);
                        str3 = str3 + " " + strArray[Convert.ToInt32(expression)].Trim();
                    }
                }
                str = str2.Trim() + " phẩy " + str3.Trim() + " " + strDVT.Trim();
            }
            else
            {
                str = str2.Trim() + " " + strDVT.Trim();
            }
            str.Trim();
            return (str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1)).Replace(",", "");
        }
        
        /// <summary>
        /// Đổi số chữ tiếng việt với tham số truyền vào kiểu double
        /// </summary>
        /// <param name="dboSo">số kiểu double</param>
        /// <param name="strDVT">chuỗi tên đơn vị tiền</param>
        /// <param name="strDVT2">chuỗi tên đơn vị sau phần thập phân của số</param>
        /// <returns>Chuỗi chữ đọc từ số</returns>
        public static string DOI_SO_CHU(object dboSo, string strDVT, string strDVT2)
        {
            int num2;
            int num3;
            string[] strArray = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string str = "";
            string str2 = "";
            string str6 = "";
            string str7 = "";
            string str3 = "";
            string str4 = "";

            double dblSo = Convert.ToDouble(dboSo);

            if (dblSo < 0.0)
            {
                dblSo = -dblSo;
                str2 = str2 + " âm";
            }
            //decimal num = new decimal(dblSo - Convert.ToInt64(dblSo));
            string snum = "0.0";
            if (dblSo.ToString().IndexOf(".") > 0)
                snum = "0" + dblSo.ToString().Substring(dblSo.ToString().IndexOf("."));
            decimal num = Convert.ToDecimal(snum);
            if (dblSo == 0.0)
            {
                str2 = "không.";
            }
            else
            {
                if (dblSo.ToString().IndexOf(".") > 0)
                    str6 = dblSo.ToString().Substring(0, dblSo.ToString().IndexOf("."));
                else
                    str6 = dblSo.ToString();

                if ((str6.Trim().Length % 3) == 1)
                {
                    str6 = "00" + str6.Trim();
                }
                if ((str6.Trim().Length % 3) == 2)
                {
                    str6 = "0" + str6.Trim();
                }
                num2 = (int)Math.Round((double)(((double)str6.Trim().Length) / 3.0));
                for (num3 = num2; num3 >= 1; num3 += -1)
                {
                    str4 = str6.Trim().Substring(str6.Trim().Length - (num3 * 3), 3);
                    if (DOI_SO_CHU_NHOM(str4, num3, num2).Trim().Length > 0)
                    {
                        if (num3 < 5)
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim() + ",";
                        }
                        else
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim();
                        }
                    }
                    else
                    {
                        str2 = str2 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim();
                    }
                }
            }
            str2 = str2.Trim();
            str2 = str2.Substring(0, str2.Length - 1);
            if (decimal.Compare(num, decimal.Zero) > 0)
            {
                //str7 = num.ToString("0.######").Trim();
                str7 = num.ToString().Trim();
                str7 = str7.Substring(2, str7.Length - 2);
                //while (str7.Substring(str7.Length - 1, 1) == "0")
                //{
                //    str7 = str7.Substring(0, str7.Length - 1);
                //}
                if (str7.Substring(0, 1) != "0")
                {
                    if ((str7.Trim().Length % 3) == 1)
                    {
                        str7 = "00" + str7.Trim();
                    }
                    if ((str7.Trim().Length % 3) == 2)
                    {
                        str7 = "0" + str7.Trim();
                    }
                    num2 = (int)Math.Round((double)(((double)str7.Trim().Length) / 3.0));
                    for (num3 = num2; num3 >= 1; num3 += -1)
                    {
                        str4 = str7.Trim().Substring(str7.Trim().Length - (num3 * 3), 3);
                        str3 = str3 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim();
                    }
                }
                else
                {
                    int num5 = str7.Length - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        string expression = str7.Substring(i, 1);
                        str3 = str3 + " " + strArray[Convert.ToInt32(expression)].Trim();
                    }
                }
                str = str2.Trim() + " " + strDVT.Trim() + " và " + str3.Trim() + " " + strDVT2.Trim();
            }
            else
            {
                str = str2.Trim() + " " + strDVT.Trim();
            }
            str.Trim();
            return (str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1)).Replace(",", "");
        }

        
        /// <summary>
        /// Đổi số chữ tiếng anh với tham số truyền vào kiểu double
        /// </summary>
        /// <param name="dboSo">số kiểu double</param>
        /// <param name="strDVT">chuỗi tên đơn vị tiền</param>
        /// <returns>Chuỗi chữ đọc từ số</returns>
        public static string DOI_SO_CHU_E(object dboSo, string strDVT)
        {
            int num2;
            int num3;
            string[] strArray = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "night" };
            string str = "";
            string str2 = "";
            string str6 = "";
            string str7 = "";
            string str3 = "";
            string str4 = "";

            double dblSo = Convert.ToDouble(dboSo);

            if (dblSo < 0.0)
            {
                dblSo = -dblSo;
                str2 = str2 + " Negative";
                return "";
            }
            //decimal num = new decimal(dblSo - Convert.ToInt64(dblSo));
            string snum = "0.0";
            if (dblSo.ToString().IndexOf(".") > 0)
                snum = "0" + dblSo.ToString().Substring(dblSo.ToString().IndexOf("."));
            decimal num = Convert.ToDecimal(snum);
            if (dblSo == 0.0)
            {
                str2 = "Zero.";
            }
            else
            {
                if (dblSo.ToString().IndexOf(".") > 0)
                    str6 = dblSo.ToString().Substring(0, dblSo.ToString().IndexOf("."));
                else
                    str6 = dblSo.ToString();

                if ((str6.Trim().Length % 3) == 1)
                {
                    str6 = "00" + str6.Trim();
                }
                if ((str6.Trim().Length % 3) == 2)
                {
                    str6 = "0" + str6.Trim();
                }
                num2 = (int)Math.Round((double)(((double)str6.Trim().Length) / 3.0));
                for (num3 = num2; num3 >= 1; num3 += -1)
                {
                    str4 = str6.Trim().Substring(str6.Trim().Length - (num3 * 3), 3);
                    if (DOI_SO_CHU_NHOM(str4, num3, num2).Trim().Length > 0)
                    {
                        if (num3 < 5)
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim() + ",";
                        }
                        else
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim();
                        }
                    }
                    else
                    {
                        str2 = str2 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim();
                    }
                }
            }
            str2 = str2.Trim();
            str2 = str2.Substring(0, str2.Length - 1);
            if (decimal.Compare(num, decimal.Zero) > 0)
            {
                str7 = num.ToString("0.######").Trim();
                str7 = str7.Substring(2, str7.Length - 2);
                while (str7.Substring(str7.Length - 1, 1) == "0")
                {
                    str7 = str7.Substring(0, str7.Length - 1);
                }
                if (str7.Substring(0, 1) != "0")
                {
                    if ((str7.Trim().Length % 3) == 1)
                    {
                        str7 = "00" + str7.Trim();
                    }
                    if ((str7.Trim().Length % 3) == 2)
                    {
                        str7 = "0" + str7.Trim();
                    }
                    num2 = (int)Math.Round((double)(((double)str7.Trim().Length) / 3.0));
                    for (num3 = num2; num3 >= 1; num3 += -1)
                    {
                        str4 = str7.Trim().Substring(str7.Trim().Length - (num3 * 3), 3);
                        str3 = str3 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim();
                    }
                }
                else
                {
                    int num5 = str7.Length - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        string expression = str7.Substring(i, 1);
                        str3 = str3 + " " + strArray[Convert.ToInt32(expression)].Trim();
                    }
                }
                str = str2.Trim() + " point " + str3.Trim() + " " + strDVT.Trim();
            }
            else
            {
                str = str2.Trim() + " " + strDVT.Trim();
            }
            str.Trim();
            return (str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1)).Replace(",", "");
        }

        /// <summary>
        /// Đổi số chữ tiếng anh với tham số truyền vào kiểu double
        /// </summary>
        /// <param name="dboSo">số kiểu double</param>
        /// <param name="strDVT">chuỗi tên đơn vị tiền</param>
        /// <param name="strDVT2">chuỗi tên đơn vị sau phần thập phân của số</param>
        /// <returns>Chuỗi chữ đọc từ số</returns>
        public static string DOI_SO_CHU_E(object dboSo, string strDVT, string strDVT2)
        {
            int num2;
            int num3;
            string[] strArray = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "night" };
            string str = "";
            string str2 = "";
            string str6 = "";
            string str7 = "";
            string str3 = "";
            string str4 = "";

            double dblSo = Convert.ToDouble(dboSo);

            if (dblSo < 0.0)
            {
                dblSo = -dblSo;
                str2 = str2 + " Negative";
                return "";
            }
            //decimal num = new decimal(dblSo - Convert.ToInt64(dblSo));
            string snum = "0.0";
            if (dblSo.ToString().IndexOf(".") > 0)
                snum = "0" + dblSo.ToString().Substring(dblSo.ToString().IndexOf("."));
            decimal num = Convert.ToDecimal(snum);
            if (dblSo == 0.0)
            {
                str2 = "Zero.";
            }
            else
            {
                if (dblSo.ToString().IndexOf(".") > 0)
                    str6 = dblSo.ToString().Substring(0, dblSo.ToString().IndexOf("."));
                else
                    str6 = dblSo.ToString();

                if ((str6.Trim().Length % 3) == 1)
                {
                    str6 = "00" + str6.Trim();
                }
                if ((str6.Trim().Length % 3) == 2)
                {
                    str6 = "0" + str6.Trim();
                }
                num2 = (int)Math.Round((double)(((double)str6.Trim().Length) / 3.0));
                for (num3 = num2; num3 >= 1; num3 += -1)
                {
                    str4 = str6.Trim().Substring(str6.Trim().Length - (num3 * 3), 3);
                    if (DOI_SO_CHU_NHOM(str4, num3, num2).Trim().Length > 0)
                    {
                        if (num3 < 5)
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim() + ",";
                        }
                        else
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim();
                        }
                    }
                    else
                    {
                        str2 = str2 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim();
                    }
                }
            }
            str2 = str2.Trim();
            str2 = str2.Substring(0, str2.Length - 1);
            if (decimal.Compare(num, decimal.Zero) > 0)
            {
                //str7 = num.ToString("0.######").Trim();
                str7 = num.ToString().Trim();
                str7 = str7.Substring(2, str7.Length - 2);
                //while (str7.Substring(str7.Length - 1, 1) == "0")
                //{
                //    str7 = str7.Substring(0, str7.Length - 1);
                //}
                if (str7.Substring(0, 1) != "0")
                {
                    if ((str7.Trim().Length % 3) == 1)
                    {
                        str7 = "00" + str7.Trim();
                    }
                    if ((str7.Trim().Length % 3) == 2)
                    {
                        str7 = "0" + str7.Trim();
                    }
                    num2 = (int)Math.Round((double)(((double)str7.Trim().Length) / 3.0));
                    for (num3 = num2; num3 >= 1; num3 += -1)
                    {
                        str4 = str7.Trim().Substring(str7.Trim().Length - (num3 * 3), 3);
                        str3 = str3 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim();
                    }
                }
                else
                {
                    int num5 = str7.Length - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        string expression = str7.Substring(i, 1);
                        str3 = str3 + " " + strArray[Convert.ToInt32(expression)].Trim();
                    }
                }
                str = str2.Trim() + " " + strDVT.Trim() + " and " + str3.Trim() + " " + strDVT2.Trim();
            }
            else
            {
                str = str2.Trim() + " " + strDVT.Trim();
            }
            str.Trim();
            return (str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1)).Replace(",", "");
        }

        
        /// <summary>
        /// Đổi số chữ tiếng việt với tham số truyền vào kiểu chuỗi
        /// </summary>
        /// <param name="dboSo">chuỗi số</param>
        /// <param name="strDVT">chuỗi tên đơn vị tiền</param>
        /// <returns>Chuỗi chữ đọc từ chuỗi số</returns>
        public static string DOI_SO_CHU(string dbcSo, string strDVT)
        {
            int num2;
            int num3;
            string[] strArray = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string str = "";
            string str2 = "";
            string str6 = "";
            string str7 = "";
            string str3 = "";
            string str4 = "";

            double dblSo = Convert.ToDouble(dbcSo);

            if (dblSo < 0.0)
            {
                dblSo = -dblSo;
                str2 = str2 + " âm";
            }
            //decimal num = new decimal(dblSo - Convert.ToInt64(dblSo));
            string snum = "0.0";
            if (dblSo.ToString().IndexOf(".") > 0)
                snum = "0" + dblSo.ToString().Substring(dblSo.ToString().IndexOf("."));
            decimal num = Convert.ToDecimal(snum);
            if (dblSo == 0.0)
            {
                str2 = "không.";
            }
            else
            {                
                if (dblSo.ToString().IndexOf(".") > 0)
                    str6 = dblSo.ToString().Substring(0, dblSo.ToString().IndexOf("."));
                else
                    str6 = dblSo.ToString();

                if ((str6.Trim().Length % 3) == 1)
                {
                    str6 = "00" + str6.Trim();
                }
                if ((str6.Trim().Length % 3) == 2)
                {
                    str6 = "0" + str6.Trim();
                }
                num2 = (int)Math.Round((double)(((double)str6.Trim().Length) / 3.0));
                for (num3 = num2; num3 >= 1; num3 += -1)
                {
                    str4 = str6.Trim().Substring(str6.Trim().Length - (num3 * 3), 3);
                    if (DOI_SO_CHU_NHOM(str4, num3, num2).Trim().Length > 0)
                    {
                        if (num3 < 5)
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim() + ",";                            
                        }
                        else
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim();
                        }
                    }
                    else
                    {
                        str2 = str2 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim();
                    }
                }
            }
            str2 = str2.Trim();
            str2 = str2.Substring(0, str2.Length - 1);
            if (decimal.Compare(num, decimal.Zero) > 0)
            {
                str7 = num.ToString("0.######").Trim();
                //str7 = Convert.ToString(num).Trim();
                str7 = str7.Substring(2, str7.Length - 2);
                while (str7.Substring(str7.Length - 1, 1) == "0")
                {
                    str7 = str7.Substring(0, str7.Length - 1);
                }
                if (str7.Substring(0, 1) != "0")
                {
                    if ((str7.Trim().Length % 3) == 1)
                    {
                        str7 = "00" + str7.Trim();
                    }
                    if ((str7.Trim().Length % 3) == 2)
                    {
                        str7 = "0" + str7.Trim();
                    }
                    num2 = (int)Math.Round((double)(((double)str7.Trim().Length) / 3.0));
                    for (num3 = num2; num3 >= 1; num3 += -1)
                    {
                        str4 = str7.Trim().Substring(str7.Trim().Length - (num3 * 3), 3);
                        str3 = str3 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim();
                    }
                }
                else
                {
                    int num5 = str7.Length - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        string expression = str7.Substring(i, 1);
                        str3 = str3 + " " + strArray[Convert.ToInt32(expression)].Trim();
                    }
                }
                str = str2.Trim() + " phẩy " + str3.Trim() + " " + strDVT.Trim();
            }
            else
            {
                str = str2.Trim() + " " + strDVT.Trim();
            }
            str.Trim();
            return (str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1)).Replace(",", "");
        }
      
        /// <summary>
        /// Đổi số chữ tiếng việt với tham số truyền vào kiểu chuỗi
        /// </summary>
        /// <param name="dboSo">chuỗi số</param>
        /// <param name="strDVT">chuỗi tên đơn vị tiền</param>
        /// <param name="strDVT2">chuỗi tên đơn vị sau phần thập phân của số</param>
        /// <returns>Chuỗi chữ đọc từ chuỗi số</returns>
        public static string DOI_SO_CHU(string dbcSo, string strDVT, string strDVT2)
        {
            int num2;
            int num3;
            string[] strArray = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string str = "";
            string str2 = "";
            string str6 = "";
            string str7 = "";
            string str3 = "";
            string str4 = "";

            double dblSo = Convert.ToDouble(dbcSo);

            if (dblSo < 0.0)
            {
                dblSo = -dblSo;
                str2 = str2 + " âm";
            }
            //decimal num = new decimal(dblSo - Convert.ToInt64(dblSo));
            string snum = "0.0";
            if (dblSo.ToString().IndexOf(".") > 0)
                snum = "0" + dbcSo.ToString().Substring(dbcSo.ToString().IndexOf("."));
            decimal num = Convert.ToDecimal(snum);
            if (dblSo == 0.0)
            {
                str2 = "không.";
            }
            else
            {
                if (dblSo.ToString().IndexOf(".") > 0)
                    str6 = dblSo.ToString().Substring(0, dblSo.ToString().IndexOf("."));
                else
                    str6 = dblSo.ToString();

                if ((str6.Trim().Length % 3) == 1)
                {
                    str6 = "00" + str6.Trim();
                }
                if ((str6.Trim().Length % 3) == 2)
                {
                    str6 = "0" + str6.Trim();
                }
                num2 = (int)Math.Round((double)(((double)str6.Trim().Length) / 3.0));
                for (num3 = num2; num3 >= 1; num3 += -1)
                {
                    str4 = str6.Trim().Substring(str6.Trim().Length - (num3 * 3), 3);
                    if (DOI_SO_CHU_NHOM(str4, num3, num2).Trim().Length > 0)
                    {
                        if (num3 < 5)
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim() + ",";
                        }
                        else
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim();
                        }
                    }
                    else
                    {
                        str2 = str2 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim();
                    }
                }
            }
            str2 = str2.Trim();
            str2 = str2.Substring(0, str2.Length - 1);
            if (decimal.Compare(num, decimal.Zero) > 0)
            {
                //str7 = num.ToString("0.######").Trim();
                str7 = num.ToString().Trim();
                str7 = str7.Substring(2, str7.Length - 2);
                //while (str7.Substring(str7.Length - 1, 1) == "0")
                //{
                //    str7 = str7.Substring(0, str7.Length - 1);
                //}
                if (str7.Substring(0, 1) != "0")
                {
                    if ((str7.Trim().Length % 3) == 1)
                    {
                        str7 = "00" + str7.Trim();
                    }
                    if ((str7.Trim().Length % 3) == 2)
                    {
                        str7 = "0" + str7.Trim();
                    }
                    num2 = (int)Math.Round((double)(((double)str7.Trim().Length) / 3.0));
                    for (num3 = num2; num3 >= 1; num3 += -1)
                    {
                        str4 = str7.Trim().Substring(str7.Trim().Length - (num3 * 3), 3);
                        str3 = str3 + " " + DOI_SO_CHU_NHOM(str4, num3, num2).Trim();
                    }
                }
                else
                {
                    int num5 = str7.Length - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        string expression = str7.Substring(i, 1);
                        str3 = str3 + " " + strArray[Convert.ToInt32(expression)].Trim();
                    }
                }
                str = str2.Trim() + " " + strDVT.Trim() + " và " + str3.Trim() + " " + strDVT2.Trim();
            }
            else
            {
                str = str2.Trim() + " " + strDVT.Trim();
            }
            str.Trim();
            return (str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1)).Replace(",", "");
        }        

        /// <summary>
        /// Đổi số chữ tiếng anh với tham số truyền vào kiểu chuỗi
        /// </summary>
        /// <param name="dboSo">chuỗi số</param>
        /// <param name="strDVT">chuỗi tên đơn vị tiền</param>
        /// <returns>Chuỗi chữ đọc từ chuỗi số</returns>
        public static string DOI_SO_CHU_E(string dbcSo, string strDVT)
        {
            int num2;
            int num3;
            string[] strArray = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "night" };
            string str = "";
            string str2 = "";
            string str6 = "";
            string str7 = "";
            string str3 = "";
            string str4 = "";

            double dblSo = Convert.ToDouble(dbcSo);

            if (dblSo < 0.0)
            {
                dblSo = -dblSo;
                str2 = str2 + " Negative";
                return "";
            }
            //decimal num = new decimal(dblSo - Convert.ToInt64(dblSo));
            string snum = "0.0";
            if (dblSo.ToString().IndexOf(".") > 0)
                snum = "0" + dblSo.ToString().Substring(dblSo.ToString().IndexOf("."));
            decimal num = Convert.ToDecimal(snum);
            if (dblSo == 0.0)
            {
                str2 = "Zero.";
            }
            else
            {                
                if (dblSo.ToString().IndexOf(".") > 0)
                    str6 = dblSo.ToString().Substring(0, dblSo.ToString().IndexOf("."));
                else
                    str6 = dblSo.ToString();

                if ((str6.Trim().Length % 3) == 1)
                {
                    str6 = "00" + str6.Trim();
                }
                if ((str6.Trim().Length % 3) == 2)
                {
                    str6 = "0" + str6.Trim();
                }
                num2 = (int)Math.Round((double)(((double)str6.Trim().Length) / 3.0));
                for (num3 = num2; num3 >= 1; num3 += -1)
                {
                    str4 = str6.Trim().Substring(str6.Trim().Length - (num3 * 3), 3);
                    if (DOI_SO_CHU_NHOM(str4, num3, num2).Trim().Length > 0)
                    {
                        if (num3 < 5)
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim() + ",";                            
                        }
                        else
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim();
                        }
                    }
                    else
                    {
                        str2 = str2 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim();
                    }
                }
            }
            str2 = str2.Trim();
            str2 = str2.Substring(0, str2.Length - 1);
            if (decimal.Compare(num, decimal.Zero) > 0)
            {
                str7 = num.ToString("0.######").Trim();
                str7 = str7.Substring(2, str7.Length - 2);
                while (str7.Substring(str7.Length - 1, 1) == "0")
                {
                    str7 = str7.Substring(0, str7.Length - 1);
                }
                if (str7.Substring(0, 1) != "0")
                {
                    if ((str7.Trim().Length % 3) == 1)
                    {
                        str7 = "00" + str7.Trim();
                    }
                    if ((str7.Trim().Length % 3) == 2)
                    {
                        str7 = "0" + str7.Trim();
                    }
                    num2 = (int)Math.Round((double)(((double)str7.Trim().Length) / 3.0));
                    for (num3 = num2; num3 >= 1; num3 += -1)
                    {
                        str4 = str7.Trim().Substring(str7.Trim().Length - (num3 * 3), 3);
                        str3 = str3 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim();
                    }
                }
                else
                {
                    int num5 = str7.Length - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        string expression = str7.Substring(i, 1);
                        str3 = str3 + " " + strArray[Convert.ToInt32(expression)].Trim();
                    }
                }
                str = str2.Trim() + " point " + str3.Trim() + " " + strDVT.Trim();
            }
            else
            {
                str = str2.Trim() + " " + strDVT.Trim();
            }
            str = str.ToLower().Trim();
            return (str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1)).Replace(",", "");
        }
        
        /// <summary>
        /// Đổi số chữ tiếng anh với tham số truyền vào kiểu chuỗi
        /// </summary>
        /// <param name="dboSo">chuỗi số</param>
        /// <param name="strDVT">chuỗi tên đơn vị tiền</param>
        /// <param name="strDVT2">chuỗi tên đơn vị sau phần thập phân của số</param>
        /// <returns>Chuỗi chữ đọc từ chuỗi số</returns>
        public static string DOI_SO_CHU_E(string dbcSo, string strDVT, string strDVT2)
        {
            int num2;
            int num3;
            string[] strArray = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "night" };
            string str = "";
            string str2 = "";
            string str6 = "";
            string str7 = "";
            string str3 = "";
            string str4 = "";

            double dblSo = Convert.ToDouble(dbcSo);

            if (dblSo < 0.0)
            {
                dblSo = -dblSo;
                str2 = str2 + " Negative";
                return "";
            }
            //decimal num = new decimal(dblSo - Convert.ToInt64(dblSo));
            string snum = "0.0";
            if (dblSo.ToString().IndexOf(".") > 0)
                snum = "0" + dbcSo.ToString().Substring(dbcSo.ToString().IndexOf("."));
            decimal num = Convert.ToDecimal(snum);
            if (dblSo == 0.0)
            {
                str2 = "Zero.";
            }
            else
            {
                if (dblSo.ToString().IndexOf(".") > 0)
                    str6 = dblSo.ToString().Substring(0, dblSo.ToString().IndexOf("."));
                else
                    str6 = dblSo.ToString();

                if ((str6.Trim().Length % 3) == 1)
                {
                    str6 = "00" + str6.Trim();
                }
                if ((str6.Trim().Length % 3) == 2)
                {
                    str6 = "0" + str6.Trim();
                }
                num2 = (int)Math.Round((double)(((double)str6.Trim().Length) / 3.0));
                for (num3 = num2; num3 >= 1; num3 += -1)
                {
                    str4 = str6.Trim().Substring(str6.Trim().Length - (num3 * 3), 3);
                    if (DOI_SO_CHU_NHOM(str4, num3, num2).Trim().Length > 0)
                    {
                        if (num3 < 5)
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim() + ",";
                        }
                        else
                        {
                            str2 = str2 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim();
                        }
                    }
                    else
                    {
                        str2 = str2 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim();
                    }
                }
            }
            str2 = str2.Trim();
            str2 = str2.Substring(0, str2.Length - 1);
            if (decimal.Compare(num, decimal.Zero) > 0)
            {
                //str7 = num.ToString("0.######").Trim();
                str7 = num.ToString().Trim();
                str7 = str7.Substring(2, str7.Length - 2);
                //while (str7.Substring(str7.Length - 1, 1) == "0")
                //{
                //    str7 = str7.Substring(0, str7.Length - 1);
                //}
                if (str7.Substring(0, 1) != "0")
                {
                    if ((str7.Trim().Length % 3) == 1)
                    {
                        str7 = "00" + str7.Trim();
                    }
                    if ((str7.Trim().Length % 3) == 2)
                    {
                        str7 = "0" + str7.Trim();
                    }
                    num2 = (int)Math.Round((double)(((double)str7.Trim().Length) / 3.0));
                    for (num3 = num2; num3 >= 1; num3 += -1)
                    {
                        str4 = str7.Trim().Substring(str7.Trim().Length - (num3 * 3), 3);
                        str3 = str3 + " " + DOI_SO_CHU_NHOM_E(str4, num3, num2).Trim();
                    }
                }
                else
                {
                    int num5 = str7.Length - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        string expression = str7.Substring(i, 1);
                        str3 = str3 + " " + strArray[Convert.ToInt32(expression)].Trim();
                    }
                }
                str = str2.Trim() + " " + strDVT.Trim() + " and " + str3.Trim() + " " + strDVT2.Trim();
            }
            else
            {
                str = str2.Trim() + " " + strDVT.Trim();
            }
            str = str.ToLower().Trim();
            return (str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1)).Replace(",", "");
        }

        private static string DOI_SO_CHU_NHOM(string strNhom_So, int intStt_Nhom, int intSo_Nhom)
        {
            string[] strArray = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string str5 = "bốn";
            string str4 = "";
            string expression = strNhom_So.Trim().Substring(0, 1);
            string ch = strNhom_So.Trim().Substring(1, 1);
            string ch2 = strNhom_So.Trim().Substring(2, 1);
            string str6 = strArray[Convert.ToInt32(expression)];
            string str2 = strArray[Convert.ToInt32(ch)];
            string str3 = strArray[Convert.ToInt32(ch2)];
            if ((Convert.ToString(expression) != "0") | ((intStt_Nhom == 1) & (intStt_Nhom < intSo_Nhom)))
            {
                str4 = str4 + " " + str6 + " trăm ";
            }
            if (Convert.ToString(ch) != "0")
            {
                if (Convert.ToString(ch) != "1")
                {
                    str4 = str4 + str2 + " mươi";
                    if (Convert.ToString(ch2) != "5")
                    {
                        if (Convert.ToString(ch2) != "0")
                        {
                            if (Convert.ToString(ch2) == "1")
                            {
                                str4 = str4 + " mốt";
                            }
                            else if ((Convert.ToString(ch2) == "4") & (intStt_Nhom > 1))
                            {
                                str4 = str4 + " " + str5;
                            }
                            else
                            {
                                str4 = str4 + " " + str3;
                            }
                        }
                    }
                    else
                    {
                        str4 = str4 + " năm";
                    }
                }
                else
                {
                    str4 = str4 + " mười";
                    if (Convert.ToString(ch2) != "5")
                    {
                        if (Convert.ToString(ch2) != "0")
                        {
                            str4 = str4 + " " + str3;
                        }
                    }
                    else
                    {
                        str4 = str4 + " năm";
                    }
                }
            }
            else if (Convert.ToString(ch2) != "0")
            {
                if (intStt_Nhom != intSo_Nhom | (Convert.ToString(expression) != "0" & intStt_Nhom == intSo_Nhom))
                {
                    str4 = str4 + " linh";
                }
                if (Convert.ToString(ch2) == "4")
                {
                    str4 = str4 + " " + str5;
                }
                else
                {
                    str4 = str4 + " " + str3;
                }
            }
            switch (intStt_Nhom)
            {
                case 2:
                    str4 = str4 + " nghìn";
                    break;

                case 3:
                    str4 = str4 + " triệu";
                    break;

                case 4:
                    str4 = str4 + " tỉ";
                    break;

                case 5:
                    str4 = str4 + " nghìn";
                    break;

                case 6:
                    str4 = str4 + " triệu";
                    break;
            }
            if ((((Convert.ToString(expression) == "0") & (Convert.ToString(ch) == "0")) & (Convert.ToString(ch2) == "0")) && ((intStt_Nhom % 4) != 0))
            {
                str4 = "";
            }
            return str4;
        }

        private static string DOI_SO_CHU_NHOM_E(string strNhom_So, int intStt_Nhom, int intSo_Nhom)
        {
            bool hzero;
            hzero = false;
            string[] strArray = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "night" };
            string[] strArray1 = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] strArray2 = new string[] { "", "", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string str4 = "";
            string expression = strNhom_So.Trim().Substring(0, 1);
            string ch = strNhom_So.Trim().Substring(1, 1);
            string ch2 = strNhom_So.Trim().Substring(2, 1);
            string str6 = strArray[Convert.ToInt32(expression)];
            string str2 = strArray2[Convert.ToInt32(ch)];
            string str3 = strArray[Convert.ToInt32(ch2)];
            if ((Convert.ToString(expression) != "0"))
            {
                str4 = str4 + " " + str6 + " hundred";
            }
            else
            {
                if (intStt_Nhom < intSo_Nhom)
                {
                    str4 = str4 + " and ";
                    hzero = true;
                }
            }

            if (Convert.ToString(ch) != "0")
            {
                if (Convert.ToString(ch) == "1")
                {
                    str4 = str4 + strArray1[Convert.ToInt32(ch2)];
                }
                else
                {
                    str4 = str4 + " " + str2 + " " + str3;
                }
            }
            else if (Convert.ToString(ch2) != "0")
            {
                if (intStt_Nhom != intSo_Nhom || (intStt_Nhom == intSo_Nhom & Convert.ToString(ch) == "0"))
                {
                    if (hzero == false & (Convert.ToString(expression) != "0"))
                        str4 = str4 + " and";
                }
                str4 = str4 + " " + str3;
            }
            switch (intStt_Nhom)
            {
                case 2:
                    str4 = str4 + " thousand";
                    break;

                case 3:
                    str4 = str4 + " million";
                    break;

                case 4:
                    str4 = str4 + " billion";
                    break;

                case 5:
                    str4 = str4 + " thousand";
                    break;

                case 6:
                    str4 = str4 + " million";
                    break;
            }
            if ((((Convert.ToString(expression) == "0") & (Convert.ToString(ch) == "0")) & (Convert.ToString(ch2) == "0")) && ((intStt_Nhom % 4) != 0))
            {
                str4 = "";
            }
            return str4;
        }
    }
}
