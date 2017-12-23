using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2017 {
    static class Day8 {

        static int Compute() {
            var instructions =
                from line in File.ReadAllLines(@"input\day8.txt")
                let sline = line.Split(' ')
                select new {
                    Register = sline[0],
                    Op = sline[1],
                    Amount = int.Parse(sline[2]),
                    IfRegister = sline[4],
                    IfOp = sline[5],
                    IfAmount = int.Parse(sline[6]),
                };
            
            var registers = new Dictionary<string, int>();

            var tests = new Dictionary<string, Func<int, int, bool>>() {
                {"==", (a,b) => a == b},
                {">",  (a,b) => a >  b},
                {"<",  (a,b) => a <  b},
                {"<=", (a,b) => a <= b},
                {">=", (a,b) => a >= b},
                {"!=", (a,b) => a != b},
                
            };
            
            foreach (var instruction in instructions) {
                var actualIfAmount = registers.GetValueOrDefault(instruction.IfRegister, 0);
                var cond = tests[instruction.IfOp](actualIfAmount, instruction.IfAmount);
                if (cond) {
                    if (instruction.Op == "inc") {
                        registers[instruction.Register] = registers.GetValueOrDefault(instruction.Register)
                                                          + instruction.Amount;
                    } else {
                        registers[instruction.Register] = registers.GetValueOrDefault(instruction.Register)
                                                          - instruction.Amount;
                    }
                }
            }

            return registers.Values.Max();

        }

        public static string Solve() {
            return Compute().ToString();
        }
    }
}