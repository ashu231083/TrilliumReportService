using LoggerManager;
using SQLiteManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgentDAL.Controllers
{
    public class SQLController
    {
        private const string _logName = "DicomServer";

        // Modality Sync 

        public DataTable GetModalitySync(string StationAE)
        {
            try
            {
                //StaticLogger.LogTrace("GetModalitySync", _logName);
                const string query = "SELECT " +
                    "ID,StationAE,StationName,LastSyncAt,CreatedAt,UpdatedAt " +
                    "From ModalitySync " +
                    "WHERE StationAE=@StationAE";
                //StaticLogger.LogTrace("GetModalitySync Query=" + query, _logName);
                var args = new Dictionary<string, object>
                {
                    {"@StationAE", StationAE}
                };
                return SQLiteDatabase.ExecuteReadData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at GetPendingSync. Message" + ex.Message, _logName);
                return null;
            }

        }

        public int InsertModalitySync(string StationAE, string StationName)
        {
            try
            {
                //StaticLogger.LogTrace("At InsertModalitySync", _logName);
                DateTime LastSyncAt = DateTime.UtcNow;

                const string query = "INSERT INTO ModalitySync " +
                    "(StationAE, StationName, LastSyncAt,CreatedAt,UpdatedAt) " +
                    "VALUES " +
                    "(@StationAE, @StationName,@LastSyncAt,@CreatedAt,@UpdatedAt)";
                var args = new Dictionary<string, object>
                    {
                        {"@StationAE",StationAE},
                        {"@StationName",StationName},
                        {"@LastSyncAt",LastSyncAt.ToString("yyyy-MM-dd HH:mm:ss")},
                        {"@CreatedAt",LastSyncAt.ToString("yyyy-MM-dd HH:mm:ss")},
                        {"@UpdatedAt",LastSyncAt.ToString("yyyy-MM-dd HH:mm:ss")}
                    };
                return SQLiteDatabase.ExecuteWriteData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at InsertModalitySync. Message: " + ex.Message, _logName);
                return -1;
            }
        }

        public int UpdateModalitySync(string StationAE, string StationName)
        {
            try
            {
                //StaticLogger.LogTrace("At UpdateModalitySync", _logName);
                DateTime LastSyncAt = DateTime.UtcNow;

                const string query = "UPDATE ModalitySync SET " +
                    "LastSyncAt=@LastSyncAt, " +
                    "UpdatedAt=@LastSyncAt " +
                    "WHERE StationAE=@StationAE";
                var args = new Dictionary<string, object>
                    {
                        {"@StationAE",StationAE},
                        {"@LastSyncAt",LastSyncAt.ToString("yyyy-MM-dd HH:mm:ss")}
                    };
                //StaticLogger.LogTrace("UpdateModalitySync Query=" + query, _logName);
                return SQLiteDatabase.ExecuteWriteData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at UpdateModalitySync. Message: " + ex.Message, _logName);
                return -1;
            }
        }

        // Worklit Manage

        public int InsertWorkList(int WorkListId, int PatientId, string PatientName, string ServiceDt, string ServiceTime)
        {
            try
            {
                //StaticLogger.LogInfo(@"InsertWorkList - Start : " + WorkListId + "," + PatientId + "," + ServiceDt + "," + ServiceTime, _logName);
                const string query = "INSERT INTO WorkList(WorkListId, PatientId,PatientName,ServiceDt,ServiceTime) VALUES (@WorkListId, @PatientId,@PatientName,@ServiceDt,@ServiceTime)";
                var args = new Dictionary<string, object>
                {
                    {"@WorkListId", WorkListId},
                    {"@PatientId", PatientId},
                    {"@PatientName", PatientName},
                    {"@ServiceDt", ServiceDt},
                    {"@ServiceTime", ServiceTime},

                };
                return SQLiteDatabase.ExecuteWriteData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogTrace("Exception at insert WorkList: " + ex.Message, _logName);
                return -1;
            }
        }

        public int UpdateWorkList(int WorkListId, int PatientId, string PatientName, string ServiceDt, string ServiceTime)
        {
            try
            {
                //StaticLogger.LogTrace("At UpdateWorkList, WorkListId: " + WorkListId, _logName);
                const string query = "UPDATE WorkList SET " +
                    "WorkListId=@WorkListId, PatientId=@PatientId, PatientName=@PatientName, " +
                    "ServiceDt=@ServiceDt,ServiceTime=@ServiceTime " +
                    "WHERE WorkListId = @WorkListId";
                var args = new Dictionary<string, object>
                {
                    {"@WorkListId", WorkListId},
                    {"@PatientId", PatientId},
                    {"@PatientName", PatientName},
                    {"@ServiceDt", ServiceDt},
                    {"@ServiceTime", ServiceTime}
                };
                return SQLiteDatabase.ExecuteWriteData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at UpdateWorkList. Message: " + ex.Message, _logName);
                return -1;
            }
        }

        // Study Manage

        public int InsertStudy(int WorkListId, int StudyId, string StudyName, string PhysicianName, string TechnologiestName, string ModalityName, string ModalityAE, string ModalityCode, string AccessionNo, int? ReadingPhysicianId)
        {
            try
            {
                //StaticLogger.LogTrace("At InsertStudy, WorkListId= " + WorkListId, _logName);
                const string query = "INSERT INTO Study " +
                    "(WorkListId, StudyId,StudyName,PhysicianName,TechnologiestName,ModalityName,ModalityAE,ModalityCode,AccessionNo,ReadingPhysicianId) " +
                    "VALUES " +
                    "(@WorkListId, @StudyId,@StudyName,@PhysicianName,@TechnologiestName,@ModalityName,@ModalityAE,@ModalityCode,@AccessionNo,@ReadingPhysicianId)";
                var args = new Dictionary<string, object>
                    {
                        {"@WorkListId",WorkListId},
                        {"@StudyId",StudyId},
                        {"@StudyName",StudyName},
                        {"@PhysicianName",PhysicianName},
                        {"@TechnologiestName",TechnologiestName},
                        {"@ModalityName",ModalityName},
                        {"@ModalityCode",ModalityCode},
                        {"@ModalityAE",ModalityAE},
                        {"@AccessionNo",AccessionNo},
                        {"@ReadingPhysicianId",ReadingPhysicianId}
                    };
                return SQLiteDatabase.ExecuteWriteData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at InsertStudy. Message: " + ex.Message, _logName);
                return -1;
            }
        }

        public int UpdateStudy(int WorkListId, int StudyId, string StudyName, string PhysicianName, string TechnologiestName, string ModalityName, string ModalityAE, string ModalityCode, string AccessionNo, int? ReadingPhysicianId)
        {
            try
            {
                //StaticLogger.LogTrace("At UpdateStudy, WorkListId= " + WorkListId, _logName);
                const string query = "UPDATE Study SET " +
                    "StudyId=@StudyId, StudyName=@StudyName, PhysicianName=@PhysicianName, TechnologiestName=@TechnologiestName, " +
                    "ModalityName=@ModalityName, ModalityAE=@ModalityAE, ModalityCode=@ModalityCode, AccessionNo=@AccessionNo, " +
                    "ReadingPhysicianId=@ReadingPhysicianId " +
                    "WHERE WorkListId = @WorkListId " +
                    "AND StudyId = @StudyId";
                var args = new Dictionary<string, object>
                {
                    {"@StudyId", StudyId},
                    {"@WorkListId", WorkListId},
                    {"@StudyName", StudyName},
                    {"@PhysicianName", PhysicianName},
                    {"@TechnologiestName", TechnologiestName},
                    {"@ModalityName", ModalityName},
                    {"@ModalityAE", ModalityAE},
                    {"@ModalityCode", ModalityCode},
                    {"@AccessionNo", AccessionNo},
                    {"@ReadingPhysicianId",ReadingPhysicianId}
                };
                return SQLiteDatabase.ExecuteWriteData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at UpdateStudy. Message: " + ex.Message, _logName);
                return -1;
            }
        }

        public DataTable GetStudyData(string ModalityCode, string LastSyncDt)
        {
            //StaticLogger.LogTrace("At GetStudyData, ModalityCode= " + ModalityCode + ", LastSyncDt= " + LastSyncDt, _logName);
            try
            {
                DateTime aDate = DateTime.UtcNow;
                const string query = "SELECT " +
     "s.*,wl.PatientId,wl.PatientName,wl.PatientFirstName,wl.PatientLastName,wl.PatientDOB,wl.ServiceDt,wl.ServiceTime,wl.ClinicName,wl.ReferrerPhysicianName,wl.PatientGender " +
     "FROM Study as s " +
     "JOIN WorkList as wl on s.WorkListId = wl.WorkListId " +
     "WHERE s.ModalityCode = @ModalityCode " +
     "AND s.UpdatedAt > @LastSyncDt " +
     "LIMIT 5";
                //StaticLogger.LogTrace("At GetStudyData Query=" + query, _logName);
                var args = new Dictionary<string, object>
                {
                    {"@ModalityCode", ModalityCode},
                    {"@LastSyncDt", LastSyncDt}
                };
                return SQLiteDatabase.ExecuteReadData(query, args);
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at GetStudyData. Message: " + ex.Message, _logName);
                return null;
            }

        }

        public int UpdateDownloadStudy(string IDs, string ModalityAE)
        {
            try
            {
                DateTime aDate = DateTime.UtcNow;
                //StaticLogger.LogTrace("At UpdateDownloadStudy, Ids= " + IDs + ", ModalityAE= " + ModalityAE, _logName);
                string query = "UPDATE Study SET " +
                    "DownloadAt=@DownloadAt, ModalityAE=@ModalityAE " +
                    "WHERE ID in (" + IDs + ")";
                var args = new Dictionary<string, object>
                {
                        {"@DownloadAt", aDate.ToString("yyyy-MM-dd HH:mm:ss")},
                        {"@ModalityAE", ModalityAE},
                        {"@IDs", IDs}
                };
                //StaticLogger.LogTrace("UpdateDownloadStudy Query=" + query, _logName);
                var numberOfRowsAffected = SQLiteDatabase.ExecuteWriteData(query, args);
                return numberOfRowsAffected;
            }
            catch (Exception ex)
            {
                //StaticLogger.LogError("Exception at UpdateDownloadStudy. Message: " + ex.Message, _logName);
                return -1;
            }
        }

        // File Sync to Cloud

        public DataTable GetPendingSync()
        {
            try
            {
                //StaticLogger.LogTrace("At GetPendingSync", _logName);
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
    }
}
