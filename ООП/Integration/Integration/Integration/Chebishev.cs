namespace NumericalMethods.Integration
{
    using NumericalMethods;
    using System;

    public class Chebishev
    {
        private double[,] result;

        public Chebishev(FunctionOne f, double a, double b, int pointsNum)
        {
            int num4 = 4;
            this.result = new double[2, pointsNum + 1];
            for (int i = 0; i <= pointsNum; i++)
            {
                double num = (b - a) / ((double) num4);
                num4 += 4;
                double num3 = 0.0;
                for (double j = a; j <= b; j += num)
                {
                    num3 += this.ChebushevMethod(j, j + num, f);
                }
                this.result[0, i] = num3;
                this.result[1, i] = num;
            }
        }

        private double ChebushevMethod(double A, double B, FunctionOne f)
        {
            double[] numArray = new double[] { 0.0, -0.832498, -0.37451300024986267, 0.0, 0.374513, 0.832498 };
            double num3 = 0.0;
            for (int i = 1; i <= 5; i++)
            {
                double x = ((A + B) / 2.0) + (((B - A) * numArray[i]) / 2.0);
                num3 += f(x);
            }
            return ((num3 * (B - A)) / 5.0);
        }

        public double[,] GetSolution()
        {
            return this.result;
        }
    }
}

