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
            Treasure, //value = 0, treasure deck
            Action, //value = 1, action deck
            Event, //value = 2, event cards
            TreasureAbandon, //value = 3, abandoned cards from treasure deck
            ActionAbandon, //value = 4, abandoned cards from action deck
            EventAbandon, //value = 5, abandoned cards from event deck
        }

        List<Player> players = new List<Player>(); //A list that holds all the players in the game
        Player currentPlayer; //The player that is currently in play

        TreasureDeck treasureDeck; //Deck that holds all avaliable treasure cards
        TreasureDeck tAbondanedDeck; //Deck that holds all the treasure cards that has been abandoned

        ActionDeck actionDeck; //Deck that holds all avaliable action cards
        ActionDeck aAbondanedDeck; //Deck that holds all the action cards that has been abandoned

        EventDeck eventDeck; //Deck that holds all avaliable event cards
        EventDeck eAbondanedDeck; //Deck that holds all the event cards that has been abandoned

        //The one and only king card
        Card kingCard = new Card("King");

        //Create singleton
        private static System theSystem = new System();

        //Hold the main game loop
        static void Main(string[] args)
        {
            //Initialize all the variables

            //Default to be 4 player-game, change that to due to input player number
            theSystem.AddPlayer(new Player("PlayerOne"));
            theSystem.AddPlayer(new Player("PlayerTwo"));
            theSystem.AddPlayer(new Player("PlayerThree"));
            theSystem.AddPlayer(new Player("PlayerFour"));

            //Set start player to be the first player added
            theSystem.currentPlayer = theSystem.players[0];

            //Initialize decks
            theSystem.treasureDeck = new TreasureDeck(0);
            theSystem.actionDeck = new ActionDeck(1);
            theSystem.eventDeck = new EventDeck(2);
            theSystem.tAbondanedDeck = new TreasureDeck(3);
            theSystem.aAbondanedDeck = new ActionDeck(4);
            theSystem.eAbondanedDeck = new EventDeck(5);

            //Add treasure cards
            theSystem.treasureDeck.AddCard(new TreasureCard("Coin", 1));
            theSystem.treasureDeck.AddCard(new TreasureCard("Coin", 1));
            theSystem.treasureDeck.AddCard(new TreasureCard("Coin", 1));
            theSystem.treasureDeck.AddCard(new TreasureCard("Coin", 1));
            theSystem.treasureDeck.AddCard(new TreasureCard("Coin", 1));
            theSystem.treasureDeck.AddCard(new TreasureCard("Coin", 1));
            theSystem.treasureDeck.AddCard(new TreasureCard("Coin", 1));
            theSystem.treasureDeck.AddCard(new TreasureCard("Coin", 1));
            theSystem.treasureDeck.AddCard(new TreasureCard("Coin", 1));
            theSystem.treasureDeck.AddCard(new TreasureCard("Coin", 1));

            theSystem.treasureDeck.AddCard(new TreasureCard("Gem", 5));
            theSystem.treasureDeck.AddCard(new TreasureCard("Gem", 5));
            theSystem.treasureDeck.AddCard(new TreasureCard("Gem", 5));
            theSystem.treasureDeck.AddCard(new TreasureCard("Gem", 5));
            theSystem.treasureDeck.AddCard(new TreasureCard("Gem", 5));
            theSystem.treasureDeck.AddCard(new TreasureCard("Gem", 5));
            theSystem.treasureDeck.AddCard(new TreasureCard("Gem", 5));
            theSystem.treasureDeck.AddCard(new TreasureCard("Gem", 5));
            theSystem.treasureDeck.AddCard(new TreasureCard("Gem", 5));
            theSystem.treasureDeck.AddCard(new TreasureCard("Gem", 5));

            theSystem.treasureDeck.AddCard(new TreasureCard("Relic", 10));
            theSystem.treasureDeck.AddCard(new TreasureCard("Relic", 10));
            theSystem.treasureDeck.AddCard(new TreasureCard("Relic", 10));
            theSystem.treasureDeck.AddCard(new TreasureCard("Relic", 10));
            theSystem.treasureDeck.AddCard(new TreasureCard("Relic", 10));
            theSystem.treasureDeck.AddCard(new TreasureCard("Relic", 10));
            theSystem.treasureDeck.AddCard(new TreasureCard("Relic", 10));
            theSystem.treasureDeck.AddCard(new TreasureCard("Relic", 10));
            theSystem.treasureDeck.AddCard(new TreasureCard("Relic", 10));
            theSystem.treasureDeck.AddCard(new TreasureCard("Relic", 10));

            theSystem.treasureDeck.AddCard(new TreasureCard("Chest", 20));
            theSystem.treasureDeck.AddCard(new TreasureCard("Chest", 20));
            theSystem.treasureDeck.AddCard(new TreasureCard("Chest", 20));
            theSystem.treasureDeck.AddCard(new TreasureCard("Chest", 20));
            theSystem.treasureDeck.AddCard(new TreasureCard("Chest", 20));
            theSystem.treasureDeck.AddCard(new TreasureCard("Chest", 20));
            theSystem.treasureDeck.AddCard(new TreasureCard("Chest", 20));
            theSystem.treasureDeck.AddCard(new TreasureCard("Chest", 20));
            theSystem.treasureDeck.AddCard(new TreasureCard("Chest", 20));
            theSystem.treasureDeck.AddCard(new TreasureCard("Chest", 20));

            //Add action cards
            theSystem.actionDeck.AddCard(new ActionCard("Draw 1 card from the treasure deck(+5)", 5));
            theSystem.actionDeck.AddCard(new ActionCard("Draw 1 card from the treasure deck(+5)", 5));
            theSystem.actionDeck.AddCard(new ActionCard("Draw 1 card from the treasure deck(+5)", 5));
            theSystem.actionDeck.AddCard(new ActionCard("Draw 1 card from the treasure deck(+5)", 5));
            theSystem.actionDeck.AddCard(new ActionCard("Draw 1 card from the treasure deck(+5)", 5));
            theSystem.actionDeck.AddCard(new ActionCard("Draw 1 card from the treasure deck(+5)", 5));
            theSystem.actionDeck.AddCard(new ActionCard("Draw 1 card from the treasure deck(+5)", 5));
            theSystem.actionDeck.AddCard(new ActionCard("Draw 1 card from the treasure deck(+5)", 5));
            theSystem.actionDeck.AddCard(new ActionCard("Draw 1 card from the treasure deck(+5)", 5));
            theSystem.actionDeck.AddCard(new ActionCard("Draw 1 card from the treasure deck(+5)", 5));
            theSystem.actionDeck.AddCard(new ActionCard("Draw 1 card from the treasure deck(+5)", 5));


            theSystem.treasureDeck.Shuffle();

            theSystem.Initialize();

            foreach (Player player in theSystem.players)
            {

                Console.WriteLine("You are " + player.PlayerID + "\r\n" +
                    "You currently have : ");
                for (int i = 0; i < player.Hand.Count; i++)
                {
                    Console.WriteLine(player.Hand[i].Name);
                }

                bool found = false;
                int index = 0;
                while(!found)
                {
                    player.UpdateScore();
                    string input;
                    Console.WriteLine("You current score is : " + player.HandScore);
                    Console.WriteLine("Which card do you want to display?");
                    input = Console.ReadLine();
                    for(int i = 0; i < player.Hand.Count; i++)
                    {
                        if (player.Hand[i].Name.Equals(input))
                        {
                            found = true;
                            index = i;
                            break;
                        }
                    }
                }

                player.AddToDisplayedFromHand(index);
                player.UpdateScore();
                Console.WriteLine("You are done with your turn, please give seat for next player" + "\r\n" +
                    "Press Any Key to Continue");
                Console.ReadLine();
                Console.Clear();
            }

            foreach (Player player in theSystem.players)
            {
                Console.WriteLine(player.PlayerID + " displayed : ");
                foreach(TreasureCard card in player.Displayed)
                {
                    Console.WriteLine(card.Name);
                }
            }

            for(int i = 0; i < 3; i++)
            {
                int round = i + 1;
                Console.WriteLine("\r\n" + "It is now round " + round);
                foreach(Player player in theSystem.players)
                {
                    player.UpdateScore();
                    Console.WriteLine("\r\n" + player.PlayerID + " currently displayed : ");
                    foreach(TreasureCard card in player.Hand)
                    {
                        Console.WriteLine(card.Name);
                    }
                    Console.WriteLine("The displayed score for " + player.PlayerID + " is " + player.DisplayedScore);
                }
                theSystem.SetUpPhase();
                theSystem.DrawPhase();
                theSystem.GivePhase();
            }

            Console.WriteLine("\r\n" + "It is now the end of game");
            foreach(Player player in theSystem.players)
            {
                player.UpdateScore();
                Console.WriteLine(player.PlayerID + " have a total score of " + player.TotalScore);
            }

        }

        public void Initialize()
        {
            //Draw 2 treasure card and 1 action card for each player
            for (int i = 0; i < players.Count; i++)
            {
                //Add the top card from treasure deck to player hand
                players[i].AddToHand(treasureDeck.Cards[0]);
                //Add the card to abandoned deck
                tAbondanedDeck.AddCard(treasureDeck.Cards[0]);
                //Remove the card from treasure deck
                treasureDeck.RemoveCard(0);

                //Add the top card from treasure deck to player hand
                players[i].AddToHand(treasureDeck.Cards[0]);
                //Add the card to abandoned deck
                tAbondanedDeck.AddCard(treasureDeck.Cards[0]);
                //Remove the card from treasure deck
                treasureDeck.RemoveCard(0);

                //Add the top card from action deck to player hand
                //players[i].AddToAction(actionDeck.Cards[0]);
                //Add the card to abandoned deck
                //aAbondanedDeck.AddCard(actionDeck.Cards[0]);
                //Remove the card from action deck
                //actionDeck.RemoveCard(0);
            }
        }
        public void AddPlayer(Player newPlayer)
        {
            players.Add(newPlayer);
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
            for (int i = 0; i < players.Count; i++)
            {
                //When find a player with higher displayed value, set this player to be new king
                if (players[i].DisplayedScore > king.DisplayedScore)
                {
                    king = players[i];
                }
            }

            //See if there are multiple player with the same displayed value
            for (int i = 0; i < players.Count; i++)
            {
                //When find player with same displayed value as king, set multipleKing to true and add that player to candidate list for the king
                if (players[i].DisplayedScore == king.DisplayedScore)
                {
                    multipleKing = true;
                    kings.Add(players[i]);
                }
            }

            //If there are multiple candidate for the king, use the tie-rule to resolve
            if (multipleKing == true)
            {
                king = SelectKing(kings);
            }

            //Set the king player's IsKing value to true, set all other players' value to false, and add non-king player to the end of list
            for (int i = 0; i < players.Count; i++)
            {
                //When the king player is found, change it's isKing value to true
                if (king.PlayerID.Equals(players[i].PlayerID))
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
            players = players.GetRange(kingIndex, players.Count - kingIndex);
            Console.WriteLine("\r\n" + players[0].PlayerID + " is King for the round");
            Console.WriteLine(players[0].PlayerID + " please have a seat, it's now your turn");
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadLine();
            Console.Clear();
        }

        //When there are multiple candidate for the king, this method is called to select a king from all the candidates
        public Player SelectKing(List<Player> candidates)
        {
            List<Player> currentCandidates = candidates; //List of player that are still candidates of king
            bool done = false; //Indicate whether the selection process is completed
            Player kingPlayer = currentCandidates[0]; //default value for king

            while (!done)
            {
                List<TreasureCard> tempCards =  new List<TreasureCard>();//A temp list that store cards used in comparison
                TreasureCard highCard; //Treasure card with highest value in comparison
                int highIndex = 0; //index for the high card
                bool isDraw =  false; //Whether the comparison is draw and need another round of comparison
                List<Player> newCandidates = new List<Player>(); //List of new candidates if a draw occured

                //Draw a treasure card for each player
                for(int i = 0; i < currentCandidates.Count; i++)
                {
                    //Add card to temp list
                    tempCards.Add(treasureDeck.Cards[0]);
                    //Add card to abandoned treasure deck
                    tAbondanedDeck.AddCard(treasureDeck.Cards[0]);
                    //Remove card from treasure deck
                    treasureDeck.RemoveCard(0);
                }

                highCard = tempCards[0]; //set current highest to first card
                //find the treasure card that has the largest value
                for(int i = 0; i < tempCards.Count; i++)
                {
                    //if a higher card is found, replace high card
                    if(tempCards[i].Score > highCard.Score)
                    {
                        highCard = tempCards[i];
                        highIndex = i;
                    }
                }

                //Add the player that ownes the high card into the new candidates list
                newCandidates.Add(currentCandidates[highIndex]);
                
                //determine whether there are cards with value equal to high card
                for(int i = 0; i < tempCards.Count; i++)
                {
                    //if a player with card value equal to high value card is found, add this players to new round of comparison
                    if (i != highIndex)
                    {
                        if (tempCards[i].Score == highCard.Score)
                        {
                            newCandidates.Add(currentCandidates[i]);
                            isDraw = true;
                        }
                    }
                }

                //If a draw occurs, continue with the new candidate list, otherwise a king is selected
                if(isDraw)
                {
                    currentCandidates = newCandidates;
                    continue;
                }
                else
                {
                    //Player with high card become king
                    kingPlayer = currentCandidates[highIndex];
                    //exit loop since king is found
                    break;
                }
            }

            //return the player that holdes the high card
            return kingPlayer;
        }

        //The draw phase of each round, each player draw 1 card from the treasure deck and 1 card from the action deck
        public void DrawPhase() 
        {
            //Draw 1 treasure card and 1 action card for each player
            for(int i = 0; i < players.Count; i++)
            {
                //Add the top card from treasure deck to player hand
                players[i].AddToHand(treasureDeck.Cards[0]);
                //Add the card to abandoned deck
                tAbondanedDeck.AddCard(treasureDeck.Cards[0]);
                //Remove the card from treasure deck
                treasureDeck.RemoveCard(0);

                //Add the top card from action deck to player hand
                //players[i].AddToAction(actionDeck.Cards[0]);
                //Add the card to abandoned deck
                //aAbondanedDeck.AddCard(actionDeck.Cards[0]);
                //Remove the card from action deck
                //actionDeck.RemoveCard(0);
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
        public void GivePhase()
        {
            string input;
            //Set the Given attribute of each player to be false
            for(int i = 0; i < players.Count; i++)
            {
                players[i].Given = false;
            }

            //Set current player to be the first player
            //currentPlayer = players[0];

            for(int i = 0; i < players.Count; i++)
            {
                bool cardFound = false; //whether a card to give is found
                bool playerFound = false; //whether a player to give is found
                TreasureCard theCard = currentPlayer.Displayed[0]; //the card that is selected by the player
                int target = 0; //the target player
                int left; //player to the left
                int right; //player to the right
                int opposite; //player to the opposite direction

                foreach(Player player in players)
                {
                    player.UpdateScore();
                }
                
                //find left player
                //when current player is last player
                if (i == 3)
                {
                    left = 0;
                }
                //get left player
                else
                {
                    left = i + 1;
                }

                //find right player
                //when current player is first player
                if (i == 0)
                {
                    right = 3;
                }
                //get right player
                else
                {
                    right = i - 1;
                }

                //find opposite player
                //when current player is first 2 player
                if (i < 2)
                {
                    opposite = i + 2;
                }
                //when current player is last 2 players
                else
                {
                    opposite = i - 2;
                }

                //Set current player
                //currentPlayer = players[i];

                //Display opponent information
                //Write left player displayed cards
                Console.WriteLine("\r\n" + "The player on your left is : " + players[left].PlayerID + "\r\n" +
                    "This player have displayed cards as following : ");
                for(int j = 0; j < players[left].Displayed.Count; j++)
                {
                    Console.WriteLine(players[left].Displayed[j].Name);
                }

                //Write right player displayed cards
                Console.WriteLine("\r\n" + "The player on your right is : " + players[right].PlayerID + "\r\n" +
                    "This player have displayed cards as following : ");
                for (int j = 0; j < players[right].Displayed.Count; j++)
                {
                    Console.WriteLine(players[right].Displayed[j].Name);
                }

                //Write opposite player displayed cards
                Console.WriteLine("\r\n" + "The player on your opposite is : " + players[opposite].PlayerID + "\r\n" +
                    "This player have displayed cards as following : ");
                for (int j = 0; j < players[opposite].Displayed.Count; j++)
                {
                    Console.WriteLine(players[opposite].Displayed[j].Name);
                }

                //Display current player information
                //Write player ID
                Console.WriteLine("\r\n" + "Your Player Id is : " + players[i].PlayerID);
                //Write player displayed cards
                Console.WriteLine("Your displayed cards are : ");
                for(int j = 0; j < players[i].Displayed.Count; j++)
                {
                    Console.WriteLine(players[i].Displayed[j].Name);
                }
                
                //Write player hand cards
                Console.WriteLine("Cards in your hands are : " );
                for (int j = 0; j < players[i].Hand.Count; j++)
                {
                    Console.WriteLine(players[i].Hand[j].Name);
                }

                Console.WriteLine("Your current score is : " + players[i].TotalScore);

                //look for card to give
                while(!cardFound)
                {
                    //Let player select card to give
                    Console.WriteLine("\r\n" + "Which card do you want to give?" + "\r\n"
                        + "1. Card from my displayed cards" + "\r\n"
                        + "2. Card from my hand"
                        );
                    //Get answer from player
                    input =  Console.ReadLine();
                    //Ask which specific card to give
                    if (input == "1")
                    {
                        //Let player choose card in displayed cards
                        Console.WriteLine("\r\n" + "Which card do you want to give?");
                        //Get answer from player
                        string temp = Console.ReadLine();
                        //find card with name correspond to user input
                        for (int j = 0; j < players[i].Displayed.Count; j++)
                        {
                            if (players[i].Displayed[j].Name.Equals(temp))
                            {
                                cardFound = true;
                                theCard = players[i].Displayed[j];
                                players[i].RemoveFromDisplayed(j);
                            }
                        }
                        //if such a card exist, exit the loop
                        if (cardFound == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Your selection is invalid, please try again");
                            continue;
                        }
                    }
                    else if(input == "2")
                    {
                        //Let player choose card in hand
                        Console.WriteLine("\r\n" + "Which card do you want to give?");
                        //Get answer from player
                        string temp = Console.ReadLine();
                        //find card with name correspond to user input
                        for (int j = 0; j < players[i].Hand.Count; j++)
                        {
                            if (players[i].Hand[j].Name.Equals(temp))
                            {
                                cardFound = true;
                                theCard = players[i].Hand[j];
                            }
                        }
                        //if such a card exist, exit the loop
                        if (cardFound == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Your selection is invalid, please try again");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your selection is invalid, please try again");
                        continue;
                    }
                }

                //look for target player
                while(!playerFound)
                {
                    //let player select target to give
                    Console.WriteLine("\r\n" + "Which player do you want to give this card?" + "\r\n"
                        + "1. Player to the left (" + players[left].PlayerID + "with a displayed score of " + players[left].DisplayedScore + ")" + "\r\n"
                        + "2. Player to the right (" + players[right].PlayerID + "with a displayed score of " + players[right].DisplayedScore + ")" + "\r\n"
                        + "3. Player to the opposite (" + players[opposite].PlayerID + "with a displayed score of " + players[opposite].DisplayedScore + ")"
                        );
                    //get player answer
                    input = Console.ReadLine();
                    if(input == "1")
                    {
                        //get left player
                        if(!players[left].Given)
                        {
                            target = left;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Your selection is invalid, please try again");
                            continue;
                        }

                    }
                    else if(input == "2")
                    {
                        //get right player
                        if (!players[right].Given)
                        {
                            target = right;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Your selection is invalid, please try again");
                            continue;
                        }
                    }
                    else if(input == "3")
                    {
                        //get opposite player
                        if (!players[opposite].Given)
                        {
                            target = opposite;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Your selection is invalid, please try again");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your selection is invalid, please try again");
                        continue;
                    }
                }
                GiveCardTo(theCard, target);
                if (players[i].Displayed.Count == 0)
                {
                    cardFound = false;
                    while(!cardFound)
                    {
                        Console.WriteLine("\r\n" + "Your displayed card area is currently empty, please choose another card from hand to display");
                        Console.WriteLine("Cards in your hands are : ");
                        for (int j = 0; j < players[i].Hand.Count; j++)
                        {
                            Console.WriteLine(players[i].Hand[j].Name);
                        }
                        input = Console.ReadLine();
                        if(input != null)
                        {
                            for(int j = 0; j < players[i].Hand.Count; i++)
                            {
                                if(players[i].Hand[j].Name.Equals(input))
                                {
                                    players[i].AddToDisplayedFromHand(j);
                                    cardFound = true;
                                    break;
                                }
                            }
                        }
                       
                    }
                }
                players[i].UpdateScore();
                Console.WriteLine("Your current score is : " + players[i].TotalScore);
                Console.WriteLine("You are done with your turn, please give seat for next player" + "\r\n" +
                    "Press Any Key to Continue");
                Console.ReadLine();
                Console.Clear();
            }
        }

        //Give a card from hand to the target player
        public void GiveCardTo(TreasureCard theCard, int target)
        {
            if(theCard.FaceUp)
            {
                players[target].AddToDisplayed(theCard);
                players[target].Given = true;
            }
            else
            {
                players[target].AddToHand(theCard);
                players[target].Given = true;
            }
        }

    }
}
