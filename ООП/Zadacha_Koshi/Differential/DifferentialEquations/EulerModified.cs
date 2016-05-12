namespace NumericalMethods.DifferentialEquations
{
    using NumericalMethods;
    using System;

    public class EulerModified
    {
        private double[,] result;

        public EulerModified(Function function, double begin, double end, double y0, int pointsNum)
        {
            double y = 0.0;
            double x = 0.0;
            this.result = new double[2, pointsNum + 1];
            double num5 = (end - begin) / ((double) pointsNum);
            double num2 = y0;
            x = 0.0;
            this.result[0, 0] = x;
            this.result[1, 0] = num2;
            for (int i = 1; i <= pointsNum; i++)
            {
                double num3 = function(x, y);
                x += num5;
                y += num3 * num5;
                y = num2 + ((num5 * (num3 + function(x, y))) / 2.0);
                num2 = y;
                this.result[0, i] = x;
                this.result[1, i] = num2;
            }
        }

        public double[,] GetSolution()
        {
            return this.result;
        }
    }
}

