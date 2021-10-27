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
            //checkArray(data);
            foreach (string[] str in data.Skip(1))
            {
                double[] temp = new double[data[0].Length - 1];
                for (int i = 0; i < 4; i++)
                {
                    if(!Double.TryParse(str[i].Replace('.', ','), out temp[i]))
                    {
                        throw new Exception("Wrong number");
                    }
                }
                if (Array.Exists(temp, element => (temp[3] != 0)))
                {
                    MathVector vector = new MathVector(temp);
                    switch (str[4])
                    {
                        case "setosa":
                            irisesSetosa.Add(vector);
                            break;
                        case "versicolor":
                            irisesVersicolor.Add(vector);
                            break;
                        case "virginica":
                            irisesVirginica.Add(vector);
                            break;
                        default:
                            throw new Exception("Unknown name iris");
                    }
                }
            }
            checkArray(data);
            averageSetosa = CreateMathVectors(irisesSetosa);
            averageVersicolor = CreateMathVectors(irisesVersicolor);
            averageVirginica = CreateMathVectors(irisesVirginica);
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

        private void checkArray(string[][] data)
        {
            HashSet<string> set = new HashSet<string>();
            foreach(string[] str in data.Skip(1))
            {
                set.Add(str[4]);
            }
            if(set.Count != 3)
            {
                if(set.Count == 0)
                {
                    throw new Exception("Not irises");
                } else
                {
                    throw new Exception("Count irises not 3");
                }
            }
        }

        public void clear()
        {
            irisesSetosa.Clear();
            irisesVersicolor.Clear();   
            irisesVirginica.Clear();
        }
    }
}
