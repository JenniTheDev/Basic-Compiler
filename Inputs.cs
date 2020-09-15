using System;
using System.Collections.Generic;
using System.IO;


namespace JenPile {
    class Inputs {

        string userChoice;
        private string fileToRead;

        List<string> inputs = new List<string>();
        List<string> lineList = new List<string>();
        string line;

        public string FileToRead {
            get { return this.fileToRead; }
            set { this.fileToRead = value; }
        }

        // TODO: remove unneeded comments when done with Inputs

      

        // This works

        public Inputs() { }

        public void ProcessInput() {
            foreach(string line in inputs) {
                BreakLineIntoIndividualParts(line);
            }
        }

        

        // This works
        public void UserEnterFileName() {

            Console.WriteLine("Enter the file location");
            fileToRead = Console.ReadLine();
            ReadInFile(@fileToRead);
        }

        // This works, creates list of individual words using spaces as a deliminator 
        public void ReadInFile(string fileName) {
            try {
                using(StreamReader streamReader = new StreamReader(@fileName)) {
                    while((line = streamReader.ReadLine()) != null) {
                        
                        inputs.Add(line);
                        
                    }
                }
            } catch(IOException e) {
                Console.WriteLine("The File could not be read: ");
                Console.WriteLine(e.Message);
            }
        }


        public void BreakLineIntoIndividualParts(string line) {
            if(line[0] != '!') {
                string[] tempLine = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string s in tempLine) {
                    lineList.Add(s);
                }
            }
        }



        public void ReadInUserInput() {
            Console.WriteLine("Type what you would like compiled, press ctrl-z to exit:");
            do {
                line = Console.ReadLine();                
                if(line != null) {    // this is kind of redundent but it makes it not throw a null exception
                    inputs.Add(line);

                    //BreakLineIntoIndividualParts(line);
                }
            } while(line != null);
        }
        public void FormatIntoPiecs() {
            // TODO: make this function  it's own class to format both the user input and the file input into it's parts to be tokenized
        }
    }
}






// until end of file
// or end of user input
// read in all the input into a list and then clean it all up
// entire file should be a giant list 
// 
// list is never cleared if we use another file or input 
// accepts user input until enter is pressed twice 
// don't tightly couple things by passing the same list around
// new class for processing
// input class only for input thats in the main
// 

