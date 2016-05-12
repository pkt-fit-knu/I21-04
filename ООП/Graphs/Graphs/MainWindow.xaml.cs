using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Petzold.Media2D;

namespace Graphs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Ellipse active, active2;
        bool dragging;
        Point oldMouse;
        int wedge;
 
        List<List<int>> distance;
        List<List<int>> p;
  
        int inf = 10000000;
        int globalres = 0;
        List<int> minpath;
        List<int> diam;
        int number;
        Graph gg;

        enum Action {Moving, addVertex, addEdge, DeleteVertex, DeleteEdge};
        Action currentAction;

        public MainWindow()
        {

            gg = new Graph();           

            
            number = 0;            
            InitializeComponent();
          
        }
        
        [Serializable]
        class Graph {
            public Dictionary<Ellipse, int> nodes;
            public Dictionary<ArrowLine, Tuple<int, int>> ArrowLines;
            public Dictionary<Tuple<int, int>, ArrowLine> edges;
            public Dictionary<Tuple<ArrowLine, Ellipse>, int> direction;
            public List<List<int>> graph;
            public Dictionary<int, Ellipse> getelipse;           
            public Dictionary<ArrowLine, TextBlock> textes;  
            public Dictionary<ArrowLine, Tuple<ArrowLine, ArrowLine>> arrows;
            
            public Graph(){
                graph = new List<List<int>>();
                textes = new Dictionary<ArrowLine, TextBlock>();
                nodes = new Dictionary<Ellipse, int>();
                getelipse = new Dictionary<int, Ellipse>();
                ArrowLines = new Dictionary<ArrowLine, Tuple<int, int>>();
                edges = new Dictionary<Tuple<int, int>, ArrowLine>();
                direction = new Dictionary<Tuple<ArrowLine, Ellipse>, int>();
                arrows = new Dictionary<ArrowLine, Tuple<ArrowLine, ArrowLine>>();
            }
        }

        public int diameter() {
            distance = new List<List<int>>(number);
            p = new List<List<int>>(number);
            
            for (int i = 0; i < number; i++)
            {
                distance.Add(new List<int>());
                p.Add(new List<int>());                
                for (int j = 0; j < number; j++)
                {
                    distance[i].Add(0);
                    p[i].Add(-1);
                    if (i != j)
                    {
                        if (gg.graph[i][j] == 0)
                            distance[i][j] = inf;
                        else
                            distance[i][j] = gg.graph[i][j];
                    }                    
                }
            }

            // Алгоритм Флойда-Воршала (находит кратчайшие расстояния между всеми вершинами)
            int v=0, u=0;
            int res = 0;
            for (int k = 0; k < number; k++) {
                for (int i = 0; i < number; i++) {
                    for (int j = 0; j < number; j++) {                    
                            if (distance[i][j] > distance[i][k] + distance[k][j])
                            {
                                distance[i][j] = distance[i][k] + distance[k][j];
                                p[i][j] = k;                            
                            }
                        
                    }
                }
            }

            // Находим максимальное из всех минимальных расстояний (диаметр)
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    if (i != j && res < distance[i][j])
                    {
                        res = distance[i][j];
                        v = i; u = j;
                    }
                }
            }
            if (minpath != null && minpath.Count > 0)
            {
                uncolorPath(minpath);
                minpath.Clear();
            }
            if (diam != null && diam.Count > 0)
            {
                uncolorPath(diam);
                diam.Clear();
            }

            // Найти все вершины диаметра
            diam = buildPath(v, u);
            output.Content = "Диаметр: " + ((res == inf) ? "Бесконечность" : res.ToString()) + Environment.NewLine;

            if (res != inf)
            {
                colorPath(diam);

                foreach (int n in diam)
                {
                    output.Content += n.ToString() + Environment.NewLine;
                }
            }
            else {
                diam.Clear();
            }

            return res;
        }

        // Найти все вершины диаметра
        public List<int> buildPath(int u, int v) {
            List<int> ans = new List<int>();

            if (p[u][v] == -1)
            {
                ans.Add(u);                
                ans.Add(v);                
            }
            else
            {
                List<int> r = buildPath(u, p[u][v]);
                List<int> l = buildPath(p[u][v], v);                
                ans.AddRange(r);                
                ans.AddRange(l);                
            }
            for (int i = 0; i+1 < ans.Count;) {
                if (ans[i] == ans[i + 1])
                {
                    ans.RemoveAt(i);
                }
                else {
                    i++;
                }
            }

                return ans;
        }


        // Найти самый короткий Гамильтонов путь
        public void shortestPath() {
     
            globalres = inf;
            if (minpath != null && minpath.Count > 0) {
                uncolorPath(minpath);
                minpath.Clear();
            }
            if (diam != null && diam.Count > 0)
            {
                uncolorPath(diam);
                diam.Clear();
            }
            minpath = new List<int>();

            // Поиск в глубину
            dfs(0, -1, 0, 0, new List<int>());
            output.Content = "Самый короткий путь: " + 
                ((globalres == inf)?"Бесконечность" : globalres.ToString()) + Environment.NewLine;
            if (globalres != inf)
            {
                minpath.Add(0);
                foreach (int n in minpath)
                {
                    output.Content += n.ToString() + Environment.NewLine;
                }
                colorPath(minpath);
            }
            else {
                minpath.Clear();
            }

  
        }


        // Поиск в глубину
        void dfs(int v, int from, int res, int mask, List<int> ans) {

            if ((mask & (1 << v)) == 0)
            {
                mask |= (1 << v);
                ans.Add(v);
               

                for (int i = 0; i < number; i++)
                {
                    if (gg.graph[v][i] != 0 && i != from)
                    {
                        dfs(i, v, res + gg.graph[v][i], mask, ans);
                    }
                }
                ans.RemoveAt(ans.Count - 1);
                mask ^= (1 << v);
            }
            else 
            {
                if (mask == (1 << number) - 1 && v == 0)
                {
                    if (res < globalres)
                    {
                        globalres = res;
                        minpath.Clear();
                        foreach (int el in ans)
                        {
                            minpath.Add(el);
                        }
                    }
                }
            }
        }

        void colorPath(List<int> path) {
            for (int i = 1; i < path.Count; i++) {
                gg.getelipse[path[i]].Fill = Brushes.Red;
                gg.getelipse[path[i-1]].Fill = Brushes.Red;
                ArrowLine ln = gg.edges[Tuple.Create(path[i - 1], path[i])];
                ln.Stroke = Brushes.Red;
            }
        }

        void uncolorPath(List<int> path)
        {
            for (int i = 1; i < path.Count; i++)
            {
                gg.getelipse[path[i]].Fill = Brushes.Blue;
                gg.getelipse[path[i - 1]].Fill = Brushes.Blue;
                ArrowLine ln = gg.edges[Tuple.Create(path[i - 1], path[i])];
                ln.Stroke = Brushes.Black;
            }
        }


        // Клик мыши по елипсу
        public void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (currentAction == Action.addEdge)
            {
                if (minpath != null && minpath.Count > 0)
                {
                    uncolorPath(minpath);
                    minpath.Clear();
                }
                if (diam != null && diam.Count > 0)
                {
                    uncolorPath(diam);
                    diam.Clear();
                }

                if (wedge < 0)
                {
                    MessageBox.Show("Введите корректный вес ребра", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (active == null)
                    {
                        active = (Ellipse)sender;
                        active.Fill = Brushes.Red;
                        ActiveNum.Content = gg.nodes[active].ToString();
                    }
                    else
                    {
                        if ((Ellipse)sender != active)
                        {
                            active2 = (Ellipse)sender;
                            active2.Fill = Brushes.Red;
                            ActiveNum.Content += " / " + gg.nodes[active2].ToString();
                          
                            int w = wedge;
                            if (gg.graph[gg.nodes[active]][gg.nodes[active2]] > 0)
                            {
                                gg.graph[gg.nodes[active]][gg.nodes[active2]] = w;
                                gg.textes[gg.edges[Tuple.Create(gg.nodes[active], gg.nodes[active2])]].Text = w.ToString();                                
                            }
                            else
                            {
                                gg.graph[gg.nodes[active]][gg.nodes[active2]] = w;

                                ArrowLine ln = new ArrowLine();

                                ln.StrokeThickness = 2;
                                ln.Stroke = Brushes.Black;
                                ln.Fill = Brushes.Blue;
                                ln.X1 = Canvas.GetLeft(active) + 15;
                                ln.Y1 = Canvas.GetTop(active) + 15;
                                ln.X2 = Canvas.GetLeft(active2) + 15;
                                ln.Y2 = Canvas.GetTop(active2) + 15;

                                canva.Children.Add(ln);
                                gg.ArrowLines.Add(ln, Tuple.Create(gg.nodes[active], gg.nodes[active2]));
                                gg.edges.Add(Tuple.Create(gg.nodes[active], gg.nodes[active2]), ln);
                                gg.direction.Add(Tuple.Create(ln, active), 1);
                                gg.direction.Add(Tuple.Create(ln, active2), 2);
                                Text(ln, (ln.X1 + ln.X2) / 2, (ln.Y1 + ln.Y2) / 2, w.ToString(), Colors.Black);
                                                                
                            }
                            active2.Fill = Brushes.Blue;
                            active.Fill = Brushes.Blue;
                            active = null;
                            active2 = null;
                            currentAction = Action.Moving;
                            Operation.Content = "Перемещение";
                            ActiveNum.Content = "-";
                        }                    
                    }
                }
            }
            else if(currentAction == Action.Moving)
            {
                active = (Ellipse)sender;
                ActiveNum.Content = gg.nodes[active].ToString();
                active.Fill = Brushes.Red;
                dragging = true;
                oldMouse = e.GetPosition(canva);
            }
            else if (currentAction == Action.DeleteVertex) {
                if (minpath != null && minpath.Count > 0)
                {
                    uncolorPath(minpath);
                    minpath.Clear();
                }
                if (diam != null && diam.Count > 0)
                {
                    uncolorPath(diam);
                    diam.Clear();
                }
                int v = gg.nodes[(Ellipse)sender];
                
                for (int i = 0; i < number; i++) {
                    if (gg.graph[v][i] != 0)
                    {
                        ArrowLine ln = gg.edges[Tuple.Create(v, i)];
                        List<Tuple<ArrowLine, Ellipse>> keys_dr = new List<Tuple<ArrowLine, Ellipse>>(gg.direction.Keys);
                        for (int p = 0; p < keys_dr.Count; p++)
                        {
                            Tuple<ArrowLine, Ellipse> key = keys_dr[p];
                            if (key.Item1 == ln)
                                gg.direction.Remove(key);

                        }
                        canva.Children.Remove(gg.textes[ln]);
                        gg.textes.Remove(ln);
                        gg.ArrowLines.Remove(ln);
                        canva.Children.Remove(ln);
                        gg.edges.Remove(Tuple.Create(v, i));
                    }
                    if (gg.graph[i][v] != 0)
                    {
                        ArrowLine ln = gg.edges[Tuple.Create(i, v)];
                        List<Tuple<ArrowLine, Ellipse>> keys_dr = new List<Tuple<ArrowLine, Ellipse>>(gg.direction.Keys);
                        for (int p = 0; p < keys_dr.Count; p++)
                        {
                            Tuple<ArrowLine, Ellipse> key = keys_dr[p];
                            if (key.Item1 == ln)
                                gg.direction.Remove(key);

                        }
                        canva.Children.Remove(gg.textes[ln]);
                        gg.textes.Remove(ln);
                        gg.ArrowLines.Remove(ln);                        
                        canva.Children.Remove(ln);
                        gg.edges.Remove(Tuple.Create(i, v));
                    }
                }




                gg.graph.RemoveAt(v);
                foreach (List<int> l in gg.graph)
                {
                    l.RemoveAt(v);
                }

                List<Ellipse> keys_el = new List<Ellipse>(gg.nodes.Keys);
                for (int i = 0; i < keys_el.Count; i++)
                {
                    Ellipse key = keys_el[i];
                    if (gg.nodes[key] > v)
                        gg.nodes[key]--;
                }

                gg.getelipse.Remove(v);
                gg.nodes.Remove((Ellipse)sender);


                List<int> keys_ge = new List<int>(gg.getelipse.Keys);
                for (int i = 0; i < keys_ge.Count; i++)
                {
                    int key = keys_ge[i];
                    if (key > v)
                    {
                        Ellipse temp = gg.getelipse[key];
                        gg.getelipse.Remove(key);
                        gg.getelipse.Add(key - 1, temp);
                    }
                }

                List<ArrowLine> keys_ln = new List<ArrowLine>(gg.ArrowLines.Keys);
                for (int j = 0; j < keys_ln.Count; j++)
                {
                    ArrowLine key_ln = keys_ln[j];
                    if (gg.ArrowLines[key_ln].Item1 > v)
                    {
                        gg.ArrowLines[key_ln] = Tuple.Create(gg.ArrowLines[key_ln].Item1 - 1, gg.ArrowLines[key_ln].Item2);
                    }
                    if (gg.ArrowLines[key_ln].Item2 > v)
                    {
                        gg.ArrowLines[key_ln] = Tuple.Create(gg.ArrowLines[key_ln].Item1, gg.ArrowLines[key_ln].Item2 - 1);
                    }
                }

                List<Tuple<int, int>> keys_ed = new List<Tuple<int, int>>(gg.edges.Keys);
                for (int k = 0; k < keys_ed.Count; k++)
                {
                    Tuple<int, int> key_ed = keys_ed[k];
                    if (key_ed.Item1 > v && key_ed.Item2 > v)
                    {
                        Tuple<int, int> temp = Tuple.Create(key_ed.Item1 - 1, key_ed.Item2 - 1);
                        ArrowLine ln = gg.edges[key_ed];
                        gg.edges.Remove(key_ed);
                        gg.edges.Add(temp, ln);
                    }
                    else
                    {
                        if (key_ed.Item1 > v)
                        {
                            Tuple<int, int> temp = Tuple.Create(key_ed.Item1 - 1, key_ed.Item2);
                            ArrowLine ln = gg.edges[key_ed];
                            gg.edges.Remove(key_ed);
                            gg.edges.Add(temp, ln);
                        }
                        if (key_ed.Item2 > v)
                        {
                            Tuple<int, int> temp = Tuple.Create(key_ed.Item1, key_ed.Item2 - 1);
                            ArrowLine ln = gg.edges[key_ed];
                            gg.edges.Remove(key_ed);
                            gg.edges.Add(temp, ln);
                        }
                    }
                }

                
                canva.Children.Remove((Ellipse)sender);
                number--;

                currentAction = Action.Moving;
                Operation.Content = "Перемещение";
                ActiveNum.Content = "-";
            }            
        }

        // Клик по холсту, добавление вершины
        public void canva_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (minpath != null && minpath.Count > 0)
            {
                uncolorPath(minpath);
                minpath.Clear();
            }
            if (diam != null && diam.Count > 0)
            {
                uncolorPath(diam);
                diam.Clear();
            }
            
            oldMouse = e.GetPosition(canva);
            if (currentAction == Action.addVertex)
            {    

             
                Ellipse r = new Ellipse();


                gg.nodes.Add(r, number);
                gg.getelipse.Add(number, r);

                number++;
                foreach (List<int> l in gg.graph)
                {
                    l.Add(0);
                }
                gg.graph.Add(new List<int>(number));
                for (int i = 0; i < number; i++)
                {
                    gg.graph[number - 1].Add(0);
                }

                r.MouseDown += new MouseButtonEventHandler(ellipse_MouseDown);
                r.Width = 30;
                r.Height = 30;
                r.StrokeThickness = 2;
                r.Stroke = Brushes.Black;
                r.Fill = Brushes.Blue;

                canva.Children.Add(r);
                Canvas.SetLeft(r, oldMouse.X);
                Canvas.SetTop(r, oldMouse.Y);

                currentAction = Action.Moving;
                Operation.Content = "Перемещение";
                ActiveNum.Content = "-";
            }          
                 
        }

        private void canva_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentAction == Action.Moving && dragging && e.LeftButton == MouseButtonState.Pressed) {
                int v = gg.nodes[active];
                for (int i = 0; i < number; i++) {
                    if (gg.graph[v][i] != 0)
                    {
                        ArrowLine ln = gg.edges[Tuple.Create(v, i)];
                        if (gg.direction[Tuple.Create(ln, active)] == 1)
                        {
                            ln.X1 += +e.GetPosition(canva).X - oldMouse.X;
                            ln.Y1 += +e.GetPosition(canva).Y - oldMouse.Y;
                        }
                        else 
                        {
                            ln.X2 += +e.GetPosition(canva).X - oldMouse.X;
                            ln.Y2 += +e.GetPosition(canva).Y - oldMouse.Y; 
                        }
                        TextBlock tb = gg.textes[ln];
                        Canvas.SetLeft(tb, (ln.X1 + ln.X2) / 2);
                        Canvas.SetTop(tb, (ln.Y1 + ln.Y2) / 2);
                    }
                    if (gg.graph[i][v] != 0)
                    {
                        ArrowLine ln = gg.edges[Tuple.Create(i, v)];
                        if (gg.direction[Tuple.Create(ln, active)] == 1)
                        {
                            ln.X1 += +e.GetPosition(canva).X - oldMouse.X;
                            ln.Y1 += +e.GetPosition(canva).Y - oldMouse.Y;
                        }
                        else
                        {
                            ln.X2 += +e.GetPosition(canva).X - oldMouse.X;
                            ln.Y2 += +e.GetPosition(canva).Y - oldMouse.Y;
                        }
                        TextBlock tb = gg.textes[ln];
                        Canvas.SetLeft(tb, (ln.X1 + ln.X2) / 2);
                        Canvas.SetTop(tb, (ln.Y1 + ln.Y2) / 2);
                    }
                }
                Canvas.SetLeft(active, Canvas.GetLeft(active) + e.GetPosition(canva).X - oldMouse.X);
                Canvas.SetTop(active, Canvas.GetTop(active) + e.GetPosition(canva).Y - oldMouse.Y);
            }
            oldMouse = e.GetPosition(canva);
        }

        private void canva_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (currentAction == Action.Moving && active != null) {
                active.Fill = Brushes.Blue;
                active = null;
            }
            dragging = false;
            ActiveNum.Content = "-";
        }

        private void Text(ArrowLine ln, double x, double y, string text, Color color)
        {

            TextBlock textBlock = new TextBlock();

            textBlock.Text = text;

            textBlock.Foreground = new SolidColorBrush(color);

            Canvas.SetLeft(textBlock, x);

            Canvas.SetTop(textBlock, y);

            gg.textes.Add(ln, textBlock);
            canva.Children.Add(textBlock);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            currentAction = Action.addVertex;
            Operation.Content = "Добавление вершины";
            ActiveNum.Content = "-";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            currentAction = Action.addEdge;
            Operation.Content = "Добавление ребра";
            ActiveNum.Content = "-";
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (minpath != null && minpath.Count > 0)
            {
                uncolorPath(minpath);
                minpath.Clear();
            }
            if (diam != null && diam.Count > 0)
            {
                uncolorPath(diam);
                diam.Clear();
            }
            currentAction = Action.Moving;
            Operation.Content = "Перемещение";
            ActiveNum.Content = "-";
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            currentAction = Action.DeleteVertex;
            Operation.Content = "Удаление вершины";
            ActiveNum.Content = "-";
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            diameter();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            shortestPath();
        }


        // Сохранить граф в файл
        private void button8_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            if (gg != null)
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //System.IO.Stream fStream = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None);
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(saveFileDialog1.FileName);
                    writer.WriteLine(number);
                    for (int i = 0; i < number; i++)
                    {
                        writer.WriteLine(i.ToString() + " " + Canvas.GetLeft(gg.getelipse[i]).ToString() + " " +
                            Canvas.GetTop(gg.getelipse[i]).ToString());
                    }

                    for (int i = 0; i < number; i++)
                    {
                        for (int j = 0; j < number; j++)
                        {
                            writer.Write(gg.graph[i][j].ToString() + ((j < number - 1) ? " " : ""));
                        }
                        writer.WriteLine();
                    }
                   
                    writer.Close();
                    //fStream.Close();                   
                }
            }
            else
            {
                MessageBox.Show("Создайте граф!");
            }
        }

        // Открыть граф из файла
        private void button7_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (Ellipse el in gg.getelipse.Values) {
                    canva.Children.Remove(el);
                }
                foreach (TextBlock tx in gg.textes.Values)
                {
                    canva.Children.Remove(tx);
                }
                foreach (ArrowLine ln in gg.ArrowLines.Keys)
                {
                    canva.Children.Remove(ln);
                }
                gg.direction.Clear();
                

                gg = new Graph();
                
               
                    string Content = System.IO.File.ReadAllText(openFileDialog1.FileName);
                    string[] integersString = Content.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    int[] integers = new int[integersString.Length];
                    int current = 0;
                    foreach(string s in integersString){
                        integers[current++] = int.Parse(s);
                    }
                    //System.IO.StreamReader reader = new System.IO.StreamReader(openFileDialog1.FileName);
                    current = 0;
                    
                    number = integers[current++];

                    for (int i = 0; i < number; i++)
                    {
                        Ellipse el = new Ellipse();

                        int index = integers[current++];
                        int x = integers[current++];
                        int y = integers[current++];
                        gg.nodes.Add(el, index);
                        gg.getelipse.Add(index, el);

                        el.MouseDown += new MouseButtonEventHandler(ellipse_MouseDown);
                        el.Width = 30;
                        el.Height = 30;
                        el.StrokeThickness = 1;
                        el.Stroke = Brushes.Black;
                        el.Fill = Brushes.Blue;

                        canva.Children.Add(el);
                        Canvas.SetLeft(el, x);
                        Canvas.SetTop(el, y);
                    }

                    for (int i = 0; i < number; i++) {
                        gg.graph.Add(new List<int>());
                        for (int j = 0; j < number; j++)
                        {
                            int w = integers[current++];
                            
                            gg.graph[i].Add(w);

                            if (w != 0)
                            {

                                ArrowLine ln = new ArrowLine();

                                ln.StrokeThickness = 2;
                                ln.Stroke = Brushes.Black;
                                ln.Fill = Brushes.Blue;
                                ln.X1 = Canvas.GetLeft(gg.getelipse[i]) + 15;
                                ln.Y1 = Canvas.GetTop(gg.getelipse[i]) + 15;
                                ln.X2 = Canvas.GetLeft(gg.getelipse[j]) + 15;
                                ln.Y2 = Canvas.GetTop(gg.getelipse[j]) + 15;

                                canva.Children.Add(ln);
                                gg.ArrowLines.Add(ln, Tuple.Create(i, j));
                                gg.edges.Add(Tuple.Create(i, j), ln);
                                gg.direction.Add(Tuple.Create(ln, gg.getelipse[i]), 1);
                                gg.direction.Add(Tuple.Create(ln, gg.getelipse[j]), 2);
                                Text(ln, (ln.X1 + ln.X2) / 2, (ln.Y1 + ln.Y2) / 2, w.ToString(), Colors.Black);
                            }

                        }
                    }              

            }
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            addedge ae = new addedge();
            ae.ShowDialog();
            if (ae.DialogResult == true) {
                wedge = ae.w;
                ae.Close();
            }
            currentAction = Action.addEdge;
            Operation.Content = "Добавление ребра";
            ActiveNum.Content = "-";
        }

        private void MenuItem_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }
    }
}
