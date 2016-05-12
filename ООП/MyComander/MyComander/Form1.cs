using System;
using System.IO;
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
    public partial class Form1 : Form
    {
        public
            string path1 = @"C:\";  // "C:\\";
            string path2 = @"C:\";  // "C:\\";
            List<string> copyFolders = new List<string>();
            List<string> copyFiles = new List<string>();
            bool copy; //true - copy, false - cut

        
        
        public Form1()
            {
                InitializeComponent();

                Refresh(listView1, path1, address1);
                Refresh(listView2, path2, address2);
                

                string[] str = Environment.GetLogicalDrives();
                int n = 0;
                foreach (string s in str)
                {
                    try
                    {
                        TreeNode tn = new TreeNode();
                        tn.Name = s;
                        tn.Text = "Локальний диск " + s;
                        treeView1.Nodes.Add(tn.Name, tn.Text, 0);
                        string t = "";
                        string[] str2 = Directory.GetDirectories(s);
                        foreach (string s2 in str2)
                        {
                            t = s2.Substring(s2.LastIndexOf('\\') + 1);
                            ((TreeNode)treeView1.Nodes[n]).Nodes.Add(s2, t, 1);
                        }
                    }
                    catch { }
                    n++;
                }

                n = 0;
                foreach (string s in str)
                {
                    try
                    {
                        TreeNode tn = new TreeNode();
                        tn.Name = s;
                        tn.Text = "Локальний диск " + s;
                        treeView2.Nodes.Add(tn.Name, tn.Text, 0);
                        string t = "";
                        string[] str2 = Directory.GetDirectories(s);
                        foreach (string s2 in str2)
                        {
                            t = s2.Substring(s2.LastIndexOf('\\') + 1);
                            ((TreeNode)treeView2.Nodes[n]).Nodes.Add(s2, t, 1);
                        }
                    }
                    catch { }
                    n++;
                }

        }

        private void AbouteProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is my first lab in C#. © Wasyl Franchuk.");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Интерфейс черзвычайно дружелюбный и не нуждается в объяснении. Но если у вас все таки возникли проблемы, обратитесь по адресу WslF@i.ua", "Help");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems[0].ImageIndex == 0)     //переход в следующую папку
                {
                    try { GoToFolder(listView1, ref path1, listView1.SelectedItems[0].Text, address1); }
                    catch { MessageBox.Show("access denied","Error"); }
                }
                else //открытие файла
                {
                    string s = path1 +'\\'+ listView1.SelectedItems[0].Text;
                    try { OpenFile(listView1, s); }
                    catch { MessageBox.Show("access denied", "Error"); }
                }
            }
        }

        private void ListView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                if (listView2.SelectedItems[0].ImageIndex == 0)     //переход в следующую папку
                {
                    try { GoToFolder(listView2, ref path2, listView2.SelectedItems[0].Text, address2); }
                    catch { MessageBox.Show("access denied", "Error"); }

                }
                else //открытие файла
                {
                    string s = path2 + '\\' + listView2.SelectedItems[0].Text;
                    try { OpenFile(listView2, s); }
                    catch { MessageBox.Show("access denied", "Error"); }
                }
            }
        }


        private void BackButton1Click(object sender, EventArgs e)
        {
            Back(listView1, ref path1, address1);
        }

        private void Address1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string s;
                s = address1.Text;
                if (!ChangeDir(listView1, ref path1, s, address1))
                {
                    address1.Text = path1;
                    MessageBox.Show("Incorrect path");
                }
            }
        }

        private void NewFolderButton1Click(object sender, EventArgs e)
        { //создание новой папки
            newFolder f2 = new newFolder();
            f2.Owner = this;
            f2.ShowDialog();
            if (f2.folderName != "") CreateDir(path1, f2.folderName);
            Refresh(listView1, path1, address1);
            f2.Dispose();
        }

        private void NewFileButton1Click(object sender, EventArgs e)
        {//создать новый файл
            newFolder f2 = new newFolder(true);
            f2.Owner = this;
            f2.ShowDialog();
            if (f2.folderName != "") CreateFile(path1, f2.folderName);
            Refresh(listView1, path1, address1);
            f2.Dispose();
        }

        private void RefreshButton1Click(object sender, EventArgs e)
        {
            Refresh(listView1, path1, address1);
        }



        private void BackButton2Click(object sender, EventArgs e)
        {
            Back(listView2, ref path2, address2);
        }

        private void Address2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void NewFolderButton2Click(object sender, EventArgs e)
        { //создание новой папки
            newFolder f2 = new newFolder();
            f2.Owner = this;
            f2.ShowDialog();
            if (f2.folderName != "") CreateDir(path2, f2.folderName);
            MessageBox.Show(path2);
            Refresh(listView2, path2, address2);
            f2.Dispose();
        }

        private void NewFileButton2Click(object sender, EventArgs e)
        {//создать новый файл
            newFolder f2 = new newFolder(true);
            f2.Owner = this;
            f2.ShowDialog();
            if (f2.folderName != "") CreateFile(path2, f2.folderName);
            Refresh(listView2, path2, address2);
            f2.Dispose();
        }

        private void RefreshButton2Click(object sender, EventArgs e)
        {
            Refresh(listView2, path2, address2);
        }


        private void Menu1_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 && listView2.SelectedItems.Count == 0)
            {
             //Menu1.Items["
            }
        }

        private void OpenItemClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0) ListView1_MouseDoubleClick(this, null);
            if (listView2.SelectedItems.Count > 0) ListView2_MouseDoubleClick(this, null);
        }

        private void DeleteItemClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0) Delete(listView1, path1);
            if (listView2.SelectedItems.Count > 0) Delete(listView2, path2);

            Refresh(listView1, path1, address1);
            Refresh(listView2, path2, address2);
        }

        private void CopyItemClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0) AddToBuffer(listView1, path1, true);
            if (listView2.SelectedItems.Count > 0) AddToBuffer(listView2, path2, true);
        }

        private void CutItemClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                AddToBuffer(listView1, path1, false);
                foreach (int n in listView1.SelectedIndices)
                {
                    listView1.Items[n].ForeColor= Color.Gray;
                }


            }
            if (listView2.SelectedItems.Count > 0) AddToBuffer(listView2, path2, false);

        }

        private void PasteItemClick(object sender, EventArgs e)
        {
            if (MousePosition.X < PointToScreen(listView2.Location).X)
            {
                try { Paste(path1); }
                catch { MessageBox.Show("Error", "ERROR"); }
                Refresh(listView1, path1, address1);
            }
            else
            {
                try { Paste(path2); }
                catch { MessageBox.Show("Error", "ERROR"); }
                Refresh(listView2, path2, address2);
            }
        }

        private void copyTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] files;
            if (listView1.SelectedItems.Count > 0) files = Directory.GetFiles(path1, "*.txt");
            else files = Directory.GetFiles(path2, "*.txt");
            copyFiles.Clear();
            copyFolders.Clear();
            copy = true;
            foreach (string s in files)
                copyFiles.Add(s);
        }

        private void copyHtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyFiles.Clear();
            copyFolders.Clear();
            string s;
            if (listView1.SelectedItems.Count > 0)
            {
                s = path1 + '\\' + listView1.SelectedItems[0].Text;
            }
            else
            {
                s = path2 + '\\' + listView2.SelectedItems[0].Text;
            }

            string s2;
            s2 = s.Substring(s.LastIndexOf('.') + 1);
            if (s2 != "htm") { MessageBox.Show("isn't html!", "ERROR"); return; }

            copyFiles.Add(s);
            s = s.Substring(0, s.LastIndexOf('.')) + "_files";
            copyFolders.Add(s);
            copy = true;
        }




        private void Refresh(ListView sender, string path, ToolStripTextBox address)
            {
                string[] files = Directory.GetFiles(path);
                string[] directories = Directory.GetDirectories(path);

                address.Text = path;

                sender.SmallImageList = imageList1;
                sender.Items.Clear();
                {
                    string dirName = "";
                    for (int i = 0; i < directories.Length; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        dirName = directories[i].Substring(directories[i].LastIndexOf('\\') + 1);
                        lvi.Text = dirName;
                        lvi.ImageIndex = 0;
                        sender.Items.Add(lvi);                       
                    }

                    string fileName = "";
                    for (int i = 0; i < files.Length; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        fileName = files[i].Substring(files[i].LastIndexOf('\\') + 1);
                        lvi.Text = fileName;
                        lvi.ImageIndex = 1;
                        sender.Items.Add(lvi);
                    }

                    sender.View = View.List;
                }

            }
        
        private bool ChangeDir(ListView sender, ref string path, string newPath, ToolStripTextBox address)
        {
            if (newPath.LastIndexOf('\\') == -1) return false;
            if (Directory.Exists(newPath))
            {
             path= newPath;
             Refresh(sender,path,address);
             return true;
            }
            return false;
        }

        private void Back(ListView sender, ref string path, ToolStripTextBox address)
        {
            while (path.LastIndexOf('\\') == path.Length - 1) path = path.Substring(0, path.LastIndexOf('\\'));
            if (path.LastIndexOf('\\') == -1) { path += '\\'; System.Console.Beep(3000, 300); return; }
            else
            {
                path = path.Substring(0, path.LastIndexOf('\\'))+'\\';
                Refresh(sender, path, address);
            }
        }

        private void GoToFolder(ListView sender, ref string path, string fName, ToolStripTextBox address)
        {
            if (path.LastIndexOf('\\') != path.Length - 1) path += '\\';
            path += fName;
            Refresh(sender, path, address);
        }

        private void OpenFile(ListView sender, string path)
        {// 
            string s = path.Substring(path.LastIndexOf(".") + 1);
            if (s != "txt") { MessageBox.Show("Can't open this file"); }
            else
            {
             textViewer tV1= new textViewer(path);
             tV1.Show();
            }
        }

        private void CreateDir(string path, string fName)
        {
            if (!Directory.Exists(path + '\\' + fName))
                Directory.CreateDirectory(path + '\\' + fName);
            else
                MessageBox.Show("Folder exists!", "Error");
        }

        private void CreateFile(string path, string fileName)
        {
            if (!File.Exists(path + '\\' + fileName))
                File.Create(path + '\\' + fileName);
            else
                MessageBox.Show("File exists!", "Error");
        }

        private void Delete(ListView sender, string path)
        {
            if (sender.SelectedItems.Count > 0)
            {
                path += '\\';
                foreach (int n in sender.SelectedIndices)
                {
                    if (sender.Items[n].ImageIndex == 0) // папка
                        Directory.Delete(path + sender.Items[n].Text, true); //удалит вместе с содержимым
                    else // файл
                        File.Delete(path + listView1.Items[n].Text);
                }
            }

        }

        private void AddToBuffer(ListView sender, string path, bool flag)
        {
            if (sender.SelectedItems.Count > 0)
            {
                copyFolders.Clear();
                copyFiles.Clear();
                copy = flag;
                path += '\\';
                foreach (int n in sender.SelectedIndices)
                {
                    if (sender.Items[n].ImageIndex == 0) // папка
                        copyFolders.Add(path + sender.Items[n].Text);
                    else // файл
                        copyFiles.Add(path + sender.Items[n].Text);
                }
            }
        }

        private void CopyFile(string from, string to, bool overwrite)
        {
            {
                int i;
                for (i = from.Length; from[i - 1] == '\\'; i--) ;
                from = from.Substring(0, i);
            }
            string fileName = from.Substring(from.LastIndexOf('\\'));
            File.Copy(from, to + '\\' + fileName, overwrite);
        }

        private void CopyFolder(string from, string to)
        {// copyFolder("D:\1\2","C:\") result "C:\2"
            {
                int i;
                for (i= from.Length; from[i-1]=='\\'; i--);
                from= from.Substring(0,i);
            }

            string fName= from.Substring(from.LastIndexOf('\\')+1);
            to+= '\\'+fName;
            if (!Directory.Exists(to)) Directory.CreateDirectory(to);

            string[] files = Directory.GetFiles(from);
            foreach (string s in files)
                CopyFile(s, to, true);

            string[] folders = Directory.GetDirectories(from);
            foreach (string s in folders)
                CopyFolder(s, to);
         }

        private void Paste(string path)
        {
            {
                string t = "";
                t += path[0];
                for (int i = 1; i < path.Length; i++)
                    if (path[i] != '\\' || path[i - 1] != '\\') t += path[i];
                path = t;
            }

            foreach (string s in copyFolders)
            {// проверка на копирование в собственный подкаталог
                string t = "";
                t += s[0];
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] != '\\' || s[i - 1] != '\\') t += s[i];
                }
                if (path.Contains(t)) { MessageBox.Show("Don't joking!"+path+t, "Error"); return; }
                
            }

            foreach (string s in copyFiles) // копирование файлов с перезаписью
                CopyFile(s, path, true);

            foreach (string s in copyFolders)
                CopyFolder(s, path);

            if (!copy)
            {//если перемещаем, то нужно удалить в исходном месте
                foreach (string s in copyFiles)
                    File.Delete(s);

                foreach (string s in copyFolders)
                    Directory.Delete(s, true); //удаляем с подкаталогами
            }

            copyFiles.Clear(); copyFolders.Clear(); copy = false;
        }




    }

}
