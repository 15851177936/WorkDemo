using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;

namespace CPUMonitor
{
    public partial class Form1 : Form
    {
        PlaybackThread playbackThread;
        public Form1()
        {
            InitializeComponent();
            notifyIcon_cpu.Icon = new System.Drawing.Icon(ConfigurationManager.AppSettings["playbackImageFloadPathDefault"]);//初始化时用透明图标
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //隐藏窗体和状态栏图标
            this.BeginInvoke(new Action(() =>
            {
                this.Hide();
                this.Opacity = 1;
            }));
        }
    }
}
