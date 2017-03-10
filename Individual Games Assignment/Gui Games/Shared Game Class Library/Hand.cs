using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Game_Class_Library
{
    // Non-Static Class - Hand Class
    //      Author: Michael Smallcombe w/UML diagram
    //      
    //      Contains the cards of a player or computer for a card game.
    //      
    //      List<Card> cards contains the cards added to the hand
    //      
    //  Constructors:
    //      Hand() - creates a blank hand with no Cards listed in the cards variable
    //      Hand(List<Card>) - creates a hand containing the specified Cards provided in the argument
    //      
    //  Class Methods:
    //      GetCount() - returns int for number of cards
    //      GetCard(int index) - returns card at index
    //      AddCard(Card card) - void
    //      ContainsCard(Card card) - returns bool of card in index or not
    //      RemoveCard(Card card) - returns bool for success of removal
    //      RemoveCardAt(int index) - void
    //      Sort() - n/a
    //      GetEnumerator() - returns enumerator
    //
    public class Hand: IEnumerable
    {
        //declare variables
        private List<Card> cards = new List<Card>();

        //Default Constructor
        //
        //Postcondition: creates blank object Hand with no cards
        public Hand() {}

        //Second Constructor - Hand
        //
        //Precondition: List of Cards inputCards to make up the initial cards in the Hand object
        //Postcondition: creates an object Hand with an initial set of cards
        public Hand(List<Card> inputCards){
            this.cards = inputCards;
        }

        //Return number of cards
        //
        //Postcondition: returns the number of cards contained in the Hand
        public int GetCount(){
            return this.cards.Count();
        }

        //Return card
        //
        //Precondition: integer index - index of the desired card in hand
        //Postcondition: returns the card at the specified index
        public Card GetCard(int index)
        {
            return this.cards[index];
        }

        //Add card
        //
        //Precondition: Card card - card to add to the hand
        //Postcondition: adds given card to the Hand
        public void AddCard(Card card){
            this.cards.Add(card);
        }

        //Check card in hand
        //
        //Precondition: Card card - card to check against the hand cards
        //Postcondition: returns true/false for the given card being in the hand cards
        public bool ContainsCard(Card card){
            return this.cards.Contains(card);
        }

        //Remove card
        //
        //Precondition: Card card - card to remove from the hand
        //Postcondition: removes given card from the hand cards, returns true/false for card being removed
        public bool RemoveCard(Card card){
            if (cards.Contains(card)){
                cards.Remove(card);
                return true;
            }else{
                return false;
            }
        }

        //Remove card at index
        //
        //Precondition: integer index - index of the card to be removed in hand cards
        //Postcondition: removes card at given index
        public void RemoveCardAt(int index){
            cards.RemoveAt(index);
        }
        //Arrange cards
        //
        //Postcondition: arranges cards in order of value
        public void SortHand(){
            cards.Sort();
        }

        //Return enumerator
        //
        //Postcondition: returns an enumerator for the cards in the Hand
        public IEnumerator GetEnumerator(){
            return cards.GetEnumerator();
        }
    }
}
