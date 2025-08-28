namespace TaskDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"主线程执行业务处理.\n";
            //创建任务
            Task task = new Task(() =>
            {
                this.Invoke(new EventHandler(delegate
                {
                    textBox1.Text = textBox1.Text + $"使用System.Threading.Tasks.Task执行异步操作.\n";
                }));
                for (int i = 0; i < 10; i++)
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        textBox1.Text = textBox1.Text + $"\n";
                    }));
                }
            });
            //启动任务,并安排到当前任务队列线程中执行任务
            task.Start();
            textBox1.Text = textBox1.Text + $"主线程执行其他处理\n";
        }
    }
}
