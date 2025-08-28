using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;

namespace CPUMonitor
{
    public partial class Form1 : Form
    {
        PlaybackThread playbackThread;
        public Form1()
        {
            InitializeComponent();
            notifyIcon_cpu.Icon = new System.Drawing.Icon(ConfigurationManager.AppSettings["playbackImageFloadPathDefault"]);
            playbackThread = new PlaybackThread(notifyIcon_cpu);
        }

        public void GetCpuUse()
        {
            PerformanceCounter cpuCounter;
            PerformanceCounter ramCounter;

            //cpuCounter = new PerformanceCounter();
            //cpuCounter.CategoryName = "Processor";
            //cpuCounter.CounterName = "% Processor Time";
            //cpuCounter.InstanceName = "_Total";
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            Console.WriteLine("电脑CPU使用率：" + cpuCounter.NextValue() + "%");
            Console.WriteLine("电脑可使用内存：" + ramCounter.NextValue() + "MB");
            Console.WriteLine();

            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("电脑CPU使用率：" + cpuCounter.NextValue() + " %");
                Console.WriteLine("电脑可使用内存：" + ramCounter.NextValue() + "MB");
                Console.WriteLine();

                if ((int)cpuCounter.NextValue() > 80)
                {
                    System.Threading.Thread.Sleep(1000 * 60);
                }
                notifyIcon_cpu.Icon = new System.Drawing.Icon(@"D:\own\Code\WorkDemo\WorkDemo\CPUMonitor\VividResource\Level0\Level0_1.ico");
            }
        }

        /// <summary>
        /// 获取屏幕Dpi重新计算显示宽度和高度
        /// </summary>
        public void GetScreenSize()
        {
            // 调用GetSystemDPI方法并打印DPI值
            uint systemDPI = DPIHelper.GetSystemDPI();
            Console.WriteLine("System DPI: " + systemDPI);

            double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            double x1 = SystemParameters.PrimaryScreenWidth;//得到屏幕整体宽度
            double y1 = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度

            double width = SystemParameters.PrimaryScreenWidth;
            double height = SystemParameters.PrimaryScreenHeight;
            this.Width = (int)(width * (0.7));
            this.Height = (int)(height * (0.7));
        }
    }
}
