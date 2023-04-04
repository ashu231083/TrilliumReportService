using NHapi.Base.Model;
using NHapi.Model.V23.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrilliumReportService.Helper;

namespace HelperHL7
{
    internal class ADT_A01MessageBuilder
    {
        private ADT_A01 _adtMessage;

        /*You can pass in a domain or data transfer object as a parameter
        when integrating with data from your application here
        I will leave that to you to explore on your own
        Using fictional data here for illustration*/

        public ADT_A01 Build(MessageModel aDTMessageModel)
        {
            var currentDateTimeString = GetCurrentTimeStamp();
            _adtMessage = new ADT_A01();



            CreateMshSegment(currentDateTimeString, aDTMessageModel);
            CreateEvnSegment(currentDateTimeString, aDTMessageModel);
            CreatePidSegment(aDTMessageModel);
            CreatePv1Segment(aDTMessageModel);
            return _adtMessage;
        }

        private void CreateMshSegment(string currentDateTimeString, MessageModel aDTMessageModel)
        {
            //var mshSegment = _adtMessage.MSH;
            //mshSegment.FieldSeparator.Value = "|";
            //mshSegment.EncodingCharacters.Value = "^~\\&";
            //mshSegment.SendingApplication.NamespaceID.Value = aDTMessageModel.SendingApplicationName;
            //mshSegment.SendingFacility.NamespaceID.Value = aDTMessageModel.SendingFacilityName;
            //mshSegment.ReceivingApplication.NamespaceID.Value = aDTMessageModel.ReceivingApplicationName;
            //mshSegment.ReceivingFacility.NamespaceID.Value = aDTMessageModel.ReceivingFacilityName;
            //mshSegment.DateTimeOfMessage.TimeOfAnEvent.Value = currentDateTimeString;
            //mshSegment.MessageControlID.Value = GetSequenceNumber();
            //mshSegment.MessageType.MessageType.Value = aDTMessageModel.MessageType;
            //mshSegment.MessageType.TriggerEvent.Value = aDTMessageModel.MessageTypeTriggerEvent;
            //mshSegment.VersionID.Value = aDTMessageModel.VersionID;
            //mshSegment.ProcessingID.ProcessingID.Value = aDTMessageModel.ProcessingID;



            MSHModel MSHModel = new MSHModel();
            MSHModel.SendingApplication = "Velox";
            MSHModel.SendingFacility = "Dev Facility";
            MSHModel.ReceivingApplication = "Receiving App";
            MSHModel.ReceivingFacility = "Receiving fac";
            MSHModel.DateTimeofMessage = DateTime.Now;
            MSHModel.Security = "Security";

            //MessageType
            MSHModel.messagetype = "ADT";
            MSHModel.triggerevent = "A01";
            MSHModel.MessageType = MSHModel.messagetype + "^" + MSHModel.triggerevent;

            MSHModel.MessageControlID = 12342023;
            MSHModel.ProcessingID = 3;
            MSHModel.VersionID = "2.3";
            MSHModel.SequenceNumber = "243";
            MSHModel.ContinuationPointer = "243";
            MSHModel.AcceptAcknowledgmentType = "AL";
            MSHModel.ApplicationAcknowledgmentType = "AL";
            MSHModel.CountryCode = "125";
            MSHModel.CharacterSet = "ASCII";
            MSHModel.PrincipalLanguageofMessage = "HL7";



            string MSHMessage = "MSH|^~\\&|";

            MSHMessage = MSHMessage + MSHModel.SendingApplication + "|" + MSHModel.SendingFacility
            + "|" + MSHModel.ReceivingApplication + "|" + MSHModel.ReceivingFacility + "|" + MSHModel.DateTimeofMessage.ToString("yyyyMMddHHmmss") + "|" + MSHModel.Security
            + "|" + MSHModel.MessageType + "|" + MSHModel.MessageControlID + "|" + MSHModel.ProcessingID + "|" + MSHModel.VersionID
            + "|" + MSHModel.SequenceNumber + "|" + MSHModel.ContinuationPointer + "|" + MSHModel.AcceptAcknowledgmentType + "|" + MSHModel.ApplicationAcknowledgmentType
            + "|" + MSHModel.CountryCode + "|" + MSHModel.CharacterSet + "|" + MSHModel.PrincipalLanguageofMessage;

            Debug.WriteLine("MSHMessage: " + MSHMessage);
        }

        private void CreateEvnSegment(string currentDateTimeString, MessageModel aDTMessageModel)
        {
            var evn = _adtMessage.EVN;
            evn.EventTypeCode.Value = aDTMessageModel.EventTypeCode;
            evn.RecordedDateTime.TimeOfAnEvent.Value = currentDateTimeString;


            EVNModel EVNModel = new EVNModel();
            EVNModel.EventTypeCode = "2";
            EVNModel.RecordedDateTime = DateTime.Now;
            EVNModel.DateTimePlannedEvent = DateTime.Now;
            EVNModel.EventReasonCode = "Reason2";
            EVNModel.OperatorID = 32;
            EVNModel.EventOccured = DateTime.Now;
            EVNModel.EventFacility = "FAC2";

            string EVNMessage = "EVN|";
            EVNMessage = EVNMessage + EVNModel.EventTypeCode + "|" + EVNModel.RecordedDateTime.ToString("yyyyMMddHHmmss") + "|" + EVNModel.DateTimePlannedEvent.ToString("yyyyMMddHHmmss") + "|" + EVNModel.EventReasonCode + "|" + EVNModel.OperatorID + "|" + EVNModel.EventOccured.ToString("yyyyMMddHHmmss") + "|" + EVNModel.EventFacility;
            Debug.WriteLine("EVNMessage: " + EVNMessage);

        }

        private void CreatePidSegment(MessageModel aDTMessageModel)
        {
            //var pid = _adtMessage.PID;
            //var patientName = pid.GetPatientName(0);
            //patientName.FamilyName.Value = aDTMessageModel.PatientLastName;
            //patientName.GivenName.Value = aDTMessageModel.PatientFirstName;

            //pid.SetIDPatientID.Value = aDTMessageModel.PatientId.ToString();
            //var patientAddress = pid.GetPatientAddress(0);
            //patientAddress.StreetAddress.Value = aDTMessageModel.PatientAddress;
            //patientAddress.City.Value = aDTMessageModel.PatientCity;
            //patientAddress.StateOrProvince.Value = aDTMessageModel.PatientState;
            //patientAddress.Country.Value = aDTMessageModel.PatientCountry;

            PIDModel PIDModel = new PIDModel();
            PIDModel.SetID = 2;
            //PatientID_External 
            PIDModel.External_ID = 2;
            PIDModel.External_checkdigit = 2;
            PIDModel.External_codeidentifyingthecheckdigitschemeemployed = "33";
            PIDModel.External_assigningauthority = "Authotity2";
            PIDModel.External_identifiertypecode = "code2";
            PIDModel.External_assigningfacility = "Fac3";
            PIDModel.PatientID_External = PIDModel.External_ID + "^" + PIDModel.External_checkdigit + "^" + PIDModel.External_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel.External_assigningauthority + "^" + PIDModel.External_identifiertypecode + "^" + PIDModel.External_assigningfacility;

            //PatientID_Internal
            PIDModel.Internal_ID = 2;
            PIDModel.Internal_checkdigit = 2;
            PIDModel.Internal_codeidentifyingthecheckdigitschemeemployed = "33";
            PIDModel.Internal_assigningauthority = "Authotity2";
            PIDModel.Internal_identifiertypecode = "code2";
            PIDModel.Internal_assigningfacility = "Fac3";
            PIDModel.PatientID_Internal = PIDModel.Internal_ID + "^" + PIDModel.Internal_checkdigit + "^" + PIDModel.Internal_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel.Internal_assigningauthority + "^" + PIDModel.Internal_identifiertypecode + "^" + PIDModel.Internal_assigningfacility;

            //PatientID_Alternate
            PIDModel.Alternate_ID = 2;
            PIDModel.Alternate_checkdigit = 2;
            PIDModel.Alternate_codeidentifyingthecheckdigitschemeemployed = "33";
            PIDModel.Alternate_assigningauthority = "Authotity2";
            PIDModel.Alternate_identifiertypecode = "code2";
            PIDModel.Alternate_assigningfacility = "Fac3";
            PIDModel.PatientID_Alternate = PIDModel.Alternate_ID + "^" + PIDModel.Alternate_checkdigit + "^" + PIDModel.Alternate_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel.Alternate_assigningauthority + "^" + PIDModel.Alternate_identifiertypecode + "^" + PIDModel.Alternate_assigningfacility;

            //PatientName
            PIDModel.familyname = "Family";
            PIDModel.givenname = "givenName";
            PIDModel.middleinitial = "Middlename";
            PIDModel.PatientName = PIDModel.familyname + "^" + PIDModel.givenname + "^" + PIDModel.middleinitial;
            PIDModel.MotherMaidenName = "NameHere";
            PIDModel.DateofBirth = DateTime.Now;
            PIDModel.Sex = "M";
            PIDModel.PatientAlias = "lolo";
            PIDModel.Race = "";

            //PatientAddress
            PIDModel.streetaddress = "Designation";
            PIDModel.otherdesignation = "Canada";
            PIDModel.city = "ST02";
            PIDModel.stateorprovince = "Canada";
            PIDModel.ziporpostalcode = "58164";
            PIDModel.othergeographicdesignation = "Designation";
            PIDModel.country = "Canada";
            PIDModel.addresstype = "AD02";
            PIDModel.countrycode = "155";
            PIDModel.censustract = "";
            PIDModel.addressrepresentationcode = "";
            PIDModel.addressvalidityrange = "";

            PIDModel.PatientAddress = PIDModel.streetaddress + "^" + PIDModel.otherdesignation + "^" + PIDModel.city + "^" + PIDModel.stateorprovince + "^" + PIDModel.ziporpostalcode + "^" + PIDModel.othergeographicdesignation + "^" + PIDModel.country + "^" + PIDModel.addresstype + "^" + PIDModel.countrycode + "^" + PIDModel.censustract + "^" + PIDModel.addressrepresentationcode + "^" + PIDModel.addressvalidityrange;

            PIDModel.CountryCode = "CL";
            PIDModel.PhoneNumber_Home = "654654684";
            PIDModel.PhoneNumber_Business = "24456674";
            PIDModel.PrimaryLanguage = "";
            PIDModel.MaritalStaus = "";
            PIDModel.Religion = "";

            //PatientAccountNumber
            PIDModel.PatientAccount_id = 35;
            PIDModel.checkdigit = 32;
            PIDModel.codeidentifyingthecheckdigitschemeemployed = "";
            PIDModel.PatientAccountNumber = PIDModel.PatientAccount_id + "^" + PIDModel.checkdigit + "^" + PIDModel.codeidentifyingthecheckdigitschemeemployed;

            PIDModel.SSNNumber_Patient = "";
            PIDModel.DriverLicenseNumber = "";
            PIDModel.IssuingState_province_country = "";
            PIDModel.DriverLicenseNumber_Patient = PIDModel.DriverLicenseNumber + "^" + PIDModel.IssuingState_province_country;

            string pid_message = "PID|";
            pid_message = pid_message + PIDModel.SetID + "|" + PIDModel.PatientID_External + "|" + PIDModel.PatientID_Internal + "|" + PIDModel.PatientID_Alternate + "|" + PIDModel.PatientName + "|" + PIDModel.MotherMaidenName + "|" + PIDModel.DateofBirth.ToString("yyyyMMddHHmmss")
                + "|" + PIDModel.Sex + "|" + PIDModel.PatientAlias + "|" + PIDModel.Race + "|" + PIDModel.PatientAddress + "|" + PIDModel.CountryCode + "|" + PIDModel.PhoneNumber_Home + "|" + PIDModel.PhoneNumber_Business + "|" + PIDModel.PrimaryLanguage + "|" + PIDModel.MaritalStaus
                + "|" + PIDModel.Religion + "|" + PIDModel.PatientAccountNumber + "|" + PIDModel.SSNNumber_Patient + "|" + PIDModel.DriverLicenseNumber + "|" + PIDModel.MotherIdentifier + "|" + PIDModel.EthnicGroup + "|" + PIDModel.BirthPlace + "|" + PIDModel.MultipleBirthIndicator
                + "|" + PIDModel.BirthOther + "|" + PIDModel.Citizenship + "|" + PIDModel.VeteransMilitaryStatus + "|" + PIDModel.NationalityCode + "|" + PIDModel.PatientDeathDateTime.ToString("yyyyMMddHHmmss") + "|" + PIDModel.PatientDeathIndicator;

            Debug.WriteLine("PID_message: " + pid_message);
        }

        private void CreatePv1Segment(MessageModel aDTMessageModel)
        {
            PV1Model PV1Model = new PV1Model();
            PV1Model.SetID = 2;
            PV1Model.PatientClass = "";

            PV1Model.PointOfCare = "";
            PV1Model.Room = "";
            PV1Model.Bed = "";
            PV1Model.Facility = "";
            PV1Model.LocationStatus = "";
            PV1Model.PersonLocationType = "";
            PV1Model.Building = "";
            PV1Model.Floor = "";
            PV1Model.LocationType = "";
            PV1Model.AssignedPatientLocation = PV1Model.PointOfCare + "^" + PV1Model.Room + "^" + PV1Model.Bed + "^" + PV1Model.Facility + "^" + PV1Model.LocationStatus + "^" + PV1Model.PersonLocationType + "^" + PV1Model.Building + "^" + PV1Model.Floor + "^" + PV1Model.LocationType;
            PV1Model.AdmissionType = "";

            PV1Model.PreadmitNumber = "";
            PV1Model.PriorPatientLocation = "";
            PV1Model.AttendingDoctor = PV1Model.IDNumber + "^" + PV1Model.Family_LastName + "^" + PV1Model.GivenName;
            PV1Model.ReferringDoctor = PV1Model.IDNumber + "^" + PV1Model.Family_LastName + "^" + PV1Model.GivenName;

            PV1Model.ConsultingDoctor = "";
            PV1Model.HospitalService = "";
            PV1Model.TemporaryLocation = "";
            PV1Model.PreadmitTestIndicator = "";
            PV1Model.Re_AdmissionIndicator = "";
            PV1Model.AdmitSource = "";
            PV1Model.AmbulatoryStatus = "";
            PV1Model.VIPIndicator = "";

            PV1Model.AdmittingDoctor = "";

            PV1Model.PatientType = "";
            PV1Model.VisitNumber = "";
            PV1Model.FinancialClass = "";
            PV1Model.ChargePriceIndicator = "";
            PV1Model.CourtesyCode = "";
            PV1Model.CreditRating = "";
            PV1Model.ContractCode = "";
            PV1Model.ContractEffectiveDate = DateTime.Now;
            PV1Model.ContractAmount = 328534;
            PV1Model.ContractPeriod = "";
            PV1Model.InterestCode = "";
            PV1Model.TransfertoBadDebtCode = "";
            PV1Model.TransfertoBadDebtDate = DateTime.Now;
            PV1Model.BadDebtAgencyCode = "";
            PV1Model.BadDebtTransferAmount = 354354;
            PV1Model.BadDebtRecoveryAmount = 3843;
            PV1Model.DeleteAccountIndicator = "";
            PV1Model.DeleteAccountDate = DateTime.Now;
            PV1Model.DischargeDisposition = "";
            PV1Model.DischargedToLocation = "";
            PV1Model.DietType = "";
            PV1Model.ServicingFacility = "";
            PV1Model.BedStatus = "";
            PV1Model.AccountStatus = "";
            PV1Model.PendingLocation = "";
            PV1Model.PriorTemporaryLocation = "";
            PV1Model.AdmitDatetime = DateTime.Now;
            PV1Model.DischargeDatetime = DateTime.Now;
            PV1Model.CurrentPatientBalance = 35435;
            PV1Model.TotalCharges = 35484;
            PV1Model.TotalAdjustments = 354388;
            PV1Model.TotalPayments = 35438;
            PV1Model.AlternateVisitID = 4;
            PV1Model.VisitIndicator = "";
            PV1Model.OtherHealthcareProvider = "";

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

            Debug.WriteLine("PV1_message: " + PV1_message);

        }


        private void CreateORCSegment(MessageModel aDTMessageModel)
        {
        }

        private void CreateOBRSegment(MessageModel aDTMessageModel)
        {
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



        public ADT_A01 BuildNEW(HL7Model aDTMessageModel)
        {
            var currentDateTimeString = GetCurrentTimeStamp();
            _adtMessage = new ADT_A01();



            CreateMshSegmentNEW(currentDateTimeString, aDTMessageModel);
            CreateEvnSegmentNEW(currentDateTimeString, aDTMessageModel);
            CreatePidSegmentNEW(aDTMessageModel);
            CreatePv1SegmentNEW(aDTMessageModel);
            return _adtMessage;
        }

        private void CreateMshSegmentNEW(string currentDateTimeString, HL7Model aDTMessageModel)
        {
            //var mshSegment = _adtMessage.MSH;
            //mshSegment.FieldSeparator.Value = "|";
            //mshSegment.EncodingCharacters.Value = "^~\\&";
            //mshSegment.SendingApplication.NamespaceID.Value = aDTMessageModel.SendingApplicationName;
            //mshSegment.SendingFacility.NamespaceID.Value = aDTMessageModel.SendingFacilityName;
            //mshSegment.ReceivingApplication.NamespaceID.Value = aDTMessageModel.ReceivingApplicationName;
            //mshSegment.ReceivingFacility.NamespaceID.Value = aDTMessageModel.ReceivingFacilityName;
            //mshSegment.DateTimeOfMessage.TimeOfAnEvent.Value = currentDateTimeString;
            //mshSegment.MessageControlID.Value = GetSequenceNumber();
            //mshSegment.MessageType.MessageType.Value = aDTMessageModel.MessageType;
            //mshSegment.MessageType.TriggerEvent.Value = aDTMessageModel.MessageTypeTriggerEvent;
            //mshSegment.VersionID.Value = aDTMessageModel.VersionID;
            //mshSegment.ProcessingID.ProcessingID.Value = aDTMessageModel.ProcessingID;



            MSHModel MSHModel = new MSHModel();
            MSHModel.SendingApplication = "Velox";
            MSHModel.SendingFacility = "Dev Facility";
            MSHModel.ReceivingApplication = "Receiving App";
            MSHModel.ReceivingFacility = "Receiving fac";
            MSHModel.DateTimeofMessage = DateTime.Now;
            MSHModel.Security = "Security";

            //MessageType
            MSHModel.messagetype = "ADT";
            MSHModel.triggerevent = "A01";
            MSHModel.MessageType = MSHModel.messagetype + "^" + MSHModel.triggerevent;

            MSHModel.MessageControlID = 12342023;
            MSHModel.ProcessingID = 3;
            MSHModel.VersionID = "2.3";
            MSHModel.SequenceNumber = "243";
            MSHModel.ContinuationPointer = "243";
            MSHModel.AcceptAcknowledgmentType = "AL";
            MSHModel.ApplicationAcknowledgmentType = "AL";
            MSHModel.CountryCode = "125";
            MSHModel.CharacterSet = "ASCII";
            MSHModel.PrincipalLanguageofMessage = "HL7";



            string MSHMessage = "MSH|^~\\&|";

            MSHMessage = MSHMessage + MSHModel.SendingApplication + "|" + MSHModel.SendingFacility
            + "|" + MSHModel.ReceivingApplication + "|" + MSHModel.ReceivingFacility + "|" + MSHModel.DateTimeofMessage.ToString("yyyyMMddHHmmss") + "|" + MSHModel.Security
            + "|" + MSHModel.MessageType + "|" + MSHModel.MessageControlID + "|" + MSHModel.ProcessingID + "|" + MSHModel.VersionID
            + "|" + MSHModel.SequenceNumber + "|" + MSHModel.ContinuationPointer + "|" + MSHModel.AcceptAcknowledgmentType + "|" + MSHModel.ApplicationAcknowledgmentType
            + "|" + MSHModel.CountryCode + "|" + MSHModel.CharacterSet + "|" + MSHModel.PrincipalLanguageofMessage;

            Debug.WriteLine("MSHMessage: " + MSHMessage);
        }

        private void CreateEvnSegmentNEW(string currentDateTimeString, HL7Model aDTMessageModel)
        {
            //var evn = _adtMessage.EVN;
            //evn.EventTypeCode.Value = aDTMessageModel.EventTypeCode;
            //evn.RecordedDateTime.TimeOfAnEvent.Value = currentDateTimeString;


            EVNModel EVNModel = new EVNModel();
            EVNModel.EventTypeCode = "2";
            EVNModel.RecordedDateTime = DateTime.Now;
            EVNModel.DateTimePlannedEvent = DateTime.Now;
            EVNModel.EventReasonCode = "Reason2";
            EVNModel.OperatorID = 32;
            EVNModel.EventOccured = DateTime.Now;
            EVNModel.EventFacility = "FAC2";

            string EVNMessage = "EVN|";
            EVNMessage = EVNMessage + EVNModel.EventTypeCode + "|" + EVNModel.RecordedDateTime.ToString("yyyyMMddHHmmss") + "|" + EVNModel.DateTimePlannedEvent.ToString("yyyyMMddHHmmss") + "|" + EVNModel.EventReasonCode + "|" + EVNModel.OperatorID + "|" + EVNModel.EventOccured.ToString("yyyyMMddHHmmss") + "|" + EVNModel.EventFacility;
            Debug.WriteLine("EVNMessage: " + EVNMessage);

        }

        private void CreatePidSegmentNEW(HL7Model aDTMessageModel)
        {
            //var pid = _adtMessage.PID;
            //var patientName = pid.GetPatientName(0);
            //patientName.FamilyName.Value = aDTMessageModel.PatientLastName;
            //patientName.GivenName.Value = aDTMessageModel.PatientFirstName;

            //pid.SetIDPatientID.Value = aDTMessageModel.PatientId.ToString();
            //var patientAddress = pid.GetPatientAddress(0);
            //patientAddress.StreetAddress.Value = aDTMessageModel.PatientAddress;
            //patientAddress.City.Value = aDTMessageModel.PatientCity;
            //patientAddress.StateOrProvince.Value = aDTMessageModel.PatientState;
            //patientAddress.Country.Value = aDTMessageModel.PatientCountry;

            PIDModel PIDModel = new PIDModel();
            PIDModel.SetID = 2;
            //PatientID_External 
            PIDModel.External_ID = 2;
            PIDModel.External_checkdigit = 2;
            PIDModel.External_codeidentifyingthecheckdigitschemeemployed = "33";
            PIDModel.External_assigningauthority = "Authotity2";
            PIDModel.External_identifiertypecode = "code2";
            PIDModel.External_assigningfacility = "Fac3";
            PIDModel.PatientID_External = PIDModel.External_ID + "^" + PIDModel.External_checkdigit + "^" + PIDModel.External_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel.External_assigningauthority + "^" + PIDModel.External_identifiertypecode + "^" + PIDModel.External_assigningfacility;

            //PatientID_Internal
            PIDModel.Internal_ID = 2;
            PIDModel.Internal_checkdigit = 2;
            PIDModel.Internal_codeidentifyingthecheckdigitschemeemployed = "33";
            PIDModel.Internal_assigningauthority = "Authotity2";
            PIDModel.Internal_identifiertypecode = "code2";
            PIDModel.Internal_assigningfacility = "Fac3";
            PIDModel.PatientID_Internal = PIDModel.Internal_ID + "^" + PIDModel.Internal_checkdigit + "^" + PIDModel.Internal_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel.Internal_assigningauthority + "^" + PIDModel.Internal_identifiertypecode + "^" + PIDModel.Internal_assigningfacility;

            //PatientID_Alternate
            PIDModel.Alternate_ID = 2;
            PIDModel.Alternate_checkdigit = 2;
            PIDModel.Alternate_codeidentifyingthecheckdigitschemeemployed = "33";
            PIDModel.Alternate_assigningauthority = "Authotity2";
            PIDModel.Alternate_identifiertypecode = "code2";
            PIDModel.Alternate_assigningfacility = "Fac3";
            PIDModel.PatientID_Alternate = PIDModel.Alternate_ID + "^" + PIDModel.Alternate_checkdigit + "^" + PIDModel.Alternate_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel.Alternate_assigningauthority + "^" + PIDModel.Alternate_identifiertypecode + "^" + PIDModel.Alternate_assigningfacility;

            //PatientName
            PIDModel.familyname = "Family";
            PIDModel.givenname = "givenName";
            PIDModel.middleinitial = "Middlename";
            PIDModel.PatientName = PIDModel.familyname + "^" + PIDModel.givenname + "^" + PIDModel.middleinitial;
            PIDModel.MotherMaidenName = "NameHere";
            PIDModel.DateofBirth = DateTime.Now;
            PIDModel.Sex = "M";
            PIDModel.PatientAlias = "lolo";
            PIDModel.Race = "";

            //PatientAddress
            PIDModel.streetaddress = "Designation";
            PIDModel.otherdesignation = "Canada";
            PIDModel.city = "ST02";
            PIDModel.stateorprovince = "Canada";
            PIDModel.ziporpostalcode = "58164";
            PIDModel.othergeographicdesignation = "Designation";
            PIDModel.country = "Canada";
            PIDModel.addresstype = "AD02";
            PIDModel.countrycode = "155";
            PIDModel.censustract = "";
            PIDModel.addressrepresentationcode = "";
            PIDModel.addressvalidityrange = "";

            PIDModel.PatientAddress = PIDModel.streetaddress + "^" + PIDModel.otherdesignation + "^" + PIDModel.city + "^" + PIDModel.stateorprovince + "^" + PIDModel.ziporpostalcode + "^" + PIDModel.othergeographicdesignation + "^" + PIDModel.country + "^" + PIDModel.addresstype + "^" + PIDModel.countrycode + "^" + PIDModel.censustract + "^" + PIDModel.addressrepresentationcode + "^" + PIDModel.addressvalidityrange;

            PIDModel.CountryCode = "CL";
            PIDModel.PhoneNumber_Home = "654654684";
            PIDModel.PhoneNumber_Business = "24456674";
            PIDModel.PrimaryLanguage = "";
            PIDModel.MaritalStaus = "";
            PIDModel.Religion = "";

            //PatientAccountNumber
            PIDModel.PatientAccount_id = 35;
            PIDModel.checkdigit = 32;
            PIDModel.codeidentifyingthecheckdigitschemeemployed = "";
            PIDModel.PatientAccountNumber = PIDModel.PatientAccount_id + "^" + PIDModel.checkdigit + "^" + PIDModel.codeidentifyingthecheckdigitschemeemployed;

            PIDModel.SSNNumber_Patient = "";
            PIDModel.DriverLicenseNumber = "";
            PIDModel.IssuingState_province_country = "";
            PIDModel.DriverLicenseNumber_Patient = PIDModel.DriverLicenseNumber + "^" + PIDModel.IssuingState_province_country;

            string pid_message = "PID|";
            pid_message = pid_message + PIDModel.SetID + "|" + PIDModel.PatientID_External + "|" + PIDModel.PatientID_Internal + "|" + PIDModel.PatientID_Alternate + "|" + PIDModel.PatientName + "|" + PIDModel.MotherMaidenName + "|" + PIDModel.DateofBirth.ToString("yyyyMMddHHmmss")
                + "|" + PIDModel.Sex + "|" + PIDModel.PatientAlias + "|" + PIDModel.Race + "|" + PIDModel.PatientAddress + "|" + PIDModel.CountryCode + "|" + PIDModel.PhoneNumber_Home + "|" + PIDModel.PhoneNumber_Business + "|" + PIDModel.PrimaryLanguage + "|" + PIDModel.MaritalStaus
                + "|" + PIDModel.Religion + "|" + PIDModel.PatientAccountNumber + "|" + PIDModel.SSNNumber_Patient + "|" + PIDModel.DriverLicenseNumber + "|" + PIDModel.MotherIdentifier + "|" + PIDModel.EthnicGroup + "|" + PIDModel.BirthPlace + "|" + PIDModel.MultipleBirthIndicator
                + "|" + PIDModel.BirthOther + "|" + PIDModel.Citizenship + "|" + PIDModel.VeteransMilitaryStatus + "|" + PIDModel.NationalityCode + "|" + PIDModel.PatientDeathDateTime.ToString("yyyyMMddHHmmss") + "|" + PIDModel.PatientDeathIndicator;

            Debug.WriteLine("PID_message: " + pid_message);
        }

        private void CreatePv1SegmentNEW(HL7Model aDTMessageModel)
        {
            PV1Model PV1Model = new PV1Model();
            PV1Model.SetID = 2;
            PV1Model.PatientClass = "";

            PV1Model.PointOfCare = "";
            PV1Model.Room = "";
            PV1Model.Bed = "";
            PV1Model.Facility = "";
            PV1Model.LocationStatus = "";
            PV1Model.PersonLocationType = "";
            PV1Model.Building = "";
            PV1Model.Floor = "";
            PV1Model.LocationType = "";
            PV1Model.AssignedPatientLocation = PV1Model.PointOfCare + "^" + PV1Model.Room + "^" + PV1Model.Bed + "^" + PV1Model.Facility + "^" + PV1Model.LocationStatus + "^" + PV1Model.PersonLocationType + "^" + PV1Model.Building + "^" + PV1Model.Floor + "^" + PV1Model.LocationType;
            PV1Model.AdmissionType = "";

            PV1Model.PreadmitNumber = "";
            PV1Model.PriorPatientLocation = "";
            PV1Model.AttendingDoctor = PV1Model.IDNumber + "^" + PV1Model.Family_LastName + "^" + PV1Model.GivenName;
            PV1Model.ReferringDoctor = PV1Model.IDNumber + "^" + PV1Model.Family_LastName + "^" + PV1Model.GivenName;

            PV1Model.ConsultingDoctor = "";
            PV1Model.HospitalService = "";
            PV1Model.TemporaryLocation = "";
            PV1Model.PreadmitTestIndicator = "";
            PV1Model.Re_AdmissionIndicator = "";
            PV1Model.AdmitSource = "";
            PV1Model.AmbulatoryStatus = "";
            PV1Model.VIPIndicator = "";

            PV1Model.AdmittingDoctor = "";

            PV1Model.PatientType = "";
            PV1Model.VisitNumber = "";
            PV1Model.FinancialClass = "";
            PV1Model.ChargePriceIndicator = "";
            PV1Model.CourtesyCode = "";
            PV1Model.CreditRating = "";
            PV1Model.ContractCode = "";
            PV1Model.ContractEffectiveDate = DateTime.Now;
            PV1Model.ContractAmount = 328534;
            PV1Model.ContractPeriod = "";
            PV1Model.InterestCode = "";
            PV1Model.TransfertoBadDebtCode = "";
            PV1Model.TransfertoBadDebtDate = DateTime.Now;
            PV1Model.BadDebtAgencyCode = "";
            PV1Model.BadDebtTransferAmount = 354354;
            PV1Model.BadDebtRecoveryAmount = 3843;
            PV1Model.DeleteAccountIndicator = "";
            PV1Model.DeleteAccountDate = DateTime.Now;
            PV1Model.DischargeDisposition = "";
            PV1Model.DischargedToLocation = "";
            PV1Model.DietType = "";
            PV1Model.ServicingFacility = "";
            PV1Model.BedStatus = "";
            PV1Model.AccountStatus = "";
            PV1Model.PendingLocation = "";
            PV1Model.PriorTemporaryLocation = "";
            PV1Model.AdmitDatetime = DateTime.Now;
            PV1Model.DischargeDatetime = DateTime.Now;
            PV1Model.CurrentPatientBalance = 35435;
            PV1Model.TotalCharges = 35484;
            PV1Model.TotalAdjustments = 354388;
            PV1Model.TotalPayments = 35438;
            PV1Model.AlternateVisitID = 4;
            PV1Model.VisitIndicator = "";
            PV1Model.OtherHealthcareProvider = "";

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

            Debug.WriteLine("PV1_message: " + PV1_message);

        }

    }
}
