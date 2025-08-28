using System.Runtime.InteropServices;

namespace CPUMonitor
{
    public class DPIHelper
    {
        // 导入GetDpiForSystem函数
        [DllImport("user32.dll")]
        private static extern uint GetDpiForSystem();

        // 定义一个方法来获取系统DPI
        public static uint GetSystemDPI()
        {
            // 调用GetDpiForSystem函数并返回DPI值
            uint dpi = GetDpiForSystem();
            return dpi;
        }
    }
}
