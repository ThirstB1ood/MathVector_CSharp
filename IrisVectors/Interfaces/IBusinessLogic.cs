using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebra;

namespace Iris
{
    interface IBusinessLogic
    {
        /// <summary>
        /// Name CSV file
        /// </summary>
        string _fileName{ set; get; }
        /// <summary>
        /// Reading file CSV, processes strings into a two-dimensional array. Process average irises.
        /// </summary>
        void ReadFile();
        /// <summary>
        /// Return average iris vector
        /// </summary>
        /// <param name="name">Type of Iris</param>
        /// <returns></returns>
        MathVector GetAverageVector(string name);
        /// <summary>
        /// Get distance between irises
        /// </summary>
        /// <param name="name">Type of Iris</param>
        /// <returns></returns>
        double Distance(string name);
    }
}
