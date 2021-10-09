using System;
using System.Collections.Generic;
using LinearAlgebra;
using MathVectorTests;

namespace VectorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*double[] num = { 1, 0, 3 };
            IMathVector vector = new MathVector(num);
            Console.Write(vector + "\n");
            double[] num1 = { 1, 2, 0 };
            IMathVector vect = new MathVector(num1);
            Console.Write(vect + "\n");
            Console.Write(vector.Sum(vect) +"\n");
            Console.Write(vector.MultiplyNumber(2) +"\n");
            Console.Write(vector.Length +"\n");
            Console.Write(vector.Dimensions +"\n");
            Console.Write(vector.ScalarMultiply(vect) + "\n");
            double[] num2 = { 1, 2, 0, 6 };
            MathVector vect2 = new MathVector(num2);
            Console.Write(vect2.Sum(vector) +"\n");
            Console.Write(vector.ScalarMultiply(vect2) + "\n");
            MathVector vect4 = new MathVector(vect2);
            vect4[1] = 100;
            Console.Write(vect2 +"\n\n");
            double[] numbers = { };
            IMathVector vectorrr = new MathVector(numbers);
            Console.Write(vectorrr.SumNumber(3) + "\n");
            Console.Write(vect4.DivideNumber(0) + "\n");
            vect[3] = 6;
            Console.ReadKey();*/
            MathVectorTest mathTest = new MathVectorTest();
            mathTest.TestMultiplyNumberFalse();
            /*mathTest.TestMultiplyFalse();
            mathTest.TestDivide_2();
            mathTest.TestDivide_3();
            mathTest.TestDivideNumberZero();
            mathTest.TestScalar_2();*/
            mathTest.TestCalcDistance_2();
        }
    }
}
