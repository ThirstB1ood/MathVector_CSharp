using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LinearAlgebra;
namespace MathVectorTests
{
    [TestClass]
    public class MathVectorTest
    {
        [TestMethod]
        public void TestDimensions()
        {
            var vector = new MathVector(new double[] { 1, 0, 3, 5 });

            int expected = 4;
            int result = vector.Dimensions;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestIndex()
        {
            var vector = new MathVector(new double[] { 1, 0, 3, 5 });

            int i = 1;
            double expected = 0;
            double result = vector[i];

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestIndexSet()
        {
            var vector = new MathVector(new double[] { 1, 0, 3, 5 });

            vector[1] = 5;
            var expected = new MathVector(new double[] { 1, 5, 3, 5 });


            Assert.IsTrue(expected == vector);
        }

        [TestMethod]
        public void TestIndexSetException()
        {
            var vector = new MathVector(new double[] { 1, 0, 3, 5 });

            int i = -1;
            var expected = new MathVector(new double[] { 1, 5, 3, 5 });


            Assert.IsTrue(expected == vector);
            Assert.ThrowsException<System.Exception>(() => vector[i] = 6);
        }

        [TestMethod]
        public void TestIndexSetExceptionPlus()
        {
            var vector = new MathVector(new double[] { 1, 0, 3, 5 });

            int i = 100;
            var expected = new MathVector(new double[] { 1, 5, 3, 5 });


            Assert.IsTrue(expected == vector);
            Assert.ThrowsException<System.Exception>(() => vector[i] = 6);
        }

        [TestMethod]
        public void TestIndexExceptionMinus()
        {
            var vector = new MathVector(new double[] { 1, 0, 3, 5 });

            int i = -1;

            Assert.ThrowsException<System.Exception>(()=> vector[i]);
        }


        [TestMethod]
        public void TestIndexMinusExceptionPlus()
        {
            var vector = new MathVector(new double[] { 1, 0, 3, 5 });

            int i = 100;

            Assert.ThrowsException<System.Exception>(() => vector[i]);
        }

        [TestMethod]
        public void TestLengthPositive()
        {
            var vector = new MathVector(new double[] { 1, 0, 3, 5 });

            double expected = 5.9160797;
            double result = vector.Length;

            Assert.AreEqual(expected, result, 0.0000001);
        }

        [TestMethod]
        public void TestLengthNegative()
        {
            var vector = new MathVector(new double[] { -5 });

            double expected = 5;
            double result = vector.Length;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSumNumberPlus()
        {
            var vector = new MathVector(new double[] { 1, 0, 3, 5 });
            var expected = new MathVector(new double[] { 4, 3, 6, 8 });

            var result = (MathVector)vector.SumNumber(3);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestSumNumberFalse()
        {
            var vector = new MathVector(new double[] { 1, 4 });
            var expected = new MathVector(new double[] { 5, 7 });

            var result = (MathVector)vector.SumNumber(3);

            Assert.IsFalse(expected == result);
        }

        [TestMethod]
        public void TestSumNumberMinus()
        {
            var vector = new MathVector(new double[] { 1, 4 });
            var expected = new MathVector(new double[] { -2, 1 });

            var result = (MathVector)vector.SumNumber(-3);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiplyNumberNegative()
        {
            var vector = new MathVector(new double[] { 1, 4 });
            var expected = new MathVector(new double[] { -1, -4 });

            var result = (MathVector)vector.MultiplyNumber(-1);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiplyNumberNull()
        {
            var vector = new MathVector(new double[] { 1, 4 });
            var expected = new MathVector(new double[] { 0, 0 });

            var result = (MathVector)vector.MultiplyNumber(0);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiplyNumberPosotive()
        {
            var vector = new MathVector(new double[] { 1, 4, 2 });
            var expected = new MathVector(new double[] { 3, 12, 6 });

            var result = (MathVector)vector.MultiplyNumber(3);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiplyNumberFalse()
        {
            var vector = new MathVector(new double[] { 1, 4, 2 });
            var expected = new MathVector(new double[] { 0, 12, 6 });

            var result = (MathVector)vector.MultiplyNumber(3);

            Assert.IsFalse(expected == result);
        }

        [TestMethod]
        public void TestSum()
        {
            var vector = new MathVector(new double[] { 1, 4, 2 });
            var vect2 = new MathVector(new double[] { 2, 3, 5 });

            var expected = new MathVector(new double[] { 3, 7, 7 });

            var result = (MathVector)vector.Sum(vect2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestSumException()
        {
            var vector = new MathVector(new double[] { 1, 4, 2 });
            var vect2 = new MathVector(new double[] { 2, 3 });

            Assert.ThrowsException<System.Exception>(()=> (MathVector)vector.Sum(vect2));
        }

        [TestMethod]
        public void TestMultiply()
        {
            var vector = new MathVector(new double[] { 1, 4, 2 });
            var vect2 = new MathVector(new double[] { 2, 3, 5 });

            var expected = new MathVector(new double[] { 2, 12, 10 });

            var result = (MathVector)vector.Multiply(vect2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiplyException()
        {
            var vector = new MathVector(new double[] { 1, 4, 2 });
            var vect2 = new MathVector(new double[] { 2, 3 });

            Assert.ThrowsException<System.Exception>(()=> (MathVector)vector.Multiply(vect2));
        }

        [TestMethod]
        public void TestMultiplyFalse()
        {
            var vector = new MathVector(new double[] { 1, 4, 2 });
            var vect2 = new MathVector(new double[] { 2, 3, 5 });

            var expected = new MathVector(new double[] { 2, 12, 1 });

            var result = (MathVector)vector.Multiply(vect2);

            Assert.IsFalse(expected == result);
        }

        [TestMethod]
        public void TestDivide()
        {
            var vector = new MathVector(new double[] { 6, 4, 2 });
            var vect2 = new MathVector(new double[] { 3, 2, 1 });

            
            var expected = new MathVector(new double[] { 2, 2, 2 });

            var result = (MathVector)vector.Divide(vect2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestDivideException()
        {
            var vector = new MathVector(new double[] { 1, 4, 2 });
            var vect2 = new MathVector(new double[] { 2, 3 });

            Assert.ThrowsException<Exception>(()=> (MathVector)vector.Divide(vect2));
        }

        [TestMethod]
        public void TestDivideByZeroExceprion()
        {
            var vector = new MathVector(new double[] { 6, 4, 2 });
            var vect2 = new MathVector(new double[] { 3, 2, 0 });

            Assert.ThrowsException<DivideByZeroException>(()=> (MathVector)vector.Divide(vect2));
        }

        [TestMethod]
        public void TestDivideNumber()
        {
            var vector = new MathVector(new double[] { 5, 4, 37 });

            var expected = new MathVector(new double[] { 2.5, 2, 18.5 });

            var result = (MathVector)vector.DivideNumber(2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestDivideNumberZeroExceprion()
        {
            var vector = new MathVector(new double[] { 6, 4, 2 });

            Assert.ThrowsException<DivideByZeroException>(()=> (MathVector)vector.DivideNumber(0));
        }

        [TestMethod]
        public void TestScalar()
        {
            var vector = new MathVector(new double[] { 6, 4, 2 });
            var vect2 = new MathVector(new double[] { 3, 2, 0 });

            double result = 26;

            double expected = vector.ScalarMultiply(vect2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestScalarDiffLengthException()
        {
            var vector = new MathVector(new double[] { 6, 4, 2 });
            var vect2 = new MathVector(new double[] { 3, 2 });

            Assert.ThrowsException<System.Exception>(()=> vector.ScalarMultiply(vect2));
        }

        [TestMethod]
        public void TestCalcDistanceDiffLengthException()
        {
            var vector = new MathVector(new double[] { 6, 4, 2 });
            var vect2 = new MathVector(new double[] { 3, 2 });

            Assert.ThrowsException<System.Exception>(()=> vector.CalcDistance(vect2));
        }

        [TestMethod]
        public void TestCalcDistance()
        {
            var vector = new MathVector(new double[] { 6, 4, 2 });
            var vect2 = new MathVector(new double[] { 3, 2, 4 });

            double result = 4.1231056;

            double expected = vector.CalcDistance(vect2);

            Assert.AreEqual(expected, result, 0.0000001);
        }

        [TestMethod]
        public void TestOperatorPlusNumber()
        {
            var vector = new MathVector(new double[] { 1, 0, 3, 5 });

            var expected = new MathVector(new double[] { 4, 3, 6, 8 });

            var result = (MathVector)(vector + 3);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestOperatorPlusVector()
        {
            var vector = new MathVector(new double[] { 4, 4, 2 });
            var vect2 = new MathVector(new double[] { 3, 2, 4 });

            var expected = new MathVector(new double[] { 7, 6, 6 });

            var result = (MathVector)(vector + vect2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestOperatorPLusVectorException()
        {
            var vector = new MathVector(new double[] { 6, 4, 2 });
            var vect2 = new MathVector(new double[] { 3, 2 });

            Assert.ThrowsException<System.Exception>(()=> (MathVector)(vector + vect2));
        }

        [TestMethod]
        public void TestOperatorMinusNumber()
        {
            var vector = new MathVector(new double[] { 1, 0, 3, 5 });

            var expected = new MathVector(new double[] { 0, -1, 2, 4 });

            var result = (MathVector)(vector - 1);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestOperatorMinusVector()
        {
            var vector = new MathVector(new double[] { 6, 4, 2 });
            var vect2 = new MathVector(new double[] { 3, 2, 4 });

            var expected = new MathVector(new double[] { 3, 2, -2 });

            var result = (MathVector)(vector - vect2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestOperatorMultiplyNumber()
        {
            var vector = new MathVector(new double[] { 1, 0, 3, 5 });

            var expected = new MathVector(new double[] { 3, 0, 9, 15 });

            var result = (MathVector)(vector * 3);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestOperatorMultiplyVector()
        {
            var vector = new MathVector(new double[] { 6, 4, 2 });
            var vect2 = new MathVector(new double[] { 3, 2, 4 });

            var expected = new MathVector(new double[] { 18, 8, 8 });

            var result = (MathVector)(vector * vect2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestOperatorDivideNumber()
        {
            var vector = new MathVector(new double[] { 9, 0, 3, 12 });

            var expected = new MathVector(new double[] { 3, 0, 1, 4 });

            var result = (MathVector)(vector / 3);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestOperatorDivideVector()
        {
            var vector = new MathVector(new double[] { 6, 4, 2 });
            var vect2 = new MathVector(new double[] { 3, 2, 4 });

            var expected = new MathVector(new double[] { 2, 2, 0.5 });

            var result = (MathVector)(vector / vect2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestOperatorScalar()
        {
            var vector = new MathVector(new double[] { 6, 4, 2 });
            var vect2 = new MathVector(new double[] { 3, 2, 0 });

            double result = 26;

            double expected = vector % vect2;

            Assert.AreEqual(expected, result);
        }
    }
}
