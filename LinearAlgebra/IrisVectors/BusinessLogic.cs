using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChartsVisualisation
{
    class BusinessLogic: UnicueIris
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
    }
}
