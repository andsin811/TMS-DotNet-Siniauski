using System;
using System.Text.RegularExpressions;

namespace TeachMeSkills.Siniauski.Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            string datePattern = @"^\d{4}-\d{2}-\d{2}";
            Console.WriteLine("Enter 'exit' to exit.");
            while (true)
            {
                Console.Write("Enter date (YYYY-MM-DD): ");
                string dateStr = Console.ReadLine();
                if (dateStr == "exit")
                    break;
                if (Regex.IsMatch(dateStr, datePattern) && DateTime.TryParse(dateStr, out DateTime date))
                    Console.WriteLine($"Day is - {date.DayOfWeek}");
                else
                    Console.WriteLine("Error! Incorrect date!");
            }
        }
    }
}
