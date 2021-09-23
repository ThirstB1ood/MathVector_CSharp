using System;
using System.Collections.Generic;
using LinearAlgebra;

namespace VectorDemo
{
    class Program
    {
        private static void ShowMenu()
        {
            Console.Write("1) Show Vectors\n" +
                "2) Add Vector\n" +
                "3) Sum\n" +
                "4) Substract\n" +
                "5) Multiply\n" +
                "6) Divide\n" +
                "7) Distance\n" +
                "8) Exit");
        }

        private static MathVector ReadVector()
        {
            Console.Write("Enter points\n");
            string[] pointsString = Console.ReadLine().Split();
            var pointsDouble = new double[pointsString.Length];
            for(int i = 0; i < pointsString.Length; i++)
            {
                pointsDouble[i] = Convert.ToDouble(pointsString[i]);
            }
            MathVector vector = new MathVector(pointsDouble);
            return vector;
        }

        private static void SelectAction()
        {

        }



        static void Main(string[] args)
        {
            MathVector[] vector = new MathVector[10];
            vector[0] = ReadVector();
            Console.Write($"{1}. " + vector[0][2]);
            Console.ReadKey();
        }
    }
}
