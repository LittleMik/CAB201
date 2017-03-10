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
using Gui_Games;

namespace Gui_Games
{
    // ChooseSuitForm
    // Author: Michael Smallcombe
    // Identifies which suit the player wishes to use for the game after an eight has been placed by
    // the player and returns it to the CrazyEightsForm for use in gameplay (to set the topCard variable suit)
    //
    public partial class ChooseSuitForm : Form
    {
        public Suit ReturnSuit { get; set; }
        public ChooseSuitForm()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            btnChoose.DialogResult = DialogResult.OK;
            //get which suit was selected and return it back to the other form
            if (rbClubs.Checked){
                this.ReturnSuit = Suit.Clubs;
            }
            else if (rbDiamonds.Checked){
                this.ReturnSuit = Suit.Diamonds;
            }
            else if (rbHearts.Checked){
                this.ReturnSuit = Suit.Hearts;
            }
            else if (rbSpades.Checked){
                this.ReturnSuit = Suit.Spades;
            }
            //close the choose suit form
            this.Close();
        }
    }
}
