using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgentDAL.ViewModel
{
   public class WorklistModel
    {
        public class MyWorklist
        {
            public int id { get; set; }
            public int clinic_id { get; set; }
            public string patient_name { get; set; }
            public string patient_last_name { get; set; }
            public string patient_first_name { get; set; }
            public int patient_id { get; set; }
            public string patient_dob { get; set; }
            public string mrn { get; set; }
            public string case_type_name { get; set; }
            public string case_image_url { get; set; }
            public string patient_gender { get; set; }
            public DateTime created_at { get; set; }
            public string service_dt { get; set; }
            public string service_time { get; set; }
            public string clinic_name { get; set; }
            public string referrer_physician_name { get; set; }
            public List<Study> study { get; set; }
        }

        public class Pivot
        {
            public int patient_encounter_id { get; set; }
            public int study_id { get; set; }
            public int id { get; set; }
        }

        public class ResponseData
        {
            public List<MyWorklist> myWorklists { get; set; }
        }

        public class Root
        {
            public string success { get; set; }
            public string message { get; set; }
            public ResponseData responseData { get; set; }
        }

        public class Study
        {
            public int id { get; set; }
            public int study_id { get; set; }
            public string study_uid { get; set; }
            public string study_name { get; set; }
            public string physician_name { get; set; }
            public string technologist_name { get; set; }
            public int modality_category_id { get; set; }
            public string category_name { get; set; }
            public int modality_id { get; set; }
            public string modality_name { get; set; }
            public string modality_code { get; set; }
            public string modality_color { get; set; }
            public string status_name { get; set; }
            public string status_color { get; set; }
            public string accession_number { get; set; }
            public int? reading_physician_id { get; set; }
            public Pivot pivot { get; set; }
        }

    }
}
