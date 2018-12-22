using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Project3
{
    public partial class Project3: Form
    {


        public Project3()
        {
            InitializeComponent();
        }

        private void Project3_Load(object sender, EventArgs e)
        {

        }


        private void okButton_Click(object sender, EventArgs e)
        {
            //
            FileStream fs = new FileStream(@"C:\Users\Gökhan\Source\Repos\Project3\Project3\422_720x576.yuv", FileMode.Open);
            Bitmap bmp = new Bitmap(fs);
            Image i = (Image)bmp;

            pictureBox1.Image = i;

            //string text = File.ReadAllText(@"C:\Users\Gökhan\Source\Repos\Project3\Project3\422_720x576.yuv", Encoding.UTF8);
            // weight.Text = text;
            ////
        }

        public static string directory = null;
        private void chooseBttn_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\Gökhan\Source\Repos\Project3\Project3";
                openFileDialog.Filter = "yuv files (*.yuv)|*.yuv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    directory = filePath;
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();


                    using(StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            MessageBox.Show("AA", "File Content at path: " + filePath, MessageBoxButtons.OK);

        }

        private Bitmap image;
        public void pushPhoto(string picLoc)
        {
            if(image != null)
            {
                image.Dispose();
            }

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            image = new Bitmap("@"+ "\""+ picLoc+ "\"");
            pictureBox1.ClientSize = new Size(352, 288);
            pictureBox1.Image = (Image)image;
            //

        }

        private void convertBttn_Click(object sender, EventArgs e)
        {
            Start();
        }


        static double[,] YUV2RGB_CONVERT_MATRIX = new double[3, 3] { { 1, 0, 1.4022 }, { 1, -0.3456, -0.7145 }, { 1, 1.771, 0 } };

        public void Start()
        {

            int width = 352;
            int height = 288;
            int imgSize = width * height;
            int frameSize = imgSize + (imgSize >> 1);


            byte[] yuv = new byte[frameSize];
            byte[] rgb = new byte[3 * imgSize];

            using(FileStream fs = File.OpenRead(directory))
            {
                int frame = (int)fs.Length / frameSize;
                using(BinaryReader br = new BinaryReader(fs))
                {
                    int index = 0;
                    while(br.PeekChar() != -1)
                    {
                        // 循环读取每一桢
                        br.Read(yuv, 0, frameSize);

                        // 转换为 RGB
                        ConvertYUV2RGB(yuv, rgb, width, height);

                        // 写 BMP 文件。 @"C:\Users\Gökhan\Source\Repos\Project3\Project3
                        WriteBMP(rgb, width, height, string.Format(@"C:\Users\Gökhan\Source\Repos\Project3\Project3\yuv2bmp_{0}.bmp", index++));


                        pushPhoto(string.Format(@"C:\Users\Gökhan\Source\Repos\Project3\Project3\yuv2bmp_{0}.bmp", index-1));
                        
                        //
                        //

                    }
                }
            }
        }

        /// <summary>
        /// 将转换后的 RGB 图像数据按照 BMP 格式写入文件。
        /// </summary>
        /// <param name="rgbFrame">RGB 格式图像数据。</param>
        /// <param name="width">图像宽（单位：像素）。</param>
        /// <param name="height">图像高（单位：像素）。</param>
        /// <param name="bmpFile"> BMP 文件名。</param>
        static void WriteBMP(byte[] rgbFrame, int width, int height, string bmpFile)
        {
            // 写 BMP 图像文件。
            int yu = width * 3 % 4;
            int bytePerLine = 0;
            yu = yu != 0 ? 4 - yu : yu;
            bytePerLine = width * 3 + yu;

            using(FileStream fs = File.Open(bmpFile, FileMode.Create))
            {
                using(BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write('B');
                    bw.Write('M');
                    bw.Write(bytePerLine * height + 54);
                    bw.Write(0);
                    bw.Write(54);
                    bw.Write(40);
                    bw.Write(width);
                    bw.Write(height);
                    bw.Write((ushort)1);
                    bw.Write((ushort)24);
                    bw.Write(0);
                    bw.Write(bytePerLine * height);
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);

                    byte[] data = new byte[bytePerLine * height];
                    int gIndex = width * height;
                    int bIndex = gIndex * 2;

                    for(int y = height - 1, j = 0; y >= 0; y--, j++)
                    {
                        for(int x = 0, i = 0; x < width; x++)
                        {
                            data[y * bytePerLine + i++] = rgbFrame[bIndex + j * width + x];    // B
                            data[y * bytePerLine + i++] = rgbFrame[gIndex + j * width + x];    // G
                            data[y * bytePerLine + i++] = rgbFrame[j * width + x];  // R
                        }
                    }

                    bw.Write(data, 0, data.Length);
                    bw.Flush();
                }
            }

        }

        /// <summary>
        /// 将一桢 YUV 格式的图像转换为一桢 RGB 格式图像。
        /// </summary>
        /// <param name="yuvFrame">YUV 格式图像数据。</param>
        /// <param name="rgbFrame">RGB 格式图像数据。</param>
        /// <param name="width">图像宽（单位：像素）。</param>
        /// <param name="height">图像高（单位：像素）。</param>
        static void ConvertYUV2RGB(byte[] yuvFrame, byte[] rgbFrame, int width, int height)
        {
            int uIndex = width * height;
            int vIndex = uIndex + ((width * height) >> 2);
            int gIndex = width * height;
            int bIndex = gIndex * 2;

            int temp = 0;

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    // R分量
                    temp = (int)(yuvFrame[y * width + x] + (yuvFrame[vIndex + (y / 2) * (width / 2) + x / 2] - 128) * YUV2RGB_CONVERT_MATRIX[0, 2]);
                    rgbFrame[y * width + x] = (byte)(temp < 0 ? 0 : (temp > 255 ? 255 : temp));

                    // G分量
                    temp = (int)(yuvFrame[y * width + x] + (yuvFrame[uIndex + (y / 2) * (width / 2) + x / 2] - 128) * YUV2RGB_CONVERT_MATRIX[1, 1] + (yuvFrame[vIndex + (y / 2) * (width / 2) + x / 2] - 128) * YUV2RGB_CONVERT_MATRIX[1, 2]);
                    rgbFrame[gIndex + y * width + x] = (byte)(temp < 0 ? 0 : (temp > 255 ? 255 : temp));

                    // B分量
                    temp = (int)(yuvFrame[y * width + x] + (yuvFrame[uIndex + (y / 2) * (width / 2) + x / 2] - 128) * YUV2RGB_CONVERT_MATRIX[2, 1]);
                    rgbFrame[bIndex + y * width + x] = (byte)(temp < 0 ? 0 : (temp > 255 ? 255 : temp));
                }
            }
        }

    }
}
