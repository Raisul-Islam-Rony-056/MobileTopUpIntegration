using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MobileTopUpIntegration
{
    public class XmlResponseParser
    {
        public void ParseResponse(byte[] response, ResponseMessage responseMessage)
        {
            try
            {
                // Converting byte array to string
                string rawString = Encoding.UTF8.GetString(response);

                // Finding the start of the actual XML content (assumes XML starts with '<')
                int xmlStartIndex = rawString.IndexOf('<');
                if (xmlStartIndex != -1)
                {
                    string xmlString = rawString.Substring(xmlStartIndex);

                    // Loading XML from string
                    XElement root = XElement.Parse(xmlString);

                    // Extracting elements from XML and populate the ResponseMessage object
                    responseMessage.MessageDate = root.Element("Header").Element("MessageDate").Value;
                    responseMessage.MessageTime = root.Element("Header").Element("MessageTime").Value;
                    responseMessage.TransactionID = int.Parse(root.Element("Body").Element("TransactionID").Value);
                    responseMessage.TransactionNumber = int.Parse(root.Element("Body").Element("TransactionNumber").Value);
                    responseMessage.PhoneNumber = root.Element("Body").Element("PhoneNumber").Value;
                    responseMessage.Amount = int.Parse(root.Element("Body").Element("Amount").Value);
                    responseMessage.Result = root.Element("Body").Element("Result").Value;
                }
            }
            catch (XmlException exception)
            {
                Console.WriteLine("XML Error: " + exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
            }
        }
    }
}
