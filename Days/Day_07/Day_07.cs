using Shared;

namespace Days
{
    public class Day_07 : Day
    {
        List<int> horizontalPositions;
        public Day_07()
        {
            Title = "The Treachery of Whales";
            DayNumber = 7;
        }
        public override void Gather_input()
        {
            horizontalPositions = Read_file().First().Split(',').Select(x => Convert.ToInt32(x)).ToList();
        }

        protected override string HandlePart1()
        {
            var possiblePositions = Enumerable.Range(0, horizontalPositions.Max())
                                                            .Select(x => horizontalPositions.Select(y => Math.Abs(x - y)).Sum())
                                                            .ToList();
            return possiblePositions.Min().ToString();
        }

        protected override string HandlePart2()
        {
            var possiblePositions = Enumerable.Range(0, horizontalPositions.Max()).Select(x => horizontalPositions
                                                                                                .Select(y => 
                                                                                                    { 
                                                                                                        var distance = Math.Abs(x - y); 
                                                                                                        return distance * (distance + 1) / 2; 
                                                                                                    })
                                                                                                .Sum())
                                                .ToList();
            return possiblePositions.Min().ToString();
        }
    }
}