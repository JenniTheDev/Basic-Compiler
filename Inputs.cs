using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

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
                // TODO: write method to input & save user input
                Console.WriteLine("User selected");
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


        public void ReadInFile(string fileName) {
            try {
                using (StreamReader streamReader = new StreamReader(@fileName)) {
                    while ((line = streamReader.ReadLine()) != null)
                        if (line[0] != '!') {
                            lineList.Add(line);
                            // remove when done testing stuff
                            Console.WriteLine(line);
                        }
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




// TODO: make function that take a line and makes it into a list of broken up words
// List of words function can be used for both of the inputs

