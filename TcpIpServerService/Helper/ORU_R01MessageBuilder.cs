using NHapi.Model.V23.Message;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperHL7
{
    internal class ORU_R01MessageBuilder
    {
        Logger Logger = LogManager.GetCurrentClassLogger();
        private ORU_R01 _Message;

        public ORU_R01 Build(MessageModel aDTMessageModel)
        {
            var currentDateTimeString = GetCurrentTimeStamp();
            _Message = new ORU_R01();

            CreateMshSegment(currentDateTimeString, aDTMessageModel);
            CreatePidSegment(aDTMessageModel);
            CreatePv1Segment(aDTMessageModel);
            CreateOrcSegment(aDTMessageModel);
            CreateObrSegment(aDTMessageModel);
            CreateObxSegment(aDTMessageModel);
            return _Message;
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

        private void CreateMshSegment(string currentDateTimeString, MessageModel aDTMessageModel)
        {
            //var mshSegment = _Message.MSH;
            //mshSegment.FieldSeparator.Value = "|";
            //mshSegment.EncodingCharacters.Value = "^~\\&";
            //mshSegment.SendingApplication.NamespaceID.Value = aDTMessageModel.SendingApplication;
            //mshSegment.SendingFacility.NamespaceID.Value = aDTMessageModel.SendingFacility;
            //mshSegment.ReceivingApplication.NamespaceID.Value = aDTMessageModel.ReceivingApplication;
            //mshSegment.ReceivingFacility.NamespaceID.Value = aDTMessageModel.ReceivingFacility;
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

        private void CreateOrcSegment(MessageModel aDTMessageModel)
        {
            /*
            ORC-1 Order Control = XO,ORC-2 Placer Order Number,ORC-3 Filler Order Number,ORC-4 Placer Group Number,ORC-5 Order Status,ORC-6 Response Flag
            ORC-7 Quantity/Timing,ORC-7.1 quantity,ORC-7.2 interval,ORC-7.3 duration,ORC-7.4 start date/time,ORC-7.5 end date/time,ORC-7.6 priority,
            ORC-8 Parent,ORC-9 Date/time of Transaction,ORC-10 Entered by,ORC-10.1 ID number(ST),ORC-10.2 family+last name,ORC-10.3 given name,ORC-11 Verified by,
            ORC-12 Ordering Provider,ORC-12.1 ID number(ST),ORC-12.2 family+last name,ORC-12.3 given name,
            ORC-13 Enterer's Location,ORC-13.1 point of care,ORC-13.2 room,ORC-13.3 bed,ORC-13.4 facility(HD),ORC-13.5 location status,ORC-13.6 person location type,ORC-13.7 building,
            ORC-13.8 floor,ORC-13.9 Location description,ORC-14 Call Back Phone Number,ORC-14.1 [(999)]999-9999[X9999][C any text],ORC-14.2 telecommunication use code, 
            ORC-15 Order Effective Date/time,ORC-16 Order Control Code Reason,ORC-17 Entering Organization,ORC-17.1 identifier,ORC-17.2 text,
            ORC-18 Entering Device,ORC-19 Action by,ORC-20 Advanced Beneficiary Notice Code,ORC-21 Ordering Facility Name,ORC-22 Ordering Facility Address,ORC-23 Ordering Facility Phone Number,
            ORC-24 Ordering Provider Address,ORC-24.1 street address,ORC-24.2 other designation,ORC-24.3 city,ORC-24.4 state or province,ORC-24.5 zip or postal code,
            ORC-24.6 country,ORC-24.7 address type,ORC-24.8 other geographic designation
             */

            Logger.Info("At CreateOrcSegmentNEW STEP1");
            ORM_ORCModel ORCModel = new ORM_ORCModel();
            ORCModel.OrderControl = aDTMessageModel.OrderControl;
            ORCModel.PlacerOrderNumber = aDTMessageModel.PlacerOrderNumber;
            ORCModel.FillerOrderNumber = aDTMessageModel.FillerOrderNumber;
            ORCModel.PlacerGroupNumber = aDTMessageModel.PlacerGroupNumber;
            ORCModel.OrderStatus = aDTMessageModel.OrderStatus;
            ORCModel.ResponseFlag = aDTMessageModel.ResponseFlag;

            //Quantity_Timing
            ORCModel.Quantity = int.Parse(aDTMessageModel.Quantity);
            ORCModel.Interval = int.Parse(aDTMessageModel.Interval);
            ORCModel.Duration = aDTMessageModel.Duration;
            ORCModel.StartDateTime = DateTime.Now;
            ORCModel.EndDateTime = DateTime.Now;
            ORCModel.Priority = aDTMessageModel.Priority;

            ORCModel.Quantity_Timing = ORCModel.Quantity + "^" + ORCModel.Interval + "^" + ORCModel.Duration + "^" + ORCModel.StartDateTime.ToString("yyyyMMddHHmmss") + "^" + ORCModel.EndDateTime.ToString("yyyyMMddHHmmss") + "^" + ORCModel.Priority;

            ORCModel.Parent = aDTMessageModel.Parent;
            ORCModel.DateTimeOfTransaction = DateTime.Now;


            //EnteredBy
            ORCModel.IDNumber = int.Parse(aDTMessageModel.IDNumber);
            ORCModel.FamilyLastName = aDTMessageModel.FamilyLastName;
            ORCModel.GivenName = aDTMessageModel.givenname;
            ORCModel.EnteredBy = ORCModel.IDNumber + "^" + ORCModel.FamilyLastName + "^" + ORCModel.GivenName;

            ORCModel.VerifiedBy = aDTMessageModel.VerifiedBy;


            //OrderingProvider
            ORCModel.ID_Number = int.Parse(aDTMessageModel.IDNumber2);
            ORCModel.Family_LastName = aDTMessageModel.FamilyLastName;
            ORCModel.Given_Name = aDTMessageModel.givenname;
            ORCModel.OrderingProvider = ORCModel.ID_Number + "^" + ORCModel.Family_LastName + "^" + ORCModel.Given_Name;


            //EntererLocation
            ORCModel.PointOfCare = aDTMessageModel.PointOfCare;
            ORCModel.Room = aDTMessageModel.Room;
            ORCModel.Bed = aDTMessageModel.Bed;
            ORCModel.Facility = aDTMessageModel.Facility;
            ORCModel.LocationStatus = aDTMessageModel.LocationStatus;
            ORCModel.PersonLocationType = aDTMessageModel.PersonLocationType;
            ORCModel.Building = aDTMessageModel.Building;
            ORCModel.Floor = aDTMessageModel.Floor;
            ORCModel.LocationDescription = aDTMessageModel.LocationDescription;
            ORCModel.EntererLocation = ORCModel.PointOfCare + "^" + ORCModel.Room + "^" + ORCModel.Bed + "^" + ORCModel.Facility + "^" + ORCModel.LocationStatus + "^" + ORCModel.PersonLocationType + "^" + ORCModel.Building + "^" + ORCModel.Floor + "^" + ORCModel.LocationDescription;

            //CallbackPhoneNumber
            ORCModel.PhoneNumber999 = aDTMessageModel.PhoneNumber999;
            ORCModel.TelecommunicationUseCode = aDTMessageModel.TelecommunicationUseCode;
            ORCModel.CallBackPhoneNumber = ORCModel.PhoneNumber999 + "^" + ORCModel.TelecommunicationUseCode;

            ORCModel.OrderEffectiveDatetime = DateTime.Now;
            ORCModel.OrderControlCodeReason = aDTMessageModel.OrderControlCodeReason;

            //EnteringOrganization
            ORCModel.Identifier = aDTMessageModel.Identifier;
            ORCModel.Text = aDTMessageModel.Text;
            ORCModel.EnteringOrganization = ORCModel.Identifier + "^" + ORCModel.Text;

            ORCModel.EnteringDevice = aDTMessageModel.EnteringDevice;
            ORCModel.ActionBy = aDTMessageModel.ActionBy;
            ORCModel.AdvancedBeneficiaryNoticeCode = aDTMessageModel.AdvancedBeneficiaryNoticeCode;
            ORCModel.OrderingFacilityName = aDTMessageModel.OrderingFacilityName;
            ORCModel.OrderingFacilityAddress = aDTMessageModel.OrderingFacilityAddress;
            ORCModel.OrderingFacilityPhoneNumber = int.Parse(aDTMessageModel.OrderingFacilityPhoneNumber);

            //OrderingProviderAddress
            ORCModel.StreetAddress = aDTMessageModel.streetaddress;
            ORCModel.OtherDesignation = aDTMessageModel.otherdesignation;
            ORCModel.City = aDTMessageModel.City;
            ORCModel.StateOrProvince = aDTMessageModel.StateOrProvince;
            ORCModel.ZipOrPostalCode = aDTMessageModel.ZipOrPostalCode;
            ORCModel.Country = aDTMessageModel.Country;
            ORCModel.AddressType = aDTMessageModel.AddressType;
            ORCModel.OtherGeographicDesignation = aDTMessageModel.OtherGeographicDesignation;

            ORCModel.OrderingProviderAddress = ORCModel.StreetAddress + "^" + ORCModel.OtherDesignation + "^" + ORCModel.City + "^" + ORCModel.StateOrProvince + "^" + ORCModel.ZipOrPostalCode
                + "^" + ORCModel.Country + "^" + ORCModel.AddressType + "^" + ORCModel.OtherGeographicDesignation;


            Logger.Info("At CreateOrcSegmentNEW STEP2");
            string ORC_message = "ORC|";

            ORC_message = ORC_message + ORCModel.OrderControl + "|" + ORCModel.PlacerOrderNumber + "|" + ORCModel.FillerOrderNumber + "|" + ORCModel.PlacerGroupNumber + "|" + ORCModel.OrderStatus + "|" + ORCModel.ResponseFlag + "|" + ORCModel.Quantity_Timing + "|" + ORCModel.Parent + "|" + ORCModel.DateTimeOfTransaction
                + "|" + ORCModel.EnteredBy + "|" + ORCModel.VerifiedBy + "|" + ORCModel.OrderingProvider + "|" + ORCModel.EntererLocation + "|" + ORCModel.CallBackPhoneNumber + "|" + ORCModel.OrderEffectiveDatetime.ToString("yyyyMMddHHmmss") + "|" + ORCModel.OrderControlCodeReason + "|" + ORCModel.EnteringOrganization + "|" + ORCModel.EnteringDevice + "|" + ORCModel.ActionBy
                + "|" + ORCModel.AdvancedBeneficiaryNoticeCode + "|" + ORCModel.OrderingFacilityName + "|" + ORCModel.OrderingFacilityAddress + "|" + ORCModel.OrderingFacilityPhoneNumber + "|" + ORCModel.OrderingProviderAddress;

            Logger.Info("ORM_ORC_message: " + ORC_message);
            //WriteLogORM(ORC_message);

        }

        private void CreateObrSegment(MessageModel aDTMessageModel)
        {
            /* OBR-1 Set ID,OBR-2 Place Order Number,OBR-3 Filler Order Number,OBR-4 Universal Service ID,OBR-4.1 identifier,OBR-4.2 test,OBR-4.3 name of coding system,OBR-4.4 alternate identifier,OBR-4.5 alternate text
 OBR-5 Priority-OBR,OBR-6 Requested Date/time,OBR-7 Observation Date/time,OBR-8 Observation End Date/time,OBR-9 Collection Volume
 OBR-10 Collector Identifier
 OBR-11 Specimen Action Code
 OBR-12 Danger Code
 OBR-13 Relevant Clinical Info
 OBR-14 Specimen Received Date/time
 OBR-15 Specimen Source

 OBR-16 Ordering Provider
 OBR-16.1 ID number
 OBR-16.2 family+last name
 OBR-16.3 given name

 OBR-17 Order Call Back Phone Number
 OBR-17.1 [(999)]999-9999[X9999][C any text]
 OBR-17.2 telecommunication use code 

 OBR-18 Placer Field1
 OBR-19 Placer Field2
 OBR-20 Filler Field1+
 OBR-21 Filler Field2+

 OBR-22 Results Rpt/Status Change Date/time
 OBR-22.1 time of an event
 OBR-22.2 degree of precision

 OBR-23 Charge to Practice+
 OBR-23.1  dollar amount
 OBR-23.2 charge code

 OBR-24 Diagnostic Serv Sect ID

 OBR-25 Result Status+

 OBR-26 Parent Result+
 OBR-26.1 OBX-3 observation identifier of parent result
 OBR-26.2 OBX-4 sub-ID of parent result
 OBR-26.3 part od OBX-5 observation result from parent


 OBR-27 Quantity/Timing
 OBR-27.1 quantity
 OBR-27.2 interval
 OBR-27.3 duration
 OBR-27.4 start Date/time
 OBR-27.5 end Date/time
 OBR-27.6 priority
 OBR-28 Result copies to
 OBR-29 Parent
 OBR-30 Transportation Mode
 OBR-31 Reason for Study 
 OBR-31.1 identifier
 OBR-31.2 text

 OBR-32 Principal Result Interpreter+
 OBR-32.1 name
 OBR-32.2 start Date/time
 OBR-32.3 end Date/time
 OBR-32.4 point of care(IS)
 OBR-32.5 room
 OBR-32.6 bed
 OBR-32.7 facility(HD)
 OBR-32.8 location status
 OBR-32.9 person location type
 OBR-32.10 building
 OBR-32.11 floor

 OBR-33 Assistant Result Interpreter+
 OBR-33.1 name
 OBR-33.2 start Date/time
 OBR-33.3 end Date/time
 OBR-33.4 point of care(IS)
 OBR-33.5 room
 OBR-33.6 bed
 OBR-33.7 facility(HD)
 OBR-33.8 location status
 OBR-33.9 person location type
 OBR-33.10 building
 OBR-33.11 floor

 OBR-34 Technician+
 OBR-34.1 name
 OBR-34.2 start Date/time
 OBR-34.3 end Date/time
 OBR-34.4 point of care(IS)
 OBR-34.5 room
 OBR-34.6 bed
 OBR-34.7 facility(HD)
 OBR-34.8 location status
 OBR-34.9 person location type
 OBR-34.10 building
 OBR-34.11 floor

 OBR-35 Transcriptionist+
 OBR-35.1 name
 OBR-35.2 start Date/time
 OBR-35.3 end Date/time
 OBR-35.4 point of care(IS)
 OBR-35.5 room
 OBR-35.6 bed
 OBR-35.7 facility(HD)
 OBR-35.8 location status
 OBR-35.9 person location type
 OBR-35.10 building
 OBR-35.11 floor


 OBR-36 Scheduled Date/time+
 OBR-36.1 time of an event
 OBR-36.2 degree of precision

 OBR-37 Number of Sample Containers
 OBR-38 Transport Logistics of Collected Sample
 OBR-38.1 Identifier2 
 OBR-38.2  Text2 
 OBR-38.3  NameOfCodingSystem2 
 OBR-38.4  AlternateIdentifier2
 OBR-38.5  AlternateText2 
 OBR-38.6  NameOfAlternateCodingSystem 
 OBR-39 Collector's Comment+
 OBR-40 Transport Arrangement Responsibility
 OBR-41 Transport Arranged
 OBR-42 Escort Required
 OBR-43 Planned Patient Transport Comment
 OBR-44 Procedure Code
 OBR-45 Procedure Code Modifier
            */
            Logger.Info("At CreateObrSegment STEP1");
            OBRModel OBRModel = new OBRModel();
            OBRModel.SetID = 1;
            OBRModel.PlacerOrderNumber = "PHI";
            OBRModel.FillerOrderNumber = "PHI";

            //UniversalServiceID
            OBRModel.Identifier = "J127 BIL BREAST";
            OBRModel.Text = "US BIL BREAST";
            OBRModel.NameOfCodingSystem = "";
            OBRModel.AlternateIdentifier = "J127B 2 MULTI";
            OBRModel.AlternateText = "J127B 2 MULTI";
            OBRModel.UniversalServiceID = OBRModel.Identifier + "^" + OBRModel.Text + "^" + OBRModel.NameOfCodingSystem + "^" + OBRModel.AlternateIdentifier + "^" + OBRModel.AlternateText;

            OBRModel.Priority_OBR = aDTMessageModel.Priority_OBR;
            OBRModel.RequestedDateTime = DateTime.Now;
            OBRModel.ObservationDateTime = DateTime.Now;
            OBRModel.ObservationEndDateTime = DateTime.Now;
            OBRModel.CollectionVolume = "";
            OBRModel.CollectorIdentifier = "";
            OBRModel.SpecimenActionCode = "A";
            OBRModel.DangerCode = "";
            OBRModel.RelevantClinicalInfo = "";
            OBRModel.SpecimenReceivedDateTime = DateTime.Now;
            OBRModel.SpecimenSource = "";

            //OrderingProvider
            OBRModel.IDNumber = 8200;
            OBRModel.FamilyLastName = "MURTOZA";
            OBRModel.GivenName = "DR G";
            OBRModel.OrderingProvider = OBRModel.IDNumber + "^" + OBRModel.FamilyLastName + "^" + OBRModel.GivenName;

            //OrderCallbackPhoneNumber
            OBRModel.PhoneNumber999 = aDTMessageModel.PhoneNumber9992;
            OBRModel.TelecommunicationUseCode = aDTMessageModel.TelecommunicationUseCode2;
            OBRModel.OrderCallBackPhoneNumber = OBRModel.PhoneNumber999 + "^" + OBRModel.TelecommunicationUseCode;

            OBRModel.PlacerField1 = "";
            OBRModel.PlacerField2 = "US";
            OBRModel.FillerField1 = "";
            OBRModel.FillerField2 = "SAMSUNGRAM1";
            OBRModel.ResultsRpt_StatusChangeDateTime = DateTime.Now;
            OBRModel.ChargeToPractice = aDTMessageModel.ChargeToPractice;
            OBRModel.DiagnosticServSectID = "US";
            OBRModel.ResultStatus = "A";
            OBRModel.ParentResult = aDTMessageModel.ParentResult;

            //Quantity/Timing
            OBRModel.Quantity = int.Parse(aDTMessageModel.Quantity);
            OBRModel.Interval = int.Parse(aDTMessageModel.Interval);
            OBRModel.Duration = aDTMessageModel.Duration;
            OBRModel.StartDateTime = DateTime.Now;
            OBRModel.EndDateTime = DateTime.Now;
            OBRModel.Priority = "R";
            OBRModel.Quantity_Timing = OBRModel.Quantity + "^" + OBRModel.Interval + "^" + OBRModel.Duration + "^" + OBRModel.StartDateTime.ToString("yyyyMMddHHmmss") + "^" + OBRModel.EndDateTime.ToString("yyyyMMddHHmmss") + "^" + OBRModel.Priority;

            OBRModel.ResultCopiesTo = aDTMessageModel.ResultCopiesTo;
            OBRModel.Parent = aDTMessageModel.Parent;
            OBRModel.TransportationMode = "CART";

            //ReasonForStudy
            OBRModel.Identifier1 = "AS PER REQUISITION";
            OBRModel.Text1 = "AS PER REQUISITION";
            OBRModel.ReasonForStudy = OBRModel.Identifier1 + "^" + OBRModel.Text1;

            OBRModel.PrincipalResultInterpreter = aDTMessageModel.PrincipalResultInterpreter;
            OBRModel.AssistantResultInterpreter = aDTMessageModel.AssistantResultInterpreter;

            //Technician
            OBRModel.Name = aDTMessageModel.Name;
            OBRModel.StartDateTime1 = DateTime.Now;
            OBRModel.EndDateTime1 = DateTime.Now;
            OBRModel.PointOfCare = aDTMessageModel.PointOfCare;
            OBRModel.Room = aDTMessageModel.Room;
            OBRModel.Bed = aDTMessageModel.Bed;
            OBRModel.Facility = aDTMessageModel.Facility;
            OBRModel.LocationStatus = aDTMessageModel.LocationStatus;
            OBRModel.PersonLocationType = aDTMessageModel.PersonLocationType2;
            OBRModel.Building = aDTMessageModel.Building2;
            OBRModel.Floor = aDTMessageModel.Floor2;

            OBRModel.Technician = OBRModel.Name + "^" + OBRModel.StartDateTime1 + "^" + OBRModel.EndDateTime1 + "^" + OBRModel.PointOfCare + "^" + OBRModel.Room
                + "^" + OBRModel.Bed + "^" + OBRModel.Facility + "^" + OBRModel.LocationStatus + "^" + OBRModel.PersonLocationType + "^" + OBRModel.Building + "^" + OBRModel.Floor;



            //Transcriptionist
            OBRModel.Name2 = aDTMessageModel.Name2;
            OBRModel.StartDateTime2 = DateTime.Now;
            OBRModel.EndDateTime2 = DateTime.Now;
            OBRModel.PointOfCare2 = aDTMessageModel.PointOfCare2;
            OBRModel.Room2 = aDTMessageModel.Room2;
            OBRModel.Bed2 = aDTMessageModel.Bed2;
            OBRModel.Facility2 = aDTMessageModel.Facility2;
            OBRModel.LocationStatus2 = aDTMessageModel.LocationStatus2;
            OBRModel.PersonLocationType2 = aDTMessageModel.PersonLocationType2;
            OBRModel.Building2 = aDTMessageModel.Building2;
            OBRModel.Floor2 = aDTMessageModel.Floor2;

            OBRModel.Name3 = aDTMessageModel.Name3;
            OBRModel.StartDateTime3 = DateTime.Now;
            OBRModel.EndDateTime3 = DateTime.Now;
            OBRModel.PointOfCare3 = aDTMessageModel.PointOfCare3;
            OBRModel.Room3 = aDTMessageModel.Room3;
            OBRModel.Bed3 = aDTMessageModel.Bed3;
            OBRModel.Facility3 = aDTMessageModel.Facility3;
            OBRModel.LocationStatus3 = aDTMessageModel.LocationStatus3;
            OBRModel.PersonLocationType3 = aDTMessageModel.PersonLocationType3;
            OBRModel.Building3 = aDTMessageModel.Building3;
            OBRModel.Floor3 = aDTMessageModel.Floor3;

            OBRModel.Transcriptionist = "NAME2"; //OBRModel.Name2 + "^" + OBRModel.StartDateTime2 + "^" + OBRModel.EndDateTime2 + "^" + OBRModel.PointOfCare2 + "^" + OBRModel.Room2 + "^" + OBRModel.Bed2 + "^" + OBRModel.Facility2               + "^" + OBRModel.LocationStatus2 + "^" + OBRModel.PersonLocationType2 + "^" + OBRModel.Building2 + "^" + OBRModel.Floor2 + "^" +        OBRModel.Name3 + "^" + OBRModel.StartDateTime3 + "^" + OBRModel.EndDateTime3 + "^" + OBRModel.PointOfCare3 + "^" + OBRModel.Room3 + "^" + OBRModel.Bed3 + "^" + OBRModel.Facility3         + "^" + OBRModel.LocationStatus3 + "^" + OBRModel.PersonLocationType3 + "^" + OBRModel.Building3 + "^" + OBRModel.Floor3;



            OBRModel.ScheduledDateTime = DateTime.Now;
            OBRModel.NumberOfSampleContainers = aDTMessageModel.NumberOfSampleContainers;
            OBRModel.TransportLogisticsOfCollectedSample = aDTMessageModel.TransportLogisticsOfCollectedSample;
            OBRModel.CollectorComment = aDTMessageModel.CollectorComment;
            OBRModel.TransportArrangementResponsibility = aDTMessageModel.TransportArrangementResponsibility;
            OBRModel.TransportArranged = aDTMessageModel.TransportArranged;
            OBRModel.EscortRequired = aDTMessageModel.EscortRequired;
            OBRModel.PlannedPatientTransportComment = aDTMessageModel.PlannedPatientTransportComment;
            OBRModel.ProcedureCode = "J127B 2 MULTI";
            OBRModel.ProcedureCodeModifier = aDTMessageModel.ProcedureCodeModifier;






            string OBR_message = "OBR|";

            OBR_message = OBR_message + OBRModel.SetID + "|" + OBRModel.PlacerOrderNumber + "|" + OBRModel.FillerOrderNumber + "|" + OBRModel.UniversalServiceID + "|" + OBRModel.Priority_OBR + "|" + OBRModel.RequestedDateTime.ToString("yyyyMMddHHmmss") + "|" + OBRModel.ObservationDateTime.ToString("yyyyMMddHHmmss") + "|" + OBRModel.ObservationEndDateTime.ToString("yyyyMMddHHmmss") + "|" + OBRModel.CollectionVolume + "|" + OBRModel.CollectorIdentifier + "|" + OBRModel.SpecimenActionCode
                + "|" + OBRModel.DangerCode + "|" + OBRModel.RelevantClinicalInfo + "|" + OBRModel.SpecimenReceivedDateTime.ToString("yyyyMMddHHmmss") + "|" + OBRModel.SpecimenSource + "|" + OBRModel.OrderingProvider + "|" + OBRModel.OrderCallBackPhoneNumber + "|" + OBRModel.PlacerField1 + "|" + OBRModel.PlacerField2 + "|" + OBRModel.FillerField1 + "|" + OBRModel.FillerField2 + "|" + OBRModel.ResultsRpt_StatusChangeDateTime.ToString("yyyyMMddHHmmss") + "|" + OBRModel.ChargeToPractice
                + "|" + OBRModel.DiagnosticServSectID + "|" + OBRModel.ResultStatus + "|" + OBRModel.ParentResult + "|" + OBRModel.Quantity_Timing + "|" + OBRModel.ResultCopiesTo + "|" + OBRModel.Parent + "|" + OBRModel.TransportationMode + "|" + OBRModel.ReasonForStudy + "|" + OBRModel.PrincipalResultInterpreter + "|" + OBRModel.AssistantResultInterpreter + "|" + OBRModel.Technician + "|" + OBRModel.Transcriptionist
                + "|" + OBRModel.ScheduledDateTime.ToString("yyyyMMddHHmmss") + "|" + OBRModel.NumberOfSampleContainers + "|" + OBRModel.TransportLogisticsOfCollectedSample + "|" + OBRModel.CollectorComment + "|" + OBRModel.TransportArrangementResponsibility + "|" + OBRModel.TransportArranged + "|" + OBRModel.EscortRequired + "|" + OBRModel.PlannedPatientTransportComment + "|" + OBRModel.ProcedureCode + "|" + OBRModel.ProcedureCodeModifier;

            //Debug.WriteLine("ORM_OBR_message: " + OBR_message);
            Logger.Info("ORM_OBR_message: " + OBR_message);
            //WriteLogORM(OBR_message);
        }

    }
}
