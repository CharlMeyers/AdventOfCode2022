namespace AdventOfCode2022.Puzzles
{
    public static class Day1
    {
        public static void Part1()
        {
            var calories = File.ReadAllLines($"Input/day1.txt");
            var totalCalories = new List<int>();
            var calorieSum = 0;

            foreach (var c in calories)
            {
                if (!string.IsNullOrEmpty(c))
                {
                    calorieSum += int.Parse(c);
                }
                else
                {
                    totalCalories.Add(calorieSum);
                    calorieSum = 0;
                }
            }

            Console.WriteLine(totalCalories.OrderByDescending(x => x).Take(3).Sum().ToString());
        }
    }
}
