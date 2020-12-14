using System;
using System.Collections.Generic;

namespace JenPile {
    internal class Parser {

        // toggles printing rules on and off
        private bool printRules = true;

        //private bool check = false;
        private List<Token> theStack = new List<Token>();

        private Token endOfFile = new Token(TokenType.ENDOFFILE, "%");
        private SymbolTable symbolTbl = new SymbolTable();

        #region Constructor

        public Parser() {
        }

        #endregion Constructor

        #region Class Methods

        public void Driver(List<Token> tokenizedInput) {
            tokenizedInput.Add(endOfFile); // Add End Of String to input string
            foreach (Token input in tokenizedInput) {
                Token tokenToParse = input;
                if (tokenToParse.Value != " ") {
                    Shift(tokenToParse);
                    if (tokenToParse.Type == TokenType.IDENTIFIER) {
                        CheckSymbolTable();
                    }
                    
                    Reduce();
                }
            }
            Console.WriteLine("Symbol Table: ");
            symbolTbl.PrintSymbolTable();
        }

        private void CheckSymbolTable() {
            if (theStack.Count > 1) {
                for (int i = 1; i < theStack.Count; i++) {
                    if (theStack[i].Type == TokenType.IDENTIFIER) {
                        if (theStack[i-1].Type == TokenType.KEYWORD) {
                            if (theStack[i-1].Value == "int") {
                                symbolTbl.AddToTable(new Symbol(SymbolType.INTEGER, theStack[i].Value));
                            } else if (theStack[i - 1].Value == "float") {
                                symbolTbl.AddToTable(new Symbol(SymbolType.FLOAT, theStack[i].Value));
                            }
                        
                        }
                    }
                }
            }
        }

        // This method moves tokens from the input buffer tokenized Input onto the stack
        private void Shift(Token currentToken) {
            // Printing to be like example
            Console.WriteLine($"{currentToken.Type} = {currentToken.Value}");
            theStack.Add(currentToken);
        }

        // If there is a match (true), replace the token with the production rule
        private void Reduce() {
            CheckForExpression();
            CheckForAssignment();
            CheckForStatement();
        }

        private void CheckForExpression() {
            Token expressionReduction = new Token(TokenType.EXPRESSION, "expression");
            Console.WriteLine("Calling ExpressCheck");

            for (int i = 0; i < theStack.Count; i++) {
                if (theStack[i].Type == TokenType.IDENTIFIER) {
                    if (i < theStack.Count - 1 && theStack[i + 1].Type == TokenType.OPERATOR && theStack[i + 1].Value != "=") {
                        if (i < theStack.Count - 2 && theStack[i + 2].Type == TokenType.IDENTIFIER) {
                            theStack.RemoveAt(i);
                            theStack.Insert(i, expressionReduction);
                            theStack.RemoveAt(i + 1);
                            theStack.RemoveAt(i + 1);
                            PrintRule(1);
                            PrintRule(2);
                        }
                    }
                }
            }
        }

        private void CheckForAssignment() {
            Token assignmentReduction = new Token(TokenType.ASSIGNMENT, "assignment");
            Console.WriteLine("Calling Assign Check");
            // check stack for keyword id = expression then replace w/ assignment
            // check stack for id = expression then replace w/ assignment
            if (theStack.Count > 3) {
                if (theStack[0].Type == TokenType.IDENTIFIER && theStack[1].Value == "=") {
                    if (theStack[2].Type == TokenType.EXPRESSION || theStack[2].Type == TokenType.FLOAT || theStack[2].Type == TokenType.INTEGER || theStack[2].Type == TokenType.IDENTIFIER) {
                        theStack.RemoveAt(0);
                        theStack.Insert(0, assignmentReduction);
                        theStack.RemoveAt(1);
                        theStack.RemoveAt(1);
                        PrintRule(5);
                    }
                }
            } else if (theStack.Count > 4) {
                if (theStack[0].Type == TokenType.KEYWORD && theStack[1].Type == TokenType.IDENTIFIER && theStack[2].Value == "=") {
                    if (theStack[3].Type == TokenType.EXPRESSION || theStack[3].Type == TokenType.FLOAT || theStack[3].Type == TokenType.INTEGER || theStack[3].Type == TokenType.IDENTIFIER) {
                        //if (theStack[0].Value == "int") {
                        //    symbolTbl.AddToTable(new Symbol(SymbolType.INTEGER, theStack[1].Value));
                        //} else if (theStack[0].Value == "float") {
                        //    symbolTbl.AddToTable(new Symbol(SymbolType.FLOAT, theStack[1].Value));
                        //}
                        theStack.RemoveAt(0);
                        theStack.Insert(0, assignmentReduction);
                        theStack.RemoveAt(1);
                        theStack.RemoveAt(1);
                        PrintRule(5);
                    }
                }
            }
        }

        private void Function() {
            // repeats through everything until end of file
            // read a token, is it expression,
            // pop statements, say sucessfully parsed for now
            // in future would use statements with loops and if else
        }

        private void CheckForStatement() {
            // statements should always have a ; at the end
            // declarative ;
            // check for Assign then ;
            // expression ;
            // would eventually handle if, while, do
            if (theStack.Count > 2) {
                for (int i = 0; i < theStack.Count - 1; i++) {
                    if (theStack[i].Type == TokenType.ASSIGNMENT || theStack[i].Type == TokenType.EXPRESSION) {
                        if (theStack[i + 1].Value == ";") {
                            PrintRule(6);
                        }
                    }
                }
            }
        }

        private void Declaritive() {
            // a keyword and an id

            // optional keyword id , id , id (recursive to add unlimited id's with commas, no ending comma ?)
        }

        private void Error() {
            Console.WriteLine("error");
        }

        private void PrintRule(int ruleNumber) {
            if (printRules) {
                switch (ruleNumber) {
                    case 1:
                        Console.WriteLine("<Expression> -> <Identifier> | <float> | <Integer>");
                        break;

                    case 2:
                        // id operator id
                        Console.WriteLine("<Expression> -> <Identifier> <Operator> <Identifier> ");
                        break;

                    case 3:
                        // expression operator id
                        Console.WriteLine("<Expression> -> <Operator> <Identifier> | <Operator> <Expression> ");
                        break;

                    case 4:
                        //// separator expression separator to simplify for now  (expression)
                        Console.WriteLine("<Expression> -> <Seperator> <Expression> <Seperator>");
                        break;

                    case 5:
                        Console.WriteLine("<Assignment> -> <Identifier> = <Expression>");
                        break;

                    case 6:
                        Console.WriteLine("<Statement> -> <Assignment> ;");
                        break;

                    case 7:
                        Console.WriteLine("<Declaration> -> <Keyword> <Identifier> | <Keyword> <Identifier> , <Identifier>");
                        break;

                    default:
                        Console.WriteLine("Error - No valid rule to use");
                        break;
                }
            }
        }

        #endregion Class Methods
    }
}