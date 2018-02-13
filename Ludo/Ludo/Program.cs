using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("hello world");
                Dice dice = new Dice(6);
                Console.WriteLine(dice.RollDice());
                Console.ReadKey();
            }
        }
    }
}
