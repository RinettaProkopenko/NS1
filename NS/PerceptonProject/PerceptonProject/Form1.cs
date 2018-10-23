using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PerceptonProject
{
    public partial class MainForm : Form
    {
        int nCells = 20;
        int ht = 0;
        int wt = 0;
        int x0 = 1;
        double h = 0.1;
        bool drawing = false;
        double[,] w;
        double w0;
        int[,] x;


        #region initial     
        public MainForm()
        {
            InitializeComponent();
            printGrid();
            w = new double[nCells, nCells];
            x = new int[nCells, nCells];
            InitW();
        }

        private void InitW()
        {
            Random rand = new Random();
            w0 = Convert.ToDouble(rand.Next(-5, 5)) / 10;
            for (int i = 0; i < nCells; i++)
                for (int j = 0; j < nCells; j++)
                {
                    w[i, j] = Convert.ToDouble(rand.Next(-5, 5)) / 10;
                }
        }


        private void MainForm_Resize(object sender, EventArgs e)
        {
            printGrid();
        }
        
        private void printGrid()
        {
            Bitmap bmp = new Bitmap(drawingField.Width, drawingField.Height);
            Graphics gr = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);

            int mY = drawingField.Height;
            int mX = drawingField.Width;

            ht = mY / nCells;
            wt = mX / nCells;

            DrowPanel.Width = wt * nCells;
            DrowPanel.Height = ht * nCells;

            //int i = wt;

            //while (i < mX)
            //{
            //    gr.DrawLine(pen, i, 0, i, mY);
            //    i += wt;
            //}

            //i = ht;

            //while (i < mY)
            //{
            //    gr.DrawLine(pen, 0, i, mX, i);
            //    i += ht;
            //}

            drawingField.Image = bmp;
        }
        #endregion

        #region draw
        private void drawingField_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                Draw(e.X, e.Y);
            }
        }


        private void drawingField_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            Draw(e.X, e.Y);
        }

        private void drawingField_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void Draw(int x, int y)
        {
            Image img = drawingField.Image;
            int[] mas = getMasCoordinates(x, y);
            Graphics gr = Graphics.FromImage(img);
            gr.FillRectangle(Brushes.Blue, mas[0], mas[1], wt, ht);
            drawingField.Image = img;
        }

        private int[] getMasCoordinates(int x, int y)
        {
            int[] res = new int[2];
            res[0] = x - (x % wt);
            res[1] = y - (y % ht);
            return res;
        }

        #endregion

        #region buttons
        private void Clear_Click(object sender, EventArgs e)
        {
            printGrid();
        }

        private void Train_Click(object sender, EventArgs e)
        {
            Bitmap img = ResizePicture();

            //считываем данные в таблицу
            readInputs();
            //вычисляем результат
           int result = Answer();
            //задаем вопрос пользователю 
            string q = result == 0 ? "Это нолик?" : "Это звездочка?";
            DialogResult dialogResult = MessageBox.Show(q,"",MessageBoxButtons.YesNo);
            //если нет, производим корректировку весов
            if (dialogResult == DialogResult.No)
            {
                int rightAns = q == "Это нолик?" ? 1 : 0;
                int delta = rightAns - result;
                ChangeW(delta);
            }
            
        }

        private void Check_Click(object sender, EventArgs e)
        {
            Bitmap img = ResizePicture();
            readInputs();
            //запрашваем результат у перцептрона
            int result = Answer();
            //выдаем ответ пользователю
            string ans = result == 0 ? "Это нолик!": "Это звездочка!";
            MessageBox.Show(ans);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            //вызываем диалог сохранения файла
            if (save.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = save.FileName;
            //записываем веса в файл
            StreamWriter str = new StreamWriter(filename);
            str.WriteLine(w0);
            for (int i = 0; i < nCells; i++)
            {
                for(int j = 0; j< nCells; j++)
                {
                    str.Write(w[i, j] + " ");
                }
                str.WriteLine();
            }
            str.Close();
            MessageBox.Show("Файл сохранен");
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = open.FileName;
            StreamReader f = new StreamReader(filename);
            string s;
            string[] buf;
            int i = 0;
            //заполняем таблицу весов
            s = f.ReadLine();
            buf = s.Split(' ');

            for (int j = 0; j < buf.Length; j++)
            {
                double t = Convert.ToDouble(buf[j]);
                w0 = t;
            }

            while ((s = f.ReadLine()) != null)
            {
                buf = s.Split(' ');
                for (int j = 0; j < nCells; j++)
                {
                    double t = Convert.ToDouble(buf[j]);
                    w[i, j] = t;
                }
                i++;
            }
        }

        #endregion

        #region algoritm
        private Bitmap ResizePicture()
        {
            Bitmap bmp = (Bitmap)drawingField.Image;

            // поиск первой точки рисунка
            int xFirst = -1;
            int yFirst = -1;

            //поиск ширины и высоты рисунка

            int maxWidth = 0;
            int maxHeight = 0;
            int width = 0;
            int height = 0;
            for (int i = 0; i < nCells - 1; i++)
            {
                int j = wt;
                int minX = 0;
                int maxX = 0;
                while (minX < bmp.Width && bmp.GetPixel(minX, i * ht).ToArgb() != Color.Blue.ToArgb())
                {
                    minX += wt;
                }

                if (yFirst < 0 && minX < bmp.Width) yFirst = i * ht;

                maxX = minX;
                int x = maxX;

                while (x < bmp.Width)
                {
                    if (bmp.GetPixel(x, i * ht).ToArgb() == Color.Blue.ToArgb())
                    {
                        maxX = x;
                    }
                    x += wt;
                }

                width = (maxX + wt) - minX;
                if (width > maxWidth) maxWidth = width;
            }

            for (int i = 0; i < nCells - 1; i++)
            {
                int j = ht;
                int minY = 0;
                int maxY = 0;
                while (minY < bmp.Height && bmp.GetPixel(i * wt, minY).ToArgb() != Color.Blue.ToArgb())
                {
                    minY += ht;
                }

                if (xFirst < 0 && minY < bmp.Height) xFirst = i * wt;


                maxY = minY;
                int y = maxY;

                while (y < bmp.Height)
                {
                    if (bmp.GetPixel(i * wt, y).ToArgb() == Color.Blue.ToArgb())
                    {
                        maxY = y;
                    }
                    y += ht;
                }

                height = (maxY + ht) - minY;
                if (height > maxHeight) maxHeight = height;
            }

            int kX = bmp.Width / maxWidth;
            int kY = bmp.Height / maxHeight;

            //перенести риунок в начало координат
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (i < bmp.Width - xFirst && j < bmp.Height - yFirst) bmp.SetPixel(i, j, bmp.GetPixel(i + xFirst, j + yFirst));
                    else bmp.SetPixel(i, j, Color.White);
                }

            //растянуть по ширине и высоте в зависимости от полученных коэффициентов
            int ni = 0;
            int nj = 0;
            Bitmap nBmp = new Bitmap(bmp);
            for (int j = 0; j < maxHeight; j++)
                for (int l = 0; l < kY; l++)
                {
                    ni = 0;
                    for (int i = 0; i < maxWidth; i++)
                        for (int m = 0; m < kX; m++)
                        {
                            nBmp.SetPixel(ni, nj, bmp.GetPixel(i, j));
                            ni++;
                        }
                    nj++;
                }

            //возвращаем полученное изображение
            //drawingField.Image = nBmp;
            return nBmp;
        }

        private void readInputs()
        {
            Bitmap bmp = new Bitmap(drawingField.Image);
            for (int i = 0; i < nCells; i++)
                for (int j = 0; j < nCells; j++)
                    x[i, j] = bmp.GetPixel(i * wt, j * ht).ToArgb() == Color.Blue.ToArgb() ? 1 : 0;
        }

        int Answer()
        {
            double s = w0 * x0;
            for (int i = 0; i < nCells; i++)
                for (int j = 0; j < nCells; j++)
                    s += w[i, j] * x[i, j];
            return s >= 0 ? 1 : 0;
        }

        void ChangeW(int delta)
        {
            w0 = w0 + h * delta * x0;
            for (int i = 0; i < nCells; i++)
                for (int j = 0; j < nCells; j++)
                    w[i, j] = w[i, j] + h * delta * x[i, j];
        }
        #endregion
    }
}
