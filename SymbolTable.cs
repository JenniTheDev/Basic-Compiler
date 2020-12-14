using System;
using System.Collections.Generic;

namespace JenPile {
    internal class SymbolTable {
        private const int MEMORY_LOCATION = 5000;
        private Token tokenToAdd;

        public Dictionary<Token, int> IdTable = new Dictionary<Token, int>();

        public void addToTable(Token token) {
            try {
                IdTable.Add(tokenToAdd, MEMORY_LOCATION);
            } catch (ArgumentException) {
                Console.WriteLine("An identifier with *this* already exists");
            }
        }
    }
}