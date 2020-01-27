using System;
using System.Collections.Generic;

namespace Jam2
{
    class System //This class holds all the game rules
    {
        enum Round //Which round the game is currently at
        {
            Initialize, //Initialize the game, shuffle cards, deal initial cards to each player
            RoundOne, //First round of the game
            RoundTwo, //Second round of the game
            RoundThree //Third and final round of the game
        }
        enum Phase //Which phase the game is currently at
        {
            Setup, //value = 0, setup phase where king is selected
            Draw, //value =1, draw phase where each player draw cards for the round
            Event, //value = 2, event phase where a event card is draw and apply to all players
            Action, //value = 3, action phase where each player in turn would choose to play action cards or skip 
            Give //value = 4, give phase where each player in turn gives one of their cards to another player
        }
        enum CardTypes //All types of card
        {
            Treasure, //value = 0, from treasure deck
            Action, //value = 1, from action deck
            Event, //value = 2, from event deck
            King //value = 3, the king card
        }

        enum DeckTypes //All types of deck
        {
            Treasure,
            TreasureAbandon,
            Action,
            ActioinAbandon,
            Event,
            EventAbandon,
            King
        }

        List<Player> players = new List<Player>(); //A list that holds all the players in the game
        Player currentPlayer; //The player that is currently in play

        Deck treasureDeck; //Deck that holds all avaliable treasure cards
        Deck tAbondanedDeck; //Deck that holds all the treasure cards that has been abandoned

        Deck actionDeck; //Deck that holds all avaliable action cards
        Deck aAbondanedDeck; //Deck that holds all the action cards that has been abandoned

        Deck eventDeck; //Deck that holds all avaliable event cards
        Deck eAbondanedDeck; //Deck that holds all the event cards that has been abandoned

        //Hold the main game loop
        static void Main(string[] args)
        {
            
        }

        //Method for the setup phase, during this phase, a new king has been selected based on total displayed value, and the order of player list is changed to start with king and go clockwise
        public void SetUpPhase()
        {
            Player king; //The player that is king of the round
            List<Player> kings = new List<Player>(); //If there are multiple player with the same highest displayed value, this list holds all of those candidates of king
            bool multipleKing = false; //Whether there are multiple player with the same highest displayed value, default to be false
            int kingIndex = 0; //The index of the king in the current player list

            //Set default king
            if (players.Count != 0)
            {
                king = players[0]; //Set king to be the first player
            }
            else
            {
                return; //If there are no players in play, this method can't be called
            }

            //Compare each player at play with the current king, update the king if find a player with higher displayed value
            for(int i = 0; i < players.Count; i++)
            {  
                //When find a player with higher displayed value, set this player to be new king
                if(players[i].DisplayedValue > king.DisplayedValue)
                {
                    king = players[i];
                }
            }

            //See if there are multiple player with the same displayed value
            for(int i = 0; i < players.Count; i++)
            {
                //When find player with same displayed value as king, set multipleKing to true and add that player to candidate list for the king
                if(players[i].DisplayedValue == king.DisplayedValue)
                {
                    multipleKing = true;
                    kings.Add(players[i]);
                }
            }

            //If there are multiple candidate for the king, use the tie-rule to resolve
            if(multipleKing == true)
            {
                king = SelectKing(kings);
            }

            //Set the king player's IsKing value to true, set all other players' value to false, and add non-king player to the end of list
            for (int i = 0; i < players.Count; i++)
            {
                //When the king player is found, change it's isKing value to true
                if(king.PlayerID.Equals(players[i].PlayerID))
                {
                    players[i].IsKing = true;
                    kingIndex = i;
                    break; //Exit from the loop when king is found, prevent players after king to be added to the back of list
                }
                //When a non-king player is found
                else
                {
                    //Set isKing value to false
                    players[i].IsKing = false;
                    //Add the player to the end of list
                    players.Add(players[i]);
                }
            }

            //Remove duplicated players in the list that is currently in front of the king
            players = players.GetRange(kingIndex, players.Count-kingIndex);
        }

        //When there are multiple candidate for the king, this method is called to select a king from all the candidates
        public Player SelectKing(List<Player> candidates)
        {
            //A temporary solution, will write later
            return candidates[0];
            //bool done = false; //Indicate whether the selection process is completed
            //while(!done)
            //{
                //List<Card> tempCards;
                //Draw a treasure card for each player
                //for(int i = 0; i < candidates.Count; i++)
                //{
                    
                //}
            //}
        }

        //The draw phase of each round, each player draw 1 card from the treasure deck and 1 card from the action deck
        public void DrawPhase() 
        {
            //Draw treasure cards for each player
            for(int i = 0; i < players.Count; i++)
            {
                //Add the top card on treasure deck to player hand
                //players[i]
            }
        }

        //The event phase of each round, draw 1 event card and apply to all players
        public void EventPhase()
        {

        }

        //The action phase of each round, each player can play their action cards
        public void ActionPhase()
        {

        }

        //The give phase of each round, each player gives a card to another player
        public void Give()
        {
            //Set the Given attribute of each player to be false
            for(int i = 0; i < players.Count; i++)
            {
                players[i].Given = false;
            }
        }

    }
}
