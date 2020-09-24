using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace JenPile {
    class InputCollector {
        private List<string> inputs = new List<string>();
        private string line;

        #region Properties
        public List<string> Inputs {
            get { return this.inputs; }
            set { this.inputs = value; }
        }
        #endregion


        #region Constructors
        public InputCollector() { }
        #endregion

        #region Class Methods

        // This works, creates list of individual words using spaces as a deliminator 
        public void ReadInFile(string fileName) {
            try {
                using (StreamReader streamReader = new StreamReader(@fileName)) {
                    while ((line = streamReader.ReadLine()) != null) {
                        if (line.Length > 0) {
                            inputs.Add(line);
                        }
                    }
                }
            } catch (IOException e) {
                Console.WriteLine("The File could not be read: ");
                Console.WriteLine(e.Message);
            }
        }

        public void ReadInUserInput() {
            Console.WriteLine("Type what you would like compiled, press enter twice to exit:");
            do {
                line = Console.ReadLine();
                if (line.Length == 0) {
                    inputs.Add("\n");
                    break;
                }
                inputs.Add(line);
            }
            while (line != null);
        }
        #endregion
    }
}






