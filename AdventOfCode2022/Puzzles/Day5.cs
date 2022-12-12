namespace AdventOfCode2022.Puzzles
{
    public static class Day5
    {
        public static void Solve()
        {
            var lines = File.ReadAllLines("Input/day5.txt").ToList();
            var emptyLineIndex = lines.IndexOf("");
            var steps = lines.GetRange(emptyLineIndex, lines.Count - emptyLineIndex);
            var stackCount = GetStackCount(lines.ElementAt(emptyLineIndex - 1));
            var stacks = new List<Queue<string>>();

            for (var index = emptyLineIndex - 1; index >= 0; index--)
            {
                for (var stackIndex = 0; stackIndex < stackCount; stackIndex++)
                {
                    var stack = stacks.ElementAt(stackIndex);

                    if (stack is null)
                    {
                        stack = new Queue<string>();
                    }

                    stack.Enqueue(lines[index]);
                }
            }
        }

        private static int GetStackCount(string input)
        {
            var trimmedText = input.Trim();

            return (int)trimmedText[trimmedText.Length - 1];
        }
    }
}
