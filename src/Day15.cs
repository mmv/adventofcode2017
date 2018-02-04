using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode2017 {

    static class Day15 {

        // const int SEED1 = 65;
        // const int SEED2 = 8921;
        const int SEED1 = 722;
        const int SEED2 = 354;

        const int FACTOR1 = 16807;
        const int FACTOR2 = 48271;

        const int REMAINDER = 2147483647;

        const int MASK_LOW_16 = 0xffff;

        static IEnumerable<int> MakeGenerator(long seed, int factor) {
            IEnumerable<int> Generator() {
                for (;;) {
                    seed *= factor;
                    seed = seed % REMAINDER;
                    yield return (int)seed;
                }
            }

            return Generator();
        }

        public static string Solve() {
            return
                MakeGenerator(SEED1, FACTOR1)
                .Zip(MakeGenerator(SEED2, FACTOR2), (fst,snd) => (fst & MASK_LOW_16) == (snd & MASK_LOW_16))
                .Take(40_000_000)
                .Where(id => id)
                .Count()
                .ToString();
            // return String.Join(Environment.NewLine, MakeGenerator(SEED1, FACTOR1)
            //     .Zip(MakeGenerator(SEED2, FACTOR2), (fst,snd) => $"{fst}  {snd}")
            //     .Take(4));
        }
    }
}