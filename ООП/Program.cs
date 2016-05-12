using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Program
    {

        class candidate
        {
            List<int> Itemset;
            int Support;

            public candidate(List<int> Itemset, int Sup)
            {
                this.Itemset = Itemset;
                this.Support = Sup;
            }


            public void addItemset2(int i1, int i2)
            {

                this.Itemset.Add(i1);
                this.Itemset.Add(i2);

            }

            public void print()
            {
                for (int i = 0; i < this.Itemset.Count; i++)
                {
                    Console.Write(this.Itemset[i]);
                }
                Console.WriteLine("");
            } //+


            public void support(int[,] A) 
            {


                for (int i = 0; i < A.GetLength(0); i++)
                {
                    int f = 0;
                    for (int j = 0; j < this.Itemset.Count; j++)
                    {
                        if (A[i, this.Itemset[j]] == 1)
                        {
                            f++;
                        }
                    }

                    if (f == this.Itemset.Count)
                    {
                        this.Support++;
                    }
                }


            }

            public bool del(int k)   
            {
                bool D = false;
                if (this.Support < k)
                {
                    D = true;
                }
                for (int i = 0; i < this.Itemset.Count; i++)
                {
                    for (int j = 0; j < this.Itemset.Count; j++)
                    {
                        if ((this.Itemset[i] == this.Itemset[j]) && (i != j))
                        {
                            D = true;
                        }
                    }
                }
                return D;
            }
            public bool del2(candidate A)  
            {
                bool D = false;
                int r = 0; 
                for (int i = 0; i < this.Itemset.Count; i++)
                {
                    for (int j = 0; j < A.Itemset.Count; j++)
                    {
                        if (this.Itemset[i] == A.Itemset[j])
                        {
                            r++;
                        }
                    }
                }
                if (r == this.Itemset.Count) { D = true; }
                return D;
            }

            public int findr(candidate A)  
            {

                int r = 0; 
                for (int i = 0; i < this.Itemset.Count; i++)
                {
                    for (int j = 0; j < A.Itemset.Count; j++)
                    {
                        if (this.Itemset[i] == A.Itemset[j])
                        {
                            r++;
                        }
                    }
                }

                return r;
            }
            //новый кандидат
            public candidate newcandidat(candidate A, int[,] B)
            {
                candidate newc = new candidate(new List<int>(), 0);
                for (int i = 0; i < this.Itemset.Count; i++)
                {
                    newc.Itemset.Add(this.Itemset[i]);
                }
                for (int i = 0; i < A.Itemset.Count; i++)
                {
                    newc.Itemset.Add(A.Itemset[i]);
                }
                newc.cleanItemset();
                newc.support(B);
                return newc;
            }

            public void cleanItemset() 
            {
                for (int i = 0; i < this.Itemset.Count; i++)
                {
                    for (int j = 0; j < this.Itemset.Count; j++)
                    {
                        if ((this.Itemset[i] == this.Itemset[j]) && (i != j))
                        {
                            this.Itemset.RemoveAt(j);
                            j--;
                        }
                    }
                }
            }

        }


        static int[,] vvid(int n, int m) 
        {
            

            int[,] tabl = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    tabl[i, j] = 0;
                }
            }

            
            
            Console.WriteLine("Введiть вхiднi даннi:");
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                for (int j = 0; j < input.Length; j++)
                {
                    int f = int.Parse(input[j]);
                    tabl[i, f] = 1;

                }
            }

            return tabl;
        }

        static void apriori(int[,] A, int m, int k)
        {
            int u = 0;
            List<candidate> set1 = new List<candidate>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    set1.Add(new candidate(new List<int>(), 0));
                    set1[u].addItemset2(i, j);
                    set1[u].support(A);
                    u++;
                }
            }
            cleanset(set1, k);

            List<List<candidate>> sets = new List<List<candidate>>();
            sets.Add(set1);
            if (set1.Count == 0) { Console.WriteLine("error"); }
            else
            {
                for (int i = 0; i < m; i++)
                {

                    sets.Add(Generaticnewset(sets, A, k));
                    if (sets[sets.Count - 1].Count == 0)
                    {
                        print(sets[sets.Count - 2]);
                        break;
                    }
                }
            }

        }
        static void print(List<candidate> set)
        {
            Console.WriteLine("Вывод");
            for (int i = 0; i < set.Count; i++)
            {
                set[i].print();
            }
            Console.WriteLine("Конец");
        }

        static List<candidate> Generaticnewset(List<List<candidate>> sets, int[,] A, int k)
        {
            int N = sets.Count;
            List<candidate> startset = sets[N - 1];

            List<candidate> finset = new List<candidate>();
            for (int i = 0; i < startset.Count; i++)
            {
                for (int j = 0; j < startset.Count; j++)
                {
                    if (startset[i].findr(startset[j]) == N)
                    {

                        finset.Add(startset[i].newcandidat(startset[j], A));
                    }
                }
            }
            cleanset(finset, k);
            return finset;


        }


        static void cleanset(List<candidate> set, int k)
        {
            for (int i = 0; i < set.Count; i++)
            {
                bool D;
                D = set[i].del(k);
                if (D == true)
                {
                    set.RemoveAt(i);
                    i--;
                }

            }
            for (int i = 0; i < set.Count; i++)
            {
                for (int j = 0; j < set.Count; j++)
                {
                    if ((set[i].del2(set[j]) == true) && (i != j))
                    {
                        set.RemoveAt(j);
                        j--;
                    }
                }
            }


        } //+

        static void Main(string[] args)
        {
            int k = 3;
            int n = 10;
            int m = 10;
            apriori(vvid(n, m), m, k);
            
            Console.ReadKey();
        }
    }
}

