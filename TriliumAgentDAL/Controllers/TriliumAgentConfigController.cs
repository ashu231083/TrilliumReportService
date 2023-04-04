using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.NetworkInformation;
using TriliumAgentDAL.ViewModel;
using HttpManager;
using LoggerManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using UtilityHelper;

namespace TriliumAgentDAL.Controllers
{
    public class TriliumAgentConfigController
    {
        private HttpClient httpClient;
        private readonly string Path = "TriliumAgent";
        private const string _logName = "TriliumAgentConfig";

        public bool CheckKeyConfiguration()
        {
            string machine_code = RegistryHelper.GetRegistry("machine_code", Path);
            if (machine_code.Trim().Length > 0)
            {
                return true;
            }
            return false;
        }

        public bool KeyVerification(string key)
        {
            try
            {
                string url = "https://smartpaper.smartrxhub.com/api/index.php?";
                //StaticLogger.LogTrace("url: " + url, _logName);

                NameValueCollection nvc = new NameValueCollection
            {
                { "action", "checkValidKey" },
                { "requestJSON", "{\"key\":\"" + key + "\"}" }
            };

                httpClient = new HttpClient();
                //string result = httpClient.HttpPostRequest(url, nvc);
                string result = httpClient.PostRemoteUrl(url, null, nvc);
                JObject jObject = JObject.Parse(result);
                JToken response = jObject["responseData"];
                bool isStored = StoreKeyConfigData(key, response);
                //StaticLogger.LogTrace(result, _logName);
                return isStored;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at KeyVerification. Message: " + ex.Message, _logName);
                return false;
            }
        }

        public bool StoreKeyConfigData(string key, JToken response)
        {
            try
            {
                if (response["configData"] != null)
                {
                    JObject configdata = JObject.Parse(response["configData"][0].ToString());
                    string company_code = (string)configdata["company_code"];
                    string company_api_url = (string)configdata["api_url"];
                    string machine_code = System.Guid.NewGuid().ToString();
                    if (company_code != "")
                    {
                        RegistryHelper.WriteRegistry("company_code", company_code, Path);
                        RegistryHelper.WriteRegistry("company_api_url", company_api_url, Path);
                        RegistryHelper.WriteRegistry("company_licensekey", key, Path);
                        RegistryHelper.WriteRegistry("machine_code", machine_code, Path);



                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at StoreKeyConfigData. Message: " + ex.Message, _logName);
                return false;
            }
        }


        public bool CheckClinicConfic()
        {
            try
            {
                string clinic_code = RegistryHelper.GetRegistry("clinic_code", Path);
                if (clinic_code.Trim().Length > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at CheckClinicConfic. Message: " + ex.Message, _logName);
                return false;
            }
        }

        public List<ClinicModel> GetLocations()
        {
            //string result = "{\"clinicData\":[{\"clinic_id\":\"1\",\"clinic_name\":\"clinic1\",\"clinic_code\":\"c1\"},{\"clinic_id\":\"2\",\"clinic_name\":\"clinic2\",\"clinic_code\":\"c2\"},{\"clinic_id\":\"3\",\"clinic_name\":\"clinic3\",\"clinic_code\":\"c3\"}]}";
            string url = RegistryHelper.GetRegistry("company_api_url", Path);

            httpClient = new HttpClient();
            string result = httpClient.GetRemoteUrl(url + "/clinics");

            JObject jObject = JObject.Parse(result);
            JToken jToken = jObject["responseData"]["clinics"];
            var response = new List<ClinicModel>();

            foreach (var data in jToken)
            {
                ClinicModel clinicModel = new ClinicModel();
                var p = JsonConvert.DeserializeObject<ClinicModel>(data.ToString());
                //StaticLogger.LogTrace(data.ToString(), _logName);
                //var p = JsonConvert.DeserializeObject<ClinicModel>(data.ToString());
                ////StaticLogger.LogTrace(p.ToString(),_logName);
                //JObject clinicData = JObject.Parse(data.ToString());
                ////StaticLogger.LogTrace(clinicData["clinic_name"].ToString(), _logName);
                clinicModel.id = (int)data["id"];
                clinicModel.short_name = data["short_name"].ToString();
                clinicModel.clinic_name = data["clinic_name"].ToString();
                response.Add(p);
            }
            return response;
        }

        public bool SaveClinicConfig(string clinic_code, string clinic_name)
        {
            string machine_code = RegistryHelper.GetRegistry("machine_code", Path);
            bool isConfig = ClinicConfig(machine_code, clinic_code);
            if (isConfig)
            {
                RegistryHelper.WriteRegistry("clinic_code", clinic_code, Path);
                RegistryHelper.WriteRegistry("clinic_name", clinic_name, Path);
                RegistryHelper.WriteRegistry("clinic_id", "1", Path);
                RegistryHelper.WriteRegistry("mac_address", GetMACAddress().ToString(), Path);
                return true;
            }
            return false;
        }


        public bool SaveUserLogin(string username, string password)
        {
            try
            {
                //string machine_code = RegistryHelper.GetRegistry("machine_code", Path);
                bool isConfig = UserLogin(username, password);
                if (isConfig)
                {
                    RegistryHelper.WriteRegistry("username", username, Path);
                    RegistryHelper.WriteRegistry("password", password, Path);
                    RegistryHelper.WriteRegistry("mac_address", GetMACAddress().ToString(), Path);
                    RegistryHelper.WriteRegistry("machine_code", System.Guid.NewGuid().ToString(), Path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at SaveUserLogin. Message: " + ex.Message, _logName);
                return false;
            }

        }

        private bool ClinicConfig(string machine_code, string clinic_code)
        {
            //string url = "https://smartpaper.smartrxhub.com/api/index.php?";
            string url = RegistryHelper.GetRegistry("company_api_url", Path);

            NameValueCollection nvc = new NameValueCollection
            {
                { "action", "checkValidKey" },
                { "machine_code", machine_code },
                { "clinic_code", clinic_code }
            };

            //httpClient = new HttpClient();
            //string result = httpClient.HttpPostRequest(url, nvc);
            //JObject jObject = JObject.Parse(result);
            //JToken response = jObject["responseData"];
            //bool isStored = StoreKeyConfigData(key, response);
            ////StaticLogger.LogTrace(result,_logName);
            //return isStored;
            return true;
        }


        private bool UserLogin(string username, string password)
        {
            try
            {
                //string url = "https://trillium.smartrxhub.com/api/v1/users/login";
                string url = RegistryHelper.GetRegistry("company_api_url", Path) + "/users/login";
                //StaticLogger.LogTrace("url: " + url, _logName);

                NameValueCollection nvc = new NameValueCollection
            {
                    { "username", username },
                    { "password", password }
                //{ "action", "checkValidKey" },
                //{ "requestJSON", "{\"key\":\"" + username + "\"}" }
            };

                httpClient = new HttpClient();
                //string result = httpClient.HttpPostRequest(url, nvc);
                string result = httpClient.UserLoginUrl(url, null, nvc);
                JObject jObject = JObject.Parse(result);
                string response = jObject["responseData"]["token"].ToString();
                //bool isStored = StoreKeyConfigData(key, response);
                //StaticLogger.LogInfo("token: " + response, _logName);

                RegistryHelper.WriteRegistry("token", response, Path);
                return true;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at KeyVerification. Message: " + ex.Message, _logName);
                return false;
            }
        }

        private string GetMACAddress()
        {
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String sMacAddress = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)// only return MAC Address from first card  
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                }
                return sMacAddress;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at GetMACAddress. Message: " + ex.Message, _logName);
                return "";
            }
        }

    }
}
