using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;


// 1
namespace Console_iris1
{
    class Program
    {
        static string PathToDataFile = "./Resources/IrisData.txt";

        static IrisType[] I = { new IrisType("Iris-setosa"), 
                                new IrisType("Iris-versicolor"), 
                                new IrisType("Iris-virginica") };

        static List<Iris>[] dataList = { new List<Iris>(), 
                                         new List<Iris>(), 
                                         new List<Iris>(), 
                                         new List<Iris>(), 
                                         new List<Iris>() };

        class IrisType
        {
            public string Name;
            public List<double>[] minmax = { new List<double>(), new List<double>(), new List<double>(), new List<double>() };

            public IrisType(string Name)
            {

                this.Name = Name;
            }

            public void CleanResult()
            {
                for (int j = 0; j < minmax.Length; j++)
                    for (int i = 1; i < this.minmax[j].Count; i++)
                    {
                        if (this.minmax[j][i] == this.minmax[j][i - 1])
                        {
                            this.minmax[j].RemoveAt(i);
                            this.minmax[j].RemoveAt(i - 1);
                            i--;
                        }
                        else { }

                    }

            }
            public void printMinMax(int index)
            {
                Console.WriteLine(this.Name);
                for (int i = 1; i < this.minmax[index].Count; i++)
                {
                    Console.Write("[" + this.minmax[index][i - 1] + ";" + this.minmax[index][i] + ")");
                    if (i + 1 != this.minmax[index].Count)
                    {
                        Console.Write("V");
                    }
                    i++;
                }
                Console.WriteLine("");
                Console.WriteLine("            ");
            }


        }

        class Iris
        {

            public double[] props = new double[5];

            public string Name;
            
            public Iris(string Name, double p1, double p2, double p3, double p4)
            {
                this.Name = Name;
                this.props[1] = p1;
                this.props[2] = p2;
                this.props[3] = p3;
                this.props[4] = p4;
            }

            public void printIris()
            {
                Console.WriteLine(this.props[1] + "--" + this.props[2] + "--" + this.props[3] + "--" + this.props[4] + "--" + this.Name);
            }
        }
        private static void AddLine(string Line)
        {
            Line = Line.Replace(',', '|');
            Line = Line.Replace('.', ',');
            string[] input = Line.Split('|');
            if (input.Length == 5)
                dataList[0].Add(
                    new Iris(input[4], 
                    double.Parse(input[0]), 
                    double.Parse(input[1]), 
                    double.Parse(input[2]), 
                    double.Parse(input[3])));
            else
            {
                Console.WriteLine("Ошибки");
            }

        } 
       
        
        public static void ReadData()
        {
            int fileLength = System.IO.File.ReadAllLines(PathToDataFile).Length;
            for (int i = 0; i < fileLength; i++)
            {
                AddLine(File.ReadLines(PathToDataFile).Skip(i).First());
            }
        }

        public static void SortIris(int S)
        {
            int n = 0;
            double min = dataList[0][n].props[S];
            for (int i = 0; i < dataList[0].Count; i++)
            {
                if (dataList[0][i].props[S] < min)
                {
                    min = dataList[0][i].props[S];
                    n = i;
                }
            }
            dataList[S].Add(dataList[0][n]);
            dataList[0].RemoveAt(n);
            if (dataList[0].Count > 0)
            {
                // recursion
                SortIris(S);
            }
        }

        public static void Sortirovka()
        {
            dataList[0].Clear();
            ReadData();
            SortIris(1);
            dataList[0].Clear();
            ReadData();
            SortIris(2);
            dataList[0].Clear();
            ReadData();
            SortIris(3);
            dataList[0].Clear();
            ReadData();
            SortIris(4);
            dataList[0].Clear();
            ReadData();
        }

        private static int dr(int M, int ii, int k, IrisType[] I)
        {
            if ((ii + 1 < dataList[M].Count) && (dataList[M][ii + 1].Name == I[k].Name))
            {
                ii++;
                ii = dr(M, ii, k, I);
            }
            return ii;
        }

        private static void Findminmax(int M, int k, int ii, IrisType[] I)
        {
            int[] l = { 0, 0, 0 };
            double min = dataList[M][ii].props[M];
        
          

            for (int i = ii; i < dataList[M].Count; i++)
            {
                for (int j = 0; j < I.Length; j++)
                {
                    if (dataList[M][i].Name == I[j].Name)
                    {
                        l[j]++;
                    }
                    if (l[j] == 3) { k = j; ii = i; break; }

                }
                if (l[k] == 3)
                {
                    break;
                }

            }

            ii = dr(M, ii, k, I);
            if (ii != min)
            {
                I[k].minmax[M - 1].Add(min);
                I[k].minmax[M - 1].Add(dataList[M][ii].props[M]);
            }
            if (ii + 1 < dataList[M].Count)
            {
                Findminmax(M, k, ii, I);
            }
        }

        private static int FindError(int M)
        {
            ReadData();
            bool er;
            int error = 0;
            for (int i = 0; i < dataList[0].Count; i++)
            {
                for (int j = 0; j < I.Length; j++)
                {
                    if (dataList[0][i].Name == I[j].Name)
                    {
                        er = false;
                        for (int g = 1; g < I[j].minmax[M].Count; g++)
                        {
                            if ((dataList[0][i].props[M + 1] >= I[j].minmax[M][g - 1]) && (dataList[0][i].props[M + 1] < I[j].minmax[M][g])) { er = true; }
                            g++;
                        }
                        if (er == false) { error++; }
                    }
                }
            }
            return error;
        }

        static void PrintResult(int i)
        {
            I[0].printMinMax(i);
            I[1].printMinMax(i);
            I[2].printMinMax(i);
            Console.WriteLine(    FindError(i) +
                "в " + i +" столбике");
            
        }

        static void Main(string[] args)
        {

            ReadData();
            Sortirovka();
            Findminmax(1, 0, 0, I);
            Findminmax(2, 0, 0, I);
            Findminmax(3, 0, 0, I);
            Findminmax(4, 0, 0, I);

            I[0].CleanResult();
            I[1].CleanResult();
            I[2].CleanResult();


            PrintResult(0);
            PrintResult(1);
            PrintResult(2);
            PrintResult(3);
            
            Console.ReadKey();
           

        }
    }
}
