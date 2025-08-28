using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CPUMonitor
{
    public class PlaybackThread
    {
        /// <summary>
        /// 动画的图片路径
        /// </summary>
        private List<string> playbackImagePath;
        /// <summary>
        /// 图片动画
        /// </summary>
        private Thread vividThread;
        /// <summary>
        /// 检测当前cpu状态
        /// </summary>
        private Thread cpuThread;
        /// <summary>
        /// 动画间隔时间(ms)
        /// </summary>
        private int vividThreadSleepTime = 1000;
        /// <summary>
        /// cpu检测间隔时间(ms)
        /// </summary>
        private int cpuThreadSleepTime = 1000;
        /// <summary>
        /// cpu使用率
        /// </summary>
        PerformanceCounter cpuCounter;
        /// <summary>
        /// cpu使用率——用来显示
        /// </summary>
        float cpuCounterDisplay;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="notifyIcon"></param>
        public PlaybackThread(NotifyIcon notifyIcon)
        {
            try
            {
                //**初始化playbackImagePath,把文件夹中的图片按照图片名字排序全部读取,刚开始默认最低
                playbackImagePath = new List<string>();
                GetPlaybackImageByLevelToList(CpuLevel.level_0_20);

                //**初始化动画线程
                vividThread = new Thread(() => PlaybackThreadDoWork(notifyIcon));
                vividThread.Start();

                //**初始化检测cpu线程
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuThread = new Thread(DetectCpuThreadDoWork);
                cpuThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 循环改变notifyIcon的显示图片，间隔时间为threadSleepTime
        /// </summary>
        /// <param name="notifyIcon"></param>
        private void PlaybackThreadDoWork(NotifyIcon notifyIcon)
        {
            try
            {
                int i = 0;
                while (true)
                {
                    i = (i == playbackImagePath.Count ? 0 : i);
                    //**根据cpu使用率显示
                    if (cpuCounterDisplay >= 0 && cpuCounterDisplay < 20)
                    {
                        //更新图片路径
                        //更新图片速度
                        GetPlaybackImageByLevelToList(CpuLevel.level_0_20);
                        vividThreadSleepTime = 1000;
                    }
                    else if (cpuCounterDisplay >= 20 && cpuCounterDisplay < 80)
                    {
                        GetPlaybackImageByLevelToList(CpuLevel.level_20_80);
                        vividThreadSleepTime = 500;
                    }
                    else
                    {
                        GetPlaybackImageByLevelToList(CpuLevel.level_80_100);
                        vividThreadSleepTime = 300;
                    }
                    notifyIcon.Icon = new System.Drawing.Icon(playbackImagePath[i++]);//这句会在关闭软件后出错 
                    Thread.Sleep(vividThreadSleepTime);
                }
            }
            catch { }
        }

        /// <summary>
        /// 一直检测当前cpu使用状态
        /// </summary>
        private void DetectCpuThreadDoWork()
        {
            while (true)
            {
                cpuCounterDisplay = cpuCounter.NextValue();
                //cpuCounterDisplay = 90;
                Thread.Sleep(cpuThreadSleepTime);
            }
        }

        /// <summary>
        /// 根据等级把显示icon读取
        /// </summary>
        /// <param name="cpuLevel"></param>
        private void GetPlaybackImageByLevelToList(CpuLevel cpuLevel)
        {
            string[] files = new string[] { };
            switch (cpuLevel)
            {
                case CpuLevel.level_0_20:
                    {
                        files = Directory.GetFiles(
                                ConfigurationManager.AppSettings["playbackImageFload0"],
                                "*.ico", SearchOption.AllDirectories);
                    }
                    break;
                case CpuLevel.level_20_80:
                    {
                        files = Directory.GetFiles(
                                ConfigurationManager.AppSettings["playbackImageFload1"],
                                "*.ico", SearchOption.AllDirectories);
                    }
                    break;
                case CpuLevel.level_80_100:
                    {
                        files = Directory.GetFiles(
                                ConfigurationManager.AppSettings["playbackImageFload2"],
                                "*.ico", SearchOption.AllDirectories);
                    }
                    break;
            }
            playbackImagePath.Clear();
            playbackImagePath.AddRange(files);
            playbackImagePath.Sort();
        }
    }
}
