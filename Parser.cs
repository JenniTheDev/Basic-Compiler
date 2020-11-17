using System;
using System.Collections.Generic;
using System.Text;

namespace JenPile {
    class Parser {

        private bool printRules = true;
        Token endOfFile = new Token(TokenType.NONE, "%%");

        #region Properties

        #endregion

        #region Constructor
        public Parser() { }
        #endregion

        #region Class Methods

        public void Driver(List<Token> tokenizedInput) {
            Stack<Token> theStack = new Stack<Token>();
           // theStack.Push(endOfFile); // Push End of File marker
           // tokenizedInput.Add(new Token(TokenType.NONE, "%")); // Add End Of String to input string

            //while (theStack != null ?  Maybe I can just make this a function and call it until the input has been checked 
                foreach (Token t in tokenizedInput) {
                    if (t.Value != " ") {
                        theStack.Push(t);
                    }
                    if (t.Value == ";") {
                        ParseStackMath(theStack);
                    }
                    // need to get more input from the List
                }

            Console.WriteLine("stack check print");
            foreach (Token token in theStack) {
                Console.WriteLine($"{token.Type} = {token.Value} "  ); 
            }

            //}


        }


        public void ParseStackMath(Stack<Token> stackToParse) {
            Token toCheck = stackToParse.Pop();
            if (toCheck.Value == ";") {                
                toCheck = stackToParse.Pop();     // id + (operator + id ) repeating until = or something else
                if (toCheck.Type == TokenType.IDENTIFIER || toCheck.Type == TokenType.INTEGER || toCheck.Type == TokenType.FLOAT) {
                    toCheck = stackToParse.Pop();
                    while (toCheck.Value != "=" && stackToParse != null) {
                        if (toCheck.Type == TokenType.OPERATOR) {
                            toCheck = stackToParse.Pop();
                        } 
                        if (toCheck.Type == TokenType.IDENTIFIER || toCheck.Type == TokenType.INTEGER || toCheck.Type == TokenType.FLOAT) {
                            toCheck = stackToParse.Pop();
                        } 
                        // else if a wrong thing break? 
                    }
                    // rule about expressions ? 

                    if (toCheck.Value == "=") {
                        Console.WriteLine(" Some rule about Assigning ");
                        toCheck = stackToParse.Pop();
                    } 

                    if (toCheck.Type == TokenType.IDENTIFIER) {
                        Console.WriteLine("Sucessful parse");
                    }

                       


                        
                    
                }
            } 
            
            // when hits = -> give expression rule
            // if no = at end, error

        }



        private void Error() {
            Console.WriteLine("error");
        }

        private void PrintTokenAndLexeme() {

        }

        // What's the point of tokens if we don't use them? 
        private void PrintSemicolonRule() {
            if (printRules) {
                Console.WriteLine("<Assign> -> <Identifier> = <Expression> ; ");
                Console.WriteLine("<Term> -> <Identifier> <Operator> <Identifier>  ;| <Number> <Operator> <Number> ; ");
                 Console.WriteLine("<Expression> -> <Term> Something? ");

            }
        }


        void PrintRule() {
            // print rule is printRules is true
        }

        //private bool Identifier() {
        //    bool isIdentifier = false;

        //    if ( // object.token is identifier){

        //    return isIdentifier;
        //}

        //private bool Assign() {


        //}

        private bool Empty() {
            bool isEmpty = false;
            if (printRules) {
                Console.WriteLine("<Empty> -> Epsilon");
            }
            return true;

        }





        #endregion







    }   
}
