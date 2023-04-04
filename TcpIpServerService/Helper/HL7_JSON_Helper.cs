using HL7.Dotnetcore;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrilliumReportService.Helper
{
    public class HL7_JSON_Helper
    {
        Logger Logger = LogManager.GetCurrentClassLogger();
        string ORUjson = "";
        public string HL7ToJsonParser()
        {
            try
            {
                Logger.Info("At HL7ToJson..");
                string[] filesArray = Directory.GetFiles(CommonData.CONNEXION_REPLY_DIRECTORY);
                Logger.Info("STEP1: Files in existing folder: " + filesArray.Length);
                for (int i = 0; i < filesArray.Length; i++)
                {
                    var filpath = filesArray[i];
                    Logger.Info("STEP2: HL7Message file: " + filpath);

                    string HL7_ORU = File.ReadAllText(filesArray[i]);
                    var message2 = new Message(HL7_ORU);
                    message2.ParseMessage();
                    var msgORU = new Message(HL7_ORU);


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

                    if (message2.GetValue("MSH.9").Contains(CommonData.ORU))
                    {
                        //messageType: ORU
                        List<Segment> mshList = message2.Segments("MSH");
                        List<Segment> pidList = message2.Segments("PID");
                        List<Segment> pv1List = message2.Segments("PV1");
                        List<Segment> orcList = message2.Segments("ORC");
                        List<Segment> obrList = message2.Segments("OBR");
                        List<Segment> obxList = message2.Segments("OBX");
                        Logger.Info("mshList.count= " + mshList.Count + ", pidList.Count= " + pidList.Count
                            + ", pv1List.Count= " + pv1List.Count + ", orcList.Count= " + orcList.Count
                            + ", obrList.Count= " + obrList.Count + ", obxList.Count= " + obxList.Count);
                        var mshFieldCount = mshList[0].GetAllFields();
                        var pidFieldCount = pidList[0].GetAllFields();
                        var pv1FieldCount = pv1List[0].GetAllFields();
                        var orcFieldCount = orcList[0].GetAllFields();
                        var obrFieldCount = obrList[0].GetAllFields();
                        var obxFieldCount = obxList[0].GetAllFields();

                        Logger.Info("mshFieldCount= " + mshFieldCount.Count() + ", pidFieldCount= " + pidFieldCount.Count()
                           + ", pv1FieldCount= " + pv1FieldCount.Count() + ", orcFieldCount= " + orcFieldCount.Count()
                           + ", obrFieldCount= " + obrFieldCount.Count() + ", obxFieldCount= " + obxFieldCount.Count());


                        Logger.Info("Message Type: " + CommonData.ORU);
                        ORUmsg.Add("patient_encounter_id", "368");
                        ORUmsg.Add("Sending Application", message2.GetValue("MSH.3") ?? string.Empty);
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
                        ORUmsg.Add("Patient ID_ExternalID", message2.GetValue("PID.2"));
                        ORUmsg.Add("Patient ID_InternalID", message2.GetValue("PID.3"));
                        ORUmsg.Add("Patient ID_Alternate", message2.GetValue("PID.4"));
                        ORUmsg.Add("Patient Name", message2.GetValue("PID.5"));
                        ORUmsg.Add("Mother's Maiden Name", message2.GetValue("PID.6"));
                        ORUmsg.Add("Date of Birth", message2.GetValue("PID.7"));
                        ORUmsg.Add("Sex", message2.GetValue("PID.8"));
                        ORUmsg.Add("Patient Alias", message2.GetValue("PID.9"));
                        ORUmsg.Add("Race", message2.GetValue("PID.10"));
                        ORUmsg.Add("Patient Address", message2.GetValue("PID.11"));
                        ORUmsg.Add("County Code", message2.GetValue("PID.12"));
                        ORUmsg.Add("Phone Number - Home", message2.GetValue("PID.13"));
                        ORUmsg.Add("Phone Number - Business", message2.GetValue("PID.14"));
                        ORUmsg.Add("Primary Language", message2.GetValue("PID.15"));
                        ORUmsg.Add("Marital Status", message2.GetValue("PID.16"));
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
                        ORUmsg.Add("Observation Sub-ID", message2.GetValue("OBX.4"));// ORUmsg.Add("Observation Sub-ID", obxList[0].Fields(4).Value));
                        ORUmsg.Add("Observation Value", obxList[0].Fields(5).Value);//message2.GetValue("OBX.5"));
                        Logger.Info("*Observation Sub-IDmessage2.GetValue(OBX.4): " + message2.GetValue("OBX.4"));
                        Logger.Info("*Observation Sub-ID=obxList[0].Fields(4).Value: " + obxList[0].Fields(4).Value);
                        Logger.Info("* Observation Value=message2.GetValue(OBX.5): " + message2.GetValue("OBX.5"));
                        Logger.Info("* Observation Value=obxList[0].Fields(5).Value: " + obxList[0].Fields(5).Value);
                        Logger.Info("------------");
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

                        ORUjson = MyDictionaryToJson(ORUmsg);
                        Logger.Info("For " + CommonData.ORU + ", Generated json= " + ORUjson);
                    }
                    else if (message2.GetValue("MSH.9").Contains(CommonData.ADT))
                    {
                        //messageType: ADT
                        List<Segment> mshList = message2.Segments("MSH");
                        List<Segment> evnList = message2.Segments("EVN");
                        List<Segment> pidList = message2.Segments("PID");
                        List<Segment> nk1List = message2.Segments("NK1");
                        List<Segment> pv1List = message2.Segments("PV1");
                        List<Segment> gt1List = message2.Segments("GT1");
                        List<Segment> dg1List = message2.Segments("DG1");
                        List<Segment> in1List = message2.Segments("IN1");
                        List<Segment> in2List = message2.Segments("IN2");

                        Logger.Info("mshList.count= " + mshList.Count + ", evnList.Count= " + evnList.Count
                       + ", pidList.Count= " + pidList.Count + ", nk1List.Count= " + nk1List.Count
                       + ", pv1List.Count= " + pv1List.Count);
                        var mshFieldCount = mshList[0].GetAllFields();
                        var evnFieldCount = evnList[0].GetAllFields();
                        var pidFieldCount = pidList[0].GetAllFields();
                        var nk1FieldCount = nk1List[0].GetAllFields();
                        var pv1FieldCount = pv1List[0].GetAllFields();
                        var gt1FieldCount = gt1List[0].GetAllFields();
                        var dg1FieldCount = dg1List[0].GetAllFields();
                        var in1FieldCount = in1List[0].GetAllFields();
                        var in2FieldCount = in2List[0].GetAllFields();

                        Logger.Info("mshFieldCount= " + mshFieldCount.Count() + ", evnFieldCount= " + evnFieldCount.Count()
                           + ", pidFieldCount= " + pidFieldCount.Count() + ", nk1FieldCount= " + nk1FieldCount.Count()
                           + ", pv1FieldCount= " + pv1FieldCount.Count() + ", gt1FieldCount= " + gt1FieldCount.Count()
                           + ", dg1FieldCount= " + dg1FieldCount.Count() + ", in1FieldCount= " + in1FieldCount.Count()
                           + ", in2FieldCount= " + in2FieldCount.Count());
                        int mshcnt = int.Parse(mshFieldCount.Count().ToString());
                        Logger.Info("Message Type: " + CommonData.ADT);

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
                        ORUmsg.Add("Continuation Pointer", message2.GetValue("MSH.14"));
                        ORUmsg.Add("Accept Acknowledgement Type", message2.GetValue("MSH.15"));
                        ORUmsg.Add("Application Acknowledgement Type", message2.GetValue("MSH.16"));
                        ORUmsg.Add("Country Code", message2.GetValue("MSH.17"));
                        ORUmsg.Add("Character Set", message2.GetValue("MSH.18"));
                        ORUmsg.Add("Principal Language of Message", message2.GetValue("MSH.19"));
                        Logger.Info("ADT Done");

                        ORUmsg.Add("Event Type Code", message2.GetValue("EVN.1"));
                        ORUmsg.Add("Record Date/Time", message2.GetValue("EVN.2"));
                        ORUmsg.Add("DateTime Planned Event", message2.GetValue("EVN.3"));
                        ORUmsg.Add("Event Reason Code", message2.GetValue("EVN.4"));
                        ORUmsg.Add("Operator ID", message2.GetValue("EVN.5"));
                        ORUmsg.Add("Event occured", message2.GetValue("EVN.6"));
                        Logger.Info("EVN Done");

                        ORUmsg.Add("Patient ID", message2.GetValue("PID.1"));
                        ORUmsg.Add("Patient ID_ExternalID", message2.GetValue("PID.2"));
                        ORUmsg.Add("Patient ID_InternalID", message2.GetValue("PID.3"));
                        ORUmsg.Add("Patient ID_Alternate", message2.GetValue("PID.4"));
                        ORUmsg.Add("Patient Name", message2.GetValue("PID.5"));
                        ORUmsg.Add("Mother's Maiden Name", message2.GetValue("PID.6"));
                        ORUmsg.Add("Date of Birth", message2.GetValue("PID.7"));
                        ORUmsg.Add("Sex", message2.GetValue("PID.8"));
                        ORUmsg.Add("Patient Alias", message2.GetValue("PID.9"));
                        ORUmsg.Add("Race", message2.GetValue("PID.10"));
                        ORUmsg.Add("Patient Address", message2.GetValue("PID.11"));
                        ORUmsg.Add("County Code", message2.GetValue("PID.12"));
                        ORUmsg.Add("Phone Number - Home", message2.GetValue("PID.13"));
                        ORUmsg.Add("Phone Number - Business", message2.GetValue("PID.14"));
                        ORUmsg.Add("Primary Language", message2.GetValue("PID.15"));
                        ORUmsg.Add("Marital Status", message2.GetValue("PID.16"));
                        ORUmsg.Add("Religion", message2.GetValue("PID.17"));
                        ORUmsg.Add("Patient Account Number", message2.GetValue("PID.18"));
                        ORUmsg.Add("SSN Number - Patient", message2.GetValue("PID.19"));
                        ORUmsg.Add("Driver's License Number", message2.GetValue("PID.20"));
                        ORUmsg.Add("Mother's Identifier", message2.GetValue("PID.21"));
                        ORUmsg.Add("Ethnic Group", message2.GetValue("PID.22"));
                        ORUmsg.Add("Birth Place", message2.GetValue("PID.23"));
                        ORUmsg.Add("Multiple Birth Indicator", message2.GetValue("PID.24"));
                        ORUmsg.Add("Birth Order", message2.GetValue("PID.25"));
                        ORUmsg.Add("Citizenship", message2.GetValue("PID.26"));
                        ORUmsg.Add("Veterans Military Status", message2.GetValue("PID.27"));
                        ORUmsg.Add("Nationality Code", message2.GetValue("PID.28"));
                        ORUmsg.Add("Patient Death DateTime", message2.GetValue("PID.29"));
                        Logger.Info("PID Done");

                        ORUmsg.Add("Set ID - Next of Kin", message2.GetValue("NK1.1"));
                        ORUmsg.Add("Name", message2.GetValue("NK1.2"));
                        ORUmsg.Add("Relationship", message2.GetValue("NK1.3"));
                        ORUmsg.Add("Address", message2.GetValue("NK1.4"));
                        ORUmsg.Add("Phone Number", message2.GetValue("NK1.5"));
                        ORUmsg.Add("Business Phone Number", message2.GetValue("NK1.6"));
                        ORUmsg.Add("Contact Role", message2.GetValue("NK1.7"));
                        ORUmsg.Add("Start Date", message2.GetValue("NK1.8"));
                        ORUmsg.Add("End Date", message2.GetValue("NK1.9"));
                        ORUmsg.Add("Next of Associated Parties Job Title", message2.GetValue("NK1.10"));
                        ORUmsg.Add("Next of Associated Parties Code", message2.GetValue("NK1.11"));
                        ORUmsg.Add("Next of Associated Parties Employee Number", message2.GetValue("NK1.12"));
                        ORUmsg.Add("Organization Name", message2.GetValue("NK1.13"));
                        ORUmsg.Add("nk1_Marital Status", message2.GetValue("NK1.14"));
                        ORUmsg.Add("nk1_Sex", message2.GetValue("NK1.15"));
                        ORUmsg.Add("nk1_Date of Birth", message2.GetValue("NK1.16"));
                        ORUmsg.Add("Living Dependency", message2.GetValue("NK1.17"));
                        ORUmsg.Add("Ambulatory Status", message2.GetValue("NK1.18"));
                        ORUmsg.Add("nk1_Citizenship", message2.GetValue("NK1.19"));
                        ORUmsg.Add("nk1_Primary Language", message2.GetValue("NK1.20"));
                        ORUmsg.Add("Living Arrangement", message2.GetValue("NK1.21"));
                        ORUmsg.Add("Publicity Indicator", message2.GetValue("NK1.22"));
                        ORUmsg.Add("Protection Indicator", message2.GetValue("NK1.23"));
                        ORUmsg.Add("Student Indicator", message2.GetValue("NK1.24"));
                        ORUmsg.Add("nk1_Religion", message2.GetValue("NK1.25"));
                        ORUmsg.Add("nk1_Mother's Maiden Name", message2.GetValue("NK1.26"));
                        ORUmsg.Add("nk1_Nationality Code", message2.GetValue("NK1.27"));
                        ORUmsg.Add("nk1_Ethnic Group", message2.GetValue("NK1.28"));
                        ORUmsg.Add("Contact Reason", message2.GetValue("NK1.29"));
                        ORUmsg.Add("Contact Person's Name", message2.GetValue("NK1.30"));
                        ORUmsg.Add("Contact Person's Telephone Number", message2.GetValue("NK1.31"));
                        ORUmsg.Add("Contact Person's Address", message2.GetValue("NK1.32"));
                        ORUmsg.Add("Associated Party's Identifiers", message2.GetValue("NK1.33"));
                        ORUmsg.Add("Job Status", message2.GetValue("NK1.34"));
                        ORUmsg.Add("nk1_Race", message2.GetValue("NK1.35"));
                        ORUmsg.Add("Handicap", message2.GetValue("NK1.36"));
                        ORUmsg.Add("Contact Person Social Security Number", message2.GetValue("NK1.37"));
                        Logger.Info("NK1 Done");

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
                        ORUmsg.Add("pv1_Ambulatory Status", message2.GetValue("PV1.15"));
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
                        ORUmsg.Add("Discharged to Location", message2.GetValue("PV1.37"));
                        ORUmsg.Add("Diet Type", message2.GetValue("PV1.38"));
                        ORUmsg.Add("Servicing Facility", message2.GetValue("PV1.39"));
                        ORUmsg.Add("Bed Status", message2.GetValue("PV1.40"));
                        ORUmsg.Add("Account Status", message2.GetValue("PV1.41"));
                        ORUmsg.Add("Pending Location", message2.GetValue("PV1.42"));
                        ORUmsg.Add("Prior Temporary Location", message2.GetValue("PV1.43"));
                        ORUmsg.Add("Admit DateTime", message2.GetValue("PV1.44"));
                        ORUmsg.Add("Discharge DateTime", message2.GetValue("PV1.45"));
                        ORUmsg.Add("Current Patient Balance", message2.GetValue("PV1.46"));
                        ORUmsg.Add("Total Charges", message2.GetValue("PV1.47"));
                        ORUmsg.Add("Total Adjustments", message2.GetValue("PV1.48"));
                        ORUmsg.Add("Total Payments", message2.GetValue("PV1.49"));
                        ORUmsg.Add("Alternate Visit ID", message2.GetValue("PV1.50"));
                        ORUmsg.Add("Visit Indicator", message2.GetValue("PV1.51"));
                        ORUmsg.Add("Other Healthcare Provider", message2.GetValue("PV1.52"));
                        Logger.Info("PV1 Done");

                        ORUmsg.Add("Set ID - Guarantor", message2.GetValue("GT1.1"));
                        ORUmsg.Add("Guarantor Number", message2.GetValue("GT1.2"));
                        ORUmsg.Add("Guarantor Name", message2.GetValue("GT1.3"));
                        ORUmsg.Add("Guarantor Spouse Name", message2.GetValue("GT1.4"));
                        ORUmsg.Add("Guarantor Address", message2.GetValue("GT1.5"));
                        ORUmsg.Add("Guarantor PhoneNumber - Home", message2.GetValue("GT1.6"));
                        ORUmsg.Add("Guarantor PhoneNumber - Business", message2.GetValue("GT1.7"));
                        ORUmsg.Add("Guarantor DateTime of Birth", message2.GetValue("GT1.8"));
                        ORUmsg.Add("Guarantor Sex", message2.GetValue("GT1.9"));
                        ORUmsg.Add("Guarantor Type", message2.GetValue("GT1.10"));
                        ORUmsg.Add("Guarantor Relationship", message2.GetValue("GT1.11"));
                        ORUmsg.Add("Guarantor SSN", message2.GetValue("GT1.12"));
                        ORUmsg.Add("Guarantor Date - Begin", message2.GetValue("GT1.13"));
                        ORUmsg.Add("Guarantor Date - End", message2.GetValue("GT1.14"));
                        ORUmsg.Add("Guarantor Priority", message2.GetValue("GT1.15"));
                        ORUmsg.Add("Guarantor Employer Name", message2.GetValue("GT1.16"));
                        ORUmsg.Add("Guarantor Employer Address", message2.GetValue("GT1.17"));
                        ORUmsg.Add("Guarantor Employ Phone Number", message2.GetValue("GT1.18"));
                        ORUmsg.Add("Guarantor Employee ID Number", message2.GetValue("GT1.19"));
                        ORUmsg.Add("Guarantor Employment Status", message2.GetValue("GT1.20"));
                        ORUmsg.Add("Guarantor Organization", message2.GetValue("GT1.21"));
                        Logger.Info("GT1 Done");

                        ORUmsg.Add("Set ID - Insurance", message2.GetValue("IN1.1"));
                        ORUmsg.Add("Insurance Plan ID", message2.GetValue("IN1.2"));
                        ORUmsg.Add("Insurance Company ID", message2.GetValue("IN1.3"));
                        ORUmsg.Add("Insurance Company Name", message2.GetValue("IN1.4"));
                        ORUmsg.Add("Insurance Company Address", message2.GetValue("IN1.5"));
                        ORUmsg.Add("Insurance Company Contact Papers", message2.GetValue("IN1.6"));
                        ORUmsg.Add("Insurance Company Phone Number", message2.GetValue("IN1.7"));
                        ORUmsg.Add("Group Number", message2.GetValue("IN1.8"));
                        ORUmsg.Add("Group Name", message2.GetValue("IN1.9"));
                        ORUmsg.Add("Insured's Group Employer ID", message2.GetValue("IN1.10"));
                        ORUmsg.Add("Insured's Group Employer Name", message2.GetValue("IN1.11"));
                        ORUmsg.Add("Plan Effective Date", message2.GetValue("IN1.12"));
                        ORUmsg.Add("Plan Expiration Date", message2.GetValue("IN1.13"));
                        ORUmsg.Add("Authorization Information", message2.GetValue("IN1.14"));
                        ORUmsg.Add("Plan Type", message2.GetValue("IN1.15"));
                        ORUmsg.Add("Name of Insured", message2.GetValue("IN1.16"));
                        ORUmsg.Add("Insured's Relationship to Patient", message2.GetValue("IN1.17"));
                        ORUmsg.Add("Insured's Date of Birth", message2.GetValue("IN1.18"));
                        ORUmsg.Add("Insured's Address", message2.GetValue("IN1.19"));
                        ORUmsg.Add("Assignment of Benefits", message2.GetValue("IN1.20"));
                        ORUmsg.Add("Coordination of Benefits", message2.GetValue("IN1.21"));
                        ORUmsg.Add("Coordination of Benefits Priority", message2.GetValue("IN1.22"));
                        ORUmsg.Add("Notice of Admission Code", message2.GetValue("IN1.23"));
                        ORUmsg.Add("Notice of Admission Date", message2.GetValue("IN1.24"));
                        ORUmsg.Add("Rpt of Eligibility Code", message2.GetValue("IN1.25"));
                        ORUmsg.Add("Rpt of Eligibility Date", message2.GetValue("IN1.26"));
                        ORUmsg.Add("Release Information Code", message2.GetValue("IN1.27"));
                        ORUmsg.Add("Pre-Admit Cert", message2.GetValue("IN1.28"));
                        ORUmsg.Add("Verification DateTime", message2.GetValue("IN1.29"));
                        ORUmsg.Add("Verification By", message2.GetValue("IN1.30"));
                        ORUmsg.Add("Type of Agreement Code", message2.GetValue("IN1.31"));
                        ORUmsg.Add("Billing Status", message2.GetValue("IN1.32"));
                        ORUmsg.Add("Lifetime Reserve Days", message2.GetValue("IN1.33"));
                        ORUmsg.Add("Delay before lifetime reserve days", message2.GetValue("IN1.34"));
                        ORUmsg.Add("Company Plan Code", message2.GetValue("IN1.35"));
                        ORUmsg.Add("Policy Number", message2.GetValue("IN1.36"));
                        ORUmsg.Add("Policy Deductible", message2.GetValue("IN1.37"));
                        ORUmsg.Add("Policy Limit - Amount", message2.GetValue("IN1.38"));
                        ORUmsg.Add("Policy Limit - Days", message2.GetValue("IN1.39"));
                        ORUmsg.Add("Room Rate - Semi Private", message2.GetValue("IN1.40"));
                        ORUmsg.Add("Room Rate - Private", message2.GetValue("IN1.41"));
                        ORUmsg.Add("Insured's Employment Status", message2.GetValue("IN1.42"));
                        ORUmsg.Add("Insured's Sex", message2.GetValue("IN1.43"));
                        ORUmsg.Add("Insured's Employer Address", message2.GetValue("IN1.44"));
                        ORUmsg.Add("Verification Status", message2.GetValue("IN1.45"));
                        ORUmsg.Add("Prior Insurance Plan ID", message2.GetValue("IN1.46"));
                        ORUmsg.Add("Coverage Type", message2.GetValue("IN1.47"));
                        ORUmsg.Add("in1_Handicap", message2.GetValue("IN1.48"));
                        ORUmsg.Add("Insured's ID Number", message2.GetValue("IN1.49"));
                        Logger.Info("IN1 Done");

                        ORUmsg.Add("Insured's Employee ID", message2.GetValue("IN2.1"));
                        ORUmsg.Add("Insured's Social Security Number", message2.GetValue("IN2.2"));
                        ORUmsg.Add("Insured's Employer Name", message2.GetValue("IN2.3"));
                        ORUmsg.Add("Employer Information Data", message2.GetValue("IN2.4"));
                        ORUmsg.Add("Mail Claim Party", message2.GetValue("IN2.5"));
                        ORUmsg.Add("Medicare Health Ins Card Number", message2.GetValue("IN2.6"));
                        ORUmsg.Add("Medicaid Case Name", message2.GetValue("IN2.7"));
                        ORUmsg.Add("Medicaid Case Number", message2.GetValue("IN2.8"));
                        ORUmsg.Add("Campus Sponsor Name", message2.GetValue("IN2.9"));
                        ORUmsg.Add("Campus ID Number", message2.GetValue("IN2.10"));
                        ORUmsg.Add("Dependent of Campus Recipient", message2.GetValue("IN2.11"));
                        ORUmsg.Add("Campus Organization", message2.GetValue("IN2.12"));
                        ORUmsg.Add("Campus Station", message2.GetValue("IN2.13"));
                        ORUmsg.Add("Campus Service", message2.GetValue("IN2.14"));
                        ORUmsg.Add("Campus Rank", message2.GetValue("IN2.15"));
                        ORUmsg.Add("Campus Status", message2.GetValue("IN2.16"));
                        ORUmsg.Add("Campus Retire Date", message2.GetValue("IN2.17"));
                        ORUmsg.Add("Campus Non-Avail Cert on File", message2.GetValue("IN2.18"));
                        ORUmsg.Add("Baby Coverage", message2.GetValue("IN2.19"));
                        ORUmsg.Add("Combile Baby Bill", message2.GetValue("IN2.20"));
                        ORUmsg.Add("Blood Deductible", message2.GetValue("IN2.21"));
                        ORUmsg.Add("Special Coverage Approval Name", message2.GetValue("IN2.22"));
                        ORUmsg.Add("Special Coverage Approval Title", message2.GetValue("IN2.23"));
                        ORUmsg.Add("Non-Covered Insurance Code", message2.GetValue("IN2.24"));
                        ORUmsg.Add("Payor ID", message2.GetValue("IN2.25"));
                        ORUmsg.Add("Payor Subcriber ID", message2.GetValue("IN2.26"));
                        ORUmsg.Add("Eligibility Source", message2.GetValue("IN2.27"));
                        ORUmsg.Add("Room Coverage Type", message2.GetValue("IN2.28"));
                        ORUmsg.Add("Policy Type", message2.GetValue("IN2.29"));
                        ORUmsg.Add("Daily Deductible", message2.GetValue("IN2.30"));
                        ORUmsg.Add("in2_Living Dependency", message2.GetValue("IN2.31"));
                        ORUmsg.Add("in2_Ambulatory Status", message2.GetValue("IN2.32"));
                        ORUmsg.Add("in2_Citizenship", message2.GetValue("IN2.33"));
                        ORUmsg.Add("in2_Primary Language", message2.GetValue("IN2.34"));
                        ORUmsg.Add("in2_Living Arrangement", message2.GetValue("IN2.35"));
                        ORUmsg.Add("in2_Publicity Indicator", message2.GetValue("IN2.36"));
                        ORUmsg.Add("in2_Protection Indicator", message2.GetValue("IN2.37"));
                        ORUmsg.Add("in2_Student Indicator", message2.GetValue("IN2.38"));
                        ORUmsg.Add("in2_Religion", message2.GetValue("IN2.39"));
                        ORUmsg.Add("in2_Mother's Maiden Name", message2.GetValue("IN2.40"));
                        ORUmsg.Add("in2_Nationality Code", message2.GetValue("IN2.41"));
                        ORUmsg.Add("in2_Ethnic Group", message2.GetValue("IN2.42"));
                        ORUmsg.Add("in2_Marital Status", message2.GetValue("IN2.43"));
                        ORUmsg.Add("Employment Start Date", message2.GetValue("IN2.44"));
                        ORUmsg.Add("Employment Stop Date", message2.GetValue("IN2.45"));
                        ORUmsg.Add("Job Title", message2.GetValue("IN2.46"));
                        ORUmsg.Add("Job Code", message2.GetValue("IN2.47"));
                        ORUmsg.Add("in2_Job Status", message2.GetValue("IN2.48"));
                        ORUmsg.Add("Employer Contact Person Name", message2.GetValue("IN2.49"));
                        ORUmsg.Add("Employer Contact Person Phone Number", message2.GetValue("IN2.50"));
                        ORUmsg.Add("Employer Contact Reason", message2.GetValue("IN2.51"));
                        ORUmsg.Add("Insured's Contact Person's Name", message2.GetValue("IN2.52"));
                        ORUmsg.Add("Insured's Contact Person Telephone Number", message2.GetValue("IN2.53"));
                        ORUmsg.Add("Insured's Contact Person Reason", message2.GetValue("IN2.54"));
                        ORUmsg.Add("Relationship to The Patient Start Date", message2.GetValue("IN2.55"));
                        ORUmsg.Add("Relationship to The Patient Stop Date", message2.GetValue("IN2.56"));
                        ORUmsg.Add("Insurance Co. Contact Reason", message2.GetValue("IN2.57"));
                        ORUmsg.Add("Insurance Co. Phone Number", message2.GetValue("IN2.58"));
                        ORUmsg.Add("Policy Scope", message2.GetValue("IN2.59"));
                        ORUmsg.Add("Policy Source", message2.GetValue("IN2.60"));
                        ORUmsg.Add("Patient Member Number", message2.GetValue("IN2.61"));
                        ORUmsg.Add("Gurantor's Relationship To Insured", message2.GetValue("IN2.62"));
                        ORUmsg.Add("Insured's Telephone Number - Home", message2.GetValue("IN2.63"));
                        ORUmsg.Add("Insured's Employer Telephone Number", message2.GetValue("IN2.64"));
                        Logger.Info("IN2 Done");
                        ORUjson = MyDictionaryToJson(ORUmsg);
                        Logger.Info("For " + CommonData.ADT + ", Generated json= " + ORUjson);

                    }
                    else if (message2.GetValue("MSH.9").Contains(CommonData.ORM))
                    {
                        //messageType: ORM
                        List<Segment> mshList = message2.Segments("MSH");
                        List<Segment> pidList = message2.Segments("PID");
                        List<Segment> pv1List = message2.Segments("PV1");
                        List<Segment> orcList = message2.Segments("ORC");
                        List<Segment> obrList = message2.Segments("OBR");

                        Logger.Info("mshList.count= " + mshList.Count + ", pidList.Count= " + pidList.Count
                       + ", pv1List.Count= " + pv1List.Count + ", orcList.Count= " + orcList.Count + ", obrList.Count= " + obrList.Count);
                        var mshFieldCount = mshList[0].GetAllFields();
                        var pidFieldCount = pidList[0].GetAllFields();
                        var pv1FieldCount = pv1List[0].GetAllFields();
                        var orcFieldCount = orcList[0].GetAllFields();
                        var obrFieldCount = obrList[0].GetAllFields();


                        Logger.Info("mshFieldCount= " + mshFieldCount.Count() + ", pidFieldCount= " + pidFieldCount.Count()
                          + ", pv1FieldCount= " + pv1FieldCount.Count() + ", orcFieldCount= " + orcFieldCount.Count()
                          + ", obrFieldCount= " + obrFieldCount.Count());




                        Logger.Info("Message Type: " + CommonData.ORM);

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
                        Logger.Info("MSH Done");

                        ORUmsg.Add("PID", message2.GetValue("PID.1"));
                        ORUmsg.Add("Patient ID", message2.GetValue("PID.2"));
                        ORUmsg.Add("Patient Identifier List", message2.GetValue("PID.3"));
                        ORUmsg.Add("Patient ID_Alternate", message2.GetValue("PID.4"));
                        //ORUmsg.Add("Patient ID_Alternate", message2.GetValue("PID.5"));
                        ORUmsg.Add("Patient Name", message2.GetValue("PID.5"));
                        ORUmsg.Add("Mother's Maiden Name", message2.GetValue("PID.6"));
                        ORUmsg.Add("Date of Birth", message2.GetValue("PID.7"));
                        ORUmsg.Add("Sex", message2.GetValue("PID.8"));
                        ORUmsg.Add("Patient Alias", message2.GetValue("PID.9"));
                        ORUmsg.Add("Race", message2.GetValue("PID.10"));
                        ORUmsg.Add("Patient Address", message2.GetValue("PID.11"));
                        //ORUmsg.Add("County Code", message2.GetValue("PID.13"));
                        //ORUmsg.Add("Phone Number - Home", message2.GetValue("PID.13"));
                        //ORUmsg.Add("Phone Number - Business", message2.GetValue("PID.14"));
                        //ORUmsg.Add("Primary Language", message2.GetValue("PID.15"));
                        //ORUmsg.Add("Marital Status", message2.GetValue("PID.16"));
                        //ORUmsg.Add("Religion", message2.GetValue("PID.17"));
                        //ORUmsg.Add("Patient Account Number", message2.GetValue("PID.18"));
                        Logger.Info("PID Done");

                        ORUmsg.Add("Set ID - PV1", message2.GetValue("PV1.1"));
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
                        //ORUmsg.Add("Financial Class", message2.GetValue("PV1.20"));
                        //ORUmsg.Add("Charge Price Indicator", message2.GetValue("PV1.21"));
                        //ORUmsg.Add("Courtesy Code", message2.GetValue("PV1.22"));
                        //ORUmsg.Add("Credit Rating", message2.GetValue("PV1.23"));
                        //ORUmsg.Add("Contract Code", message2.GetValue("PV1.24"));
                        //ORUmsg.Add("Contract Effective Date", message2.GetValue("PV1.25"));
                        //ORUmsg.Add("Contract Amount", message2.GetValue("PV1.26"));
                        //ORUmsg.Add("Contract Period", message2.GetValue("PV1.27"));
                        //ORUmsg.Add("Interest Code", message2.GetValue("PV1.28"));
                        //ORUmsg.Add("Transfer to Bad Debt Code", message2.GetValue("PV1.29"));
                        //ORUmsg.Add("Transfer to Bad Debt Date", message2.GetValue("PV1.30"));
                        //ORUmsg.Add("Bad Debt Agency Code", message2.GetValue("PV1.31"));
                        //ORUmsg.Add("Bad Debt Transfer Amount", message2.GetValue("PV1.32"));
                        //ORUmsg.Add("Bad Debt Recovery Amount", message2.GetValue("PV1.33"));
                        //ORUmsg.Add("Delete Account Indicator", message2.GetValue("PV1.34"));
                        //ORUmsg.Add("Delete Account Date", message2.GetValue("PV1.35"));
                        //ORUmsg.Add("Discharge Disposition", message2.GetValue("PV1.36"));
                        //ORUmsg.Add("Discharged Location", message2.GetValue("PV1.37"));
                        //ORUmsg.Add("Diet Type", message2.GetValue("PV1.38"));
                        //ORUmsg.Add("Servicing Facility", message2.GetValue("PV1.39"));
                        //ORUmsg.Add("Bed Status", message2.GetValue("PV1.40"));
                        //ORUmsg.Add("Account Status", message2.GetValue("PV1.41"));
                        //ORUmsg.Add("Pending Location", message2.GetValue("PV1.42"));
                        //ORUmsg.Add("Prior Temporary Location", message2.GetValue("PV1.43"));
                        //ORUmsg.Add("Admit DateTime", message2.GetValue("PV1.44"));
                        //ORUmsg.Add("Discharge DateTime", message2.GetValue("PV1.45"));
                        //ORUmsg.Add("Current Patient Balance", message2.GetValue("PV1.46"));
                        Logger.Info("PV1 Done");

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
                        ORUmsg.Add("Verified By", message2.GetValue("ORC.11"));
                        ORUmsg.Add("Ordering Provider", message2.GetValue("ORC.12"));
                        ORUmsg.Add("Enterer's Location", message2.GetValue("ORC.13"));
                        ORUmsg.Add("Call Back Phone Number", message2.GetValue("ORC.14"));
                        ORUmsg.Add("Order Effective DateTime", message2.GetValue("ORC.15"));
                        ORUmsg.Add("Order Control Code Reason", message2.GetValue("ORC.16"));
                        ORUmsg.Add("Entering Organization", message2.GetValue("ORC.17"));
                        ORUmsg.Add("Entering Device", message2.GetValue("ORC.18"));
                        ORUmsg.Add("Action By", message2.GetValue("ORC.19"));
                        ORUmsg.Add("Advanced Beneficiary Notice Code", message2.GetValue("ORC.20"));
                        ORUmsg.Add("Ordering Facility Name", message2.GetValue("ORC.21"));
                        ORUmsg.Add("Ordering Facility Address", message2.GetValue("ORC.22"));
                        ORUmsg.Add("Ordering Facility Phone Number", message2.GetValue("ORC.23"));
                        ORUmsg.Add("Ordering Provider Address", message2.GetValue("ORC.24"));
                        Logger.Info("ORC Done");

                        ORUmsg.Add("Set ID-OBR", message2.GetValue("OBR.1"));
                        ORUmsg.Add("obr_Placer Order Number", message2.GetValue("OBR.2"));
                        ORUmsg.Add("obr_Filler Order Number", message2.GetValue("OBR.3"));
                        ORUmsg.Add("Universal Service ID", message2.GetValue("OBR.4"));
                        ORUmsg.Add("Priority-OBR", message2.GetValue("OBR.5"));
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
                        ORUmsg.Add("obr_Ordering Provider", message2.GetValue("OBR.16"));
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
                        ORUmsg.Add("obr_QuantityTiming", message2.GetValue("OBR.27"));
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
                        ORUmsg.Add("Transport Logistics of Collected Sample", message2.GetValue("OBR.38"));
                        ORUmsg.Add("Collector's Comment", message2.GetValue("OBR.39"));
                        ORUmsg.Add("Transport Arrangement Responsibility", message2.GetValue("OBR.40"));
                        ORUmsg.Add("Transport Arranged", message2.GetValue("OBR.41"));
                        ORUmsg.Add("Escort Required", message2.GetValue("OBR.42"));
                        ORUmsg.Add("Planned Patient Transport Comment", message2.GetValue("OBR.43"));
                        ORUmsg.Add("Procedure Code", message2.GetValue("OBR.44"));
                        ORUmsg.Add("Procedure Code Modifier", message2.GetValue("OBR.45"));
                        Logger.Info("OBR Done");
                        ORUjson = MyDictionaryToJson(ORUmsg);
                        Logger.Info("For " + CommonData.ORM + ", Generated json= " + ORUjson);

                    }
                    else if (message2.GetValue("MSH.9").Contains(CommonData.ACK))
                    {
                        Logger.Info("Message Type: " + CommonData.ACK);
                    }

                    try
                    {
                        File.Delete(filpath);
                        Logger.Info("File Deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Exception at deleting filename: " + filpath + ", Message: " + ex.Message);
                    }


                    #region OBX 
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

                    #endregion OBX
                }

                return ORUjson;
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at HL7ToJson. Message: " + ex.Message);
                return "";
            }
        }



        public void HL7_JSON()
        {
            try
            {
                Logger.Info("At HL7_JSON..");
                string[] filesArray = Directory.GetFiles(CommonData.CONNEXION_REPLY_DIRECTORY);
                Logger.Info("STEP1: Files in existing folder: " + filesArray.Length);
                for (int i = 0; i < filesArray.Length; i++)
                {
                    var filpath = filesArray[i];
                    Logger.Info("STEP2: HL7Message file: " + filpath);

                    string HL7_ORU = File.ReadAllText(filesArray[i]);
                    var message2 = new Message(HL7_ORU);
                    message2.ParseMessage();
                    var msgORU = new Message(HL7_ORU);

                    List<Segment> MSHList = message2.Segments("MSH");
                    List<Segment> EVNList = message2.Segments("EVN");
                    List<Segment> PIDList = message2.Segments("PID");
                    List<Segment> NK1List = message2.Segments("NK1");
                    List<Segment> PV1List = message2.Segments("PV1");
                    List<Segment> ORCList = message2.Segments("ORC");
                    List<Segment> OBRList = message2.Segments("OBR");
                    List<Segment> OBXList = message2.Segments("OBX");
                    Logger.Info("MSHList.count= " + MSHList.Count + ", PIDList.Count= " + PIDList.Count
                        + ", PV1List.Count= " + PV1List.Count + ", ORCList.Count= " + ORCList.Count
                        + ", OBRList.Count= " + OBRList.Count + ", OBXList.Count= " + OBXList.Count
                        + ", EVNList.Count= " + EVNList.Count + ", NK1List.Count= " + NK1List.Count);



                    Dictionary<string, string> ORUmsg = new Dictionary<string, string>();

                    if (message2.GetValue("MSH.9").Contains(CommonData.ORU))
                    {
                        //messageType: ORU
                        Logger.Info("Message Type: " + CommonData.ORU);
                        ORUmsg.Add("Sending Application", message2.GetValue("MSH.3") ?? string.Empty);
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
                        ORUmsg.Add("Patient ID_ExternalID", message2.GetValue("PID.2"));
                        ORUmsg.Add("Patient ID_InternalID", message2.GetValue("PID.3"));
                        ORUmsg.Add("Patient ID_Alternate", message2.GetValue("PID.4"));
                        ORUmsg.Add("Patient Name", message2.GetValue("PID.5"));
                        ORUmsg.Add("Mother's Maiden Name", message2.GetValue("PID.6"));
                        ORUmsg.Add("Date of Birth", message2.GetValue("PID.7"));
                        ORUmsg.Add("Sex", message2.GetValue("PID.8"));
                        ORUmsg.Add("Patient Alias", message2.GetValue("PID.9"));
                        ORUmsg.Add("Race", message2.GetValue("PID.10"));
                        ORUmsg.Add("Patient Address", message2.GetValue("PID.11"));
                        ORUmsg.Add("County Code", message2.GetValue("PID.12"));
                        ORUmsg.Add("Phone Number - Home", message2.GetValue("PID.13"));
                        ORUmsg.Add("Phone Number - Business", message2.GetValue("PID.14"));
                        ORUmsg.Add("Primary Language", message2.GetValue("PID.15"));
                        ORUmsg.Add("Marital Status", message2.GetValue("PID.16"));
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
                        Logger.Info("For " + CommonData.ORU + ", Generated json= " + ORUjson);
                    }
                    else if (message2.GetValue("MSH.9").Contains(CommonData.ADT))
                    {
                        //messageType: ADT
                        List<Segment> mshList = message2.Segments("MSH");
                        List<Segment> evnList = message2.Segments("EVN");
                        List<Segment> pidList = message2.Segments("PID");
                        List<Segment> nk1List = message2.Segments("NK1");
                        List<Segment> pv1List = message2.Segments("PV1");
                        List<Segment> gt1List = message2.Segments("GT1");
                        List<Segment> dg1List = message2.Segments("DG1");
                        List<Segment> in1List = message2.Segments("IN1");
                        List<Segment> in2List = message2.Segments("IN2");

                        Logger.Info("mshList.count= " + mshList.Count + ", evnList.Count= " + evnList.Count
                       + ", pidList.Count= " + pidList.Count + ", nk1List.Count= " + nk1List.Count
                       + ", pv1List.Count= " + pv1List.Count);
                        var mshFieldCount = mshList[0].GetAllFields();
                        var evnFieldCount = evnList[0].GetAllFields();
                        var pidFieldCount = pidList[0].GetAllFields();
                        var nk1FieldCount = nk1List[0].GetAllFields();
                        var pv1FieldCount = pv1List[0].GetAllFields();
                        var gt1FieldCount = gt1List[0].GetAllFields();
                        var dg1FieldCount = dg1List[0].GetAllFields();
                        var in1FieldCount = in1List[0].GetAllFields();
                        var in2FieldCount = in2List[0].GetAllFields();

                        Logger.Info("mshFieldCount= " + mshFieldCount.Count() + ", evnFieldCount= " + evnFieldCount.Count()
                           + ", pidFieldCount= " + pidFieldCount.Count() + ", nk1FieldCount= " + nk1FieldCount.Count()
                           + ", pv1FieldCount= " + pv1FieldCount.Count() + ", gt1FieldCount= " + gt1FieldCount.Count()
                           + ", dg1FieldCount= " + dg1FieldCount.Count() + ", in1FieldCount= " + in1FieldCount.Count()
                           + ", in2FieldCount= " + in2FieldCount.Count());

                        Logger.Info("Message Type: " + CommonData.ADT);

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
                        ORUmsg.Add("Continuation Pointer", message2.GetValue("MSH.14"));
                        ORUmsg.Add("Accept Acknowledgement Type", message2.GetValue("MSH.15"));
                        ORUmsg.Add("Application Acknowledgement Type", message2.GetValue("MSH.16"));
                        ORUmsg.Add("Country Code", message2.GetValue("MSH.17"));
                        ORUmsg.Add("Character Set", message2.GetValue("MSH.18"));
                        ORUmsg.Add("Principal Language of Message", message2.GetValue("MSH.19"));


                        ORUmsg.Add("Event Type Code", message2.GetValue("EVN.1"));
                        ORUmsg.Add("Record Date/Time", message2.GetValue("EVN.2"));
                        ORUmsg.Add("DateTime Planned Event", message2.GetValue("EVN.3"));
                        ORUmsg.Add("Event Reason Code", message2.GetValue("EVN.4"));
                        ORUmsg.Add("Operator ID", message2.GetValue("EVN.5"));
                        ORUmsg.Add("Event occured", message2.GetValue("EVN.6"));


                        ORUmsg.Add("Patient ID", message2.GetValue("PID.1"));
                        ORUmsg.Add("Patient ID_ExternalID", message2.GetValue("PID.2"));
                        ORUmsg.Add("Patient ID_InternalID", message2.GetValue("PID.3"));
                        ORUmsg.Add("Patient ID_Alternate", message2.GetValue("PID.4"));
                        ORUmsg.Add("Patient Name", message2.GetValue("PID.5"));
                        ORUmsg.Add("Mother's Maiden Name", message2.GetValue("PID.6"));
                        ORUmsg.Add("Date of Birth", message2.GetValue("PID.7"));
                        ORUmsg.Add("Sex", message2.GetValue("PID.8"));
                        ORUmsg.Add("Patient Alias", message2.GetValue("PID.9"));
                        ORUmsg.Add("Race", message2.GetValue("PID.10"));
                        ORUmsg.Add("Patient Address", message2.GetValue("PID.11"));
                        ORUmsg.Add("County Code", message2.GetValue("PID.12"));
                        ORUmsg.Add("Phone Number - Home", message2.GetValue("PID.13"));
                        ORUmsg.Add("Phone Number - Business", message2.GetValue("PID.14"));
                        ORUmsg.Add("Primary Language", message2.GetValue("PID.15"));
                        ORUmsg.Add("Marital Status", message2.GetValue("PID.16"));
                        ORUmsg.Add("Religion", message2.GetValue("PID.17"));
                        ORUmsg.Add("Patient Account Number", message2.GetValue("PID.18"));
                        ORUmsg.Add("SSN Number - Patient", message2.GetValue("PID.19"));
                        ORUmsg.Add("Driver's License Number", message2.GetValue("PID.20"));
                        ORUmsg.Add("Mother's Identifier", message2.GetValue("PID.21"));
                        ORUmsg.Add("Ethnic Group", message2.GetValue("PID.22"));
                        ORUmsg.Add("Birth Place", message2.GetValue("PID.23"));
                        ORUmsg.Add("Multiple Birth Indicator", message2.GetValue("PID.24"));
                        ORUmsg.Add("Birth Order", message2.GetValue("PID.25"));
                        ORUmsg.Add("Citizenship", message2.GetValue("PID.26"));
                        ORUmsg.Add("Veterans Military Status", message2.GetValue("PID.27"));
                        ORUmsg.Add("Nationality Code", message2.GetValue("PID.28"));
                        ORUmsg.Add("Patient Death DateTime", message2.GetValue("PID.29"));


                        ORUmsg.Add("Set ID - Next of Kin", message2.GetValue("NK1.1"));
                        ORUmsg.Add("Name", message2.GetValue("NK1.2"));
                        ORUmsg.Add("Relationship", message2.GetValue("NK1.3"));
                        ORUmsg.Add("Address", message2.GetValue("NK1.4"));
                        ORUmsg.Add("Phone Number", message2.GetValue("NK1.5"));
                        ORUmsg.Add("Business Phone Number", message2.GetValue("NK1.6"));
                        ORUmsg.Add("Contact Role", message2.GetValue("NK1.7"));
                        ORUmsg.Add("Start Date", message2.GetValue("NK1.8"));
                        ORUmsg.Add("End Date", message2.GetValue("NK1.9"));
                        ORUmsg.Add("Next of Associated Parties Job Title", message2.GetValue("NK1.10"));
                        ORUmsg.Add("Next of Associated Parties Code", message2.GetValue("NK1.11"));
                        ORUmsg.Add("Next of Associated Parties Employee Number", message2.GetValue("NK1.12"));
                        ORUmsg.Add("Organization Name", message2.GetValue("NK1.13"));
                        ORUmsg.Add("Marital Status", message2.GetValue("NK1.14"));
                        ORUmsg.Add("Sex", message2.GetValue("NK1.15"));
                        ORUmsg.Add("Date of Birth", message2.GetValue("NK1.16"));
                        ORUmsg.Add("Living Dependency", message2.GetValue("NK1.17"));
                        ORUmsg.Add("Ambulatory Status", message2.GetValue("NK1.18"));
                        ORUmsg.Add("Citizenship", message2.GetValue("NK1.19"));
                        ORUmsg.Add("Primary Language", message2.GetValue("NK1.20"));
                        ORUmsg.Add("Living Arrangement", message2.GetValue("NK1.21"));
                        ORUmsg.Add("Publicity Indicator", message2.GetValue("NK1.22"));
                        ORUmsg.Add("Protection Indicator", message2.GetValue("NK1.23"));
                        ORUmsg.Add("Student Indicator", message2.GetValue("NK1.24"));
                        ORUmsg.Add("Religion", message2.GetValue("NK1.25"));
                        ORUmsg.Add("Mother's Maiden Name", message2.GetValue("NK1.26"));
                        ORUmsg.Add("Nationality Code", message2.GetValue("NK1.27"));
                        ORUmsg.Add("Ethnic Group", message2.GetValue("NK1.28"));
                        ORUmsg.Add("Contact Reason", message2.GetValue("NK1.29"));
                        ORUmsg.Add("Contact Person's Name", message2.GetValue("NK1.30"));
                        ORUmsg.Add("Contact Person's Telephone Number", message2.GetValue("NK1.31"));
                        ORUmsg.Add("Contact Person's Address", message2.GetValue("NK1.32"));
                        ORUmsg.Add("Associated Party's Identifiers", message2.GetValue("NK1.33"));
                        ORUmsg.Add("Job Status", message2.GetValue("NK1.34"));
                        ORUmsg.Add("Race", message2.GetValue("NK1.35"));
                        ORUmsg.Add("Handicap", message2.GetValue("NK1.36"));
                        ORUmsg.Add("Contact Person Social Security Number", message2.GetValue("NK1.37"));


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
                        ORUmsg.Add("Discharged to Location", message2.GetValue("PV1.37"));
                        ORUmsg.Add("Diet Type", message2.GetValue("PV1.38"));
                        ORUmsg.Add("Servicing Facility", message2.GetValue("PV1.39"));
                        ORUmsg.Add("Bed Status", message2.GetValue("PV1.40"));
                        ORUmsg.Add("Account Status", message2.GetValue("PV1.41"));
                        ORUmsg.Add("Pending Location", message2.GetValue("PV1.42"));
                        ORUmsg.Add("Prior Temporary Location", message2.GetValue("PV1.43"));
                        ORUmsg.Add("Admit DateTime", message2.GetValue("PV1.44"));
                        ORUmsg.Add("Discharge DateTime", message2.GetValue("PV1.45"));
                        ORUmsg.Add("Current Patient Balance", message2.GetValue("PV1.46"));
                        ORUmsg.Add("Total Charges", message2.GetValue("PV1.47"));
                        ORUmsg.Add("Total Adjustments", message2.GetValue("PV1.48"));
                        ORUmsg.Add("Total Payments", message2.GetValue("PV1.49"));
                        ORUmsg.Add("Alternate Visit ID", message2.GetValue("PV1.50"));
                        ORUmsg.Add("Visit Indicator", message2.GetValue("PV1.51"));
                        ORUmsg.Add("Other Healthcare Provider", message2.GetValue("PV1.52"));


                        ORUmsg.Add("Set ID - Guarantor", message2.GetValue("GT1.1"));
                        ORUmsg.Add("Guarantor Number", message2.GetValue("GT1.2"));
                        ORUmsg.Add("Guarantor Name", message2.GetValue("GT1.3"));
                        ORUmsg.Add("Guarantor Spouse Name", message2.GetValue("GT1.4"));
                        ORUmsg.Add("Guarantor Address", message2.GetValue("GT1.5"));
                        ORUmsg.Add("Guarantor PhoneNumber - Home", message2.GetValue("GT1.6"));
                        ORUmsg.Add("Guarantor PhoneNumber - Business", message2.GetValue("GT1.7"));
                        ORUmsg.Add("Guarantor DateTime of Birth", message2.GetValue("GT1.8"));
                        ORUmsg.Add("Guarantor Sex", message2.GetValue("GT1.9"));
                        ORUmsg.Add("Guarantor Type", message2.GetValue("GT1.10"));
                        ORUmsg.Add("Guarantor Relationship", message2.GetValue("GT1.11"));
                        ORUmsg.Add("Guarantor SSN", message2.GetValue("GT1.12"));
                        ORUmsg.Add("Guarantor Date - Begin", message2.GetValue("GT1.13"));
                        ORUmsg.Add("Guarantor Date - End", message2.GetValue("GT1.14"));
                        ORUmsg.Add("Guarantor Priority", message2.GetValue("GT1.15"));
                        ORUmsg.Add("Guarantor Employer Name", message2.GetValue("GT1.16"));
                        ORUmsg.Add("Guarantor Employer Address", message2.GetValue("GT1.17"));
                        ORUmsg.Add("Guarantor Employ Phone Number", message2.GetValue("GT1.18"));
                        ORUmsg.Add("Guarantor Employee ID Number", message2.GetValue("GT1.19"));
                        ORUmsg.Add("Guarantor Employment Status", message2.GetValue("GT1.20"));
                        ORUmsg.Add("Guarantor Organization", message2.GetValue("GT1.21"));


                        ORUmsg.Add("Set ID - Insurance", message2.GetValue("IN1.1"));
                        ORUmsg.Add("Insurance Plan ID", message2.GetValue("IN1.2"));
                        ORUmsg.Add("Insurance Company ID", message2.GetValue("IN1.3"));
                        ORUmsg.Add("Insurance Company Name", message2.GetValue("IN1.4"));
                        ORUmsg.Add("Insurance Company Address", message2.GetValue("IN1.5"));
                        ORUmsg.Add("Insurance Company Contact Papers", message2.GetValue("IN1.6"));
                        ORUmsg.Add("Insurance Company Phone Number", message2.GetValue("IN1.7"));
                        ORUmsg.Add("Group Number", message2.GetValue("IN1.8"));
                        ORUmsg.Add("Group Name", message2.GetValue("IN1.9"));
                        ORUmsg.Add("Insured's Group Employer ID", message2.GetValue("IN1.10"));
                        ORUmsg.Add("Insured's Group Employer Name", message2.GetValue("IN1.11"));
                        ORUmsg.Add("Plan Effective Date", message2.GetValue("IN1.12"));
                        ORUmsg.Add("Plan Expiration Date", message2.GetValue("IN1.13"));
                        ORUmsg.Add("Authorization Information", message2.GetValue("IN1.14"));
                        ORUmsg.Add("Plan Type", message2.GetValue("IN1.15"));
                        ORUmsg.Add("Name of Insured", message2.GetValue("IN1.16"));
                        ORUmsg.Add("Insured's Relationship to Patient", message2.GetValue("IN1.17"));
                        ORUmsg.Add("Insured's Date of Birth", message2.GetValue("IN1.18"));
                        ORUmsg.Add("Insured's Address", message2.GetValue("IN1.19"));
                        ORUmsg.Add("Assignment of Benefits", message2.GetValue("IN1.20"));
                        ORUmsg.Add("Coordination of Benefits", message2.GetValue("IN1.21"));
                        ORUmsg.Add("Coordination of Benefits Priority", message2.GetValue("IN1.22"));
                        ORUmsg.Add("Notice of Admission Code", message2.GetValue("IN1.23"));
                        ORUmsg.Add("Notice of Admission Date", message2.GetValue("IN1.24"));
                        ORUmsg.Add("Rpt of Eligibility Code", message2.GetValue("IN1.25"));
                        ORUmsg.Add("Rpt of Eligibility Date", message2.GetValue("IN1.26"));
                        ORUmsg.Add("Release Information Code", message2.GetValue("IN1.27"));
                        ORUmsg.Add("Pre-Admit Cert", message2.GetValue("IN1.28"));
                        ORUmsg.Add("Verification DateTime", message2.GetValue("IN1.29"));
                        ORUmsg.Add("Verification By", message2.GetValue("IN1.30"));
                        ORUmsg.Add("Type of Agreement Code", message2.GetValue("IN1.31"));
                        ORUmsg.Add("Billing Status", message2.GetValue("IN1.32"));
                        ORUmsg.Add("Lifetime Reserve Days", message2.GetValue("IN1.33"));
                        ORUmsg.Add("Delay before lifetime reserve days", message2.GetValue("IN1.34"));
                        ORUmsg.Add("Company Plan Code", message2.GetValue("IN1.35"));
                        ORUmsg.Add("Policy Number", message2.GetValue("IN1.36"));
                        ORUmsg.Add("Policy Deductible", message2.GetValue("IN1.37"));
                        ORUmsg.Add("Policy Limit - Amount", message2.GetValue("IN1.38"));
                        ORUmsg.Add("Policy Limit - Days", message2.GetValue("IN1.39"));
                        ORUmsg.Add("Room Rate - Semi Private", message2.GetValue("IN1.40"));
                        ORUmsg.Add("Room Rate - Private", message2.GetValue("IN1.41"));
                        ORUmsg.Add("Insured's Employment Status", message2.GetValue("IN1.42"));
                        ORUmsg.Add("Insured's Sex", message2.GetValue("IN1.43"));
                        ORUmsg.Add("Insured's Employer Address", message2.GetValue("IN1.44"));
                        ORUmsg.Add("Verification Status", message2.GetValue("IN1.45"));
                        ORUmsg.Add("Prior Insurance Plan ID", message2.GetValue("IN1.46"));
                        ORUmsg.Add("Coverage Type", message2.GetValue("IN1.47"));
                        ORUmsg.Add("Handicap", message2.GetValue("IN1.48"));
                        ORUmsg.Add("Insured's ID Number", message2.GetValue("IN1.49"));


                        ORUmsg.Add("Insured's Employee ID", message2.GetValue("IN2.1"));
                        ORUmsg.Add("Insured's Social Security Number", message2.GetValue("IN2.2"));
                        ORUmsg.Add("Insured's Employer Name", message2.GetValue("IN2.3"));
                        ORUmsg.Add("Employer Information Data", message2.GetValue("IN2.4"));
                        ORUmsg.Add("Mail Claim Party", message2.GetValue("IN2.5"));
                        ORUmsg.Add("Medicare Health Ins Card Number", message2.GetValue("IN2.6"));
                        ORUmsg.Add("Medicaid Case Name", message2.GetValue("IN2.7"));
                        ORUmsg.Add("Medicaid Case Number", message2.GetValue("IN2.8"));
                        ORUmsg.Add("Campus Sponsor Name", message2.GetValue("IN2.9"));
                        ORUmsg.Add("Campus ID Number", message2.GetValue("IN2.10"));
                        ORUmsg.Add("Dependent of Campus Recipient", message2.GetValue("IN2.11"));
                        ORUmsg.Add("Campus Organization", message2.GetValue("IN2.12"));
                        ORUmsg.Add("Campus Station", message2.GetValue("IN2.13"));
                        ORUmsg.Add("Campus Service", message2.GetValue("IN2.14"));
                        ORUmsg.Add("Campus Rank", message2.GetValue("IN2.15"));
                        ORUmsg.Add("Campus Status", message2.GetValue("IN2.16"));
                        ORUmsg.Add("Campus Retire Date", message2.GetValue("IN2.17"));
                        ORUmsg.Add("Campus Non-Avail Cert on File", message2.GetValue("IN2.18"));
                        ORUmsg.Add("Baby Coverage", message2.GetValue("IN2.19"));
                        ORUmsg.Add("Combile Baby Bill", message2.GetValue("IN2.20"));
                        ORUmsg.Add("Blood Deductible", message2.GetValue("IN2.21"));
                        ORUmsg.Add("Special Coverage Approval Name", message2.GetValue("IN2.22"));
                        ORUmsg.Add("Special Coverage Approval Title", message2.GetValue("IN2.23"));
                        ORUmsg.Add("Non-Covered Insurance Code", message2.GetValue("IN2.24"));
                        ORUmsg.Add("Payor ID", message2.GetValue("IN2.25"));
                        ORUmsg.Add("Payor Subcriber ID", message2.GetValue("IN2.26"));
                        ORUmsg.Add("Eligibility Source", message2.GetValue("IN2.27"));
                        ORUmsg.Add("Room Coverage Type", message2.GetValue("IN2.28"));
                        ORUmsg.Add("Policy Type", message2.GetValue("IN2.29"));
                        ORUmsg.Add("Daily Deductible", message2.GetValue("IN2.30"));
                        ORUmsg.Add("Living Dependency", message2.GetValue("IN2.31"));
                        ORUmsg.Add("Ambulatory Status", message2.GetValue("IN2.32"));
                        ORUmsg.Add("Citizenship", message2.GetValue("IN2.33"));
                        ORUmsg.Add("Primary Language", message2.GetValue("IN2.34"));
                        ORUmsg.Add("Living Arrangement", message2.GetValue("IN2.35"));
                        ORUmsg.Add("Publicity Indicator", message2.GetValue("IN2.36"));
                        ORUmsg.Add("Protection Indicator", message2.GetValue("IN2.37"));
                        ORUmsg.Add("Student Indicator", message2.GetValue("IN2.38"));
                        ORUmsg.Add("Religion", message2.GetValue("IN2.39"));
                        ORUmsg.Add("Mother's Maiden Name", message2.GetValue("IN2.40"));
                        ORUmsg.Add("Nationality Code", message2.GetValue("IN2.41"));
                        ORUmsg.Add("Ethnic Group", message2.GetValue("IN2.42"));
                        ORUmsg.Add("Marital Status", message2.GetValue("IN2.43"));
                        ORUmsg.Add("Employment Start Date", message2.GetValue("IN2.44"));
                        ORUmsg.Add("Employment Stop Date", message2.GetValue("IN2.45"));
                        ORUmsg.Add("Job Title", message2.GetValue("IN2.46"));
                        ORUmsg.Add("Job Code", message2.GetValue("IN2.47"));
                        ORUmsg.Add("Job Status", message2.GetValue("IN2.48"));
                        ORUmsg.Add("Employer Contact Person Name", message2.GetValue("IN2.49"));
                        ORUmsg.Add("Employer Contact Person Phone Number", message2.GetValue("IN2.50"));
                        ORUmsg.Add("Employer Contact Reason", message2.GetValue("IN2.51"));
                        ORUmsg.Add("Insured's Contact Person's Name", message2.GetValue("IN2.52"));
                        ORUmsg.Add("Insured's Contact Person Telephone Number", message2.GetValue("IN2.53"));
                        ORUmsg.Add("Insured's Contact Person Reason", message2.GetValue("IN2.54"));
                        ORUmsg.Add("Relationship to The Patient Start Date", message2.GetValue("IN2.55"));
                        ORUmsg.Add("Relationship to The Patient Stop Date", message2.GetValue("IN2.56"));
                        ORUmsg.Add("Insurance Co. Contact Reason", message2.GetValue("IN2.57"));
                        ORUmsg.Add("Insurance Co. Phone Number", message2.GetValue("IN2.58"));
                        ORUmsg.Add("Policy Scope", message2.GetValue("IN2.59"));
                        ORUmsg.Add("Policy Source", message2.GetValue("IN2.60"));
                        ORUmsg.Add("Patient Member Number", message2.GetValue("IN2.61"));
                        ORUmsg.Add("Gurantor's Relationship To Insured", message2.GetValue("IN2.62"));
                        ORUmsg.Add("Insured's Telephone Number - Home", message2.GetValue("IN2.63"));
                        ORUmsg.Add("Insured's Employer Telephone Number", message2.GetValue("IN2.64"));

                        string ORUjson = MyDictionaryToJson(ORUmsg);
                        Logger.Info("For " + CommonData.ADT + ", Generated json= " + ORUjson);

                    }
                    else if (message2.GetValue("MSH.9").Contains(CommonData.ORM))
                    {
                        //messageType: ORM
                        Logger.Info("Message Type: " + CommonData.ORM);

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


                        ORUmsg.Add("PID", message2.GetValue("PID.1"));
                        ORUmsg.Add("Patient ID", message2.GetValue("PID.2"));
                        ORUmsg.Add("Patient Identifier List", message2.GetValue("PID.3"));
                        ORUmsg.Add("Patient ID_Alternate", message2.GetValue("PID.4"));
                        //ORUmsg.Add("Patient ID_Alternate", message2.GetValue("PID.5"));
                        ORUmsg.Add("Patient Name", message2.GetValue("PID.5"));
                        ORUmsg.Add("Mother's Maiden Name", message2.GetValue("PID.6"));
                        ORUmsg.Add("Date of Birth", message2.GetValue("PID.7"));
                        ORUmsg.Add("Sex", message2.GetValue("PID.8"));
                        ORUmsg.Add("Patient Alias", message2.GetValue("PID.9"));
                        ORUmsg.Add("Race", message2.GetValue("PID.10"));
                        ORUmsg.Add("Patient Address", message2.GetValue("PID.11"));
                        //ORUmsg.Add("County Code", message2.GetValue("PID.13"));
                        //ORUmsg.Add("Phone Number - Home", message2.GetValue("PID.13"));
                        //ORUmsg.Add("Phone Number - Business", message2.GetValue("PID.14"));
                        //ORUmsg.Add("Primary Language", message2.GetValue("PID.15"));
                        //ORUmsg.Add("Marital Status", message2.GetValue("PID.16"));
                        //ORUmsg.Add("Religion", message2.GetValue("PID.17"));
                        //ORUmsg.Add("Patient Account Number", message2.GetValue("PID.18"));


                        ORUmsg.Add("Set ID - PV1", message2.GetValue("PV1.1"));
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
                        //ORUmsg.Add("Financial Class", message2.GetValue("PV1.20"));
                        //ORUmsg.Add("Charge Price Indicator", message2.GetValue("PV1.21"));
                        //ORUmsg.Add("Courtesy Code", message2.GetValue("PV1.22"));
                        //ORUmsg.Add("Credit Rating", message2.GetValue("PV1.23"));
                        //ORUmsg.Add("Contract Code", message2.GetValue("PV1.24"));
                        //ORUmsg.Add("Contract Effective Date", message2.GetValue("PV1.25"));
                        //ORUmsg.Add("Contract Amount", message2.GetValue("PV1.26"));
                        //ORUmsg.Add("Contract Period", message2.GetValue("PV1.27"));
                        //ORUmsg.Add("Interest Code", message2.GetValue("PV1.28"));
                        //ORUmsg.Add("Transfer to Bad Debt Code", message2.GetValue("PV1.29"));
                        //ORUmsg.Add("Transfer to Bad Debt Date", message2.GetValue("PV1.30"));
                        //ORUmsg.Add("Bad Debt Agency Code", message2.GetValue("PV1.31"));
                        //ORUmsg.Add("Bad Debt Transfer Amount", message2.GetValue("PV1.32"));
                        //ORUmsg.Add("Bad Debt Recovery Amount", message2.GetValue("PV1.33"));
                        //ORUmsg.Add("Delete Account Indicator", message2.GetValue("PV1.34"));
                        //ORUmsg.Add("Delete Account Date", message2.GetValue("PV1.35"));
                        //ORUmsg.Add("Discharge Disposition", message2.GetValue("PV1.36"));
                        //ORUmsg.Add("Discharged Location", message2.GetValue("PV1.37"));
                        //ORUmsg.Add("Diet Type", message2.GetValue("PV1.38"));
                        //ORUmsg.Add("Servicing Facility", message2.GetValue("PV1.39"));
                        //ORUmsg.Add("Bed Status", message2.GetValue("PV1.40"));
                        //ORUmsg.Add("Account Status", message2.GetValue("PV1.41"));
                        //ORUmsg.Add("Pending Location", message2.GetValue("PV1.42"));
                        //ORUmsg.Add("Prior Temporary Location", message2.GetValue("PV1.43"));
                        //ORUmsg.Add("Admit DateTime", message2.GetValue("PV1.44"));
                        //ORUmsg.Add("Discharge DateTime", message2.GetValue("PV1.45"));
                        //ORUmsg.Add("Current Patient Balance", message2.GetValue("PV1.46"));


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
                        ORUmsg.Add("Verified By", message2.GetValue("ORC.11"));
                        ORUmsg.Add("Ordering Provider", message2.GetValue("ORC.12"));
                        ORUmsg.Add("Enterer's Location", message2.GetValue("ORC.13"));
                        ORUmsg.Add("Call Back Phone Number", message2.GetValue("ORC.14"));
                        ORUmsg.Add("Order Effective DateTime", message2.GetValue("ORC.15"));
                        ORUmsg.Add("Order Control Code Reason", message2.GetValue("ORC.16"));
                        ORUmsg.Add("Entering Organization", message2.GetValue("ORC.17"));
                        ORUmsg.Add("Entering Device", message2.GetValue("ORC.18"));
                        ORUmsg.Add("Action By", message2.GetValue("ORC.19"));
                        ORUmsg.Add("Advanced Beneficiary Notice Code", message2.GetValue("ORC.20"));
                        ORUmsg.Add("Ordering Facility Name", message2.GetValue("ORC.21"));
                        ORUmsg.Add("Ordering Facility Address", message2.GetValue("ORC.22"));
                        ORUmsg.Add("Ordering Facility Phone Number", message2.GetValue("ORC.23"));
                        ORUmsg.Add("Ordering Provider Address", message2.GetValue("ORC.24"));


                        ORUmsg.Add("Set ID-OBR", message2.GetValue("OBR.1"));
                        ORUmsg.Add("Placer Order Number", message2.GetValue("OBR.2"));
                        ORUmsg.Add("Filler Order Number", message2.GetValue("OBR.3"));
                        ORUmsg.Add("Universal Service ID", message2.GetValue("OBR.4"));
                        ORUmsg.Add("Priority-OBR", message2.GetValue("OBR.5"));
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
                        ORUmsg.Add("QuantityTiming", message2.GetValue("OBR.27"));
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
                        ORUmsg.Add("Transport Logistics of Collected Sample", message2.GetValue("OBR.38"));
                        ORUmsg.Add("Collector's Comment", message2.GetValue("OBR.39"));
                        ORUmsg.Add("Transport Arrangement Responsibility", message2.GetValue("OBR.40"));
                        ORUmsg.Add("Transport Arranged", message2.GetValue("OBR.41"));
                        ORUmsg.Add("Escort Required", message2.GetValue("OBR.42"));
                        ORUmsg.Add("Planned Patient Transport Comment", message2.GetValue("OBR.43"));
                        ORUmsg.Add("Procedure Code", message2.GetValue("OBR.44"));
                        ORUmsg.Add("Procedure Code Modifier", message2.GetValue("OBR.45"));

                        string ORUjson = MyDictionaryToJson(ORUmsg);
                        Logger.Info("For " + CommonData.ORM + ", Generated json= " + ORUjson);

                    }
                    else if (message2.GetValue("MSH.9").Contains(CommonData.ACK))
                    {
                        Logger.Info("Message Type: " + CommonData.ACK);
                    }



                }
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at HL7_JSON. Message: " + ex.Message);
            }

        }


        string MyDictionaryToJson(Dictionary<string, string> dict)
        {
            try
            {
                Logger.Info("At MyDictionaryToJson..");
                var entries = dict.Select(d =>
                    string.Format("\"{0}\": \"{1}\"", d.Key, string.Join(",", d.Value)));
                return "{" + string.Join(",", entries) + "}";
            }
            catch (Exception e)
            {
                Logger.Error("Exception at MyDictionaryToJson. Message: " + e);
                return "";
            }
        }
    }
}
