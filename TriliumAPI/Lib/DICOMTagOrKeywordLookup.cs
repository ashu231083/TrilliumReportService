using FellowOakDicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgent.Lib
{
    public class DICOMTagOrKeywordLookup
    {
        private static DICOMTagOrKeywordLookup _instance;

        private readonly Dictionary<string, DicomDictionaryEntry> _keywords = new Dictionary<string, DicomDictionaryEntry>();
        private const string _logName = "WebServer";

        // TODO: manage singleton lifecycle through DI container and remove this method
     
    }
}