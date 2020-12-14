using System;
using System.Collections.Generic;

namespace JenPile {
    internal class SymbolTable {
        private int memoryLocation = 5000;
        // Token should instead be a identifier and previous keyword pair

        public Dictionary<Symbol, int> IdTable = new Dictionary<Symbol, int>();

        public void AddToTable(Symbol identifierCheck) {
            if (IdTable.ContainsKey(identifierCheck)) {
                Console.WriteLine($"An identifier with {identifierCheck.Keyword} already exists");
            } else {
                IdTable.Add(identifierCheck, memoryLocation);
                memoryLocation++;
            }
        }

        public void PrintSymbolTable() {
            foreach (KeyValuePair<Symbol, int> sym in IdTable) {
                Console.WriteLine($"Identifier: {sym.Key.Identifier}, Token Type: {sym.Key.Keyword}, Memory Location: {sym.Value} ");
            }
        }
    }
}