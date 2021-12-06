using Shared;

namespace Days
{
    public class Day_06 : Day
    {
        long[] LanternFishTimers;
        public Day_06()
        {
            Title = "Lanternfish";
            DayNumber = 6;
        }
        public override void Gather_input()
        {
            LanternFishTimers = new long[9];
            foreach (var number in Read_file().Single().Split(',').Select(x => Convert.ToInt32(x)))
            {
                LanternFishTimers[number]++;
            }
        }

        protected override string HandlePart1()
        {
            var resultFishies = CalculateFishies(80, LanternFishTimers);
            return resultFishies.Sum().ToString();
        }

        protected override string HandlePart2()
        {
            var resultFishies = CalculateFishies(256, LanternFishTimers);
            return resultFishies.Sum().ToString();
        }

        public long[] CalculateFishies(int days, long[] input)
        {
            var output = input.ToArray();
            for (int d = 0; d < days; d++)
            {
                var FishesOn0 = output[0];
                output = output.Select((x, index) => index == 8 ? output[index] : output[index + 1]).ToArray();
                output[8] = FishesOn0; // babies
                output[6] += output[8]; // parents
            }
            return output;
        }
    }
}
