

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TriliumAgent.Models;
using TriliumAgentDAL.Controllers;
using static TriliumAgent.Models.Query;
using static TriliumAgentDAL.ViewModel.WorklistModel;
using System.Configuration;
using System.IO.Compression;
using TriliumAgent.Helper;
using System.Web.Script.Serialization;

namespace TriliumAgent.Controllers
{
    public class OperationController : ApiController
    {
        private const string _logName = "TriliumAgentServer";
        List<requestdata> data = new List<requestdata>();

        [ActionName("Encrypt")]
        public JObject GetEncrypt(HttpRequestMessage requestMessage, string str)
        {
            string key = "MModalXml";
            HelperClass HC = new HelperClass();

            string encrypted_str = HC.EncryptString(str, key, Encoding.Unicode);


            //Console.WriteLine("str: " + str + ", encrypted_str: " + encrypted_str);

            string result = "{\"success\":\"True\",\"encrypted_str\":\"" + encrypted_str + "\"}";


            JObject json = JObject.Parse(result);

            return json;


        }


        private void FileUpload()
        {
            try
            {
                TriliumAgentDAL.Controllers.ServerServiceController ssc = new TriliumAgentDAL.Controllers.ServerServiceController();
                //file will be saved to C:\\Scanner\\
                ssc.UploadServiceDocument("519", "1", "C:\\Users\\Lenovo\\OneDrive\\Desktop\\WCG.png");
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at fileuploadbtn_Click. Message: " + ex.Message, _logName);
            }
        }


        //Clear local directory
        private void ClearExistingData(string path)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);

                foreach (FileInfo file in directory.GetFiles())
                {
                    //StaticLogger.LogInfo("file deleted: " + file, _logName);
                    file.Delete();
                }

                Directory.Delete(path + "MicroDicom", true);
                //StaticLogger.LogInfo("ClearExistingData done.");
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at ClearExistingData: " + ex.Message, _logName);
            }
        }

        //ZIP download
        private void GetZIPFile(string file, string path)
        {
            try
            {
                //StaticLogger.LogInfo("NEW-----", _logName);
                //StaticLogger.LogInfo("ZIP File: " + file.ToString() + ", pathToSave: " + path + "MicroDicom", _logName);
                var extention = Path.GetExtension(file.ToString());
                string fname = "";
                if (extention == ".zip")
                {
                    fname = extention;
                }
                try
                {
                    var client = new WebClient();
                    //StaticLogger.LogInfo("ZIPFile: " + file.ToString() + ", pathToSave: " + path + "MicroDicom", _logName);
                    client.DownloadFile(file.ToString(), path + "MicroDicom.zip");
                }
                catch (Exception ex)
                {
                    //StaticLogger.LogError("Exception at download ZIP file: " + file.ToString() + ", Message: " + ex.Message, _logName);
                }


                string dirName = "C:\\TriliumAgentCD\\ZIP\\MicroDicom";
                string zipName = "C:\\TriliumAgentCD\\ZIP\\MicroDicom.zip";
                try
                {
                    //StaticLogger.LogInfo("NEW----1" + "zipName: " + zipName                     + "dirName: " + dirName, _logName);
                    //ZipFile.ExtractToDirectory(zipName, @"C:\Users\user\Desktop\TriliumAgentCD");
                    ZipFile.ExtractToDirectory(zipName, dirName);
                }
                catch (Exception ex)
                {
                    //StaticLogger.LogError("Exception at unzip file: " + zipName + ", Message: " + ex.Message, _logName);
                }
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at GetZIPFile, Message: " + ex.Message, _logName);
            }
        }
    }
}
