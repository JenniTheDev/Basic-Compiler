using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace CompilerProject {
    class Inputs : Program {

        string userChoice;
        string fileToRead;
        List<string> lineList = new List<string>();
        string line;

        // TODO: remove unneeded comments when done with Inputs

        // This works
        public void ChooseInputFromFileOrUser() {
            Console.WriteLine("Compile from File or User Input?");
            Console.WriteLine("Choose File or User: ");
            userChoice = Console.ReadLine();

            if (userChoice == "File" || userChoice == "file") {
                UserEnterFileName();
                return;
            }
            if (userChoice == "User" || userChoice == "user") {
                ReadInUserInput();
                return;
            } else {
                Console.WriteLine("That didn't work, Let's try again: ");
                ChooseInputFromFileOrUser();
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
                using (StreamReader streamReader = new StreamReader(@fileName)) {
                    while ((line = streamReader.ReadLine()) != null) {
                        // For now, moved this to it's own function
                        // if I add a line, and add to lineList, is lineList passed by reference? I am pretty sure it is

                        BreakLineIntoIndividualParts(line);
                        //if (line[0] != '!') {
                        //    string[] tempLine = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        //    foreach (string s in tempLine) {
                        //        lineList.Add(s);
                        //    }
                       // }
                    }
                }
            } catch (IOException e) {
                Console.WriteLine("The File could not be read: ");
                Console.WriteLine(e.Message);
            }
        }


        public void BreakLineIntoIndividualParts(string line) {
            if (line[0] != '!') {
                string[] tempLine = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in tempLine) {
                    lineList.Add(s);
                }
            }
        }



        public void ReadInUserInput() {
            Console.WriteLine("Type what you would like compiled, press ctrl-z to exit:");
            do {
                line = Console.ReadLine();
                if (line != null) {    // this is kind of redundent but it makes it not throw a null exception
                    BreakLineIntoIndividualParts(line);
                }
            } while (line != null);
        }

        public void FormatIntoPiecs() {
            // TODO: make this function format both the user input and the file input into it's parts to be tokenized
        }
    }
}






