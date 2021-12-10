using Shared;

namespace Days
{
    public class Day_10 : Day
    {
        List<string> Lines;
        public Day_10()
        {
            Title = "Syntax Scoring";
            DayNumber = 10;
        }
        public override void Gather_input()
        {
            Lines = Read_file().ToList();
        }

        protected override string HandlePart1()
        {
            var points = Lines.Select(x =>
            {
                var openings = new List<Char>();
                foreach (var character in x)
                {
                    if (character is '(' or '[' or '{' or '<')
                    {
                        openings.Add(character);
                    }
                    else
                    {
                        if (openings.Last().GetClosingChar() == character)
                        {
                            openings.RemoveAt(openings.Count - 1);
                        }
                        else
                        {
                            return character.GetPoints();
                        }
                    }
                }
                return 0;
            });
            return points.Sum().ToString();
        }

        protected override string HandlePart2()
        {
            var points = Lines.Select(x =>
            {
                var openings = new List<Char>();
                foreach (var character in x)
                {
                    if (character is '(' or '[' or '{' or '<')
                    {
                        openings.Add(character);
                    }
                    else
                    {
                        if (openings.Last().GetClosingChar() == character)
                        {
                            openings.RemoveAt(openings.Count - 1);
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                }
                return new string(openings.ToArray());
            })
                .Where(x => x != string.Empty)
                .Select(x => new string(x.Reverse().Select(y => y.GetClosingChar()).ToArray()))
                .Select(x => x.Aggregate((long)0, (current, next) => (current * 5) + next.GetPointsP2()))
                .OrderBy(x => x);
            return points.ElementAt(points.Count() / 2).ToString();
        }
    }
}
