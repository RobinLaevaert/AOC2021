namespace Days
{
    public class Command
    {
        public Command(CommandType commandType, int unitCount)
        {
            CommandType = commandType;
            UnitCount = unitCount;
        }

        public CommandType CommandType { get; set; }
        public int UnitCount { get; set; }
    }
}
