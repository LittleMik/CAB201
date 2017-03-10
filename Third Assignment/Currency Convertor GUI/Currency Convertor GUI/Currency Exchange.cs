using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Convertor_GUI {

    enum Currencies {AUD, CYN, DKK, EUR, INR, NZD, AED, GBP, USD, VND}; //!!!changed UKP to GBP

    static class Currency_Exchange{
        private static double[] xRates = {1, 4.2681, 5.0844, 0.6849, 43.5921, 0.9705, 2.7094, 0.4963, 0.7382, 19115.5547};

        // Insert method or methods here

        //--------------------------------------------------------------
        // Converts value of a currency to value in AUD and returns the
        // result
        //
        // Preconditions:
        // currencyIndex - integer value identifying the currency
        // selected by the user according to index
        // inputValue - double value entered by the user for the amount
        // to convert
        // Postcondition: outputValue - double calculated using the
        // given currency's rate
        //--------------------------------------------------------------
        public static double ToAUD(int currencyIndex, double inputValue){
            double rate, outputValue;
            //get rate from currency provided
            rate = xRates[currencyIndex];
            //convert value of currency to AUD
            outputValue = inputValue / rate;
            return outputValue;
        }//end ToAUD

        //--------------------------------------------------------------
        // Converts from value in AUD to value in another currency and
        // returns the result
        //
        // Preconditions:
        // currencyIndex - integer value identifying the currency
        // selected by the user according to index
        // inputValue - double value entered by the user for the amount
        // to convert
        // Postcondition: outputValue - double calculated using the given
        // currency's rate
        //--------------------------------------------------------------
        public static double FromAUD(int currencyIndex, double inputValue){
            double rate, outputValue;
            //get rate from currency provided
            rate = xRates[currencyIndex];
            //convert value of currency from AUD
            outputValue = inputValue * rate;
            return outputValue;
        }//end FromAUD

        //--------------------------------------------------------------
        // Returns the currency code according to the index value provided
        //
        // Precondition: currencyIndex - integer value identifying the 
        // currency selected by the user according to index
        // Postconditions: outputCode - string which returns the currency's
        // code according to the respective currency code listed in the enum
        // 'Currencies'
        //--------------------------------------------------------------
        public static string GetCurrencyCode(int currencyIndex){
            string outputCode = ((Currencies)currencyIndex).ToString();
            return outputCode;
        }//end GetCurrencyCode
    }//end class
}//end namespace
