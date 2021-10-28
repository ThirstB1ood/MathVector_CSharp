using System.IO;
using LinearAlgebra;

namespace ChartsVisualisation
{
    public class BusinessLogic
    {
        private readonly UnicueIris irises = new UnicueIris();

        public void ReadFile(string fileName)
        {
            irises.DivideIrises(fileName);
        }

        public MathVector GetAverageVector(string name)
        {
            MathVector vector = new MathVector(new double[] { 0 });
            switch (name)
            {
                case "Setosa":
                    vector = new MathVector(irises.AverageSetosa);
                    break;
                case "Versicolor":
                    vector = new MathVector(irises.AverageVersicolor);
                    break;
                case "Virginica":
                    vector = new MathVector(irises.AverageVirginica);
                    break;
            }
            return vector;
        }

        public double Length(string name)
        {
            double length = 0;
            switch (name) 
            {
                case "Setosa and Versicolor":
                    length = irises.AverageSetosa.CalcDistance(irises.AverageVersicolor);
                    break;
                case "Versicolor and Virginica":
                    length = irises.AverageVersicolor.CalcDistance(irises.AverageVirginica);
                    break;
                case "Setosa and Virginica":
                    length = irises.AverageSetosa.CalcDistance(irises.AverageVirginica);
                    break;
            }
            return length;
        }
    }
}
