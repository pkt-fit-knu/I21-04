namespace NumericalMethods.Integration
{
    using NumericalMethods;
    using System;

    public class Simpson
    {
        private double[,] result;

        public Simpson(FunctionOne f, double a, double b, int pointsNum)
        {
            double num2 = 0.0;
            int num4 = 0;
            double num3 = 0.014999999664723873;
            this.result = new double[2, pointsNum + 1];
            for (int i = 0; i < pointsNum; i++)
            {
                double x = a + num3;
                do
                {
                    if ((num4 % 2) == 0)
                    {
                        num2 += 2.0 * f(x);
                    }
                    else
                    {
                        num2 += 4.0 * f(x);
                    }
                    x += num3;
                    num4++;
                }
                while (x < b);
                num2 = (num2 + f(a)) + f(b);
                num2 *= num3 / 3.0;
                this.result[0, i] = num2;
                this.result[1, i] = num3;
                num2 = 0.0;
                num3 += 0.0010000000474974513;
            }
        }

        public double[,] GetSolution()
        {
            return this.result;
        }
    }
}

