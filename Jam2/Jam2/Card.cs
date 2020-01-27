using System;
using System.Collections.Generic;
using System.Text;

namespace Jam2
{
    class Card
    {
        string name; //The name of the card
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        bool faceUp; //Whether the card is face up or down
        public bool FaceUp
        {
            get
            {
                return faceUp;
            }
            set
            {
                faceUp = value;
            }
        }

        int type; //type of this card, 0 = treasure, 1 = action, 2 = event, 3 = king
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

        //constructor
        public Card(string cardName)
        {
            name = cardName;
            faceUp = false; //all cards are default to face down
        }
    }

    class TreasureCard : Card //Treasure cards
    {
        int score; //face value of the card
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        
        //constructor
        public TreasureCard(string cardName, int cardValue) : base(cardName)
        {
            Type = 0;
            score = cardValue;
        }
    }

    class ActionCard : Card //Action cards
    {
        int score; //value of the card
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        //constructor
        public ActionCard(string cardName, int cardValue) : base(cardName)
        {
            Type = 1;
            score = cardValue;
        }
    }

    class EventCard : Card //Event cards
    {
        //constructor
        public EventCard(string cardName) : base(cardName)
        {
            Type = 2;
        }
    }
}
