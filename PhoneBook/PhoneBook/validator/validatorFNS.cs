using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneBook.validator
{
    /*========================================================================================
    * THIS IS THE VALIDATOR CLASS, it is in charge of validating user input.
    *  1. Query Format
    *  2. phonebook format
    *  3. n validity
    *  4. phone number validity.
    *  5. phone name validity
    *  
    *  N/B
    *  => this program will use (interger) data type because no input or number will
    *      go beyound  {2,147,483,647}
     ========================================================================================*/
    class validatorFNS
    {

        /*===================================================================================
        *  query format => {name(string)}
        *  
        *  RULES     : only one name is used, if 2 names the format is wrong
        *              only english letters no digits (english names)
        *              onlu lowercase, uppercase will be rejected
         ===================================================================================*/
        public bool queryFormat(string inputQuery)
        {
            /*check if the name is valid*/
            if(phoneNameChecker(inputQuery))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /*===================================================================================
         *  phone book format => {name(string) (2 spaces) phoneNumber(8 digits)}
         *  space == null, new char[0]
         *===================================================================================*/
        public bool phoneBookFormat(string inputPhoneRecord)
        {
            /*confirm if phone number and name are separated by 2 spaces*/
            string[] inputPhoneRecordSplit = inputPhoneRecord.Split(null);

            if (inputPhoneRecordSplit.Length==3)
            {
                /*check if the name and number is valid*/
                if(phoneNameChecker(inputPhoneRecordSplit[0]) && 
                    phoneNumberChecker(inputPhoneRecordSplit[inputPhoneRecordSplit.Length - 1]))
                {
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            else
            {
                return false;
            }
            
        }



        /*===================================================================================
         *  n Value => 1 <= x <= 100,000
         *  n must be an integer, no string
         ===================================================================================*/
        public bool nChecker(string nValue)
        {
            /*check if n value is an integer*/
            if(isInteger(nValue))
            {
                /*check for 1 <= n <= 100,000*/
                int nValueInt = Convert.ToInt32(nValue);

                if(nValueInt > 0 && nValueInt < 100001)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            else
            {
                return false;
            }
        }



        /*===================================================================================
        *  Phone name MUST be english words only
        *  only characters(letters), lowercase only uppercase will be rejected
        * 
       ===================================================================================*/
        public bool phoneNameChecker(string phoneNameString)
        {
            /*first check if its only letters*/
            if(Regex.IsMatch(phoneNameString, @"^[a-z]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
          
        }



        /*===================================================================================
         *  Phone number MUST be 8 digits
         *    => {18928909}, only digits
         * 
        ===================================================================================*/
        public bool phoneNumberChecker(string phoneNumberString)
        {
            /*first check if its an integer and it it has 8 digits*/
            if ((isInteger(phoneNumberString)) && (phoneNumberString.Count()==8))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /*===================================================================================
        *  Checks if a given string is an integer
        * 
       ===================================================================================*/
        public bool isInteger(string intInString)
        {
            try
            {
                int newNumber = Convert.ToInt32(intInString);
                return true;
            }
            catch(Exception exp)
            {
                return false;
            }
        }

        
    }
}
