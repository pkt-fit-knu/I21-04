namespace NumericalMethods.Integration
{
    using NumericalMethods;
    using System;

    public class Trapezium
    {
        private double[,] result;

        public Trapezium(FunctionOne f, double a, double b, int pointsNum)
        {
            int num4 = 4;
            this.result = new double[2, pointsNum + 1];
            for (int i = 0; i <= pointsNum; i++)
            {
                double num = (b - a) / ((double) num4);
                num4 += 4;
                double num3 = f(a) + f(b);
                for (double j = a + num; j < b; j += num)
                {
                    num3 += 2.0 * f(j);
                }
                num3 = (num3 * num) / 2.0;
                this.result[0, i] = num3;
                this.result[1, i] = num;
            }
        }

        public double[,] GetSolution()
        {
            return this.result;
        }
    }
}

