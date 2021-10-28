using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebra;


namespace IrisVectors
{
    class FileReader
    {
        private List<MathVector> irisesSetosa = new List<MathVector>();
        private List<MathVector> irisesVersicolor = new List<MathVector>();
        private List<MathVector> irisesVirginica = new List<MathVector>();

        private void CheckArray(string[][] data)
        {
            HashSet<string> set = new HashSet<string>();
            bool flag = false;
            foreach (string[] str in data.Skip(1))
            {
                set.Add(str[4]);
                if (set.Count == 3)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                throw new Exception("Count of irises not 3");
            }
        }

        public Dictionary<string, List<MathVector>> GetData(string[] fileStr)
        {
            string[][] data;
            data = fileStr.Select(x => x.Split(',')).ToArray();
            foreach (string[] str in data.Skip(1))  // Рассматривает файл без заголовков
            {
                double[] temp = new double[data[0].Length - 1];
                for (int i = 0; i < 4; i++)
                {
                    if (!Double.TryParse(str[i].Replace('.', ','), out temp[i]))
                    {
                        throw new Exception("Wrong number");
                    }
                }
                if (Array.Exists(temp, element => (temp[3] != 0)))
                {
                    MathVector vector = new MathVector(temp);
                    string type = str[4];
                    if (type == "setosa")
                    {
                        irisesSetosa.Add(vector);
                    }
                    else if (type == "versicolor")
                    {
                        irisesVersicolor.Add(vector);
                    }
                    else if (type == "virginica")
                    {
                        irisesVirginica.Add(vector);
                    }
                    else
                    {
                        throw new Exception("Unknown name iris");
                    }
                }
            }
            CheckArray(data);
            Dictionary<string, List<MathVector>> res = new Dictionary<string, List<MathVector>>(3);
            res.Add("Setosa", irisesSetosa);
            res.Add("Virginica", irisesVirginica);
            res.Add("Versicolor", irisesVersicolor);
            return res;
        }
        public void СlearData()
        {
            irisesSetosa.Clear();
            irisesVersicolor.Clear();
            irisesVirginica.Clear();
        }
    }
}
