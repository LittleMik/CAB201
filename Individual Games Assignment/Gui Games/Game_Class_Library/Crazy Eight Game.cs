using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Game_Class_Library;

namespace Game_Class_Library {

    //  Crazy Eight Game Static Class
    //
    //      Provides types and variables to the CrazyEightsForm for 
    //      Crazy Eight Game provides the setup for the variables required to play the
    //      game, the AI for the computer decision for card to discard through ComputerDecision, and creation of the
    //      playable cards lists to determine what can and can't be played according to the given hand
    //      according to the hand of the player or computer
    public static class Crazy_Eight_Game {

        //Create Draw Pile
        public static CardPile SetDrawPile(){
            CardPile drawPile = new CardPile(true);
            drawPile.ShufflePile();
            return drawPile;
        }

        //Return hand with dealt cards from the drawPile
        public static Hand DealCards(CardPile drawPile){
            //Deal 8 cards and add them to the contructor of the Hand class
            List<Card> cards = new List<Card>(drawPile.DealCards(8));
            Hand hand = new Hand(cards);
            //return cards
            return hand;
        }

        //Create Discard Pile from Draw Pile Last Card
        public static CardPile SetDiscardPile(CardPile drawPile){
            //Declare new card pile
            CardPile discardPile = new CardPile();
            //Retrieve last card from draw pile and add it to the discard pile
            Card lastCard = drawPile.GetLastCardInPile();
            discardPile.AddCard(lastCard);
            //Remove the last card from the draw pile
            drawPile.RemoveLastCard();
            //return the discard pile
            return discardPile;
        }

        //Add a card to the discard pile 'discarding' it
        public static CardPile DiscardCard(CardPile discardPile, Card card){
            discardPile.AddCard(card);
            return discardPile;
        }

        //Draw one card from the draw pile and return it
        public static Card DrawCard(CardPile drawPile){
            Card card = drawPile.DealOneCard();
            return card;
        }

        //send in current cards list and displaying card
        public static List<Card> CheckPlayable(Hand hand, Card pileCard){
            List<Card> playableCards = new List<Card>(); 
            foreach(Card card in hand){
                //add card to playable cards if the face value or suit matches the pile card
                //or if the face value of the card is eight
                if ((card.GetFaceValue() == pileCard.GetFaceValue()) || (card.GetSuit() == pileCard.GetSuit())){
                    playableCards.Add(card);
                }else if (card.GetFaceValue().ToString() == FaceValue.Eight.ToString()){
                    playableCards.Add(card);
                }
            }
            //return the list of cards that can be played
            return playableCards;
        }
        
        //Reset the Draw Pile on Empty
        public static CardPile ResetDrawPile(CardPile discardPile){
            //declare new cardpile
            CardPile drawPile = new CardPile();
            //go through discardpile in reverse order adding the cards to drawPile
            for (int i = 0; i < discardPile.GetCount(); i++){
                drawPile.AddCard(discardPile.DealOneCard());
            }
            //return reversed pile for Draw Pile
            return drawPile;
        }

        //Computer Decision Process according to the Crazy Eight Rules
        public static Card ComputerDecision(List<Card> playableCards, Card topCard){
            //base final decision on heirarchy of lists and selection of a random card
            List<Card> matchValue = new List<Card>();
            List<Card> matchSuit = new List<Card>();
            List<Card> matchEight = new List<Card>();
            //cycle through cards in playablecards, adding cards to their correct list categories
            foreach (Card card in playableCards){
                if ((card.GetFaceValue() == topCard.GetFaceValue()) && card.GetFaceValue() != FaceValue.Eight){
                    matchValue.Add(card);
                }
                else if (card.GetSuit() == topCard.GetSuit()){
                    matchSuit.Add(card);
                }
                else if (card.GetFaceValue() == FaceValue.Eight){
                    matchEight.Add(card);
                }
            }
            //choose the first list that contains a value and return a card based on a random index
            Random random = new Random();
            if (matchValue.Count != 0){
                int rand = random.Next(0, matchValue.Count());
                return matchValue[rand];
            }else if (matchSuit.Count != 0){
                int rand = random.Next(0, matchSuit.Count());
                return matchSuit[rand];
            }else{
                int rand = random.Next(0, matchEight.Count());
                return matchEight[rand];
            }
        }
    }//end class
}
