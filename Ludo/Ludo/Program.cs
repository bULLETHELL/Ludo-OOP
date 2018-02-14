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
                Board board = new Board();
                Console.WriteLine(board.Info());
                Console.ReadKey();
            }
        }
    }
}
