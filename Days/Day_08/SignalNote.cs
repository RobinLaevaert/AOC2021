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
            numbers[1] = Input.FirstOrDefault(x => x.Length == (int)SegmentCount.One) ?? Output.FirstOrDefault(x => x.Length == (int)SegmentCount.One);
            numbers[4] = Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Four) ?? Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Four);
            numbers[7] = Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Seven) ?? Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Seven);
            numbers[8] = Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Eight) ?? Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Eight);

            signals[0] = numbers[7].Except(numbers[1]).Single();
            numbers[0] = Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Zero && numbers[4].Except(x).Count() == 1 && x.Contains(numbers[1][0]) && x.Contains(numbers[1][1])) ?? Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Zero && numbers[4].Except(x).Count() == 1 && x.Contains(numbers[1][0]) && x.Contains(numbers[1][1]));
            numbers[9] = Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Nine && numbers[4].Except(x).Count() == 0) ?? Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Nine && numbers[4].Except(x).Count() == 0);
            numbers[6] = Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Six && x.Except(numbers[0]).Count() != 0 && x.Except(numbers[9]).Count() != 0) ?? Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Six && x.Except(numbers[0]).Count() != 0 && x.Except(numbers[9]).Count() != 0);
            numbers[3] = Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Three && numbers[1].Except(x).Count() == 0) ?? Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Three && numbers[1].Except(x).Count() == 0);
            signals[3] = numbers[8].Except(numbers[0]).Single();
            signals[1] = numbers[4].Except($"{numbers[1]}{signals[3]}").Single();
            numbers[5] = Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Five && x.Except(numbers[3]).Count() != 0 && x.Contains(signals[1])) ?? Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Five && x.Except(numbers[3]).Count() != 0 && x.Contains(signals[1]));
            numbers[2] = Input.FirstOrDefault(x => x.Length == (int)SegmentCount.Two && x.Except(numbers[3]).Count() != 0 && x.Except(numbers[5]).Count() != 0) ?? Output.FirstOrDefault(x => x.Length == (int)SegmentCount.Two && x.Except(numbers[3]).Count() != 0 && x.Except(numbers[5]).Count() != 0);

            var OrderedNumbers = numbers.Select(x => x.OrderBy(y => y));
            return OutputValue = Convert.ToInt32(new string(Output.Select(x => Array.IndexOf(numbers, numbers.Where(y => new string(y.OrderBy(z => z).ToArray()) == new string(x.OrderBy(z => z).ToArray())).Single()).ToString()).SelectMany(x => x).ToArray()));
        }
    }
}
