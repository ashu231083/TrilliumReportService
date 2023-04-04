using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgentDAL.ViewModel
{
    public class HealthModel
    {
        public class DicomMachine
        {
            public int id { get; set; }
            public object machine_name { get; set; }
            public string machine_code { get; set; }
            public object user_id { get; set; }
            public int clinic_id { get; set; }
            public int is_active { get; set; }
            public string mac_address { get; set; }
            public string disk_storage { get; set; }
            public string cpu_usage { get; set; }
            public DateTime health_dt { get; set; }
            public string last_sync_date { get; set; }
            public string created_at { get; set; }
        }

        public class ResponseData
        {
            public DicomMachine dicomMachine { get; set; }
            public SyncData syncData { get; set; }
        }

        public class Root
        {
            public string success { get; set; }
            public string message { get; set; }
            public ResponseData responseData { get; set; }
        }

        public class SyncData
        {
            public int sync_my_worklist { get; set; }
        }

    }
}
