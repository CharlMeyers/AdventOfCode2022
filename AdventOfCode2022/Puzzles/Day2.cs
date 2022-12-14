using System;
using System.IO;

namespace AdventOfCode2022.Puzzles
{
    public static class Day2
    {
        public static void Solve()
        {
            var input = File.ReadAllLines($"Input/day2.txt");
            var score = 0;

            foreach (var line in input)
            {
                var play = line.Split(' ');
                var opponent = GetShape(play[0]);
                var mine = GetChosenShape(opponent, play[1]);
                score += (int)GetOutcome(opponent, mine) + (int)mine;
            }

            Console.WriteLine(score);
        }

        private static OUTCOME GetOutcome(SHAPE opponent, SHAPE mine)
        {
            return mine switch
            {
                SHAPE.Rock when opponent == SHAPE.Paper => OUTCOME.Loose,
                SHAPE.Rock when opponent == SHAPE.Scissor => OUTCOME.Win,
                SHAPE.Rock when opponent == SHAPE.Rock => OUTCOME.Draw,

                SHAPE.Paper when opponent == SHAPE.Paper => OUTCOME.Draw,
                SHAPE.Paper when opponent == SHAPE.Scissor => OUTCOME.Loose,
                SHAPE.Paper when opponent == SHAPE.Rock => OUTCOME.Win,

                SHAPE.Scissor when opponent == SHAPE.Paper => OUTCOME.Win,
                SHAPE.Scissor when opponent == SHAPE.Scissor => OUTCOME.Draw,
                SHAPE.Scissor when opponent == SHAPE.Rock => OUTCOME.Loose
            };
        }

        private static SHAPE GetShape(string move)
        {
            return move.ToLower() switch
            {
                "a" => SHAPE.Rock,
                "b" => SHAPE.Paper,
                "c" => SHAPE.Scissor
            };
        }

        private static SHAPE GetChosenShape(SHAPE opponent, string outcome)
        {
            //loose
            if (outcome.ToLower() == "x")
            {
                return opponent switch
                {
                    SHAPE.Rock => SHAPE.Scissor,
                    SHAPE.Paper => SHAPE.Rock,
                    SHAPE.Scissor => SHAPE.Paper
                };
            }

            //draw
            if (outcome.ToLower() == "y")
            {
                return opponent switch
                {
                    SHAPE.Rock => SHAPE.Rock,
                    SHAPE.Paper => SHAPE.Paper,
                    SHAPE.Scissor => SHAPE.Scissor
                };
            }

            //win
            if (outcome.ToLower() == "z")
            {
                return opponent switch
                {
                    SHAPE.Rock => SHAPE.Paper,
                    SHAPE.Paper => SHAPE.Scissor,
                    SHAPE.Scissor => SHAPE.Rock
                };
            }

            return SHAPE.Rock;
        }
    }

    public enum SHAPE
    {
        Rock = 1,
        Paper = 2,
        Scissor = 3
    }

    public enum OUTCOME
    {
        Loose = 0,
        Draw = 3,
        Win = 6
    }
}
