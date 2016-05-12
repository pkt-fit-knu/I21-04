using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyComander
{
    public partial class newFolder : Form
    {
        public string folderName;
        public newFolder()
        {
            InitializeComponent();
            folderName = "";
        }

        public newFolder(bool flag)
        {
            InitializeComponent();
            if (flag)
            {// новый файл
                label1.Text = "Введіть назву нового файлу";
                this.Text = "newFile";
            }
            folderName = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null) { folderName = textBox1.Text; }
            Close();
//            Dispose();   
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, null);
            }

        }
    }
}
