using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Yolov5Net.Scorer;
using Yolov5Net.Scorer.Models;

namespace BatchInspectionCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var image = await SixLabors.ImageSharp.Image.LoadAsync<Rgba32>(textBox1.Text);
                {
                    using var scorer = new YoloScorer<YoloCocoP5Model>(textBox2.Text);
                    {
                        var predictions = scorer.Predict(image);

                        var font = new Font(new FontCollection().Add("C:/Windows/Fonts/consola.ttf"), 50);

                        foreach (var prediction in predictions) // draw predictions
                        {
                            var score = Math.Round(prediction.Score, 2);

                            var (x, y) = (prediction.Rectangle.Left - 3, prediction.Rectangle.Top - 23);

                            image.Mutate(a => a.DrawPolygon(new SixLabors.ImageSharp.Drawing.Processing.Pen(prediction.Label.Color, 5),
                                new PointF(prediction.Rectangle.Left, prediction.Rectangle.Top),
                                new PointF(prediction.Rectangle.Right, prediction.Rectangle.Top),
                                new PointF(prediction.Rectangle.Right, prediction.Rectangle.Bottom),
                                new PointF(prediction.Rectangle.Left, prediction.Rectangle.Bottom)
                            ));


                            image.Mutate(a => a.DrawText($"{prediction.Label.Name} ({score})",
                                font, prediction.Label.Color, new PointF(x, y - 25)));
                        }

                        string imageSavePath = Directory.GetCurrentDirectory() + @"\result_label.jpg";
                        if (File.Exists(imageSavePath))
                        {
                            // 如果文件存在，则删除该文件
                            File.Delete(imageSavePath);
                        }
                        await image.SaveAsync(imageSavePath);
                        image1.Source = new BitmapImage(new Uri(imageSavePath));
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}