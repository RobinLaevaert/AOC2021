using Shared;

namespace Days
{
    public class Day_09 : Day
    {
        HeightMap HeightMap;
        public Day_09()
        {
            Title = "Smoke Basin";
            DayNumber = 9;
        }
        public override void Gather_input()
        {
            HeightMap = new HeightMap();
            var input = Read_file().ToList();
            for (int y = 0; y < input.Count; y++)
            {
                var line = input[y];
                for (int x = 0; x < line.Count(); x++)
                {
                    var heigth = (int)Char.GetNumericValue(line[x]);
                    HeightMap.Locations.Add(new Location(x, y, heigth));
                }
            }
        }

        protected override string HandlePart1()
        {
            return FindMins(HeightMap).Sum(x => x.Height +1).ToString();
        }

        protected override string HandlePart2()
        {
            return FindMins(HeightMap)
                        .Select(x => DetermineBasinSize(HeightMap, x))
                        .OrderByDescending(x => x).Take(3)
                        .Aggregate((current, next) => current * next)
                        .ToString();
        }

        private static List<Location> FindMins(HeightMap input) => input.Locations.Where(x => input.GetAdjacentLocations(x).All(y => y.Height > x.Height)).ToList();

        private int DetermineBasinSize(HeightMap dict, Location location)
        {
            if (location.Height == 9)
                return 0;
            location.Height = 9;
            var leftLoc = dict.Locations.SingleOrDefault(x => x.X == location.X - 1 && x.Y == location.Y);
            var rightLoc = dict.Locations.SingleOrDefault(x => x.X == location.X + 1 && x.Y == location.Y);
            var upLoc = dict.Locations.SingleOrDefault(x => x.X == location.X && x.Y == location.Y - 1);
            var downLoc = dict.Locations.SingleOrDefault(x => x.X == location.X && x.Y == location.Y + 1);
            return 1 +
                    (leftLoc == null ? 0 : DetermineBasinSize(dict, leftLoc)) +
                    (rightLoc == null ? 0 : DetermineBasinSize(dict, rightLoc)) +
                    (upLoc == null ? 0 : DetermineBasinSize(dict, upLoc)) +
                    (downLoc == null ? 0: DetermineBasinSize(dict, downLoc));
        }
    }
}
