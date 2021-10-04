using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TeachMeSkills.Siniauski.Homework3
{
    class Program
    {
        private static string datePattern = @"^\d{4}-\d{2}-\d{2}";
        private static List<string> daysOfWeek = new List<string>
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };

        private static (bool isCorrect, DateTime date) GetDate(string dateStr)
        {
            if (Regex.IsMatch(dateStr, datePattern) && DateTime.TryParse(dateStr, out DateTime dateTime))
            {
                return (true, dateTime);
            }
            else
            {
                return (false, default(DateTime));
            }
        }
        private static DateTime ReadDate(string dateType, DateTime minDate = default(DateTime))
        {
            while (true)
            {
                Console.Write($"Enter {dateType} (YYYY-MM-DD): ");
                string dateStr = Console.ReadLine();
                var dateResult = GetDate(dateStr);
                if (dateResult.isCorrect)
                {
                    if (dateResult.date >= minDate)
                    {
                        return dateResult.date;
                    }
                    else
                    {
                        Console.WriteLine($"Error! Incorrect date (earlier than {minDate.ToString("yyyy-MM-dd")})!");
                    }
                }
                else
                {
                    Console.WriteLine("Error! Incorrect date!");
                }
            }
        }
        private static string ReadDayOfWeek()
        {
            while (true)
            {
                Console.Write($"Enter day of week: ");
                string dayOfWeek = Console.ReadLine();
                if (daysOfWeek.Contains(dayOfWeek))
                {
                    return dayOfWeek;
                }
                else
                {
                    Console.WriteLine("Error! Incorrect day of week!");
                }
            }
        }
        private static void PrintAllDatesForDayOfWeek(DateTime startDate, DateTime endDate, string dayOfWeek)
        {
            DateTime currentDate = startDate;
            while (currentDate <= endDate)
            {
                if (currentDate.DayOfWeek.ToString() == dayOfWeek)
                {
                    Console.WriteLine(currentDate.ToString("yyyy-MM-dd"));                    
                }
                currentDate = currentDate.AddDays(1);
            }

        }
        static void Main(string[] args)
        {
            DateTime startDate = ReadDate("start date");
            DateTime endDate = ReadDate("end date", startDate);
            string dayOfWeek = ReadDayOfWeek();
            PrintAllDatesForDayOfWeek(startDate, endDate, dayOfWeek);
        }
    }
}
