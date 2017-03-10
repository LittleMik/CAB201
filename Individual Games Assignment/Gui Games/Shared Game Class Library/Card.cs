using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Game_Class_Library
{
    //Card Enum Types
    public enum Suit { Clubs, Diamonds, Hearts, Spades }
    public enum FaceValue { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
   
    //  Card Class
    //      Non-static Class for a Card
    //      Contains the variables of a Suit and a FaceValue enum which identify a particular card
    //      

    // Non-Static Class - Card Class
    //      Author: Michael Smallcombe w/UML diagram
    //      
    //      Defines a card which is used in both Hands and Piles in each game.
    //      Cards contain a suit and a face value to identify them,
    //      this is used in both controlling gameplay and identifying what card to display to users
    //      
    //      Enum Suit contains the 4 suits of a standard card in the order of Clubs, Diamonds, Hearts, Spades
    //      Enum FaceValue contains the 13 values of a standard card in the order of Two to Ace
    //      
    //  Constructors:
    //      Card() - creates a blank card with no suit or facevalue defined
    //      Card(Suit suit, FaceValue, faceValue) - creates a card with the suit and facevalues defined according to the arguments provided
    //      
    //  Class Methods:
    //      GetFaceValue() - returns enum FaceValue of card
    //      GetSuit() - returns enum Suit of card
    //      Equals(Card card) - returns bool to identify if the card is equal to the card in the argument in value or not
    //      CompareTo(Card card) - returns int to identify value compared to the other card in the argument
    //
    public class Card: IEquatable<Card>, IComparable<Card>{
        //initialise variables for Card object
        private Suit suit;
        private FaceValue faceValue;

        //Constructor
        //
        //Postcondition: Creates blank/empty card object
        public Card() { }
        
        //Constructor - Creates a specific card
        //
        //Precondition: 
        //  Suit inputsuit - a suit as listed in the enum Suit
        //  FaceValue inputFaceValue - a card face value as listed in the enum FaceValue
        //Postcondition:
        //  Creates a card with an enum suit and faceValue as provided in the inputSuit and inputFacevalue
        public Card(Suit inputSuit, FaceValue inputFaceValue){
            this.suit = inputSuit;
            this.faceValue = inputFaceValue;
        }

        //Retrieve Face Value of Card
        //
        //Postcondition: returns enum faceValue variable of Card
        public FaceValue GetFaceValue(){
            return this.faceValue;
        }

        //Retrieve Suit of Card
        //
        //Postcondition: returns enum suit variable of Card
        public Suit GetSuit(){
            return this.suit;
        }

        //Determine if card is equal to another card
        //
        //Precondition: Card object (card)
        //Postcondition: returns Boolean true if the cards are equal, false if not equal
        public bool Equals(Card card){
            if (this.GetFaceValue() == card.GetFaceValue()){
                return true;
            }else{
                return false;
            }
        }
        
        //Compare two cards values against one another
        //
        //Precondition: Card object (card)
        //Postcondition: returns integer variable based on the result comparison between the values of the cards
        //according to their suit or facevalue (if suits are the same). The weight of values is determined by enum type
        //position. A postitive if the values are the exact same, negative if the card precondition is greater than the 
        //card object that calls the method, and postitive if the card object that calls the method is greater than the 
        //precondition variable.
        public int CompareTo(Card card){

            //compare card suit values
            int suitValue1 = (int)this.GetSuit();
            int suitValue2 = (int)card.GetSuit();
            int result = suitValue1 - suitValue2;
            //compare faceValue if the suits are of the same value
            if (result == 0){
                int faceValue1 = (int)this.GetFaceValue();
                int faceValue2 = (int)card.GetFaceValue();
                int resultFaceValue = faceValue1 - faceValue2;
                return resultFaceValue;
            }else{
                //return result value
                return result;
            }
        }
    }
}
