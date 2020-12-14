using System;
using System.Collections.Generic;

namespace JenPile {
    internal class SymbolTable {
        private int MEMORY_LOCATION = 5000;

        public Dictionary<string, int> IdTable = new Dictionary<string, int>();

        public void AddToTable(string identifierCheck) {
            try {
                IdTable.Add(identifierCheck, MEMORY_LOCATION);
                MEMORY_LOCATION++;
            } catch (ArgumentException) {
                Console.WriteLine("An identifier with = {0} already exists", identifierCheck);
            }
        }

        public void PrintSymbolTable() {
            foreach(KeyValuePair<string, int> sym in IdTable) {
                Console.WriteLine("Identifier: = {0}, Memory Location: = {1} ", sym.Key, sym.Value);
            }
        }

    }
}