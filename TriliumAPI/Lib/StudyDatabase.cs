using TriliumAgent.Models;
using FellowOakDicom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgent.Lib
{
    public class StudyDatabase
    {
        private static StudyDatabase _instance;
        private readonly Dictionary<string, Study> _studies = new Dictionary<string, Study>();
        private const string _logName = "TriliumAgentServer";
        
     
    }
}