using Shared;

namespace Days
{
    public class Day_03 : Day
    {
        List<string> binaryReadout;
        public Day_03()
        {
            Title = "Binary Diagnostic";
            DayNumber = 3;
        }
        protected override void Gather_input()
        {
            binaryReadout = Read_file().ToList() ;
        }

        protected override void Part1()
        {
            var gamma = string.Empty;
            for (int i = 0; i < binaryReadout.First().Length; i++)
            {
                var temp = binaryReadout.Select(x => x[i])
                    .GroupBy(y => y)
                    .OrderByDescending(g => g.Count())
                    .Select(x => x.Key).First();
                gamma += temp;
            }
            var gammaNumber = Convert.ToInt32(gamma, 2);
            var epsilon = Convert.ToString(~gammaNumber, 2);
            epsilon = epsilon.Remove(0, epsilon.Length - gamma.Length);
            var epsilonNumber = Convert.ToInt32(epsilon, 2);
            var consumptionRate = gammaNumber * epsilonNumber;
            Console.WriteLine(consumptionRate);
        }

        protected override void Part2()
        {
            var oxygenRating = GetOxygenRating(binaryReadout.ToList());
            var co2Rating = Getco2Rating(binaryReadout.ToList());
            var lifeSupportRating = Convert.ToInt32(oxygenRating, 2) * Convert.ToInt32(co2Rating, 2);
            Console.WriteLine(lifeSupportRating);
        }
        public string GetOxygenRating(List<string> input)
        {
            return FilterInputList(input, 0, true);
        }

        public string Getco2Rating(List<string> input)
        {
            return FilterInputList(input, 0, false);
        }

        public string FilterInputList(List<string> input, int index, bool mostCommon)
        {
            var temp = input.Select(x => x[index])
                    .OrderByDescending(x => x)
                    .GroupBy(i => i)
                    .OrderByDescending(g => g.Count())
                    .Select(x => x.Key)
                    .First();
            var filteredList = mostCommon ? 
                                input.Where(x => x[index] == temp).ToList() : 
                                input.Where(x => x[index] != temp).ToList();
            if (filteredList.Count == 1) return filteredList.First();
            return FilterInputList(filteredList, index += 1, mostCommon);
        }
    }
}
