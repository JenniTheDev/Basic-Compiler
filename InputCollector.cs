using System;
using System.Collections.Generic;
using System.IO;
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
        public InputCollector() {

        }
        #endregion

        #region Class Methods
        public void ReadInFile(string fileName) {
            try {
                using (StreamReader streamReader = new StreamReader(@fileName)) {
                    while ((line = streamReader.ReadLine()) != null) {
                            inputs.Add(line);      
                    }
                }
            } catch (IOException e) {
                Console.WriteLine("The File could not be read: ");
                Console.WriteLine(e.Message);
            }
        }

        public void ReadInUserInput() {
            Console.WriteLine("Type what you would like compiled, press enter twice when finished:");
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







