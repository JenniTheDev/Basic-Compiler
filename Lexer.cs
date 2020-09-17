using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JenPile {
    class Lexer {
        const string separatorPattern = @";\(\)\[\]\{\},.:";
        const string identifierPattern = @"^[A-Z]\w|\$";
        const string floatPattern = @"^\d+\.\d+$";
        const string integerPattern = @"^\d+$";

        private readonly Regex separatorRgx = new Regex(separatorPattern, RegexOptions.IgnoreCase);
        private readonly Regex identifierRgx = new Regex(identifierPattern, RegexOptions.IgnoreCase);
        private readonly Regex floatRgx = new Regex(floatPattern);
        private readonly Regex integerRgx = new Regex(integerPattern);

        #region Properties
        public List<Token> Tokens { get; private set; } = new List<Token>();
        #endregion

        #region Constructor
        public Lexer() { }
        #endregion

        #region Class Methods
        public List<Token> LexInput(List<string> input) {
            List<Token> tokens = new List<Token>();
            StringBuilder evalLine = new StringBuilder();
            bool evalOff = false;
            
            foreach(string line in input) {
                foreach (char c in line) { 
                // Turn evaluation off during comments
                if(c == '!') {
                    evalOff = !evalOff;
                    continue;
                }
                if (evalOff) { continue; }

                    Match separatorCheck = separatorRgx.Match(c.ToString());
                    if (separatorCheck.Success) {
                        //We hit a seperator, back up and evaluate what is before it & add both as tokens
                        if (evalLine.Length > 0) {
                            string tokenToEval = evalLine.ToString();
                            TokenType type;

                            if (TokenDictionary.Tokens.TryGetValue(tokenToEval, out type)) {
                            } else if (floatRgx.IsMatch(tokenToEval)) {
                                type = TokenType.FLOAT;

                            } else if (integerRgx.IsMatch(tokenToEval)) {
                                type = TokenType.INTEGER;

                            } else if (identifierRgx.IsMatch(tokenToEval)) {
                                type = TokenType.IDENTIFIER;
                            } else {
                                type = TokenType.UNDEFINED;
                            }
                            tokens.Add(new Token(type, tokenToEval));
                        }
                        tokens.Add(new Token(TokenType.SEPARATOR, c.ToString()));
                        evalLine.Clear();
                    } else {
                        evalLine.Append(c);
                    }
                }
            }
            return tokens;
        }


        //TODO: Remove. For Testing purposes

        public void PrintTokens(List<Token> tokens) {
            foreach(Token token in tokens) {
                Console.WriteLine($"{token.Type} = {token.Value}");
            }
        }

        #endregion

        

    }
}
