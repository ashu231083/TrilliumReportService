using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TcpIpServerService
{
    public class ADTMessageFactory
    {
        public Logger Logger = LogManager.GetCurrentClassLogger();
        public static IMessage CreateMessageNEW(string messageType, HL7Model aDTMessageModel)
        {
            try
            {
                //This patterns enables you to build other message types 
                //if (messageType.Equals("A01"))
                //{
                //    return new ADT_A01MessageBuilder().Build(aDTMessageModel);
                //}

                //if (messageType.Equals("A04"))
                //{
                //    return new ADT_A04MessageBuilder().BuildA04(aDTMessageModel);
                //}

                if (messageType.Equals("A08"))
                {

                    return (IMessage)new ADT_A08MessageBuilder().BuildA08NEW(aDTMessageModel);
                }

                //if other types of ADT messages are needed, then implement your builders here
                throw new ArgumentException($"'{messageType}'Exception at CreateMessageNEW.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception at CreateMessageNEW. Message: " + ex.Message);
                return null;
            }
        }
    }
}
