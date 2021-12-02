using Days;
using Shared;
using System.Reflection;

internal static  partial class Program
{

    private static readonly List<Day> Days = new()
    {
        new Day_01(),
        new Day_02(),
    };
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Which Day do you want ?");
            var infos = Days.Where(x => x.Title != null).ToList().Select(x => x.Info).ToList();
            WriteHelper.PrintInfos(infos);
            var input = Console.ReadLine();
            if (int.TryParse(input, out var chosenDay) && Days.SingleOrDefault(x => x.DayNumber == chosenDay) != null)
            {
                var day = Days.Single(x => x.DayNumber == chosenDay);
                day.HandleSelect();
                day.Deselect();
            }
            else
            {
                Console.WriteLine("Day not found, Press Key to go back to main menu");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

