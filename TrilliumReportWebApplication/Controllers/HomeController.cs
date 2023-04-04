using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Security.Cryptography;
using System.Text;
using XSystem.Security.Cryptography;

namespace TrilliumReportWebApplication.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EncryptController : Controller
    {
        private readonly ILogger<EncryptController> _logger;


        public EncryptController(ILogger<EncryptController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<ThreeDashEncrptClass> Get(string str)
        {

            string key = "MModalXml";
            HelperClass HC = new HelperClass();

            string encrypted_str = HC.EncryptString(str, key, Encoding.Unicode);


            Console.WriteLine("str: " + str + ", encrypted_str: " + encrypted_str);

            return Enumerable.Range(1, 1).Select(index => new ThreeDashEncrptClass
            {
                encrypted_str = encrypted_str
            })
            .ToArray();
        }




    }
}
