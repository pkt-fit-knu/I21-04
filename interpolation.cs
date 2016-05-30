using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Npgsql;
using Emgu.CV.UI;

namespace interpolation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Image<Gray, Byte> imgPr;
            string src = @"interpolation.png";
            Image<Bgr, Byte> firstimg;

            firstimg = new Image<Bgr, byte>((Bitmap)Bitmap.FromFile(src));

            imgPr = firstimg.InRange(new Bgr(0, 0, 0), new Bgr(100, 100, 100));

            

            int z = 3;

            Image<Bgr, Byte> zoom = new Image<Bgr, byte>(imgPr.Width * z, imgPr.Height * z);

            for (int i = 0; i < imgPr.Height * z; i++)
            {
                for (int j = 0; j < imgPr.Width * z; j++)
                {
                    if (i % z == 0)//i
                    {
                        if (j % z == 0)//j
                        {
                            zoom[i, j] = firstimg[i / z, j / z];
                        }
                        else// j%k+1
                        {
                            Bgr color_m = firstimg[i / z, j / z];
                            Bgr color_t;

                            if ((j / z) + 1 < firstimg.Width)
                                color_t = firstimg[i / z, (j / z)+1];
                            else
                                color_t = color_m;
                            Bgr bgr = new Bgr((color_m.Blue + color_t.Blue) / 2, (color_m.Green + color_t.Green) / 2, (color_m.Red + color_t.Red) / 2);
                            zoom[i, j] = bgr;
                        }
                    }
                    else 
                    //i
                    {
                        if (j % z == 0)
                    //j
                        {
                            Bgr color_l = firstimg[i / z, j / z];
                            Bgr color_r;
                            if ((i / z) + 1 < firstimg.Height)
                                color_r = firstimg[Convert.ToInt32((i / z) + 1), j / z];
                            else
                                color_r = color_l;
                            Bgr bgr = new Bgr((color_l.Blue + color_r.Blue) / 2, (color_l.Green + color_r.Green) / 2, (color_l.Red + color_r.Red) / 2);
                            zoom[i, j] = bgr;
                        }
                        else 


                        //j
                        {
                            Bgr color_l_t = firstimg[i / z, j / z];
                            Bgr color_r_t;
                            if ((i / z) + 1 < firstimg.Height)
                                color_r_t = firstimg[(i / z) + 1, j / z];
                            else
                                color_r_t = color_l_t;
                            Bgr bgr_top = new Bgr((color_l_t.Blue + color_r_t.Blue) / 2, (color_l_t.Green + color_r_t.Green) / 2, (color_l_t.Red + color_r_t.Red) / 2);

                            Bgr bgr_bottom;
                            if ((j / z) + 1 < firstimg.Width)
                            {
                                Bgr color_l_b = firstimg[i / z, (j / z) + 1];
                                Bgr color_r_b;
                                if ((i / z) + 1 < firstimg.Height)
                                    color_r_b = firstimg[(i / z) + 1, (j / z) + 1];
                                else
                                    color_r_b = color_l_b;
                                bgr_bottom = new Bgr((color_l_b.Blue + color_r_b.Blue) / 2, (color_l_b.Green + color_r_b.Green) / 2, (color_l_b.Red + color_r_b.Red) / 2);
                            }
                            else
                                bgr_bottom = bgr_top;

                            Bgr bgr = new Bgr((bgr_top.Blue + bgr_bottom.Blue) / 2, (bgr_top.Green + bgr_bottom.Green) / 2, (bgr_top.Red + bgr_bottom.Red) / 2);

                            zoom[i, j] = bgr;
                        }
                    }
                }
            }
            

            new_img_box.Image = firstimg;
            this.zoom_img_block.Image = zoom;





        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
