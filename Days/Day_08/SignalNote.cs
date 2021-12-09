using Shared;

namespace Days
{
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

        public int DetermineOutputValue()
        {
            var numbers = new string[10];
            var signals = new char[7];
            numbers[1] = Input.First(x => x.Length == (int)SegmentCount.One);
            numbers[4] = Input.First(x => x.Length == (int)SegmentCount.Four);
            numbers[7] = Input.First(x => x.Length == (int)SegmentCount.Seven);
            numbers[8] = Input.First(x => x.Length == (int)SegmentCount.Eight);

            numbers[0] = Input.First(x => x.Length == (int)SegmentCount.Zero && numbers[4].Except(x).Count() == 1 && x.Contains(numbers[1][0]) && x.Contains(numbers[1][1]));
            numbers[9] = Input.First(x => x.Length == (int)SegmentCount.Nine && !numbers[4].Except(x).Any());
            numbers[6] = Input.First(x => x.Length == (int)SegmentCount.Six && x.Except(numbers[0]).Any() && x.Except(numbers[9]).Any());
            numbers[3] = Input.First(x => x.Length == (int)SegmentCount.Three && !numbers[1].Except(x).Any());
            signals[3] = numbers[8].Except(numbers[0]).Single();
            signals[1] = numbers[4].Except($"{numbers[1]}{signals[3]}").Single();
            numbers[5] = Input.First(x => x.Length == (int)SegmentCount.Five && x.Except(numbers[3]).Any() && x.Contains(signals[1]));
            numbers[2] = Input.First(x => x.Length == (int)SegmentCount.Two && x.Except(numbers[3]).Any() && x.Except(numbers[5]).Any());

            var OrderedNumbers = numbers.Select(x => x.OrderAlphabetically()).ToArray();
            return OutputValue = Convert.ToInt32(Output.Select(x => Array.IndexOf(OrderedNumbers, x.OrderAlphabetically()).ToString()).Aggregate((current, next) => current + next));

        }
    }
}
