using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Game_Class_Library
{
    public class CardPile
    {
        // Non-Static Class - CardPile Class
        //      Author: Michael Smallcombe w/UML diagram
        //      
        //      Contains the cards in a pile for a game which can be used to draw cards, 
        //      add and remove cards through the stages of the game
        //      
        //      List<Card> pile contains the cards added to CardPile
        //      
        //  Constructors:
        //      CardPile() - creates a blank pile with no Cards listed in the pile variable
        //      CardPile(Bool createDeck) - creates a CardPile containing a deck of 52 unique cards if the argument is true
        //      
        //  Class Methods:
        //      AddCard(Card card) - void
        //      GetCount() - returns int for number of cards in pile
        //      GetLastCardInPile() - returns Card for last Card in pile
        //      RemoveLastCard() - void
        //      ShufflePile() - void
        //      DealOneCard() - returns Card from the end of the pile
        //      DealCards(int numCards) - returns List<Cards> from the end of the pile to the specified range
        //
        private List<Card> pile = new List<Card>();

        //Default Constructor
        //
        //Postcondition: Produces an empty CardPile object with no cards
        public CardPile() {}

        //Second Constructor - Creates a standard deck of cards
        //
        //Precondition: Boolean createDeck - when true triggers the creation of a deck
        //Postcondition: Creates a CardPile object with 52 cards with a unique faceValue and suit combination
        public CardPile(Boolean createDeck){
            if(createDeck == true){
                //create full deck of 52 cards
                foreach(Suit suit in Enum.GetValues(typeof(Suit))){
                    foreach (FaceValue faceValue in Enum.GetValues(typeof(FaceValue))){
                        //make card
                        Card card = new Card(suit, faceValue);
                        this.pile.Add(card);
                    }
                }
            }
        }

        //Add card to the pile
        //
        //Precondition: Card card - the card to add to the pile
        //Postcondition: adds given card to the pile
        public void AddCard(Card card){
            //add card to deck
            this.pile.Add(card);
        }

        //Retrieves the amount of cards in the pile
        //
        //Postcondition: returns integer of the nuber of cards in the pile
        public int GetCount(){
            //count cards in pile and return int
            int numCards = this.pile.Count();
            return numCards;
        }

        //Retrieves the last card in the pile
        //
        //Postcondition: returns last Card in the pile
        public Card GetLastCardInPile()
        {
            //gets value of last card in pile
            return this.pile.Last();
        }

        //Removes last card
        //
        //Postcondition: removes the last Card in the pile
        public void RemoveLastCard(){
            this.pile.RemoveAt(pile.Count()-1);
        }

        //Shuffles the cards in the pile
        //
        //Postcondition: uses fisher-yates method of shuffling to shuffle
        //the cards in the pile
        public void ShufflePile(){
            //shuffle pile of cards - any public available algorithm
            //get random
            var rand = new Random();
            //fisher-yates shuffle
            for (int n = this.pile.Count() - 1; n > 0; n--){
                //get random integer (between current card and first card)
                int i = rand.Next(n + 1);
                //hold the card at n in a temporary variable
                Card temp = this.pile[n];
                //card at n takes on the value of the card at the random number
                this.pile[n] = this.pile[i];
                //the random card at i takes on the value of the card at n
                this.pile[i] = temp;
            }

        }

        //Deals a single card
        //
        //Postcondition: returns the last Card in the pile and removes it from the pile
        public Card DealOneCard(){
            //get card (last card of the pile)
            Card card = pile.Last();
            //remove card from pile (last card in pile)
            this.RemoveLastCard();
            //return card
            return card;
        }

        //Deal a number of cards
        //
        //Precondition: integer numCards - indicates the number of cards to retrieve
        //Postcondition: returns the number of Cards desired and removes them from the pile 
        public List<Card> DealCards(int numCards)
        {
            //declare variables temp cards list and index
            List<Card> cards = new List<Card>();
            int index = 0;
            //repeat until number of cards specified are dealt
            for(int dealt = 0; dealt >= numCards; dealt++){
                //get current index in pile
                index = (pile.Count() - 1) - dealt;
                //add card at pile index to temporary cards list
                cards.Add(pile[index]);
                //remove card at index from pile
                this.pile.RemoveAt(index);
            }
            //return cards
            return cards;
        }

    }
}
