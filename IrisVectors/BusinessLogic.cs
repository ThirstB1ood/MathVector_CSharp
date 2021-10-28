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
        private SetOfIris irises = new SetOfIris();
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

            irises.СlearData();
            arrayStrings = File.ReadAllLines(fileName);
            irises.GetData(arrayStrings);
        }

        public MathVector GetAverageVector(string name)
        {
            MathVector vector = new MathVector(new double[] { 0 });
            switch (name)
            {
                case "Setosa":
                    vector = new MathVector(irises.avgSetosa);
                    break;
                case "Versicolor":
                    vector = new MathVector(irises.avgVersicolor);
                    break;
                case "Virginica":
                    vector = new MathVector(irises.avgVirginica);
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
                    length = irises.avgSetosa.CalcDistance(irises.avgVersicolor);
                    break;
                case "Versicolor and Virginica":
                    length = irises.avgVersicolor.CalcDistance(irises.avgVirginica);
                    break;
                case "Setosa and Virginica":
                    length = irises.avgSetosa.CalcDistance(irises.avgVirginica);
                    break;
                default:
                    throw new Exception("Not Irises");
            }
            return length;
        }
    }
}
