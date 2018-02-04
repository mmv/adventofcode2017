using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace adventofcode2017 {
    static class Day14 {

        // const string INPUT = "flqrgnkx";
        const string INPUT = "ffayrhll";

        static int CountBits(char hex) {
            int b = hex - (hex > '9' ? ('a' -10): '0');
            int bits = 0;
            while (b > 0) {
                bits += b & 1;
                b = b >> 1;
            }
            return bits;
        }

        static IEnumerable<string> BuildGrid(string input) {
            for (int i = 0; i < 128; i++) {
                yield return Day10.Hash($"{input}-{i}");
            }
        }

        public static string Solve() {
            return (from line in BuildGrid(INPUT) from c in line select CountBits(c)).Sum().ToString();
        }
    }
}