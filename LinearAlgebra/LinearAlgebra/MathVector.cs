using System;
using System.Collections;

namespace LinearAlgebra
{
	/// <summary>
	/// Класс математического вектора
	/// </summary>
	public class MathVector : IMathVector
    {
		private double[] points;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="newPoints"></param>
		public MathVector(double[] newPoints)
		{ 
			points = new double[newPoints.Length]; 
			for(int i = 0; i < newPoints.Length; i++)
            {
				points[i] = newPoints[i];
            }
        }

		/// <summary>
		/// Конструктор копирования
		/// </summary>
		/// <param name="vector"></param>
		public MathVector(MathVector vector)
        {
			points = new double[vector.Dimensions]; 
			for(int i = 0; i < vector.Dimensions; i++)
            {
				this.points[i] = vector[i];
            }
        }

		/// <summary>
		/// Получить размерность вектора (количество координат).
		/// </summary>
		public int Dimensions
        {
            get
			{
				return points.Length;
            }
        }

		/// <summary>
		/// Индексатор для доступа к элементам вектора. Нумерация с нуля.
		/// </summary>
		/// <param name="i">Индекс</param>
		/// <returns>Значение по индексу</returns>
		public double this[int i]
		{
            get
            {
				if ( i >= Dimensions || i < 0)
				{
					throw new Exception("outside vector");
				}
				return points[i];
            }
            set
			{
				if (i >= Dimensions || i < 0)
				{
					throw new Exception("outside vector");
				}
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
				foreach(double point in points)
                {
					length += Math.Pow(point, 2);
                }
				return Math.Sqrt(length);
            } 
		}

		public double LengthVector(MathVector vector)
        {
			if (this.Dimensions != vector.Dimensions)
			{
				throw new Exception("different lengths");
			}
			double length = 0;
			for (int i = 0; i < Dimensions; i++)
			{
				length += Math.Pow(points[i] - vector[i], 2);
			}
			return Math.Sqrt(length);
		}

		/// <summary>
		/// Покомпонентное сложение с числом.
		/// </summary>
		/// <param name="number">Число</param>
		/// <returns>Новый массив</returns>
		public IMathVector SumNumber(double number)
        {
			if (this.Dimensions == 0)
			{
				throw new Exception("empty vector");
			}
			var newPoints = new double [Dimensions];
			for(int i = 0; i < Dimensions; i++)
            {
				newPoints[i] = points[i] + number;
            }
			return new MathVector(newPoints);
        }

		/// <summary>
		/// Покомпонентное умножение на число.
		/// </summary>
		/// <param name="number">Число</param>
		/// <returns>Новый массив</returns>
		public IMathVector MultiplyNumber(double number)
        {
			if (this.Dimensions == 0)
			{
				throw new Exception("empty vector");
			}
			var newPoints = new double[Dimensions];
			for (int i = 0; i < Dimensions; i++)
			{
				newPoints[i] = points[i] * number;
			}
			return new MathVector(newPoints);
		}

		/// <summary>
		/// Сложение с другим вектором.
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Новый массив</returns>
		public IMathVector Sum(IMathVector vector)
        {
			if (this.Dimensions != vector.Dimensions)
			{
				throw new Exception("different lengths");
			}
			var newPoints = new double[Dimensions];
			for(int i = 0; i < Dimensions; i++)
            {
				newPoints[i] = this.points[i] + vector[i];
            }
			return new MathVector(newPoints);
		}

		/// <summary>
		/// Покомпонентное умножение с другим вектором.
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Новый вектор</returns>
		public IMathVector Multiply(IMathVector vector)
        {
			if (this.Dimensions != vector.Dimensions)
			{
				throw new Exception("different lengths");
			}
			var newPoints = new double[Dimensions];
			for (int i = 0; i < Dimensions; i++)
			{
				newPoints[i] = points[i] * vector[i];
			}
			return new MathVector(newPoints);
		}

		/// <summary>
		/// Покомпонентное деление с другим вектором.
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Новый массив</returns>
		public IMathVector Divide(IMathVector vector)
		{
			if (this.Dimensions != vector.Dimensions)
			{
				throw new Exception("different lengths");
			}
			var newPoints = new double[Dimensions];
			for (int i = 0; i < Dimensions; i++)
			{
				newPoints[i] = points[i] / vector[i];
				if (vector[i] == 0)
				{
					throw new Exception("divide By Zero");
				}
			}
			return new MathVector(newPoints);
		}

		/// <summary>
		/// Покомпонентное деление с числом.
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Новый массив</returns>
		public IMathVector DivideNumber(double number)
		{
			var newPoints = new double[Dimensions];
			if (this.Dimensions == 0)
			{
				throw new Exception("empty vector");
			}
			for (int i = 0; i < Dimensions; i++)
			{
				newPoints[i] = points[i] / number;
			}
			if (number == 0)
			{
				throw new Exception("divide By Zero");
			}
			return new MathVector(newPoints);
		}

		/// <summary>
		/// Скалярное умножение на другой вектор.
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Новый массив</returns>
		public double ScalarMultiply(IMathVector vector)
        {
			if (this.Dimensions != vector.Dimensions)
			{
				throw new Exception("different lengths");
			}
			double result = 0;
			for(int i = 0; i <  Dimensions; i++)
            {
				result += vector[i] * points[i];
            }
			return result;
        }

		/// <summary>
		/// Вычислить Евклидово расстояние до другого вектора.
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Расстояние</returns>
		public double CalcDistance(IMathVector vector)
        {
			if (this.Dimensions != vector.Dimensions)
			{
				throw new Exception("different lengths");
			}
			double result = 0;
			for (int i = 0; i < Dimensions; i++)
			{
                result += Math.Pow(vector[i] - points[i], 2);
			}
			return Math.Sqrt(result);
		}

		/// <summary>
		/// Возврат перечислителя
		/// </summary>
		/// <returns>Перечислитель</returns>
        public IEnumerator GetEnumerator()
        {
			return this.points.GetEnumerator();
        }

		/// <summary>
		/// Перегрузка оператора + для числа
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <param name="number">Число</param>
		/// <returns>Новый массив</returns>
		public static IMathVector operator +(MathVector vector, double number)
        {
			return vector.SumNumber(number);
        }

		/// <summary>
		/// Перегрузка оператора + для векторов
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <param name="vectorTwo">Вектор</param>
		/// <returns>Новый массив</returns>
		public static IMathVector operator +(MathVector vector, MathVector vectorTwo)
		{
			return vector.Sum(vectorTwo);
		}

		/// <summary>
		/// Перегрузка оператора - для числа
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <param name="number">Число</param>
		/// <returns>Новый массив</returns>
		public static IMathVector operator -(MathVector vector, double number)
		{
			return vector.SumNumber(-number);
		}

		/// <summary>
		/// Перегрузка опретаора - для векторов
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="vectorTwo"></param>
		/// <returns>Новый массив</returns>
		public static IMathVector operator -(MathVector vector, MathVector vectorTwo)
		{
			return vector.Sum(vectorTwo.MultiplyNumber(-1));
		}

		/// <summary>
		/// Перегрузка оператора * для числа
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <param name="number">Число</param>
		/// <returns>Новый массив</returns>
		public static IMathVector operator *(MathVector vector, double number)
		{
			return vector.MultiplyNumber(number);
		}

		/// <summary>
		/// Перегрузка оператора * для векторов
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <param name="vectorTwo">Вектор</param>
		/// <returns>Новый массив</returns>
		public static IMathVector operator *(MathVector vector, MathVector vectorTwo)
		{
			return vector.Multiply(vectorTwo);
		}

		/// <summary>
		/// Перегрузка оператора / для числа
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <param name="number">Число</param>
		/// <returns>Новый массив</returns>
		public static IMathVector operator /(MathVector vector, double number)
		{
			return vector.DivideNumber(number);
		}

		/// <summary>
		/// Перегрузка оператора / для векторов
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <param name="vectorTwo">Вектор</param>
		/// <returns>Новый массив</returns>
		public static IMathVector operator /(MathVector vector, MathVector vectorTwo)
		{
			return vector.Divide(vectorTwo);
		}

		/// <summary>
		/// Перегрузка оператора %
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <param name="vectorTwo">Вектор</param>
		/// <returns>Новый массив</returns>
		public static double operator %(MathVector vector, MathVector vectorTwo)
		{
			return vector.ScalarMultiply(vectorTwo);
		}

		/// <summary>
		/// Перегрузка оператора сравнение ==
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <param name="vectorTwo">Вектор</param>
		/// <returns>true, если равны, иначе false</returns>
		public static bool operator ==(MathVector vector, MathVector vectorTwo)
        {
			bool flag = true;
			if (vector.Dimensions != vectorTwo.Dimensions)
			{
				flag = true;
			}
			else
			{
				for (int i = 0; i < vector.Dimensions; i++)
				{
					if (vector[i] != vectorTwo[i])
					{
						flag = false;
						break;
					}
				}
			}
			return flag;
		}

		/// <summary>
		/// Перегрузка оператора сравнение !=
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <param name="vectorTwo">Вектор</param>
		/// <returns>true, если неравны, иначе false</returns>
		public static bool operator !=(MathVector vector, MathVector vectorTwo)
        {
			bool flag = false;
			if(vector.Dimensions != vectorTwo.Dimensions)
            {
				flag = true;
            }
            else
            {
				for(int i = 0; i < vector.Dimensions; i++)
                {
					if(vector[i] != vectorTwo[i])
                    {
						flag = true;
						break;
                    }
                }
            }
			return flag;
        }

		/// <summary>
		/// Перегрузка вывода
		/// </summary>
		/// <returns>Вектор</returns>
		public override string ToString()
		{
			string res = "";
			foreach (double point in this) 
            {
				res += " " + point.ToString();
            }
			return res;
		}
	}
}
