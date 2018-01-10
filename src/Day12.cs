using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace adventofcode2017 {
    static class Day12 {

        static IDictionary<int, IEnumerable<int>> ReadInput() {
            IEnumerable<int> ParseSet(string set) {
                return
                    from part in set.Split(',')
                    select int.Parse(part);
            }
            KeyValuePair<int, IEnumerable<int>> ParseLine(string line) {
                var parts = line.Split("<->");
                var key = int.Parse(parts[0]);
                return KeyValuePair.Create(key, ParseSet(parts[1]));
            }
            return new Dictionary<int, IEnumerable<int>>(
                from line in File.ReadAllLines(@"input\day12.txt")
                select ParseLine(line));
        }

        static int CountRefs(IDictionary<int, IEnumerable<int>> pipemap) {
            var visited = new HashSet<int>();
            var missing = new Queue<int>();
            missing.Enqueue(0);

            while (missing.Count > 0) {
                var current = missing.Dequeue();
                if (!visited.Add(current)) continue;
                foreach (var next in pipemap[current]) {
                    missing.Enqueue(next);
                }
            }

            return visited.Count;
        }

        public static string Solve() {
            return CountRefs(ReadInput()).ToString();
        }
    }
}