using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgentDAL.ViewModel
{
    class FileSyncQueueModel
    {
        public int ID { get; set; }
        public string FilePath { get; set; }
        public string IsSync { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
