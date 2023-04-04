using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgent.Models
{
    public class DocumentClass
    {
        public int id { get; set; }
        public int patient_encounter_id { get; set; }
        public string document_name { get; set; }
        public string original_name { get; set; }
        public string document_type { get; set; }
        public string document_path { get; set; }


    }
}
