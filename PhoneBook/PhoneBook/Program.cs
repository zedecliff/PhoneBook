using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PhoneBook.output;
using PhoneBook.validator;

namespace PhoneBook
{
    class Program
    {
        /*========================================================================================
         * THIS IS THE MAIN FUNCTION. 
         *  => gets the user input -> validator -> (results(entity) | error) -> output
         *========================================================================================*/
        static void Main(string[] args)
        {
           /*variable declaration and initializations*/
            int nValueHolder = 0;
            int inputPhoneRecordCounter = 0;
            List<string> queriesHolder = new List<string>();

            validatorFNS oValidator = new validatorFNS();
            entity.entityFNS oEntity = new entity.entityFNS();
            outputFNS oOutput = new outputFNS();

            /*===================================================================================
             *  WELCOMING MESSAGE
              ===================================================================================*/
            Console.Write(oOutput.welcomeMessage());


            /*===================================================================================
             *  Guideline on how to use the program
              ===================================================================================*/
            Console.Write(oOutput.nGuidelines());
            Console.Write(oOutput.phoneBookGuidelines());
            Console.Write(oOutput.queryGuidelines());
            Console.Write(oOutput.exitQueryGuidelines());
            Console.WriteLine("\n\n");


            /*===================================================================================
             *  get n
              ===================================================================================*/
            while (true)
            {
                string nValueStr = Console.ReadLine();

                /*check if n is valid*/
                if (oValidator.nChecker(nValueStr))
                {
                    nValueHolder = Convert.ToInt32(nValueStr);
                    break;
                }
                else
                {
                    /*show guidelines*/
                    Console.Write(oOutput.nGuidelines());
                }
            }



            /*===================================================================================
             *  get the phone records
             *  => read n number of phone records
             ===================================================================================*/

            while (true)
            {
                if (inputPhoneRecordCounter == nValueHolder)
                {
                    break;
                }
                else
                {
                    /*read phone record if format is wrong prompt to enter valid record*/
                    string phoneRecordStr = Console.ReadLine();
                    if (oValidator.phoneBookFormat(phoneRecordStr) && !oEntity.seachName(phoneRecordStr))
                    {
                        /*format is OK, save the data*/
                        oEntity.enterRecord(phoneRecordStr);

                        inputPhoneRecordCounter++;
                    }
                    else
                    {
                        /*display guidelines*/
                        Console.Write(oOutput.phoneBookGuidelines());

                    }
                }
                

            }



            /*===================================================================================
            *  get the queries
            *  => read 1 >= queries <= 100,000
            *  exit by entering any integer value
            ===================================================================================*/
            while (true)
            {
                /*read the name*/
                string queryNameHolder = Console.ReadLine();

                /*check if its exit*/
                if (oValidator.isInteger(queryNameHolder) && queriesHolder.Count>0)
                {
                    /*exit and display output*/
                    break;
                }
                else
                {
                    if (oValidator.queryFormat(queryNameHolder))
                    {
                        /*save the query*/
                        queriesHolder.Add(queryNameHolder);
                    }
                    else
                    {
                        /*show query guidelines*/
                        Console.Write(oOutput.queryGuidelines());
                    }
                }
                
            }



            /*===================================================================================
             *  PRINT THE OUTPUT.
              ===================================================================================*/
            Console.WriteLine(oOutput.readQueryRecords(queriesHolder, oEntity.readAllRecords()));



            Console.ReadKey();


            /*===================================================================================
           *  END  END  END END
            ===================================================================================*/



        }
    }
}
