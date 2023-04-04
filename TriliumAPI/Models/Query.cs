using FellowOakDicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgent.Models
{
    public class Query
    {
        public Query()
        {
            QueryAttributes = new Dictionary<DicomTag, QueryAttribute>();
            IncludeFields = new List<DicomTag>();
            IncludeAll = false;
            FuzzyMatching = false;
            Limit = 50;
            Offset = 0;
            Errors = new List<string>();
        }

        public Dictionary<DicomTag, QueryAttribute> QueryAttributes;
        public List<DicomTag> IncludeFields;
        public bool IncludeAll;
        public bool FuzzyMatching;
        public int Limit;
        public int Offset;
        public List<string> Errors;



        public class requestdata
        {
            public string pat_code { get; set; }
        }

        public QueryAttribute FindQueryAttribute(ushort group, ushort element)
        {
            QueryAttribute value;
            var tag = new DicomTag(group, element);
            QueryAttributes.TryGetValue(tag, out value);
            return value;
        }
    }
}