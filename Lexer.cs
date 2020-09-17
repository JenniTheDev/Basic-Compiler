using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JenPile {
    class Lexer {
        const string keywordsPattern = @"(int)|(float)|(bool)|(true)";
        const string seperatorsPattern = @";\(\)\[\]\{\},.:";
        const string operatorsPattern = @"\+-<>\*/";

        private readonly Regex keywords = new Regex(keywordsPattern, RegexOptions.IgnoreCase);
        private readonly Regex separators = new Regex(seperatorsPattern, RegexOptions.IgnoreCase);
        private readonly Regex operators = new Regex(operatorsPattern, RegexOptions.IgnoreCase);

        public List<Token> Tokens { get; private set; } = new List<Token>();

        #region Constructor
        public Lexer() { }
        #endregion

        #region Class Methods
        public void LexInput(List<String> input) {
            StringBuilder lineToCheck = new StringBuilder();
            bool matched = false;
            bool commentSwitch = false;
            foreach(var line in input) {
                for (int i = 0; i < line.Length; i++) {
                    // check if this is correct
                    //  RemoveComment(commentSwitch, line[i]);
                    // Original Here
                    if (line[i] == '!' && !commentSwitch) {
                        commentSwitch = true;
                        continue;
                    }
                    if (line[i] == '!' && commentSwitch) {
                        commentSwitch = false;
                        continue;
                    }

                    if (commentSwitch) {
                        Console.WriteLine("switch off");
                        continue;
                    }
                    lineToCheck.Append(line[i]);
                    Console.WriteLine(lineToCheck);

                    if (keywords.Match(lineToCheck.ToString()).Success) {
                        matched = true;
                        Console.WriteLine("match keyword");
                        Tokens.Add(new Token(TokenType.KEYWORD, lineToCheck.ToString()));
                    } else if (separators.Match(lineToCheck.ToString()).Success) {
                        matched = true;
                        Tokens.Add(new Token(TokenType.SEPARATOR, lineToCheck.ToString()));
                    } else if (operators.Match(lineToCheck.ToString()).Success) {
                        matched = true;
                        Tokens.Add(new Token(TokenType.OPERATOR, lineToCheck.ToString()));
                    }

                    if (matched) {
                        lineToCheck.Clear();
                        matched = false;
                    }


                }
            }
        }
        #endregion

        //public void RemoveComment(bool comSwitch, char check) {
        //    if (check == '!' && !comSwitch) {
        //        comSwitch = true;
        //        continue;
        //    }
        //    if (check == '!' && comSwitch) {
        //        comSwitch = false;
        //        continue;
        //    }
        //    if (comSwitch) {
        //        continue;
        //    }
        //}

    }
}
