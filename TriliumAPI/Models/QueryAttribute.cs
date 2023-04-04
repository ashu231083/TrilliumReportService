using FellowOakDicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgent.Models
{
    public class QueryAttribute
    {
        public string RawValue { get; set; }
        public string RawKey { get; set; }

        public DicomTag Tag { get; set; }

    }
}