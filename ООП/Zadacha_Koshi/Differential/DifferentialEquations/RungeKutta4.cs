namespace NumericalMethods.DifferentialEquations
{
    using NumericalMethods;
    using System;

    public class RungeKutta4
    {
        private double[,] result;

        public RungeKutta4(Function function, double begin, double end, double y0, int pointsNum)
        {
            this.result = new double[2, pointsNum + 1];
            double num4 = (end - begin) / ((double) pointsNum);
            double x = 0.0;
            double y = 0.0;
            double num5 = y0;
            this.result[0, 0] = x;
            this.result[1, 0] = num5;
            for (int i = 1; i <= pointsNum; i++)
            {
                double num = num4 * function(x, y);
                x += num4 / 2.0;
                y = num5 + (num / 2.0);
                double num2 = function(x, y) * num4;
                y = num5 + (num2 / 2.0);
                double num3 = function(x, y) * num4;
                x += num4 / 2.0;
                y = num5 + ((((num + (2.0 * num2)) + (2.0 * num3)) + (function(x, y) * num4)) / 6.0);
                num5 = y;
                this.result[0, i] = x;
                this.result[1, i] = num5;
            }
        }

        public double[,] GetSolution()
        {
            return this.result;
        }
    }
}

