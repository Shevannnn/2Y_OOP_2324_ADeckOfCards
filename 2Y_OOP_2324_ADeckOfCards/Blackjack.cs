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
                List<Card> pHand = new List<Card>();
                List<Card> cHand = new List<Card>();
                DeckOfCards deck = new DeckOfCards(true);
                cHand.Clear();
                pHand.Clear();
                bool pTurn = true;

                cHand = deck.drawACard(2);
                pHand = deck.drawACard(2);
                PrintHand(pHand, cHand, pTurn);

                //player move
                ChooseMove(pHand, cHand, deck);
                pTurn = false;
                PrintHand(pHand, cHand, pTurn);

                //cpu move
                if (AddValue(pHand) < 21)
                {
                    AImove(cHand, deck);
                    PrintHand(pHand, cHand, pTurn);
                }

                CheckForWin(pHand, cHand);
                Console.WriteLine("\nEnter any key to play again");
                Console.ReadKey();
            }
        }

        private int AddValue(List<Card> hand)
        {
            int value = 0;
            int aceCount = 0;

            foreach (Card c in hand)
            {
                value += c.GetCardValue();
                if (c.GetCardFace() == "Ace")
                    aceCount++;
            }

            // Turn ace to 11 if it will not cause bust
            while (aceCount > 0 && value + 10 <= 21)
            {
                value += 10;
                aceCount--;
            }
            return value;
        }
        
        private void PrintHand(List<Card> pHand, List<Card> cHand, bool pTurn)
        {
            Console.Clear();
            if (pTurn)
            {
                Console.WriteLine("Dealer's Hand:");
                Console.WriteLine("Value: ?");
                Console.WriteLine($"{cHand[0].GetCardFace()} of {cHand[0].GetCardSuit()}");
                Console.WriteLine("[Face Down Card]\n");

                Console.WriteLine("Player's Hand:");
                Console.WriteLine("Value: " + AddValue(pHand));
                foreach (Card c in pHand)
                {
                    Console.WriteLine($"{c.GetCardFace()} of {c.GetCardSuit()}");
                }
                Console.WriteLine("\nEnter H - Hit or S - Stand");
            }
            else
            {
                Console.WriteLine("Dealer's Hand:");
                Console.WriteLine("Value: " + AddValue(cHand));
                foreach (Card c in cHand)
                {
                    Console.WriteLine($"{c.GetCardFace()} of {c.GetCardSuit()}");
                }

                Console.WriteLine("\nPlayer's Hand:");
                Console.WriteLine("Value: " + AddValue(pHand));
                foreach (Card c in pHand)
                {
                    Console.WriteLine($"{c.GetCardFace()} of {c.GetCardSuit()}");
                }
            }
        }

        private void ChooseMove(List<Card> pHand, List<Card> cHand, DeckOfCards doc)
        {
            string uInput = "";
            while (true)
            {
                uInput = Console.ReadLine().ToUpper();
                if (uInput == "H")
                {
                    pHand.Add(doc.drawACard());
                    PrintHand(pHand, cHand, true);
                    if (AddValue(pHand) > 21)
                        break;
                }
                else if (uInput == "S")
                    break;
                else
                    Console.WriteLine("Invalid input");
            }
        }

        private void AImove(List<Card> cHand, DeckOfCards doc)
        {
            Console.WriteLine("\nDealer is drawing a card. Please wait");
            while (AddValue(cHand) < 17)
            {
                Thread.Sleep(1000);
                cHand.Add(doc.drawACard());
            }
        }

        private void CheckForWin(List<Card> pHand, List<Card> cHand)
        {
            Console.WriteLine("");
            if (AddValue(pHand) == 21)
            {
                Console.WriteLine("Blackjack! You Win!");
            }
            else if (AddValue(pHand) > 21)
            {
                Console.WriteLine("Bust!");
            }
            else if (AddValue(cHand) > 21)
            {
                Console.WriteLine("Dealer bust. You Win!");
            }
            else if (AddValue(pHand) > AddValue(cHand))
            {
                Console.WriteLine("You Win!");
            }
            else if (AddValue(cHand) > AddValue(pHand))
            {
                Console.WriteLine("You Lose.");
            }
            else if (AddValue(pHand) == AddValue(cHand))
            {
                Console.WriteLine("It's a tie.");
            }
        }
    }
}
