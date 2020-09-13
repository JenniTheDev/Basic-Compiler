using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace CompilerProject {
    class Inputs : Program {

        string userChoice;
        string fileToRead;
       // string[] lines;
        string line;

        // TODO: remove unneeded comments when done with Inputs

        // This works
        public void ChooseInputFromFileOrUser() {
            Console.WriteLine("Compile from File or User Input?");
            Console.WriteLine("Choose File or User: ");
            userChoice = Console.ReadLine();

            try {
                if (userChoice == "File" || userChoice == "file") {
                    UserEnterFileName();
                } 
                if (userChoice == "User" || userChoice == "user") {

                    // TODO: write function to get user input
                    Console.WriteLine("User selected");
                }
            }
            catch (IOException e) {
                Console.WriteLine("Wrong Selection");
            }
        }

        // This works
        public void UserEnterFileName() {

            Console.WriteLine("Enter the file location");
            fileToRead = Console.ReadLine();
           // Console.WriteLine(fileToRead);
            ReadInFile(@fileToRead);
        }

        //This works as it is
        public void ReadInFile(string fileName) {

            try {
                using (var lines = new StreamReader(fileName)) {
                    Console.WriteLine(lines.ReadToEnd());
                }
            }
            catch (IOException e) {
                Console.WriteLine("The File could not be read: ");
                Console.WriteLine(e.Message);
            }
        }

        public void FormatIntoPiecs() {
            // TODO: make this function format both the user input and the file input into it's parts to be tokenized
        }

    }
}
