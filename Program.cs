using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JenPile {
    class Program {
        static void Main(string[] args) {
            string fileToCompile = null;

            for (int i = 0; i < args.Length; i++) {
                if ((args[i] == "-c") && (i + 1 < args.Length) && (args[i + 1] != null)) {
                    // Example: CSUF323_Compiler.exe -c helloworld.jen 
                    fileToCompile = args[i + 1];
                }
            }

            InputCollector input = new InputCollector();
            Lexer lex = new Lexer();

            if (fileToCompile != null) {
                input.ReadInFile(fileToCompile);
            } else {
                input.ReadInUserInput();
            }

            lex.LexInput(input.Inputs);

            //TODO: Remove. For Demoing
            lex.PrintTokens(lex.LexInput(input.Inputs));

           

            //TODO: FSM

            //TODO: Outputs
        }
    }
}
