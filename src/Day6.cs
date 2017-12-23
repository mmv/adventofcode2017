using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace adventofcode2017 {

    static class Assert {
        public static void That(Func<bool> pred, string testDescription) {
            if (pred() == false) {
                throw new InvalidOperationException($"assert failed {testDescription}");
            }
        }
    }

    static class Day6 {

        static void Redistribute(int[] buffer) {
            // start by finding the max
            var maxp = 0;
            for (int i = 1; i < buffer.Length; i++)
            {
                if (buffer[maxp] < buffer[i]) {
                    maxp = i;
                }
            }

            var units = buffer[maxp];
            var p = maxp;

            // take all units from the one with most
            buffer[maxp] = 0;
            p++;

            // go around the buffer distributing them
            while (units > 0) {
                if (p == buffer.Length) p = 0;                
                buffer[p++]++;
                units--;
            }
        }

        static int[] ReadInput() {
            return File.ReadAllText(@"input\day6.txt")
                       .Trim()
                       .Split("\t")
                       .Select(int.Parse)
                       .ToArray();
        }

        class Remember {
            int[] b;
            int hashCode;
            public Remember(int[] b) {
                this.b = new int[b.Length];
                b.CopyTo(this.b, 0);
                foreach (var x in b) {
                    hashCode ^= x.GetHashCode();
                }
            }
            
            public override int GetHashCode() {
                return hashCode;
            }

            public override bool Equals(object obj) {
                var other = obj as Remember;
                return other != null
                    && other.hashCode == hashCode
                    && other.b.SequenceEqual(b);
            }
        }

        static int StepsToLoop(int[] b) {
            var seen = new HashSet<Remember>();
            seen.Add(new Remember(b));
            
            var steps = 0;    

            while(true) {
                steps++;                
                Redistribute(b);
                var remember = new Remember(b);
                if (seen.Contains(remember)) {
                    return steps;
                }
                seen.Add(remember);
            }
        }

        static void Tests() {
            var b = new[] {0,2,7,0};
            Redistribute(b);
            Assert.That(() => b.SequenceEqual(new[] {2,4,1,2}), "example 1");
            Redistribute(b);
            Assert.That(() => b.SequenceEqual(new[] {3,1,2,3}), "example 2");
        }

        public static string Solve() {
            // return StepsToLoop(new[] {0,2,7,0}).ToString();
            return StepsToLoop(ReadInput()).ToString();
        }
    }
}