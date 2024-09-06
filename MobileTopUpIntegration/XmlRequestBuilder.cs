using System;
using System.Xml.Linq;
using System.Text;

namespace MobileTopUpIntegration
{
    public class XmlRequestBuilder
    {
        public byte[] BuildRequest(RequestMessage request)
        {
            try
            {
                // Ensures the amount to be a 10 digit string
                string amountInCents = (request.Amount).ToString("0000000000");

              
                var xml = new XElement("Message",
                    new XElement("Header",
                        new XElement("Identifier", request.Identifier),
                        new XElement("MessageDate", request.MessageDate.ToString("ddMMyyyy")), 
                        new XElement("MessageTime", request.MessageTime.ToString("HHmmss"))   
                    ),
                    new XElement("Body",
                        new XElement("MessageID", request.MessageID),
                        new XElement("PhoneNumber", request.PhoneNumber.PadLeft(12, '0')), // Ensures PhoneNumber is 12 digits
                        new XElement("Amount", amountInCents)  
                    )
                );

                // Converting  XML to byte array
                return Encoding.UTF8.GetBytes(xml.ToString());
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error occurred: {exception.Message}");
                throw; 
            }
        }
    }
}
