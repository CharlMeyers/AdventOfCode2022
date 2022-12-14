using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Puzzles
{
    public static class Day3
    {
        public static void Solve()
        {
            var input = File.ReadAllLines("Input/day3.txt").ToList();
            var sum = 0;
            var groupedItems = input.Select((x, idx) => new { x, idx })
                .GroupBy(x => x.idx / 3)
                .Select(x => x.Select(y => y.x)).ToList();

            foreach (var group in groupedItems)
            {

                var common = group.ElementAt(0).Intersect(group.ElementAt(1)).Intersect(group.ElementAt(2)).First();
                var priority = GetPriority(common);

                sum += priority;
            }

            Console.WriteLine(sum);
        }

        private static int GetPriority(char val)
        {
            if (val > 'Z')
            {
                return val - 96;
            }

            return val - 38;
        }
    }
}
