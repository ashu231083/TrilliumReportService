using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgentDAL.ViewModel
{
    public class ConfigDataModel
    {
        //{"company_code":"COM20151219120733156780","dt_added":"2022-03-22 04:22:32","api_url":"https:\/\/qampgl.smartrxhub.com\/qa\/v1_4epaper\/api\/index.php","portal_url":"https:\/\/qampgl.smartrxhub.com\/qa\/epaper_panel_v1\/src\/","support_url":"https:\/\/qampgl.smartrxhub.com\/qa\/support\/v1_8epaper\/api\/index.php","mobile_url":"https:\/\/qampgl.smartrxhub.com\/qa\/MobileApi\/epaper_v1\/index.php","dt":"2022-03-22 04:22:32","activation_key":"4EPAPER41"}
        public string CompanyCode { get; set; }
        public string URL { get; set; }
        public string SupportURL { get; set; }
    }
}
