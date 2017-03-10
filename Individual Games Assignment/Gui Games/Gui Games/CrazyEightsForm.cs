using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared_Game_Class_Library;
using Game_Class_Library;
using Gui_Games;

namespace Gui_Games
{
    //  Crazy_Eights_Form
    //  Author: Michael Smallcombe
    //      Runs the user input and major events of the Crazy Eights Game returning results through the GUI based on user
    //      input and the Crazy_Eight_Game class methods
    //      
    //      btnDeal starts the game by triggering the SetupGame method which
    //      Aquires the drawPile, discardPile starting card, hands for both computer and player
    //      as well as trigger the turn start for the player.
    //
    //      Clicking on the pictureboxes in the table panel for player allows the discarding of cards
    //      if they are in the 'playerPlayableCards' list
    //
    //      Clicking on the drawPile image draws a pile if the player is allowed to draw at that point in the game
    //      
    //      btnCancel leaves the current game
    //
    //      Most methods require the Crazy Eight Game class to return various types to be used
    //      for hands, piles, cards and determining what to do in cases such as computer discarding
    //

    public partial class CrazyEightsForm : Form{
        //setup game variables
        PictureBox[] cardImage;
        public CardPile drawPile, discardPile = new CardPile();
        public Hand playerHand = new Hand();
        public Hand computerHand = new Hand();
        public Card topCard = new Card();
        public List<Card> playerPlayableCards = new List<Card>();
        public List<Card> computerPlayableCards = new List<Card>();
        private bool playerPass, computerPass, allowDraw = false;
        private bool playerTurn = true;
        private string output; //instructions label

        public CrazyEightsForm(){
            InitializeComponent();
        }//end CrazyEightsForm

        //Setup Game - On 'Deal btn'
        public void SetupGame(){
            //Create a deck, shuffle and use as drawPile
            drawPile = Crazy_Eight_Game.SetDrawPile();
            //deal the cards from the draw pile
            DealCards();
            //Start the discard pile using card from draw pile
            discardPile = Crazy_Eight_Game.SetDiscardPile(drawPile);
            //Get showing discard pile card value
            topCard = discardPile.GetLastCardInPile();
            //start player turn
            PlayerTurn();
            //update hand images for both player and computer
            UpdateHandImages(playerHand, true);
            UpdateHandImages(computerHand, false);
            UpdateTopCardImage();
        }

        //Deal Cards
        public void DealCards(){
            const int CARDS_DEALT = 8;
            for (int i = 0; i < CARDS_DEALT; i++){
                playerHand.AddCard(drawPile.DealOneCard());
                computerHand.AddCard(drawPile.DealOneCard());
            }
        }

        //go to next turn according to last turn
        public void NextTurn(){
            playerTurn = !playerTurn;
            if (playerTurn){
                PlayerTurn();
            }else{
                ComputerTurn();
            }
        }

        //Start player turn (before player input)
        public void PlayerTurn(){
            //Update Computer Hand
            //UpdateHandImages(computerHand, false);
            //check game state (returns false if no longer running)
            if (CheckGameState()){
                //retrieve playable cards from hand 
                playerPlayableCards = Crazy_Eight_Game.CheckPlayable(playerHand, topCard);
                //if playable card is present, deny draw. If not, allow draw and prompt the user to draw.
                if (playerPlayableCards.Count() != 0){
                    allowDraw = false;
                    output = "Your turn. \nSelect a card to discard. \n(You have at least one)";
                    UpdateInstructions();
                }else{
                    //Check pass status
                    CheckPass();
                    if (playerPass){
                        output = "Your hand is full, you cannot draw anymore cards. \nPassing your turn...";
                        UpdateInstructions();
                        NextTurn();
                    }else{
                        //permit draw card
                        output = "You have no cards to discard. \nDraw a card";
                        UpdateInstructions();
                        allowDraw = true;
                    }
                }
            }else{
                //end game
                EndGame();
            }
        }

        //Computer turn
        public void ComputerTurn(){
            //Update Player Hand
            //UpdateHandImages(playerHand, true);
            //check game state (returns false if no longer running)
            if (CheckGameState()){
                //retrieve playable cards from hand 
                computerPlayableCards = Crazy_Eight_Game.CheckPlayable(computerHand, topCard);
                //if playable card is present, discard a card. If not, draw a card if possible.
                if (computerPlayableCards.Count() != 0){
                    //get card based on computer rules of play and discard it
                    Card playCard = Crazy_Eight_Game.ComputerDecision(computerPlayableCards, topCard);
                    DiscardCard(computerHand, playCard);
                }else{
                    //check pass status
                    CheckPass();
                    if (computerPass){
                        //computer pass, trigger next turn
                        NextTurn();
                    }else{
                        //permit draw card
                        DrawCard(computerHand);
                    }
                }
            }else{
                //end game
                EndGame();
            }
        }
        
        //End Game
        private void EndGame(){
            MessageBox.Show(output);
            Close();
        }

        //update the card images of a hand for a given hand
        private void UpdateHandImages(Hand hand, Boolean player){
            PictureBox pBox;
            cardImage = new PictureBox[hand.GetCount()];
            //clear hand images for given hand (player or computer)
            if (player){
                tblpanelPlayer.Controls.Clear();
            }else{
                tblpanelComputer.Controls.Clear();
            }
            //for each card in the hand, output it as a picture box image to the hand's panels
            for (int i = 0; i < (hand.GetCount()); i++){
                pBox = new PictureBox();
                pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pBox.Dock = DockStyle.Fill;
                pBox.Image = Images.GetCardImage(hand.GetCard(i));
                cardImage[i] = pBox;
                cardImage[i].Click += new EventHandler(PictureBox_Click);
                cardImage[i].Tag = hand.GetCard(i);
                //determine which hand to add it to based on turn
                if (player){
                    tblpanelPlayer.Controls.Add(cardImage[i]);
                }else{
                    tblpanelComputer.Controls.Add(cardImage[i]);
                }
            }
        }

        //Output the top card image
        private void UpdateTopCardImage(){
            imgDiscardPile.Image = Images.GetCardImage(topCard);
        }

        //Game State Check
        public bool CheckGameState(){
            if (playerHand.GetCount() == 0){
                //if the player has no cards in their hand, player win
                output = "Player Wins";
                return false;
            }else if (computerHand.GetCount() == 0){
                //if the computer has no cards in their hand, computer win
                output = "Computer Wins";
                return false;
            }else if(playerPass && computerPass){
                //if the player and computer both passed, tie
                output = "Tie";
                return false;
            }else{
                //game continues
                return true;
            }
        }

        //Check if player/computer needs to pass when drawing
        public void CheckPass(){
            if(playerHand.GetCount() == 13){
                playerPass = true;
            }else{
                playerPass = false;
            }
            if(computerHand.GetCount() == 13){
                computerPass = true;
            }else{
                computerPass = false;
            }
        }

        public void DiscardCard(Hand hand, Card card){
            discardPile = Crazy_Eight_Game.DiscardCard(discardPile, card);
            if (card.GetFaceValue() == FaceValue.Eight){
                //set top card suit if player
                if (playerTurn){
                    //display form
                    Suit resultSuit = Suit.Clubs; //default value
                    using (ChooseSuitForm ChooseSuit = new ChooseSuitForm()){
                        var DialogResult = ChooseSuit.ShowDialog();
                        if (DialogResult == DialogResult.OK)
                        {
                            resultSuit = ChooseSuit.ReturnSuit;
                        }
                        //get new top card based on suit chosen
                    }
                    topCard = new Card(resultSuit, FaceValue.Eight);
                }
            }else{
                topCard = discardPile.GetLastCardInPile();
            }
            hand.RemoveCard(card);
            UpdateHandImages(hand, playerTurn);
            UpdateTopCardImage();
            //End Turn
            NextTurn();
        }

        public void DrawCard(Hand hand){
            //draw a card from the draw pile and add it to the hand
            hand.AddCard(Crazy_Eight_Game.DrawCard(drawPile));
            //Check draw pile after draw
            CheckDrawPile();
            //update hand images
            UpdateHandImages(hand, playerTurn);
            //End Turn
            NextTurn();
        }

        //Update Instructions Label
        public void UpdateInstructions(){
            lblInstructions.Text = string.Format(output);
        }

        //Check DrawPile for reset requirement
        public void CheckDrawPile(){
            if (drawPile.GetCount() == 0){
                drawPile = Crazy_Eight_Game.ResetDrawPile(discardPile);
                discardPile = Crazy_Eight_Game.SetDiscardPile(drawPile);
                UpdateTopCardImage();
            }
        }

        //Click Card
        private void PictureBox_Click(object sender, EventArgs e){
            PictureBox clickedCard = (PictureBox)sender;
            foreach(Card card in playerPlayableCards){
                if (clickedCard.Tag.Equals(card)){
                    //discard card from player hand, update hand images and end turn
                    DiscardCard(playerHand, card);
                    break;
                }else{
                    output = "Sorry that card is not playable. \nPick a card from your hand with \na matching suit or face value";
                }
            }
        }

        private void imgDrawPile_Click(object sender, EventArgs e){
            //draw card if no cards playable
            if (allowDraw == true){
                DrawCard(playerHand);
                UpdateHandImages(playerHand, true);
            }else{
                output = "You cannot draw a card";
                UpdateInstructions();
            }
        }

        //Starts the game
        private void btnDeal_Click(object sender, EventArgs e){
            //call setup game
            SetupGame();
            //disable deal button
            btnDeal.Enabled = false;
            btnSort.Enabled = true;
        }

        //Closes the game
        private void btnCancel_Click(object sender, EventArgs e){
            Close();
        }
    }
}
