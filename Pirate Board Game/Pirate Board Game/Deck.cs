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
        public void Shuffle()
        {
            //Copy the current deck
            List<TreasureCard> oldDeck = cards;
            //Prepare new deck
            List<TreasureCard> newDeck = new List<TreasureCard>();
            //Prepare a random number
            Random rnd = new Random();

            //Add each card from old deck to random place in new deck
            while(oldDeck.Count != 0)
            {
                if(newDeck.Count == 0)
                {
                    newDeck.Add(oldDeck[0]);
                    oldDeck.RemoveAt(0);
                }
                else
                {
                    newDeck.Insert(rnd.Next(0, newDeck.Count), oldDeck[0]);
                    oldDeck.RemoveAt(0);
                }
            }
            cards = newDeck;
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
        public void Shuffle()
        {
            //Copy the current deck
            List<EventCard> oldDeck = cards;
            //Prepare new deck
            List<EventCard> newDeck = new List<EventCard>();
            //Prepare a random number
            Random rnd = new Random();

            //Add each card from old deck to random place in new deck
            while (oldDeck.Count != 0)
            {
                if (newDeck.Count == 0)
                {
                    newDeck.Add(oldDeck[0]);
                    oldDeck.RemoveAt(0);
                }
                else
                {
                    newDeck.Insert(rnd.Next(0, newDeck.Count), oldDeck[0]);
                    oldDeck.RemoveAt(0);
                }
            }
            cards = newDeck;
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
        public void Shuffle()
        {
            //Copy the current deck
            List<ActionCard> oldDeck = cards;
            //Prepare new deck
            List<ActionCard> newDeck = new List<ActionCard>();
            //Prepare a random number
            Random rnd = new Random();

            //Add each card from old deck to random place in new deck
            while (oldDeck.Count != 0)
            {
                if (newDeck.Count == 0)
                {
                    newDeck.Add(oldDeck[0]);
                    oldDeck.RemoveAt(0);
                }
                else
                {
                    newDeck.Insert(rnd.Next(0, newDeck.Count), oldDeck[0]);
                    oldDeck.RemoveAt(0);
                }
            }
            cards = newDeck;
        }

    }
}