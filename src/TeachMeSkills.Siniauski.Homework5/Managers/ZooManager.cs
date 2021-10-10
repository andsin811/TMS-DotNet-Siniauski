using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachMeSkills.Siniauski.Homework5.Models;
using TeachMeSkills.Siniauski.Homework5.Interfaces;


namespace TeachMeSkills.Siniauski.Homework5
{
    class ZooManager : IZooManager
    {
        public List<AnimalBase> Animals { get; set; } = new List<AnimalBase>();

        public void PrintAllAnimals()
        {
            Console.WriteLine(new string('-', 20));
            foreach (var animal in Animals)
            {
                if(animal is Bear)
                {
                    (animal as Bear).PrintInfo();
                    continue;
                }
                if (animal is Crocodile)
                {
                    (animal as Crocodile).PrintInfo();
                    continue;
                }
                if (animal is Sparrow)
                {
                    (animal as Sparrow).PrintInfo();
                    continue;
                }                
            }
            Console.WriteLine(new string('-', 20));
        }

        public void Run()
        {
            Bear bear = new Bear("Teddy");
            Crocodile crocodile = new Crocodile("Gena");
            Sparrow sparrow = new Sparrow("Jack");

            Animals.Add(bear);
            Animals.Add(crocodile);
            Animals.Add(sparrow);

            PrintAllAnimals();

            Console.WriteLine();
            (bear as IRun).Go(15);
            (crocodile as ISwim).Go(10);
            (sparrow as IFly).Go(5);
            Console.WriteLine();

            PrintAllAnimals();
        }
    }
}
