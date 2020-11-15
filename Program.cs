﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JenPile {
    class Program {
        static void Main(string[] args) {
            string fileToCompile = null;

            for (int i = 0; i < args.Length; i++) {
                if ((args[i] == "-c") && (i + 1 < args.Length) && (args[i + 1] != null)) {
                    // Example: CSUF323_Compiler.exe -c HelloWorld.jen 
                    fileToCompile = args[i + 1];
                }
            }

            InputCollector input = new InputCollector();
            Lexer lex = new Lexer();
            // Rules for Syntax
            // First pass is expressions
            Expression expression = new Expression();

            if (fileToCompile != null) {
                input.ReadInFile(fileToCompile);
            } else {
                input.ReadInUserInput();
            }

            lex.LexInput(input.Inputs);

            //TODO: Remove. For Demoing
            lex.PrintTokens(lex.LexInput(input.Inputs));

            // TODO: Is passing the list of token & value pairs? 
            expression.Driver(lex.LexInput(input.Inputs));


           

           

            

            
        }
    }
}
