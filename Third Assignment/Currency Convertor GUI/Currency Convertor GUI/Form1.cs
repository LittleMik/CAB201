using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Currency_Convertor_GUI {
    
    public partial class frmMain : Form {

        private double amount; //used to hold the parsed user input

        //--------------------------------------------------------------
        // Initialise Form
        //--------------------------------------------------------------
        public frmMain(){
            InitializeComponent();
        }//end frmMain

        //--------------------------------------------------------------
        // Parses the value entered by the user from the textbox 'txtInput'
        // into a double variable 'amount' and checks if the value is
        // positive. If the value is parsed and positive, the
        // method returns true to indicate the values were valid.
        // If unsuccessful, the user will be warned that the value was
        // incorrect and will return false indicating an invalid value.
        //
        // Precondition: a value entered in txtInput
        //
        // Postcondition: boolean returned indicating either if the value
        // was valid or invalid
        //--------------------------------------------------------------
        public bool ValidateValues(){
            //attempt to parse the user input into a double
            if(double.TryParse(txtInput.Text, out amount)){
                //if value is positive, return true
                if (amount >= 0){
                    //valid value
                    return true;
                }else{
                    //prompt user to re-enter a postive value
                    MessageBox.Show("Please enter a positive value");
                    return false;
                }
            }else{
                //prompt user to re-enter a valid value
                MessageBox.Show("Please enter a valid numeric value");
                txtInput.Focus();
                return false;
            }
        }//end ValidateValues

        //--------------------------------------------------------------
        // Calls the Currency_Exchange class to convert the value
        // according to the currency provided
        // 
        // Precondition: inputValue - double retrieved from the amount 
        // entered by the user
        //
        // Postcondition: returns a double from the final conversion
        // to the output currency using the Currency_Exchange class
        //--------------------------------------------------------------
        public double Convert(double inputValue){
            int inputCurrency, outputCurrency;
            //get inputed currencies
            inputCurrency = cboCurrency1.SelectedIndex;
            outputCurrency = cboCurrency2.SelectedIndex;
            //If the first currency is AUD, proceed to final conversion
            if (cboCurrency1.SelectedItem.ToString() != "Australia (AUD)"){
                //Convert inputValue from value in input currency to value in AUD currency
                double tempValue = Currency_Exchange.ToAUD(inputCurrency, inputValue);
                //If the final currency is to be AUD, return the tempValue
                if (cboCurrency2.SelectedItem.ToString() != "Australia (AUD)"){
                    //Convert tempValue from value in AUD currency to value in output currency
                    return Currency_Exchange.FromAUD(outputCurrency, tempValue);
                }else{
                    //return AUD value
                    return tempValue;
                }
            }else{
                //Convert inputValue from value in AUD to value in output currency
                return Currency_Exchange.FromAUD(outputCurrency, inputValue);
            }
        }//end Convert

        //--------------------------------------------------------------
        // Outputs the converted value to two decimal places in the output
        // textbox
        //
        // Precondition: outputValue - double retrieved from the conversion
        // process
        //--------------------------------------------------------------
        public void OutputConversion(double outputValue){
            txtOutput.Text = String.Format("{0:f2}", outputValue);
        }//end OutputConversion

        //--------------------------------------------------------------
        // Changes the form elements according to the given stage of the
        // user input
        //
        // Precondition: stage - integer identifiying the particular
        // stage of the input
        //
        // Postcondition: n/a
        //--------------------------------------------------------------
        public void InputStates(int stage){
            switch(stage){
                //Following cboCurrency1 select
                case 1:
                    cboCurrency1.Enabled = false;
                    cboCurrency2.Enabled = true;
                    break;
                //Following cboCurrency2 select
                case 2:
                    //disable current input
                    cboCurrency2.Enabled = false;
                    //get currency code based on first selection and output to label
                    lblCurrencyCode1.Text = Currency_Exchange.GetCurrencyCode(cboCurrency1.SelectedIndex);
                    lblCurrencyCode1.Visible = true;
                    //enable next input
                    txtInput.Enabled = true;
                    //disabled convert button (if enabled)
                    btnConvert.Enabled = false;
                    break;
                //Following txtInput edit (with value entered)
                case 3:
                    //enable convert button
                    btnConvert.Enabled = true;
                    break;
                //Final Form State (following conversion)
                case 4:
                    //get currency code based on second selection and output to label
                    lblCurrencyCode2.Text = Currency_Exchange.GetCurrencyCode(cboCurrency2.SelectedIndex);
                    lblCurrencyCode2.Visible = true;
                    //disable current inputs
                    txtInput.Enabled = false;
                    btnConvert.Enabled = false;
                    //enable next input
                    grpPromptRepeat.Visible = true;
                    break;
                //Reset/Default Form State
                default:
                    //enable first input
                    cboCurrency1.Enabled = true;
                    //clear textboxes
                    txtInput.Clear();
                    txtOutput.Clear();
                    //disable other inputs
                    btnConvert.Enabled = false;
                    cboCurrency2.Enabled = false;
                    txtInput.Enabled = false;
                    txtOutput.Enabled = false;
                    //hide currency codes
                    lblCurrencyCode1.Visible = false;
                    lblCurrencyCode2.Visible = false;
                    //hide final prompt
                    grpPromptRepeat.Visible = false;
                    break;
            }//end switch
        }//end InputStates

        //--------------------------------------------------------------
        // Sets the next input state after a value from the combobox 
        // 'çboCurrency1' is selected
        //
        // Precondition/Postcondition: n/a
        //--------------------------------------------------------------
        private void cboCurrency1_SelectedIndexChanged(object sender, EventArgs e){
            //if a value is selected, proceed to the next input
            if (cboCurrency1.SelectedItem.ToString() != ""){
                //call following inputs to be enabled
                InputStates(1);
            }
        }//end cboCurrency1_SelectedIndexChanged

        //--------------------------------------------------------------
        // Validates inputs and runs conversion method if input is valid.
        // Follows conversion by outputing the result and then changing
        // the state of the form elements for the next input.
        //
        // Precondition/Postcondition: n/a
        //--------------------------------------------------------------
        private void btnConvert_Click(object sender, EventArgs e){
            double outputValue;
            bool validValues;
            //check values
            validValues = ValidateValues();
            //if values valid do conversion, do nothing (wait for user to change value)
            if (validValues){
                //do conversion
                outputValue = Convert(amount);
                //output new value
                OutputConversion(outputValue);
                //call following form elements to be enabled
                InputStates(4);
            }
        }//end btnConvert_Click

        //--------------------------------------------------------------
        // Enable next form elements when a value is entered, revert
        // to previous state if the textbox is cleared
        //
        // Precondtion/Postcondition: n/a
        //--------------------------------------------------------------
        private void txtInput_TextChanged(object sender, EventArgs e){
            //if the input textbox contains a value, enable the button to convert
            if (txtInput.TextLength != 0){
                InputStates(3);
            //if cleared, revert
            }else{
                InputStates(2);
            }
        }//end txtInput_TextChanged

        //--------------------------------------------------------------
        // When the form is loaded, setup the default state for the form
        //
        // Precondition/Postcondtion: n/a
        //--------------------------------------------------------------
        private void frmMain_Load(object sender, EventArgs e){
            //call default state
            InputStates(0);
        }//end frm_Main_Load

        //--------------------------------------------------------------
        // Sets the next input state after a value from the combobox 
        // 'çboCurrency2' is selected
        //
        // Precondition/Postcondition: n/a
        //--------------------------------------------------------------
        private void cboCurrency2_SelectedIndexChanged(object sender, EventArgs e){
            //if a value is selected, proceed to the next input
            if (cboCurrency2.SelectedItem.ToString() != ""){
                //call the following form elements
                InputStates(2);
            }
        }//end cboCurrency2_SelectedIndexChanged

        //--------------------------------------------------------------
        // Resets the form when checked
        //
        // Precondition/Postcondition: n/a
        //--------------------------------------------------------------
        private void rbYes_CheckedChanged(object sender, EventArgs e){
            //Reset form to default state
            InputStates(0);
        }//end rbYes_CheckedChanged

        //--------------------------------------------------------------
        // Calls the close program method when checked
        //
        // Precondition/Postcondition: n/a
        //--------------------------------------------------------------
        private void rbNo_CheckedChanged(object sender, EventArgs e){
            ExitProgram();
        }//end rbNo_CheckedChanged

        //--------------------------------------------------------------
        // Gives a farewell message before closing the program
        //
        // Precondition/Postcondition: n/a
        //--------------------------------------------------------------
        public void ExitProgram(){
            MessageBox.Show("Thank you for using Currency Converter");
            Close();
        }//end ExitProgram

    }//end class 
}
