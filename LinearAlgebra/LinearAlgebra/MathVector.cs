using System;
using System.Collections;

namespace LinearAlgebra
{
	public interface IMathVector : IEnumerable
	{
		/// <summary>
		/// Получить размерность вектора (количество координат).
		/// </summary>
		int Dimensions { get; }

		/// <summary>
		/// Индексатор для доступа к элементам вектора. Нумерация с нуля.
		/// </summary>
		double this[int i] { get; set; }

		/// <summary>Рассчитать длину (модуль) вектора.</summary>
		double Length { get; }

		/// <summary>Покомпонентное сложение с числом.</summary>
		IMathVector SumNumber(double number);

		/// <summary>Покомпонентное умножение на число.</summary>
		IMathVector MultiplyNumber(double number);

		/// <summary>Сложение с другим вектором.</summary>
		IMathVector Sum(IMathVector vector);

		/// <summary>Покомпонентное умножение с другим вектором.</summary>
		IMathVector Multiply(IMathVector vector);

		/// <summary>Скалярное умножение на другой вектор.</summary>
		double ScalarMultiply(IMathVector vector);

		/// <summary>
		/// Вычислить Евклидово расстояние до другого вектора.
		/// </summary>
		double CalcDistance(IMathVector vector);
	}


	/// <summary>
	/// 
	/// </summary>
	public class MathVector : IMathVector
    {
		private double[] points;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="newPoints"></param>
		public MathVector(double[] newPoints)
        {
			this.points = newPoints;
        }

		/// <summary>
		/// </summary>
		/// <param name="vector"></param>
		public MathVector(MathVector vector)
        {
			this.points = vector.points;
        }

		/// <summary>
		/// Получить размерность вектора (количество координат).
		/// </summary>
		public int Dimensions
        {
            get
			{
				return this.points.Length;
            }
        }

		/// <summary>
		/// Индексатор для доступа к элементам вектора. Нумерация с нуля.
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public double this[int i]
		{
            get
            {
				return points[i];
            }
            set
            {
				this.points[i] = value;
            }
		}

		/// <summary>
		/// Рассчитать длину (модуль) вектора.
		/// </summary>
		public double Length 
		{
		get
            {
				double length = 0;
				foreach(double point in this.points)
                {
					length += Math.Pow(point, 2);
                }
				return Math.Sqrt(length);
            } 
		}

		/// <summary>
		/// Покомпонентное сложение с числом.
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public IMathVector SumNumber(double number)
        {
			var newPoints = new double [Dimensions];
			for(int i = 0; i < this.Length; i++)
            {
				newPoints[i] = points[i] + number;
            }
			return new MathVector(newPoints);
        }

		/// <summary>
		/// Покомпонентное умножение на число.
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public IMathVector MultiplyNumber(double number)
        {
			var newPoints = new double[Dimensions];
			for (int i = 0; i < this.Length; i++)
			{
				newPoints[i] = points[i] * number;
			}
			return new MathVector(newPoints);
		}

		/// <summary>
		/// Сложение с другим вектором.
		/// </summary>
		/// <param name="vector"></param>
		/// <returns></returns>
		public IMathVector Sum(IMathVector vector)
        {
			if(vector.Length == this.Length)
            {
				var newPoints = new double[Dimensions];
				for(int i = 0; i < this.Length; i++)
                {
					newPoints[i] = this.points[i] + vector[i];
                }
				return new MathVector(newPoints);
            }
            else
            {
				return null;
            }
		}

		/// <summary>
		/// Покомпонентное умножение с другим вектором.
		/// </summary>
		/// <param name="vector"></param>
		/// <returns>Новый вектор</returns>
		public IMathVector Multiply(IMathVector vector)
        {
			if (vector.Length == this.Length)
			{
				var newPoints = new double[Dimensions];
				for (int i = 0; i < this.Length; i++)
				{
					newPoints[i] = this.points[i] * vector[i];
				}
				return new MathVector(newPoints);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Скалярное умножение на другой вектор.
		/// </summary>
		/// <param name="vector"></param>
		/// <returns></returns>
		public double ScalarMultiply(IMathVector vector)
        {
			if(vector.Length == this.Length)
            {
				double result = 0;
				for(int i = 0; i < this.Length; i++)
                {
					result += vector[i] * this.points[i];
                }
				return result;
            }
            else
            {
				return 0;
            }
        }

		/// <summary>
		/// Вычислить Евклидово расстояние до другого вектора.
		/// </summary>
		/// <param name="vector"></param>
		/// <returns></returns>
		public double CalcDistance(IMathVector vector)
        {
			if (vector.Length == this.Length)
			{
				double result = 0;
				for (int i = 0; i < this.Length; i++)
				{
					result = Math.Pow(vector[i] - this.points[i], 2);
				}
				return Math.Sqrt(result);
			}
			else
			{
				return 0;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public IEnumerator GetEnumerator()
        {
			return this.points.GetEnumerator();
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="number"></param>
		/// <returns></returns>
		public static IMathVector operator +(MathVector vector, double number)
        {
			return vector.SumNumber(number);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="vectorTwo"></param>
		/// <returns></returns>
		public static IMathVector operator +(MathVector vector, MathVector vectorTwo)
		{
			return vector.Sum(vectorTwo);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="vectorTwo"></param>
		/// <returns></returns>
		public static IMathVector operator -(MathVector vector, double number)
		{
			return vector.SumNumber(-number);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="vectorTwo"></param>
		/// <returns></returns>
		public static IMathVector operator -(MathVector vector, MathVector vectorTwo)
		{
			return vector.Sum(vectorTwo.MultiplyNumber(-1));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="number"></param>
		/// <returns></returns>
		public static IMathVector operator *(MathVector vector, double number)
		{
			return vector.MultiplyNumber(number);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="vectorTwo"></param>
		/// <returns></returns>
		public static IMathVector operator *(MathVector vector, MathVector vectorTwo)
		{
			return vector.Multiply(vectorTwo);
		}

		public static double operator %(MathVector vector, MathVector vectorTwo)
		{
			return vector.ScalarMultiply(vectorTwo);
		}
	}
}
