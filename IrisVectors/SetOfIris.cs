using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebra;

namespace ChartsVisualisation
{
    class SetOfIris
    {
        public MathVector avgSetosa;
        public MathVector avgVersicolor;
        public MathVector avgVirginica;

        public void GetData(string[] fileStr)
        {
            
            avgSetosa = CreateMathVectors(irisesSetosa);
            avgVersicolor = CreateMathVectors(irisesVersicolor);
            avgVirginica = CreateMathVectors(irisesVirginica);
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
