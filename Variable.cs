namespace JenPile {

    public struct Variable {
        public TokenType Type { get; private set; }
        public string Value { get; private set; }

        public Variable(TokenType type, string value) {
            Type = type;
            Value = value;
        }
    }
}