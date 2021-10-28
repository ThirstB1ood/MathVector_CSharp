using LinearAlgebra;
using System;
using System.Collections.Generic;

namespace Iris
{
    class IrisData
    {
        public MathVector avgSetosa;
        public MathVector avgVersicolor;
        public MathVector avgVirginica;

        public void SetAvgIris(string[] fileStr)
        {
            FileReader reader = new FileReader();
            Dictionary<string, List<MathVector>> irises = reader.GetIrises(fileStr);
            avgSetosa = CreateMathVectors(irises["Setosa"]);
            avgVersicolor = CreateMathVectors(irises["Versicolor"]);
            avgVirginica = CreateMathVectors(irises["Virginica"]);
        }

        public MathVector CreateMathVectors(List<MathVector> vectorsIrises)
        {
            double[] temp = new double[vectorsIrises[0].Dimensions];
            for(int i = 0; i < vectorsIrises[0].Dimensions; i++)
            {
                double res = 0;
                for (int j = 0; j < vectorsIrises.Count; j++)
                {
                    res += vectorsIrises[j][i];
                }
                temp[i] = Math.Round(res, 2) / vectorsIrises.Count;
            }
            return new MathVector(temp);
        }
    }
}
