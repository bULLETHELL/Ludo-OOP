using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public class Dice
    {
        private int sides;
        private Random random = new Random();
        private string diceValue;

        //constructor for the dice class
        public Dice(int diceSides)
        {
            this.sides = diceSides;
        }

        //the function that rolls the dice
        public string Roll()
        {
            diceValue = random.Next(1, (this.sides + 1)).ToString();
            //diceValue = "Globe";debugterning

            if (diceValue == "3")
            {
                return "Star";
            }
            else if (diceValue == "5")
            {
                return "Globe";
            }
            else
            {
                return diceValue;
            }
        }
    }
}
