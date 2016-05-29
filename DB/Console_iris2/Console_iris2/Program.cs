using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace IrisTry
{
    class Program
    {
        static string PathToDataFile = "./Resources/IrisData.txt";

        static IrisType[] Types = { new IrisType("Iris-setosa"), 
                                new IrisType("Iris-versicolor"), 
                                new IrisType("Iris-virginica") };

       
        static List<Iris> List = new List<Iris>();

        class IrisType
        {
            public string Name;
            public List<double>[] minmax = { new List<double>(), new List<double>(), new List<double>(), new List<double>() };

            public IrisType(string Name)
            {

                this.Name = Name;
            }
            public void printMinMax(int N)
            {
                Console.WriteLine(this.Name);
                for (int i = 0; i < this.minmax[N].Count; i++)
                {
                    Console.WriteLine(this.minmax[N][i]);
                }
                Console.WriteLine("++++++++++++");
            }


        }

        class Iris
        {
            public string Name;
            public double[] D = new double[5];
            public Iris(string Name, double D1, double D2, double D3, double D4)
            {
                this.Name = Name;
                this.D[1] = D1;
                this.D[2] = D2;
                this.D[3] = D3;
                this.D[4] = D4;
            }
            public void print()
            {
                Console.WriteLine(this.D[1] + "--" + this.D[2] + "--" + this.D[3] + "--" + this.D[4] + "--" + this.Name);
            }

        }
        private static void AddLine(string Line)
        {
            Line = Line.Replace(',', '|');
            Line = Line.Replace('.', ',');
            string[] input = Line.Split('|');
            if (input.Length == 5)
                List.Add(new Iris(input[4], double.Parse(input[0]), double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3])));
            else
            {
                // Console.WriteLine("Помилка");
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



        private static void Findminmax(int N, IrisType[] T)
        {

            for (int j = 0; j < T.Length; j++)
            {
                Console.WriteLine(T[j].Name);
                string read = Console.ReadLine();
                string[] input = read.Split(' ');
                for (int i = 0; i < input.Length; i++)
                {
                    T[j].minmax[N - 1].Add(double.Parse(input[i]));
                }
            }
        }

        private static int FindError(int N)
        {
            ReadData();
            bool er;
            int error = 0;
            for (int i = 0; i < List.Count; i++)
            {
                for (int j = 0; j < Types.Length; j++)
                {
                    if (List[i].Name == Types[j].Name)
                    {
                        er = false;
                        for (int g = 1; g < Types[j].minmax[N].Count; g++)
                        {
                            if ((List[i].D[N + 1] >= Types[j].minmax[N][g - 1]) && (List[i].D[N + 1] < Types[j].minmax[N][g])) { er = true; }
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
            Types[0].printMinMax(i);
            Types[1].printMinMax(i);
            Types[2].printMinMax(i);
            Console.WriteLine(FindError(i) + "в " + i + " столбике");

        }

        static void Main(string[] args)
        {

            ReadData();
            Findminmax(1, Types);
            Findminmax(2, Types);
            Findminmax(3, Types);
            Findminmax(4, Types);

            PrintResult(0);
            PrintResult(1);
            PrintResult(2);
            PrintResult(3);
         
            Console.ReadKey();
         

        }
    }
}
