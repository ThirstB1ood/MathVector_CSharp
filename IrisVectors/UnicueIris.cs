using System;
using System.Collections.Generic;
using LinearAlgebra;

namespace ChartsVisualisation
{
    public class UnicueIris
    {
        private List<List<MathVector>> irises = new List<List<MathVector>>();

        public MathVector AverageSetosa { get; set; }
        public MathVector AverageVersicolor { get; set; }
        public MathVector AverageVirginica { get; set; }

        public void DivideIrises(string fileName)
        {
            var readerFile = new ReaderFile(fileName);
            irises = readerFile.DivideIrises();

            AverageSetosa = CreateAverageMathVectors(irises[0]);
            AverageVersicolor = CreateAverageMathVectors(irises[1]);
            AverageVirginica = CreateAverageMathVectors(irises[2]);
        }

        public MathVector CreateAverageMathVectors(List<MathVector> vectorsIrises)
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
