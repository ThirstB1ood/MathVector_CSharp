using System;
using System.Collections.Generic;
using System.Linq;
using LinearAlgebra;
using System.IO;

namespace ChartsVisualisation
{
    public class ReaderFile
    {
        private readonly List<List<MathVector>> irises = new List<List<MathVector>>();
        private readonly string fileName;
        /// <summary>
        /// size in bytes
        /// </summary>
        private readonly int sizeFile = 10000;
        private readonly int countValues = 4;

        public ReaderFile(string filename)
        {
            this.fileName = filename;
        }

        public List<List<MathVector>> DivideIrises()
        {
            CheckFile();
            string[] arrayStrings = File.ReadAllLines(fileName);
            var irisesSetosa = new List<MathVector>();
            var irisesVersicolor = new List<MathVector>();
            var irisesVirginica = new List<MathVector>();

            CheckStrings(arrayStrings);

            string[][] data;
            data = arrayStrings.Select(x => x.Split(',')).ToArray();

            foreach (string[] str in data.Skip(1))
            {
                double[] temp = new double[data[0].Length - 1];
                temp = CheckValue(str, data[0].Length - 1);

                MathVector vector = new MathVector(temp);
                switch (str[countValues])
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

            CheckArray(data);

            irises.Add(irisesSetosa);
            irises.Add(irisesVersicolor);
            irises.Add(irisesVirginica);

            return irises;
        }

        private double[] CheckValue(string[] str, int length)
        {
            double[] temp = new double[length];
            for (int i = 0; i < countValues; i++)
            {
                if (string.IsNullOrEmpty(str[i]))
                {
                    throw new Exception("Empty number in file");
                }
                if (!Double.TryParse(str[i].Replace('.', ','), out temp[i]))
                {
                    throw new Exception("Wrong number");
                }
            }
            return temp;
        }

        private void CheckArray(string[][] data)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (string[] str in data.Skip(1))
            {
                set.Add(str[countValues]);
            }
            if (set.Count != 3)
            {
                if (set.Count == 0)
                {
                    throw new Exception("Not irises");
                }
                else
                {
                    throw new Exception("Count irises not 3");
                }
            }
        }

        private void CheckStrings(string[] arrayString)
        {
            foreach (string str in arrayString)
            {
                if (string.IsNullOrEmpty(str))
                {
                    throw new Exception("Empty string in file");
                }
                else if (!str.Contains(','))
                {
                    throw new Exception("Error file");
                }
            }
        }

        private void CheckFile()
        {
            FileInfo file = new FileInfo(fileName);
            if (fileName == "")
            {
                throw new FileNotFoundException();
            } 
            else if (file.Length == 0)
            {
                throw new Exception("Empty file");
            } 
            else if (!file.Exists)
            {
                throw new Exception("File not exists");
            } 
            else if (file.Length > sizeFile)
            {
                throw new Exception("Size too large");
            }
        }
    }
}
