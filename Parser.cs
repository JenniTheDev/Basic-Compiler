using System;
using System.Collections.Generic;
using System.Text;

namespace JenPile {
    class Parser {
        // toggles printing rules on and off
        private bool printRules = true;
        Stack<Token> theStack = new Stack<Token>();
        Token endOfFile = new Token(TokenType.ENDOFFILE, "%");
        

        #region Properties

        #endregion

        #region Constructor
        public Parser() { }
        #endregion

        #region Class Methods

        public void Driver(List<Token> tokenizedInput) {
            Console.WriteLine("Calling driver");
            theStack.Push(endOfFile); // Push End of File marker
            tokenizedInput.Add(endOfFile); // Add End Of String to input string
           foreach (Token input in tokenizedInput) {
                Token tokenToParse = input;
                Shift(tokenToParse);
                Reduce();
           }
            
        }

        // This method moves tokens from the input buffer tokenized Input onto the stack
        private void Shift(Token currentToken) {
            Console.WriteLine($"{currentToken.Type} = {currentToken.Value}");
            theStack.Push(currentToken);
        }

        // If there is a match (true), replace the token with the production rule 
        private void Reduce() {

            CheckForExpression();
            CheckForAssignment();
        }
        





        private void Function () {
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

        private void CheckForExpression () {
            // only a int
            // only a float
            // only an id
            if (printRules) {
                // Rule- An expression can be an identifier, a float or an integer by itself. 
                Console.WriteLine("<Expression> -> <Identifier> | <float> | <Integer>");
            }


            // id operator id
            if (printRules) {
                Console.WriteLine("<Expression> -> <Identifier> <Operator> <Identifier> ");
            }
            // int/float operator int/float (int/float is an id)

            // expression operator id
            // This probably needs recursion to handle infinite operator Expression additions (like a + b + c + 8 etc)
            if (printRules) {
                Console.WriteLine("<Expression> -> <Expression> <Operator> <Identifier> | <Expression> <Operator> <Expression> ");
            }
            // separator expression separator to simplify for now  (expression)
            if (printRules) {
                Console.WriteLine("<Expression> -> <Seperator> <Expression> <Seperator>");
            }
            
        }

        private void CheckForAssignment () {
            // check stack for keyword id = expression then replace w/ assignment
            // check stack for id = expression then replace w/ assignment


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
