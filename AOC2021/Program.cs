﻿using Days;
using Shared;

internal static  partial class Program
{

    private static readonly List<Day> Days = new()
    {
        new Day_01(),
        new Day_02(),
        new Day_03(),
        new Day_04(),
        new Day_05(),
        new Day_06(),
        new Day_07(),
        new Day_08(),
        new Day_09(),
        new Day_10(),
    };
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Which Day do you want ?");
            var infos = Days.Where(x => x.Title != null).Select(x => x.Info);
            WriteHelper.PrintInfos(infos.ToList());
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

