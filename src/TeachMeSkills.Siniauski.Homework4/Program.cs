using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.RegularExpressions;

namespace TeachMeSkills.Siniauski.Homework4
{
    

    class Program
    {
        private static readonly string eventListFilePath = "EventList.data";
        private static List<Event> eventList;
        private static readonly string datePattern = @"^\d{4}-\d{2}-\d{2}";
        private static readonly Dictionary<string, EventStatus> statusInputDictionary = new Dictionary<string, EventStatus>()
        {
            { "U", EventStatus.Unknown },
            { "P", EventStatus.Planned },
            { "IP", EventStatus.InProgress },
            { "D", EventStatus.Done },
            { "C", EventStatus.Сanceled }
        };
        private static readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions { WriteIndented = true };

        static void Main(string[] args)
        {
            eventList = new List<Event>();
            if (File.Exists(eventListFilePath))
            {
                eventList = JsonSerializer.Deserialize<List<Event>>(File.ReadAllText(eventListFilePath), serializerOptions);
            }
            Console.WriteLine("Work modes:" +
                    "\n\tA - add new event" +
                    "\n\tE - edit event" +
                    "\n\tD - delete event" +
                    "\n\tP - print all events" +
                    "\n\tS - save all events to file" +
                    "\n\texit - exit the program");

            while (true)
            {
                Console.WriteLine("Enter work mode:");
                string input = Console.ReadLine();
                switch (input)
                {                    
                    case "A":
                        if (AddEvent())
                        {
                            Console.WriteLine("New event was successfully added!");                            
                        }
                        break;
                    case "E":
                        if (EditEvent())
                        {
                            Console.WriteLine("Event was successfully edited!");
                        }
                        break;
                    case "D":
                        if (DeleteEvent())
                        {
                            Console.WriteLine("Event was successfully deleted!");
                        }
                        break;
                    case "P":
                        PrintAllEvents();
                        break;
                    case "S":
                        if(SaveToFile())
                        {
                            Console.WriteLine("Events was successfully saved!");
                        }
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Incorrect work mode!");
                        break;
                }
            }
        }

        private static bool AddEvent()
        {
            try
            {
                int number = eventList.Count == 0 ? 1 : eventList.Select(ev => ev.Number).Max() + 1;
                Console.WriteLine("Enter description: ");
                string description = Console.ReadLine();
                Console.WriteLine("Enter date (YYYY-MM-DD): ");
                string date = Console.ReadLine();
                if (!Regex.IsMatch(date, datePattern) || !DateTime.TryParse(date, out DateTime dateTime))
                {
                    throw new Exception("Incorrect date value!");
                }
                Console.WriteLine("Enter status (U -unknown, P - planned, IP - in progress, D - done, C - canceled): ");
                string status = Console.ReadLine();
                if (!statusInputDictionary.Keys.Contains(status))
                {
                    throw new Exception("Incorrect status value!");
                }
                eventList.Add(new Event(number, description, dateTime, statusInputDictionary[status]));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static bool EditEvent()
        {
            try
            {
                Console.WriteLine("Enter event number: ");
                string numberStr = Console.ReadLine();
                if (!int.TryParse(numberStr, out int number) || (!eventList.Exists(ev => ev.Number == number)))
                {
                    throw new Exception("Event not found!");
                }
                Event currentEvent = eventList.Find(ev => ev.Number == number);
                Console.WriteLine("Enter new description (enter + to keep the previous value): ");
                string description = Console.ReadLine();
                if (description != "+")
                {
                    currentEvent.Description = description;
                }
                Console.WriteLine("Enter new date (YYYY-MM-DD) (enter + to keep the previous value): ");
                string date = Console.ReadLine();
                if (date != "+")
                {
                    if (!Regex.IsMatch(date, datePattern) || !DateTime.TryParse(date, out DateTime dateTime))
                    {
                        throw new Exception("Incorrect date value!");
                    }
                    currentEvent.Date = dateTime;
                }
                Console.WriteLine("Enter new status (U -unknown, P - planned, IP - in progress, D - done, C - canceled)" +
                    "\n(enter + to keep the previous value): ");
                string status = Console.ReadLine();
                if (status != "+")
                {
                    if (!statusInputDictionary.Keys.Contains(status))
                    {
                        throw new Exception("Incorrect status value!");
                    }
                    currentEvent.Status = statusInputDictionary[status];
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static bool DeleteEvent()
        {
            try
            {
                Console.WriteLine("Enter event number: ");
                string numberStr = Console.ReadLine();
                if (!int.TryParse(numberStr, out int number) || (!eventList.Exists(ev => ev.Number == number)))
                {
                    throw new Exception("Event not found!");
                }
                eventList.RemoveAt(eventList.FindIndex(ev => ev.Number == number));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static void PrintAllEvents()
        {
            Console.WriteLine($"\nCount of events: {eventList.Count}");
            foreach (Event ev in eventList)
            {
                ev.Print();
            }
            Console.WriteLine();
        }

        private static bool SaveToFile()
        {
            try
            {
                File.WriteAllText(eventListFilePath, JsonSerializer.Serialize(eventList, serializerOptions));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
