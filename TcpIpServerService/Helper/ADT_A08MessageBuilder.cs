using NHapi.Model.V23.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperHL7
{
    internal class ADT_A08MessageBuilder
    {
        private ADT_A08 _adtMessage;

        /*You can pass in a domain or data transfer object as a parameter
        when integrating with data from your application here
        I will leave that to you to explore on your own
        Using fictional data here for illustration*/

        public ADT_A08 BuildA08(MessageModel aDTMessageModel)
        {
            var currentDateTimeString = GetCurrentTimeStamp();
            _adtMessage = new ADT_A08();

            CreateMshSegment(currentDateTimeString, aDTMessageModel);
            CreateEvnSegment(currentDateTimeString, aDTMessageModel);
            CreatePidSegment(aDTMessageModel);

            CreateNk1Segment(aDTMessageModel);

            CreatePv1Segment(aDTMessageModel);
            CreateGT1Segment(aDTMessageModel);
            CreateDg1Segment(aDTMessageModel);



            CreateIn1Segment(aDTMessageModel);
            CreateIn2Segment(aDTMessageModel);

            return _adtMessage;
        }


        public ADT_A08 BuildA08NEW(HL7Model aDTMessageModel)
        {
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

            //Debug.WriteLine("mshSegment: " + mshSegment.Message);


            MSHModel MSHModel = new MSHModel();
            MSHModel.SendingApplication = "Velox";
            MSHModel.SendingFacility = "Dev Facility";
            MSHModel.ReceivingApplication = "Receiving App";
            MSHModel.ReceivingFacility = "Receiving fac";
            MSHModel.DateTimeofMessage = DateTime.Now;
            MSHModel.Security = "Security";

            //MessageType
            MSHModel.messagetype = "ADT";
            MSHModel.triggerevent = "A08";
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

        private void CreateMshSegmentNEW(string currentDateTimeString, HL7Model aDTMessageModel)
        {

            MSHModel MSHModel = new MSHModel();
            MSHModel.SendingApplication = aDTMessageModel.SendingApplication;
            MSHModel.SendingFacility = aDTMessageModel.SendingFacility;
            MSHModel.ReceivingApplication = aDTMessageModel.ReceivingApplication;
            MSHModel.ReceivingFacility = "";
            MSHModel.DateTimeofMessage = DateTime.Now;
            MSHModel.Security = aDTMessageModel.Security;

            //MessageType
            MSHModel.messagetype = aDTMessageModel.messagetype;
            MSHModel.triggerevent = aDTMessageModel.triggerevent;
            MSHModel.MessageType = MSHModel.messagetype + "^" + MSHModel.triggerevent;

            MSHModel.MessageControlID = 43;
            MSHModel.ProcessingID = 3;
            MSHModel.VersionID = aDTMessageModel.VersionID;
            MSHModel.SequenceNumber = aDTMessageModel.SequenceNumber;
            MSHModel.ContinuationPointer = aDTMessageModel.ContinuationPointer;
            MSHModel.AcceptAcknowledgmentType = aDTMessageModel.AcceptAcknowledgmentType;
            MSHModel.ApplicationAcknowledgmentType = aDTMessageModel.ApplicationAcknowledgmentType;
            MSHModel.CountryCode = "";
            MSHModel.CharacterSet = "ASCII";
            MSHModel.PrincipalLanguageofMessage = "HL7";



            string MSHMessage = "MSH|^~\\&|";
            MSHMessage = MSHMessage + MSHModel.SendingApplication + "|" + MSHModel.SendingFacility
            + "|" + MSHModel.ReceivingApplication + "|" + MSHModel.ReceivingFacility + "|" + MSHModel.DateTimeofMessage.ToString("yyyyMMddHHmmss") + "|" + MSHModel.Security
            + "|" + MSHModel.MessageType + "|" + MSHModel.MessageControlID + "|" + MSHModel.ProcessingID + "|" + MSHModel.VersionID
            + "|" + MSHModel.SequenceNumber + "|" + MSHModel.ContinuationPointer + "|" + MSHModel.AcceptAcknowledgmentType + "|" + MSHModel.ApplicationAcknowledgmentType
            + "|" + MSHModel.CountryCode + "|" + MSHModel.CharacterSet + "|" + MSHModel.PrincipalLanguageofMessage;

            Debug.WriteLine("NEW MSHMessage: " + MSHMessage);
        }

        private void CreateEvnSegment(string currentDateTimeString, MessageModel aDTMessageModel)
        {
            var evn = _adtMessage.EVN;
            evn.EventTypeCode.Value = aDTMessageModel.EventTypeCode;
            evn.RecordedDateTime.TimeOfAnEvent.Value = currentDateTimeString;

            EVNModel EVNModel = new EVNModel();
            EVNModel.EventTypeCode = "A08";
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

        private void CreateEvnSegmentNEW(string currentDateTimeString, HL7Model aDTMessageModel)
        {

            EVNModel EVNModel = new EVNModel();
            EVNModel.EventTypeCode = aDTMessageModel.EventTypeCode;
            EVNModel.RecordedDateTime = DateTime.Now;
            EVNModel.DateTimePlannedEvent = DateTime.Now;
            EVNModel.EventReasonCode = "";
            EVNModel.OperatorID = 32;
            EVNModel.EventOccured = DateTime.Now;
            EVNModel.EventFacility = "FAC22";

            string EVNMessage = "EVN|";
            EVNMessage = EVNMessage + EVNModel.EventTypeCode + "|" + EVNModel.RecordedDateTime.ToString("yyyyMMddHHmmss") + "|" + EVNModel.DateTimePlannedEvent.ToString("yyyyMMddHHmmss") + "|" + EVNModel.EventReasonCode + "|" + EVNModel.OperatorID + "|" + EVNModel.EventOccured.ToString("yyyyMMddHHmmss") + "|" + EVNModel.EventFacility;
            Debug.WriteLine("EVNMessage: " + EVNMessage);
        }

        private void CreatePidSegment(MessageModel aDTMessageModel)
        {
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

        private void CreatePidSegmentNEW(HL7Model aDTMessageModel)
        {
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
            PIDModel.familyname = aDTMessageModel.familyname;
            PIDModel.givenname = aDTMessageModel.givenname;
            PIDModel.middleinitial = aDTMessageModel.middleinitial;
            PIDModel.PatientName = PIDModel.familyname + "^" + PIDModel.givenname + "^" + PIDModel.middleinitial;
            PIDModel.MotherMaidenName = aDTMessageModel.MotherMaidenName;
            PIDModel.DateofBirth = DateTime.Now;
            PIDModel.Sex = aDTMessageModel.Sex;
            PIDModel.PatientAlias = aDTMessageModel.PatientAlias;
            PIDModel.Race = "";

            //PatientAddress
            PIDModel.streetaddress = aDTMessageModel.streetaddress;
            PIDModel.otherdesignation = aDTMessageModel.otherdesignation;
            PIDModel.city = aDTMessageModel.city;
            PIDModel.stateorprovince = aDTMessageModel.stateorprovince;
            PIDModel.ziporpostalcode = aDTMessageModel.ziporpostalcode;
            PIDModel.othergeographicdesignation = aDTMessageModel.othergeographicdesignation;
            PIDModel.country = aDTMessageModel.country;
            PIDModel.addresstype = aDTMessageModel.addresstype;
            PIDModel.countrycode = aDTMessageModel.countrycode;
            PIDModel.censustract = aDTMessageModel.censustract;
            PIDModel.addressrepresentationcode = aDTMessageModel.addressrepresentationcode;
            PIDModel.addressvalidityrange = aDTMessageModel.addressvalidityrange;

            PIDModel.PatientAddress = PIDModel.streetaddress + "^" + PIDModel.otherdesignation + "^" + PIDModel.city + "^" + PIDModel.stateorprovince + "^" + PIDModel.ziporpostalcode + "^" + PIDModel.othergeographicdesignation + "^" + PIDModel.country + "^" + PIDModel.addresstype + "^" + PIDModel.countrycode + "^" + PIDModel.censustract + "^" + PIDModel.addressrepresentationcode + "^" + PIDModel.addressvalidityrange;

            PIDModel.CountryCode = aDTMessageModel.countrycode;
            PIDModel.PhoneNumber_Home = aDTMessageModel.PhoneNumber_Home;
            PIDModel.PhoneNumber_Business = aDTMessageModel.PhoneNumber_Business;
            PIDModel.PrimaryLanguage = aDTMessageModel.PrimaryLanguage;
            PIDModel.MaritalStaus = aDTMessageModel.MaritalStaus;
            PIDModel.Religion = aDTMessageModel.Religion;

            //PatientAccountNumber
            PIDModel.PatientAccount_id = int.Parse(aDTMessageModel.PatientAccount_id);
            PIDModel.checkdigit = int.Parse(aDTMessageModel.checkdigit);
            PIDModel.codeidentifyingthecheckdigitschemeemployed = aDTMessageModel.codeidentifyingthecheckdigitschemeemployed;
            PIDModel.PatientAccountNumber = PIDModel.PatientAccount_id + "^" + PIDModel.checkdigit + "^" + PIDModel.codeidentifyingthecheckdigitschemeemployed;

            PIDModel.SSNNumber_Patient = aDTMessageModel.SSNNumber_Patient;
            PIDModel.DriverLicenseNumber = aDTMessageModel.DriverLicenseNumber;
            PIDModel.IssuingState_province_country = aDTMessageModel.IssuingState_province_country;
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
            //var pv1 = _adtMessage.PV1;
            //pv1.PatientClass.Value = "O"; // to represent an 'Outpatient'
            //var assignedPatientLocation = pv1.AssignedPatientLocation;
            //assignedPatientLocation.Facility.NamespaceID.Value = aDTMessageModel.LocationFacility;
            //assignedPatientLocation.PointOfCare.Value = aDTMessageModel.LocationPointOfCare;
            //pv1.AdmissionType.Value = aDTMessageModel.AdminssionType;
            //var referringDoctor = pv1.GetReferringDoctor(0);
            //referringDoctor.IDNumber.Value = aDTMessageModel.ReferringDoctorId.ToString();
            //referringDoctor.FamilyName.Value = aDTMessageModel.ReferringDoctorLastName;
            //referringDoctor.GivenName.Value = aDTMessageModel.ReferringDoctorLastName;
            //referringDoctor.IdentifierTypeCode.Value = aDTMessageModel.ReferringDoctorIdentifierTypeCode;
            //pv1.AdmitDateTime.TimeOfAnEvent.Value = GetCurrentTimeStamp();
            //Debug.WriteLine("pv1Segment: " + pv1.Message);

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

        private void CreatePv1SegmentNEW(HL7Model aDTMessageModel)
        {


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

        private void CreatePd1Segment(MessageModel aDTMessageModel)
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


            PD1Model pD1Model = new PD1Model();
            pD1Model.LivingDependency = "U";
            pD1Model.LivingArrangement = "A";
            pD1Model.PatientPrimaryFacility = "Facility2";
            pD1Model.PatientPrimaryCareProviderName_ID_No = "2";
            pD1Model.StudentIndicator = "F";
            pD1Model.Handicap = "";
            pD1Model.LivingWillCode = "I";
            pD1Model.OrganDonorCode = "F";
            pD1Model.SeparateBill = "N";
            pD1Model.DuplicatePatient = "No";
            pD1Model.PublicityCode = "U";
            pD1Model.ProtectionIndicator = "Y";
            pD1Model.ProtectionIndicatorEffectiveDate = DateTime.Now;
            pD1Model.PlaceofWorkship = "";
            pD1Model.AdvanceDirectiveCode = "N";
            pD1Model.ImmunizationRegistryStatus = "A";
            pD1Model.ImmunizationRegistryStatusEffectiveDate = DateTime.Now;
            pD1Model.PublicityCodeEffectiveDate = DateTime.Now;
            pD1Model.MilitaryBranch = "AUSA";
            pD1Model.MilitaryRank_Grade = "E1... E9";
            pD1Model.MilitaryStatus = "RET";


            string pd1_message = "PD1|";
            pd1_message = pd1_message + pD1Model.LivingDependency + "|" + pD1Model.LivingArrangement + "|" + pD1Model.PatientPrimaryFacility + "|" + pD1Model.PatientPrimaryCareProviderName_ID_No + "|" + pD1Model.StudentIndicator + "|" + pD1Model.Handicap + "|" + pD1Model.LivingWillCode
                 + "|" + pD1Model.OrganDonorCode + "|" + pD1Model.SeparateBill + "|" + pD1Model.DuplicatePatient + "|" + pD1Model.PublicityCode + "|" + pD1Model.ProtectionIndicator
                 + "|" + pD1Model.ProtectionIndicatorEffectiveDate.ToString("yyyyMMddHHmmss") + "|" + pD1Model.PlaceofWorkship + "|" + pD1Model.AdvanceDirectiveCode + "|" + pD1Model.ImmunizationRegistryStatus + "|" + pD1Model.ImmunizationRegistryStatusEffectiveDate.ToString("yyyyMMddHHmmss")
                 + "|" + pD1Model.PublicityCodeEffectiveDate.ToString("yyyyMMddHHmmss") + "|" + pD1Model.MilitaryBranch + "|" + pD1Model.MilitaryRank_Grade + "|" + pD1Model.MilitaryStatus;

            Debug.WriteLine("pd1_message: " + pd1_message);

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


            PD1Model pD1Model = new PD1Model();
            pD1Model.LivingDependency = "U";
            pD1Model.LivingArrangement = "A";
            pD1Model.PatientPrimaryFacility = "Facility2";
            pD1Model.PatientPrimaryCareProviderName_ID_No = "2";
            pD1Model.StudentIndicator = "F";
            pD1Model.Handicap = "";
            pD1Model.LivingWillCode = "I";
            pD1Model.OrganDonorCode = "F";
            pD1Model.SeparateBill = "N";
            pD1Model.DuplicatePatient = "No";
            pD1Model.PublicityCode = "U";
            pD1Model.ProtectionIndicator = "Y";
            pD1Model.ProtectionIndicatorEffectiveDate = DateTime.Now;
            pD1Model.PlaceofWorkship = "";
            pD1Model.AdvanceDirectiveCode = "N";
            pD1Model.ImmunizationRegistryStatus = "A";
            pD1Model.ImmunizationRegistryStatusEffectiveDate = DateTime.Now;
            pD1Model.PublicityCodeEffectiveDate = DateTime.Now;
            pD1Model.MilitaryBranch = "AUSA";
            pD1Model.MilitaryRank_Grade = "E1... E9";
            pD1Model.MilitaryStatus = "RET";


            string pd1_message = "PD1|";
            pd1_message = pd1_message + pD1Model.LivingDependency + "|" + pD1Model.LivingArrangement + "|" + pD1Model.PatientPrimaryFacility + "|" + pD1Model.PatientPrimaryCareProviderName_ID_No + "|" + pD1Model.StudentIndicator + "|" + pD1Model.Handicap + "|" + pD1Model.LivingWillCode
                 + "|" + pD1Model.OrganDonorCode + "|" + pD1Model.SeparateBill + "|" + pD1Model.DuplicatePatient + "|" + pD1Model.PublicityCode + "|" + pD1Model.ProtectionIndicator
                 + "|" + pD1Model.ProtectionIndicatorEffectiveDate.ToString("yyyyMMddHHmmss") + "|" + pD1Model.PlaceofWorkship + "|" + pD1Model.AdvanceDirectiveCode + "|" + pD1Model.ImmunizationRegistryStatus + "|" + pD1Model.ImmunizationRegistryStatusEffectiveDate.ToString("yyyyMMddHHmmss")
                 + "|" + pD1Model.PublicityCodeEffectiveDate.ToString("yyyyMMddHHmmss") + "|" + pD1Model.MilitaryBranch + "|" + pD1Model.MilitaryRank_Grade + "|" + pD1Model.MilitaryStatus;

            Debug.WriteLine("pd1_message: " + pd1_message);

        }


        private void CreateGT1Segment(MessageModel aDTMessageModel)
        {
            GT1Model gt1Model = new GT1Model();
            gt1Model.SetID = 263;
            gt1Model.GuarantorNumber = 515;
            gt1Model.familyname = "FamName";
            gt1Model.givenname = "GivName";
            gt1Model.middleinitial = "asd";
            gt1Model.GuarantorName = gt1Model.familyname + "^" + gt1Model.givenname + "^" + gt1Model.middleinitial;
            gt1Model.GuarantorSpouseName = "Spousename";

            gt1Model.streetaddress = "st. 2";
            gt1Model.otherdesignation = "Duck";
            gt1Model.city = "kota";
            gt1Model.stateorprovince = "Province6";
            gt1Model.ziporpostalcode = "15426";
            gt1Model.country = "Canada";
            gt1Model.GuarantorAddress = gt1Model.streetaddress = "st. 2" + "^" + gt1Model.otherdesignation + "^" + gt1Model.city + "^" + gt1Model.stateorprovince + "^" + gt1Model.ziporpostalcode + "^" + gt1Model.country;

            gt1Model.GuarantorPhNumHome = "527444225";
            gt1Model.GuarantorPhNumBusiness = "45815561";
            gt1Model.GuarantorDateTimeofBirth = DateTime.Now;
            gt1Model.GuarantorSex = "M";
            gt1Model.GuarantorType = "";
            gt1Model.GuarantorRelationship = "relation";
            gt1Model.GuarantorSSN = "15425";
            gt1Model.GuarantorDateBegin = DateTime.Now;
            gt1Model.GuarantorDateEnd = DateTime.Now;
            gt1Model.GuarantorPriority = "32";

            gt1Model.GuarantorEmployerName = "EmployerName";

            gt1Model.streetaddress = "address st.";
            gt1Model.otherdesignation = "place";
            gt1Model.city = "canada";
            gt1Model.stateorprovince = "state3";
            gt1Model.ziporpostalcode = "15122215";
            gt1Model.country = "canada";
            gt1Model.GuarantorEmployerAddress = gt1Model.streetaddress + "^" + gt1Model.otherdesignation + "^" + gt1Model.city + "^" + gt1Model.stateorprovince + "^" + gt1Model.ziporpostalcode + "^" + gt1Model.country;

            gt1Model.GuarantorEmployPhoneNumber = 63546351;
            gt1Model.GuarantorEmployeeIDNumber = "24754";
            gt1Model.GuarantorEmployementStatus = "PT";
            gt1Model.GuarantorOrganization = "ORG2";


            string gt1_message = "GT1|";

            gt1_message = gt1_message + gt1Model.SetID + "|" + gt1Model.GuarantorNumber + "|" + gt1Model.GuarantorName + "|" + gt1Model.GuarantorSpouseName + "|" + gt1Model.GuarantorAddress + "|" + gt1Model.GuarantorPhNumHome + "|" + gt1Model.GuarantorPhNumBusiness
              + "|" + gt1Model.GuarantorDateTimeofBirth + "|" + gt1Model.GuarantorSex + "|" + gt1Model.GuarantorType + "|" + gt1Model.GuarantorRelationship + "|" + gt1Model.GuarantorSSN + "|" + gt1Model.GuarantorDateBegin + "|" + gt1Model.GuarantorDateEnd
              + "|" + gt1Model.GuarantorPriority + "|" + gt1Model.GuarantorEmployerName + "|" + gt1Model.GuarantorEmployerAddress + "|" + gt1Model.GuarantorEmployPhoneNumber + "|" + gt1Model.GuarantorEmployeeIDNumber + "|" + gt1Model.GuarantorEmployementStatus
              + "|" + gt1Model.GuarantorOrganization;
            Debug.WriteLine("gt1_message: " + gt1_message);
        }

        private void CreateGT1SegmentNEW(HL7Model aDTMessageModel)
        {
            GT1Model gt1Model = new GT1Model();
            gt1Model.SetID = 263;
            gt1Model.GuarantorNumber = 515;
            gt1Model.familyname = "FamName";
            gt1Model.givenname = "GivName";
            gt1Model.middleinitial = "asd";
            gt1Model.GuarantorName = gt1Model.familyname + "^" + gt1Model.givenname + "^" + gt1Model.middleinitial;
            gt1Model.GuarantorSpouseName = "Spousename";

            gt1Model.streetaddress = "st. 2";
            gt1Model.otherdesignation = "Duck";
            gt1Model.city = "kota";
            gt1Model.stateorprovince = "Province6";
            gt1Model.ziporpostalcode = "15426";
            gt1Model.country = "Canada";
            gt1Model.GuarantorAddress = gt1Model.streetaddress = "st. 2" + "^" + gt1Model.otherdesignation + "^" + gt1Model.city + "^" + gt1Model.stateorprovince + "^" + gt1Model.ziporpostalcode + "^" + gt1Model.country;

            gt1Model.GuarantorPhNumHome = "527444225";
            gt1Model.GuarantorPhNumBusiness = "45815561";
            gt1Model.GuarantorDateTimeofBirth = DateTime.Now;
            gt1Model.GuarantorSex = "M";
            gt1Model.GuarantorType = "";
            gt1Model.GuarantorRelationship = "relation";
            gt1Model.GuarantorSSN = "15425";
            gt1Model.GuarantorDateBegin = DateTime.Now;
            gt1Model.GuarantorDateEnd = DateTime.Now;
            gt1Model.GuarantorPriority = "32";

            gt1Model.GuarantorEmployerName = "EmployerName";

            gt1Model.streetaddress = "address st.";
            gt1Model.otherdesignation = "place";
            gt1Model.city = "canada";
            gt1Model.stateorprovince = "state3";
            gt1Model.ziporpostalcode = "15122215";
            gt1Model.country = "canada";
            gt1Model.GuarantorEmployerAddress = gt1Model.streetaddress + "^" + gt1Model.otherdesignation + "^" + gt1Model.city + "^" + gt1Model.stateorprovince + "^" + gt1Model.ziporpostalcode + "^" + gt1Model.country;

            gt1Model.GuarantorEmployPhoneNumber = 63546351;
            gt1Model.GuarantorEmployeeIDNumber = "24754";
            gt1Model.GuarantorEmployementStatus = "PT";
            gt1Model.GuarantorOrganization = "ORG2";


            string gt1_message = "GT1|";

            gt1_message = gt1_message + gt1Model.SetID + "|" + gt1Model.GuarantorNumber + "|" + gt1Model.GuarantorName + "|" + gt1Model.GuarantorSpouseName + "|" + gt1Model.GuarantorAddress + "|" + gt1Model.GuarantorPhNumHome + "|" + gt1Model.GuarantorPhNumBusiness
              + "|" + gt1Model.GuarantorDateTimeofBirth + "|" + gt1Model.GuarantorSex + "|" + gt1Model.GuarantorType + "|" + gt1Model.GuarantorRelationship + "|" + gt1Model.GuarantorSSN + "|" + gt1Model.GuarantorDateBegin + "|" + gt1Model.GuarantorDateEnd
              + "|" + gt1Model.GuarantorPriority + "|" + gt1Model.GuarantorEmployerName + "|" + gt1Model.GuarantorEmployerAddress + "|" + gt1Model.GuarantorEmployPhoneNumber + "|" + gt1Model.GuarantorEmployeeIDNumber + "|" + gt1Model.GuarantorEmployementStatus
              + "|" + gt1Model.GuarantorOrganization;
            Debug.WriteLine("gt1_message: " + gt1_message);
        }
        private void CreateNk1Segment(MessageModel aDTMessageModel)
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

            NK1Model nK1Model = new NK1Model();
            nK1Model.SetID = 511;

            nK1Model.familyname = "Doe";

            nK1Model.givenname = "John";

            nK1Model.Name = nK1Model.familyname + "^" + nK1Model.givenname;
            nK1Model.Relationship = "CHD";

            nK1Model.streetaddress = "";
            nK1Model.otherdesignation = "";
            nK1Model.city = "";
            nK1Model.stateorprovince = "";
            nK1Model.ziporpostalcode = "";
            nK1Model.Address = nK1Model.streetaddress + "^" + nK1Model.otherdesignation + "^" + nK1Model.city + "^" + nK1Model.stateorprovince + "^" + nK1Model.ziporpostalcode;

            nK1Model.PhoneNumber = 27883518;
            nK1Model.BusinesPhoneNumber = 464584455;
            nK1Model.ContactRole = "C";
            nK1Model.StartDate = DateTime.Now;
            nK1Model.EndDate = DateTime.Now;
            nK1Model.NextofKin_AssociatedPartiesJobTitle = "Job5";
            nK1Model.NextofKin_AssociatedPartiesJobCode_Class = "3";

            nK1Model.NextofKin_AssociatedPartiesEmployeeNumber = "5684388";
            nK1Model.OrganizationName = "REFR";
            nK1Model.MaritalStatus = "U";
            nK1Model.AdministrativeSex = "M";
            nK1Model.Date_TimeofBirth = DateTime.Now;
            nK1Model.LivingDependency = "C";
            nK1Model.AmbulatoryStatus = "A0";
            nK1Model.Citizenship = "CAN";
            nK1Model.PrimaryLanguage = "English";
            nK1Model.LivingArrangement = "A";
            nK1Model.PublicityCode = "F";
            nK1Model.ProtectionIndicator = "N";
            nK1Model.StudentIndicator = "P";
            nK1Model.Religion = "ABC";
            nK1Model.MothersMaidenName = "asiydbo ouabsd";
            nK1Model.Nationality = "Canadian";
            nK1Model.EthnicGroup = "H";
            nK1Model.ContactReason = "Reasons";
            nK1Model.ContactPersonName = "John mily";
            nK1Model.ContactPersonTelephoneNumber = 51335156;
            nK1Model.ContactPersonAddress = "Address..";
            nK1Model.NextofKin_AssociatedPartyIdentifiers = "";
            nK1Model.JobStatus = "P";
            nK1Model.Race = "1002-5";
            nK1Model.Handicap = "";
            nK1Model.ContactPersonSocialSecutityNumber = 16341382;




            string NK1Message = "NK1|";

            NK1Message = NK1Message + nK1Model.SetID + "|" + nK1Model.Name + "|" + nK1Model.Relationship + "|" + nK1Model.Address + "|" + nK1Model.PhoneNumber + "|" + nK1Model.BusinesPhoneNumber + "|" + nK1Model.ContactRole + "|" + nK1Model.StartDate.ToString("yyyyMMddHHmmss")
                     + "|" + nK1Model.EndDate.ToString("yyyyMMddHHmmss") + "|" + nK1Model.NextofKin_AssociatedPartiesJobTitle + "|" + nK1Model.NextofKin_AssociatedPartiesJobCode_Class + "|" + nK1Model.NextofKin_AssociatedPartiesEmployeeNumber + "|" + nK1Model.OrganizationName + "|" + nK1Model.MaritalStatus
                     + "|" + nK1Model.AdministrativeSex + "|" + nK1Model.Date_TimeofBirth.ToString("yyyyMMddHHmmss") + "|" + nK1Model.LivingDependency + "|" + nK1Model.AmbulatoryStatus + "|" + nK1Model.Citizenship + "|" + nK1Model.PrimaryLanguage + "|" + nK1Model.LivingArrangement
                     + "|" + nK1Model.PublicityCode + "|" + nK1Model.ProtectionIndicator + "|" + nK1Model.StudentIndicator + "|" + nK1Model.Religion + "|" + nK1Model.MothersMaidenName + "|" + nK1Model.Nationality + "|" + nK1Model.EthnicGroup
                      + "|" + nK1Model.ContactReason + "|" + nK1Model.ContactPersonName + "|" + nK1Model.ContactPersonTelephoneNumber + "|" + nK1Model.ContactPersonAddress + "|" + nK1Model.NextofKin_AssociatedPartyIdentifiers + "|" + nK1Model.JobStatus
                      + "|" + nK1Model.Race + "|" + nK1Model.Handicap + "|" + nK1Model.ContactPersonSocialSecutityNumber;


            Debug.WriteLine("NK1Message: " + NK1Message);

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

            NK1Model nK1Model = new NK1Model();
            nK1Model.SetID = 511;

            nK1Model.familyname = "Doe";

            nK1Model.givenname = "John";

            nK1Model.Name = nK1Model.familyname + "^" + nK1Model.givenname;
            nK1Model.Relationship = "CHD";

            nK1Model.streetaddress = "";
            nK1Model.otherdesignation = "";
            nK1Model.city = "";
            nK1Model.stateorprovince = "";
            nK1Model.ziporpostalcode = "";
            nK1Model.Address = nK1Model.streetaddress + "^" + nK1Model.otherdesignation + "^" + nK1Model.city + "^" + nK1Model.stateorprovince + "^" + nK1Model.ziporpostalcode;

            nK1Model.PhoneNumber = 27883518;
            nK1Model.BusinesPhoneNumber = 464584455;
            nK1Model.ContactRole = "C";
            nK1Model.StartDate = DateTime.Now;
            nK1Model.EndDate = DateTime.Now;
            nK1Model.NextofKin_AssociatedPartiesJobTitle = "Job5";
            nK1Model.NextofKin_AssociatedPartiesJobCode_Class = "3";

            nK1Model.NextofKin_AssociatedPartiesEmployeeNumber = "5684388";
            nK1Model.OrganizationName = "REFR";
            nK1Model.MaritalStatus = "U";
            nK1Model.AdministrativeSex = "M";
            nK1Model.Date_TimeofBirth = DateTime.Now;
            nK1Model.LivingDependency = "C";
            nK1Model.AmbulatoryStatus = "A0";
            nK1Model.Citizenship = "CAN";
            nK1Model.PrimaryLanguage = "English";
            nK1Model.LivingArrangement = "A";
            nK1Model.PublicityCode = "F";
            nK1Model.ProtectionIndicator = "N";
            nK1Model.StudentIndicator = "P";
            nK1Model.Religion = "ABC";
            nK1Model.MothersMaidenName = "asiydbo ouabsd";
            nK1Model.Nationality = "Canadian";
            nK1Model.EthnicGroup = "H";
            nK1Model.ContactReason = "Reasons";
            nK1Model.ContactPersonName = "John mily";
            nK1Model.ContactPersonTelephoneNumber = 51335156;
            nK1Model.ContactPersonAddress = "Address..";
            nK1Model.NextofKin_AssociatedPartyIdentifiers = "";
            nK1Model.JobStatus = "P";
            nK1Model.Race = "1002-5";
            nK1Model.Handicap = "";
            nK1Model.ContactPersonSocialSecutityNumber = 16341382;




            string NK1Message = "NK1|";

            NK1Message = NK1Message + nK1Model.SetID + "|" + nK1Model.Name + "|" + nK1Model.Relationship + "|" + nK1Model.Address + "|" + nK1Model.PhoneNumber + "|" + nK1Model.BusinesPhoneNumber + "|" + nK1Model.ContactRole + "|" + nK1Model.StartDate.ToString("yyyyMMddHHmmss")
                     + "|" + nK1Model.EndDate.ToString("yyyyMMddHHmmss") + "|" + nK1Model.NextofKin_AssociatedPartiesJobTitle + "|" + nK1Model.NextofKin_AssociatedPartiesJobCode_Class + "|" + nK1Model.NextofKin_AssociatedPartiesEmployeeNumber + "|" + nK1Model.OrganizationName + "|" + nK1Model.MaritalStatus
                     + "|" + nK1Model.AdministrativeSex + "|" + nK1Model.Date_TimeofBirth.ToString("yyyyMMddHHmmss") + "|" + nK1Model.LivingDependency + "|" + nK1Model.AmbulatoryStatus + "|" + nK1Model.Citizenship + "|" + nK1Model.PrimaryLanguage + "|" + nK1Model.LivingArrangement
                     + "|" + nK1Model.PublicityCode + "|" + nK1Model.ProtectionIndicator + "|" + nK1Model.StudentIndicator + "|" + nK1Model.Religion + "|" + nK1Model.MothersMaidenName + "|" + nK1Model.Nationality + "|" + nK1Model.EthnicGroup
                      + "|" + nK1Model.ContactReason + "|" + nK1Model.ContactPersonName + "|" + nK1Model.ContactPersonTelephoneNumber + "|" + nK1Model.ContactPersonAddress + "|" + nK1Model.NextofKin_AssociatedPartyIdentifiers + "|" + nK1Model.JobStatus
                      + "|" + nK1Model.Race + "|" + nK1Model.Handicap + "|" + nK1Model.ContactPersonSocialSecutityNumber;


            Debug.WriteLine("NK1Message: " + NK1Message);

        }


        private void CreateIn1Segment(MessageModel aDTMessageModel)
        {
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


            string IN1Message = "IN1|";

            IN1Message = IN1Message + In1Model.SetID + "|" + In1Model.InsurancePlanID + "|" + In1Model.InsuranceCompanyID + "|" + In1Model.InsuranceCompanyName + "|" + In1Model.InsuranceCompanyAddress + "|" + In1Model.InsuranceCoContactPpers + "|" + In1Model.InsuranceCoPhoneNuber + "|" + In1Model.GroupNumber
                     + "|" + In1Model.GroupName + "|" + In1Model.InsuredGroupEmployerID + "|" + In1Model.InsuredGroupEmpName + "|" + In1Model.PlanEffectiveDate.ToString("yyyyMMddHHmmss") + "|" + In1Model.PlanExpirationDate.ToString("yyyyMMddHHmmss") + "|" + In1Model.AuthorizationInformation
                     + "|" + In1Model.PlanType + "|" + In1Model.NameOfInsured + "|" + In1Model.InsuredRelationshipToPatient + "|" + In1Model.InsuredDateOfBirth.ToString("yyyyMMddHHmmss") + "|" + In1Model.InsuredAddress + "|" + In1Model.AssignmentOfBenefits + "|" + In1Model.CoordinationOfBenefits
                     + "|" + In1Model.CoordofBenPriority + "|" + In1Model.NoticeofAdmissionCode + "|" + In1Model.NoticeofAdmissionDate.ToString("yyyyMMddHHmmss") + "|" + In1Model.ReptofEligibilityCode + "|" + In1Model.ReptofEligibilityDate.ToString("yyyyMMddHHmmss") + "|" + In1Model.ReleaseInfoCode + "|" + In1Model.PreAdmitCert_PAC
                      + "|" + In1Model.VerificationDateTime.ToString("yyyyMMddHHmmss") + "|" + In1Model.VerificationBy + "|" + In1Model.TypeofAgreementCode + "|" + In1Model.BillingStatus + "|" + In1Model.LifeTimeReverseDays + "|" + In1Model.DelayBeforeLifeTimeReverseDays
                      + "|" + In1Model.CompanyPlanCode + "|" + In1Model.PolicyNumber + "|" + In1Model.PolicyDeductible + "|" + In1Model.PolicyLimitAmount + "|" + In1Model.PolicyLimitDays + "|" + In1Model.RoomRate_SemiPrivate + "|" + In1Model.RoomRate_Private
                      + "|" + In1Model.InsuredEmploymentStatus + "|" + In1Model.InsuredSex + "|" + In1Model.InsuredEmployerAddress + "|" + In1Model.VerificationStatus + "|" + In1Model.PriorInsurancePlanID + "|" + In1Model.CoverageType
                      + "|" + In1Model.Handicap + "|" + In1Model.InsuredIDNumber;


            Debug.WriteLine("IN1Message: " + IN1Message);


        }

        private void CreateIn1SegmentNEW(HL7Model aDTMessageModel)
        {
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


            string IN1Message = "IN1|";

            IN1Message = IN1Message + In1Model.SetID + "|" + In1Model.InsurancePlanID + "|" + In1Model.InsuranceCompanyID + "|" + In1Model.InsuranceCompanyName + "|" + In1Model.InsuranceCompanyAddress + "|" + In1Model.InsuranceCoContactPpers + "|" + In1Model.InsuranceCoPhoneNuber + "|" + In1Model.GroupNumber
                     + "|" + In1Model.GroupName + "|" + In1Model.InsuredGroupEmployerID + "|" + In1Model.InsuredGroupEmpName + "|" + In1Model.PlanEffectiveDate.ToString("yyyyMMddHHmmss") + "|" + In1Model.PlanExpirationDate.ToString("yyyyMMddHHmmss") + "|" + In1Model.AuthorizationInformation
                     + "|" + In1Model.PlanType + "|" + In1Model.NameOfInsured + "|" + In1Model.InsuredRelationshipToPatient + "|" + In1Model.InsuredDateOfBirth.ToString("yyyyMMddHHmmss") + "|" + In1Model.InsuredAddress + "|" + In1Model.AssignmentOfBenefits + "|" + In1Model.CoordinationOfBenefits
                     + "|" + In1Model.CoordofBenPriority + "|" + In1Model.NoticeofAdmissionCode + "|" + In1Model.NoticeofAdmissionDate.ToString("yyyyMMddHHmmss") + "|" + In1Model.ReptofEligibilityCode + "|" + In1Model.ReptofEligibilityDate.ToString("yyyyMMddHHmmss") + "|" + In1Model.ReleaseInfoCode + "|" + In1Model.PreAdmitCert_PAC
                      + "|" + In1Model.VerificationDateTime.ToString("yyyyMMddHHmmss") + "|" + In1Model.VerificationBy + "|" + In1Model.TypeofAgreementCode + "|" + In1Model.BillingStatus + "|" + In1Model.LifeTimeReverseDays + "|" + In1Model.DelayBeforeLifeTimeReverseDays
                      + "|" + In1Model.CompanyPlanCode + "|" + In1Model.PolicyNumber + "|" + In1Model.PolicyDeductible + "|" + In1Model.PolicyLimitAmount + "|" + In1Model.PolicyLimitDays + "|" + In1Model.RoomRate_SemiPrivate + "|" + In1Model.RoomRate_Private
                      + "|" + In1Model.InsuredEmploymentStatus + "|" + In1Model.InsuredSex + "|" + In1Model.InsuredEmployerAddress + "|" + In1Model.VerificationStatus + "|" + In1Model.PriorInsurancePlanID + "|" + In1Model.CoverageType
                      + "|" + In1Model.Handicap + "|" + In1Model.InsuredIDNumber;


            Debug.WriteLine("IN1Message: " + IN1Message);


        }



        private void CreateIn2Segment(MessageModel aDTMessageModel)
        {

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



            string IN2Message = "IN2|";

            IN2Message = IN2Message + In2Model.InsuredEmployeeID + "|" + In2Model.InsuredSocialSecurityNumber + "|" + In2Model.InsuredEmployerName + "|" + In2Model.EmployerInformationData + "|" + In2Model.MailClaimParty + "|" + In2Model.MedicareHealthInsCardNumber + "|" + In2Model.MedicaidCaseName + "|" + In2Model.MedicaidCaseNumber + "|" + In2Model.CampusSponsorName
                + "|" + In2Model.CampusIDNumber + "|" + In2Model.DependentofCampusRecipient + "|" + In2Model.CampusOrganization + "|" + In2Model.CampusStation + "|" + In2Model.CampusService + "|" + In2Model.CampusRank_Grade + "|" + In2Model.CampusStatus + "|" + In2Model.CampusRetireDate + "|" + In2Model.CampusNonAvailCertonFile
            + "|" + In2Model.BabyCoverage + "|" + In2Model.CombineBabyBill + "|" + In2Model.BloodDeductile + "|" + In2Model.SpecialCoverageApprovalName + "|" + In2Model.SpecialCoverageApprovalTitle + "|" + In2Model.NonCoveredInsuranceCode + "|" + In2Model.PayorID + "|" + In2Model.PayorSubscriberID + "|" + In2Model.EligibilitySource + "|" + In2Model.RoomCoverageTypeAmount
            + "|" + In2Model.PolicyTypeAmount + "|" + In2Model.DailyDeductible + "|" + In2Model.LivingDependency + "|" + In2Model.AmbulatoryStatus + "|" + In2Model.Citizenship + "|" + In2Model.PrimaryLanguage + "|" + In2Model.LivingArrangement + "|" + In2Model.PublicityIndicator + "|" + In2Model.ProtectionIndicator + "|" + In2Model.StudentIndicator + "|" + In2Model.Religion
            + "|" + In2Model.MotherMaidenName + "|" + In2Model.NationalityCode + "|" + In2Model.EthnicGroup + "|" + In2Model.MaritalStatus + "|" + In2Model.EmploymentStartDate + "|" + In2Model.EmploymentStopDate + "|" + In2Model.JobTitle + "|" + In2Model.JobCode_Class + "|" + In2Model.JobStatus + "|" + In2Model.EmployerContactPersonName + "|" + In2Model.EmployerContactPersonPhoneNumber
            + "|" + In2Model.EmployerContactReason + "|" + In2Model.InsuredContactPersonName + "|" + In2Model.InsuredContactPersonTeleNumber + "|" + In2Model.InsuredContactPersonReason + "|" + In2Model.RelationshipToPatientStartDate + "|" + In2Model.RelationshipToPatientStopDate + "|" + In2Model.InsuranceCoContactReason + "|" + In2Model.InsuranceCoContactPhoneNumber
            + "|" + In2Model.PolicyScope + "|" + In2Model.PolicySource + "|" + In2Model.PatientMemberNumber + "|" + In2Model.GuarantorRelationshipToInsured + "|" + In2Model.InsuredTelephoneNumber + "|" + In2Model.InsuredEmployerTelephoneNumber;


            Debug.WriteLine("IN2Message: " + IN2Message);

        }

        private void CreateIn2SegmentNEW(HL7Model aDTMessageModel)
        {

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



            string IN2Message = "IN2|";

            IN2Message = IN2Message + In2Model.InsuredEmployeeID + "|" + In2Model.InsuredSocialSecurityNumber + "|" + In2Model.InsuredEmployerName + "|" + In2Model.EmployerInformationData + "|" + In2Model.MailClaimParty + "|" + In2Model.MedicareHealthInsCardNumber + "|" + In2Model.MedicaidCaseName + "|" + In2Model.MedicaidCaseNumber + "|" + In2Model.CampusSponsorName
                + "|" + In2Model.CampusIDNumber + "|" + In2Model.DependentofCampusRecipient + "|" + In2Model.CampusOrganization + "|" + In2Model.CampusStation + "|" + In2Model.CampusService + "|" + In2Model.CampusRank_Grade + "|" + In2Model.CampusStatus + "|" + In2Model.CampusRetireDate + "|" + In2Model.CampusNonAvailCertonFile
            + "|" + In2Model.BabyCoverage + "|" + In2Model.CombineBabyBill + "|" + In2Model.BloodDeductile + "|" + In2Model.SpecialCoverageApprovalName + "|" + In2Model.SpecialCoverageApprovalTitle + "|" + In2Model.NonCoveredInsuranceCode + "|" + In2Model.PayorID + "|" + In2Model.PayorSubscriberID + "|" + In2Model.EligibilitySource + "|" + In2Model.RoomCoverageTypeAmount
            + "|" + In2Model.PolicyTypeAmount + "|" + In2Model.DailyDeductible + "|" + In2Model.LivingDependency + "|" + In2Model.AmbulatoryStatus + "|" + In2Model.Citizenship + "|" + In2Model.PrimaryLanguage + "|" + In2Model.LivingArrangement + "|" + In2Model.PublicityIndicator + "|" + In2Model.ProtectionIndicator + "|" + In2Model.StudentIndicator + "|" + In2Model.Religion
            + "|" + In2Model.MotherMaidenName + "|" + In2Model.NationalityCode + "|" + In2Model.EthnicGroup + "|" + In2Model.MaritalStatus + "|" + In2Model.EmploymentStartDate + "|" + In2Model.EmploymentStopDate + "|" + In2Model.JobTitle + "|" + In2Model.JobCode_Class + "|" + In2Model.JobStatus + "|" + In2Model.EmployerContactPersonName + "|" + In2Model.EmployerContactPersonPhoneNumber
            + "|" + In2Model.EmployerContactReason + "|" + In2Model.InsuredContactPersonName + "|" + In2Model.InsuredContactPersonTeleNumber + "|" + In2Model.InsuredContactPersonReason + "|" + In2Model.RelationshipToPatientStartDate + "|" + In2Model.RelationshipToPatientStopDate + "|" + In2Model.InsuranceCoContactReason + "|" + In2Model.InsuranceCoContactPhoneNumber
            + "|" + In2Model.PolicyScope + "|" + In2Model.PolicySource + "|" + In2Model.PatientMemberNumber + "|" + In2Model.GuarantorRelationshipToInsured + "|" + In2Model.InsuredTelephoneNumber + "|" + In2Model.InsuredEmployerTelephoneNumber;


            Debug.WriteLine("IN2Message: " + IN2Message);

        }
        private void CreateObxSegment(MessageModel aDTMessageModel)
        {
            /*OBX-1 Set ID - OBX,OBX-2 Value Type,OBX-3 Observation Identifier,OBX-4 Observation Sub-ID,OBX-5 Observation Value
            OBX-6 Units,OBX-7 References Range,OBX-8 Abnormal Flags,OBX-9 Probability,OBX-10 Nature of Abnormal Test,OBX-11 Observation Result Status
            OBX-12 Effective Date of Reference Range Values,OBX-13 User Defined Access Checks,OBX-14 Date/Time of the Observation,OBX-15 Producer's Reference
            OBX-16 Responsible Observer,OBX-17 Observation Method,OBX-18 Equipment Instance Identifier,OBX-19 Date/Time of the Analysis,OBX-20 Performing Organization Name
            OBX-21 Performing Organization Address,OBX-22 Performing Organization Medical Director */


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

            string obx_message = "OBX|";

            obx_message = obx_message + oBXModel.SetID + "|" + oBXModel.ValueType + "|" + oBXModel.ObservationIdentifier + "|" + oBXModel.ObservationSubID + "|" + oBXModel.ObservationValue + "|" + oBXModel.Units + "|" + oBXModel.ReferencesRange
              + "|" + oBXModel.AbnormalFlags + "|" + oBXModel.Probability + "|" + oBXModel.NatureofAbnormalTest + "|" + oBXModel.ObservationResultStatus + "|" + oBXModel.EffectiveDateofReferenceRangeValues.ToString("yyyyMMddHHmmss")
              + "|" + oBXModel.UserDefinedAccessChecks + "|" + oBXModel.DateTimeoftheObservation.ToString("yyyyMMddHHmmss") + "|" + oBXModel.ProducersReference + "|" + oBXModel.ResponsibleObserver + "|" + oBXModel.ObservationMethod
              + "|" + oBXModel.EquipmentInstanceIdentifier + "|" + oBXModel.DateTimeoftheAnalysis.ToString("yyyyMMddHHmmss") + "|" + oBXModel.PerformingOrganizationName + "|" + oBXModel.PerformingOrganizationAddress + "|" + oBXModel.PerformingOrganizationMedicalDirector;
            Debug.WriteLine("obx_message: " + obx_message);

        }


        private void CreateObxSegmentNEW(HL7Model aDTMessageModel)
        {
            /*OBX-1 Set ID - OBX,OBX-2 Value Type,OBX-3 Observation Identifier,OBX-4 Observation Sub-ID,OBX-5 Observation Value
            OBX-6 Units,OBX-7 References Range,OBX-8 Abnormal Flags,OBX-9 Probability,OBX-10 Nature of Abnormal Test,OBX-11 Observation Result Status
            OBX-12 Effective Date of Reference Range Values,OBX-13 User Defined Access Checks,OBX-14 Date/Time of the Observation,OBX-15 Producer's Reference
            OBX-16 Responsible Observer,OBX-17 Observation Method,OBX-18 Equipment Instance Identifier,OBX-19 Date/Time of the Analysis,OBX-20 Performing Organization Name
            OBX-21 Performing Organization Address,OBX-22 Performing Organization Medical Director */


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

            string obx_message = "OBX|";

            obx_message = obx_message + oBXModel.SetID + "|" + oBXModel.ValueType + "|" + oBXModel.ObservationIdentifier + "|" + oBXModel.ObservationSubID + "|" + oBXModel.ObservationValue + "|" + oBXModel.Units + "|" + oBXModel.ReferencesRange
              + "|" + oBXModel.AbnormalFlags + "|" + oBXModel.Probability + "|" + oBXModel.NatureofAbnormalTest + "|" + oBXModel.ObservationResultStatus + "|" + oBXModel.EffectiveDateofReferenceRangeValues.ToString("yyyyMMddHHmmss")
              + "|" + oBXModel.UserDefinedAccessChecks + "|" + oBXModel.DateTimeoftheObservation.ToString("yyyyMMddHHmmss") + "|" + oBXModel.ProducersReference + "|" + oBXModel.ResponsibleObserver + "|" + oBXModel.ObservationMethod
              + "|" + oBXModel.EquipmentInstanceIdentifier + "|" + oBXModel.DateTimeoftheAnalysis.ToString("yyyyMMddHHmmss") + "|" + oBXModel.PerformingOrganizationName + "|" + oBXModel.PerformingOrganizationAddress + "|" + oBXModel.PerformingOrganizationMedicalDirector;
            Debug.WriteLine("obx_message: " + obx_message);

        }
        private void CreateAl1Segment(MessageModel aDTMessageModel)
        {
            /*AL1-1 Set ID - AL1,AL1-2 Allergen Type Code,AL1-3 Allergen Code/Mnemonic/Description,AL1-4 Allergy Severity Code,AL1-5 Allergy Reaction Code
            AL1-6 Identification Date */

            AL1Model aL1Model = new AL1Model();
            aL1Model.SetID = 2;
            aL1Model.AllergenTypeCode = 1543;
            aL1Model.AllergenCode = "AL03";
            aL1Model.AllergySeverityCode = "VAL12";
            aL1Model.AllergyReactionCode = 234;
            aL1Model.IdentificationDate = DateTime.Now;
            string AL1_message = "AL1|";

            AL1_message = AL1_message + aL1Model.SetID + "|" + aL1Model.AllergenTypeCode + "|" + aL1Model.AllergenCode + "|" + aL1Model.AllergySeverityCode + "|" + aL1Model.AllergyReactionCode + "|" + aL1Model.IdentificationDate.ToString("yyyyMMddHHmmss");
            Debug.WriteLine("AL1_message: " + AL1_message);
        }

        private void CreateAl1SegmentNEW(HL7Model aDTMessageModel)
        {
            /*AL1-1 Set ID - AL1,AL1-2 Allergen Type Code,AL1-3 Allergen Code/Mnemonic/Description,AL1-4 Allergy Severity Code,AL1-5 Allergy Reaction Code
            AL1-6 Identification Date */

            AL1Model aL1Model = new AL1Model();
            aL1Model.SetID = 2;
            aL1Model.AllergenTypeCode = 1543;
            aL1Model.AllergenCode = "AL03";
            aL1Model.AllergySeverityCode = "VAL12";
            aL1Model.AllergyReactionCode = 234;
            aL1Model.IdentificationDate = DateTime.Now;
            string AL1_message = "AL1|";

            AL1_message = AL1_message + aL1Model.SetID + "|" + aL1Model.AllergenTypeCode + "|" + aL1Model.AllergenCode + "|" + aL1Model.AllergySeverityCode + "|" + aL1Model.AllergyReactionCode + "|" + aL1Model.IdentificationDate.ToString("yyyyMMddHHmmss");
            Debug.WriteLine("AL1_message: " + AL1_message);
        }
        private void CreateDg1Segment(MessageModel aDTMessageModel)
        {
            /*DG1-1 Set ID - DG1,DG1-2 Diagnosis Coding Method,DG1-3 Diagnosis Code - DG1,DG1-4 Diagnosis Description,DG1-5 Diagnosis Date/Time
            DG1-6 Diagnosis Type,DG1-7 Major Diagnostic Category,DG1-8 Diagnostic Related Group,DG1-9 DRG Approval Indicator,DG1-10 DRG Grouper Review Code
            DG1-11 Outlier Type,DG1-12 Outlier Days,DG1-13 Outlier Cost,DG1-14 Grouper Version And Type,DG1-15 Diagnosis Priority
            DG1-16 Diagnosing Clinician,DG1-17 Diagnosis Classification,DG1-18 Confidential Indicator,DG1-19 Attestation Date/Time
            DG1-20 Diagnosis Identifier,DG1-21 Diagnosis Action Code */

            DG1Model dG1Model = new DG1Model();
            dG1Model.SetID = 263;
            dG1Model.DiagnosisCodingMethod = "AD";
            dG1Model.DiagnosisCode = 55;
            dG1Model.DiagnosisDescription = 15;
            dG1Model.DiagnosisDateTime = DateTime.Now;
            dG1Model.DiagnosisType = "Unit3";
            dG1Model.MajorDiagnosticCategory = "cachj kasb";
            dG1Model.DiagnosticRelatedGroup = "A";
            dG1Model.DRGApprovalIndicator = "Probability2";
            dG1Model.DRGGrouperReviewCode = "B";
            dG1Model.OutlierType = "status ok";
            dG1Model.OutlierDays = "5";
            dG1Model.OutlierCost = "Checks";
            dG1Model.GrouperVersionAndType = "01";
            dG1Model.DiagnosisPriority = "Reference";
            dG1Model.DiagnosingClinician = "Observer1";
            dG1Model.DiagnosisClassification = "Method3";
            dG1Model.ConfidentialIndicator = "N";
            dG1Model.AttestationDateTime = DateTime.Now;
            dG1Model.DiagnosisIdentifier = "Identifier2";
            dG1Model.DiagnosisActionCode = "A";


            string DG1_message = "DG1|";

            DG1_message = DG1_message + dG1Model.SetID + "|" + dG1Model.DiagnosisCodingMethod + "|" + dG1Model.DiagnosisCode
                + "|" + dG1Model.DiagnosisDescription + "|" + dG1Model.DiagnosisDateTime.ToString("yyyyMMddHHmmss")
                + "|" + dG1Model.DiagnosisType + "|" + dG1Model.MajorDiagnosticCategory + "|" + dG1Model.DiagnosticRelatedGroup + "|" + dG1Model.DRGApprovalIndicator
              + "|" + dG1Model.DRGGrouperReviewCode + "|" + dG1Model.OutlierType + "|" + dG1Model.OutlierDays
              + "|" + dG1Model.OutlierCost + "|" + dG1Model.GrouperVersionAndType + "|" + dG1Model.DiagnosisPriority
              + "|" + dG1Model.DiagnosingClinician + "|" + dG1Model.DiagnosisClassification + "|" + dG1Model.ConfidentialIndicator + "|" + dG1Model.AttestationDateTime.ToString("yyyyMMddHHmmss")
              + "|" + dG1Model.DiagnosisIdentifier + "|" + dG1Model.DiagnosisActionCode;
            Debug.WriteLine("DG1_message: " + DG1_message);

        }

        private void CreateDg1SegmentNEW(HL7Model aDTMessageModel)
        {
            /*DG1-1 Set ID - DG1,DG1-2 Diagnosis Coding Method,DG1-3 Diagnosis Code - DG1,DG1-4 Diagnosis Description,DG1-5 Diagnosis Date/Time
            DG1-6 Diagnosis Type,DG1-7 Major Diagnostic Category,DG1-8 Diagnostic Related Group,DG1-9 DRG Approval Indicator,DG1-10 DRG Grouper Review Code
            DG1-11 Outlier Type,DG1-12 Outlier Days,DG1-13 Outlier Cost,DG1-14 Grouper Version And Type,DG1-15 Diagnosis Priority
            DG1-16 Diagnosing Clinician,DG1-17 Diagnosis Classification,DG1-18 Confidential Indicator,DG1-19 Attestation Date/Time
            DG1-20 Diagnosis Identifier,DG1-21 Diagnosis Action Code */

            DG1Model dG1Model = new DG1Model();
            dG1Model.SetID = 263;
            dG1Model.DiagnosisCodingMethod = "AD";
            dG1Model.DiagnosisCode = 55;
            dG1Model.DiagnosisDescription = 15;
            dG1Model.DiagnosisDateTime = DateTime.Now;
            dG1Model.DiagnosisType = "Unit3";
            dG1Model.MajorDiagnosticCategory = "cachj kasb";
            dG1Model.DiagnosticRelatedGroup = "A";
            dG1Model.DRGApprovalIndicator = "Probability2";
            dG1Model.DRGGrouperReviewCode = "B";
            dG1Model.OutlierType = "status ok";
            dG1Model.OutlierDays = "5";
            dG1Model.OutlierCost = "Checks";
            dG1Model.GrouperVersionAndType = "01";
            dG1Model.DiagnosisPriority = "Reference";
            dG1Model.DiagnosingClinician = "Observer1";
            dG1Model.DiagnosisClassification = "Method3";
            dG1Model.ConfidentialIndicator = "N";
            dG1Model.AttestationDateTime = DateTime.Now;
            dG1Model.DiagnosisIdentifier = "Identifier2";
            dG1Model.DiagnosisActionCode = "A";


            string DG1_message = "DG1|";

            DG1_message = DG1_message + dG1Model.SetID + "|" + dG1Model.DiagnosisCodingMethod + "|" + dG1Model.DiagnosisCode
                + "|" + dG1Model.DiagnosisDescription + "|" + dG1Model.DiagnosisDateTime.ToString("yyyyMMddHHmmss")
                + "|" + dG1Model.DiagnosisType + "|" + dG1Model.MajorDiagnosticCategory + "|" + dG1Model.DiagnosticRelatedGroup + "|" + dG1Model.DRGApprovalIndicator
              + "|" + dG1Model.DRGGrouperReviewCode + "|" + dG1Model.OutlierType + "|" + dG1Model.OutlierDays
              + "|" + dG1Model.OutlierCost + "|" + dG1Model.GrouperVersionAndType + "|" + dG1Model.DiagnosisPriority
              + "|" + dG1Model.DiagnosingClinician + "|" + dG1Model.DiagnosisClassification + "|" + dG1Model.ConfidentialIndicator + "|" + dG1Model.AttestationDateTime.ToString("yyyyMMddHHmmss")
              + "|" + dG1Model.DiagnosisIdentifier + "|" + dG1Model.DiagnosisActionCode;
            Debug.WriteLine("DG1_message: " + DG1_message);

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
