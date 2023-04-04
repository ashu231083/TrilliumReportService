using NHapi.Base.Log;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Model.V23.Message;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using HelperHL7;
using NLog;
using System.IO;

namespace TcpIpServerService
{
    internal class ORM_001MessageBuilder
    {
        Logger Logger = LogManager.GetCurrentClassLogger();
        private ORM_O01 _Message;


        public ORM_O01 BuildNEW(HL7ORMModel aDTMessageModel)
        {
            var currentDateTimeString = GetCurrentTimeStamp();
            _Message = new ORM_O01();

            CreateMshSegmentNEW(currentDateTimeString, aDTMessageModel);
            CreatePidSegmentNEW(currentDateTimeString, aDTMessageModel);
            CreatePv1SegmentNEW(currentDateTimeString, aDTMessageModel);
            CreateOrcSegmentNEW(currentDateTimeString, aDTMessageModel);
            CreateObrSegmentNEW(currentDateTimeString, aDTMessageModel);

            return _Message;
        }

        public static void WriteLogORM(string LogMessage)
        {
            string path = @"C:\HL7\HL7MSGORM001" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".hl7";
            using (var file = new StreamWriter(path, true))
            {
                file.WriteLine(LogMessage + "\n ");
                file.Close();
            }
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

        private void CreateMshSegmentNEW(string currentDateTimeString, HL7ORMModel aDTMessageModel)
        {
            /*  MSH - 1 Field Separator = |,MSH - 2 Encoding Characters = ^~\&,MSH - 3 Sending Application,
  MSH - 4 Sending Facility,MSH - 5 Receiving Application,MSH - 6 Receiving Facility,MSH - 7 Date\Time of Message = 20230125124217,MSH - 8 Security,
  MSH - 9 Message Type = ORM ^ 001, MSH - 10 Message Control ID, MSH - 11 Processing ID,MSH - 12 Version ID,MSH - 13 Sequence Number,
  MSH - 14 Continuation Pointer, MSH - 15 Accept Acknowledgment Type,MSH - 16 Application Acknowledgment Type,MSH - 17 Country Code,
  MSH - 18 Character Set,MSH - 19 Principal Language of Message,MSH - 20 Alternate Character Set Handling Scheme*/


            Logger.Info("At CreateMshSegmentNEW STEP1");
            ORM_MSHModel MSHModel = new ORM_MSHModel();
            MSHModel.SendingApplication = aDTMessageModel.SendingApplication;
            MSHModel.SendingFacility = aDTMessageModel.SendingFacility;
            MSHModel.ReceivingApplication = aDTMessageModel.ReceivingApplication;
            MSHModel.ReceivingFacility = aDTMessageModel.ReceivingFacility;
            MSHModel.DateTimeofMessage = DateTime.Now;
            MSHModel.Security = aDTMessageModel.Security;


            //MessageType
            MSHModel.messagetype = "ORM";
            MSHModel.triggerevent = "001";
            MSHModel.MessageType = MSHModel.messagetype + "^" + MSHModel.triggerevent;


            MSHModel.MessageControlID = int.Parse(aDTMessageModel.MessageControlID);
            MSHModel.ProcessingID = int.Parse(aDTMessageModel.ProcessingID);
            MSHModel.VersionID = aDTMessageModel.VersionID;
            MSHModel.SequenceNumber = aDTMessageModel.SequenceNumber;
            MSHModel.ContinuationPointer = aDTMessageModel.ContinuationPointer;
            MSHModel.AcceptAcknowledgmentType = aDTMessageModel.AcceptAcknowledgmentType;
            MSHModel.ApplicationAcknowledgmentType = aDTMessageModel.ApplicationAcknowledgmentType;
            MSHModel.CountryCode = aDTMessageModel.countrycode;
            MSHModel.CharacterSet = aDTMessageModel.CharacterSet;
            MSHModel.PrincipalLanguageofMessage = "HL7";
            MSHModel.AlternateCharacterSetHandlingScheme = aDTMessageModel.AlternateCharacterSetHandlingScheme;
            Logger.Info("At CreateMshSegmentNEW STEP2");
            string MSH_message = "MSH|^~\\&|";

            MSH_message = MSH_message + MSHModel.SendingApplication + "|" + MSHModel.SendingFacility + "|" + MSHModel.ReceivingApplication + "|" + MSHModel.ReceivingFacility + "|" + MSHModel.DateTimeofMessage.ToString("yyyyMMddHHmmss") + "|" + MSHModel.Security
                + "|" + MSHModel.MessageType + "|" + MSHModel.MessageControlID + "|" + MSHModel.ProcessingID + "|" + MSHModel.VersionID + "|" + MSHModel.SequenceNumber + "|" + MSHModel.ContinuationPointer + "|" + MSHModel.AcceptAcknowledgmentType
             + "|" + MSHModel.ApplicationAcknowledgmentType + "|" + MSHModel.CountryCode + "|" + MSHModel.CharacterSet + "|" + MSHModel.PrincipalLanguageofMessage + "|" + MSHModel.AlternateCharacterSetHandlingScheme;

            Logger.Info("NEW ORM_MSH_message: " + MSH_message);
            WriteLogORM(MSH_message);
        }

        private void CreatePidSegmentNEW(string currentDateTimeString, HL7ORMModel aDTMessageModel)
        {
            Logger.Info("At CreatePidSegmentNEW STEP1");
            ORM_PIDModel PIDModel = new ORM_PIDModel();
            PIDModel.SetID = 2;
            //PatientID_External 
            PIDModel.External_ID = int.Parse(aDTMessageModel.External_ID);
            PIDModel.External_checkdigit = int.Parse(aDTMessageModel.External_checkdigit);
            PIDModel.External_codeidentifyingthecheckdigitschemeemployed = aDTMessageModel.External_codeidentifyingthecheckdigitschemeemployed;
            PIDModel.External_assigningauthority = aDTMessageModel.External_assigningauthority;
            PIDModel.External_identifiertypecode = aDTMessageModel.External_identifiertypecode;
            PIDModel.External_assigningfacility = aDTMessageModel.External_assigningfacility;
            PIDModel.PatientID_External = PIDModel.External_ID + "^" + PIDModel.External_checkdigit + "^" + PIDModel.External_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel.External_assigningauthority + "^" + PIDModel.External_identifiertypecode + "^" + PIDModel.External_assigningfacility;

            //PatientID_Internal
            PIDModel.Internal_ID = int.Parse(aDTMessageModel.Internal_ID);
            PIDModel.Internal_checkdigit = int.Parse(aDTMessageModel.Internal_checkdigit);
            PIDModel.Internal_codeidentifyingthecheckdigitschemeemployed = aDTMessageModel.Internal_codeidentifyingthecheckdigitschemeemployed;
            PIDModel.Internal_assigningauthority = aDTMessageModel.Internal_assigningauthority;
            PIDModel.Internal_identifiertypecode = aDTMessageModel.Internal_identifiertypecode;
            PIDModel.Internal_assigningfacility = aDTMessageModel.Internal_assigningfacility;
            PIDModel.PatientID_Internal = PIDModel.Internal_ID + "^" + PIDModel.Internal_checkdigit + "^" + PIDModel.Internal_codeidentifyingthecheckdigitschemeemployed + "^" + PIDModel.Internal_assigningauthority + "^" + PIDModel.Internal_identifiertypecode + "^" + PIDModel.Internal_assigningfacility;

            //PatientID_Alternate
            PIDModel.Alternate_ID = int.Parse(aDTMessageModel.Alternate_ID);
            PIDModel.Alternate_checkdigit = int.Parse(aDTMessageModel.Alternate_checkdigit);
            PIDModel.Alternate_codeidentifyingthecheckdigitschemeemployed = aDTMessageModel.Alternate_codeidentifyingthecheckdigitschemeemployed;
            PIDModel.Alternate_assigningauthority = aDTMessageModel.Alternate_assigningauthority;
            PIDModel.Alternate_identifiertypecode = aDTMessageModel.Alternate_identifiertypecode;
            PIDModel.Alternate_assigningfacility = aDTMessageModel.Alternate_assigningfacility;
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
            PIDModel.Race = aDTMessageModel.Race;

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

            PIDModel.CountryCode = aDTMessageModel.CountryCode;
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
            Logger.Info("At CreatePidSegmentNEW STEP2");
            string pid_message = "PID|";
            pid_message = pid_message + PIDModel.SetID + "|" + PIDModel.PatientID_External + "|" + PIDModel.PatientID_Internal + "|" + PIDModel.PatientID_Alternate + "|" + PIDModel.PatientName + "|" + PIDModel.MotherMaidenName + "|" + PIDModel.DateofBirth.ToString("yyyyMMddHHmmss")
                + "|" + PIDModel.Sex + "|" + PIDModel.PatientAlias + "|" + PIDModel.Race + "|" + PIDModel.PatientAddress + "|" + PIDModel.CountryCode + "|" + PIDModel.PhoneNumber_Home + "|" + PIDModel.PhoneNumber_Business + "|" + PIDModel.PrimaryLanguage + "|" + PIDModel.MaritalStaus
                + "|" + PIDModel.Religion + "|" + PIDModel.PatientAccountNumber + "|" + PIDModel.SSNNumber_Patient + "|" + PIDModel.DriverLicenseNumber + "|" + PIDModel.MotherIdentifier + "|" + PIDModel.EthnicGroup + "|" + PIDModel.BirthPlace + "|" + PIDModel.MultipleBirthIndicator
                + "|" + PIDModel.BirthOther + "|" + PIDModel.Citizenship + "|" + PIDModel.VeteransMilitaryStatus + "|" + PIDModel.NationalityCode + "|" + PIDModel.PatientDeathDateTime.ToString("yyyyMMddHHmmss") + "|" + PIDModel.PatientDeathIndicator;

            Logger.Info("PID_message: " + pid_message);
            WriteLogORM(pid_message);
        }

        private void CreatePv1SegmentNEW(string currentDateTimeString, HL7ORMModel aDTMessageModel)
        {
            /* PV1-1 Set ID - PV1 = 1234,PV1-2 Patient Class,PV1-3 Assigned Patient Location,PV1-3.1 point of care,PV1-3.2 room,PV1-3.3 bed,PV1-3.4 facility(HD),PV1-3.5 location status,PV1-3.6 person location type,
         PV1-3.7 building,PV1-3.8 floor, PV1-3.9 Location description,PV1-4 Admission Type, PV1-5 Preadmit Number, PV1-6 Prior Patient Location,PV1-7 Attending Doctor, PV1-8 Referring Doctor,
         PV1-8.1 ID number(ST),PV1-8.2 family+last name, PV1-8.3 given name,PV1-9 Consulting Doctor, PV1-10 Hospital Service, PV1-11 Temporary Location, PV1-12 Preadmit Test Indicator,PV1-13 Re-admission Indicator,
         PV1-14 Admit Source,PV1-15 Ambulatory Status,PV1-16 VIP Indicator,PV1-17 Admitting Doctor,PV1-18 Patient Type,PV1-19 Visit Number,PV1-20 Financial Class,PV1-21 Charge Price Indicator,PV1-22 Courtesy Code,PV1-23 Credit Rating,
         PV1-24 Contract Code,PV1-25 Contract Effective Date,PV1-26 Contract Amount,PV1-27 Contract Period,PV1-28 Interest Code,PV1-29 Transfer to Bad Debt Code,PV1-30 Transfer to Bad Debt Date,PV1-31 Bad Debt Agency Code,
         PV1-32 Bad Debt Transfer Amount,PV1-33 Bad Debt Recovery Amount,PV1-34 Delete Account Indicator,PV1-35 Delete Account Date,PV1-36 Discharge Disposition,PV1-37 Discharged to Location,PV1-38 Diet Type,
         PV1-39 Servicing Facility,PV1-40 Bed Status,PV1-41 Account Status,PV1-42 Pending Location,PV1-43 Prior Temporary Location,PV1-44 Admit Date/time,PV1-45 Discharge Date/time,PV1-46 Current Patient Balance,PV1-47 Total Charges,
         PV1-48 Total Adjustments,PV1-49 Total Payments,PV1-50 Alternate Visit ID,PV1-51 visit Indicator,PV1-52 Other Healthcare Provider*/
            Logger.Info("At CreatePv1SegmentNEW STEP1");
            ORM_PV1Model PV1Model = new ORM_PV1Model();
            PV1Model.SetID = int.Parse(aDTMessageModel.PV1SetID);
            PV1Model.PatientClass = aDTMessageModel.PatientClass;


            //AssignedPatientLocation
            PV1Model.PointOfCare = aDTMessageModel.PointOfCare;
            PV1Model.Room = aDTMessageModel.Room;
            PV1Model.Bed = aDTMessageModel.Bed;
            PV1Model.Facility = aDTMessageModel.Facility;
            PV1Model.LocationStatus = aDTMessageModel.LocationStatus;
            PV1Model.PersonLocationType = aDTMessageModel.PersonLocationType;
            PV1Model.Building = aDTMessageModel.Building;
            PV1Model.Floor = aDTMessageModel.Floor;
            PV1Model.LocationDescription = aDTMessageModel.LocationDescription;

            PV1Model.AssignedPatientLocation = PV1Model.PointOfCare + "^" + PV1Model.Room + "^" + PV1Model.Bed + "^" + PV1Model.Facility + "^" + PV1Model.LocationStatus + "^" + PV1Model.PersonLocationType
               + "^" + PV1Model.Building + "^" + PV1Model.Floor + "^" + PV1Model.LocationDescription;

            PV1Model.AdmissionType = aDTMessageModel.AdmissionType;
            PV1Model.PreadmitNumber = aDTMessageModel.PreadmitNumber;
            PV1Model.PriorPatientLocation = aDTMessageModel.PriorPatientLocation;
            PV1Model.AttendingDoctor = aDTMessageModel.AttendingDoctor;

            //ReferringDoctor
            PV1Model.IDNumber = aDTMessageModel.IDNumber2;
            PV1Model.Family_LastName = aDTMessageModel.FamilyLastName;
            PV1Model.GivenName = aDTMessageModel.givenname;

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
            PV1Model.DeleteAccountIndicator = aDTMessageModel.DeleteAccountDate;
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
            Logger.Info("At CreatePv1SegmentNEW STEP2");

            string PV1_message = "PV1|";

            PV1_message = PV1_message + +PV1Model.SetID + "|" + PV1Model.PatientClass + "|" + PV1Model.AssignedPatientLocation + "|" + PV1Model.AdmissionType + "|" + PV1Model.PreadmitNumber + "|" + PV1Model.PriorPatientLocation + "|" + PV1Model.AttendingDoctor + "|" + PV1Model.ReferringDoctor + "|" + PV1Model.ConsultingDoctor
                + "|" + PV1Model.HospitalService + "|" + PV1Model.TemporaryLocation + "|" + PV1Model.PreadmitTestIndicator + "|" + PV1Model.Re_AdmissionIndicator + "|" + PV1Model.AdmitSource + "|" + PV1Model.AmbulatoryStatus + "|" + PV1Model.VIPIndicator + "|" + PV1Model.AdmittingDoctor + "|" + PV1Model.PatientType + "|" + PV1Model.VisitNumber
                + "|" + PV1Model.FinancialClass + "|" + PV1Model.ChargePriceIndicator + "|" + PV1Model.CourtesyCode + "|" + PV1Model.CreditRating + "|" + PV1Model.ContractCode + "|" + PV1Model.ContractEffectiveDate.ToString("yyyyMMddHHmmss") + "|" + PV1Model.ContractAmount + "|" + PV1Model.ContractPeriod + "|" + PV1Model.InterestCode
                + "|" + PV1Model.TransfertoBadDebtCode + "|" + PV1Model.TransfertoBadDebtDate.ToString("yyyyMMddHHmmss") + "|" + PV1Model.BadDebtAgencyCode + "|" + PV1Model.BadDebtTransferAmount + "|" + PV1Model.BadDebtRecoveryAmount + "|" + PV1Model.DeleteAccountIndicator + "|" + PV1Model.DeleteAccountDate.ToString("yyyyMMddHHmmss")
                + "|" + PV1Model.DischargeDisposition + "|" + PV1Model.DischargedToLocation + "|" + PV1Model.DietType + "|" + PV1Model.ServicingFacility + "|" + PV1Model.BedStatus + "|" + PV1Model.AccountStatus + "|" + PV1Model.PendingLocation + "|" + PV1Model.PriorTemporaryLocation + "|" + PV1Model.AdmitDatetime.ToString("yyyyMMddHHmmss") + "|" + PV1Model.DischargeDatetime.ToString("yyyyMMddHHmmss");

            Logger.Info("ORM_PV1_message: " + PV1_message);
            WriteLogORM(PV1_message);
        }

        private void CreateOrcSegmentNEW(string currentDateTimeString, HL7ORMModel aDTMessageModel)
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
            WriteLogORM(ORC_message);

        }

        private void CreateObrSegmentNEW(string currentDateTimeString, HL7ORMModel aDTMessageModel)
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
            Logger.Info("At CreateObrSegmentNEW STEP1");
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
            WriteLogORM(OBR_message);
        }
    }
}
