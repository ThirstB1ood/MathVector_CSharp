using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LinearAlgebra;

namespace ChartsVisualisation
{
    class BusinessLogic
    {
        private string fileName;
        private string[] arrayStrings;
        private UnicueIris irises = new UnicueIris();
        public string _fileName
        {
            set => fileName = value;
            get => fileName;
        }

        public BusinessLogic()
        {
            fileName = "";
        }

        public void ReadFile()
        {
            if (fileName == "")
                throw new FileNotFoundException();

            arrayStrings = File.ReadAllLines(fileName);
            irises.DivideIrises(arrayStrings);
        }

        public MathVector GetAverageVector(string name)
        {
            MathVector vector = new MathVector(new double[] { 0 });
            switch (name)
            {
                case "Setosa":
                    vector = new MathVector(irises.averageSetosa);
                    break;
                case "Versicolor":
                    vector = new MathVector(irises.averageVersicolor);
                    break;
                case "Virginica":
                    vector = new MathVector(irises.averageVirginica);
                    break;
            }
            return vector;
        }

        public double length(string name)
        {
            double length = 0;
            switch (name) 
            {
                case "Setosa and Versicolor":
                    length = irises.averageSetosa.CalcDistance(irises.averageVersicolor);
                    break;
                case "Versicolor and Virginica":
                    length = irises.averageVersicolor.CalcDistance(irises.averageVirginica);
                    break;
                case "Setosa and Virginica":
                    length = irises.averageSetosa.CalcDistance(irises.averageVirginica);
                    break;
            }
            return length;
        }
    }
}
