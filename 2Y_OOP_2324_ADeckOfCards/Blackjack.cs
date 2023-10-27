using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class Blackjack
    {
        public void Play()
        {
            while (true)
            {
                DeckOfCards deck = new DeckOfCards(true);
                Player player = new Player();
                AI_BJ dealer = new AI_BJ();
                Hand dHand = new Hand(2, deck);
                Hand cHand = new Hand(2, deck);
                bool pTurn = true;

                dHand.PrintHand(dHand, cHand, pTurn);

                //player move
                player.ChooseMove(dHand, cHand, deck);
                pTurn = false;
                dHand.PrintHand(dHand, cHand, pTurn);

                //cpu move
                if (dHand.AddValue() < 21)
                {
                    dealer.AImove(dHand, cHand, deck);
                    dHand.PrintHand(dHand, cHand, pTurn);
                }

                CheckForWin(dHand, cHand);
                Console.WriteLine("\nEnter any key to play again");
                Console.ReadKey();
            }
        }

        private void CheckForWin(Hand pHand, Hand cHand)
        {
            Console.WriteLine("");
            if (pHand.AddValue() == 21)
            {
                Console.WriteLine("Blackjack! You Win!");
            }
            else if (pHand.AddValue() > 21)
            {
                Console.WriteLine("Bust!");
            }
            else if (cHand.AddValue() > 21)
            {
                Console.WriteLine("Dealer bust. You Win!");
            }
            else if (pHand.AddValue() > cHand.AddValue())
            {
                Console.WriteLine("You Win!");
            }
            else if (cHand.AddValue() > pHand.AddValue())
            {
                Console.WriteLine("You Lose.");
            }
            else if (pHand.AddValue() == cHand.AddValue())
            {
                Console.WriteLine("It's a tie.");
            }
        }
    }
}



