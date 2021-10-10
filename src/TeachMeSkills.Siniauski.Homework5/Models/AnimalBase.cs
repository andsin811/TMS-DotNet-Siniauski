using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachMeSkills.Siniauski.Homework5.Enums;

namespace TeachMeSkills.Siniauski.Homework5.Models
{
    abstract public class AnimalBase
    {
        private string _name;
        private AnimalClass _animalClass;
        private bool _isPredatory;
        private string _status;

        public string Status
        {
            get => _status;
            set => _status = value;
        }
        public string Name
        {
            get => _name;
        }

        public AnimalBase(string name, AnimalClass animalClass, bool isPredatory)
        {
            _name = name;
            _animalClass = animalClass;
            _isPredatory = isPredatory;
            _status = "Is not moving";
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Class: {_animalClass.ToString().ToLower()}");
            Console.WriteLine("Is predatory: " + (_isPredatory ? "yes" : "no"));
            Console.WriteLine($"Status: {_status.ToLower()}");
            Console.WriteLine();
        }
    }
}
