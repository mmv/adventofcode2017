using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace adventofcode2017 {

    static class Day1 {

        static IEnumerable<IEnumerable<T>> Window<T>(IEnumerable<T> self, int count) {
            List<T> window = new List<T>();
            foreach(var item in self) {
                window.Add(item);
                if (window.Count == count) {
                    yield return window.ToList();
                    window.RemoveAt(0);
                }
            }
        }

        public static string Solve() {
            var input = File.ReadAllText(@"input\day1.txt").Trim();
            var result = 0;
            input += input.Last();
            foreach(var pair in Window(input, 2)) {
                var apair = pair.ToArray();
                if (apair[0] != apair[1]) {
                    continue;
                } else {
                    result += (apair[0] - '0');
                }
            }

            return result.ToString();
        }

    }
}