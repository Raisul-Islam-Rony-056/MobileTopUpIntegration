using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTopUpIntegration
{
    public class ResponseMessage
    {
        public string MessageDate { get; set; }
        public string MessageTime { get; set; }
        public int TransactionID { get; set; }
        public int TransactionNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int Amount { get; set; }
        public string Result { get; set; }

        public void Print_Response()
        {
            Console.WriteLine("Response Message Attributes:");
            Console.WriteLine($"Message Date: {MessageDate}");
            Console.WriteLine($"Message Time: {MessageTime}");
            Console.WriteLine($"Transaction ID: {TransactionID}");
            Console.WriteLine($"Transaction Number: {TransactionNumber}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine($"Amount: {Amount}");
            Console.WriteLine($"Result: {Result}");
            Console.WriteLine();
        }
    }
}
