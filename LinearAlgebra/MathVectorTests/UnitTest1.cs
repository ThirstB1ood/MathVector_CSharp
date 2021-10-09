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
            double[] num = new double[]{ 1, 0, 3, 5 };
            MathVector vector = new MathVector(num);

            int expected = 4;
            int result = vector.Dimensions;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestIndex_1()
        {
            double[] num = { 1, 0, 3, 5 };
            MathVector vector = new MathVector(num);

            int i = 1;
            double expected = 0;
            double result = vector[i];

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestIndex_2()
        {
            double[] num = { 1, 0, 3, 5 };
            MathVector vector = new MathVector(num);

            int i = -1;

            Assert.ThrowsException<Exception>(delegate
            {
                double result = vector[i];
            });
        }

        [TestMethod]
        public void TestLength_1()
        {
            double[] num = { 1, 0, 3, 5 };
            MathVector vector = new MathVector(num);

            double expected = 5.9160797;
            double result = vector.Length;

            Assert.AreEqual(expected, result, 0.0000001);
        }

        [TestMethod]
        public void TestLength_2()
        {
            double[] num = {-5};
            MathVector vector = new MathVector(num);

            double expected = 5;
            double result = vector.Length;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSumNumber_1()
        {
            double[] num = { 1, 0, 3, 5 };
            MathVector vector = new MathVector(num);

            double[] res = { 4, 3, 6, 8 };
            var expected = new MathVector(res);

            var result = (MathVector)vector.SumNumber(3);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestSumNumberFalse()
        {
            double[] num = { 1, 4 };
            MathVector vector = new MathVector(num);

            double[] res = { 5, 7 };
            var expected = new MathVector(res);

            var result = (MathVector)vector.SumNumber(3);

            Assert.IsFalse(expected == result);
        }

        [TestMethod]
        public void TestSumNumber_2()
        {
            double[] num = { 1, 4 };
            MathVector vector = new MathVector(num);

            double[] res = { -2, 1 };
            var expected = new MathVector(res);
            
            var result = (MathVector)vector.SumNumber(-3);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiplyNumber_1()
        {
            double[] num = { 1, 4 };
            MathVector vector = new MathVector(num);

            double[] res = { -1, -4 };
            var expected = new MathVector(res);
            
            var result = (MathVector)vector.MultiplyNumber(-1);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiplyNumber_2()
        {
            double[] num = { 1, 4 };
            MathVector vector = new MathVector(num);

            double[] res = { 0, 0};
            var expected = new MathVector(res);

            var result = (MathVector)vector.MultiplyNumber(0);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiplyNumber_3()
        {
            double[] num = { 1, 4, 2 };
            double[] res = { 3, 12, 6 };

            var expected = new MathVector(res);
            var vector = new MathVector(num);

            var result = (MathVector)vector.MultiplyNumber(3);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiplyNumberFalse()
        {
            double[] num = { 1, 4, 2 };
            double[] res = { 0, 12, 6 };

            var expected = new MathVector(res);
            var vector = new MathVector(num);

            var result = (MathVector)vector.MultiplyNumber(3);

            Assert.IsFalse(expected == result);
        }

        [TestMethod]
        public void TestSum_1()
        {
            double[] num = { 1, 4, 2 }, num2 = { 2, 3, 5 };
            var vector = new MathVector(num);
            var vect2 = new MathVector(num2);

            double[] res = { 3, 7, 7 };
            var expected = new MathVector(res);

            var result = (MathVector)vector.Sum(vect2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestSum_2()
        {
            double[] num = { 1, 4, 2 }, num2 = { 2, 3 };
            var vector = new MathVector(num);
            var vect2 = new MathVector(num2);

            double[] res = { 3, 7, 7 };
            var expected = new MathVector(res);

            Assert.ThrowsException<Exception>(delegate
            {
                var result = (MathVector)vector.Sum(vect2);
            });
        }

        [TestMethod]
        public void TestMultiply_1()
        {
            double[] num = { 1, 4, 2 }, num2 = { 2, 3, 5 };
            var vector = new MathVector(num);
            var vect2 = new MathVector(num2);

            double[] res = { 2, 12, 10 };
            var expected = new MathVector(res);

            var result = (MathVector)vector.Multiply(vect2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiply_2()
        {
            double[] num = { 1, 4, 2 }, num2 = { 2, 3 };
            var vector = new MathVector(num);
            var vect2 = new MathVector(num2);

            Assert.ThrowsException<Exception>(delegate
            {
                var result = (MathVector)vector.Multiply(vect2);
            });
        }

        [TestMethod]
        public void TestMultiplyFalse()
        {
            double[] num = { 1, 4, 2 }, num2 = { 2, 3, 5 };
            var vector = new MathVector(num);
            var vect2 = new MathVector(num2);

            double[] res = { 2, 12, 1 };
            var expected = new MathVector(res);

            var result = (MathVector)vector.Multiply(vect2);

            Assert.IsFalse(expected == result);
        }

        [TestMethod]
        public void TestDivide_1()
        {
            double[] num = { 6, 4, 2 }, num2 = { 3, 2, 1 };
            var vector = new MathVector(num);
            var vect2 = new MathVector(num2);

            double[] res = { 2, 2, 2 };
            var expected = new MathVector(res);

            var result = (MathVector)vector.Divide(vect2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestDivide_2()
        {
            double[] num = { 1, 4, 2 }, num2 = { 2, 3 };
            var vector = new MathVector(num);
            var vect2 = new MathVector(num2);

            Assert.ThrowsException<Exception>(delegate
            {
                var result = (MathVector)vector.Divide(vect2);
            });
        }

        [TestMethod]
        public void TestDivide_3()
        {
            double[] num = { 6, 4, 2 }, num2 = { 3, 2, 0 };
            var vector = new MathVector(num);
            var vect2 = new MathVector(num2);

            Assert.ThrowsException<DivideByZeroException>(delegate
            {
                var result = (MathVector)vector.Divide(vect2);
            });
        }

        [TestMethod]
        public void TestDivideNumber()
        {
            double[] num = { 5, 4, 37 };
            var vector = new MathVector(num);

            double[] res = { 2.5, 2, 18.5 };
            var expected = new MathVector(res);

            var result = (MathVector)vector.DivideNumber(2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestDivideNumberZero()
        {
            double[] num = { 6, 4, 2 };
            var vector = new MathVector(num);

            Assert.ThrowsException<DivideByZeroException>(delegate
            {
                var result = (MathVector)vector.DivideNumber(0);
            });
        }

        [TestMethod]
        public void TestScalar_1()
        {
            double[] num = { 6, 4, 2 }, num2 = { 3, 2, 0 };
            var vector = new MathVector(num);
            var vect2 = new MathVector(num2);

            double result = 26;

            double expected = vector.ScalarMultiply(vect2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestScalar_2()
        {
            double[] num = { 6, 4, 2 }, num2 = { 3, 2 };
            var vector = new MathVector(num);
            var vect2 = new MathVector(num2);

            Assert.ThrowsException<Exception>(delegate
            {
                var result = vector.ScalarMultiply(vect2);
            });
        }

        [TestMethod]
        public void TestCalcDistance_1()
        {
            double[] num = { 6, 4, 2 }, num2 = { 3, 2 };
            var vector = new MathVector(num);
            var vect2 = new MathVector(num2);

            Assert.ThrowsException<Exception>(delegate
            {
                var result = vector.CalcDistance(vect2);
            });
        }

        [TestMethod]
        public void TestCalcDistance_2()
        {
            double[] num = { 6, 4, 2 }, num2 = { 3, 2, 4 };
            var vector = new MathVector(num);
            var vect2 = new MathVector(num2);

            double result = 4.1231056;

            double expected = vector.CalcDistance(vect2);

            Assert.AreEqual(expected, result, 0.0000001);
        }

        [TestMethod]
        public void TestOperatorPlusNumber()
        {
            double[] num = { 1, 0, 3, 5 };
            MathVector vector = new MathVector(num);

            double[] res = { 4, 3, 6, 8 };
            var expected = new MathVector(res);

            var result = (MathVector)vector + 3;

            Assert.IsTrue(expected == result);
        }
    }
}
