using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace adventofcode2017 {
    static class Day4 {
        static IEnumerable<IEnumerable<string>> ReadInput() {
            return from line in File.ReadAllLines(@"input\day4.txt")
                   select line.Trim().Split(" ");
        }

        public static string Solve() {
            return (
                from passphrase in ReadInput()
                where passphrase.Count() == passphrase.ToHashSet().Count
                select 1
            ).Count().ToString();
        }
    }
}