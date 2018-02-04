using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace adventofcode2017 {
    static class Day13 {

        public static IEnumerable<(int, int)> ReadInput() {
            return
                from line in File.ReadAllLines(@"input\day13.txt")
                let parts = line.Split(":")
                select (int.Parse(parts[0]), int.Parse(parts[1]));
            
        }

        public static int Process(IEnumerable<(int range, int depth)> config) {
            var rounds =
                from p in config
                let rtt = (p.depth - 1) * 2
                where p.range % rtt == 0
                select p.depth * p.range;
            
            return rounds.Sum();
        }

        public static string Solve() {
            return Process(ReadInput()).ToString();
        }
    }
}