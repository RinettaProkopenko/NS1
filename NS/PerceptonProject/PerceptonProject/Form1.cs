﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerceptonProject
{
    public partial class MainForm : Form
    {
        int nCells = 10;
        int ht = 0;
        int wt = 0;
        bool drawing = false;

        public MainForm()
        {
            InitializeComponent();
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

            int i = wt;

            while (i < mX)
            {
                gr.DrawLine(pen, i, 0, i, mY);
                i += wt;
            }

            i = ht;

            while (i < mY)
            {
                gr.DrawLine(pen, 0, i, mX, i);
                i += ht;
            }

            drawingField.Image = bmp;
        }

        private void drawingField_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                Draw(e.X, e.Y);
            }
        }

        private int[] getMasCoordinates(int x, int y)
        {
            int[] res = new int[2];
            res[0] = x - (x % wt);
            res[1] = y - (y % ht);
            return res;
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

        private void Clear_Click(object sender, EventArgs e)
        {
            printGrid();
        }

        private void Train_Click(object sender, EventArgs e)
        {
            Image img = ResizePicture();
            //считываем данные в таблицу
            //инициализируем таблицу весов, если она пустая
            //применяем алгоритм обучения
            //задаем вопрос пользователю 
            //если нет, производим корректировку весов
        }

        private Image ResizePicture()
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
            for(int i = 0; i<nCells - 1; i++)
            {
                int j = wt;
                int minX = 0;
                int maxX = 0;
                while(minX < bmp.Width && bmp.GetPixel(minX, i*ht).ToArgb() != Color.Blue.ToArgb())
                {
                    minX += wt;
                }

                if (xFirst < 0 && minX < bmp.Width) xFirst = minX;

                maxX = minX;
                int x = maxX;

                while(x < bmp.Width)
                {
                    if(bmp.GetPixel(x, i * ht).ToArgb() == Color.Blue.ToArgb())
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

                if (yFirst < 0 && minY < bmp.Height) yFirst = minY;
  

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

            //double kX = drawingField.Width / maxWidth;
            //double kY = drawingField.Height / maxHeight;

            //перенести риунок в начало координат
            for(int i = 0; i<bmp.Width; i++)
                for (int j =0; j<bmp.Height; j++)
                {
                    if (i < bmp.Width - xFirst && j < bmp.Height - yFirst) bmp.SetPixel(i, j, bmp.GetPixel(i + xFirst, j + yFirst));
                    else bmp.SetPixel(i, j, Color.White);
                }

            //растянуть по ширине и высоте в зависимости от полученных коэффициентов

            //возвращаем полученное изображение
            drawingField.Image = bmp;
            return null;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            printGrid();
        }

        private void Check_Click(object sender, EventArgs e)
        {
            //запрашваем результат у перцептрона
            //выдаем ответ пользователю
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //вызываем диалог сохранения файла
            //записываем веса в файл
        }

        private void Load_Click(object sender, EventArgs e)
        {
            //вызываем диалог открытия файла
            //заполняем таблицу весов
        }

        private void drawingField_Click(object sender, EventArgs e)
        {

        }
    }
}