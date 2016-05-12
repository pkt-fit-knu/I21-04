/*
 * Created by SharpDevelop.
 * Nazar Zdorovylo
 * Kyyiv
 * KNU Shevchenko
 * Faculty of Cybernetics
 * Date: 20.03.2011
 */

#define eps

using System;
using NumericalMethods.Integration;

namespace Integration
{
	class Program
	{
		public static double Funct(double x)
    	{
			return Math.Sqrt(x) * Math.Sin(x);
    	}

		
		public static double Funct2(double x)
    	{
			return x*x + x;
    	}

		public static void Main(string[] args)
		{
			double a = 0;
			double b = 1;
			int pointsNum;
			
			Console.WriteLine("I = Int[0,1](sqrt(x) * sin(x))dx\n\na = {0}\nb = {1}", a, b);
			Console.Write("Vvedit' chyslo rozbytt'a: ");
			pointsNum = Convert.ToInt32(Console.ReadLine());
			
			Chebishev ch = new Chebishev(Funct2, a, b, pointsNum);
			Simpson si = new Simpson(Funct2, a, b, pointsNum);
			Simpson2 si2 = new Simpson2(Funct2, a, b, pointsNum);
			Trapezium tr = new Trapezium(Funct2, a, b, pointsNum);

			Console.WriteLine("\nChebishev");
			double[,] d = ch.GetSolution();
			for (int i = 0; i < d.Length/2; i++)
				Console.WriteLine("i={0}:\th = {1:f4}\tI = {2:f4}", i, d[1,i], d[0,i]);

			Console.WriteLine("\nSimpson");
			d = si.GetSolution();
			for (int i = 0; i < d.Length/2; i++)
				Console.WriteLine("i={0}:\th = {1:f4}\tI = {2:f4}", i, d[1,i], d[0,i]);

			Console.WriteLine("\nSimpson2");
			double dd = si2.GetSolution();
			Console.WriteLine("\t\t\tI = {0:f4}", dd);

			Console.WriteLine("\nTrapezium");
			d = tr.GetSolution();
			for (int i = 0; i < d.Length/2; i++)
				Console.WriteLine("i={0}:\th = {1:f4}\tI = {2:f4}", i, d[1,i], d[0,i]);

			Console.ReadKey(true);
		}
	}
}