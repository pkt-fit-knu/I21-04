namespace NumericalMethods.Integration
{
    using NumericalMethods;
    using System;
    using System.Runtime.CompilerServices;

    public class Simpson2
    {
        public Simpson2(FunctionOne f, double a, double b, int step_number)
        {
            double num = 0.0;
            double num2 = (b - a) / ((double) step_number);
            for (int i = 0; i < step_number; i += 2)
            {
                num += (((f(a + (i * num2)) + (4.0 * f(a + ((i + 1) * num2)))) + f(a + ((i + 2) * num2))) * num2) / 3.0;
            }
            this.Sum = num;
        }

        public double GetSolution()
        {
            return this.Sum;
        }

        private double Sum { get; set; }
    }
}

