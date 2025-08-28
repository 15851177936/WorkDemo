using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPUMonitor
{
    public class VividPicture
    {
        NotifyIcon formNotifyIcon = new NotifyIcon();
        System.Drawing.Icon iconLevel0_1;
        System.Drawing.Icon iconLevel0_2;
        System.Drawing.Icon iconLevel0_3;


        System.Drawing.Icon iconLevel50_1;
        System.Drawing.Icon iconLevel50_2;
        System.Drawing.Icon iconLevel50_3;

        System.Drawing.Icon iconLevel100_1;
        System.Drawing.Icon iconLevel100_2;
        System.Drawing.Icon iconLevel100_3;


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="formNotifyIcon"></param>
        /// <param name="iconLevel0_1_path"></param>
        /// <param name="iconLevel0_2_path"></param>
        /// <param name="iconLevel0_3_path"></param>
        /// <param name="iconLevel50_1_path"></param>
        /// <param name="iconLevel50_2_path"></param>
        /// <param name="iconLevel50_3_path"></param>
        /// <param name="iconLevel100_1_path"></param>
        /// <param name="iconLevel100_2_path"></param>
        /// <param name="iconLevel100_3_path"></param>
        public VividPicture(NotifyIcon formNotifyIcon, string iconLevel0_1_path, string iconLevel0_2_path, string iconLevel0_3_path,
            string iconLevel50_1_path, string iconLevel50_2_path, string iconLevel50_3_path
            , string iconLevel100_1_path, string iconLevel100_2_path, string iconLevel100_3_path)
        {
            this.formNotifyIcon = formNotifyIcon;

            this.iconLevel0_1 = new System.Drawing.Icon(iconLevel0_1_path);
            this.iconLevel0_2 = new System.Drawing.Icon(iconLevel0_2_path);
            this.iconLevel0_3 = new System.Drawing.Icon(iconLevel0_3_path);

            if (iconLevel50_1_path != null)
                this.iconLevel50_1 = new System.Drawing.Icon(iconLevel50_1_path);
            if (iconLevel50_2_path != null)
                this.iconLevel50_2 = new System.Drawing.Icon(iconLevel50_2_path);
            if (iconLevel50_3_path != null)
                this.iconLevel50_3 = new System.Drawing.Icon(iconLevel50_3_path);

            if (iconLevel100_1_path != null)
                this.iconLevel100_1 = new System.Drawing.Icon(iconLevel100_1_path);
            if (iconLevel100_2_path != null)
                this.iconLevel100_2 = new System.Drawing.Icon(iconLevel100_2_path);
            if (iconLevel100_3_path != null)
                this.iconLevel100_3 = new System.Drawing.Icon(iconLevel100_3_path);
        }

        /// <summary>
        /// 图标闪烁
        /// </summary>
        /// <param name="icon1"></param>
        /// <param name="icon2"></param>
        /// <param name="icon3"></param>
        public async Task VividPictureLevel0()
        {
            await Task.Run(async () =>
            {
                formNotifyIcon.Icon = iconLevel0_1;
                await Task.Delay(100);
                formNotifyIcon.Icon = iconLevel0_2;
                await Task.Delay(100);
                formNotifyIcon.Icon = iconLevel0_3;
                await Task.Delay(100);
                formNotifyIcon.Icon = iconLevel0_1;
                await Task.Delay(100);
                formNotifyIcon.Icon = iconLevel0_2;
                await Task.Delay(100);
                formNotifyIcon.Icon = iconLevel0_3;
                await Task.Delay(100);
                formNotifyIcon.Icon = iconLevel0_1;
                await Task.Delay(100);
                formNotifyIcon.Icon = iconLevel0_2;
                await Task.Delay(100);
                formNotifyIcon.Icon = iconLevel0_3;
                await Task.Delay(100);
            });
        }
    }
}
