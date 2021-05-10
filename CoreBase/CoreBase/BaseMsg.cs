using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreBase
{
    public enum MessageType
    {
        None = 0,
        Error = 16,
        Question = 32,
        Warning = 48,
        Infomation = 64
    }
    public sealed class BaseMessage
    {
        public static DialogResult Warning(string message)
        {
            return Show(message, MessageType.Warning);
        }
        public static DialogResult Infomation(string message)
        {
            return Show(message, MessageType.Infomation);
        }
        public static DialogResult Error(string message)
        {
            return Show(message, MessageType.Error);
        }
        /// <summary>
        /// Hỏi, trả về YesNo
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult Question(string message)
        {
            return Show(message, MessageType.Question);
        }
        /// <summary>
        /// type = Question thì trả về Yes/No
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DialogResult Show(string message, MessageType type)
        {
            switch (type)
            {
                case MessageType.Error:
                    return MessageBox.Show(message, CONFIG.PRJName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case MessageType.Question:
                    return MessageBox.Show(message, CONFIG.PRJName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
                case MessageType.Warning:
                    return MessageBox.Show(message, CONFIG.PRJName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case MessageType.Infomation:
                    return MessageBox.Show(message, CONFIG.PRJName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    return MessageBox.Show(message, CONFIG.PRJName);

            }
        }
        public static DialogResult Show(string message)
        {
            return MessageBox.Show(message, CONFIG.PRJName);
        }
        public static DialogResult Show(string message, MessageBoxButtons buttons)
        {
            return MessageBox.Show(message, CONFIG.PRJName, buttons);
        }
        public static DialogResult Show(string message, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, CONFIG.PRJName, MessageBoxButtons.OK, icon);
        }
        public static DialogResult Show(string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, CONFIG.PRJName, buttons, icon);
        }

        public static DialogResult ShowWithFormat(MessageType type, string message, params object[] args)
        {
            return Show(string.Format(message, args), type);
        }
    }
}
