using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace adventofcode2017 {
    static class Day7 {

        class Node {
            public string Name { get; private set; }
            public int Order { get; private set; }
            public HashSet<string> ChildIds { get; private set; }

            Regex nameorder = new Regex(@"(?<name>.+) \((?<order>\d+)\)");

            public Node(string line) {
                var groups = nameorder.Match(line).Groups;
                Name = groups["name"].Value;
                Order = int.Parse(groups["order"].Value);
                
                if (line.IndexOf("->") > 0) {
                    ChildIds = line.Split("->").Last().Split(",").Select(x => x.Trim()).ToHashSet();
                } else {
                    ChildIds = new HashSet<string>(0);
                }
            }
        }

        static IEnumerable<Node> ReadInput() {
            return from line in File.ReadAllLines(@"input\day7.txt")
                   select new Node(line);
        }

        static string GetRootNode() {
            var nodes = new Dictionary<string, Node>();
            var parents = new Dictionary<string, string>();
            foreach (var n in ReadInput()) {
                nodes[n.Name] = n;

                foreach (var c in n.ChildIds) {
                    parents[c] = n.Name;
                }
            }

            var node = parents.First().Value;
            while (parents.ContainsKey(node)) {
                node = parents[node];
            }

            return node;
        }

        public static string Solve() {
            // return ReadInput().OrderBy(line => line.Order).First().Name;
            return GetRootNode();
        }
    }
}