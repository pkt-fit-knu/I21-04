using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO; //Подключаем пространство имен для работы с файлами

namespace MyComander
{
    public partial class textViewer : Form
    {
        string path = "";

        public textViewer()
        {
            InitializeComponent();
        }

        public textViewer(string s)
        {//загрузка с открытием текстового файла path
            InitializeComponent();
            LoadFile(s);
        }

        private void LoadFile(string newPath)
        {
            text.Clear(); path = "";
            if (!File.Exists(newPath))
            {
                MessageBox.Show("File doesn't exist!");
                return;
            }

            string s = newPath.Substring(newPath.LastIndexOf('.') + 1);
            if (s != "txt")
            {
                newPath += " isn't txt file!";
                MessageBox.Show(newPath, "ERROR");
                return;
            }
            else
            {
                path = newPath;
                StreamReader streamReader = new StreamReader(newPath); //Открываем файл для чтения
                string str = ""; //Объявляем переменную, в которую будем записывать текст из файла

                str = streamReader.ReadLine();
                while (!streamReader.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
                {
                    str += "\n"+streamReader.ReadLine(); //В переменную str по строчно записываем содержимое файла
                }

                text.Text = str;
                streamReader.Close();
            }
        }

        private void SaveFile()
        {
            StreamWriter write_text= new StreamWriter(path,false,Encoding.GetEncoding(1251));  //Класс для перезаписи в файл
            
            write_text.WriteLine(text.Text); //Записываем в файл текст из текстового поля
            write_text.Close(); // Закрываем файл
        }

        private void textViewer_Load(object sender, EventArgs e)
        {
            text.Left = 0;
            text.Top = menu.Size.Height;
            text.Size = new Size(this.Size.Width,this.Size.Width-menu.Size.Height);
        }

        
        private void textViewer_SizeChanged(object sender, EventArgs e)
        {
            text.Size = new Size(this.Size.Width, this.Size.Width - menu.Size.Height);
            //text.Size.Height = 12;

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(openFileDialog1.FileName);
                LoadFile(openFileDialog1.FileName);
            }
        }

        private void findOnecWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pathT= path+"~~.txt";
            StreamWriter write_text = new StreamWriter(pathT, false, Encoding.GetEncoding(1251));  //Класс для перезаписи в файл

            Dictionary<string,int> map = new Dictionary<string,int>();
            string str= text.Text;
            int i=0; int l= str.Length;

            while (i<l)
            {// в цикле вытаскием слова из текста, и в мап записываем количество вхождений
                while (i<l && (str[i]==' ' || str[i]=='\n')) i++;
                if (i<l)
                {
                string s = "";
                int i1 = 0;
                while (i+i1<l && (str[i+i1]!=' ' && str[i+i1]!='\n')) i1++;
                s= str.Substring(i,i1);
                //MessageBox.Show(s);
                if (!map.ContainsKey(s)) map.Add(s, 1);
                else map[s]= 2;
                i+= i1+1;
                }
            }
            
            foreach (KeyValuePair<string,int> s in map)
            {
             if (s.Value==1) write_text.WriteLine(s.Key);
            }
            write_text.Close(); // Закрываем файл


            var tV2 = new textViewer(pathT);
            tV2.ShowDialog();
            tV2.Dispose();
            File.Delete(pathT);
        }

        private void deleteSpacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str= text.Text;
            string str2 = "";
            int i=0; int l= str.Length;
            str+= '#';
            while (i < l)
            {// в цикле вытаскием слова из текста, и в мап записываем количество вхождений
                if (str[i] != str[i + 1] || (str[i] != ' ' && str[i] != '\n' && str[i] != '\t')) { str2 += str[i]; }
                i++;
            }


            string pathT = path + "~~.txt";
            StreamWriter write_text = new StreamWriter(pathT, false, Encoding.GetEncoding(1251));  //Класс для перезаписи в файл
            write_text.WriteLine(str2);
            write_text.Close();
            var tV2 = new textViewer(pathT);
            tV2.ShowDialog();
            tV2.Dispose();
            File.Delete(pathT);

        }

        private void text_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
