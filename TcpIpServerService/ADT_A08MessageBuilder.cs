using HelperHL7;
using NHapi.Model.V23.Message;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpIpServerService
{
    internal class ADT_A08MessageBuilder
    {
        Logger Logger = LogManager.GetCurrentClassLogger();
        private ADT_A08 _adtMessage;

        /*You can pass in a domain or data transfer object as a parameter
        when integrating with data from your application here
        I will leave that to you to explore on your own
        Using fictional data here for illustration*/

        public ADT_A08 BuildA08NEW(HL7Model aDTMessageModel)
        {
            try
            {
                Logger.Info("At BuildA08NEW.");
                var currentDateTimeString = GetCurrentTimeStamp();
                _adtMessage = new ADT_A08();

                CreateMshSegmentNEW(currentDateTimeString, aDTMessageModel);
                CreateEvnSegmentNEW(currentDateTimeString, aDTMessageModel);
                CreatePidSegmentNEW(aDTMessageModel);

                CreateNk1SegmentNEW(aDTMessageModel);

                CreatePv1SegmentNEW(aDTMessageModel);
                CreateGT1SegmentNEW(aDTMessageModel);
                CreateDg1SegmentNEW(aDTMessageModel);



                CreateIn1SegmentNEW(aDTMessageModel);
                CreateIn2SegmentNEW(aDTMessageModel);
                Logger.Info("At BuildA08NEW returning null");
                //return _adtMessage;
                return null;
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at BuildA08NEW. Message: " + ex.Message);
                return _adtMessage;

            }
        }

        public static void WriteLogA08(string LogMessage)
        {
            string path = @"C:\HL7\HL7MSGA08" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".hl7";
            using (var file = new StreamWriter(path, true))
            {
                file.WriteLine(LogMessage + "\n ");
                file.Close();
            }
        }

        private void CreateMshSegmentNEW(string currentDateTimeString, HL7Model aDTMessageModel)
        {
            Logger.Info("At CreateMshSegmentNEW STEP1.");
            MSHModel MSHModel = new MSHModel();
            MSHModel.SendingApplication = aDTMessageModel.SendingApplication;
            MSHModel.SendingFacility = aDTMessageModel.SendingFacility;
            MSHModel.ReceivingApplication = aDTMessageModel.ReceivingApplication;
            MSHModel.ReceivingFacility = "";
            MSHModel.DateTimeofMessage = DateTime.Now;
            MSHModel.Security = aDTMessageModel.Security;

            //MessageType
            MSHModel.messagetype = "ADT";
            MSHModel.triggerevent = "A08";
            MSHModel.MessageType = MSHModel.messagetype + "^" + MSHModel.triggerevent;

            MSHModel.MessageControlID = int.Parse(aDTMessageModel.MessageControlID);
            MSHModel.ProcessingID = int.Parse(aDTMessageModel.ProcessingID);
            MSHModel.VersionID = aDTMessageModel.VersionID;
            MSHModel.SequenceNumber = aDTMessageModel.SequenceNumber;
            MSHModel.ContinuationPointer = aDTMessageModel.ContinuationPointer;
            MSHModel.AcceptAcknowledgmentType = aDTMessageModel.AcceptAcknowledgmentType;
            MSHModel.ApplicationAcknowledgmentType = aDTMessageModel.ApplicationAcknowledgmentType;
            MSHModel.CountryCode = "";
            MSHModel.CharacterSet = "ASCII";
            MSHModel.PrincipalLanguageofMessage = "HL7";
            Logger.Info("At CreateMshSegmentNEW STEP2.");


            string MSHMessage = "MSH|^~\\&|";
            MSHMessage = MSHMessage + MSHModel.SendingApplication + "|" + MSHModel.SendingFacility
            + "|" + MSHModel.ReceivingApplication + "|" + MSHModel.ReceivingFacility + "|" + MSHModel.DateTimeofMessage.ToString("yyyyMMddHHmmss") + "|" + MSHModel.Security
            + "|" + MSHModel.MessageType + "|" + MSHModel.MessageControlID + "|" + MSHModel.ProcessingID + "|" + MSHModel.VersionID
            + "|" + MSHModel.SequenceNumber + "|" + MSHModel.ContinuationPointer + "|" + MSHModel.AcceptAcknowledgmentType + "|" + MSHModel.ApplicationAcknowledgmentType
            + "|" + MSHModel.CountryCode + "|" + MSHModel.CharacterSet + "|" + MSHModel.PrincipalLanguageofMessage;

            Logger.Info("NEW MSHMessage: " + MSHMessage);
            WriteLogA08(MSHMessage);
        }

        private void CreateEvnSegmentNEW(string currentDateTimeString, HL7Model aDTMessageModel)
        {
            Logger.Info("At CreateEvnSegmentNEW STEP1.");
            EVNModel EVNModel = new EVNModel();
            EVNModel.EventTypeCode = "223";
            EVNModel.RecordedDateTime = DateTime.Now;
            EVNModel.DateTimePlannedEvent = DateTime.Now;
            EVNModel.EventReasonCode = "";//aDTMessageModel.EventReasonCode;//"";
            EVNModel.OperatorID = 2;// int.Parse(aDTMessageModel.OperatorID);
            EVNModel.EventOccured = DateTime.Now;
            EVNModel.EventFacility = "FAC2";//aDTMessageModel.EventFacility; //"FAC22";
            Logger.Info("At CreateEvnSegmentNEW STEP2.");

            string EVNMessage = "EVN|";
            EVNMessage = EVNMessage + EVNModel.EventTypeCode + "|" + EVNModel.RecordedDateTime.ToString("yyyyMMddHHmmss") + "|" + EVNModel.DateTimePlannedEvent.ToString("yyyyMMddHHmmss") + "|" + EVNModel.EventReasonCode + "|" + EVNModel.OperatorID + "|" + EVNModel.EventOccured.ToString("yyyyMMddHHmmss") + "|" + EVNModel.EventFacility;
            Logger.Info("EVNMessage: " + EVNMessage);
            WriteLogA08(EVNMessage);
        }

        private void CreatePidSegmentNEW(HL7Model aDTMessageModel)
        {
            Logger.Info("STATIC data At CreatePidSegmentNEW STEP1.");
            PIDModel PIDModel1 = new PIDModel();
            PIDModel1.SetID = 2;
            //PatientID_External 
            PIDModel1.External_ID = 2;
            PIDModel1.External_checkdigit = 2;
            PIDModel1.External_codeidentifyingthecheckdigitschemeemployed = "33";
            PIDModel1.External_assigningauthority = "Authotity2";
            PIDModel1.External_identifiertypecode = "code2";
            PIDModel1.External_assigningfacility = "Fac3";
            PIDModel1.PatientID_External = PIDModel1.External_ID + "^" + PIDModel1.External_checkdigit + "^" + PIDModel1.External_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel1.External_assigningauthority + "^" + PIDModel1.External_identifiertypecode + "^" + PIDModel1.External_assigningfacility;

            //PatientID_Internal
            PIDModel1.Internal_ID = 2;
            PIDModel1.Internal_checkdigit = 2;
            PIDModel1.Internal_codeidentifyingthecheckdigitschemeemployed = "33";
            PIDModel1.Internal_assigningauthority = "Authotity2";
            PIDModel1.Internal_identifiertypecode = "code2";
            PIDModel1.Internal_assigningfacility = "Fac3";
            PIDModel1.PatientID_Internal = PIDModel1.Internal_ID + "^" + PIDModel1.Internal_checkdigit + "^" + PIDModel1.Internal_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel1.Internal_assigningauthority + "^" + PIDModel1.Internal_identifiertypecode + "^" + PIDModel1.Internal_assigningfacility;

            //PatientID_Alternate
            PIDModel1.Alternate_ID = 2;
            PIDModel1.Alternate_checkdigit = 2;
            PIDModel1.Alternate_codeidentifyingthecheckdigitschemeemployed = "33";
            PIDModel1.Alternate_assigningauthority = "Authotity2";
            PIDModel1.Alternate_identifiertypecode = "code2";
            PIDModel1.Alternate_assigningfacility = "Fac3";
            PIDModel1.PatientID_Alternate = PIDModel1.Alternate_ID + "^" + PIDModel1.Alternate_checkdigit + "^" + PIDModel1.Alternate_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel1.Alternate_assigningauthority + "^" + PIDModel1.Alternate_identifiertypecode + "^" + PIDModel1.Alternate_assigningfacility;

            //PatientName
            PIDModel1.familyname = aDTMessageModel.familyname;
            PIDModel1.givenname = aDTMessageModel.givenname;
            PIDModel1.middleinitial = aDTMessageModel.middleinitial;
            PIDModel1.PatientName = PIDModel1.familyname + "^" + PIDModel1.givenname + "^" + PIDModel1.middleinitial;
            PIDModel1.MotherMaidenName = aDTMessageModel.MotherMaidenName;
            PIDModel1.DateofBirth = DateTime.Now;
            PIDModel1.Sex = aDTMessageModel.Sex;
            PIDModel1.PatientAlias = aDTMessageModel.PatientAlias;
            PIDModel1.Race = "";

            //PatientAddress
            PIDModel1.streetaddress = aDTMessageModel.streetaddress;
            PIDModel1.otherdesignation = aDTMessageModel.otherdesignation;
            PIDModel1.city = aDTMessageModel.city;
            PIDModel1.stateorprovince = aDTMessageModel.stateorprovince;
            PIDModel1.ziporpostalcode = aDTMessageModel.ziporpostalcode;
            PIDModel1.othergeographicdesignation = aDTMessageModel.othergeographicdesignation;
            PIDModel1.country = aDTMessageModel.country;
            PIDModel1.addresstype = aDTMessageModel.addresstype;
            PIDModel1.countrycode = aDTMessageModel.countrycode;
            PIDModel1.censustract = aDTMessageModel.censustract;
            PIDModel1.addressrepresentationcode = aDTMessageModel.addressrepresentationcode;
            PIDModel1.addressvalidityrange = aDTMessageModel.addressvalidityrange;

            PIDModel1.PatientAddress = PIDModel1.streetaddress + "^" + PIDModel1.otherdesignation + "^" + PIDModel1.city + "^" + PIDModel1.stateorprovince + "^" + PIDModel1.ziporpostalcode + "^" + PIDModel1.othergeographicdesignation + "^" + PIDModel1.country + "^" + PIDModel1.addresstype + "^" + PIDModel1.countrycode + "^" + PIDModel1.censustract + "^" + PIDModel1.addressrepresentationcode + "^" + PIDModel1.addressvalidityrange;

            PIDModel1.CountryCode = aDTMessageModel.countrycode;
            PIDModel1.PhoneNumber_Home = aDTMessageModel.PhoneNumber_Home;
            PIDModel1.PhoneNumber_Business = aDTMessageModel.PhoneNumber_Business;
            PIDModel1.PrimaryLanguage = aDTMessageModel.PrimaryLanguage;
            PIDModel1.MaritalStaus = aDTMessageModel.MaritalStaus;
            PIDModel1.Religion = aDTMessageModel.Religion;

            //PatientAccountNumber
            PIDModel1.PatientAccount_id = int.Parse(aDTMessageModel.PatientAccount_id);
            PIDModel1.checkdigit = int.Parse(aDTMessageModel.checkdigit);
            PIDModel1.codeidentifyingthecheckdigitschemeemployed = aDTMessageModel.codeidentifyingthecheckdigitschemeemployed;
            PIDModel1.PatientAccountNumber = PIDModel1.PatientAccount_id + "^" + PIDModel1.checkdigit + "^" + PIDModel1.codeidentifyingthecheckdigitschemeemployed;

            PIDModel1.SSNNumber_Patient = aDTMessageModel.SSNNumber_Patient;
            PIDModel1.DriverLicenseNumber = aDTMessageModel.DriverLicenseNumber;
            PIDModel1.IssuingState_province_country = aDTMessageModel.IssuingState_province_country;
            PIDModel1.DriverLicenseNumber_Patient = PIDModel1.DriverLicenseNumber + "^" + PIDModel1.IssuingState_province_country;

            Logger.Info("STATIC data At CreatePidSegmentNEW STEP2.");
            string pid_message1 = "PID|";
            pid_message1 = pid_message1 + PIDModel1.SetID + "|" + PIDModel1.PatientID_External + "|" + PIDModel1.PatientID_Internal + "|" + PIDModel1.PatientID_Alternate + "|" + PIDModel1.PatientName + "|" + PIDModel1.MotherMaidenName + "|" + PIDModel1.DateofBirth.ToString("yyyyMMddHHmmss")
                + "|" + PIDModel1.Sex + "|" + PIDModel1.PatientAlias + "|" + PIDModel1.Race + "|" + PIDModel1.PatientAddress + "|" + PIDModel1.CountryCode + "|" + PIDModel1.PhoneNumber_Home + "|" + PIDModel1.PhoneNumber_Business + "|" + PIDModel1.PrimaryLanguage + "|" + PIDModel1.MaritalStaus
                + "|" + PIDModel1.Religion + "|" + PIDModel1.PatientAccountNumber + "|" + PIDModel1.SSNNumber_Patient + "|" + PIDModel1.DriverLicenseNumber + "|" + PIDModel1.MotherIdentifier + "|" + PIDModel1.EthnicGroup + "|" + PIDModel1.BirthPlace + "|" + PIDModel1.MultipleBirthIndicator
                + "|" + PIDModel1.BirthOther + "|" + PIDModel1.Citizenship + "|" + PIDModel1.VeteransMilitaryStatus + "|" + PIDModel1.NationalityCode + "|" + PIDModel1.PatientDeathDateTime.ToString("yyyyMMddHHmmss") + "|" + PIDModel1.PatientDeathIndicator;

            Logger.Info("STATIC data PID_message: " + pid_message1);
            WriteLogA08(pid_message1);



            //#region
            //Logger.Info("-----------------------------------------");
            //Logger.Info("DYNAMIC data At CreatePidSegmentNEW STEP1");
            ////ORM_PIDModel PIDModel = new ORM_PIDModel();
            //PIDModel PIDModel = new PIDModel();
            //PIDModel.SetID = 2;
            ////PatientID_External 
            //PIDModel.External_ID = int.Parse(aDTMessageModel.External_ID);
            //PIDModel.External_checkdigit = int.Parse(aDTMessageModel.External_checkdigit);
            //PIDModel.External_codeidentifyingthecheckdigitschemeemployed = aDTMessageModel.External_codeidentifyingthecheckdigitschemeemployed;
            //PIDModel.External_assigningauthority = aDTMessageModel.External_assigningauthority;
            //PIDModel.External_identifiertypecode = aDTMessageModel.External_identifiertypecode;
            //PIDModel.External_assigningfacility = aDTMessageModel.External_assigningfacility;
            //PIDModel.PatientID_External = PIDModel.External_ID + "^" + PIDModel.External_checkdigit + "^" + PIDModel.External_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel.External_assigningauthority + "^" + PIDModel.External_identifiertypecode + "^" + PIDModel.External_assigningfacility;

            ////PatientID_Internal
            //PIDModel.Internal_ID = int.Parse(aDTMessageModel.Internal_ID);
            //PIDModel.Internal_checkdigit = int.Parse(aDTMessageModel.Internal_checkdigit);
            //PIDModel.Internal_codeidentifyingthecheckdigitschemeemployed = aDTMessageModel.Internal_codeidentifyingthecheckdigitschemeemployed;
            //PIDModel.Internal_assigningauthority = aDTMessageModel.Internal_assigningauthority;
            //PIDModel.Internal_identifiertypecode = aDTMessageModel.Internal_identifiertypecode;
            //PIDModel.Internal_assigningfacility = aDTMessageModel.Internal_assigningfacility;
            //PIDModel.PatientID_Internal = PIDModel.Internal_ID + "^" + PIDModel.Internal_checkdigit + "^" + PIDModel.Internal_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel.Internal_assigningauthority + "^" + PIDModel.Internal_identifiertypecode + "^" + PIDModel.Internal_assigningfacility;

            ////PatientID_Alternate
            //PIDModel.Alternate_ID = int.Parse(aDTMessageModel.Alternate_ID);
            //PIDModel.Alternate_checkdigit = int.Parse(aDTMessageModel.Alternate_checkdigit);
            //PIDModel.Alternate_codeidentifyingthecheckdigitschemeemployed = aDTMessageModel.Alternate_codeidentifyingthecheckdigitschemeemployed;
            //PIDModel.Alternate_assigningauthority = aDTMessageModel.Alternate_assigningauthority;
            //PIDModel.Alternate_identifiertypecode = aDTMessageModel.Alternate_identifiertypecode;
            //PIDModel.Alternate_assigningfacility = aDTMessageModel.Alternate_assigningfacility;
            //PIDModel.PatientID_Alternate = PIDModel.Alternate_ID + "^" + PIDModel.Alternate_checkdigit + "^" + PIDModel.Alternate_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel.Alternate_assigningauthority + "^" + PIDModel.Alternate_identifiertypecode + "^" + PIDModel.Alternate_assigningfacility;

            ////PatientName
            //PIDModel.familyname = aDTMessageModel.familyname;
            //PIDModel.givenname = aDTMessageModel.givenname;
            //PIDModel.middleinitial = aDTMessageModel.middleinitial;
            //PIDModel.PatientName = PIDModel.familyname + "^" + PIDModel.givenname + "^" + PIDModel.middleinitial;
            //PIDModel.MotherMaidenName = aDTMessageModel.MotherMaidenName;
            //PIDModel.DateofBirth = DateTime.Now;
            //PIDModel.Sex = aDTMessageModel.Sex;
            //PIDModel.PatientAlias = aDTMessageModel.PatientAlias;
            //PIDModel.Race = aDTMessageModel.Race;

            ////PatientAddress
            //PIDModel.streetaddress = aDTMessageModel.streetaddress;
            //PIDModel.otherdesignation = aDTMessageModel.otherdesignation;
            //PIDModel.city = aDTMessageModel.city;
            //PIDModel.stateorprovince = aDTMessageModel.stateorprovince;
            //PIDModel.ziporpostalcode = aDTMessageModel.ziporpostalcode;
            //PIDModel.othergeographicdesignation = aDTMessageModel.othergeographicdesignation;
            //PIDModel.country = aDTMessageModel.country;
            //PIDModel.addresstype = aDTMessageModel.addresstype;
            //PIDModel.countrycode = aDTMessageModel.countrycode;
            //PIDModel.censustract = aDTMessageModel.censustract;
            //PIDModel.addressrepresentationcode = aDTMessageModel.addressrepresentationcode;
            //PIDModel.addressvalidityrange = aDTMessageModel.addressvalidityrange;

            //PIDModel.PatientAddress = PIDModel.streetaddress + "^" + PIDModel.otherdesignation + "^" + PIDModel.city + "^" + PIDModel.stateorprovince + "^" + PIDModel.ziporpostalcode + "^" + PIDModel.othergeographicdesignation + "^" + PIDModel.country + "^" + PIDModel.addresstype + "^" + PIDModel.countrycode + "^" + PIDModel.censustract + "^" + PIDModel.addressrepresentationcode + "^" + PIDModel.addressvalidityrange;

            //PIDModel.CountryCode = aDTMessageModel.CountryCode;
            //PIDModel.PhoneNumber_Home = aDTMessageModel.PhoneNumber_Home;
            //PIDModel.PhoneNumber_Business = aDTMessageModel.PhoneNumber_Business;
            //PIDModel.PrimaryLanguage = aDTMessageModel.PrimaryLanguage;
            //PIDModel.MaritalStaus = aDTMessageModel.MaritalStaus;
            //PIDModel.Religion = aDTMessageModel.Religion;

            ////PatientAccountNumber
            //PIDModel.PatientAccount_id = int.Parse(aDTMessageModel.PatientAccount_id);
            //PIDModel.checkdigit = int.Parse(aDTMessageModel.checkdigit);
            //PIDModel.codeidentifyingthecheckdigitschemeemployed = aDTMessageModel.codeidentifyingthecheckdigitschemeemployed;
            //PIDModel.PatientAccountNumber = PIDModel.PatientAccount_id + "^" + PIDModel.checkdigit + "^" + PIDModel.codeidentifyingthecheckdigitschemeemployed;

            //PIDModel.SSNNumber_Patient = aDTMessageModel.SSNNumber_Patient;
            //PIDModel.DriverLicenseNumber = aDTMessageModel.DriverLicenseNumber;
            //PIDModel.IssuingState_province_country = aDTMessageModel.IssuingState_province_country;
            //PIDModel.DriverLicenseNumber_Patient = PIDModel.DriverLicenseNumber + "^" + PIDModel.IssuingState_province_country;
            //Logger.Info("DYNAMIC Data At CreatePidSegmentNEW STEP2");
            //string pid_message = "PID|";
            //pid_message = pid_message + PIDModel.SetID + "|" + PIDModel.PatientID_External + "|" + PIDModel.PatientID_Internal + "|" + PIDModel.PatientID_Alternate + "|" + PIDModel.PatientName + "|" + PIDModel.MotherMaidenName + "|" + PIDModel.DateofBirth.ToString("yyyyMMddHHmmss")
            //    + "|" + PIDModel.Sex + "|" + PIDModel.PatientAlias + "|" + PIDModel.Race + "|" + PIDModel.PatientAddress + "|" + PIDModel.CountryCode + "|" + PIDModel.PhoneNumber_Home + "|" + PIDModel.PhoneNumber_Business + "|" + PIDModel.PrimaryLanguage + "|" + PIDModel.MaritalStaus
            //    + "|" + PIDModel.Religion + "|" + PIDModel.PatientAccountNumber + "|" + PIDModel.SSNNumber_Patient + "|" + PIDModel.DriverLicenseNumber + "|" + PIDModel.MotherIdentifier + "|" + PIDModel.EthnicGroup + "|" + PIDModel.BirthPlace + "|" + PIDModel.MultipleBirthIndicator
            //    + "|" + PIDModel.BirthOther + "|" + PIDModel.Citizenship + "|" + PIDModel.VeteransMilitaryStatus + "|" + PIDModel.NationalityCode + "|" + PIDModel.PatientDeathDateTime.ToString("yyyyMMddHHmmss") + "|" + PIDModel.PatientDeathIndicator;

            //Logger.Info("DYNAMIC Data PID_message: " + pid_message);
            //WriteLogA08(pid_message);
            //#endregion
        }

        private void CreatePv1SegmentNEW(HL7Model aDTMessageModel)
        {
            Logger.Info("At CreatePv1SegmentNEW STEP1.");

            PV1Model PV1Model = new PV1Model();
            PV1Model.SetID = int.Parse(aDTMessageModel.PV1SetID);
            PV1Model.PatientClass = aDTMessageModel.PatientClass;

            PV1Model.PointOfCare = aDTMessageModel.PointOfCare;
            PV1Model.Room = aDTMessageModel.Room;
            PV1Model.Bed = aDTMessageModel.Bed;
            PV1Model.Facility = aDTMessageModel.Facility;
            PV1Model.LocationStatus = aDTMessageModel.LocationStatus;
            PV1Model.PersonLocationType = aDTMessageModel.PersonLocationType;
            PV1Model.Building = aDTMessageModel.Building;
            PV1Model.Floor = aDTMessageModel.Floor;
            PV1Model.LocationType = aDTMessageModel.LocationType;
            PV1Model.AssignedPatientLocation = PV1Model.PointOfCare + "^" + PV1Model.Room + "^" + PV1Model.Bed + "^" + PV1Model.Facility + "^" + PV1Model.LocationStatus + "^" + PV1Model.PersonLocationType + "^" + PV1Model.Building + "^" + PV1Model.Floor + "^" + PV1Model.LocationType;
            PV1Model.AdmissionType = aDTMessageModel.AdmissionType;

            PV1Model.PreadmitNumber = aDTMessageModel.PreadmitNumber;
            PV1Model.PriorPatientLocation = aDTMessageModel.PriorPatientLocation;
            PV1Model.AttendingDoctor = PV1Model.IDNumber + "^" + PV1Model.Family_LastName + "^" + PV1Model.GivenName;
            PV1Model.ReferringDoctor = PV1Model.IDNumber + "^" + PV1Model.Family_LastName + "^" + PV1Model.GivenName;

            PV1Model.ConsultingDoctor = aDTMessageModel.ConsultingDoctor;
            PV1Model.HospitalService = aDTMessageModel.HospitalService;
            PV1Model.TemporaryLocation = aDTMessageModel.TemporaryLocation;
            PV1Model.PreadmitTestIndicator = aDTMessageModel.PreadmitTestIndicator;
            PV1Model.Re_AdmissionIndicator = aDTMessageModel.Re_AdmissionIndicator;
            PV1Model.AdmitSource = aDTMessageModel.AdmitSource;
            PV1Model.AmbulatoryStatus = aDTMessageModel.AmbulatoryStatus;
            PV1Model.VIPIndicator = aDTMessageModel.VIPIndicator;

            PV1Model.AdmittingDoctor = aDTMessageModel.AdmittingDoctor;

            PV1Model.PatientType = aDTMessageModel.PatientType;
            PV1Model.VisitNumber = aDTMessageModel.VisitNumber;
            PV1Model.FinancialClass = aDTMessageModel.FinancialClass;
            PV1Model.ChargePriceIndicator = aDTMessageModel.ChargePriceIndicator;
            PV1Model.CourtesyCode = aDTMessageModel.CourtesyCode;
            PV1Model.CreditRating = aDTMessageModel.CreditRating;
            PV1Model.ContractCode = aDTMessageModel.ContractCode;
            PV1Model.ContractEffectiveDate = DateTime.Now;
            PV1Model.ContractAmount = int.Parse(aDTMessageModel.ContractAmount);
            PV1Model.ContractPeriod = aDTMessageModel.ContractPeriod;
            PV1Model.InterestCode = aDTMessageModel.InterestCode;
            PV1Model.TransfertoBadDebtCode = aDTMessageModel.TransfertoBadDebtCode;
            PV1Model.TransfertoBadDebtDate = DateTime.Now;
            PV1Model.BadDebtAgencyCode = aDTMessageModel.BadDebtAgencyCode;
            PV1Model.BadDebtTransferAmount = int.Parse(aDTMessageModel.BadDebtTransferAmount);
            PV1Model.BadDebtRecoveryAmount = int.Parse(aDTMessageModel.BadDebtRecoveryAmount);
            PV1Model.DeleteAccountIndicator = aDTMessageModel.DeleteAccountIndicator;
            PV1Model.DeleteAccountDate = DateTime.Now;
            PV1Model.DischargeDisposition = aDTMessageModel.DischargeDisposition;
            PV1Model.DischargedToLocation = aDTMessageModel.DischargedToLocation;
            PV1Model.DietType = aDTMessageModel.DietType;
            PV1Model.ServicingFacility = aDTMessageModel.ServicingFacility;
            PV1Model.BedStatus = aDTMessageModel.BedStatus;
            PV1Model.AccountStatus = aDTMessageModel.AccountStatus;
            PV1Model.PendingLocation = aDTMessageModel.PendingLocation;
            PV1Model.PriorTemporaryLocation = aDTMessageModel.PriorTemporaryLocation;
            PV1Model.AdmitDatetime = DateTime.Now;
            PV1Model.DischargeDatetime = DateTime.Now;
            PV1Model.CurrentPatientBalance = int.Parse(aDTMessageModel.CurrentPatientBalance);
            PV1Model.TotalCharges = int.Parse(aDTMessageModel.TotalCharges);
            PV1Model.TotalAdjustments = int.Parse(aDTMessageModel.TotalAdjustments);
            PV1Model.TotalPayments = int.Parse(aDTMessageModel.TotalPayments);
            PV1Model.AlternateVisitID = int.Parse(aDTMessageModel.AlternateVisitID);
            PV1Model.VisitIndicator = aDTMessageModel.VisitIndicator;
            PV1Model.OtherHealthcareProvider = aDTMessageModel.OtherHealthcareProvider;
            Logger.Info("At CreatePv1SegmentNEW STEP2.");

            string PV1_message = "PV1|";
            PV1_message = PV1_message + PV1Model.SetID + "|" + PV1Model.PatientClass + "|" + PV1Model.AssignedPatientLocation + "|" + PV1Model.AdmissionType + "|" + PV1Model.PreadmitNumber + "|" + PV1Model.PriorPatientLocation + "|" + PV1Model.AttendingDoctor
           + "|" + PV1Model.ReferringDoctor + "|" + PV1Model.ConsultingDoctor + "|" + PV1Model.HospitalService + "|" + PV1Model.TemporaryLocation
            + "|" + PV1Model.PreadmitTestIndicator + "|" + PV1Model.Re_AdmissionIndicator + "|" + PV1Model.AdmitSource
            + "|" + PV1Model.AmbulatoryStatus + "|" + PV1Model.VIPIndicator + "|" + PV1Model.AdmittingDoctor + "|" + PV1Model.PatientType + "|" + PV1Model.VisitNumber + "|" + PV1Model.FinancialClass
            + "|" + PV1Model.ChargePriceIndicator + "|" + PV1Model.CourtesyCode + "|" + PV1Model.CreditRating + "|" + PV1Model.ContractCode
            + "|" + PV1Model.ContractEffectiveDate.ToString("yyyyMMddHHmmss") + "|" + PV1Model.ContractAmount + "|" + PV1Model.ContractPeriod + "|" + PV1Model.InterestCode
            + "|" + PV1Model.TransfertoBadDebtCode + "|" + PV1Model.TransfertoBadDebtDate.ToString("yyyyMMddHHmmss") + "|" + PV1Model.BadDebtAgencyCode + "|" + PV1Model.BadDebtTransferAmount
            + "|" + PV1Model.BadDebtRecoveryAmount + "|" + PV1Model.DeleteAccountIndicator + "|" + PV1Model.DeleteAccountDate.ToString("yyyyMMddHHmmss") + "|" + PV1Model.DischargeDisposition
            + "|" + PV1Model.DischargedToLocation + "|" + PV1Model.DietType + "|" + PV1Model.ServicingFacility + "|" + PV1Model.BedStatus
            + "|" + PV1Model.AccountStatus + "|" + PV1Model.PendingLocation + "|" + PV1Model.PriorTemporaryLocation + "|" + PV1Model.AdmitDatetime.ToString("yyyyMMddHHmmss")
            + "|" + PV1Model.DischargeDatetime.ToString("yyyyMMddHHmmss") + "|" + PV1Model.CurrentPatientBalance + "|" + PV1Model.TotalCharges + "|" + PV1Model.TotalAdjustments
            + "|" + PV1Model.TotalPayments + "|" + PV1Model.AlternateVisitID + "|" + PV1Model.VisitIndicator + "|" + PV1Model.OtherHealthcareProvider;

            Logger.Info("PV1_message: " + PV1_message);
            WriteLogA08(PV1_message);
        }

        private void CreatePd1SegmentNEW(HL7Model aDTMessageModel)
        {

            /*PD1-1 Living Dependency(C - Small Children Dependent, M - Medical Supervision Required, O - Other, S - Spouse Dependent, U - Unknown) = M,PD1-2 Living Arrangement(A - Alone,F - Family,I - Institution,R - Relative,S - Spouse Only,U - Unknown) = U,PD1-3 Patient Primary Facility
            PD1-4 Patient Primary Care Provider Name & ID No.,PD1-5 Student Indicator(F - Full-time student,N - Not a student,P - Part-time student) = N
            PD1-6 Handicap,PD1-7 Living Will Code(F - Yes patient has a living will but it is not on file, I - No patient does not have a living will but information was provided, N - No patient does not have a living will and no information was provided, U - Unknown, Y - Yes patient has a living will) = Y
            PD1-8 Organ Donor Code(F - Yes patient is a documented donor but documentation is not on file,I - No patient is not a documented donor but information was provided,N - No patient has not agreed to be a donor,P - Patient leaves organ donation decision to a specific person,R - Patient leaves organ donation decision to relatives,U - Unknown,Y - Yes patient is a documented donor and documentation is on file) = U
            PD1-9 Separate Bill(N - No, Y - Yes) = N,PD1-10 Duplicate Patient,PD1-11 Publicity Code(F - Family only,N - No Publicity,O - Other,U - Unknown) = U
            PD1-12 Protection Indicator(N - No, Y - Yes) = N,PD1-13 Protection Indicator Effective Date = 20230125154633
            PD1-14 Place of Workship,PD1-15 Advance Directive Code(DNR - Do not resuscitate,N - No directive) = N
            PD1-16 Immunization Registry Status(A - Active,I - Inactive,L -  Lost to follow-up (cancel contract),M -  Moved or gone elsewhere (cancel contract),O - Other,P -  Permanently inactive (Do not reactivate or add new entries to the record), U - Unknown) = U
            PD1-17 Immunization Registry Status Effective Date = 20230125154633,PD1-18 Publicity Code  Effective Date = 20230125154633
            PD1-19 Military Branch,PD1-20 Military Rank/Grade,PD1-21 Military Status(ACT - Active duty,DEC - Deceased,RET - Retired) = ACT */
            Logger.Info("At CreatePd1SegmentNEW STEP1.");

            PD1Model pD1Model = new PD1Model();
            pD1Model.LivingDependency = aDTMessageModel.LivingDependency;//"U";
            pD1Model.LivingArrangement = aDTMessageModel.LivingArrangement;//"A";
            pD1Model.PatientPrimaryFacility = aDTMessageModel.PatientPrimaryFacility;//"Facility2";
            pD1Model.PatientPrimaryCareProviderName_ID_No = aDTMessageModel.PatientPrimaryCareProviderName_ID_No;//"2";
            pD1Model.StudentIndicator = aDTMessageModel.StudentIndicator;//"F";
            pD1Model.Handicap = aDTMessageModel.Handicap;//"";
            pD1Model.LivingWillCode = aDTMessageModel.LivingWillCode;//"I";
            pD1Model.OrganDonorCode = aDTMessageModel.OrganDonorCode;//"F";
            pD1Model.SeparateBill = aDTMessageModel.SeparateBill;//"N";
            pD1Model.DuplicatePatient = aDTMessageModel.DuplicatePatient;//"No";
            pD1Model.PublicityCode = aDTMessageModel.PublicityCode;//"U";
            pD1Model.ProtectionIndicator = aDTMessageModel.ProtectionIndicator;//"Y";
            pD1Model.ProtectionIndicatorEffectiveDate = DateTime.Now;
            pD1Model.PlaceofWorkship = aDTMessageModel.PlaceofWorkship;//"";
            pD1Model.AdvanceDirectiveCode = aDTMessageModel.AdvanceDirectiveCode;//"N";
            pD1Model.ImmunizationRegistryStatus = aDTMessageModel.ImmunizationRegistryStatus;//"A";
            pD1Model.ImmunizationRegistryStatusEffectiveDate = DateTime.Now;
            pD1Model.PublicityCodeEffectiveDate = DateTime.Now;
            pD1Model.MilitaryBranch = aDTMessageModel.MilitaryBranch;//"AUSA";
            pD1Model.MilitaryRank_Grade = aDTMessageModel.MilitaryRank_Grade;//"E1... E9";
            pD1Model.MilitaryStatus = aDTMessageModel.MilitaryStatus;//"RET";
            Logger.Info("At CreatePd1SegmentNEW STEP2.");

            string pd1_message = "PD1|";
            pd1_message = pd1_message + pD1Model.LivingDependency + "|" + pD1Model.LivingArrangement + "|" + pD1Model.PatientPrimaryFacility + "|" + pD1Model.PatientPrimaryCareProviderName_ID_No + "|" + pD1Model.StudentIndicator + "|" + pD1Model.Handicap + "|" + pD1Model.LivingWillCode
                 + "|" + pD1Model.OrganDonorCode + "|" + pD1Model.SeparateBill + "|" + pD1Model.DuplicatePatient + "|" + pD1Model.PublicityCode + "|" + pD1Model.ProtectionIndicator
                 + "|" + pD1Model.ProtectionIndicatorEffectiveDate.ToString("yyyyMMddHHmmss") + "|" + pD1Model.PlaceofWorkship + "|" + pD1Model.AdvanceDirectiveCode + "|" + pD1Model.ImmunizationRegistryStatus + "|" + pD1Model.ImmunizationRegistryStatusEffectiveDate.ToString("yyyyMMddHHmmss")
                 + "|" + pD1Model.PublicityCodeEffectiveDate.ToString("yyyyMMddHHmmss") + "|" + pD1Model.MilitaryBranch + "|" + pD1Model.MilitaryRank_Grade + "|" + pD1Model.MilitaryStatus;

            Logger.Info("pd1_message: " + pd1_message);
            WriteLogA08(pd1_message);

        }

        private void CreateGT1SegmentNEW(HL7Model aDTMessageModel)
        {
            Logger.Info("At CreateGT1SegmentNEW STEP1.");
            GT1Model gt1Model = new GT1Model();
            gt1Model.SetID = 263;//int.Parse(aDTMessageModel.GTSetID);
            gt1Model.GuarantorNumber = 515;//int.Parse(aDTMessageModel.GuarantorNumber);
            gt1Model.familyname = "FamName"; //aDTMessageModel.familyname;
            gt1Model.givenname = "given";// aDTMessageModel.givenname;
            gt1Model.middleinitial = "middle";// aDTMessageModel.middleinitial;
            gt1Model.GuarantorName = aDTMessageModel.familyname + "^" + aDTMessageModel.givenname + "^" + aDTMessageModel.middleinitial;
            gt1Model.GuarantorSpouseName = "spousename";//aDTMessageModel.GuarantorSpouseName;

            gt1Model.streetaddress = "st. 2"; //aDTMessageModel.GTstreetaddress;
            gt1Model.otherdesignation = "Duck"; //aDTMessageModel.GTotherdesignation;
            gt1Model.city = "kota"; //aDTMessageModel.GTcity;
            gt1Model.stateorprovince = "Province6"; //aDTMessageModel.GTstateorprovince;
            gt1Model.ziporpostalcode = "15426"; //aDTMessageModel.GTziporpostalcode;
            gt1Model.country = "Canada"; //aDTMessageModel.GTcountry;
            gt1Model.GuarantorAddress = aDTMessageModel.GTstreetaddress + "^" + aDTMessageModel.GTotherdesignation + "^" + aDTMessageModel.GTcity + "^" + aDTMessageModel.GTstateorprovince + "^" + aDTMessageModel.GTziporpostalcode + "^" + aDTMessageModel.GTcountry;

            gt1Model.GuarantorPhNumHome = "527444225"; //aDTMessageModel.GuarantorPhNumHome;
            gt1Model.GuarantorPhNumBusiness = "45815561"; //aDTMessageModel.GuarantorPhNumBusiness;
            gt1Model.GuarantorDateTimeofBirth = DateTime.Now;//aDTMessageModel.GuarantorDateTimeofBirth;
            gt1Model.GuarantorSex = "M"; //aDTMessageModel.GuarantorSex;
            gt1Model.GuarantorType = "";// aDTMessageModel.GuarantorType;
            gt1Model.GuarantorRelationship = "relation"; //aDTMessageModel.GuarantorRelationship;
            gt1Model.GuarantorSSN = "15425";// aDTMessageModel.GuarantorSSN;
            gt1Model.GuarantorDateBegin = DateTime.Now;//aDTMessageModel.GuarantorDateBegin;
            gt1Model.GuarantorDateEnd = DateTime.Now;//aDTMessageModel.GuarantorDateEnd;
            gt1Model.GuarantorPriority = "32";// aDTMessageModel.GuarantorPriority;

            gt1Model.GuarantorEmployerName = "EmployerName"; //aDTMessageModel.GuarantorEmployerName;

            gt1Model.streetaddress = "address st."; //aDTMessageModel.GT1streetaddress;
            gt1Model.otherdesignation = "place"; //aDTMessageModel.GT1otherdesignation;
            gt1Model.city = "canada"; //aDTMessageModel.GT1city;
            gt1Model.stateorprovince = "state3"; //aDTMessageModel.GT1stateorprovince;
            gt1Model.ziporpostalcode = "15122215";//aDTMessageModel.GT1ziporpostalcode;
            gt1Model.country = "canada"; //aDTMessageModel.GT1country;
            gt1Model.GuarantorEmployerAddress = aDTMessageModel.GT1streetaddress + "^" + aDTMessageModel.GT1otherdesignation + "^" + aDTMessageModel.GT1city + "^" + aDTMessageModel.GT1stateorprovince + "^" + aDTMessageModel.GT1ziporpostalcode + "^" + aDTMessageModel.GT1country;

            gt1Model.GuarantorEmployPhoneNumber = 63546351;//int.Parse(aDTMessageModel.GuarantorEmployPhoneNumber);
            gt1Model.GuarantorEmployeeIDNumber = "6354";//aDTMessageModel.GuarantorEmployeeIDNumber;
            gt1Model.GuarantorEmployementStatus = "PT";// aDTMessageModel.GuarantorEmployementStatus;
            gt1Model.GuarantorOrganization = "ORG2"; //aDTMessageModel.GuarantorOrganization;
            Logger.Info("At CreateGT1SegmentNEW STEP2.");

            string gt1_message = "GT1|";

            gt1_message = gt1_message + gt1Model.SetID + "|" + gt1Model.GuarantorNumber + "|" + gt1Model.GuarantorName + "|" + gt1Model.GuarantorSpouseName + "|" + gt1Model.GuarantorAddress + "|" + gt1Model.GuarantorPhNumHome + "|" + gt1Model.GuarantorPhNumBusiness
              + "|" + gt1Model.GuarantorDateTimeofBirth.ToString("yyyyMMddHHmmss") + "|" + gt1Model.GuarantorSex + "|" + gt1Model.GuarantorType + "|" + gt1Model.GuarantorRelationship + "|" + gt1Model.GuarantorSSN + "|" + gt1Model.GuarantorDateBegin.ToString("yyyyMMddHHmmss") + "|" + gt1Model.GuarantorDateEnd.ToString("yyyyMMddHHmmss")
              + "|" + gt1Model.GuarantorPriority + "|" + gt1Model.GuarantorEmployerName + "|" + gt1Model.GuarantorEmployerAddress + "|" + gt1Model.GuarantorEmployPhoneNumber + "|" + gt1Model.GuarantorEmployeeIDNumber + "|" + gt1Model.GuarantorEmployementStatus
              + "|" + gt1Model.GuarantorOrganization;
            Logger.Info("gt1_message: " + gt1_message);
            WriteLogA08(gt1_message);
        }

        private void CreateNk1SegmentNEW(HL7Model aDTMessageModel)
        {
            /*NK1-1 Set ID - NK1 = 1234,NK1-2 Name,NK1-3 Relationship,NK1-4 Address,NK1-5 Phone Number,NK1-6 Business Phone Number
            NK1-7 Contact Role,NK1-8 Start Date = 20230125161507,NK1-9 End Date = 20230125161507,NK1-10 Next of Kin/Associated Parties Job Title
            NK1-11 Next of Kin/Associated Parties Job Code/Class,NK1-12 Next of Kin/Associated Parties Employee Number
            NK1-13 Organization Name - NK1,NK1-14 Marital Status,NK1-15 Administrative Sex,NK1-16 Date/Time of Birth,NK1-17 Living Dependency
            NK1-18 Ambulatory Status,NK1-19 Citizenship,NK1-20 Primary Language,NK1-21 Living Arrangement,NK1-22 Publicity Code
            NK1-23 Protection Indicator,NK1-24 Student Indicator,NK1-25 Religion,NK1-26 Mother's Maiden Name,NK1-27 Nationality
            NK1-28 Ethnic Group,NK1-29 Contact Reason,NK1-30 Contact Person's Name,NK1-31 Contact Person's Telephone Number
            NK1-32 Contact Person's Address,NK1-33 Next of Kin\Associated Party's Identifiers,NK1-34 Job Status,NK1-35 Race,NK1-36 Handicap,
            NK1-37 Contact Person Social Secutity Number */
            Logger.Info("At CreateNk1SegmentNEW STEP1.");
            NK1Model nK1Model = new NK1Model();
            nK1Model.SetID = 511;//int.Parse(aDTMessageModel.NKSetID);//511;

            nK1Model.familyname = "NKfamilyname";//aDTMessageModel.NKfamilyname;

            nK1Model.givenname = "NKfamilyname";//aDTMessageModel.NKgivenname;

            nK1Model.Name = aDTMessageModel.NKfamilyname + "^" + aDTMessageModel.NKgivenname;
            nK1Model.Relationship = "CHD";//aDTMessageModel.NKRelationship;

            nK1Model.streetaddress = ""; //aDTMessageModel.NKstreetaddress;
            nK1Model.otherdesignation = ""; //aDTMessageModel.NKotherdesignation;
            nK1Model.city = ""; //aDTMessageModel.NKcity;
            nK1Model.stateorprovince = ""; // aDTMessageModel.NKstateorprovince;
            nK1Model.ziporpostalcode = ""; //aDTMessageModel.NKziporpostalcode;
            nK1Model.Address = aDTMessageModel.NKstreetaddress + "^" + aDTMessageModel.NKotherdesignation + "^" + aDTMessageModel.NKcity + "^" + aDTMessageModel.NKstateorprovince + "^" + aDTMessageModel.NKziporpostalcode;

            nK1Model.PhoneNumber = 27883518;//aDTMessageModel.PhoneNumber;
            nK1Model.BusinesPhoneNumber = 27883518;// aDTMessageModel.BusinesPhoneNumber;
            nK1Model.ContactRole = "C"; //aDTMessageModel.ContactRole;
            nK1Model.StartDate = DateTime.Now;
            nK1Model.EndDate = DateTime.Now;
            nK1Model.NextofKin_AssociatedPartiesJobTitle = "Job5"; //aDTMessageModel.NextofKin_AssociatedPartiesJobTitle;
            nK1Model.NextofKin_AssociatedPartiesJobCode_Class = "3";// aDTMessageModel.NextofKin_AssociatedPartiesJobCode_Class;

            nK1Model.NextofKin_AssociatedPartiesEmployeeNumber = "5684388";// aDTMessageModel.NextofKin_AssociatedPartiesEmployeeNumber;
            nK1Model.OrganizationName = "REFR";//aDTMessageModel.OrganizationName;
            nK1Model.MaritalStatus = "U";//aDTMessageModel.MaritalStatus;
            nK1Model.AdministrativeSex = "M";// aDTMessageModel.AdministrativeSex;
            nK1Model.Date_TimeofBirth = DateTime.Now;
            nK1Model.LivingDependency = "C";// aDTMessageModel.NKLivingDependency;
            nK1Model.AmbulatoryStatus = "A0";// aDTMessageModel.NKAmbulatoryStatus;
            nK1Model.Citizenship = "CAN"; //aDTMessageModel.NKCitizenship;
            nK1Model.PrimaryLanguage = "English";// aDTMessageModel.NKPrimaryLanguage;
            nK1Model.LivingArrangement = "A";// aDTMessageModel.NKLivingArrangement;
            nK1Model.PublicityCode = "F";//aDTMessageModel.NKPublicityCode;
            nK1Model.ProtectionIndicator = "N";//aDTMessageModel.NKProtectionIndicator;
            nK1Model.StudentIndicator = "P";// aDTMessageModel.NKStudentIndicator;
            nK1Model.Religion = "ABC";// aDTMessageModel.NKReligion;
            nK1Model.MothersMaidenName = "asiydbo ouabsd";// aDTMessageModel.MothersMaidenName;
            nK1Model.Nationality = "Canadian";// aDTMessageModel.Nationality;
            nK1Model.EthnicGroup = "H"; //aDTMessageModel.NKEthnicGroup;
            nK1Model.ContactReason = "Reasons"; //aDTMessageModel.ContactReason;
            nK1Model.ContactPersonName = "John mily"; //aDTMessageModel.ContactPersonName;
            nK1Model.ContactPersonTelephoneNumber = 51335156; //aDTMessageModel.ContactPersonTelephoneNumber;
            nK1Model.ContactPersonAddress = "Address";// aDTMessageModel.ContactPersonAddress;
            nK1Model.NextofKin_AssociatedPartyIdentifiers = ""; //aDTMessageModel.NextofKin_AssociatedPartyIdentifiers;
            nK1Model.JobStatus = "P";// aDTMessageModel.JobStatus;
            nK1Model.Race = "1002-5"; //aDTMessageModel.NKRace;
            nK1Model.Handicap = "";// aDTMessageModel.NKHandicap;
            nK1Model.ContactPersonSocialSecutityNumber = aDTMessageModel.ContactPersonSocialSecutityNumber;


            Logger.Info("At CreateNk1SegmentNEW STEP2.");

            string NK1Message = "NK1|";

            NK1Message = NK1Message + nK1Model.SetID + "|" + nK1Model.Name + "|" + nK1Model.Relationship + "|" + nK1Model.Address + "|" + nK1Model.PhoneNumber + "|" + nK1Model.BusinesPhoneNumber + "|" + nK1Model.ContactRole + "|" + nK1Model.StartDate.ToString("yyyyMMddHHmmss")
                     + "|" + nK1Model.EndDate.ToString("yyyyMMddHHmmss") + "|" + nK1Model.NextofKin_AssociatedPartiesJobTitle + "|" + nK1Model.NextofKin_AssociatedPartiesJobCode_Class + "|" + nK1Model.NextofKin_AssociatedPartiesEmployeeNumber + "|" + nK1Model.OrganizationName + "|" + nK1Model.MaritalStatus
                     + "|" + nK1Model.AdministrativeSex + "|" + nK1Model.Date_TimeofBirth.ToString("yyyyMMddHHmmss") + "|" + nK1Model.LivingDependency + "|" + nK1Model.AmbulatoryStatus + "|" + nK1Model.Citizenship + "|" + nK1Model.PrimaryLanguage + "|" + nK1Model.LivingArrangement
                     + "|" + nK1Model.PublicityCode + "|" + nK1Model.ProtectionIndicator + "|" + nK1Model.StudentIndicator + "|" + nK1Model.Religion + "|" + nK1Model.MothersMaidenName + "|" + nK1Model.Nationality + "|" + nK1Model.EthnicGroup
                      + "|" + nK1Model.ContactReason + "|" + nK1Model.ContactPersonName + "|" + nK1Model.ContactPersonTelephoneNumber + "|" + nK1Model.ContactPersonAddress + "|" + nK1Model.NextofKin_AssociatedPartyIdentifiers + "|" + nK1Model.JobStatus
                      + "|" + nK1Model.Race + "|" + nK1Model.Handicap + "|" + nK1Model.ContactPersonSocialSecutityNumber;


            Logger.Info("NK1Message: " + NK1Message);
            WriteLogA08(NK1Message);

        }

        private void CreateIn1SegmentNEW(HL7Model aDTMessageModel)
        {
            Logger.Info("At CreateIn1SegmentNEW STEP1.");
            IN1Model In1Model = new IN1Model();
            In1Model.SetID = 155;
            In1Model.InsurancePlanID = "MEDICARE";
            In1Model.InsuranceCompanyID = 545;
            In1Model.InsuranceCompanyAddress = "Unknown";
            In1Model.InsuranceCoContactPpers = "";
            In1Model.InsuranceCoPhoneNuber = "Canada";
            In1Model.GroupNumber = "551";
            In1Model.GroupName = "GRP2";
            In1Model.InsuredGroupEmployerID = "55";
            In1Model.InsuredGroupEmpName = "EmpName..";
            In1Model.PlanEffectiveDate = DateTime.Now;

            In1Model.PlanExpirationDate = DateTime.Now;
            In1Model.AuthorizationInformation = "Ref2";
            In1Model.PlanType = "type2";

            //NameOfInsured
            In1Model.familyName = "FamilyName";
            In1Model.givenName = "NameGiven";
            In1Model.middleInitialorName = "middleName";
            In1Model.NameOfInsured = In1Model.familyName + "^" + In1Model.givenName + "^" + In1Model.middleInitialorName;


            In1Model.InsuredRelationshipToPatient = "BRO";
            In1Model.InsuredDateOfBirth = DateTime.Now;

            //InsuredAddress
            In1Model.streetaddress = "St2.";
            In1Model.otherdesignation = "3";
            In1Model.city = "Franci";
            In1Model.stateorprovince = "state";
            In1Model.ziporpostalcode = "12521";
            In1Model.country = "Canada";
            In1Model.InsuredAddress = In1Model.streetaddress + "^" + In1Model.otherdesignation + "^" + In1Model.city + "^" + In1Model.stateorprovince + "^" + In1Model.ziporpostalcode + "^" + In1Model.country;

            In1Model.AssignmentOfBenefits = "2";
            In1Model.CoordinationOfBenefits = "CO";
            In1Model.CoordofBenPriority = "OK";
            In1Model.NoticeofAdmissionCode = "N";
            In1Model.NoticeofAdmissionDate = DateTime.Now;
            In1Model.ReptofEligibilityCode = "N";
            In1Model.ReptofEligibilityDate = DateTime.Now;
            In1Model.ReleaseInfoCode = "54542";
            In1Model.PreAdmitCert_PAC = "";
            In1Model.VerificationDateTime = DateTime.Now;
            In1Model.VerificationBy = "verifyBy";
            In1Model.TypeofAgreementCode = "S";
            In1Model.BillingStatus = "No";
            In1Model.LifeTimeReverseDays = "3";
            In1Model.DelayBeforeLifeTimeReverseDays = "1";
            In1Model.CompanyPlanCode = "AC";
            In1Model.PolicyNumber = "124";
            In1Model.PolicyDeductible = "C";
            In1Model.PolicyLimitAmount = "200000";
            In1Model.PolicyLimitDays = "3";
            In1Model.RoomRate_SemiPrivate = "1000";
            In1Model.RoomRate_Private = "3000";
            In1Model.InsuredEmploymentStatus = "PT";
            In1Model.InsuredSex = "M";

            //InsuredEmployerAddress
            In1Model.streetaddress = "ST03";
            In1Model.otherdesignation = "designation";
            In1Model.city = "stekls";
            In1Model.stateorprovince = "ottava";
            In1Model.ziporpostalcode = "122452";
            In1Model.InsuredEmployerAddress = In1Model.streetaddress + "^" + In1Model.otherdesignation + "^" + In1Model.city + "^" + In1Model.stateorprovince + "^" + In1Model.ziporpostalcode;

            In1Model.VerificationStatus = "State";
            In1Model.PriorInsurancePlanID = "55";
            In1Model.CoverageType = "B";
            In1Model.Handicap = "HANDICAP";
            In1Model.InsuredIDNumber = "1246";
            Logger.Info("At CreateIn1SegmentNEW STEP2.");

            string IN1Message = "IN1|";

            IN1Message = IN1Message + In1Model.SetID + "|" + In1Model.InsurancePlanID + "|" + In1Model.InsuranceCompanyID + "|" + In1Model.InsuranceCompanyName + "|" + In1Model.InsuranceCompanyAddress + "|" + In1Model.InsuranceCoContactPpers + "|" + In1Model.InsuranceCoPhoneNuber + "|" + In1Model.GroupNumber
                     + "|" + In1Model.GroupName + "|" + In1Model.InsuredGroupEmployerID + "|" + In1Model.InsuredGroupEmpName + "|" + In1Model.PlanEffectiveDate.ToString("yyyyMMddHHmmss") + "|" + In1Model.PlanExpirationDate.ToString("yyyyMMddHHmmss") + "|" + In1Model.AuthorizationInformation
                     + "|" + In1Model.PlanType + "|" + In1Model.NameOfInsured + "|" + In1Model.InsuredRelationshipToPatient + "|" + In1Model.InsuredDateOfBirth.ToString("yyyyMMddHHmmss") + "|" + In1Model.InsuredAddress + "|" + In1Model.AssignmentOfBenefits + "|" + In1Model.CoordinationOfBenefits
                     + "|" + In1Model.CoordofBenPriority + "|" + In1Model.NoticeofAdmissionCode + "|" + In1Model.NoticeofAdmissionDate.ToString("yyyyMMddHHmmss") + "|" + In1Model.ReptofEligibilityCode + "|" + In1Model.ReptofEligibilityDate.ToString("yyyyMMddHHmmss") + "|" + In1Model.ReleaseInfoCode + "|" + In1Model.PreAdmitCert_PAC
                      + "|" + In1Model.VerificationDateTime.ToString("yyyyMMddHHmmss") + "|" + In1Model.VerificationBy + "|" + In1Model.TypeofAgreementCode + "|" + In1Model.BillingStatus + "|" + In1Model.LifeTimeReverseDays + "|" + In1Model.DelayBeforeLifeTimeReverseDays
                      + "|" + In1Model.CompanyPlanCode + "|" + In1Model.PolicyNumber + "|" + In1Model.PolicyDeductible + "|" + In1Model.PolicyLimitAmount + "|" + In1Model.PolicyLimitDays + "|" + In1Model.RoomRate_SemiPrivate + "|" + In1Model.RoomRate_Private
                      + "|" + In1Model.InsuredEmploymentStatus + "|" + In1Model.InsuredSex + "|" + In1Model.InsuredEmployerAddress + "|" + In1Model.VerificationStatus + "|" + In1Model.PriorInsurancePlanID + "|" + In1Model.CoverageType
                      + "|" + In1Model.Handicap + "|" + In1Model.InsuredIDNumber;


            Logger.Info("IN1Message: " + IN1Message);

            WriteLogA08(IN1Message);
        }

        private void CreateIn2SegmentNEW(HL7Model aDTMessageModel)
        {
            Logger.Info("At CreateIn2SegmentNEW STEP1.");

            IN2Model In2Model = new IN2Model();
            In2Model.InsuredEmployeeID = 2;
            In2Model.InsuredSocialSecurityNumber = "3244";
            In2Model.InsuredEmployerName = "EmployerName";
            In2Model.EmployerInformationData = "Cartoon Ducks";
            In2Model.MailClaimParty = "E";
            In2Model.MedicareHealthInsCardNumber = "24353";
            In2Model.MedicaidCaseName = "2245441";
            In2Model.MedicaidCaseNumber = "55";

            In2Model.CampusSponsorName = "Sponser";
            In2Model.CampusIDNumber = "CAMP1";
            In2Model.DependentofCampusRecipient = "";
            In2Model.CampusOrganization = "Organizer";
            In2Model.CampusStation = "Station2";
            In2Model.CampusService = "USA";
            In2Model.CampusRank_Grade = "E1...E9";
            In2Model.CampusStatus = "ACT";


            In2Model.CampusRetireDate = DateTime.Now;
            In2Model.CampusIDNumber = "CAMP1";
            In2Model.CampusNonAvailCertonFile = "N";
            In2Model.BabyCoverage = "N";
            In2Model.CombineBabyBill = "Y";
            In2Model.BloodDeductile = "";
            In2Model.SpecialCoverageApprovalName = "approv";
            In2Model.SpecialCoverageApprovalTitle = "title";


            In2Model.NonCoveredInsuranceCode = "";
            In2Model.PayorID = "Pay12";
            In2Model.PayorSubscriberID = "Payor03";
            In2Model.EligibilitySource = "1";
            In2Model.RoomCoverageTypeAmount = "ICU";
            In2Model.PolicyTypeAmount = "2ANC";
            In2Model.DailyDeductible = "";
            In2Model.LivingDependency = "C";

            In2Model.AmbulatoryStatus = "A1";
            In2Model.Citizenship = "CAN";
            In2Model.PrimaryLanguage = "";
            In2Model.LivingArrangement = "F";
            In2Model.PublicityIndicator = "F";
            In2Model.ProtectionIndicator = "N";
            In2Model.StudentIndicator = "P";
            In2Model.Religion = "ABC";


            In2Model.MotherMaidenName = "MotherName";
            In2Model.NationalityCode = "142";
            In2Model.EthnicGroup = "H";
            In2Model.MaritalStatus = "A";
            In2Model.EmploymentStartDate = DateTime.Now;
            In2Model.EmploymentStopDate = DateTime.Now;
            In2Model.JobTitle = "Trainer";
            In2Model.JobCode_Class = "J2";

            In2Model.JobStatus = "O";
            In2Model.EmployerContactPersonName = "Name";
            In2Model.EmployerContactPersonPhoneNumber = "13651661";
            In2Model.EmployerContactReason = "reason to contact";
            In2Model.InsuredContactPersonName = "ContactNAME";
            In2Model.InsuredContactPersonTeleNumber = "56543834";
            In2Model.InsuredContactPersonReason = "";
            In2Model.RelationshipToPatientStartDate = DateTime.Now;
            In2Model.RelationshipToPatientStopDate = DateTime.Now;


            In2Model.InsuranceCoContactReason = "1";
            In2Model.InsuranceCoContactPhoneNumber = "154566421";
            In2Model.PolicyScope = "";
            In2Model.PolicySource = "Source";
            In2Model.PatientMemberNumber = "Member20";
            In2Model.GuarantorRelationshipToInsured = "ASC";
            In2Model.InsuredTelephoneNumber = "5151564";
            In2Model.InsuredEmployerTelephoneNumber = "5463686";
            Logger.Info("At CreateIn2SegmentNEW STEP2.");


            string IN2Message = "IN2|";

            IN2Message = IN2Message + In2Model.InsuredEmployeeID + "|" + In2Model.InsuredSocialSecurityNumber + "|" + In2Model.InsuredEmployerName + "|" + In2Model.EmployerInformationData + "|" + In2Model.MailClaimParty + "|" + In2Model.MedicareHealthInsCardNumber + "|" + In2Model.MedicaidCaseName + "|" + In2Model.MedicaidCaseNumber + "|" + In2Model.CampusSponsorName
                + "|" + In2Model.CampusIDNumber + "|" + In2Model.DependentofCampusRecipient + "|" + In2Model.CampusOrganization + "|" + In2Model.CampusStation + "|" + In2Model.CampusService + "|" + In2Model.CampusRank_Grade + "|" + In2Model.CampusStatus + "|" + In2Model.CampusRetireDate.ToString("yyyyMMddHHmmss") + "|" + In2Model.CampusNonAvailCertonFile
            + "|" + In2Model.BabyCoverage + "|" + In2Model.CombineBabyBill + "|" + In2Model.BloodDeductile + "|" + In2Model.SpecialCoverageApprovalName + "|" + In2Model.SpecialCoverageApprovalTitle + "|" + In2Model.NonCoveredInsuranceCode + "|" + In2Model.PayorID + "|" + In2Model.PayorSubscriberID + "|" + In2Model.EligibilitySource + "|" + In2Model.RoomCoverageTypeAmount
            + "|" + In2Model.PolicyTypeAmount + "|" + In2Model.DailyDeductible + "|" + In2Model.LivingDependency + "|" + In2Model.AmbulatoryStatus + "|" + In2Model.Citizenship + "|" + In2Model.PrimaryLanguage + "|" + In2Model.LivingArrangement + "|" + In2Model.PublicityIndicator + "|" + In2Model.ProtectionIndicator + "|" + In2Model.StudentIndicator + "|" + In2Model.Religion
            + "|" + In2Model.MotherMaidenName + "|" + In2Model.NationalityCode + "|" + In2Model.EthnicGroup + "|" + In2Model.MaritalStatus + "|" + In2Model.EmploymentStartDate.ToString("yyyyMMddHHmmss") + "|" + In2Model.EmploymentStopDate.ToString("yyyyMMddHHmmss") + "|" + In2Model.JobTitle + "|" + In2Model.JobCode_Class + "|" + In2Model.JobStatus + "|" + In2Model.EmployerContactPersonName + "|" + In2Model.EmployerContactPersonPhoneNumber
            + "|" + In2Model.EmployerContactReason + "|" + In2Model.InsuredContactPersonName + "|" + In2Model.InsuredContactPersonTeleNumber + "|" + In2Model.InsuredContactPersonReason + "|" + In2Model.RelationshipToPatientStartDate.ToString("yyyyMMddHHmmss") + "|" + In2Model.RelationshipToPatientStopDate.ToString("yyyyMMddHHmmss") + "|" + In2Model.InsuranceCoContactReason + "|" + In2Model.InsuranceCoContactPhoneNumber
            + "|" + In2Model.PolicyScope + "|" + In2Model.PolicySource + "|" + In2Model.PatientMemberNumber + "|" + In2Model.GuarantorRelationshipToInsured + "|" + In2Model.InsuredTelephoneNumber + "|" + In2Model.InsuredEmployerTelephoneNumber;


            Logger.Info("IN2Message: " + IN2Message);
            WriteLogA08(IN2Message);

        }
        private void CreateObxSegmentNEW(HL7Model aDTMessageModel)
        {
            /*OBX-1 Set ID - OBX,OBX-2 Value Type,OBX-3 Observation Identifier,OBX-4 Observation Sub-ID,OBX-5 Observation Value
            OBX-6 Units,OBX-7 References Range,OBX-8 Abnormal Flags,OBX-9 Probability,OBX-10 Nature of Abnormal Test,OBX-11 Observation Result Status
            OBX-12 Effective Date of Reference Range Values,OBX-13 User Defined Access Checks,OBX-14 Date/Time of the Observation,OBX-15 Producer's Reference
            OBX-16 Responsible Observer,OBX-17 Observation Method,OBX-18 Equipment Instance Identifier,OBX-19 Date/Time of the Analysis,OBX-20 Performing Organization Name
            OBX-21 Performing Organization Address,OBX-22 Performing Organization Medical Director */
            Logger.Info("At CreateObxSegmentNEW STEP1.");

            OBXModel oBXModel = new OBXModel();
            oBXModel.SetID = 263;
            oBXModel.ValueType = "AD";
            oBXModel.ObservationIdentifier = 55;
            oBXModel.ObservationSubID = 15;
            oBXModel.ObservationValue = "uasyv kudbs";
            oBXModel.Units = "Unit3";
            oBXModel.ReferencesRange = "cachj kasb";
            oBXModel.AbnormalFlags = "A";
            oBXModel.Probability = "Probability2";
            oBXModel.NatureofAbnormalTest = "B";
            oBXModel.ObservationResultStatus = "status ok";
            oBXModel.EffectiveDateofReferenceRangeValues = DateTime.Now;
            oBXModel.UserDefinedAccessChecks = "Checks";
            oBXModel.DateTimeoftheObservation = DateTime.Now;
            oBXModel.ProducersReference = "Reference";
            oBXModel.ResponsibleObserver = "Observer1";
            oBXModel.ObservationMethod = "Method3";
            oBXModel.EquipmentInstanceIdentifier = "Identifier5";
            oBXModel.DateTimeoftheAnalysis = DateTime.Now;
            oBXModel.PerformingOrganizationName = "OrganizationName";
            oBXModel.PerformingOrganizationAddress = "OrganizationAddress";
            oBXModel.PerformingOrganizationMedicalDirector = "MedicalDirectorName";
            Logger.Info("At CreateObxSegmentNEW STEP2.");
            string obx_message = "OBX|";

            obx_message = obx_message + oBXModel.SetID + "|" + oBXModel.ValueType + "|" + oBXModel.ObservationIdentifier + "|" + oBXModel.ObservationSubID + "|" + oBXModel.ObservationValue + "|" + oBXModel.Units + "|" + oBXModel.ReferencesRange
              + "|" + oBXModel.AbnormalFlags + "|" + oBXModel.Probability + "|" + oBXModel.NatureofAbnormalTest + "|" + oBXModel.ObservationResultStatus + "|" + oBXModel.EffectiveDateofReferenceRangeValues.ToString("yyyyMMddHHmmss")
              + "|" + oBXModel.UserDefinedAccessChecks + "|" + oBXModel.DateTimeoftheObservation.ToString("yyyyMMddHHmmss") + "|" + oBXModel.ProducersReference + "|" + oBXModel.ResponsibleObserver + "|" + oBXModel.ObservationMethod
              + "|" + oBXModel.EquipmentInstanceIdentifier + "|" + oBXModel.DateTimeoftheAnalysis.ToString("yyyyMMddHHmmss") + "|" + oBXModel.PerformingOrganizationName + "|" + oBXModel.PerformingOrganizationAddress + "|" + oBXModel.PerformingOrganizationMedicalDirector;
            Logger.Info("obx_message: " + obx_message);
            WriteLogA08(obx_message);

        }


        private void CreateAl1SegmentNEW(HL7Model aDTMessageModel)
        {
            /*AL1-1 Set ID - AL1,AL1-2 Allergen Type Code,AL1-3 Allergen Code/Mnemonic/Description,AL1-4 Allergy Severity Code,AL1-5 Allergy Reaction Code
            AL1-6 Identification Date */
            Logger.Info("At CreateAl1SegmentNEW STEP1.");
            AL1Model aL1Model = new AL1Model();
            aL1Model.SetID = 2;
            aL1Model.AllergenTypeCode = 1543;
            aL1Model.AllergenCode = "AL03";
            aL1Model.AllergySeverityCode = "VAL12";
            aL1Model.AllergyReactionCode = 234;
            aL1Model.IdentificationDate = DateTime.Now;
            string AL1_message = "AL1|";
            Logger.Info("At CreateAl1SegmentNEW STEP2.");
            AL1_message = AL1_message + aL1Model.SetID + "|" + aL1Model.AllergenTypeCode + "|" + aL1Model.AllergenCode + "|" + aL1Model.AllergySeverityCode + "|" + aL1Model.AllergyReactionCode + "|" + aL1Model.IdentificationDate.ToString("yyyyMMddHHmmss");
            Logger.Info("AL1_message: " + AL1_message);
            WriteLogA08(AL1_message);
        }
        private void CreateDg1SegmentNEW(HL7Model aDTMessageModel)
        {
            /*DG1-1 Set ID - DG1,DG1-2 Diagnosis Coding Method,DG1-3 Diagnosis Code - DG1,DG1-4 Diagnosis Description,DG1-5 Diagnosis Date/Time
            DG1-6 Diagnosis Type,DG1-7 Major Diagnostic Category,DG1-8 Diagnostic Related Group,DG1-9 DRG Approval Indicator,DG1-10 DRG Grouper Review Code
            DG1-11 Outlier Type,DG1-12 Outlier Days,DG1-13 Outlier Cost,DG1-14 Grouper Version And Type,DG1-15 Diagnosis Priority
            DG1-16 Diagnosing Clinician,DG1-17 Diagnosis Classification,DG1-18 Confidential Indicator,DG1-19 Attestation Date/Time
            DG1-20 Diagnosis Identifier,DG1-21 Diagnosis Action Code */
            Logger.Info("At CreateDg1SegmentNEW STEP1.");
            DG1Model dG1Model = new DG1Model();
            dG1Model.SetID = aDTMessageModel.DGSetID;//263;
            dG1Model.DiagnosisCodingMethod = aDTMessageModel.DiagnosisCodingMethod;//"AD";
            dG1Model.DiagnosisCode = aDTMessageModel.DiagnosisCode;//55;
            dG1Model.DiagnosisDescription = aDTMessageModel.DiagnosisDescription;//15;
            dG1Model.DiagnosisDateTime = DateTime.Now;
            dG1Model.DiagnosisType = aDTMessageModel.DiagnosisType;//"Unit3";
            dG1Model.MajorDiagnosticCategory = aDTMessageModel.MajorDiagnosticCategory;//"cachj kasb";
            dG1Model.DiagnosticRelatedGroup = aDTMessageModel.DiagnosticRelatedGroup;//"A";
            dG1Model.DRGApprovalIndicator = aDTMessageModel.DRGApprovalIndicator;//"Probability2";
            dG1Model.DRGGrouperReviewCode = aDTMessageModel.DRGGrouperReviewCode;//"B";
            dG1Model.OutlierType = aDTMessageModel.OutlierType;//"status ok";
            dG1Model.OutlierDays = aDTMessageModel.OutlierDays;//"5";
            dG1Model.OutlierCost = aDTMessageModel.OutlierCost;//"Checks";
            dG1Model.GrouperVersionAndType = aDTMessageModel.GrouperVersionAndType;//"01";
            dG1Model.DiagnosisPriority = aDTMessageModel.DiagnosisPriority;//"Reference";
            dG1Model.DiagnosingClinician = aDTMessageModel.DiagnosingClinician;//"Observer1";
            dG1Model.DiagnosisClassification = aDTMessageModel.DiagnosisClassification;//"Method3";
            dG1Model.ConfidentialIndicator = aDTMessageModel.ConfidentialIndicator;//"N";
            dG1Model.AttestationDateTime = DateTime.Now;
            dG1Model.DiagnosisIdentifier = aDTMessageModel.DiagnosisIdentifier;//"Identifier2";
            dG1Model.DiagnosisActionCode = aDTMessageModel.DiagnosisActionCode;//"A";
            Logger.Info("At CreateDg1SegmentNEW STEP2.");

            string DG1_message = "DG1|";

            DG1_message = DG1_message + dG1Model.SetID + "|" + dG1Model.DiagnosisCodingMethod + "|" + dG1Model.DiagnosisCode
                + "|" + dG1Model.DiagnosisDescription + "|" + dG1Model.DiagnosisDateTime.ToString("yyyyMMddHHmmss")
                + "|" + dG1Model.DiagnosisType + "|" + dG1Model.MajorDiagnosticCategory + "|" + dG1Model.DiagnosticRelatedGroup + "|" + dG1Model.DRGApprovalIndicator
              + "|" + dG1Model.DRGGrouperReviewCode + "|" + dG1Model.OutlierType + "|" + dG1Model.OutlierDays
              + "|" + dG1Model.OutlierCost + "|" + dG1Model.GrouperVersionAndType + "|" + dG1Model.DiagnosisPriority
              + "|" + dG1Model.DiagnosingClinician + "|" + dG1Model.DiagnosisClassification + "|" + dG1Model.ConfidentialIndicator + "|" + dG1Model.AttestationDateTime.ToString("yyyyMMddHHmmss")
              + "|" + dG1Model.DiagnosisIdentifier + "|" + dG1Model.DiagnosisActionCode;
            Logger.Info("DG1_message: " + DG1_message);
            WriteLogA08(DG1_message);

        }
        private static string GetCurrentTimeStamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        }

        private static string GetSequenceNumber()
        {
            const string facilityNumberPrefix = "1234"; // some arbitrary prefix for the facility
            return facilityNumberPrefix + GetCurrentTimeStamp();
        }
    }
}
