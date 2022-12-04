using System.Threading.Channels;
using Shared;
namespace Days
{
    public class Day_03 : Day
    {
        List<Round> rounds;
        private List<Tuple<Move, string, string, int, Result>> map;
        
        public Day_03()
        {
            Title = "Binary Diagnostic";
            DayNumber = 3;
        }
        public override void Gather_input()
        {
            map = new List<Tuple<Move, string, string, int, Result>>()
            {
                new(Move.Paper, "B", "Y", 2, Result.Draw),
                new(Move.Rock, "A", "X", 1, Result.Loss),
                new(Move.Scissors, "C", "Z", 3, Result.Win),
            };
            rounds = Read_file().Select(x => new Round(map.Single(y => y.Item2 == x.Split(" ")[0]).Item1,
                map.Single(y => y.Item3 == x.Split(" ")[1]).Item1, map.Single(y => y.Item3 == x.Split(" ")[1]).Item5)).ToList();
        }

        protected override string HandlePart1()
        {
            foreach (var round in rounds)
            {
                round.Points = map.Single(y => y.Item1 == round.Round1Move).Item4 + (((int) round.Round1Result) * 3);
            }

            return rounds.Sum(x => x.Points).ToString();
        }

        protected override string HandlePart2()
        {
            foreach (var round in rounds)
            {
                round.Points = map.Single(y => y.Item1 == round.Round2Move).Item4 + (((int) round.Round2Result) * 3);
            }
            
            return rounds.Sum(x => x.Points).ToString();
        }

    }

    public class Round
    {
        public Round(Move opponentMove, Move ownMove, Result expectedResult)
        {
            OpponentMove = opponentMove;
            OwnMove = ownMove;
            Round1Move = ownMove;
            Round2Result = expectedResult;
        }
        public Move OpponentMove { get; set; }
        public Move OwnMove { get; set; }
        
        public Move Round1Move { get; set; }

        public Move Round2Move => Round2Result == Result.Draw ? OpponentMove :
            Round2Result == Result.Win ? 
                (Move)(((int) OpponentMove + 2) % 3): 
                (Move)(((int) OpponentMove + 1) % 3);
        
        public Result Round2Result { get; set; }

        public int Points { get; set; }

        public Result Round1Result => (int) OpponentMove == (int) OwnMove ? 
            Result.Draw :
            (int) OwnMove % 3 == (((int) OpponentMove + 1) % 3) ? 
                Result.Loss : 
                Result.Win;
    }

    public enum Move
    {
        Rock,
        Scissors,
        Paper,
    }

    public enum Result
    {
        Loss,
        Draw,
        Win
    }
}
