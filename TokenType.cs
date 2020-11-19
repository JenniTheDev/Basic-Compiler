namespace JenPile {
    public enum TokenType {
       NONE,
       KEYWORD,
       IDENTIFIER,
       SEPARATOR,
       OPERATOR,
       INTEGER,
       FLOAT,
       ENDOFFILE,

       // For parsing for now
       EXPRESSION,
       ASSIGNMENT, 

       UNDEFINED
    }   
}
