﻿using System;
using System.Collections;
using System.Text;

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
		/// <param name="i">Индекс</param>
		/// <returns>Элемент по индексу</returns>
		double this[int i] { get; set; }

		/// <summary>
		/// Рассчитать длину (модуль) вектора
		/// </summary>
		double Length { get; }

		/// <summary>
		/// Покомпонентное сложение с числом
		/// </summary>
		/// <param name="number">Число</param>
		/// <returns>Новый массив</returns>
		IMathVector SumNumber(double number);

		/// <summary>
		/// Покомпонентное умножение на число
		/// </summary>
		/// <param name="number">Число</param>
		/// <returns>Новый массив</returns>
		IMathVector MultiplyNumber(double number);

		/// <summary>
		/// Сложение с другим вектором
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Новый массив</returns>
		IMathVector Sum(IMathVector vector);

		/// <summary>
		/// Покомпонентное умножение с другим вектором
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Новый массив</returns>
		IMathVector Multiply(IMathVector vector);

		/// <summary>
		/// Скалярное умножение на другой вектор
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Скаляр</returns>
		double ScalarMultiply(IMathVector vector);

		/// <summary>
		/// Вычислить Евклидово расстояние до другого вектора
		/// </summary>
		/// <param name="vector">Вектор</param>
		/// <returns>Расстояние</returns>
		double CalcDistance(IMathVector vector);
	}
}
