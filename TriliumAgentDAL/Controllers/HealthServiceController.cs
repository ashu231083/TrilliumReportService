using TriliumAgentDAL.ViewModel;
using HttpManager;
using LoggerManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLiteManager;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UtilityHelper;
using static TriliumAgentDAL.ViewModel.HealthModel;

namespace TriliumAgentDAL.Controllers
{
    public class HealthServiceController
    {
        private readonly string Path = "ODC";
        private const string _logName = "TriliumSync";
        private HttpClient httpClient;
        List<FileSyncQueueModel> fileSyncQueuesList;
        public void HealthCall()
        {
            try
            {
                //string result = "{\"clinicData\":[{\"clinic_id\":\"1\",\"clinic_name\":\"clinic1\",\"clinic_code\":\"c1\"},{\"clinic_id\":\"2\",\"clinic_name\":\"clinic2\",\"clinic_code\":\"c2\"},{\"clinic_id\":\"3\",\"clinic_name\":\"clinic3\",\"clinic_code\":\"c3\"}]}";
                string url = RegistryHelper.GetRegistry("company_api_url", Path);
                string machine_name = RegistryHelper.GetRegistry("clinic_name", Path);
                string machine_code = RegistryHelper.GetRegistry("machine_code", Path);
                string clinic_id = RegistryHelper.GetRegistry("clinic_id", Path);
                string mac_address = RegistryHelper.GetRegistry("mac_address", Path);

                //StaticLogger.LogTrace("HealthCall  url: " + url + ", machine_name: " + machine_name + ", machine_code: " + machine_code + ", clinic_id: " + clinic_id + ", mac_address: " + mac_address, _logName);

                // Health Post to server 
                httpClient = new HttpClient();
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("machine_name", machine_name);
                nvc.Add("machine_code", machine_code);
                nvc.Add("clinic_id", clinic_id);
                nvc.Add("mac_address", mac_address);
                nvc.Add("disk_storage", "120000");
                nvc.Add("cpu_usage", "26");

                string result = httpClient.PostRemoteUrl(url + "/update-machine-health", null, nvc);
                //StaticLogger.LogTrace("HealthCall result: " + result, _logName);

                JObject jObject = JObject.Parse(result);
                JToken jTokenMachineData = jObject["responseData"]["dicomMachine"];
                JToken jTokenSyncData = jObject["responseData"]["syncData"];

                ////StaticLogger.LogTrace("HealthCall result jObject: " + jObject + ", dicomMachine jToken: " + jTokenMachineData + ", syncData jToken: " + jTokenSyncData, _logName);
                //machineData = JsonConvert.DeserializeObject<DicomMachine>(result);
                var DicomMachineJsonobject = JsonConvert.DeserializeObject<DicomMachine>(result);
                var SyncDataJsonobject = JsonConvert.DeserializeObject<SyncData>(result);
                ////StaticLogger.LogTrace("jObject SyncDataJsonobject sync_my_worklist: " + SyncDataJsonobject.sync_my_worklist, _logName);

                string json = JsonConvert.SerializeObject(SyncDataJsonobject);
                var ob = JsonConvert.DeserializeObject<SyncData>(result);
                //StaticLogger.LogTrace("jToken ob: " + ob.sync_my_worklist + ", json: " + json + ", jToken: " + JsonConvert.SerializeObject(jTokenSyncData), _logName);

                if (SyncDataJsonobject.sync_my_worklist > 0)
                {
                    //StaticLogger.LogTrace("sync_my_worklist: " + SyncDataJsonobject.sync_my_worklist, _logName);
                    //GetWorkList(machine_code);
                }
                else
                {
                    //StaticLogger.LogTrace("No call for worklist.", _logName);
                }

                GetWorkList(machine_code);
                //StaticLogger.LogTrace("HealthCall - before GetPendingSync", _logName);
                DataTable dt = GetPendingSync();

                if (dt == null)
                {
                    //StaticLogger.LogTrace("HealthCall - DataTable Null", _logName);
                }
                else
                {
                    SyncFile(dt);
                }
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at HealthCall. Message: " + ex.Message, _logName);
            }
        }


        public string TriliumHealthCall(NameValueCollection nvc)
        {
            try
            {
                //StaticLogger.LogInfo("At TriliumHealthCall.", _logName);
                // Health Post to server 
                httpClient = new HttpClient();
                NameValueCollection nvcdata = new NameValueCollection();

                nvcdata.Add("machine_code", nvc["machine_code"]);
                nvcdata.Add("mac_add", nvc["mac_add"]);
                nvcdata.Add("teamviewer_id", nvc["teamviewer_id"]);
                nvcdata.Add("app_ver", nvc["app_ver"]);
                nvcdata.Add("ip_address", nvc["ip_address"]);
                nvcdata.Add("public_ip", nvc["public_ip"]);
                nvcdata.Add("token",  nvc["token"]);

                //StaticLogger.LogInfo("HealthCall url: " + nvc["url"], _logName);
                StaticLogger.LogInfo("DEVANG 0610 Trilium HealthCall, AppVersion: " + nvc["app_ver"] +
                     ", facility_code: " + nvc["facility_code"] +
                    ", machine_code: " + nvc["machine_code"] +
                    ", mac_add: " + nvc["mac_add"] +
                    ", ip_address: " + nvc["ip_address"] +
                     ", public_ip: " + nvc["public_ip"] +
                     ", token: " + nvc["token"], _logName);

                string result = httpClient.PostRemoteUrl(nvc["url"], null, nvcdata);
                //StaticLogger.LogInfo("HealthCall result: " + result, _logName);
                return result;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at HealthCall. Message: " + ex.Message, _logName);
                return "";
            }
        }

        private void SyncFile(DataTable dt)
        {
            try
            {
                //StaticLogger.LogTrace("SyncFile: ", _logName);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JToken result = CallAPI(dt.Rows[i]["FilePath"].ToString());
                    int isUpdate = UpdatePendingQueue(Convert.ToInt32(dt.Rows[i]["ID"]));
                    if (isUpdate > 0)
                    {
                        //StaticLogger.LogTrace("File sync successfully. ID: " + dt.Rows[i]["ID"].ToString() + " FilePath: " + dt.Rows[i]["FilePath"].ToString(), _logName);
                    }
                    else
                    {
                        //StaticLogger.LogTrace("File sync fail. ID: " + dt.Rows[i]["ID"].ToString() + " FilePath: " + dt.Rows[i]["FilePath"].ToString(), _logName);
                    }
                }
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at SyncFile. Message: " + ex.Message, _logName);
            }
        }

        private JToken CallAPI(string filePath)
        {
            try
            {
                string url = "https://trillium.smartrxhub.com/dev-api/api/service/v1/encounter/dicom-document";

                NameValueCollection nvc = new NameValueCollection
            {
                { "batch_code", "BATCH202203231252" },
                { "machine_code", "A1B2-C3D3-E4F5-G7H8" },
                { "clinic_id", "1" },
                { "patient_id", "1"},
                { "accession_number", "123"}
            };
                string[] files = { filePath };
                HttpClient httpClient = new HttpClient();
                string result = httpClient.PostRemoteUrl(url, files, nvc, "document_file");
                JObject jObject = JObject.Parse(result);
                JToken response = jObject["responseData"];
                //StaticLogger.LogTrace(result, _logName);
                return response;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at CallAPI. Message: " + ex.Message, _logName);
                return "";
            }
        }

        private DataTable GetPendingSync()
        {
            try
            {
                //StaticLogger.LogTrace("GetPendingSync", _logName);
                const string query = "SELECT * FROM FileSyncQueue WHERE isSync=@isSync ORDER BY ID ASC LIMIT 1";
                var args = new Dictionary<string, object>
                {
                    {"@isSync", "0"}
                };
                return SQLiteDatabase.ExecuteReadData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at GetPendingSync. Message: " + ex.Message, _logName);
                return null;
            }

        }

        public DataTable GetworklistSQL(int WorklistId)
        {
            try
            {
                //StaticLogger.LogTrace("STEP1 GetworklistSQL ", _logName);
                const string query = "SELECT * " +
                    "FROM WorkList " +
                    "WHERE WorklistId=@WorklistId";
                var args = new Dictionary<string, object>
                {
                     {"@WorklistId", WorklistId}
                };
                //StaticLogger.LogTrace("GetworklistSQL STEP2", _logName);
                return SQLiteDatabase.ExecuteReadData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at GetworklistSQL. Message: " + ex.Message, _logName);
                return null;
            }

        }

        public DataTable GetstudySQL(int WorklistId, int StudyId)
        {
            try
            {
                //StaticLogger.LogTrace("STEP1 GetstudySQL ", _logName);
                const string query = "SELECT * " +
                    "FROM Study " +
                    "WHERE WorklistId=@WorklistId AND StudyId=@StudyId";
                var args = new Dictionary<string, object>
                {
                    {"@WorklistId",WorklistId },
                    {"@StudyId",StudyId }
                };
                //StaticLogger.LogTrace("STEP2 GetstudySQL ", _logName);
                return SQLiteDatabase.ExecuteReadData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at GetstudySQL. Message: " + ex.Message, _logName);
                return null;
            }
        }




        private int UpdatePendingQueue(int id)
        {
            try
            {
                //StaticLogger.LogTrace("STEP1 UpdatePendingQueue ", _logName);
                const string query = "UPDATE FileSyncQueue SET UpdatedAt='2022-05-23 12:54:23',isSync=@isSync WHERE ID = @id";
                var args = new Dictionary<string, object>
                {
                    {"@isSync", 1},
                    {"@id", id}
                };
                return SQLiteDatabase.ExecuteWriteData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at UpdatePendingQueue. Message: " + ex.Message, _logName);
                return 0;
            }
        }



        private void LoadPendingList(DataTable dt)
        {
            try
            {
                fileSyncQueuesList = new List<FileSyncQueueModel>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FileSyncQueueModel fileSyncQueueModel = new FileSyncQueueModel
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                        FilePath = dt.Rows[i]["FilePath"].ToString()
                    };
                    fileSyncQueuesList.Add(fileSyncQueueModel);
                }
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at LoadPendingList. Message: " + ex.Message, _logName);
            }
        }

        public void GetWorkList(string machine_code)
        {
            try
            {
                // Get Worklist from Server
                //StaticLogger.LogTrace("STEP1 At GetWorkList ", _logName);
                JToken result = CallWorkList(machine_code);

                if (result != null)
                {
                    //StaticLogger.LogTrace("STEP5 At GetWorkList ", _logName);
                    foreach (var workList in result["myWorklists"])
                    {
                        AddWorklist(int.Parse(workList["id"].ToString()), int.Parse(workList["patient_id"].ToString()), workList["patient_name"].ToString(), workList["service_dt"].ToString(), workList["service_time"].ToString(), int.Parse(workList["clinic_id"].ToString()), workList["patient_first_name"].ToString(), workList["patient_last_name"].ToString(), workList["patient_dob"].ToString(), workList["mrn"].ToString(), workList["case_type_name"].ToString(), workList["case_image_url"].ToString(), workList["patient_gender"].ToString(), workList["created_at"].ToString(), workList["clinic_name"].ToString(), workList["referrer_physician_name"].ToString());
                        //StaticLogger.LogTrace("New added to worklist." + int.Parse(workList["id"].ToString()), _logName);

                        foreach (var study in workList["study"])
                        {
                            try
                            {
                                StaticLogger.LogTrace("For study GetWorkList - " + study + ", worklistID: " + workList["id"]
                                    + ", study_id: " + study["study_id"] + ", study_name: " + study["study_name"]
                                    + ", physician_name: " + study["physician_name"] + ",technologist_name: "
                                    + study["technologist_name"] + ", modality_name: " + study["modality_name"]
                                    + ",accession_number: " + study["accession_number"]
                                    + ", reading_physician_id: " + study["reading_physician_id"], _logName);
                                string worklist_id = workList["id"].ToString();
                                string study_id = study["study_id"].ToString();
                                string study_name = study["study_name"].ToString();
                                string physician = study["physician_name"].ToString();
                                string technologist = study["technologist_name"].ToString();
                                string modality = study["modality_name"].ToString();
                                string modality_code = study["modality_code"].ToString();
                                string accession_number = study["accession_number"].ToString();
                                int reading_physicianId;
                                if (study["reading_physician_id"].HasValues)
                                {
                                    //StaticLogger.LogTrace("study[reading_physician_id] study- " + study["reading_physician_id"], _logName);
                                    reading_physicianId = int.Parse(study["reading_physician_id"].ToString());
                                }
                                else
                                {
                                    //Console.WriteLine(“contain Null Value.”);
                                    //StaticLogger.LogTrace("study[reading_physician_id]  is null", _logName);
                                    reading_physicianId = 0;
                                }
                                //StaticLogger.LogTrace("----------1");
                                //if (study["reading_physician_id"].ToString().Length <= 0)
                                //{
                                //    //StaticLogger.LogTrace("Exception For study GetWorkList - " + study["reading_physician_id"], _logName);
                                //    reading_physicianId = 0;
                                //}



                                string studyUid = study["study_uid"].ToString();
                                int modalityCategoryId = int.Parse(study["modality_category_id"].ToString());
                                string CategoryName = study["category_name"].ToString();
                                int ModalityId = int.Parse(study["modality_id"].ToString());
                                int serviceId = int.Parse(study["id"].ToString());
                                //string modalityColor = study["ModalityColor"].ToString();
                                //string StatusName = study["StatusName"].ToString();
                                //string StatusColor = study["StatusColor"].ToString();
                                //string ModalityDevice = study["ModalityDevice"].ToString();
                                //StaticLogger.LogTrace("----------2");

                                reading_physicianId = 0;//int.Parse(study["reading_physician_id"].ToString());
                                //StaticLogger.LogTrace("For study GetWorkList - study_name: " + study_name + ", physician: " + physician + ", technologist: " + technologist + ", modality: " + modality + ", accession_number: " + accession_number + ", reading_physicianId: " + reading_physicianId + ", CategoryName: " + CategoryName);
                                //StaticLogger.LogTrace("----------3");
                                ////StaticLogger.LogTrace("For study GetWorkList - studyid: " + studyid);
                                //StaticLogger.LogTrace("----------4");
                                AddStudy(int.Parse(worklist_id), serviceId, int.Parse(study_id), study["study_name"].ToString(), study["physician_name"].ToString(), study["technologist_name"].ToString(), study["modality_name"].ToString(), "STATIC", study["modality_code"].ToString(), study["accession_number"].ToString(), reading_physicianId, studyUid, ModalityId, modalityCategoryId, CategoryName, "", "", "", "");//, int.Parse(study["StudyUId"].ToString()), int.Parse(study["StudyUId"].ToString()), study["ModalityColor"].ToString(), study["StatusName"].ToString(), study["StatusColor"].ToString(), study["ModalityDevice"].ToString());
                                //StaticLogger.LogTrace("----------5");

                            }
                            catch (Exception ex)
                            {
                                //StaticLogger.LogError("Exception For Add into study. Message: " + ex.Message, _logName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at GetWorkList. Message: " + ex.Message, _logName);
            }
        }

        private JToken CallWorkList(string machine_code)
        {
            try
            {
                //StaticLogger.LogTrace("At CallWorkList machine_code: " + machine_code, _logName);
                //string url = "https://trillium.smartrxhub.com/dev-api/api/service/v1/worklist?clinic_id=1&last_sync_date=2021-12-03 12:03:21";
                string url = "https://trillium.smartrxhub.com/dev-api/api/service/v1/worklist?machine_code=" + machine_code;
                HttpClient httpClient = new HttpClient();
                //StaticLogger.LogTrace("At CallWorkList url: " + url, _logName);
                string result = httpClient.GetRemoteUrl(url);
                //StaticLogger.LogTrace("result data: " + result, _logName);
                JObject jObject = JObject.Parse(result);
                return jObject["responseData"];
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at CallWorkList. Message: " + ex.Message, _logName);
                return null;
            }
        }

        private void AddWorklist(int WorkListId, int PatientId, string PatientName, string ServiceDt, string ServiceTime, int ClinicId, string PatientFirstName, string PatientLastName, string PatientDOB, string Mrn, string CaseTypeName, string CaseImageUrl, string PatientGender, string CreatedAt, string ClinicName, string ReferrerPhysicianName)
        {
            try
            {
                bool available = false;
                DataTable worklistdt = GetworklistSQL(WorkListId);
                if (worklistdt.Rows.Count > 0)
                {
                    foreach (DataRow worklist in worklistdt.Rows)
                    {
                        if (int.Parse(worklist["WorkListId"].ToString()) == WorkListId)
                        {
                            available = true;
                            try
                            {
                                //StaticLogger.LogTrace("Update WorkListId: " + WorkListId, _logName);
                                const string query = "UPDATE WorkList SET WorkListId=@WorkListId, PatientId=@PatientId,PatientName=@PatientName, ServiceDt=@ServiceDt,ServiceTime=@ServiceTime,ClinicId=@ClinicId,PatientFirstName=@PatientFirstName,PatientLastName=@PatientLastName,PatientDOB=@PatientDOB,Mrn=@Mrn,CaseTypeName=@CaseTypeName,CaseImageUrl=@CaseImageUrl,PatientGender=@PatientGender,CreatedAt=@CreatedAt,ClinicName=@ClinicName,ReferrerPhysicianName=@ReferrerPhysicianName WHERE WorkListId = @WorkListId";
                                var args = new Dictionary<string, object>
                            {
                                 {"@WorkListId", WorkListId},
                                 {"@PatientId", PatientId},
                                 {"@PatientName", PatientName},
                                 {"@ServiceDt", ServiceDt},
                                 {"@ServiceTime", ServiceTime},
                                 {"@ClinicId", ClinicId},
                                 {"@PatientFirstName", PatientFirstName},
                                 {"@PatientLastName", PatientLastName},
                                 {"@PatientDOB", PatientDOB},
                                 {"@Mrn", Mrn},
                                 {"@CaseTypeName", CaseTypeName},
                                 {"@CaseImageUrl", CaseImageUrl},
                                 {"@PatientGender", PatientGender},
                                 {"@CreatedAt", CreatedAt},
                                 {"@ClinicName", ClinicName},
                                 {"@ReferrerPhysicianName", ReferrerPhysicianName}
                            };
                                SQLiteDatabase.ExecuteWriteData(query, args);
                            }
                            catch (Exception ex)
                            {
                                //StaticLogger.LogError("Exception at UPDATE WorkList. Message: " + ex.Message, _logName);
                            }
                            //StaticLogger.LogInfo(@"AddWorklist - available " + available, _logName);
                        }
                    }

                    if (available == false)
                    {
                        //StaticLogger.LogInfo(@"AddWorklist - Start : " + WorkListId + "," + PatientId + "," + ServiceDt + "," + ServiceTime, _logName);
                        const string query = "INSERT INTO WorkList(WorkListId, PatientId,PatientName,ServiceDt,ServiceTime,ClinicId,PatientFirstName,PatientLastName,PatientDOB,Mrn,CaseTypeName,CaseImageUrl,PatientGender,CreatedAt,ClinicName,ReferrerPhysicianName)" +
                                                         " VALUES (@WorkListId, @PatientId,@PatientName,@ServiceDt,@ServiceTime,@ClinicId,@PatientFirstName,@PatientLastName,@PatientDOB,@Mrn,@CaseTypeName,@CaseImageUrl,@PatientGender,@CreatedAt,@ClinicName,@ReferrerPhysicianName)";
                        var args = new Dictionary<string, object>
                    {
                        {"@WorkListId", WorkListId},
                        {"@PatientId", PatientId},
                        {"@PatientName", PatientName},
                        {"@ServiceDt", ServiceDt},
                        {"@ServiceTime", ServiceTime},
                        {"@ClinicId", ClinicId},
                        {"@PatientFirstName", PatientFirstName},
                        {"@PatientLastName", PatientLastName},
                        {"@PatientDOB", PatientDOB},
                        {"@Mrn", Mrn},
                        {"@CaseTypeName", CaseTypeName},
                        {"@CaseImageUrl", CaseImageUrl},
                        {"@PatientGender", PatientGender},
                        {"@CreatedAt", CreatedAt},
                        {"@ClinicName", ClinicName},
                        {"@ReferrerPhysicianName", ReferrerPhysicianName}
                     };
                        var numberOfRowsAffected = SQLiteDatabase.ExecuteWriteData(query, args);
                        //StaticLogger.LogInfo("At AddWorklist numberOfRowsAffected= " + numberOfRowsAffected, _logName);
                    }
                }
                else
                {
                    //StaticLogger.LogInfo(@"*******No Data availabe, AddWorklist - Start : " + WorkListId + "," + PatientId + "," + ServiceDt + "," + ServiceTime + ", " + ClinicId + ", " + PatientFirstName + ", " + PatientLastName + ", " + PatientDOB + ", " + Mrn + ", " + CaseTypeName + ", " + CaseImageUrl + ", " + PatientGender + ", " + CreatedAt + ", " + ClinicName + ", " + ReferrerPhysicianName, _logName);
                    const string query = "INSERT INTO WorkList(WorkListId, PatientId,PatientName,ServiceDt,ServiceTime,ClinicId,PatientFirstName,PatientLastName,PatientDOB,Mrn,CaseTypeName,CaseImageUrl,PatientGender,CreatedAt,ClinicName,ReferrerPhysicianName)" +
                                                     " VALUES (@WorkListId, @PatientId,@PatientName,@ServiceDt,@ServiceTime,@ClinicId,@PatientFirstName,@PatientLastName,@PatientDOB,@Mrn,@CaseTypeName,@CaseImageUrl,@PatientGender,@CreatedAt,@ClinicName,@ReferrerPhysicianName)";
                    var args = new Dictionary<string, object>
                    {
                        {"@WorkListId", WorkListId},
                        {"@PatientId", PatientId},
                        {"@PatientName", PatientName},
                        {"@ServiceDt", ServiceDt},
                        {"@ServiceTime", ServiceTime},
                        {"@ClinicId", ClinicId},
                        {"@PatientFirstName", PatientFirstName},
                        {"@PatientLastName", PatientLastName},
                        {"@PatientDOB", PatientDOB},
                        {"@Mrn", Mrn},
                        {"@CaseTypeName", CaseTypeName},
                        {"@CaseImageUrl", CaseImageUrl},
                        {"@PatientGender", PatientGender},
                        {"@CreatedAt", CreatedAt},
                        {"@ClinicName", ClinicName},
                        {"@ReferrerPhysicianName", ReferrerPhysicianName}
                    };
                    var numberOfRowsAffected = SQLiteDatabase.ExecuteWriteData(query, args);
                    //StaticLogger.LogInfo("At AddWorklist numberOfRowsAffected= " + numberOfRowsAffected, _logName);
                }
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at AddWorklist. Message: " + ex.Message, _logName);
            }
        }

        private void AddStudy(int WorkListId, int serviceId, int StudyId, string StudyName, string PhysicianName, string TechnologiestName, string ModalityName, string ModalityAE, string ModalityCode, string AccessionNo, int? ReadingPhysicianId, string StudyUId, int ModalityId, int ModalityCategoryId, string CategoryName, string ModalityColor, string StatusName, string StatusColor, string ModalityDevice)
        {
            try
            {
                //StaticLogger.LogInfo("STEP1 at AddStudy, WorkListId: " + WorkListId + ", StudyId: " + StudyId, _logName);
                bool available = false;
                DataTable studydt = GetstudySQL(WorkListId, StudyId);
                //StaticLogger.LogInfo("STEP2 AddStudy, StudyTable rows: " + studydt.Rows.Count, _logName);
                if (studydt.Rows.Count > 0)
                {
                    //StaticLogger.LogInfo("STEP3 at AddStudy: ", _logName);
                    foreach (DataRow worklist in studydt.Rows)
                    {
                        if ((int.Parse(worklist["WorkListId"].ToString()) == WorkListId && (int.Parse(worklist["StudyId"].ToString()) == StudyId)))
                        {
                            available = true;
                            try
                            {
                                //StaticLogger.LogTrace("Update study: " + WorkListId, _logName);
                                const string query = "UPDATE Study SET serviceId=@serviceId, StudyId=@StudyId, StudyName=@StudyName,PhysicianName=@PhysicianName, TechnologiestName=@TechnologiestName,ModalityName=@ModalityName, ModalityAE=@ModalityAE, ModalityCode=@ModalityCode, AccessionNo=@AccessionNo, ReadingPhysicianId=@ReadingPhysicianId, StudyUId=@StudyUId, ModalityId=@ModalityId, ModalityCategoryId=@ModalityCategoryId,CategoryName=@CategoryName, ModalityColor=@ModalityColor, StatusName=@StatusName, StatusColor=@StatusColor, ModalityDevice=@ModalityDevice WHERE WorkListId = @WorkListId";// , StudyId = @StudyId";
                                var args = new Dictionary<string, object>
                            {
                                 {"@StudyId", StudyId},
                                 {"@serviceId",serviceId},
                                 {"@WorkListId", WorkListId},
                                 {"@StudyName", StudyName},
                                 {"@PhysicianName", PhysicianName},
                                 {"@TechnologiestName", TechnologiestName},
                                 {"@ModalityName", ModalityName},
                                 {"@ModalityAE", ModalityAE},
                                 {"@ModalityCode", ModalityCode},
                                 {"@AccessionNo", AccessionNo},
                                 {"@ReadingPhysicianId",ReadingPhysicianId},
                                 {"@StudyUId",StudyUId},
                                 {"@ModalityId",ModalityId },
                                 {"@ModalityCategoryId",ModalityCategoryId},
                                 {"@CategoryName",CategoryName},
                                 {"@ModalityColor",ModalityColor},
                                 {"@StatusName",StatusName},
                                 {"@StatusColor",StatusColor},
                                 {"@ModalityDevice",ModalityDevice}
                            };
                                SQLiteDatabase.ExecuteWriteData(query, args);
                            }
                            catch (Exception ex)
                            {
                                //StaticLogger.LogError("Exception at UPDATE study. Message: " + ex.Message, _logName);
                            }
                            //StaticLogger.LogInfo(@"AddStudy, available " + available, _logName);
                        }
                    }
                }
                else
                {
                    //StaticLogger.LogInfo(@" STEP5 at AddStudy, No Data availabe, AddStudy at WorkListId: " + WorkListId, _logName);
                    InsertStudy(WorkListId, serviceId, StudyId, StudyName, PhysicianName, TechnologiestName, ModalityName, ModalityAE, ModalityCode, AccessionNo, ReadingPhysicianId, StudyUId, ModalityId, ModalityCategoryId, CategoryName, ModalityColor, StatusName, StatusColor, ModalityDevice);
                }
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at AddStudy. Message: " + ex.Message, _logName);
            }
        }

        private int InsertStudy(int WorkListId, int serviceId, int StudyId, string StudyName, string PhysicianName, string TechnologiestName, string ModalityName, string ModalityAE, string ModalityCode, string AccessionNo, int? ReadingPhysicianId, string StudyUId, int ModalityId, int ModalityCategoryId, string CategoryName, string ModalityColor, string StatusName, string StatusColor, string ModalityDevice)
        {
            try
            {
                //StaticLogger.LogInfo("STEP1 at InsertStudy", _logName);
                DateTime UTCNow = DateTime.UtcNow;
                const string query = "INSERT INTO Study " +
                "(WorkListId,serviceId, StudyId,StudyName,PhysicianName,TechnologiestName,ModalityName,ModalityAE,ModalityCode,AccessionNo,ReadingPhysicianId,StudyUId,ModalityId,ModalityCategoryId,CategoryName,ModalityColor,StatusName,StatusColor,ModalityDevice,CreatedAt,UpdatedAt) " +
                "VALUES " +
                "(@WorkListId,@serviceId, @StudyId,@StudyName,@PhysicianName,@TechnologiestName,@ModalityName,@ModalityAE,@ModalityCode,@AccessionNo,@ReadingPhysicianId,@StudyUId,@ModalityId,@ModalityCategoryId,@CategoryName,@ModalityColor,@StatusName,@StatusColor,@ModalityDevice,@CreatedAt,@UpdatedAt)";
                var args = new Dictionary<string, object>
                    {
                        {"@WorkListId",WorkListId},
                         {"@serviceId",serviceId},
                        {"@StudyId",StudyId},
                        {"@StudyName",StudyName},
                        {"@PhysicianName",PhysicianName},
                        {"@TechnologiestName",TechnologiestName},
                        {"@ModalityName",ModalityName},
                        {"@ModalityCode",ModalityCode},
                        {"@ModalityAE",ModalityAE},
                        {"@AccessionNo",AccessionNo},
                        {"@ReadingPhysicianId",ReadingPhysicianId},
                        {"@StudyUId",StudyUId},
                        {"@ModalityId",ModalityId },
                        {"@ModalityCategoryId",ModalityCategoryId},
                        {"@CategoryName",CategoryName},
                        {"@ModalityColor",ModalityColor},
                        {"@StatusName",StatusName},
                        {"@StatusColor",StatusColor},
                        {"@ModalityDevice",ModalityDevice},
                        {"@CreatedAt",UTCNow.ToString("yyyy-MM-dd HH:mm:ss")},
                        {"@UpdatedAt",UTCNow.ToString("yyyy-MM-dd HH:mm:ss")}
                    };
                //StaticLogger.LogInfo("STEP2 at InsertStudy ", _logName);
                var numberOfRowsAffected = SQLiteDatabase.ExecuteWriteData(query, args);
                //StaticLogger.LogInfo("STEP3 at InsertStudy", _logName);
                //StaticLogger.LogInfo("STEP4 InsertStudy numberOfRowsAffected= " + numberOfRowsAffected, _logName);
                return numberOfRowsAffected;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at InsertStudy. Message: " + ex.Message, _logName);
                return 0;
            }
        }
        private void GetStudy()
        {
            //StaticLogger.LogInfo("at GetStudy", _logName);
            try
            {

                const string query = "SELECT * from Study";
                //StaticLogger.LogInfo("at GetStudy QUERY: " + query, _logName);
                Dictionary<string, object> DictionaryData = new Dictionary<string, object>();
                var numberOfRowscollected = "";//SQLiteDatabase.ExecuteRead(query);
                //StaticLogger.LogInfo("GetStudy numberOfRowsAffected= " + numberOfRowscollected, _logName);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at GetStudy. Message: " + ex.Message, _logName);
            }
        }


        private DataTable WorkList()
        {
            try
            {
                //StaticLogger.LogTrace("GetPendingSync", _logName);
                const string query = "SELECT * FROM FileSyncQueue WHERE isSync=@isSync ORDER BY ID ASC LIMIT 1";
                var args = new Dictionary<string, object>
                {
                    {"@isSync", "0"}
                };
                return SQLiteDatabase.ExecuteReadData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogTrace("GetPendingSync" + ex.Message, _logName);
                return null;
            }
        }
    }
}
