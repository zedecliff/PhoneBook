using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.entity
{
    /*========================================================================================
    * THIS IS THE DATA CLASS, it holds and manipulates the phone book data.
     ========================================================================================*/
    class entityFNS
    {
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();

        public bool enterRecord(string phoneBookRecord)
        {
            /*get name and number*/
            string[] phoneBookRecordSplit = phoneBookRecord.Split(null);
            try
            {
                phoneBook.Add(phoneBookRecordSplit[0], phoneBookRecordSplit[phoneBookRecordSplit.Length - 1]);
                return true;
            }
            catch (ArgumentException)
            {
                /*that key exists*/
                return false;

            }
        }



        /*read all records*/
        public Dictionary<string, string> readAllRecords()
        {
            return phoneBook;
        }



        /*check if the queried name is present*/
        public bool seachName(string recordInput)
        {
            /*get name and number*/
            string[] recordInputSplit = recordInput.Split(null);

            if (phoneBook.ContainsKey(recordInputSplit[0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
