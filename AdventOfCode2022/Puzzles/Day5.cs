using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Puzzles
{
    public static class Day5
    {
        public static void Solve()
        {
            var lines = File.ReadAllLines("Input/day5.txt").ToList();
            var emptyLineIndex = lines.IndexOf("");
            var stacks = new List<List<string>>();
            var crateIndexes = new Dictionary<int, int>();

            for (var index = 0; index < lines[emptyLineIndex - 1].Length; index++)
            {
                var currentChar = lines[emptyLineIndex - 1][index].ToString();
                var crateIndex = 0;

                if (int.TryParse(currentChar, out crateIndex))
                {
                    crateIndexes.Add(crateIndex, index);
                }
            }

            for (var index = emptyLineIndex - 2; index >= 0; index--)
            {
                foreach (var crateIndex in crateIndexes)
                {
                    var stack = stacks.ElementAtOrDefault(crateIndex.Key - 1);
                    var crate = lines[index][crateIndex.Value].ToString();

                    if (stack is null)
                    {
                        stack = new List<string>();
                        stacks.Add(stack);
                    }

                    if (!string.IsNullOrWhiteSpace(crate))
                    {
                        stack.Add(crate);
                    }
                }
            }

            for (var index = emptyLineIndex + 1; index < lines.Count; index++)
            {
                var instructions = Regex.Matches(lines[index], @"\d+").ToArray();
                var moveCount = int.Parse(instructions[0].Value);
                var fromCrate = stacks[int.Parse(instructions[1].Value) - 1];
                var toCrate = stacks[int.Parse(instructions[2].Value) - 1];

                toCrate.AddRange(fromCrate.GetRange(fromCrate.Count - moveCount, moveCount));
                fromCrate.RemoveRange(fromCrate.Count - moveCount, moveCount);


            }

            foreach (var stack in stacks)
            {
                Console.Write(stack.LastOrDefault());
            }
        }

        private static int GetStackCount(string input)
        {
            var trimmedText = input.Trim();

            return (int)trimmedText[trimmedText.Length - 1];
        }
    }
}
