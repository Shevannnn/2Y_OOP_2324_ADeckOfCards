using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class Hand
    {
        private List<Card> cards = new List<Card>();

        public Hand(int num, DeckOfCards deck)
        {
            for (int i = 0; i < num; i++)
            {
                Card drawnCard = deck.drawACard();
                cards.Add(drawnCard);
            }
        }

        private List<Card> GetCards()
        {
            return cards;
        }

        public void AddToHand(DeckOfCards deck)
        {
            Card drawnCard = deck.drawACard();
            cards.Add(drawnCard);
        }

        public int AddValue()
        {
            int value = 0;
            int aceCount = 0;

            foreach (Card c in cards)
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

        public void PrintHand(Hand pHand, Hand dHand, bool pTurn)
        {
            Console.Clear();
            List<Card> pCards = pHand.GetCards();
            List<Card> dCards = dHand.GetCards();

            if (pTurn)
            {
                Console.WriteLine("Dealer's Hand:");
                Console.WriteLine("Value: ?");
                Console.WriteLine($"{dCards[0].GetCardFace()} of {dCards[0].GetCardSuit()}");
                Console.WriteLine("[Face Down Card]\n");

                Console.WriteLine("Player's Hand:");
                Console.WriteLine("Value: " + pHand.AddValue());
                foreach (Card c in pCards)
                {
                    Console.WriteLine($"{c.GetCardFace()} of {c.GetCardSuit()}");
                }
                Console.WriteLine("\nEnter H - Hit or S - Stand");
            }
            else
            {
                Console.WriteLine("Dealer's Hand:");
                Console.WriteLine("Value: " + dHand.AddValue());
                foreach (Card c in dCards)
                {
                    Console.WriteLine($"{c.GetCardFace()} of {c.GetCardSuit()}");
                }

                Console.WriteLine("\nPlayer's Hand:");
                Console.WriteLine("Value: " + pHand.AddValue());
                foreach (Card c in pCards)
                {
                    Console.WriteLine($"{c.GetCardFace()} of {c.GetCardSuit()}");
                }
            }
        }

    }
}
