using System;
using System.Collections.Generic;

namespace JenPile {
    internal class SymbolTable {
        private int MEMORY_LOCATION = 5000;

        public Dictionary<Token, int> IdTable = new Dictionary<Token, int>();

        public void AddToTable(Token identifierCheck) {
            try {
                IdTable.Add(identifierCheck, MEMORY_LOCATION);
                MEMORY_LOCATION++;
            } catch (ArgumentException) {
                Console.WriteLine("An identifier with {0} already exists", identifierCheck.Value);
            }
        }

        public void PrintSymbolTable() {
            foreach (KeyValuePair<Token, int> sym in IdTable) {
                Console.WriteLine("Identifier: {0}, Token Type: {1}, Memory Location: {2} ", sym.Key.Value, sym.Key.Type, sym.Value);
            }
        }
    }
}