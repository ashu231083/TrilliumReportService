using HelperHL7;
using NHapi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpIpServerService
{
    public class ORMMessageFactory
    {
        public ORMMessageFactory() { }
        public static IMessage CreateMessage(string messageType, MessageModel aDTMessageModel)
        {
            //This patterns enables you to build other message types 
            //if (messageType.Equals("001"))
            //{
            //    return new ORM_001MessageBuilder().Build(aDTMessageModel);
            //}

            //if other types of ADT messages are needed, then implement your builders here
            throw new ArgumentException($"'{messageType}' is not supported yet. Extend this if you need to");
        }


        public static IMessage CreateMessageNEW(string messageType, HL7ORMModel aDTMessageModel)
        {
            //This patterns enables you to build other message types 
            if (messageType.Equals("001"))
            {
                return new ORM_001MessageBuilder().BuildNEW(aDTMessageModel);
            }

            //if other types of ADT messages are needed, then implement your builders here
            throw new ArgumentException($"'{messageType}' is not supported yet. Extend this if you need to");
        }
    }
}
