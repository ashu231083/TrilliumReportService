using NHapi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperHL7
{
    public class ADTMessageFactory
    {
        public ADTMessageFactory() { }
        public static IMessage CreateMessage(string messageType, MessageModel aDTMessageModel)
        {
            //This patterns enables you to build other message types 
            if (messageType.Equals("A01"))
            {
                return new ADT_A01MessageBuilder().Build(aDTMessageModel);
            }

            if (messageType.Equals("A04"))
            {
                return new ADT_A04MessageBuilder().BuildA04(aDTMessageModel);
            }

            if (messageType.Equals("A08"))
            {
                return new ADT_A08MessageBuilder().BuildA08(aDTMessageModel);
            }

            //if other types of ADT messages are needed, then implement your builders here
            throw new ArgumentException($"'{messageType}' is not supported yet. Extend this if you need to");
        }


        public static IMessage CreateMessageNEW(string messageType, HL7Model aDTMessageModel)
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
                return new ADT_A08MessageBuilder().BuildA08NEW(aDTMessageModel);
            }

            //if other types of ADT messages are needed, then implement your builders here
            throw new ArgumentException($"'{messageType}' is not supported yet. Extend this if you need to");
        }

    }
}
