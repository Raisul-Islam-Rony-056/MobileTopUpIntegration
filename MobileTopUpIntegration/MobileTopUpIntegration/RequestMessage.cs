using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTopUpIntegration
{
    public class RequestMessage
    {
        public string Identifier { get; set; } = "EZE";
        public DateTime MessageDate { get; set; }
        public DateTime MessageTime { get; set; }
        public int MessageID { get; set; }
        public string PhoneNumber { get; set; }
        public int Amount { get; set; }

        public void Request_Xml(byte[] byte_array)
        {
            Console.WriteLine("Generating XML Request:");
            Console.WriteLine(Encoding.UTF8.GetString(byte_array));
            Console.WriteLine();
        }
    }
}
