namespace JenPile {

    public struct Symbol {
        public SymbolType Keyword { get; private set; }
        public string Identifier { get; private set; }

        public Symbol(SymbolType keyword, string identifier) {
            Keyword = keyword;
            Identifier = identifier;
        }
    }
}