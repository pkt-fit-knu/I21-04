namespace NumericalMethods.DifferentialEquations
{
    using NumericalMethods;
    using System;

    public class EulerCorrected
    {
        private double[,] result;

        public EulerCorrected(Function function, double begin, double end, double y0, int pointsNum)
        {
            double y = 0.0;
            double x = 0.0;
            this.result = new double[2, pointsNum + 1];
            double num5 = (end - begin) / ((double) pointsNum);
            double num2 = y0;
            for (int i = 0; i <= pointsNum; i++)
            {
                double num3 = function(x, y);
                y = num2 + ((num5 / 2.0) * (function(x, y) + function(x + num5, y + (num5 * num3))));
                this.result[0, i] = x;
                this.result[1, i] = num2;
                num2 = y;
                x += num5;
            }
        }

        public double[,] GetSolution()
        {
            return this.result;
        }
    }
}

