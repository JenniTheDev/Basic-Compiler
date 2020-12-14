using System;
using System.Collections.Generic;

namespace JenPile {
    internal class SymbolTable {
        private int MEMORY_LOCATION = 5000;
        // Token should instead be a identifier and previous keyword pair

        public Dictionary<Variable, int> IdTable = new Dictionary<Variable, int>();

        public void AddToTable(Variable identifierCheck) {
            try {
                IdTable.Add(identifierCheck, MEMORY_LOCATION);
                MEMORY_LOCATION++;
            } catch (ArgumentException) {
                Console.WriteLine("An identifier with {0} already exists", identifierCheck.Value);
            }
        }

        public void PrintSymbolTable() {
            foreach (KeyValuePair<Variable, int> sym in IdTable) {
                Console.WriteLine($"Identifier: {sym.Key.Value}, Token Type: {sym.Key.Type}, Memory Location: {sym.Value} ");
            }
        }
    }
}