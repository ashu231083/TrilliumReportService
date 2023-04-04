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
    internal class ADT_A04MessageBuilder
    {
        private ADT_A04 _adtMessage;

        /*You can pass in a domain or data transfer object as a parameter
        when integrating with data from your application here
        I will leave that to you to explore on your own
        Using fictional data here for illustration*/

        public ADT_A04 BuildA04(MessageModel aDTMessageModel)
        {
            var currentDateTimeString = GetCurrentTimeStamp();
            _adtMessage = new ADT_A04();

            CreateMshSegment(currentDateTimeString, aDTMessageModel);
            CreateEvnSegment(currentDateTimeString, aDTMessageModel);
            CreatePidSegment(aDTMessageModel);
            CreatePv1Segment(aDTMessageModel);
            CreatePd1Segment(aDTMessageModel);
            CreateRolSegment(aDTMessageModel);
            CreateNk1Segment(aDTMessageModel);
            CreatePv2Segment(aDTMessageModel);
            CreateDb1Segment(aDTMessageModel);
            CreateObxSegment(aDTMessageModel);
            CreateAl1Segment(aDTMessageModel);
            CreateDg1Segment(aDTMessageModel);
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
            MSHModel.triggerevent = "A04";
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
            //var evn = _adtMessage.EVN;
            //evn.EventTypeCode.Value = aDTMessageModel.EventTypeCode;
            //evn.RecordedDateTime.TimeOfAnEvent.Value = currentDateTimeString;
            //Debug.WriteLine("evnSegment: " + evn.Message);

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
            //Debug.WriteLine("pidSegment: " + pid.Message);

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


        private void CreateRolSegment(MessageModel aDTMessageModel)
        {
            /*ROL-1 Role Instance ID,ROL-2 Action Code(AD - ADD,CO - CORRECT,DE - DELETE,LI - LINK,UC - UNCHANGED *,UN - UNLINK,UP - UPDATE) = AD
             ROL-3 Role-ROL,ROL-4 Role Person,ROL-5 Role Begin Date\Time,ROL-6 Role End Date\Time,ROL-7 Role Duration,ROL-8 Role Action Reason
             ROL-9 Provider Type,ROL-10 Organization Unit Type,ROL-11 Office/Home Address/Birthplace,ROL-12 Phone */

            ROL1Model rOL1Model = new ROL1Model();
            rOL1Model.RoleInstanceID = 263;
            rOL1Model.ActionCode = "AD";
            rOL1Model.RoleROL = "ROL Name";
            rOL1Model.RolePerson = "Person1";
            rOL1Model.RoleBeginDateTime = DateTime.Now;
            rOL1Model.RoleEndDateTime = DateTime.Now;
            rOL1Model.RoleDuration = 5;
            rOL1Model.RoleActionReason = "Reason for action..";
            rOL1Model.ProviderType = "Type2";
            rOL1Model.OrganizationUnitType = "Unit3";
            rOL1Model.Office_HomeAddress_Birthplace = "Address for office";
            rOL1Model.Phone = "484751848";

            string rol1_message = "ROL|";

            rol1_message = rol1_message + rOL1Model.RoleInstanceID + "|" + rOL1Model.ActionCode + "|" + rOL1Model.RoleROL + "|" + rOL1Model.RolePerson + "|" + rOL1Model.RoleBeginDateTime.ToString("yyyyMMddHHmmss") + "|" + rOL1Model.RoleEndDateTime.ToString("yyyyMMddHHmmss") + "|" + rOL1Model.RoleDuration
              + "|" + rOL1Model.RoleActionReason + "|" + rOL1Model.ProviderType + "|" + rOL1Model.OrganizationUnitType + "|" + rOL1Model.Office_HomeAddress_Birthplace + "|" + rOL1Model.Phone;
            Debug.WriteLine("rol1_message: " + rol1_message);
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
            nK1Model.Name = "Deo John";
            nK1Model.Relationship = "CHD";
            nK1Model.Address = "canada";
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


        private void CreatePv2Segment(MessageModel aDTMessageModel)
        {
            /*PV2-1 Prior Pending Location,PV2-2 Accommodation Code,PV2-3 Admit Reason,PV2-4 Transfer Reason,PV2-5 Patient Valuables
             PV2-6 Patient Valuables Location,PV2-7 Visit User Code,PV2-8 Expected Admit Date/Time,PV2-9 Expected Discharge Date/Time,PV2-10 Estimated Length of Inpatient Stay
             PV2-11 Actual Length of Inpatient Stay,PV2-12 Visit Description,PV2-13 Referral Source Code,PV2-14 Previous Service Date,PV2-15 Employment Illness Related Indicator
             PV2-16 Purge Status Code,PV2-17 Purge Status Date,PV2-18 Special Program Code,PV2-19 Retention Indicator,PV2-20 Expected Number of Insurance Plan
             PV2-21 Visit Publicity Code,PV2-22 Visit Protection Indicator,PV2-23 Clinic Organization Name,PV2-24 Patient Status Code,PV2-25 Visit Priority Code
             PV2-26 Previous Treatment Date,PV2-27 Expected Discharge Disposition,PV2-28 Signature on File Date,PV2-29 First Similar Illness Date,PV2-30 Patient Charge Adjustment Code
             PV2-31 Recurring Service Code,PV2-32 Billing Media Code,PV2-33 Expected Surgery Date/Time,PV2-34 Military Partnership Code,PV2-35 Military Non-availability Code
             PV2-36 Newborn Baby Indicator,PV2-37 Baby Detained Indicator,PV2-38 Mode of Arrival Code,PV2-39 Recreational Drug Use Code,PV2-40 Admission Level of Care Code
             PV2-41 Precaution Code,PV2-42 Patient Condition Code,PV2-43 Living Will Code,PV2-44 Organ Donor Code,PV2-45 Advance Directive Code,PV2-46 Patient Status Effective Date
             PV2-47 Expected LOA Return Date/Time,PV2-48 Expected Pre-admission Testing Date/Time,PV2-49 Notify Clergy Code */


            PV2Model pV2Model = new PV2Model();
            pV2Model.PriorPendingLocation = "canada";
            pV2Model.AccommodationCode = "1";
            pV2Model.AdmitReason = "Emergency";
            pV2Model.TransferReason = "Unknown";
            pV2Model.PatientValuables = "";
            pV2Model.PatientValuablesLocation = "Canada";
            pV2Model.VisitUserCode = "HO";
            pV2Model.ExpectedAdmitDate = DateTime.Now;
            pV2Model.ExpectedDischargeDate = DateTime.Now;
            pV2Model.EstimatedLengthofInpatientStay = "2";
            pV2Model.ActualLengthofInpatientStay = "3";

            pV2Model.VisitDescription = "Description..";
            pV2Model.ReferralSourceCode = "Ref2";
            pV2Model.PreviousServiceDate = DateTime.Now;
            pV2Model.EmploymentIllnessRelatedIndicator = "N";
            pV2Model.PurgeStatusCode = "D";
            pV2Model.PurgeStatusDate = DateTime.Now;
            pV2Model.SpecialProgramCode = "ES";
            pV2Model.RetentionIndicator = "N";
            pV2Model.ExpectedNumberofInsurancePlan = "3";
            pV2Model.VisitPublicityCode = "F";
            pV2Model.VisitProtectionIndicator = "N";
            pV2Model.ClinicOrganizationName = "OCD";
            pV2Model.PatientStatusCode = "AI";
            pV2Model.VisitPriorityCode = "2";
            pV2Model.PreviousTreatmentDate = DateTime.Now;
            pV2Model.ExpectedDischargeDisposition = "OK";
            pV2Model.SignatureOnFileDate = DateTime.Now;
            pV2Model.FirstSimilarIllnessDate = DateTime.Now;
            pV2Model.PatientChargeAdjustmentCode = "225";
            pV2Model.RecurringServiceCode = "04";
            pV2Model.BillingMediaCode = "54542";
            pV2Model.ExpectedSurgeryDate = DateTime.Now;
            pV2Model.MilitaryPartnershipCode = "N";
            pV2Model.MilitaryNon_availabilityCode = "N";
            pV2Model.NewbornBabyIndicator = "N";
            pV2Model.BabyDetainedIndicator = "N";
            pV2Model.ModeofArrivalCode = "C";
            pV2Model.RecreationalDrugUseCode = "C";
            pV2Model.AdmissionLevelofCareCode = "AC";
            pV2Model.PrecautionCode = "A";
            pV2Model.PatientConditionCode = "C";
            pV2Model.LivingWillCode = "F";
            pV2Model.OrganDonorCode = "F";
            pV2Model.AdvanceDirectiveCode = "N";
            pV2Model.PatientStatusEffectiveDate = DateTime.Now;
            pV2Model.ExpectedLOAReturnDate = DateTime.Now;
            pV2Model.ExpectedPre_admissionTestingDate = DateTime.Now;
            pV2Model.NotifyClergyCode = "O";


            string PV2Message = "PV2|";

            PV2Message = PV2Message + pV2Model.PriorPendingLocation + "|" + pV2Model.AccommodationCode + "|" + pV2Model.AdmitReason + "|" + pV2Model.TransferReason + "|" + pV2Model.PatientValuables + "|" + pV2Model.PatientValuablesLocation + "|" + pV2Model.VisitUserCode + "|" + pV2Model.ExpectedAdmitDate.ToString("yyyyMMddHHmmss")
                     + "|" + pV2Model.ExpectedDischargeDate.ToString("yyyyMMddHHmmss") + "|" + pV2Model.EstimatedLengthofInpatientStay + "|" + pV2Model.ActualLengthofInpatientStay + "|" + pV2Model.VisitDescription + "|" + pV2Model.ReferralSourceCode + "|" + pV2Model.PreviousServiceDate.ToString("yyyyMMddHHmmss")
                     + "|" + pV2Model.EmploymentIllnessRelatedIndicator + "|" + pV2Model.PurgeStatusCode + "|" + pV2Model.PurgeStatusDate.ToString("yyyyMMddHHmmss") + "|" + pV2Model.SpecialProgramCode + "|" + pV2Model.RetentionIndicator + "|" + pV2Model.ExpectedNumberofInsurancePlan + "|" + pV2Model.VisitPublicityCode
                     + "|" + pV2Model.VisitProtectionIndicator + "|" + pV2Model.ClinicOrganizationName + "|" + pV2Model.PatientStatusCode + "|" + pV2Model.VisitPriorityCode + "|" + pV2Model.PreviousTreatmentDate.ToString("yyyyMMddHHmmss") + "|" + pV2Model.ExpectedDischargeDisposition + "|" + pV2Model.SignatureOnFileDate.ToString("yyyyMMddHHmmss")
                      + "|" + pV2Model.FirstSimilarIllnessDate.ToString("yyyyMMddHHmmss") + "|" + pV2Model.PatientChargeAdjustmentCode + "|" + pV2Model.RecurringServiceCode + "|" + pV2Model.BillingMediaCode + "|" + pV2Model.ExpectedSurgeryDate.ToString("yyyyMMddHHmmss") + "|" + pV2Model.MilitaryPartnershipCode
                      + "|" + pV2Model.MilitaryNon_availabilityCode + "|" + pV2Model.NewbornBabyIndicator + "|" + pV2Model.BabyDetainedIndicator + "|" + pV2Model.ModeofArrivalCode + "|" + pV2Model.RecreationalDrugUseCode + "|" + pV2Model.AdmissionLevelofCareCode + "|" + pV2Model.PrecautionCode
                      + "|" + pV2Model.PatientConditionCode + "|" + pV2Model.LivingWillCode + "|" + pV2Model.OrganDonorCode + "|" + pV2Model.AdvanceDirectiveCode + "|" + pV2Model.PatientStatusEffectiveDate.ToString("yyyyMMddHHmmss") + "|" + pV2Model.ExpectedLOAReturnDate.ToString("yyyyMMddHHmmss")
                      + "|" + pV2Model.ExpectedPre_admissionTestingDate.ToString("yyyyMMddHHmmss") + "|" + pV2Model.NotifyClergyCode;
            Debug.WriteLine("PV2Message: " + PV2Message);


        }



        private void CreateDb1Segment(MessageModel aDTMessageModel)
        {
            /*DB1-1 Set ID - DB1,DB1-2 Disabled Person Code,DB1-3 Disabled Person Identifier,DB1-4 Disabled Indicator
DB1-5 Disability Start Date,DB1-6 Disability End Date,DB1-7 Disability Return to Work Date,DB1-8 Disability Unable to Work Date */



            DB1Model dB1Model = new DB1Model();
            dB1Model.SetID = 2;
            dB1Model.DisabledPersonCode = "3244";
            dB1Model.DisabledPersonIdentifier = 15;
            dB1Model.DisabledIndicator = 02;
            dB1Model.DisabilityStartDate = DateTime.Now;
            dB1Model.DisabilityEndDate = DateTime.Now;
            dB1Model.DisabilityReturntoWorkDate = DateTime.Now;
            dB1Model.DisabilityUnabletoWorkDate = DateTime.Now;
            string DB1Message = "DB1|";

            DB1Message = DB1Message + dB1Model.SetID + "|" + dB1Model.DisabledPersonCode + "|" + dB1Model.DisabledPersonIdentifier + "|" + dB1Model.DisabledIndicator + "|" + dB1Model.DisabilityStartDate.ToString("yyyyMMddHHmmss") + "|" + dB1Model.DisabilityEndDate.ToString("yyyyMMddHHmmss") + "|" + dB1Model.DisabilityReturntoWorkDate.ToString("yyyyMMddHHmmss") + "|" + dB1Model.DisabilityUnabletoWorkDate.ToString("yyyyMMddHHmmss");
            Debug.WriteLine("DB1Message: " + DB1Message);

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
    }
}
