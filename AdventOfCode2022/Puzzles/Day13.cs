using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AdventOfCode2022.Puzzles
{
    public static class Day13
    {
        public static void Solve()
        {
            var lines = File.ReadAllLines($"Input/{MethodBase.GetCurrentMethod().DeclaringType.Name.ToLower()}.txt");
            var pairs = new List<List<object>>();
            var pair = new List<object>();

            //foreach (var line in lines)
            //{
            //    if (string.IsNullOrWhiteSpace(line))
            //    {
            //        pairs.Add(pair);
            //        pair = new List<object>();
            //        continue;
            //    }

            //    if ()

            //        pair.Add(new List<object>(line.Split(",")));


            //}

            pairs.Add(pair);
        }

        //private static List<object> AddList(string line)
        //{

        //}
    }
}
