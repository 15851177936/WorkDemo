using LMStringConvertLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WorkDemo
{
    public partial class Form1 : Form
    {
        //LogHelper logHelper;//log输出
        //object yamlData;
        //HObject hImage;//halcon图片        
        //ToolTip toolTip1;// 创建the ToolTip 

        public Form1()
        {
            InitializeComponent();

            //logHelper = new LogHelper(textBox_display);
            //yamlData = null;
            //hImage = new HObject();
            //toolTip1 = new ToolTip();

            //MouseWheel += Form1_MouseWheel;//鼠标控制图像放大缩小
        }

        /// <summary>
        /// 写入数据到Yaml文件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_write_yaml_Click(object sender, EventArgs e)
        {
            var test = new YamlClass();
            test.yamlClass = new List<YamlClass.YamlClassCell> { };
            var newCell = new YamlClass.YamlClassCell
            {
                arraytest = new string[] { "ABC1", "BCD", "123" },
                stringtest = "这是测试",
                inttest = 5,
                dictionarytest = new Dictionary<string, string> {
                    { "KEY1", "VAL1"},
                    {"KEY2", "VAL2" },
                    {"KEY3", "VAL3" }
                },
            };
            test.yamlClass.Add(newCell);
            newCell = new YamlClass.YamlClassCell
            {
                arraytest = new string[] { "A", "B", "123" },
                stringtest = "这是测试2",
                inttest = 5,
                dictionarytest = new Dictionary<string, string> {
                    { "KEY1", "VAL1"},
                    {"KEY2", "VAL2" },
                    {"KEY3", "VAL3" }
                },
            };
            test.yamlClass.Add(newCell);
            YamlHelper.WriteToYaml<YamlClass>("test.yaml", test);
        }

        /// <summary>
        /// 读取Yaml文件到代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_read_yaml_Click(object sender, EventArgs e)
        {
            //var test = YamlHelper.ReadYaml<YamlClass>("test.yaml");
            //yamlData = test;
            //logHelper.Info(String.Join(",", test.yamlClass[0].arraytest));
            //logHelper.Info(test.yamlClass[0].stringtest.ToString());
            //logHelper.Info(test.yamlClass[0].inttest.ToString());
            //logHelper.Info(test.yamlClass[0].dictionarytest.Count.ToString());
        }

        /// <summary>
        /// Yaml文件转换成json文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_yaml_to_json_Click(object sender, EventArgs e)
        {
            //if (yamlData == null)
            //{
            //    MessageBox.Show("yaml 数据为空。");
            //    return;
            //}
            //var serializer = new JsonSerializer();
            //serializer.Formatting = Newtonsoft.Json.Formatting.Indented; // For pretty-printed JSON

            //using (var stringWriter = new StringWriter())
            //{
            //    serializer.Serialize(stringWriter, yamlData);

            //    // 解析 JSON 字符串
            //    var jsonData = JsonConvert.DeserializeObject<YamlClass>(stringWriter.ToString());
            //    // 获取某一个关键字的值
            //    //Console.WriteLine(jsonData.stringtest);
            //}
        }

        /// <summary>
        /// 将一个文件夹中的文件更改名称到另一个文件夹中
        /// 命名名1~文件个数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string originalFile = OpenFile("请选择需要更改名称的文件"); // 原本路径
            string newFile = OpenFile("请选择更改名称后需要保存到的地址"); // 更改名字后的路径

            label1.Text = originalFile;
            label2.Text = newFile;

            //
            //var res = MessageBox.Show("是否执行？(操作不可返回)", "是否取消", MessageBoxButtons.YesNoCancel);
            //if (res.Equals(DialogResult.No)) return;

            //此方法不操作
            var res = MessageBox.Show("危险操作！");
            if (res.Equals(DialogResult.OK)) return;

            try
            {
                // 获取指定文件夹中的所有文件
                string[] files = Directory.GetFiles(originalFile);

                int pictureIndex = 1;
                // 遍历文件数组并重命名每个文件
                foreach (string file in files)
                {
                    // 获取文件的原始名称（不含扩展名）和扩展名
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    string extension = Path.GetExtension(file);

                    // 构建新的文件名
                    string newFileName = pictureIndex + extension;

                    // 构建新的文件路径
                    string newFilePath = Path.Combine(newFile, newFileName);

                    // 重命名文件
                    File.Move(file, newFilePath);
                    Console.WriteLine($"Renamed '{file}' to '{newFilePath}'");
                    pictureIndex++;
                }
            }
            catch (Exception ex)
            {
                // 处理可能发生的异常，如路径不存在、没有权限等
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// 获取一个文件夹下所有文件的路径显示到控制台上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //// 指定要读取的文件夹路径
            //string folderPath = OpenFile("选择想要遍历的文件路径:"); // 请替换为实际的文件夹路径
            //label3.Text = folderPath;
            //try
            //{
            //    // 读取文件夹及其所有子文件夹中的文件路径
            //    string[] filePaths = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            //    // 输出文件路径
            //    foreach (string filePath in filePaths)
            //    {
            //        logHelper.Info(filePath);
            //        Console.WriteLine(filePath);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logHelper.Debug("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            //    // 处理任何异常，例如文件夹不存在或没有访问权限等
            //    Console.WriteLine("An error occurred: " + ex.Message + "\n" + ex.StackTrace);
            //}
        }

        /// <summary>
        /// 计算图片平均灰度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //HObject image = new HObject();
            //HObject region = new HObject();
            //HTuple mean = new HTuple();
            //HTuple deviation = new HTuple();

            //HOperatorSet.ReadImage(out image, @"C:\Users\qiwa\Pictures\Saved Pictures\th.jpg");//图片路径另外添加
            //HOperatorSet.Threshold(image, out region, 1, 255);
            //HOperatorSet.Intensity(region, image, out mean, out deviation);
        }

        /// <summary>
        /// 浏览图片识别的模型点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //ShapeModel shapeModel = new ShapeModel();
            //HObject hObject = new HObject();
            //HImage image = new HImage();
            //Matching matching = new Matching();
            //List<ShapeModel> shapeModelList = new List<ShapeModel>();

            //HOperatorSet.ReadImage(out hObject, @"C:\Users\qiwa\Desktop\pictures\pictures\pictures\Z.bmp");
            //image = new HImage(hObject);
            //shapeModel = new ShapeModel(image,
            //    new RoiRect(1566.35000000f, 2235.15000000f, 1906.58000000f, 2630.78000000f),
            //    0, 360, 0.35f, 5, new PointF((1566.35000000f + 1906.58000000f) / 2, (2235.15000000f + 2630.78000000f) / 2));
            //shapeModel.CreateShapeModel();
            //shapeModelList.Add(shapeModel);
            //matching = new Matching(shapeModelList);

            //HOperatorSet.ReadImage(out hObject, @"C:\Users\qiwa\Desktop\pictures\pictures\pictures\Z_1.bmp");
            //image = new HImage(hObject);
            ////(ReturnCode returnCode, List<List<double[]>> transMarixResult) result = matching.FindShapeModels(image);


            //(ReturnCode returnCode, List<List<double[]>> transMarixResult) result1 = matching.FindShapeModels(new HImage());
        }

        /// <summary>
        /// halcon C# example -- Matching
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            //HImage image = new HImage(@"D:\own\2024\4G\Code\DTE_ImageProcessing\test\testData\Matching\字母\300-50000-2-Model_A.bmp");
            //buttonRefresh_Click(null, null);

            //HRegion rectangle = new HRegion(1655.25000000, 2560.90000000, 1987.81000000, 2899.70000000);
            //HRegion modelRegion = new HRegion();
            //HShapeModel shapeModel = new HShapeModel();

            //hSmartWindowControl1.HalconWindow.DispObj(image);
            //HImage imgReduced;

            //imgReduced = image.ReduceDomain(rectangle);
            //imgReduced.InspectShapeModel(out modelRegion, 1, 30);//改变最后一个参数可以取舍模型点,值越大，模型点越少
            //// The default contructor creates an empty generic shape model.
            //// This is different to many other constructors that create
            //// an empty uninitialized instance.
            //// In this example matching works with default parameters.
            //// For illustration, we set angle_step to 1.0.
            //shapeModel.SetGenericShapeModelParam("angle_step", new HTuple(1.0).TupleRad().D);
            //shapeModel.TrainGenericShapeModel(imgReduced);

            //hSmartWindowControl1.HalconWindow.DispObj(image);
            //modelRegion.DispObj(hSmartWindowControl1.HalconWindow);
        }

        //#region 鼠标滚动放大缩小图片
        //public void Form1_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    //HSmartWindowControl控件的区域
        //    Rectangle rect = hSmartWindowControl1.RectangleToScreen(hSmartWindowControl1.ClientRectangle);
        //    //滚动时，鼠标悬停在在HSmartWindowControl控件上
        //    if (rect.Contains(Cursor.Position))
        //    {
        //        //缩放
        //        hSmartWindowControl1.HSmartWindowControl_MouseWheel(sender, e);
        //    }
        //}

        /// <summary>
        /// 刷新hSmartWindowControl(重新设置控件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void buttonRefresh_Click(object sender, EventArgs e)
        //{
        //if (hImage != null)
        //{
        //    #region hSmartWindowControl配置
        //    //获取图像及显示窗口长宽
        //    HOperatorSet.GetImageSize(hImage, out HTuple imgWidth, out HTuple imgHeight);
        //    int wndWidth = hSmartWindowControl1.ClientRectangle.Width;
        //    int wndHeight = hSmartWindowControl1.ClientRectangle.Height;

        //    //计算比例
        //    double scale = Math.Max(1.0 * imgWidth.I / wndWidth, 1.0 * imgHeight / wndHeight);
        //    double w = wndWidth * scale;
        //    double h = wndHeight * scale;
        //    //居中时，Part的区域
        //    hSmartWindowControl1.HalconWindow.SetPart(-(h - imgHeight) / 2, -(w - imgWidth) / 2, imgHeight + (h - imgHeight.D) / 2, imgWidth + (w - imgWidth) / 2);

        //    //背景色
        //    hSmartWindowControl1.HalconWindow.SetWindowParam("background_color", "black");
        //    hSmartWindowControl1.HalconWindow.ClearWindow();
        //    //CreateBtn.IsEnabled = false;
        //    hSmartWindowControl1.HalconWindow.SetLineWidth(3);
        //    hSmartWindowControl1.HalconWindow.SetColor("green");
        //    hSmartWindowControl1.HalconWindow.SetDraw("fill");
        //    #endregion
        //    hSmartWindowControl1.HalconWindow.DispObj(hImage);
        //}
        //}
        //#endregion

        /// <summary>
        /// 打开图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_open_image_Click(object sender, EventArgs e)
        {
            //OpenFileDialog file = new OpenFileDialog();
            //file.InitialDirectory = ".";
            //file.Filter = "Image Files (*.jpg;*.png;*.bmp;*gif;*.jpeg)|*.jpg;*.png;*.bmp;*.gif;*.jpeg";
            ////Image Files (*.jpg;*.png;*.bmp;*gif;*.jpeg)|*.jpg;*.png;*.bmp;*.gif;*.jpeg
            //file.ShowDialog();
            //if (file.FileName != string.Empty)
            //{
            //    try
            //    {
            //        string imagePath = file.FileName;//获得文件的绝对路径
            //        HOperatorSet.ReadImage(out hImage, imagePath);
            //        DispObj(hImage);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        /// <summary>
        /// 自适应到窗体显示图片
        /// </summary>
        /// <param name="image">需要显示的图片</param>
        //private void DispObj(HObject image)
        //{
        //int cWidth = hSmartWindowControl1.Width;
        //int cHeight = hSmartWindowControl1.Height;
        //HOperatorSet.GetImageSize(image, out HTuple mWidth, out HTuple mHeight);
        //double scaleWidth = 1.0 * mWidth / cWidth;
        //double scaleHeight = 1.0 * mHeight / cHeight;
        //double row1, col1, row2, col2;
        //if (scaleWidth > scaleHeight)
        //{
        //    double finHeight = cHeight * scaleWidth;
        //    row1 = -(1.0) * (finHeight - mHeight) / 2;
        //    col1 = 0;
        //    row2 = row1 + finHeight;
        //    col2 = mWidth;
        //}
        //else
        //{
        //    double finWidth = cWidth * scaleHeight;
        //    row1 = 0;
        //    col1 = -(1.0) * (finWidth - mWidth) / 2;
        //    row2 = mHeight;
        //    col2 = col1 + finWidth;
        //}
        //HOperatorSet.SetPart(hSmartWindowControl1.HalconWindow, row1, col1, row2, col2);
        //HOperatorSet.DispObj(image, hSmartWindowControl1.HalconWindow);
        //}

        /// <summary>
        /// 打个文件
        /// </summary>
        /// <param name="description">提示信息</param>
        /// <returns>
        /// 打开文件的路径
        /// </returns>
        private string OpenFile(string description)
        {
            //选择文件夹路径
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            //提示信息
            dialog.Description = description;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            return String.Empty;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            //// 设置显示样式
            //toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            //toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            //toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            //toolTip1.ShowAlways = true;//是否显示提示框

            ////  设置伴随的对象.
            //toolTip1.SetToolTip(this.label1, label1.Text);//设置提示按钮和提示内容
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            //// 设置显示样式
            //toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            //toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            //toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            //toolTip1.ShowAlways = true;//是否显示提示框

            ////  设置伴随的对象.
            //toolTip1.SetToolTip(this.label2, label2.Text);//设置提示按钮和提示内容
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            //// 设置显示样式
            //toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            //toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            //toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            //toolTip1.ShowAlways = true;//是否显示提示框

            ////  设置伴随的对象.
            //toolTip1.SetToolTip(this.label3, label3.Text);//设置提示按钮和提示内容
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TransBefore.Text == String.Empty)
            {
                MessageBox.Show("转换字符为空！");
                return;
            }
            TransAfter.Text = LMStringConvertManager.DecryptAES128(TransBefore.Text);
        }
    }
}
