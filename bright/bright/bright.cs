using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace bright_histog
{
    public partial class Form1 : Form
    {
        //Функція, що розраховує новий кольор для точки
        public int[] newcolor(int[] m,int p)

        {
            //Записуємо результати розрахунків
            int[] newm = new int[256];
            int s = 0;
            for (int i = 0; i < m.Length; i++)
            {
                s += m[i];
                //формула для розрахування нового кольору для покращення картинки
                newm[i] = (int)255*s/p;
            }
            return newm;
        }
        public void histogram(Bitmap my_img, int x1, int y1, int p1, int h1)
        {
            int[] br_r = new int[256];
            int[] br_g = new int[256];
            int[] br_b = new int[256];

            int x = 0;
            int y = 0;
            for (x = 0; x < my_img.Width; x++)
            {
                for (y = 0; y < my_img.Height; y++)
                {
                    br_r[my_img.GetPixel(x, y).R]++;
                    br_g[my_img.GetPixel(x, y).G]++;
                    br_b[my_img.GetPixel(x, y).B]++;
                }
            }

            Chart charting = new Chart();
            // Розміщуємо діаграму на формі 
            charting.Parent = this;

            // Задаємо параметри елементу
            charting.SetBounds(x1, y1, p1, h1);

            // Створюємо нову обл для побудови граф
            ChartArea oblast = new ChartArea();
            
            // Даємо їй назву, для додавання графіків у майб
            oblast.Name = "myNewGraph";

            // Задаємо ліву і праву границі осі х
            oblast.AxisX.Minimum = 0;
            oblast.AxisX.Maximum = 255;

            // Визначаємо крок сітки 
            oblast.AxisX.MajorGrid.Interval = 1;

            // Додаємо область до діаграми
            charting.ChartAreas.Add(oblast);
            
            // Створюємо для першого графіку об'єкт
            Series series1 = new Series();
            series1.Color = Color.Blue;

            // Силка на область для побудови графіку 
            series1.ChartArea = "myNewGraph";
            
            // тип графіка - сплайн
            series1.ChartType = SeriesChartType.Bar;
            
            // ширина лінії графіку
            series1.BorderWidth = 3;
            
            // Назва графіку(для відобр у легенді)
            // Додаємо діаграми
            charting.Series.Add(series1);
            // Таке ж для 2 кольору
            Series series2 = new Series();
            // Силка на обл побудови граф
            series2.ChartArea = "myNewGraph";
            // тип графіка - сплайн
            series2.ChartType = SeriesChartType.Bar;
            
            series2.BorderWidth = 3;
            series2.Color = Color.Red;
            // Назва графіку
            
            charting.Series.Add(series2);
            //для 3 кольору
            Series series3 = new Series();
            series3.ChartArea = "myNewGraph";
            
            series3.ChartType = SeriesChartType.Bar;
           
            series3.BorderWidth = 3;
           
            
            series3.Color = Color.Green;

            charting.Series.Add(series3);


            int[] h = new int[256];
            for (int i = 0; i < 256; i++)
            {
                h[i] = i;
            }

            charting.Series[0].Points.DataBindXY(h, br_b);
            charting.Series[1].Points.DataBindXY(h, br_r);
            charting.Series[2].Points.DataBindXY(h, br_g);
        }


        public Form1()
        {
            InitializeComponent();

            int[] bright_r = new int[256];
            int[] bright_g = new int[256];
            int[] bright_b = new int[256];


            Bitmap my_img = (Bitmap)Bitmap.FromFile(@"image.png");
            Bitmap new_img = (Bitmap)Bitmap.FromFile(@"image.png");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Image = my_img;

            pictureBox2.Location = new Point(0, my_img.Height);
            pictureBox2.Image = new_img;
            int x = 0;
            int y = 0;
            for (x = 0; x < my_img.Width; x++)
            {
                for (y = 0; y < my_img.Height; y++)
                {
                    //Створюємо масив RGB значень для кожного пікселя картинки 
                    bright_r[my_img.GetPixel(x, y).R]++;
                    bright_g[my_img.GetPixel(x, y).G]++;
                    bright_b[my_img.GetPixel(x, y).B]++;
                }
            }
            //виводимо гістограму для старої картинки
            histogram(my_img, my_img.Width + 20, 0, 500, 250);

            int w = my_img.Width * my_img.Height;

            int[] new_r = newcolor(bright_r,w);
            int[] new_g = newcolor(bright_g,w);
            int[] new_b = newcolor(bright_b,w);

            for (x = 0; x < my_img.Width; x++)
            {
                for (y = 0; y < my_img.Height; y++)
                {
                    Color c = Color.FromArgb(new_r[my_img.GetPixel(x, y).R],new_g[my_img.GetPixel(x, y).G],new_b[my_img.GetPixel(x, y).B]);
                    //Встановлюємо нове покращене значення пікселя для картинки, розраховане за формулою
                    new_img.SetPixel(x, y, c);
                }
            }
            //виводимо гістограму для нової картинки
            histogram(new_img, my_img.Width+20, my_img.Height, 500, 250);





        }
    }
}
