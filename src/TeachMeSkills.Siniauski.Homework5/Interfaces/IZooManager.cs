using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachMeSkills.Siniauski.Homework5.Models;

namespace TeachMeSkills.Siniauski.Homework5.Interfaces
{
    interface IZooManager
    {
        public List<AnimalBase> Animals { get; set; }

        public void PrintAllAnimals();
        public void Run();
    }
}
