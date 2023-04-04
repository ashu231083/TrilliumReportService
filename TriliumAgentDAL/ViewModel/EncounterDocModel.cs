using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgentDAL.ViewModel
{
    public class EncounterDocModel
    {
        public int id { get; set; }
        public string document_name { get; set; }
        public string original_name { get; set; }
        public string document_type { get; set; }
        public string document_path { get; set; }
        public string patient_encounter_id { get; set; }
    }
}
