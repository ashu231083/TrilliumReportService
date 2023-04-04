using AWSManager;
using HttpManager;
using LoggerManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLiteManager;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TriliumAgentDAL.ViewModel;
using UtilityHelper;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.UI.Xaml;

namespace TriliumAgentDAL.Controllers
{
    public class ServerServiceController
    {
        private const string _logName = "TriliumAgentServer";
        private readonly string AppPath = "ODC";
        private readonly string ConfigPath = "TriliumAgent";

        public void AddDicomFile(string filePath, List<Dictionary<string, string>> fileMetaData)
        {
            string json = JsonConvert.SerializeObject(fileMetaData);
            //StaticLogger.LogInfo("At AddDicomFile fileMetaData: " + json, _logName);

            // split string 
            string[] flnm = filePath.Split('\\');
            for (int i = 0; i < flnm.Length; i++)
            {
                //StaticLogger.LogInfo("step1 string: " + flnm[i], _logName);
            }
            //StaticLogger.LogInfo("FOLDER: " + flnm[flnm.Length - 2] + ", FILE: " + flnm[flnm.Length - 1], _logName);

            string filename = flnm[flnm.Length - 1];
            string filedir = flnm[flnm.Length - 2];

            string seriesId = "";

            foreach (var dictionary in fileMetaData)
            {
                //StaticLogger.LogInfo("Keyword: " + dictionary["Keyword"] + ", Value: " + dictionary["Value"], _logName);
                if (dictionary["Keyword"] == "SeriesNumber")
                {
                    seriesId = dictionary["Value"];
                }
            }


            //StaticLogger.LogInfo("seriesId: " + seriesId, _logName);


            CallUpdateDocumentStatusDicomServer(seriesId, filedir + "/" + filename);
            AddFileSyncQueue(filePath);
            MyFileUploadToS3(filePath);
            CallUpdateDocumentStatusCloud(seriesId, filedir + "/" + filename, "12");
            //API Call - Study - File upload to cloud

        }

        private void AddFileSyncQueue(string filePath)
        {
            try
            {
                const string query = "INSERT INTO FileSyncQueue(FilePath, IsSync) VALUES(@filePath, @isSync)";
                var args = new Dictionary<string, object>
            {
                {"@filePath", filePath},
                {"@isSync", "0"}
            };
                var numberOfRowsAffected = SQLiteDatabase.ExecuteWriteData(query, args);
                //StaticLogger.LogInfo("At AddFileSyncQueue numberOfRowsAffected= " + numberOfRowsAffected, _logName);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogInfo("Exception at AddFileSyncQueue. Message: " + ex.Message, _logName);
            }
        }

        private void MyFileUploadToS3(string filePath)
        {
            Guid guid = Guid.NewGuid();
            // split string 
            string[] flnm = filePath.Split('\\');
            for (int i = 0; i < flnm.Length; i++)
            {
                Console.WriteLine("step1 string: " + flnm[i]);
            }
            Console.WriteLine("FOLDER: " + flnm[flnm.Length - 2] + ", FILE: " + flnm[flnm.Length - 1]);
            string filename = flnm[flnm.Length - 1];
            string filedir = flnm[flnm.Length - 2];
            //StaticLogger.LogInfo("filename: " + filename, _logName);
            //StaticLogger.LogInfo("filedir: " + filedir, _logName);
            S3SDKHelper.UploadFile(filePath, filename, filedir);
        }

        public JToken GetWorkList()
        {
            //StaticLogger.LogTrace("GetWorkList | " + DateTime.Now.ToString(), _logName);
            string last_sync_dt = "";
            if (last_sync_dt == "")
            {
                DateTime aDate = DateTime.UtcNow;
                last_sync_dt = aDate.ToString("yyyy-MM-dd HH:mm:ss").ToString();
            }
            string clinic_id = RegistryHelper.GetRegistry("clinic_id", AppPath);
            //StaticLogger.LogTrace("GetWorkList | clinic_id=" + clinic_id, _logName);
            string machine_code = RegistryHelper.GetRegistry("machine_code", AppPath);
            //StaticLogger.LogTrace("GetWorkList | machine_code=" + machine_code, _logName);
            return CallWorkList(clinic_id, machine_code, last_sync_dt);
        }

        public DataTable GetWorkListSQL(string modality, string callingAE, string callingAEIP)
        {
            try
            {
                //HealthServiceController hsc = new HealthServiceController();

                //StaticLogger.LogTrace(@"GetWorkListSQL: Modality= " + modality + ", callingAE= " + callingAE + ", callingAEIP= " + callingAEIP, _logName);

                SQLController sqlController = new SQLController();
                DataTable ModalitySyncData = sqlController.GetModalitySync(callingAE);
                //StaticLogger.LogTrace(@"GetWorkListSQL: ModalitySyncData count: " + ModalitySyncData.Rows.Count, _logName);
                // Modality Verify 
                DateTime _DT = DateTime.UtcNow;
                //string lastSyncAt = _DT.ToString("yyyy-MM-dd HH:mm:ss");
                if (ModalitySyncData.Rows.Count <= 0)
                {
                    int isAdded = sqlController.InsertModalitySync(callingAE, callingAE);
                    //StaticLogger.LogTrace(@"GetWorkListSQL: New Added= " + isAdded, _logName);
                }
                else
                {
                    //StaticLogger.LogTrace(@"GetWorkListSQL: Start GetStudy from sql..modality: " + modality, _logName);
                    _DT = Convert.ToDateTime(ModalitySyncData.Rows[0]["LastSyncAt"].ToString());
                }
                // Study List get for Modality
                //StaticLogger.LogTrace(@"GetWorkListSQL: Start GetStudy from sql..modality: " + modality, _logName);

                DataTable StudyData = sqlController.GetStudyData(modality.ToString(), _DT.ToString("yyyy-MM-dd HH:mm:ss"));
                //StaticLogger.LogTrace(@"GetWorkListSQL: Study Count = " + StudyData.Rows.Count, _logName);
                if (StudyData.Rows.Count > 0)
                {
                    //string IDs = String.Join(",", StudyData.AsEnumerable().Select(x => x.Field<int>("ID").ToString()).ToArray());
                    string IDs = GetIDs(StudyData);

                    //StaticLogger.LogTrace(@"GetWorkListSQL: Study Ids = " + IDs, _logName);
                    // Update Modality in Study table and download dt                
                    int isUpdate = sqlController.UpdateDownloadStudy(IDs, callingAE);
                    //StaticLogger.LogTrace(@"GetWorkListSQL: Study download with callingAE " + callingAE + "update IDs = " + IDs, _logName);
                    // MOdality sync update with modality ae
                    sqlController.UpdateModalitySync(callingAE, callingAE);
                    //StaticLogger.LogTrace(@"GetWorkListSQL: Last sync update for CallingAE = " + callingAE, _logName);
                }
                //Update Modality in Study table and download dt
                return StudyData;
                //return null;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogTrace("Exception at GetWorkListSQL. Message: " + ex.Message, _logName);
                return null;
            }
        }

        private string GetIDs(DataTable dt)
        {
            string output = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                output += dt.Rows[i]["ID"].ToString();
                output += (i + 1 < dt.Rows.Count) ? "," : string.Empty;
            }
            return output;
        }

        private JToken CallWorkList(string clinic_id, string machine_code, string last_sync_dt)
        {
            try
            {
                //StaticLogger.LogTrace("CallWorkList | " + clinic_id + " " + machine_code, _logName);
                if (clinic_id != "")
                {
                    string api_url = "https://trillium.smartrxhub.com/dev-api/api/service/v1/worklist";

                    string url = api_url + "?clinic_id=" + clinic_id + "&machine_code=" + machine_code + "&last_sync_date=" + last_sync_dt;
                    //StaticLogger.LogTrace("CallWorkList | " + url, _logName);
                    HttpClient httpClient = new HttpClient();
                    string result = httpClient.GetRemoteUrl(url);
                    //StaticLogger.LogTrace("CallWorkList | " + result, _logName);
                    JObject jObject = JObject.Parse(result);
                    //StaticLogger.LogTrace("CallWorkList | JObject: " + jObject.ToString(), _logName);
                    JToken responseData = jObject["responseData"];
                    //StaticLogger.LogTrace("CallWorkList | ResponseData: " + responseData.ToString(), _logName);
                    return responseData;
                }
                else
                {
                    //StaticLogger.LogError("CallWorkList | Clinic not configure. Please config clinic", _logName);
                }
                return null;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogTrace("CallWorkList" + ex.Message, _logName);
                return null;
            }
        }

        private JToken CallUpdateDocumentStatusDicomServer(string study_id, string file_name)
        {
            try
            {
                string clinic_id = RegistryHelper.GetRegistry("clinic_id", AppPath);
                //StaticLogger.LogTrace("GetWorkList | clinic_id=" + clinic_id, _logName);
                string machine_code = RegistryHelper.GetRegistry("machine_code", AppPath);
                //StaticLogger.LogTrace("GetWorkList | machine_code=" + machine_code, _logName);

                //StaticLogger.LogTrace("CallUpdateDocumentStatus | " + clinic_id + " " + machine_code, _logName);
                if (clinic_id != "")
                {
                    string api_url = "https://trillium.smartrxhub.com/dev-api/api/service/v1/worklist/study/modality-document-info";
                    NameValueCollection nvc = new NameValueCollection
                    {
                        { "clinic_id", clinic_id },
                        { "machine_code", machine_code },
                        { "service_id ", study_id },
                        { "image_name", file_name},
                    };
                    HttpClient httpClient = new HttpClient();
                    string result = httpClient.PostRemoteUrl(api_url, null, nvc, "");
                    JObject jObject = JObject.Parse(result);
                    JToken responseData = jObject["responseData"];
                    //StaticLogger.LogTrace(result, _logName);
                    return responseData;
                }
                else
                {
                    //StaticLogger.LogError("CallWorkList | Clinic not configure. Please config clinic", _logName);
                }
                return null;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogTrace("CallWorkList" + ex.Message, _logName);
                return null;
            }
        }

        private JToken CallUpdateDocumentStatusCloud(string study_id, string document_path, string document_id)
        {
            try
            {
                string clinic_id = RegistryHelper.GetRegistry("clinic_id", AppPath);
                //StaticLogger.LogTrace("GetWorkList | clinic_id=" + clinic_id, _logName);
                string machine_code = RegistryHelper.GetRegistry("machine_code", AppPath);
                //StaticLogger.LogTrace("GetWorkList | machine_code=" + machine_code, _logName);

                //StaticLogger.LogTrace("CallUpdateDocumentStatus | " + clinic_id + " " + machine_code, _logName);
                if (clinic_id != "")
                {
                    string api_url = "https://trillium.smartrxhub.com/dev-api/api/service/v1/worklist/study/dicom-document-info";
                    NameValueCollection nvc = new NameValueCollection
                    {
                        { "clinic_id", clinic_id },
                        { "machine_code", machine_code },
                        { "service_id ", study_id },
                        { "document_id", document_id},
                        { "document_path", document_path},
                    };
                    HttpClient httpClient = new HttpClient();
                    string result = httpClient.PostRemoteUrl(api_url, null, nvc, "");
                    JObject jObject = JObject.Parse(result);
                    JToken responseData = jObject["responseData"];
                    //StaticLogger.LogTrace(result, _logName);
                    return responseData;
                }
                else
                {
                    //StaticLogger.LogError("CallWorkList | Clinic not configure. Please config clinic", _logName);
                }
                return null;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogTrace("CallWorkList" + ex.Message, _logName);
                return null;
            }
        }



        public bool UploadServiceDocument(string patient_encounter_study_id, string document_type, string document_path)
        {
            try
            {
                string username = RegistryHelper.GetRegistry("username", ConfigPath);
                //StaticLogger.LogTrace("GetWorkList | username=" + username, _logName);
                string machine_code = RegistryHelper.GetRegistry("machine_code", ConfigPath);
                string token = RegistryHelper.GetRegistry("token", ConfigPath);
                //StaticLogger.LogTrace("GetWorkList | machine_code=" + machine_code, _logName);
                string[] str1 = new string[1] { document_path.ToString() };
                NameValueCollection nvc = new NameValueCollection();
                //StaticLogger.LogTrace("CallUpdateDocumentStatus | " + username + " " + machine_code, _logName);

                //string api_url = "https://trillium.smartrxhub.com/dev-api/api/v1/reception/patient/encounter/service-document";

                string api_url = RegistryHelper.GetRegistry("company_api_url", ConfigPath);
                if (document_type == "1")
                {
                    //api_url = api_url + "/encounter/service-document"; //api_url + " /reception/patient/encounter/service-document";
                    //nvc.Add("patient_encounter_study_id", patient_encounter_study_id);

                    api_url = api_url + "/encounter/service-document";
                    nvc.Add("patient_encounter_study_id", patient_encounter_study_id);
                }
                else if (document_type == "3")
                {
                    //api_url = api_url + "/encounter/document";
                    //nvc.Add("patient_encounter_id", patient_encounter_study_id);
                    api_url = api_url + "/encounter/document";
                    nvc.Add("patient_encounter_id", patient_encounter_study_id);
                }
                //StaticLogger.LogTrace("api_url:" + api_url, _logName);




                nvc.Add("document_type", document_type);
                nvc.Add("token", token);
                HttpClient httpClient = new HttpClient();

                string result = httpClient.PostRemoteUrl(api_url, str1, nvc, "document_file[]");
                //StaticLogger.LogTrace(result, _logName);
                return true;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at UploadServiceDocument, Message: " + ex.Message, _logName);
                return false;
            }
        }





        public JToken UploadEncounterDocument(string patient_encounter_id, string document_type, string document_path)
        {
            try
            {
                string username = RegistryHelper.GetRegistry("username", ConfigPath);
                //StaticLogger.LogTrace("GetWorkList | username=" + username, _logName);
                string machine_code = RegistryHelper.GetRegistry("machine_code", ConfigPath);
                //StaticLogger.LogTrace("GetWorkList | machine_code=" + machine_code, _logName);
                string token = RegistryHelper.GetRegistry("token", ConfigPath);
                //StaticLogger.LogTrace("CallUpdateDocumentStatus | " + username + " " + machine_code, _logName);
                string[] str1 = new string[1] { document_path.ToString() };
                //string api_url = "https://trillium.smartrxhub.com/api/v1/reception/patient/encounter/document";
                //string api_url = "https://trillium.smartrxhub.com/dev-api/api/v1/reception/patient/encounter/document";
                NameValueCollection nvc = new NameValueCollection();


                string api_url = RegistryHelper.GetRegistry("company_api_url", ConfigPath);
                if (document_type == "1")
                {
                    api_url = api_url + "/encounter/service-document";

                    nvc.Add("patient_encounter_study_id", patient_encounter_id);
                }
                else if (document_type == "3")
                {
                    api_url = api_url + "/encounter/document";

                    nvc.Add("patient_encounter_id", patient_encounter_id);

                }

                nvc.Add("document_type", document_type);
                nvc.Add("token", token);
                HttpClient httpClient = new HttpClient();

                string result = httpClient.PostRemoteUrl(api_url, str1, nvc, "document_file[]");
                //StaticLogger.LogTrace(result, _logName);
                return true;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at UploadEncounterDocument, Message: " + ex.Message, _logName);
                return null;
            }
        }



        public string DownloadEncounterDocument(string url)
        {
            try
            {
                string username = RegistryHelper.GetRegistry("username", ConfigPath);
                //StaticLogger.LogTrace("username=" + username, _logName);
                string machine_code = RegistryHelper.GetRegistry("machine_code", ConfigPath);
                //StaticLogger.LogTrace("machine_code=" + machine_code, _logName);
                string token = RegistryHelper.GetRegistry("token", AppPath);
                //StaticLogger.LogTrace("token=" + token, _logName);
                string api_url = "https://trillium.smartrxhub.com/dev-api/api/agent/v1/encounter/burn-document?patient_encounter_ids=" + url;
                //StaticLogger.LogTrace("api_url=" + api_url, _logName);
                HttpClient httpClient = new HttpClient();
                string result = httpClient.HttpGetRequest(api_url, token);//"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC90cmlsbGl1bS5zbWFydHJ4aHViLmNvbVwvYXBpXC9hZ2VudFwvdjFcL3VzZXJzXC9sb2dpbiIsImlhdCI6MTY2NTE0MTE2MSwibmJmIjoxNjY1MTQxMTYxLCJqdGkiOiJoVkdaaHdoTk0wdkVaWHhPIiwic3ViIjo1MSwicHJ2IjoiMjNiZDVjODk0OWY2MDBhZGIzOWU3MDFjNDAwODcyZGI3YTU5NzZmNyJ9.16nVhwNzWJ2pK-UurQcF_oLjHPWPDIpavQdryTHW7u8");
                //StaticLogger.LogTrace("result=" + result, _logName);
                return result;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at DownloadEncounterDocument, Message: " + ex.Message, _logName);
                return null;
            }
        }


        public async Task<string> DownloadDocumentAsync(string url)
        {
            try
            {
                //string username = RegistryHelper.GetRegistry("username", Path);
                ////StaticLogger.LogTrace("GetWorkList | username=" + username, _logName);
                //string machine_code = RegistryHelper.GetRegistry("machine_code", Path);
                ////StaticLogger.LogTrace("GetWorkList | machine_code=" + machine_code, _logName);
                //string token = RegistryHelper.GetRegistry("token", Path);

                //string api_url = "https://trillium.smartrxhub.com/dev-api/api/agent/v1/encounter/burn-document?patient_encounter_ids=" + url;
                HttpClient httpClient = new HttpClient();
                string result = httpClient.GetRemoteUrl(url);
                return result;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at DownloadDocument, Message: " + ex.Message, _logName);
                return null;
            }
        }


        //convert img to binary
        public static byte[] ImageToBinary(string imagePath)
        {
            try
            {
                FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, (int)fileStream.Length);
                fileStream.Close();
                return buffer;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at ImageToBinary, Message: " + ex.Message, _logName);
                return null;
            }
        }
    }
}
