using LinearAlgebra;
using System;
using System.IO;

namespace Iris
{
    class BusinessLogic : IBusinessLogic
    {
        private string fileName;
        private string[] arrayStrings;
        private IrisData irises = new IrisData();
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
            irises.SetAvgIris(arrayStrings);
        }

        public MathVector GetAverageVector(string name)
        {
            MathVector vector = new MathVector(new double[] { 0 });
            if (name == "Setosa")
            {
                vector = new MathVector(irises.avgSetosa);
            }  else if (name == "Versicolor")
            {
                vector = new MathVector(irises.avgVersicolor);
            } else if (name == "Virginica")
            {
                vector = new MathVector(irises.avgVirginica);
            }
            return vector;
        }

        public double Distance(string name)
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
