using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика1
{
    class Program
    {
        static void Main (string [ ] args)
        {
            try
            {
                Cat murzik = new Cat("Мурзик");
                Cat barsik = new Cat("Барсег");
                murzik.Meow( );
                barsik.Meow( );
                barsik.Name = "Мурзик"+"a";
                barsik.Weight =1.3;
                barsik.WeightWrite( );
                barsik.Name = "Барсик" + "a";
                barsik.Weight = 1.6;
                barsik.WeightWrite( );
                barsik.Meow( );
                barsik.Meow( );
            }
            catch
            {
                Console.WriteLine("Некорректный ввод данных!");
            }
            Console.ReadKey( );
        }
    }
}
