using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    internal class Testing
    {
        public Testing(int shuffleType)
        {
            Pack pack = new Pack();
            ShuffleAndDraw(shuffleType, Pack.pack.Count);
        }

        void ShuffleAndDraw(int shuffleType, int drawAmount) //// calls the shuffle method, draws a single card, then draws multiple cards by the draw amount and prints their values
        {
            if (Pack.shuffleCardPack(shuffleType)) // if calls the shuffle method and returns true
            {
                List<Card> dealCards = Pack.dealCard(drawAmount); // draw multiple cards showing this method works //dealCards also cals the draw method in pack
                for (int i = 0; i < dealCards.Count; i++)
                {
                    Console.Write(dealCards[i].GetValue() + " of " + dealCards[i].GetSuit() + "\n"); // print the value of all those drawn cards
                }
            }
            else
            {
                throw new ArgumentException("Shuffle method returned false value");
            }
            Console.WriteLine("///////////////////////////////////////////////////");
        }
    }
}
