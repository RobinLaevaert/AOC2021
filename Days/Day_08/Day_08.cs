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
            foreach (var note in SignalNotes)
            {
                var numbers = new string[10];
                var signals = new char[7];
                numbers[1] = note.Input.FirstOrDefault(x => x.Length == (int)SegmentCount.One) ?? note.Output.FirstOrDefault(x => x.Length == (int)SegmentCount.One);
                numbers[4] = note.Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Four) ?? note.Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Four);
                numbers[7] = note.Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Seven) ?? note.Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Seven);
                numbers[8] = note.Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Eight) ?? note.Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Eight);

                signals[0] = numbers[7].Except(numbers[1]).Single();
                numbers[0] = note.Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Zero && numbers[4].Except(x).Count() == 1 && x.Contains(numbers[1][0]) && x.Contains(numbers[1][1])) ?? note.Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Zero && numbers[4].Except(x).Count() == 1 && x.Contains(numbers[1][0]) && x.Contains(numbers[1][1]));
                numbers[9] = note.Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Nine && numbers[4].Except(x).Count() == 0) ?? note.Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Nine && numbers[4].Except(x).Count() == 0);
                numbers[6] = note.Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Six && x.Except(numbers[0]).Count() != 0 && x.Except(numbers[9]).Count() != 0) ?? note.Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Six && x.Except(numbers[0]).Count() != 0 && x.Except(numbers[9]).Count() != 0);
                numbers[3] = note.Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Three && numbers[1].Except(x).Count() == 0) ?? note.Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Three && numbers[1].Except(x).Count() == 0);
                signals[3] = numbers[8].Except(numbers[0]).Single();
                signals[1] = numbers[4].Except($"{numbers[1]}{signals[3]}").Single();
                numbers[5] = note.Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Five && x.Except(numbers[3]).Count() != 0 && x.Contains(signals[1])) ?? note.Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Five && x.Except(numbers[3]).Count() != 0 && x.Contains(signals[1]));
                numbers[2] = note.Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Two && x.Except(numbers[3]).Count() != 0 && x.Except(numbers[5]).Count() != 0) ?? note.Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Two && x.Except(numbers[3]).Count() != 0 && x.Except(numbers[5]).Count() != 0);

                var OrderedNumbers = numbers.Select(x => x.OrderBy(y => y));
                note.OutputValue = Convert.ToInt32(new string(note.Output.Select(x => Array.IndexOf(numbers, numbers.Where(y => new string(y.OrderBy(z => z).ToArray()) == new string(x.OrderBy(z => z).ToArray())).Single()).ToString()).SelectMany(x => x).ToArray()));
            }
            return SignalNotes.Sum(x => x.OutputValue).ToString();
        }
    }

    public class SignalNote
    {
        public List<string> Input { get; set; }
        public List<string> Output { get; set; }
        public int OutputValue { get; set; }

        public SignalNote(string note)
        {
            var temp = note.Split(" | ");
            Input = temp.First().Split(" ").ToList();
            Output = temp.Last().Split(" ").ToList();
        }
    }

    public enum SegmentCount
    {
        Zero = 6,
        One = 2,
        Two = 5,
        Three = 5,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 3,
        Eight = 7,
        Nine = 6
    }
}
