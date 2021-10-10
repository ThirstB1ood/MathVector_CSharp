using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebra;

namespace ChartsVisualisation
{
    class UnicueIris
    {
        private List<MathVector> irisesSetosa = new List<MathVector>();
        private List<MathVector> irisesVersicolor = new List<MathVector>();
        private List<MathVector> irisesVirginica = new List<MathVector>();
        public MathVector averageSetosa { get; set; }
        public MathVector averageVersicolor { get; set; }
        public MathVector averageVirginica { get; set; }

        public void DivideIrises(string[] arrayString)
        {
            string[][] data;
            data = arrayString.Select(x => x.Split(',')).ToArray();
            foreach (string[] str in data.Skip(1))
            {
                double[] temp = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    temp[i] = Convert.ToDouble(str[i].Replace('.', ','));
                }
                if (Array.Exists(temp, element => (temp[3] != 0)))
                {
                    MathVector vector = new MathVector(temp);
                    if (str[4] == "setosa")
                        irisesSetosa.Add(vector);
                    else if (str[4] == "versicolor")
                        irisesVersicolor.Add(vector);
                    else if (str[4] == "virginica")
                        irisesVirginica.Add(vector);
                }
            }
            averageSetosa = CreateMathVectors(irisesSetosa);
            averageVersicolor = CreateMathVectors(irisesVersicolor);
            averageVirginica = CreateMathVectors(irisesVirginica);
            int b = 3;
        }

        public MathVector CreateMathVectors(List<MathVector> vectorsIrises)
        {
            double[] temp = new double[vectorsIrises[0].Dimensions];
            double res = 0;
            for(int i = 0; i < vectorsIrises[0].Dimensions; i++)
            {
                for(int j = 0; j < vectorsIrises.Count; j++)
                {
                    res += vectorsIrises[j][i];
                }
                temp[i] = Math.Round(res, 2) / vectorsIrises.Count;
            }
            return new MathVector(temp);
        }
    }
}
