using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class AI_BJ
    {
        public void AImove(Hand pHand, Hand dHand, DeckOfCards deck)
        {
            Console.WriteLine("\nDealer is drawing a card. Please wait");
            while (dHand.AddValue() < 17)
            {
                Thread.Sleep(1000);
                dHand.AddToHand(deck);
                pHand.PrintHand(pHand, dHand, false);
            }
        }
    }
}
