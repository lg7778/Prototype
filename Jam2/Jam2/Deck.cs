using System;
using System.Collections.Generic;
using System.Text;

namespace Jam2
{
    class Deck
    {
        int type; //Type of Deck, 0 = treasure, 1 = action, 2 = event, 3 = abandoned treasure, 4 = abandoned action, 5 = abandoned event, 6 = king
        public int Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        List<Card> cards = new List<Card>(); //List of cards
        public List<Card> Cards
        {
            get
            {
                return cards;
            }
            set
            {
                cards = value;
            }
        }

        //constructor
        public Deck(int deckType)
        {
            type = deckType;
        }

        //Add card to deck
        public void AddCard(Card newCard)
        {
            cards.Add(newCard);
        }

        //Remove card from deck
        public void RemoveCard(int index)
        {
            cards.RemoveAt(index);
        }

        //Shuffle the deck to be in random order
        public void shuffle()
        {

        }

    }
}