using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        List<Card> pack;

        public Pack()
        {
            //Initialise the card pack here
            pack = new List<Card>();
            for (int i = 0; i < 51; i++)
            {
                Card newCard = new Card();
                newCard.Value = (i % 13) + 1;  
                newCard.Suit = (i/ 13) + 1;
                pack.Add(newCard);
                //l
            }
        }

        public bool shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle
            if (typeOfShuffle == 1)
            {
                Random rnd = new Random();

                for (int i = 51; i >= 0; i--)
                {
                    int j = rnd.Next(i + 1);
                    Card temp = pack[i];
                    pack[i] = pack[j];
                    pack[j] = temp;
                }

                return true;
            }
            if (typeOfShuffle == 2)
            {
                int halfDeck = pack.Count / 2;
                List<Card> cards1 = pack.GetRange(0, 26);
                List<Card> cards2 = pack.GetRange(27, 51);
                List<Card> newlist = new List<Card>();

                while (cards1.Count == 0)
                {
                    Random rand = new Random();

                    if (rand.NextDouble() == 0)
                    {
                        newlist.Add(cards1[cards1.Count - 1]);
                        cards1.RemoveAt(cards1.Count - 1);
                    }
                    else
                    {
                        newlist.Add(cards2[cards1.Count - 1]);
                        cards2.RemoveAt(cards2.Count - 1);  
                    }
                }
                return true;
            }
            if (typeOfShuffle == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Card deal()
        {
            //Deals one card
            Card card = pack[pack.Count - 1];
            pack.RemoveAt(pack.Count - 1);
            return card;
        }
        public List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            List<Card> cards = pack.GetRange(amount, pack.Count - 1);
            pack.RemoveRange(amount, pack.Count - 1);
            return cards;
        }
    }
}
