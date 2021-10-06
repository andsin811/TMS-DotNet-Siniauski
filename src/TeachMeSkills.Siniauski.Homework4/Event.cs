using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachMeSkills.Siniauski.Homework4
{
    public enum EventStatus
    {
        Unknown,
        Planned,
        InProgress,
        Done,
        Сanceled
    }

    public class Event
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public EventStatus Status { get; set; }

        public Event() { }
        public Event(int number, string description, DateTime date, EventStatus status)
        {
            Number = number;
            Description = description;
            Date = date;
            Status = status;
        }

        public void Print()
        {
            Console.WriteLine($"----- Event № {Number} -----");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Date: {Date.ToShortDateString()}");
            Console.WriteLine($"Status: {Status.ToString()}");
        }

    }
}
