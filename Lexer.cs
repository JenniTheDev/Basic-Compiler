using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JenPile {
    public class Lexer {
        private const string separatorPattern = @"[=*+/\-;\s:()\[\]{},]+";

        // currently working for single letters
        private const string identifierPattern = @"[A-Z]";

        // original working one that didn't do single letters
        // const string identifierPattern = @"^[A-Z]\w|\$";
        private const string floatPattern = @"^-?\d+\.\d+$";

        private const string integerPattern = @"^-?\d+$";

        // Trying this
        private const string operatorPattern = @"[=+_*/]";

        private readonly Regex separatorRgx = new Regex(separatorPattern, RegexOptions.IgnoreCase);
        private readonly Regex identifierRgx = new Regex(identifierPattern, RegexOptions.IgnoreCase);
        private readonly Regex floatRgx = new Regex(floatPattern);
        private readonly Regex integerRgx = new Regex(integerPattern);

        // Trying this
        private readonly Regex operatorRgx = new Regex(operatorPattern);

        private SymbolTable symbolTbl = new SymbolTable();

        #region Properties
        public List<Token> Tokens { get; private set; } = new List<Token>();
        #endregion Properties

        #region Constructor

        public Lexer() {
        }

        #endregion Constructor

        #region Class Methods

        public List<Token> LexInput(List<string> input) {
            List<Token> tokens = new List<Token>();
            StringBuilder evalLine = new StringBuilder();
            // SymbolTable symbolTable = new SymbolTable();
            bool evalOff = false;

            foreach (string line in input) {
                foreach (char c in line) {
                    // Turning evaluation off during comments
                    if (c == '!') {
                        evalOff = !evalOff;
                        continue;
                    }
                    if (evalOff) { continue; }

                    Match separatorCheck = separatorRgx.Match(c.ToString());
                    if (separatorCheck.Success) {
                        // We've hit a separator, evaluate the line, & add it as a token with the separator
                        if (evalLine.Length > 0) {
                            string tokenToEval = evalLine.ToString();
                            TokenType type;

                            if (TokenDictionary.Tokens.TryGetValue(tokenToEval, out type)) {
                            } else if (floatRgx.IsMatch(tokenToEval)) {
                                type = TokenType.FLOAT;
                            } else if (integerRgx.IsMatch(tokenToEval)) {
                                type = TokenType.INTEGER;
                            } else if (identifierRgx.IsMatch(tokenToEval)) {
                                symbolTbl.AddToTable(tokenToEval);
                                type = TokenType.IDENTIFIER;
                            } else {
                                // Should throw an error if this hits
                                type = TokenType.UNDEFINED;
                            }

                            tokens.Add(new Token(type, tokenToEval));
                        }
                        // Trying this for part 2 AND IT WORKS!
                        if (operatorRgx.IsMatch(c.ToString())) {
                            tokens.Add(new Token(TokenType.OPERATOR, c.ToString()));
                        } else {
                            tokens.Add(new Token(TokenType.SEPARATOR, c.ToString()));
                        }
                        //tokens.Add(new Token(TokenType.SEPARATOR, c.ToString()));
                        evalLine.Clear();
                    } else {
                        evalLine.Append(c);
                    }
                }
            }
            return tokens;
        }

        //TODO: Remove. For Testing Purposes

        public void PrintTokens(List<Token> tokens) {
            foreach (Token token in tokens) {
                Console.WriteLine($"{token.Type} = {token.Value}");
                // System.IO.File.AppendAllText(@"CompilerOutput.jen", $"{token.Type} = {token.Value} \r");
            }
            symbolTbl.PrintSymbolTable();
        }

       

        #endregion Class Methods
    }
}