using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgent.Models
{
    public class PrintLabel
    {
        public string patient_lastname { get; set; }
        public string patient_firstname { get; set; }
        public string health_card_no { get; set; }
        public string mrn_no { get; set; }
        public string patient_gender { get; set; }
        public string patient_age { get; set; }

        public string patient_dob { get; set; }
        public string patient_phone_no { get; set; }
        public string encounter_date { get; set; }
        public string accession_number { get; set; }
        public string reffered_doctor { get; set; }
    }
}
