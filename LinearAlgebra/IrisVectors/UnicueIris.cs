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
        List<MathVector> irisesSetosa = new List<MathVector>();
        List<MathVector> irisesVersicolor = new List<MathVector>();
        List<MathVector> irisesVirginica = new List<MathVector>();

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
        }
    }
}
