/*
 * Created by SharpDevelop.
 * Nazar Zdorovylo
 * Kyyiv
 * KNU Shevchenko
 * Faculty of Cybernetics
 * Date: 24.03.2011
 */
using System;
using NumericalMethods.DifferentialEquations;

namespace Differential
{
	class Program
	{
		public static double Funct(double x, double y)
		{
			return x*x+y;
		}
		
		public static void Main(string[] args)
		{
			double begin = 0;
			double end = 3.14;
			double y0 = 1;
			int pointsNum;

			Console.WriteLine("y'(x) = x^2 + y\n\nbegin = {0}\nend = {1}\ny0 = {2}", begin, end, y0);
			Console.Write("Vvedit' chyslo rozbytt'a: ");
			pointsNum = Convert.ToInt32(Console.ReadLine());
			
			EulerCorrected ec = new EulerCorrected(Funct, begin, end, y0, pointsNum);
			EulerModified em = new EulerModified(Funct, begin, end, y0, pointsNum);
			EulerSimple es = new EulerSimple(Funct, begin, end, y0, pointsNum);
			RungeKutta4 rk = new RungeKutta4(Funct, begin, end, y0, pointsNum);

			Console.WriteLine("\nEulerCorrected");
			double[,] d = ec.GetSolution();
			for (int i = 0; i < d.Length/2; i++)
				Console.WriteLine("i={0}:\th = {1:f4}\t{2:f4}", i, d[1,i], d[0,i]);

			Console.WriteLine("\nEulerModified");
			d = em.GetSolution();
			for (int i = 0; i < d.Length/2; i++)
				Console.WriteLine("i={0}:\th = {1:f4}\t{2:f4}", i, d[1,i], d[0,i]);

			Console.WriteLine("\nEulerSimple");
			d = es.GetSolution();
			for (int i = 0; i < d.Length/2; i++)
				Console.WriteLine("i={0}:\th = {1:f4}\t{2:f4}", i, d[1,i], d[0,i]);

			Console.WriteLine("\nRungeKutta4");
			d = rk.GetSolution();
			for (int i = 0; i < d.Length/2; i++)
				Console.WriteLine("i={0}:\th = {1:f4}\t{2:f4}", i, d[1,i], d[0,i]);
			
			Console.ReadKey(true);
		}
	}
}