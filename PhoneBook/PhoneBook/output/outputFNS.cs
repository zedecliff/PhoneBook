using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.output
{
    /*========================================================================================
     * THIS IS THE OUTPUT CLASS, it is in charge of displaying output in a good format.
     *  1. Error outputs
     *  2. phonebook records
     *  3. guide on how to enter records
     *  4. Welcoming message, closing messages etc.
      ========================================================================================*/ 
    class outputFNS
    {
        public string welcomeMessage()
        {
            string welcomeMSG = null;
            StringBuilder sb = new StringBuilder();

            string part1 = "===========================================================\n";
            string part2 = "           PHONE BOOK CONSOLE APPLICATION                  \n";
            string part3 = "\n\n";

            sb.Append(part1);
            sb.Append(part2);
            sb.Append(part1);
            sb.Append(part3);

            welcomeMSG = sb.ToString();

            return welcomeMSG;
        }

        public string nGuidelines()
        {
            string nGuidelineFinal = null;
            StringBuilder sb = new StringBuilder();

            string part1 = "\nN must be an integer and 1 <= n <= 100,000";
            string part2 = "\n\n";

            sb.Append(part1);
            sb.Append(part2);

            nGuidelineFinal = sb.ToString();

            return nGuidelineFinal;
        }



        public string phoneBookGuidelines()
        {
            string pbGuideFinal = null;
            StringBuilder sb = new StringBuilder();

            string part1 = "\nphone record format: (name)(space)(space)(number)\n";
            string part2 = "name=>(english word), number=>(8 digits), name is unique";
            string part3 = "\n\n";

            sb.Append(part1);
            sb.Append(part2);
            sb.Append(part3);

            pbGuideFinal = sb.ToString();

            return pbGuideFinal;

        }


        public string exitQueryGuidelines()
        {
            string exitQueryFinal = null;
            StringBuilder sb = new StringBuilder();

            string part1 = "\nWhile entering queries(names), enter any number to exit\n1 >= queries <= 100,000\n";
            string part3 = "\n";

            sb.Append(part1);
            sb.Append(part3);

            exitQueryFinal = sb.ToString();

            return exitQueryFinal;

        }


        public string queryGuidelines()
        {
            string queryGudeFinal = null;

            StringBuilder sb = new StringBuilder();

            string part1 = "\nquery format: (name)\n";
            string part2 = "name=>(english word)";
            string part3 = "\n\n";

            sb.Append(part1);
            sb.Append(part2);
            sb.Append(part3);

            queryGudeFinal = sb.ToString();

            return queryGudeFinal;

        }

        public string readQueryRecords(List<string> queries, Dictionary<string, string> phoneBook)
        {
            entity.entityFNS oEntity = new entity.entityFNS();
            string outputFinal = null;
            StringBuilder sb = new StringBuilder();

            sb.Append("\n\n");

            for (int i = 0; i < queries.Count; i++)
            {
                /*check if key exists*/
                if (phoneBook.ContainsKey(queries[i]))
                {
                    string name = queries[i];
                    string separator = "=";
                    string phoneNumber = phoneBook[queries[i]];
                    string nwLine = "\n";

                    sb.Append(name);
                    sb.Append(separator);
                    sb.Append(phoneNumber);
                    sb.Append(nwLine);
                }
                else
                {
                    sb.Append("Not found\n");
                }
            }


            outputFinal = sb.ToString();
            return outputFinal;

        }

    }
}
