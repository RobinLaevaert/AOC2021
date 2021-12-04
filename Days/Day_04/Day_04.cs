using Shared;

namespace Days
{
    public class Day_04 : Day
    {
        List<int> DrawnNumbers;
        List<Board> Boards;
        public Day_04()
        {
            Title = "Giant Squid";
            DayNumber = 4;
        }
        public override void Gather_input()
        {
            var input = Read_file().ToList();
            DrawnNumbers = input.First().Split(',').Select(x => Convert.ToInt32(x)).ToList();
            input.RemoveRange(0, 2);
            Boards = new List<Board>();
            var tempBoard = new List<string>();
            foreach (var line in input)
            {
                if(line != "") tempBoard.Add(line);
                else
                {
                    Boards.Add(new Board(tempBoard));
                    tempBoard = new List<string>();
                }
            }
            Boards.Add(new Board(tempBoard));
        }

        protected override string HandlePart1()
        {
            var finalNumber = 0;
            foreach (var number in DrawnNumbers)
            {
                finalNumber = number;
                foreach (var board in Boards)
                {
                    board.PlayNumber(number);
                }

                if (Boards.Any(x => x.hasBingo()))
                    break;
            }
            var winningBoard = Boards.Single(x => x.hasBingo());
            var sumUnchecked = winningBoard.Fields.Where(x => !x.Checked).Sum(x => x.Value);
            return (finalNumber * sumUnchecked).ToString();
        }

        protected override string HandlePart2()
        {
            var finalNumber = 0;
            var boardsInPlay = Boards.ToList();
            var finishedBoards = new List<Board>();
            foreach (var number in DrawnNumbers)
            {
                finalNumber = number;
                foreach (var board in Boards)
                {
                    board.PlayNumber(number);
                }

                var boardsWithBingo = boardsInPlay.ToList().Where(x => x.hasBingo());
                finishedBoards.AddRange(boardsWithBingo);
                boardsInPlay = boardsInPlay.Except(finishedBoards).ToList();
                if (!boardsInPlay.Any()) break;
            }
            
            var lastWinningBoard = finishedBoards.Last();
            var sumUnchecked = lastWinningBoard.Fields.Where(x => !x.Checked).Sum(x => x.Value);
            return (finalNumber * sumUnchecked).ToString();
        }
    }
}
