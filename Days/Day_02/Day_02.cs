using Shared;

namespace Days
{
    public class Day_02 : Day
    {
        public List<Command> CommandList { get; set; }
        public Day_02()
        {
            Title = "Dive!";
            DayNumber = 2;
        }
        protected override void Gather_input()
        {
            CommandList = Read_file().Select(x =>
            {
                var temp = x.Split(' ');
                _ = Enum.TryParse(temp[0], out CommandType commandType);
                var unitCount = int.Parse(temp[1]);
                return new Command(commandType, unitCount);
            }).ToList();
        }

        protected override void Part1()
        {
            var finalPosition = DetermineFinalPosition(CommandList, false);
            Console.WriteLine($"HorizontalPosition: {finalPosition.HorizontalPosition}, Depth: {finalPosition.Depth}");
            Console.WriteLine($"HorizontalPosition x depth: {finalPosition.HorizontalPosition * finalPosition.Depth}");
        }

        protected override void Part2()
        {
            var finalPosition = DetermineFinalPosition(CommandList, true);
            Console.WriteLine($"HorizontalPosition: {finalPosition.HorizontalPosition}, Depth: {finalPosition.Depth}");
            Console.WriteLine($"HorizontalPosition x depth: {finalPosition.HorizontalPosition * finalPosition.Depth}");
        }

        public Position DetermineFinalPosition(List<Command> commands, bool useAim)
        {
            var horizontalPos = 0;
            var depth = 0;
            var aim = 0;

            foreach (var command in CommandList)
            {
                switch (command.CommandType)
                {
                    case CommandType.down:
                        if (!useAim) { depth += command.UnitCount; } else { aim += command.UnitCount; }
                        break;
                    case CommandType.up:
                        if (!useAim) { depth -= command.UnitCount; } else { aim -= command.UnitCount; }
                        break;
                    case CommandType.forward:
                        horizontalPos += command.UnitCount;
                        if (useAim) depth += (aim * command.UnitCount);
                        break;
                }
            }
            return new Position(horizontalPos, depth);
        }
    }
}
