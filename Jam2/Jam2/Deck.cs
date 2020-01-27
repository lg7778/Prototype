using System;
using System.Collections.Generic;
using System.Text;

namespace Jam2
{
    class TreasureDeck
    {
        int typeOfDeck; //Type of Deck, 0 = treasure, 1 = action, 2 = event, 3 = abandoned treasure, 4 = abandoned action, 5 = abandoned event
        public int TypeOfDeck
        {
            get
            {
                return typeOfDeck;
            }
            set
            {
                typeOfDeck = value;
            }
        }

        List<TreasureCard> cards = new List<TreasureCard>(); //List of cards
        public List<TreasureCard> Cards
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
        public TreasureDeck(int deckType)
        {
            typeOfDeck = deckType;
        }

        //Add card to deck
        public void AddCard(TreasureCard newCard)
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

    class EventDeck
    {
        int typeOfDeck; //Type of Deck, 0 = treasure, 1 = action, 2 = event, 3 = abandoned treasure, 4 = abandoned action, 5 = abandoned event
        public int TypeOfDeck
        {
            get
            {
                return typeOfDeck;
            }
            set
            {
                typeOfDeck = value ;
            }
        }

        List<EventCard> cards = new List<EventCard>(); //List of cards
        public List<EventCard> Cards
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
        public EventDeck(int deckType)
        {
            typeOfDeck = deckType;
        }

        //Add card to deck
        public void AddCard(EventCard newCard)
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

    class ActionDeck
    {
        int typeOfDeck; //Type of Deck, 0 = treasure, 1 = action, 2 = event, 3 = abandoned treasure, 4 = abandoned action, 5 = abandoned event
        public int TypeOfDeck
        {
            get
            {
                return typeOfDeck;
            }
            set
            {
                typeOfDeck = value;
            }
        }

        List<ActionCard> cards = new List<ActionCard>(); //List of cards
        public List<ActionCard> Cards
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
        public ActionDeck(int deckType)
        {
            typeOfDeck = deckType;
        }

        //Add card to deck
        public void AddCard(ActionCard newCard)
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