using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace adventofcode2017 {
    static class Day9 {

        static int Compute(IEnumerable<char> cs) {
            int totalScore = 0;
            int currentScore = 0;

            var css = cs.GetEnumerator();

            while (css.MoveNext()) {
                switch (css.Current) {
                    case '{':
                        currentScore++;
                        totalScore += currentScore;
                        break;
                    case '}':
                        currentScore--;
                        break;
                    case '<':
                        void EatGarbage() {
                            while (css.MoveNext()) {
                                switch (css.Current) {
                                    case '!':
                                        css.MoveNext();
                                        continue;
                                    case '>':
                                        return;
                                }
                            }
                        }
                        EatGarbage();
                        break;
                }
            }
            return totalScore;
        }

        static string ReadInput() {
            return File.ReadAllText(@"input\day9.txt");
        }

        public static string Solve() {
            // return Compute("{<!!x>{}{}<x>}").ToString();
            return Compute(ReadInput()).ToString();
        }
    } 
}