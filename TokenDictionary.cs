using System.Collections.Generic;

namespace JenPile {
    public static class TokenDictionary {
        public static readonly Dictionary<string, TokenType> Tokens = new Dictionary<string, TokenType>() {
            { "int", TokenType.KEYWORD },
            { "float", TokenType.KEYWORD },
            { "bool", TokenType.KEYWORD },
            { "true", TokenType.KEYWORD },
            { "false", TokenType.KEYWORD },
            { "if", TokenType.KEYWORD },
            { "else", TokenType.KEYWORD },
            { "then", TokenType.KEYWORD },
            { "endif", TokenType.KEYWORD },
            { "while", TokenType.KEYWORD },
            { "whilend", TokenType.KEYWORD },
            { "do", TokenType.KEYWORD },
            { "doend", TokenType.KEYWORD },
            { "for", TokenType.KEYWORD },
            { "forend", TokenType.KEYWORD },
            { "input", TokenType.KEYWORD },
            { "output", TokenType.KEYWORD },
            { "and", TokenType.KEYWORD },
            { "or", TokenType.KEYWORD },
            { "not", TokenType.KEYWORD },

            { "+", TokenType.OPERATOR }, 
            { "-", TokenType.OPERATOR },
            { "=", TokenType.OPERATOR }, 
            { "/", TokenType.OPERATOR },
            { ">", TokenType.OPERATOR },
            { "<", TokenType.OPERATOR },
            { "*", TokenType.OPERATOR },
        };

    }
}
