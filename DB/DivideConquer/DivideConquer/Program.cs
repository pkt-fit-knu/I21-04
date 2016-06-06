using System;
using System.Collections.Generic;
using System.Data;

namespace DivideConquer
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtable = new DataTable();

            Attrib outlook = new Attrib(Const.Outlook, new List<Dannue>() { new Dannue(Const.Sunny), new Dannue(Const.Overcast), new Dannue(Const.Rainy) });
            Attrib temperature = new Attrib(Const.Temp, new List<Dannue>() { new Dannue(Const.Hot), new Dannue(Const.Mild), new Dannue(Const.Cool) });
            Attrib humidity = new Attrib(Const.Humidity, new List<Dannue>() { new Dannue(Const.High), new Dannue(Const.Normal) });
            Attrib windy = new Attrib(Const.Windy, new List<Dannue>() { new Dannue(Const.False), new Dannue(Const.True) });
            Attrib play = new Attrib(Const.Play, new List<Dannue>() { new Dannue(Const.Yes), new Dannue(Const.No) });

            List<Attrib> attributes = new List<Attrib>() { outlook, temperature, humidity, windy };

            dtable.Columns.Add(outlook.attributeName, typeof(string));
            dtable.Columns.Add(temperature.attributeName, typeof(string));
            dtable.Columns.Add(humidity.attributeName, typeof(string));
            dtable.Columns.Add(windy.attributeName, typeof(string));
            dtable.Columns.Add(play.attributeName, typeof(string));

                      

            dtable.Rows.Add(Const.Sunny, Const.Hot, Const.High, Const.False, Const.No);
            dtable.Rows.Add(Const.Sunny, Const.Hot, Const.High, Const.True, Const.No);
            dtable.Rows.Add(Const.Overcast, Const.Hot, Const.High, Const.False, Const.Yes);
            dtable.Rows.Add(Const.Rainy, Const.Mild, Const.High, Const.False, Const.Yes);
            dtable.Rows.Add(Const.Rainy, Const.Cool, Const.Normal, Const.False, Const.Yes);
            dtable.Rows.Add(Const.Rainy, Const.Cool, Const.Normal, Const.True, Const.No);
            dtable.Rows.Add(Const.Overcast, Const.Cool, Const.Normal, Const.True, Const.Yes);
            dtable.Rows.Add(Const.Sunny, Const.Mild, Const.High, Const.False, Const.No);
            dtable.Rows.Add(Const.Sunny, Const.Cool, Const.Normal, Const.False, Const.Yes);
            dtable.Rows.Add(Const.Rainy, Const.Mild, Const.Normal, Const.False, Const.Yes);
            dtable.Rows.Add(Const.Sunny, Const.Mild, Const.Normal, Const.True, Const.Yes);
            dtable.Rows.Add(Const.Overcast, Const.Mild, Const.High, Const.True, Const.Yes);
            dtable.Rows.Add(Const.Overcast, Const.Hot, Const.Normal, Const.False, Const.Yes);
            dtable.Rows.Add(Const.Rainy, Const.Mild, Const.High, Const.True, Const.No);

           
            

            Tree decisionTree = new Tree();

            decisionTree.BuildDecisionTree(dtable, attributes, null);

            decisionTree.PrintDecisionTree(decisionTree.treeNodes[0]);

            Console.ReadKey();
        }
    }

    internal class Attrib
    {
        public string attributeName;

        public List<Dannue> options;

        public double averageInformationValue;

        public Attrib(string attributeName, List<Dannue> options)
        {
            this.attributeName = attributeName;

            this.options = options;
        }
        /// <summary>
        /// /////////////////////
        /// </summary>
        public void setAverageInfVal()
        {
            int overallYes = 0;
            int overallNo = 0;

            foreach (Dannue option in this.options)//подсчитываем количество да и нет
            {
                overallYes += option.yesAmount;
                overallNo += option.noAmount;
            }

            //вес одного к сумме 
            double tempYes = (double)overallYes / (overallYes + overallNo);
            double tempNo = (double)overallNo / (overallYes + overallNo);

            //определяем вес информации
            double tempInformationValue = -(tempYes * Math.Log(tempYes, 2) + tempNo * Math.Log(tempNo, 2));

            int overallYesNo = 0;
            double tempResult = 0;

            foreach (Dannue option in this.options)
            {
                overallYesNo = option.yesAmount + option.noAmount;

                tempResult += (double)overallYesNo / (overallYes + overallNo) * option.informationValue;
            }

            this.averageInformationValue = tempInformationValue - tempResult;

            Console.WriteLine("   " + this.averageInformationValue);
        }
    }

    internal static class Const
    {
        public const string Outlook = "Outlook";

        public const string Sunny = "Sunny";
        public const string Overcast = "Overcast";
        public const string Rainy = "Rainy";


        public const string Temp = "Temperature";

        public const string Hot = "Hot";
        public const string Mild = "Mild";
        public const string Cool = "Cool";


        public const string Humidity = "Humidity";

        public const string High = "High";
        public const string Normal = "Normal";


        public const string Windy = "Windy";

        public const string False = "False";
        public const string True = "True";


        public const string Play = "Play";

        public const string Yes = "Yes";
        public const string No = "No";
    }


    /// <summary>

    /// </summary>
    /// 
    ///////////////////////////
    internal class Tree
    {
        public List<TreeUzel> treeNodes;

        public Tree()
        {
            this.treeNodes = new List<TreeUzel>();
        }

        public void BuildDecisionTree(DataTable table, List<Attrib> attributes, Svazn relation)
        {

            //проходим по колонкам данных
            for (int i = 0; i < table.Columns.Count - 1; i++)
            {

                foreach (Attrib attribute in attributes)//
                {
                    //находим атрибут соответствующей колонки
                    if (table.Columns[i].Caption == attribute.attributeName)
                    {

                        //подсчитываем да, нет в каждой строке
                        for (int j = 0; j < table.Rows.Count; j++)
                        {
                            foreach (Dannue option in attribute.options)
                            {
                                if (table.Rows[j][i].ToString() == option.optionName)
                                {
                                    if (table.Rows[j].Field<string>("Play") == Const.Yes)
                                    {
                                        option.yesAmount++;
                                    }
                                    else if (table.Rows[j].Field<string>("Play") == Const.No)
                                    {
                                        option.noAmount++;
                                    }
                                }
                            }
                        }

                        /////////////

                        foreach (Dannue option in attribute.options)
                        {
                            //вызывается метод вычисление веса информации
                            option.setInformationValue();
                            //если хоть да или нет = 0, то общий вес тоже = 0
                            if (Double.IsNaN(option.informationValue))
                            {
                                option.informationValue = 0;
                            }

                            Console.WriteLine(option.informationValue);
                        }

                        //вычисляем среднее значение веса информации для всего атрибута
                        attribute.setAverageInfVal();

                        Console.WriteLine("      " + attribute.averageInformationValue);
                    }
                }
            }

            Attrib choosenAttribute = attributes[0];

            //выбираем атрибут с максимальной весом информации
            for (int i = 1; i < attributes.Count; i++)
            {
                if (attributes[i].averageInformationValue > choosenAttribute.averageInformationValue)
                {
                    choosenAttribute = attributes[i];
                }
            }

            Console.WriteLine("         " + choosenAttribute.averageInformationValue);
            Console.WriteLine(Environment.NewLine + Environment.NewLine);


            List<Svazn> relations = new List<Svazn>();

            DataTable dataTable;

            foreach (Dannue option in choosenAttribute.options)
            {
                if (option.informationValue != 0)
                {
                    dataTable = table.Copy();
                    //проходим по строкам таблицы
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        //выбираем одну опцию, удаляя строки, которые ее не содержат
                        //оставляем строки содержащие требуемое значение (опцию) колонки (аттрибута) 
                        if (dataTable.Rows[i].Field<string>(choosenAttribute.attributeName) != option.optionName)
                        {
                            dataTable.Rows.Remove(dataTable.Rows[i]);
                            i--;
                        }
                    }

                    //добавляем ветки к дереву
                    relations.Add(new Svazn(null, option.optionName, dataTable));
                }
                else
                {
                    string nodeData = "";

                    if (option.yesAmount == 0)
                    {
                        nodeData = Const.No;
                    }
                    else if (option.noAmount == 0)
                    {
                        nodeData = Const.Yes;
                    }

                    relations.Add(new Svazn(new TreeUzel(nodeData, null, null), option.optionName, null));
                }
            }

            List<Attrib> tempAttributes = new List<Attrib>();

            //выбираем все атрибуты, кроме максимального 
            foreach (Attrib attribute in attributes)
            {
                if (attribute != choosenAttribute)
                {
                    tempAttributes.Add(attribute);
                }
            }

            TreeUzel tempTreeNode = new TreeUzel(choosenAttribute.attributeName, relations, tempAttributes);

            //добавляем ветку в список веток дерева 
            this.treeNodes.Add(tempTreeNode);

            if (relation != null)
            {
                relation.childNode = tempTreeNode;
            }

            foreach (Attrib attribute in attributes)
            {
                foreach (Dannue option in attribute.options)
                {
                    option.yesAmount = 0;
                    option.noAmount = 0;
                }

                attribute.averageInformationValue = 0;
            }

            //перебераем все все ветки и строим рекурсивно Decision tree для каждой зависимости  
            foreach (Svazn newRelation in relations)
            {
                if (newRelation.childNode == null)
                {
                    //рекурсия
                    BuildDecisionTree(newRelation.dataTable, tempTreeNode.attributes, newRelation);
                }
                else
                {
                    continue;
                }
            }
        }

        public void PrintDecisionTree(TreeUzel treeNode)
        {
            if (treeNode.nodeData != Const.Yes && treeNode.nodeData != Const.No)
            {
                Console.WriteLine(treeNode.nodeData);
            }
            else
            {
                Console.WriteLine("                      " + treeNode.nodeData);
            }

            if (treeNode.relations != null)
            {
                foreach (Svazn relation in treeNode.relations)
                {
                    Console.WriteLine("           " + relation.childEdge);

                    PrintDecisionTree(relation.childNode);
                }
            }
        }
    }

    internal class Dannue
    {
        public string optionName;

        public int yesAmount;
        public int noAmount;

        public double informationValue;

        public Dannue(string optionName)
        {
            this.optionName = optionName;
        }

        //вычисление веса информации для опции(вар погоды - атрибута)
        public void setInformationValue()
        {
            double tempYes = (double)this.yesAmount / (this.yesAmount + this.noAmount);
            double tempNo = (double)this.noAmount / (this.yesAmount + this.noAmount);

            this.informationValue = -(tempYes * Math.Log(tempYes, 2) + tempNo * Math.Log(tempNo, 2));
        }
    }

    internal class Svazn
    {
        public TreeUzel childNode;
        public string childEdge;

        public DataTable dataTable;

        public Svazn(TreeUzel childNode, string childEdge, DataTable dataTable)
        {
            this.childNode = childNode;
            this.childEdge = childEdge;

            this.dataTable = dataTable;
        }
    }

    internal class TreeUzel
    {
        public string nodeData;

        public List<Svazn> relations;

        public List<Attrib> attributes;

        public TreeUzel(string nodeData, List<Svazn> relations, List<Attrib> attributes)
        {
            this.nodeData = nodeData;

            this.relations = relations;

            this.attributes = attributes;
        }
    }
}