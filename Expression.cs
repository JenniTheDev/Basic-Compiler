using System;
using System.Collections.Generic;
using System.Text;

namespace JenPile {
    class Expression {

        #region Properties

        #endregion

        #region Constructor
        public Expression() { }
        #endregion

        #region Class Methods
        // <Expression> -> <Expression> + <Term>
        // <Expression> -> <Expression> - <Term>
        // <Expression> -> <Term>

        // <Term> -> <Term> * <Factor>
        // <Term> -> <Term> / <Factor> 
        // <Term> -> <Factor> 

        // <Factor> -> (Expression)
        // <Factor> -> ID
        // <Factor> -> Num

        // ID -> id

        // bottom up approach - the first term to be computed will be on the bottom (like multiplying)

        // TODO: Is this modifying my token list so that I can't continue to use it? 
        public List<Token> Driver(List<Token> tokenizedInput) {
            Stack<String> theStack = new Stack<string>();
            theStack.Push("%"); // Push End of File marker
            tokenizedInput.Add(new Token(TokenType.NONE, "%")); // Add End Of String to input string
            theStack.Push("Some starting symbol here"); // Push start symbol on stack

            while(tokenizedInput.Count != 0 ){ // While the stack is not empty
                // if top of stack is a terminal token and 
                // if incoming tokenizendInput[i] == terminal symbol at top of stack {
                // TODO: I should also make sure that I skip space seperators from my input list - make a method to check
                //          theStack.Pop();
                //          go to next tokenizedInput }
                        //  else error message
                // else 
                // {  if table [top of stack , tokenizenInput[i]] has an entry
                // theStack.Pop(top of stack);
                // theStack.Push(Table cell contents of [top of stack, tokenizenInput[i]] in reverse order)
                // else error 

            }

            return tokenizedInput; // return something ? 
        }

        private void Error() {
            Console.WriteLine("error");
        }

        #endregion

       







    }
}
