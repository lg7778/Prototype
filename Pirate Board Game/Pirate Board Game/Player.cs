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

        List<TreasureCard> displayed = new List<TreasureCard>(); //List of cards displayed
        public List<TreasureCard> Displayed
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

        List<TreasureCard> hand = new List<TreasureCard>(); //List of cards in hand
        public List<TreasureCard> Hand
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

        List<ActionCard> action = new List<ActionCard>(); //List of action cards in hand
        public List<ActionCard> Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }

        int displayedScore; //Total value of displayed cards
        public int DisplayedScore
        {
            get
            {
                return displayedScore;
            }
            set
            {
                displayedScore = value;
            }
        }

        int handScore; //Total value of cards in hand
        public int HandScore
        {
            get
            {
                return handScore;
            }
            set
            {
                handScore = value;
            }
        }

        int totalScore; //Total value of all the cards
        public int TotalScore
        {
            get
            {
                return totalScore;
            }
            set
            {
                totalScore = value;
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

        //constructor
        public Player(string ID)
        {
            playerID = ID;
            displayedScore = 0;
            handScore = 0;
            totalScore = 0;
        }

        //Add a card to player's hand
        public void AddToHand(TreasureCard newCard)
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
            //flip the card
            displayed[displayed.Count - 1].FaceUp =  true;
            //Remove card from hand list
            hand.RemoveAt(index);
        }

        //Add a card to a player's displayed card directly
        public void AddToDisplayed(TreasureCard newCard)
        {
            newCard.FaceUp = true;
            displayed.Add(newCard);
        }

        //Remove a card from a player's displayed cards
        public void RemoveFromDisplayed(int index)
        {
            displayed.RemoveAt(index);
        }

        //Add a card to a player's action cards
        public void AddToAction(ActionCard newAction)
        {
            action.Add(newAction);
        }

        //Remove a card from a player's action cards
        public void RemoveFromAction(int index)
        {
            action.RemoveAt(index);
        }

        //Update the score of cards attribute
        public void UpdateScore()
        {
            int sum = 0; //initialize sum
            //add all the hands together
            for(int i = 0; i < hand.Count; i++)
            {
                sum += hand[i].Score;
            }
            //set hand score and reset sum
            handScore = sum;
            sum = 0;
            
            //add all the displayed cards together
            for(int i = 0; i < displayed.Count; i++)
            {
                sum += displayed[i].Score;
            }
            //set displayed score
            displayedScore = sum;

            //set total score
            totalScore = displayedScore + handScore;
        }
    }
}
