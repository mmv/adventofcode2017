using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace adventofcode2017 {
    static class Day10 {
        
        class CircularList {
            int[] backArray;

            public CircularList(IEnumerable<int> initial) {
                backArray = initial.ToArray();
            }

            public int this[int pos] {
                get => backArray[pos % backArray.Length];
                set => backArray[pos % backArray.Length] = value;
            }

            public void Reverse(int from, int to) {
                int x;
                while (from < to) {
                    x = this[from];
                    this[from] = this[to];
                    this[to] = x;
                    from++;
                    to--;
                }
            }

            public override string ToString() {
                return "{" + string.Join(",", backArray) + "}";
            }
        }

        static IEnumerable<int> ReadInput() {
            return from numpart in File.ReadAllText(@"input\day10.txt").Split(',')
                   select int.Parse(numpart);
        }

        static IEnumerable<int> MakeBuffer() {
            for (var i = 0; i < 256; i++) yield return i;
        }

        static int Run(IEnumerable<int> input) {
            var lst = new CircularList(MakeBuffer());
            var startPos = 0;
            var skipSize = 0;

            foreach (var c in input) {
                Console.WriteLine(lst.ToString());
                lst.Reverse(startPos, startPos+(c-1));
                startPos += c;
                startPos += skipSize++;
            }

            Console.WriteLine(lst.ToString());

            return lst[0] * lst[1];
        }

        public static string Hash(string input) {

            IEnumerable<int> lengthsAtEnd = new[] {17, 31, 73, 47, 23};

            var codes = input.Select(c => (int)c)
                .Concat(lengthsAtEnd).ToArray();

            var lst = new CircularList(MakeBuffer());
            var startPos = 0;
            var skipSize = 0;

            for (var i = 0; i < 64; i++) {
                foreach (var c in codes) {
                    lst.Reverse(startPos, startPos+(c-1));
                    startPos += c;
                    startPos += skipSize++;
                }
            }

            var dense = new byte[16];
            for (var i = 0; i < 256; i++) {
                dense[i / 16] ^= (byte)lst[i];
            }

            return string.Join("", dense.Select(b => b.ToString("x")));
        }

        public static string Solve() {
            // return Run(new[] {3,4,1,5}).ToString();
            return Run(ReadInput()).ToString() + Environment.NewLine +
                Hash(File.ReadAllText(@"input\day10.txt").Trim()).ToString();
        }

    }
}