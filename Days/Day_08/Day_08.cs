using Shared;

namespace Days
{
    public class Day_08 : Day
    {
        List<SignalNote> SignalNotes;
        public Day_08()
        {
            Title = "Seven Segment Search";
            DayNumber = 8;
        }
        public override void Gather_input()
        {
            SignalNotes = Read_file().Select(x => new SignalNote(x)).ToList();
        }

        protected override string HandlePart1()
        {
            var response = SignalNotes.Select(x => x.Output.Select(y => y.Count() == (int)SegmentCount.One ||
                                                                    y.Count() == (int)SegmentCount.Four ||
                                                                    y.Count() == (int)SegmentCount.Seven ||
                                                                    y.Count() == (int)SegmentCount.Eight)
                                                        .Count(x => x == true))
                                                        .Sum();
            return response.ToString();
        }

        protected override string HandlePart2()
        {
            return SignalNotes.Sum(x => x.DetermineOutputValue()).ToString();
        }
    }
}
