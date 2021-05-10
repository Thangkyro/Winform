/* Author: Chungtv # May 11, 2011
 * Purpose: Lớp thư viện chứa các hàm và thủ tục xử lý dữ liệu ngày tháng
 * Modify log:
 *      Date | Author | Description
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreBase.Helpers
{
    public static class DateTimeLibrary
    {
        /// <summary>
        /// Hàm kiểm tra và trả về ngày đầu của tháng với tháng năm đưa vào
        /// </summary>
        /// <param name="month">tháng số</param>
        /// <param name="year">năm số</param>
        /// <returns>ngày đầu tiên của thagn1</returns>
        public static DateTime BOM(int month, int year)
        {
            DateTime dtRet;
            try
            {
                if (month > 12 || month < 1)
                {
                    throw new Exception("Tháng không hợp lệ!!!");
                }
                if (year.ToString().Length < 4)
                {
                    year = Convert.ToInt32(DateTime.Today.Year.ToString().Substring(0, 4 - year.ToString().Length) + year.ToString());
                }
                else if (year.ToString().Length != 4)
                {
                    throw new Exception("Năm không hợp lệ!!!");                
                }                
                dtRet = new DateTime(year, month, 1);

            }
            catch (Exception e)
            {
                ErrorProcess.ErrorProcessFromEx(e);
                return DateTime.Today;
            }           
            return dtRet; 
        }

        /// <summary>
        /// Hàm trả về ngày đầu của tháng khi đưa ngày tháng năm bất kỳ vào
        /// </summary>
        /// <param name="date">Ngày tháng năm đưa vào</param>
        /// <returns>Ngày đầu tiên của tháng</returns>
        public static DateTime BOM(DateTime date)
        {
            return new DateTime(date.Year, date.Month , 1);
        }

        /// <summary>
        /// Hàm kiểm tra và trả về ngày cuối cùng của tháng với tháng năm đưa vào
        /// </summary>
        /// <param name="month">tháng số</param>
        /// <param name="year">năm số</param>
        /// <returns>ngày cuối cùng của tháng</returns>
        public static DateTime EOM(int month, int year)
        {
            DateTime dtRet;
            try
            {
                if (month > 12 || month < 1)
                {
                    throw new Exception("Tháng không hợp lệ!!!");
                }
                if (year.ToString().Length < 4)
                {
                    year = Convert.ToInt32(DateTime.Today.Year.ToString().Substring(0, 4 - year.ToString().Length) + year.ToString());
                }
                else if (year.ToString().Length != 4)
                {
                    throw new Exception("Năm không hợp lệ!!!");
                }
                dtRet = new DateTime(year, month, DateTime.DaysInMonth(year,month));

            }
            catch (Exception e)
            {
                ErrorProcess.ErrorProcessFromEx(e);
                return DateTime.Today;
            }
            return dtRet;                        
        }

        /// <summary>
        /// Hàm trả về ngày cuối cùng của tháng khi đưa vào một ngày bất kỳ
        /// </summary>
        /// <param name="date">ngày tháng năm đưa vào</param>
        /// <returns>ngày cuối cùng của tháng</returns>
        public static DateTime EOM(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        /// <summary>
        /// Hàm đọc ngày, đưa vào 1 ngày bất kỳ đọc sang dạng "ngày...tháng...năm..."
        /// </summary>
        /// <param name="date">ngày tháng năm đưa vào</param>
        /// <returns>Chuỗi ngày tháng năm</returns>
        public static string ReadDate(DateTime date)
        {
            return "Ngày " + date.Day.ToString() + " tháng " + date.Month.ToString() + " năm " + date.Year.ToString();
        }
        

        public static bool IsDate(object expression)
        {
            return IsDate(expression);
        }

        public static bool IsDate(int year, int month, int day)
        {
            try
            {
                DateTime d = new DateTime(year, month, day);
                return IsDate(d);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDate(string year, string month, string day)
        {
            try
            {
                DateTime d = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                return IsDate(d);
            }
            catch
            {
                return false;
            }
        }

        public static DateTime ToDate(object expression)
        {
            return ToDate(expression);
        }
    }
}
