using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class Player
    {
        public void ChooseMove(Hand pHand, Hand dHand, DeckOfCards deck)
        {
            string uInput = "";
            while (true)
            {
                uInput = Console.ReadLine().ToUpper();
                if (uInput == "H")
                {
                    pHand.AddToHand(deck);
                    pHand.PrintHand(pHand, dHand, true);
                    if (pHand.AddValue() > 21)
                        break;
                }
                else if (uInput == "S")
                    break;
                else
                    Console.WriteLine("Invalid input");
            }
        }
    }
}
