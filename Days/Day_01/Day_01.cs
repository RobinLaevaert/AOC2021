using Shared;

namespace Days
{
    public class Day_01 : Day
    {
        public List<int> input = new ();
        public Day_01()
        {
            Title = "Sonar Sweep";
            DayNumber = 1;
        }
        public override void Gather_input()
        {
            input = Read_file().Select(int.Parse).ToList();
        }

        protected override string HandlePart1()
        {
            var result = input.SelectWithPrevious((prev, cur) => cur > prev).ToList();
            return result.Count(x => x == true).ToString();
        }

        protected override string HandlePart2()
        {
            var WindowedInput = new int[input.Count - 2];
            WindowedInput = WindowedInput.Select((x, index) => input[index] + input[index + 1] + input[index + 2]).ToArray();
            var result = WindowedInput.SelectWithPrevious((prev, cur) => cur > prev).ToList();
            return result.Count(x => x == true).ToString();
        }
    }
}
