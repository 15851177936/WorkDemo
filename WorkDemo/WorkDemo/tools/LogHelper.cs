using System;
using System.Windows.Forms;

namespace WorkDemo.tools
{
    /// <summary>
    /// 转出字符串到textBox_display
    /// </summary>
    internal class LogHelper
    {
        private TextBox textBox;
        private string filePath;
        private string errorPath;
        private string basePath;

        public string FilePath { get => filePath; set => filePath = value; }
        public string ErrorPath { get => errorPath; set => errorPath = value; }
        public string BasePath { get => basePath; set => basePath = value; }

        public LogHelper(TextBox textBox)
        {
            this.textBox = textBox;
        }
        /// <summary>
        /// 写入日志内容
        /// </summary>
        /// <param name="content">写日志文件的语句内容</param>
        private void WriteLog(string content)
        {
            try
            {
                textBox.Text += (DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "> " + content);
                textBox.AppendText(System.Environment.NewLine);
            }
            catch (Exception ex)
            {
                textBox.Text += (DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "> " + ex.Message + "\n" + ex.StackTrace);
                textBox.AppendText(System.Environment.NewLine);
            }
        }
        /// <summary>
        /// 代码等级为Debug
        /// </summary>
        /// <param name="debug">需要转出的信息</param>
        public void Debug(string debug)
        {
            WriteLog("DEBUG  " + debug);
        }
        /// <summary>
        /// 代码等级为Info
        /// </summary>
        /// <param name="info">需要转出的信息</param>
        public void Info(string info)
        {
            WriteLog("INFO   " + info);
        }
        /// <summary>
        /// 代码等级为Warn
        /// </summary>
        /// <param name="warning">需要转出的信息</param>
        public void Warn(string warn)
        {
            WriteLog("WARN   " + warn);
        }
        /// <summary>
        /// 代码等级为Error
        /// </summary>
        /// <param name="error"></param>
        public void Error(string error)
        {
            WriteLog("ERROR  " + error);
        }
    }
}
