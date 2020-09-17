using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace JenPile {
    class Inputs {


        private string fileToRead;

        // inputs contains each line inputted 
        List<string> inputs = new List<string>();
        List<string> lineList = new List<string>();
        string line;


        public string FileToRead {
            get { return this.fileToRead; }
            set { this.fileToRead = value; }
        }

        public Inputs() { }

        public void ProcessInput() {
            foreach (string line in inputs) {
                // BreakLineIntoIndividualParts(line);
                //BreakLineIntoParts(line);
            }
        }

        // This works, creates list of individual words using spaces as a deliminator 
        public void ReadInFile(string fileName) {
            try {
                using (StreamReader streamReader = new StreamReader(@fileName)) {
                    while ((line = streamReader.ReadLine()) != null) {
                            inputs.Add(line);     
                       // inputs.ForEach(Console.WriteLine);
                    }
                }
            } catch (IOException e) {
                Console.WriteLine("The File could not be read: ");
                Console.WriteLine(e.Message);
            }
        }

        public void ReadInUserInput() {
            Console.WriteLine("Type what you would like compiled, press ctrl-z to exit:");
            do {
                line = Console.ReadLine();
                inputs.Add(line);
            }
            while (line != null);
        }

        // moved to separate class
        //public void BreakLineIntoIndividualParts(string line) {
        //    if (line[0] != '!') {
        //        // string[] tempLine = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        //        string[] tempLine = Regex.Split(line, separators);
        //        foreach (string s in tempLine) {
        //            lineList.Add(s);
        //        }
        //    }
        // }
    }
}







