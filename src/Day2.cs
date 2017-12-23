using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace adventofcode2017 {
    static class Day2 {

        static IEnumerable<IEnumerable<int>> ReadInput() {
            var input = File.ReadAllLines(@"input\day2.txt");
            return from line in input
                   select from number in line.Split("\t")
                          select int.Parse(number.Trim());
        }

        static (int, int) MinMax(IEnumerable<int> xs) {
            int min = int.MaxValue,
                max = int.MinValue;
            foreach (var x in xs) {
                if (x < min) min = x;
                if (x > max) max = x;
            }
            return (min, max);
        }

        public static string Solve() {
            return (
                from line in ReadInput()
                let minmax = MinMax(line)
                select minmax.Item2 - minmax.Item1
            ).Sum().ToString();
        }
    }
}