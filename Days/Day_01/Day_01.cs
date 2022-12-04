using Shared;

namespace Days
{
    public class Day_01 : Day
    {
        public List<Elf> input = new ();
        public Day_01()
        {
            Title = "Sonar Sweep";
            DayNumber = 1;
        }
        public override void Gather_input()
        {
            var elfCount = 1;
            var currentElf = new Elf(elfCount);
            foreach (var line in Read_file())
            {
                if (string.IsNullOrEmpty(line))
                {
                    input.Add(currentElf);
                    elfCount++;
                    currentElf = new(elfCount);
                }
                else
                {
                    currentElf.Calories.Add(int.Parse(line));
                }
            }
        }

        protected override string HandlePart1()
        {
            var maxElf = input.OrderByDescending(x => x.Calories.Sum()).First();
            return $"Elf #{maxElf.Number} has {maxElf.Calories.Sum()} Calories";
        }

        protected override string HandlePart2()
        {
            var maxElves = input.OrderByDescending(x => x.Calories.Sum()).Take(3);
            return $"The top 3 elves carry a combined {maxElves.Sum(x => x.Calories.Sum())} Calories";
        }
    }

    public class Elf
    {
        public Elf(int number)
        {
            Number = number;
            Calories = new();
        }
        public int Number { get; set; }
        public List<int> Calories { get; set; }
    }
}
