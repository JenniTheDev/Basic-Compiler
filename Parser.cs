using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JenPile {
    class Parser {
        // toggles printing rules on and off
        private bool printRules = true;
        private bool check = false;
        List<Token> theStack = new List<Token>();
        Token endOfFile = new Token(TokenType.ENDOFFILE, "%");

        #region Properties

        #endregion

        #region Constructor
        public Parser() { }
        #endregion

        #region Class Methods

        public void Driver(List<Token> tokenizedInput) {
            Console.WriteLine("Calling driver");
            theStack.Add(endOfFile); // Push End of File marker
            tokenizedInput.Add(endOfFile); // Add End Of String to input string
            foreach (Token input in tokenizedInput) {
                Token tokenToParse = input;
                if (tokenToParse.Value != " ") {
                    Shift(tokenToParse);
                    Reduce();
                }
            }

        }

        // This method moves tokens from the input buffer tokenized Input onto the stack
        private void Shift(Token currentToken) {
            // Remove this after testing
            Console.WriteLine($"{currentToken.Type} = {currentToken.Value}");
            theStack.Add(currentToken);
        }

        // If there is a match (true), replace the token with the production rule 
        private void Reduce() {
            CheckForExpression(check);
            CheckForAssignment();
        }

        private void CheckForExpression(bool check) {
            // only a int
            // only a float
            // only an id
            Token expressionReduction = new Token(TokenType.EXPRESSION, "expression");

            for (int i = 0; i < theStack.Count; i++) {
                if (theStack[i].Type == TokenType.IDENTIFIER) {
                    Console.WriteLine("expression rule"); 
                    theStack.RemoveAt(i);
                    theStack.Add(expressionReduction);
                }  if (theStack.Count > 2 && theStack[i].Type == TokenType.EXPRESSION && theStack[i-1].Type == TokenType.OPERATOR && theStack[i-2].Type == TokenType.EXPRESSION) {
                    theStack.RemoveAt(i);
                    theStack.RemoveAt(i-1);
                    theStack.RemoveAt(i - 2);
                    theStack.Add(expressionReduction);
                    Console.WriteLine("expression rule long");
                }


                //if (theStack.[i].Type == TokenType.IDENTIFIER) {

                //    if (printRules) {
                //        // Rule- An expression can be an identifier, a float or an integer by itself. 
                //        Console.WriteLine("<Expression> -> <Identifier> | <float> | <Integer>");
                //    }
                //}   

                //// id operator id
                //if (printRules) {
                //    Console.WriteLine("<Expression> -> <Identifier> <Operator> <Identifier> ");
                //}
                //// int/float operator int/float (int/float is an id)

                //// expression operator id
                //// This probably needs recursion to handle infinite operator Expression additions (like a + b + c + 8 etc)
                //if (printRules) {
                //    Console.WriteLine("<Expression> -> <Expression> <Operator> <Identifier> | <Expression> <Operator> <Expression> ");
                //}
                //// separator expression separator to simplify for now  (expression)
                //if (printRules) {
                //    Console.WriteLine("<Expression> -> <Seperator> <Expression> <Seperator>");
                //}

            }
        }
        private void CheckForAssignment() {
            // check stack for keyword id = expression then replace w/ assignment
            // check stack for id = expression then replace w/ assignment
            for (int i = 0; i < theStack.Count; i++) {
                if (theStack.Count > 2 && theStack[i].Type == TokenType.IDENTIFIER && theStack[i + 1].Value == "=" && theStack[i + 2].Type == TokenType.EXPRESSION) {
                    Console.WriteLine("It is an assignment");
                } else if (theStack.Count > 3 && theStack[i].Type == TokenType.KEYWORD && theStack[i].Type == TokenType.IDENTIFIER && theStack[i + 1].Value == "=" && theStack[i + 2].Type == TokenType.EXPRESSION) {
                    Console.WriteLine("It is an assignment");
                }
            }        
                
                
            }

            private void Function() {
                // repeats through everything until end of file

                // read a token, is it expression, 

                // pop statements, say sucessfully parsed for now 
                // in future would use statements with loops and if eslse 


            }

            private void Statement() {
                // statements should always have a ; at the end
                // declarative ;
                // check for Assign then ; , pop and replace with statement

                // would eventually handle if, while, do 


            }

            private void Declaritive() {

                // a keyword and an id

                // optional keyword id , id , id (recursive to add unlimited id's with commas, no ending comma ?) 

            }

            private void Error() {
                Console.WriteLine("error");
            }

            private void PrintTokenAndLexeme() {

            }

            private void PrintRule() {
                // print rule is printRules is true
                // Not really needed since I put rules in the functions ? 
            }








            #endregion








        }
    }
