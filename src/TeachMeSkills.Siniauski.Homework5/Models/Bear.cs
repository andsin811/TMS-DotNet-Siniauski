using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachMeSkills.Siniauski.Homework5.Enums;
using TeachMeSkills.Siniauski.Homework5.Interfaces;

namespace TeachMeSkills.Siniauski.Homework5.Models
{
    class Bear : AnimalBase, IMove, IRun, ISwim
    {
        public Bear(string name) : base(name, AnimalClass.Mammal, true) { }

        public override void PrintInfo()
        {
            Console.WriteLine($"Animal: bear");
            base.PrintInfo();
        }

        void IMove.Go(int speed)
        {
            Status = $"Is mowing with speed {speed} km/h";
            Console.WriteLine($"Bear {Name} {Status.ToLower()}");
        }
        void IRun.Go(int speed)
        {
            Status = $"Is running with speed {speed} km/h";
            Console.WriteLine($"Bear {Name} {Status.ToLower()}");
        }
        void ISwim.Go(int speed)
        {
            Status = $"Is swimming with speed {speed} km/h";
            Console.WriteLine($"Bear {Name} {Status.ToLower()}");
        }
    }
}
