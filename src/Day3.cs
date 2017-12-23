using System;
using System.Linq;
using System.Collections.Generic;

namespace adventofcode2017 {
    static class Day3 {

        enum Direction {
            Right, Up, Left, Down
        }

        static int M(int pos) {
            int dist = 0;
            int right = 0, up = 0, left = 0, down = 0;
            Direction going = Direction.Right;

            for (int i = 1; i < pos; i++) {
                // Console.WriteLine($">> {up} {down} {left} {right} ({dist})");
                
                switch (going) {
                    case Direction.Up:
                        if (down > 0) {
                            down--;
                            break;
                        } else if (++up == dist) going = Direction.Left;
                        break;
                    case Direction.Left:
                        if (right > 0) right--;
                        else if (++left == dist) going = Direction.Down;
                        break;
                    case Direction.Down:
                        if (up > 0) up--;
                        else if (++down == dist) going = Direction.Right;
                        break;
                    case Direction.Right:
                        if (left > 0) left--;
                        else if (++right > dist) {
                            dist ++;
                            going = Direction.Up;
                        }
                        break;

                }
            }

            // Console.WriteLine($"{up} {down} {left} {right}");
            return up + down + left + right;
        }


        public static string Solve() {
            for (int i = 0; i < 10; i++) M(i);
            return M(361527).ToString();
        }
    }
}