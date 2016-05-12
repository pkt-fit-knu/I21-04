namespace NumericalMethods.DifferentialEquations
{
    using NumericalMethods;
    using System;

    public class EulerSimple
    {
        private double[,] result;

        public EulerSimple(Function function, double begin, double end, double y0, int pointsNum)
        {
            double x = 0.0;
            this.result = new double[2, pointsNum];
            double num4 = (end - begin) / ((double) pointsNum);
            double num2 = y0;
            double y = 0.0;
            for (int i = 0; i < pointsNum; i++)
            {
                y = num2 + (num4 * function(x, y));
                num2 = y;
                x += num4;
                this.result[0, i] = x;
                this.result[1, i] = y;
            }
        }

        public double[,] GetSolution()
        {
            return this.result;
        }
    }
}

