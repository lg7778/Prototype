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
    }
}
