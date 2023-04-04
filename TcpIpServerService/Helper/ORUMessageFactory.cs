using NHapi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperHL7
{
    public class ORUMessageFactory
    {
        public ORUMessageFactory() { }
        public static IMessage CreateMessage(string messageType, MessageModel aDTMessageModel)
        {
            //This patterns enables you to build other message types 
            if (messageType.Equals("001"))
            {
                return new ORU_R01MessageBuilder().Build(aDTMessageModel);
            }

            //if other types of ADT messages are needed, then implement your builders here
            throw new ArgumentException($"'{messageType}' is not supported yet. Extend this if you need to");
        }
    }
}
