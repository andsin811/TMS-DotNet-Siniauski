using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachMeSkills.Siniauski.Homework5.Enums;
using TeachMeSkills.Siniauski.Homework5.Interfaces;


namespace TeachMeSkills.Siniauski.Homework5.Models
{
    class Sparrow : AnimalBase, IMove, IFly
    {
        public Sparrow(string name) : base(name, AnimalClass.Bird, false) { }

        public override void PrintInfo()
        {
            Console.WriteLine($"Animal: sparrow");
            base.PrintInfo();
        }

        void IMove.Go(int speed)
        {
            Status = $"Is mowing with speed {speed} km/h";
            Console.WriteLine($"Sparrow {Name} {Status.ToLower()}");
        }
        void IFly.Go(int speed)
        {
            Status = $"Is flying with speed {speed} km/h";
            Console.WriteLine($"Sparrow {Name} {Status.ToLower()}");
        }
    }
}
