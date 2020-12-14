namespace JenPile {

    public struct Symbol {
        public string Keyword { get; private set; }
        public string Identifier { get; private set; }

        public Symbol(string keyword, string identifier) {
            Keyword = keyword;
            Identifier = identifier;
        }
    }
}