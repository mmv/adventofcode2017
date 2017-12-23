using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace adventofcode2017 {
    static class Day5 {

        static int[] ReadInstructions() {
            return (from line in File.ReadAllLines(@"input\day5.txt")
                    select int.Parse(line.Trim()))
                   .ToArray();
        }

        static int Runner(int[] input) {
            var p = 0;
            var max = input.Length;
            int count = 0;

            while (0 <= p && p < max) {
                var steps = input[p]++;
                p += steps;
                count++;
            }
            return count;
        }

        public static string Solve() {
            // return Runner(new[]{0,3,0,1,-3,})
            return Runner(ReadInstructions())
                .ToString();
        }
    }
}