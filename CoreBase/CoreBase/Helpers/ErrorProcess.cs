/* Author: Chungtv # xx/x7/2011
 * Purpose: Lớp xử lý lỗi
 * Modify Log:
 *  Chungtv @ Nov 04,2011 | Bổ sung các thuộc tính, phương thức cho việc xử lý ngoại lệ 
 *  
 */
using Microsoft.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.SqlServer.MessageBox;
////For EnterpriseLibrary
//using Microsoft.Practices.EnterpriseLibrary.Common;
//using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace CoreBase.Helpers
{
    public class ErrorProcess
    {
        #region Properties

        /// <summary>
        /// Thuộc tính ExceptionManager sử dụng để xử lý ngoại lệ thông qua Enterprise Library Exception Handling Block.
        /// Một Best practice của Microsoft
        /// </summary>
        //public static ExceptionManager ExMan
        //{
        //    get
        //    {
        //        return EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
        //    }
        //}

        /// <summary>
        /// Tên của chính sác xử lý ngoại lệ được cấu hình trong file config của ứng dụng, tên này được lấy để xử lý Localization
        /// </summary>
        public static string ExHandlPolicy
        {
            get
            {
                //return GlobalVariable.GetStringVariable("M_ExceptionHandlingPolicy");
                return "";
            }
        }

        #endregion

        #region Methods

        public static void ErrorProcessFromEx(Exception ex)
        {
            throw ex;
            //ExceptionManager exMan = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();

            //TODO  
        }

        public static void HandleException(System.Windows.Forms.IWin32Window owner, Exception ex)
        {
            throw  new Exception("");
            //ExceptionMessageBox exMsg = new ExceptionMessageBox(ex, ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Stop);
            //exMsg.Show(owner);
        }

        public static void HandleException(Exception ex)
        {
            throw new Exception("");
            //ExceptionMessageBox exMsg = new ExceptionMessageBox(ex, ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Stop);
            //exMsg.Show(null);
        }
        #endregion
    }
}

