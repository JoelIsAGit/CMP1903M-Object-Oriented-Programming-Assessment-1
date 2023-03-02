using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        static public List<Card> pack;

        public Pack()
        {
            pack = new List<Card>();
            for (int suit = 1; suit < 5; suit++)
            {
                for (int value = 1; value < 14; value++)
                {
                    pack.Add(new Card(value, suit));
                }
            }
        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            switch (typeOfShuffle)
            {
                case 0:
                    return FisherYatesShuffle();
                case 1:
                    return RiffleShuffle();
                case 2:
                    return true;
                default:
                    throw new ArgumentException(typeOfShuffle.ToString() + "not a type of shuffle");
            }
            //Shuffles the pack based on the type of shuffle

        }
        public static Card deal() // take the next card in the deck, remove and send it
        {
            if (pack.Count > 0)
            {
                Card dealCard = pack[0];
                pack.RemoveAt(0);
                pack.Add(dealCard); // put drawn card at end of deck
                return dealCard;
            }
            else
            {
                throw new ArgumentException("no cards left to draw");
            }
        }
        public static List<Card> dealCard(int amount)
        {
            List<Card> dealCards = new List<Card>(); /// use deal to get the next card and add it to an array to return multiple cards
            for (int i = 0; i < amount; i++)
            {
                dealCards.Add(deal());
            }
            return dealCards;
        }

        static bool FisherYatesShuffle() //////// The Richard Durstenfeld Fisher-Yates Shuffle
        {
            Random random = new Random();
            for (int i = pack.Count-1; i > 1; i--) /////////////// For the size of the deck of cards, decreasing
            {
                int sortPosition = random.Next(i);
                Card sortCard = pack[sortPosition]; // Get a random card in the pack
                Card swapCard = pack[i];            // Get the last card in the pack
                pack[i] = sortCard;                 ////////////// swap the two selected cards
                pack[sortPosition] = swapCard;      //////////////
            }
            return true;
        }

        static bool RiffleShuffle()
        {
            Random random = new Random();
            List<Card> SplitDeck1 = new List<Card>();
            List<Card> SplitDeck2 = new List<Card>();
            for (int o = 0; o < 7; o++) /////////////// The Gilbert-Shannon-Reeds model suggests shuffling seven times
            {
                int deckSplitPoint = 0;
                List<bool> flips = new List<bool>();
                List<Card> newPack = new List<Card>();
                for (int i = 0; i < pack.Count; i++)////// Flip a coin to get deck split point and generate order in which split decks are added back in
                {
                    if (random.Next(2) == 1)
                    {
                        flips.Add(true);
                        SplitDeck1.Add(pack[deckSplitPoint]);
                        deckSplitPoint++;
                    }
                    else
                    {
                        flips.Add(false);
                    }
                }///////////////////////
                for (int i = deckSplitPoint; i < pack.Count; i++)////////////// Add remaining cards to second split deck pack
                {
                    SplitDeck2.Add(pack[i]);
                }///////////////////////////////
                for (int i = 0; i < flips.Count; i++)////////// Add a card into the new pack using the flips list to decide the order
                {
                    if (flips[i])
                    {
                        newPack.Add(SplitDeck1[0]);
                        SplitDeck1.RemoveAt(0);
                    }
                    else
                    {
                        newPack.Add(SplitDeck2[0]);
                        SplitDeck2.RemoveAt(0);
                    }
                }////////////////////////
                pack = newPack;
            }
            return true;
        }
    }
}
