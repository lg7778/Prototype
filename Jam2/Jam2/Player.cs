using System;
using System.Collections.Generic;
using System.Text;

namespace Jam2
{
    class Player 
    {
        string playerID; //A unique ID for each player
        public string PlayerID
        {
            get
            {
                return playerID;
            }
            set
            {
                playerID = value;
            }
        }

        List<Card> displayed = new List<Card>(); //List of cards displayed
        public List<Card> Displayed
        {
            get
            {
                return displayed;
            }
            set
            {
                displayed = value;
            }
        }

        List<Card> hand = new List<Card>(); //List of cards in hand
        public List<Card> Hand
        {
            get
            {
                return hand;
            }
            set
            {
                hand = value;
            }
        }

        int displayedValue; //Total value of displayed cards
        public int DisplayedValue
        {
            get
            {
                return displayedValue;
            }
            set
            {
                displayedValue = value;
            }
        }

        int handValue; //Total value of cards in hand
        public int HandValue
        {
            get
            {
                return handValue;
            }
            set
            {
                handValue = value;
            }
        }

        int totalValue; //Total value of all the cards
        public int TotalValue
        {
            get
            {
                return totalValue;
            }
            set
            {
                totalValue = value;
            }
        }

        bool isKing = false; //Whether the player is king for the current round
        public bool IsKing
        {
            get
            {
                return isKing;
            }
            set
            {
                isKing = value;
            }
        }

        bool given = false; //Whether the player has been given any card in the give phase for this round
        public bool Given
        {
            get
            {
                return given;
            }
            set
            {
                given = value;
            }
        }

        public Player(string ID)
        {
            playerID = ID;
            displayedValue = 0;
            handValue = 0;
            totalValue = 0;
        }

        //Add a card to player's hand
        public void AddToHand(Card newCard)
        {
            hand.Add(newCard);
        }

        //Remove a card from player's hand
        public void RemoveFromHand(int index)
        {
            hand.RemoveAt(index);
        }

        //Display a card from player's hand
        public void AddToDisplayedFromHand(int index)
        {
            //Add the card to displayed list
            displayed.Add(hand[index]);
            //Remove card from hand list
            hand.RemoveAt(index);
        }

        //Add a card to a player's displayed card directly
        public void AddToDisplayed(Card newCard)
        {
            displayed.Add(newCard);
        }

        //Update the totalValue attribute
        public void UpdateTotal()
        {
            totalValue = displayedValue + handValue;
        }
    }
}
