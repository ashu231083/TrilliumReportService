using HL7.Dotnetcore;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HL7ReportingService
{
    public partial class HL7ReportingService : ServiceBase
    {
        Logger Logger = LogManager.GetCurrentClassLogger();
        System.Timers.Timer timer = new System.Timers.Timer();
        private System.Threading.Timer IntervalTimer;
        private bool isAvilApp = false;
        public HL7ReportingService()
        {
            InitializeComponent();
            Logger.Info("HL7ReportingService InitializeComponent done.");
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                Logger.Info("HL7ReportingService is started with interval: " + ConfigurationManager.AppSettings["report_interval"]);
                TimeSpan tsInterval = new TimeSpan(0, Convert.ToInt32(ConfigurationManager.AppSettings["report_interval"]), 0);
                IntervalTimer = new System.Threading.Timer(new System.Threading.TimerCallback(OnElapsedTimeCall), null, tsInterval, tsInterval);

                OnstartCall("Start");
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at OnStart. Message: " + ex.Message);
            }
        }

        protected override void OnStop()
        {
            try
            {
                Logger.Info("HL7ReportingService is Stopped.");
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at OnStop. Message: " + ex.Message);
            }
        }

        private void OnstartCall(string opt)
        {
            try
            {
                Logger.Info("HL7ReportingService is OnstartCall.");


            }
            catch (Exception ex)
            {
                Logger.Error("Exception at OnstartCall. Message: " + ex.Message);
            }
        }

        public void HL7ToJson()
        {
            try
            {
                Logger.Info("At HL7ToJson..");
                string HL7_ORU = File.ReadAllText("D:\\DMS_WORKSPACE\\HL7ReportingService\\HL7Decoder\\test\\" + "Sample-ORU.txt");
                var message2 = new Message(HL7_ORU);
                message2.ParseMessage();
                var msgORU = new Message(HL7_ORU);


                List<Segment> MSHList = message2.Segments("MSH");
                List<Segment> PIDList = message2.Segments("PID");
                List<Segment> PV1List = message2.Segments("PV1");
                List<Segment> ORCList = message2.Segments("ORC");
                List<Segment> OBRList = message2.Segments("OBR");
                List<Segment> OBXList = message2.Segments("OBX");
                Logger.Info("MSHList.count= " + MSHList.Count + ", PIDList.Count= " + PIDList.Count
                    + ", PV1List.Count= " + PV1List.Count + ", ORCList.Count= " + ORCList.Count
                    + ", OBRList.Count= " + OBRList.Count + ", OBXList.Count= " + OBXList.Count);
                var MSHFieldCount = MSHList[0].GetAllFields();
                var PIDFieldCount = PIDList[0].GetAllFields();
                var PV1FieldCount = PV1List[0].GetAllFields();
                var ORCFieldCount = ORCList[0].GetAllFields();
                var OBRFieldCount = OBRList[0].GetAllFields();
                var OBXFieldCount = OBXList[0].GetAllFields();

                Logger.Info("MSHFieldCount= " + MSHFieldCount + ", PIDFieldCount= " + PIDFieldCount
                   + ", PV1FieldCount= " + PV1FieldCount + ", ORCFieldCount= " + ORCFieldCount
                   + ", OBRFieldCount= " + OBRFieldCount + ", OBXFieldCount= " + OBXFieldCount);
                int msh = int.Parse(MSHFieldCount.Count().ToString());

                //#region MSH
                //Dictionary<string, string> MSHmsg = new Dictionary<string, string>();
                //for (int i = 0; i < int.Parse(MSHFieldCount.Count().ToString()); i++)
                //{
                //    MSHmsg.Add("key" + (i + 1), message2.GetValue("MSH." + (i + 1)));
                //}
                //string MSHjson = MyDictionaryToJson(MSHmsg);
                //#endregion MSH


                //#region PID
                //Dictionary<string, string> PIDmsg = new Dictionary<string, string>();
                //for (int i = 0; i < int.Parse(PIDFieldCount.Count().ToString()); i++)
                //{
                //    PIDmsg.Add("key" + (i + 1), message2.GetValue("PID." + (i + 1)));
                //}
                //string PIDjson = MyDictionaryToJson(PIDmsg);
                //#endregion PID


                //#region PV1
                //Dictionary<string, string> PV1msg = new Dictionary<string, string>();
                //for (int i = 0; i < int.Parse(PV1FieldCount.Count().ToString()); i++)
                //{
                //    PV1msg.Add("key" + (i + 1), message2.GetValue("PV1." + (i + 1)));
                //}
                //string PV1json = MyDictionaryToJson(PV1msg);
                //#endregion PV1


                //#region ORC
                //Dictionary<string, string> ORCmsg = new Dictionary<string, string>();
                //for (int i = 0; i < int.Parse(ORCFieldCount.Count().ToString()); i++)
                //{
                //    ORCmsg.Add("key" + (i + 1), message2.GetValue("ORC." + (i + 1)));
                //}
                //string ORCjson = MyDictionaryToJson(ORCmsg);
                //#endregion ORC


                //#region OBR
                //Dictionary<string, string> OBRmsg = new Dictionary<string, string>();
                //for (int i = 0; i < int.Parse(OBRFieldCount.Count().ToString()); i++)
                //{
                //    OBRmsg.Add("key" + (i + 1), message2.GetValue("OBR." + (i + 1)));
                //}
                //string OBRjson = MyDictionaryToJson(OBRmsg);
                //#endregion OBR


                //#region OBX
                //Dictionary<string, string> OBXmsg = new Dictionary<string, string>();
                //for (int i = 0; i < int.Parse(OBXFieldCount.Count().ToString()); i++)
                //{
                //    OBXmsg.Add("key" + (i + 1), message2.GetValue("OBX." + (i + 1)));
                //}
                //string OBXjson = MyDictionaryToJson(OBXmsg);
                //#endregion OBX


                Dictionary<string, string> ORUmsg = new Dictionary<string, string>();

                ORUmsg.Add("Sending Application", message2.GetValue("MSH.3"));
                ORUmsg.Add("Sending Facility", message2.GetValue("MSH.4"));
                ORUmsg.Add("Receiving Application", message2.GetValue("MSH.5"));
                ORUmsg.Add("Receiving Facility", message2.GetValue("MSH.6"));
                ORUmsg.Add("DateTime of Message", message2.GetValue("MSH.7"));
                ORUmsg.Add("Security", message2.GetValue("MSH.8"));
                ORUmsg.Add("Message Type", message2.GetValue("MSH.9"));
                ORUmsg.Add("Message Control ID", message2.GetValue("MSH.10"));
                ORUmsg.Add("Processing ID", message2.GetValue("MSH.11"));
                ORUmsg.Add("Version ID", message2.GetValue("MSH.12"));
                ORUmsg.Add("Sequence Number", message2.GetValue("MSH.13"));


                ORUmsg.Add("Patient ID", message2.GetValue("PID.1"));
                ORUmsg.Add("Patient ID(External ID)", message2.GetValue("PID.2"));
                ORUmsg.Add("Patient ID(Internal ID)", message2.GetValue("PID.3"));
                ORUmsg.Add("Alternate Patient ID", message2.GetValue("PID.4"));
                ORUmsg.Add("Patient Name", message2.GetValue("PID.5"));
                ORUmsg.Add("Mother's Maiden Name", message2.GetValue("PID.6"));

                ORUmsg.Add("Date of Birth", message2.GetValue("PID.7"));
                ORUmsg.Add("Sex", message2.GetValue("PID.8"));
                ORUmsg.Add("Patient Alias", message2.GetValue("PID.9"));
                ORUmsg.Add("Race", message2.GetValue("PID.10"));
                ORUmsg.Add("Pateint Address", message2.GetValue("PID.11"));
                ORUmsg.Add("County Code", message2.GetValue("PID.12"));

                ORUmsg.Add("Phone Number - Home", message2.GetValue("PID.13"));
                ORUmsg.Add("Phone Number - Business", message2.GetValue("PID.14"));
                ORUmsg.Add("Primary Language", message2.GetValue("PID.15"));
                ORUmsg.Add("Merital Status", message2.GetValue("PID.16"));
                ORUmsg.Add("Religion", message2.GetValue("PID.17"));
                ORUmsg.Add("Patient Account Number", message2.GetValue("PID.18"));


                ORUmsg.Add("Set ID - Patient Visit", message2.GetValue("PV1.1"));
                ORUmsg.Add("Patient Class", message2.GetValue("PV1.2"));
                ORUmsg.Add("Assigned Patient Location", message2.GetValue("PV1.3"));
                ORUmsg.Add("Admission Type", message2.GetValue("PV1.4"));
                ORUmsg.Add("Preadmit Number", message2.GetValue("PV1.5"));
                ORUmsg.Add("Prior Patient Location", message2.GetValue("PV1.6"));
                ORUmsg.Add("Attending Doctor", message2.GetValue("PV1.7"));
                ORUmsg.Add("Referring Doctor", message2.GetValue("PV1.8"));
                ORUmsg.Add("Consulting Doctor", message2.GetValue("PV1.9"));
                ORUmsg.Add("Hospital Service", message2.GetValue("PV1.10"));

                ORUmsg.Add("Temporary Location", message2.GetValue("PV1.11"));
                ORUmsg.Add("Preadmit Test Indicator", message2.GetValue("PV1.12"));
                ORUmsg.Add("Readmission Indicator", message2.GetValue("PV1.13"));
                ORUmsg.Add("Admit Source", message2.GetValue("PV1.14"));
                ORUmsg.Add("Ambulatory Status", message2.GetValue("PV1.15"));
                ORUmsg.Add("VIP Indicator", message2.GetValue("PV1.16"));
                ORUmsg.Add("Admitting Doctor", message2.GetValue("PV1.17"));
                ORUmsg.Add("Patient Type", message2.GetValue("PV1.18"));
                ORUmsg.Add("Visit Number", message2.GetValue("PV1.19"));
                ORUmsg.Add("Financial Class", message2.GetValue("PV1.20"));

                ORUmsg.Add("Charge Price Indicator", message2.GetValue("PV1.21"));
                ORUmsg.Add("Courtesy Code", message2.GetValue("PV1.22"));
                ORUmsg.Add("Credit Rating", message2.GetValue("PV1.23"));
                ORUmsg.Add("Contract Code", message2.GetValue("PV1.24"));
                ORUmsg.Add("Contract Effective Date", message2.GetValue("PV1.25"));
                ORUmsg.Add("Contract Amount", message2.GetValue("PV1.26"));
                ORUmsg.Add("Contract Period", message2.GetValue("PV1.27"));
                ORUmsg.Add("Interest Code", message2.GetValue("PV1.28"));
                ORUmsg.Add("Transfer to Bad Debt Code", message2.GetValue("PV1.29"));
                ORUmsg.Add("Transfer to Bad Debt Date", message2.GetValue("PV1.30"));

                ORUmsg.Add("Bad Debt Agency Code", message2.GetValue("PV1.31"));
                ORUmsg.Add("Bad Debt Transfer Amount", message2.GetValue("PV1.32"));
                ORUmsg.Add("Bad Debt Recovery Amount", message2.GetValue("PV1.33"));
                ORUmsg.Add("Delete Account Indicator", message2.GetValue("PV1.34"));
                ORUmsg.Add("Delete Account Date", message2.GetValue("PV1.35"));
                ORUmsg.Add("Discharge Disposition", message2.GetValue("PV1.36"));
                ORUmsg.Add("Discharged Location", message2.GetValue("PV1.37"));
                ORUmsg.Add("Diet Type", message2.GetValue("PV1.38"));
                ORUmsg.Add("Servicing Facility", message2.GetValue("PV1.39"));
                ORUmsg.Add("Bed Status", message2.GetValue("PV1.40"));

                ORUmsg.Add("Account Status", message2.GetValue("PV1.41"));
                ORUmsg.Add("Pending Location", message2.GetValue("PV1.42"));
                ORUmsg.Add("Prior Temporary Location", message2.GetValue("PV1.43"));
                ORUmsg.Add("Admit DateTime", message2.GetValue("PV1.44"));
                ORUmsg.Add("Discharge DateTime", message2.GetValue("PV1.45"));
                ORUmsg.Add("Current Patient Balance", message2.GetValue("PV1.46"));


                ORUmsg.Add("Order Control", message2.GetValue("ORC.1"));
                ORUmsg.Add("Placer Order Number", message2.GetValue("ORC.2"));
                ORUmsg.Add("Filler Order Number", message2.GetValue("ORC.3"));
                ORUmsg.Add("Placer Group Number", message2.GetValue("ORC.4"));
                ORUmsg.Add("Order Status", message2.GetValue("ORC.5"));
                ORUmsg.Add("Response Flag", message2.GetValue("ORC.6"));
                ORUmsg.Add("QuantityTiming", message2.GetValue("ORC.7"));
                ORUmsg.Add("Parent", message2.GetValue("ORC.8"));
                ORUmsg.Add("DateTime of Transaction", message2.GetValue("ORC.9"));
                ORUmsg.Add("Entered By", message2.GetValue("ORC.10"));


                ORUmsg.Add("Set ID Observation Request", message2.GetValue("OBR.1"));
                ORUmsg.Add("Placer Order Number2", message2.GetValue("OBR.2"));
                ORUmsg.Add("Filler Order Number2", message2.GetValue("OBR.3"));
                ORUmsg.Add("Universal Service Identifier", message2.GetValue("OBR.4"));
                ORUmsg.Add("Priority", message2.GetValue("OBR.5"));
                ORUmsg.Add("Requested DateTime", message2.GetValue("OBR.6"));
                ORUmsg.Add("Observation DateTime", message2.GetValue("OBR.7"));
                ORUmsg.Add("Observation End DateTime", message2.GetValue("OBR.8"));
                ORUmsg.Add("Collection Volume", message2.GetValue("OBR.9"));
                ORUmsg.Add("Collector Identifier", message2.GetValue("OBR.10"));

                ORUmsg.Add("Specimen Action Code", message2.GetValue("OBR.11"));
                ORUmsg.Add("Danger Code", message2.GetValue("OBR.12"));
                ORUmsg.Add("Relevant Clinical Information", message2.GetValue("OBR.13"));
                ORUmsg.Add("Specimen Received DateTime", message2.GetValue("OBR.14"));
                ORUmsg.Add("Specimen Source", message2.GetValue("OBR.15"));
                ORUmsg.Add("Ordering Provider", message2.GetValue("OBR.16"));
                ORUmsg.Add("Order Callback Phone Number", message2.GetValue("OBR.17"));
                ORUmsg.Add("Placer Field1", message2.GetValue("OBR.18"));
                ORUmsg.Add("Placer Field2", message2.GetValue("OBR.19"));
                ORUmsg.Add("Filler Field1", message2.GetValue("OBR.20"));

                ORUmsg.Add("Filler Field2", message2.GetValue("OBR.21"));
                ORUmsg.Add("Results Status Chng DateTime", message2.GetValue("OBR.22"));
                ORUmsg.Add("Charge To Practice", message2.GetValue("OBR.23"));
                ORUmsg.Add("Diagnostic Service Section ID", message2.GetValue("OBR.24"));
                ORUmsg.Add("Result Status", message2.GetValue("OBR.25"));
                ORUmsg.Add("Parent Result", message2.GetValue("OBR.26"));
                ORUmsg.Add("QuantityTiming2", message2.GetValue("OBR.27"));
                ORUmsg.Add("Result Copies To", message2.GetValue("OBR.28"));
                ORUmsg.Add("Parent Number", message2.GetValue("OBR.29"));
                ORUmsg.Add("Transportation Mode", message2.GetValue("OBR.30"));

                ORUmsg.Add("Reason For Study", message2.GetValue("OBR.31"));
                ORUmsg.Add("Principal Result Interpreter", message2.GetValue("OBR.32"));
                ORUmsg.Add("Assistant Result Interpreter", message2.GetValue("OBR.33"));
                ORUmsg.Add("Technician", message2.GetValue("OBR.34"));
                ORUmsg.Add("Transcriptionist", message2.GetValue("OBR.35"));
                ORUmsg.Add("Scheduled DateTime", message2.GetValue("OBR.36"));
                ORUmsg.Add("Number of Sample Containers", message2.GetValue("OBR.37"));


                ORUmsg.Add("Set ID - OBX", message2.GetValue("OBX.1"));
                ORUmsg.Add("Value Type", message2.GetValue("OBX.2"));
                ORUmsg.Add("Observation Identifier", message2.GetValue("OBX.3"));
                ORUmsg.Add("Observation Sub-ID", OBXList[0].Fields(4).Value);// ORUmsg.Add("Observation Sub-ID", message2.GetValue("OBX.4"));
                ORUmsg.Add("Observation Value", message2.GetValue("OBX.5"));
                ORUmsg.Add("Units", message2.GetValue("OBX.6"));
                ORUmsg.Add("References Range", message2.GetValue("OBX.7"));
                ORUmsg.Add("Abnormal Flags", message2.GetValue("OBX.8"));
                ORUmsg.Add("Probability", message2.GetValue("OBX.9"));
                ORUmsg.Add("Nature of Abnormal Test", message2.GetValue("OBX.10"));

                ORUmsg.Add("Observ Result Status", message2.GetValue("OBX.11"));
                ORUmsg.Add("Date Last Obs Normal Values", message2.GetValue("OBX.12"));
                ORUmsg.Add("User Defined Access Checks", message2.GetValue("OBX.13"));
                ORUmsg.Add("DateTime of the Observation", message2.GetValue("OBX.14"));
                ORUmsg.Add("Producer's ID", message2.GetValue("OBX.15"));
                ORUmsg.Add("Responsible Observer", message2.GetValue("OBX.16"));
                ORUmsg.Add("Observation Method", message2.GetValue("OBX.17"));

                string ORUjson = MyDictionaryToJson(ORUmsg);


                //#region OBX
                //string SetID = message2.GetValue("OBX.1");
                //string ValueType = message2.GetValue("OBX.2");
                //string ObservationIdentifier = message2.GetValue("OBX.3");
                //string ObservationSubID = message2.GetValue("OBX.4");
                //var data2 = OBXList[0].Fields(4).Value;
                //string ObservationValue = message2.GetValue("OBX.5");
                //string Units = message2.GetValue("OBX.6");
                //string ReferenceRange = message2.GetValue("OBX.7");
                //string AbnormalFlags = message2.GetValue("OBX.8");
                //string Probability = message2.GetValue("OBX.9");
                //string NatureOfAbnormalTest = message2.GetValue("OBX.10");
                //string ObservResultStatus = message2.GetValue("OBX.11");
                //string DateLastObsNormalValues = message2.GetValue("OBX.12");
                //string UserDefinedAccessChecks = message2.GetValue("OBX.13");
                //string DateOfObservation = message2.GetValue("OBX.14");
                //string ProducerID = message2.GetValue("OBX.15");
                //string ResponsibleObserver = message2.GetValue("OBX.16");
                //string ObservationMethod = message2.GetValue("OBX.17");

                //Dictionary<string, string> ORXmsg = new Dictionary<string, string>();
                //ORXmsg.Add("SetID", SetID);
                //ORXmsg.Add("ValueType", ValueType);
                //ORXmsg.Add("ObservationIdentifier", ObservationIdentifier);
                //ORXmsg.Add("ObservationSubID", ObservationSubID);
                //ORXmsg.Add("ObservationValue", ObservationValue);
                //ORXmsg.Add("Units", Units);
                //ORXmsg.Add("ReferenceRange", ReferenceRange);
                //ORXmsg.Add("AbnormalFlags", AbnormalFlags);
                //ORXmsg.Add("Probability", Probability);
                //ORXmsg.Add("NatureOfAbnormalTest", NatureOfAbnormalTest);
                //ORXmsg.Add("ObservResultStatus", ObservResultStatus);
                //ORXmsg.Add("DateLastObsNormalValues", DateLastObsNormalValues);
                //ORXmsg.Add("UserDefinedAccessChecks", UserDefinedAccessChecks);
                //ORXmsg.Add("DateOfObservation", DateOfObservation);
                //ORXmsg.Add("ProducerID", ProducerID);
                //ORXmsg.Add("ResponsibleObserver", ResponsibleObserver);
                //ORXmsg.Add("ObservationMethod", ObservationMethod);

                //string json = MyDictionaryToJson(ORXmsg);

                //#endregion OBX
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at HL7ToJson. Message: " + ex.Message);
            }
        }



        string MyDictionaryToJson(Dictionary<string, string> dict)
        {
            try
            {
                var entries = dict.Select(d =>
                    string.Format("\"{0}\": \"{1}\"", d.Key, string.Join(",", d.Value)));
                return "{" + string.Join(",", entries) + "}";
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at MyDictionaryToJson. Message: " + ex.Message);
                return "";
            }
        }



        private void OnElapsedTimeCall(object state)
        {
            try
            {
                Logger.Info("HL7ReportingService at OnElapsedTimeCall.");
                HL7ToJson();
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at OnElapsedTime. Message: " + ex.Message);
            }
        }

    }
}
