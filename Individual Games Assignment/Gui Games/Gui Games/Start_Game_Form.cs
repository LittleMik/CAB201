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

namespace Gui_Games {
    public partial class Start_Game_Form : Form {

        //  Start_Game_Form
        //  Author: Michael Smallcombe
        //  User input of a combo box identifies the desired game and opens the specified
        //  game form when btnStart is clicked
        public Start_Game_Form() {
            InitializeComponent();
        }

        //On Combo Box Change
        private void cboGame_SelectedIndexChanged(object sender, EventArgs e){
            //check correct game entered for start button to enable
            if ((cboGame.SelectedItem.ToString() == "Crazy Eights") || (cboGame.SelectedItem.ToString() == "Solitaire")){
                btnStart.Enabled = true;
            }else{
                btnStart.Enabled = false;
            }
        }

        //Exit Button
        private void btnExit_Click(object sender, EventArgs e){
            //exit program
            ExitProgram();
        }

        //Exit Program
        public void ExitProgram(){
            Close();
        }

        //get which form to display
        private void btnStart_Click(object sender, EventArgs e)
        {
            int index = cboGame.SelectedIndex;
            switch (index){
                case 0:
                    CrazyEightsForm CrazyEights = new CrazyEightsForm();
                    CrazyEights.Show();
                    break;
                case 1:
                    SolitaireForm Solitaire = new SolitaireForm();
                    Solitaire.Show();
                    break;
            }
        }
    }
}
