using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Puzzles
{
    public static class Day4
    {
        public static void Solve()
        {
            var lines = File.ReadAllLines("Input/day4.txt");
            var sum = 0;

            foreach (var line in lines)
            {
                var pairs = line.Split(',');
                var pair1 = GetRange(pairs[0]);
                var pair2 = GetRange(pairs[1]);

                if (pair1.Intersect(pair2).Count() > 0)
                {
                    sum++;
                    continue;
                }

                if (pair2.Intersect(pair1).Count() > 0)
                {
                    sum++;
                }
            }

            Console.WriteLine(sum);
        }

        private static IEnumerable<int> GetRange(string input)
        {
            var range = input.Split('-');
            var start = int.Parse(range[0]);
            var end = int.Parse(range[1]);

            return Enumerable.Range(start, end - start + 1);
        }
    }
}
