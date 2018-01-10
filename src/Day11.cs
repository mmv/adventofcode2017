using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace adventofcode2017 {
    static class Day11 {

        enum Direction {
            s,se,sw,n,ne,nw
        }

        static IEnumerable<string> ParseInput(string input) {
            return from part in input.Trim().Split(",")
                   select part.Trim();
        }

        static string ReadInput() {
            return File.ReadAllText(@"input\day11.txt");
        }

        static int InnerSolve(string input) {
            int s = 0, se = 0, sw = 0, n = 0, ne = 0, nw = 0;

            var counts = ParseInput(input)
                            .GroupBy(x => x)
                            .ToDictionary(x => x.Key, x => x.Count());
            
            s = counts.GetValueOrDefault("s", 0);
            sw = counts.GetValueOrDefault("sw", 0);
            se = counts.GetValueOrDefault("se", 0);
            n = counts.GetValueOrDefault("n", 0);
            ne = counts.GetValueOrDefault("ne", 0);
            nw = counts.GetValueOrDefault("nw", 0);

            Console.WriteLine($"{n} {nw} {ne} {s} {sw} {se}");

            // clear inversions
            n -= s;
            ne -= sw;
            nw -= se;

            Console.WriteLine($"{n} {nw} {ne} {s} {sw} {se}");

            // optimize sidewinds
            if (Math.Abs(ne) > Math.Abs(nw)) {
                n += nw;
                ne -= nw;
                nw = 0;
            } else {
                n += ne;
                nw -= ne;
                ne = 0;
            }

            Console.WriteLine($"{n} {nw} {ne} {s} {sw} {se}");            

            // optimize northwinds
            if (nw * n < 0 || ne * n < 0) {
                var side = nw + ne;
                if (Math.Abs(n) >= Math.Abs(side)) {
                    if (nw != 0) {
                        nw = 0;
                        ne -= side;
                        n += side;
                    } else {
                        ne = 0;
                        nw -= side;
                        n += side*2;
                    }
                } else {
                    if (nw != 0) {
                        if (nw != 0) {
                            nw += n;
                            ne = n;
                            n = 0;
                        } else {
                            ne += n;
                            nw = n;
                            n = 0;
                        }
                    }
                }
            }

            Console.WriteLine($"{n} {nw} {ne} {s} {sw} {se}");
            return Math.Abs(n) + Math.Abs(nw) + Math.Abs(ne);
        }

        public static string Solve() {
            // return InnerSolve("se,sw,se,sw,sw").ToString();
            Console.WriteLine(InnerSolve("ne,ne,ne").ToString());
            Console.WriteLine(InnerSolve("ne,ne,sw,sw").ToString());
            Console.WriteLine(InnerSolve("ne,ne,s,s").ToString());
            Console.WriteLine(InnerSolve("se,sw,se,sw,sw").ToString());
            return InnerSolve(ReadInput()).ToString();
        }

    }
}