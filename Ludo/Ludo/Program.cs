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
                Square square = new Square(SquareType.Normal, 1, Color.White);
                Console.WriteLine(square.Info());
                square.SqClr = Color.Red;
                Console.ReadKey();
            }
        }
    }
}
