using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика1
{
    class Cat
    {
        private string name;
        private double weight;
        bool weightscan = true;
        public Cat (string CatName)
        {
            Name = CatName;
        }

        public void Meow ()
        {
            Console.WriteLine($"{name}: МЯЯЯЯЯЯЯУУУУУУУУУУ!");
        }

        public void WeightWrite ()
        {
            if ( weightscan )
                Console.WriteLine($"Вес кота {name} - {weight}");
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                bool OnlyLetters = true;
                foreach ( var ch in value )
                {
                    if ( !char.IsLetter(ch) )
                    {
                        OnlyLetters = false;
                    }
                }

                if ( OnlyLetters )
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }
        }

        public double Weight
        {
            get
            {
                return weight;
                weightscan = true;
            }
            set
            {
                if ( value != 0 && value > 0 )
                {
                    weight = value;
                }
                else if ( value == 0 )
                {
                    Console.WriteLine("Вес кота не может быть равен нулю");
                    weightscan = false;
                }
                else if ( value < 0 )
                {
                    Console.WriteLine("Вес кота не может быть отрицательным числом");
                    weightscan = false;
                }
            }
        }
    }
}
