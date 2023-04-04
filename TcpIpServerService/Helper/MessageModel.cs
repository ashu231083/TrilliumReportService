using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HelperHL7
{
    public class MessageModel
    {
        public string PatientId { get; set; }
        public string PatientId_External { get; set; }
        public string PatientId_Internal { get; set; }
        public string PatientId_Alternate { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientHealthCardNo { get; set; }
        public string PatientAddress { get; set; }
        public string PatientCity { get; set; }
        public string PatientState { get; set; }
        public string PatientCountry { get; set; }
        public string MessageType { get; set; }
        public string MessageTypeTriggerEvent { get; set; }
        public string VersionID { get; set; }
        public string MessageControlID { get; set; }
        public string ProcessingID { get; set; }
        public string FieldSeparator { get; set; }
        public string EncodingCharacters { get; set; }
        public string SendingApplication { get; set; }
        public string SendingFacility { get; set; }
        public string ReceivingApplication { get; set; }
        public string ReceivingFacility { get; set; }
        public string DateTimeOfMessage { get; set; }
        public string EventTypeCode { get; set; }
        public string EventRecordDateTime { get; set; }
        public string LocationFacility { get; set; }
        public string LocationPointOfCare { get; set; }
        public string AdminssionType { get; set; }
        public int ReferringDoctorId { get; set; }
        public string ReferringDoctorFirstName { get; set; }
        public string ReferringDoctorLastName { get; set; }
        public string ReferringDoctorIdentifierTypeCode { get; set; }
        public string AdmitDateTime { get; set; }

        public string DateTimeofMessage { get; set; }
        public string Security { get; set; }

        public string messagetype { get; set; }
        public string triggerevent { get; set; }

        public string SequenceNumber { get; set; }
        public string ContinuationPointer { get; set; }
        public string AcceptAcknowledgmentType { get; set; }
        public string ApplicationAcknowledgmentType { get; set; }
        public string CountryCode { get; set; }
        public string CharacterSet { get; set; }
        public string PrincipalLanguageofMessage { get; set; }
        public string AlternateCharacterSetHandlingScheme { get; set; }
        public string PIDSetID { get; set; }
        public string PatientID_External { get; set; }
        public string External_ID { get; set; }
        public string External_checkdigit { get; set; }
        public string External_codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string External_assigningauthority { get; set; }
        public string External_identifiertypecode { get; set; }
        public string External_assigningfacility { get; set; }
        public string PatientID_Internal { get; set; }
        public string Internal_ID { get; set; }
        public string Internal_checkdigit { get; set; }
        public string Internal_codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string Internal_assigningauthority { get; set; }
        public string Internal_identifiertypecode { get; set; }
        public string Internal_assigningfacility { get; set; }

        public string Alternate_ID { get; set; }
        public string Alternate_checkdigit { get; set; }
        public string Alternate_codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string Alternate_assigningauthority { get; set; }
        public string Alternate_identifiertypecode { get; set; }
        public string Alternate_assigningfacility { get; set; }
        public string PatientName { get; set; }
        public string familyname { get; set; }
        public string givenname { get; set; }
        public string middleinitial { get; set; }
        public string MotherMaidenName { get; set; }
        public string DateofBirth { get; set; }
        public string Sex { get; set; }
        public string PatientAlias { get; set; }
        public string Race { get; set; }
        public string streetaddress { get; set; }
        public string otherdesignation { get; set; }
        public string city { get; set; }
        public string stateorprovince { get; set; }
        public string ziporpostalcode { get; set; }
        public string country { get; set; }
        public string addresstype { get; set; }
        public string othergeographicdesignation { get; set; }
        public string countrycode { get; set; }
        public string censustract { get; set; }
        public string addressrepresentationcode { get; set; }
        public string addressvalidityrange { get; set; }
        public string CountryCode2 { get; set; }
        public string PhoneNumber_Home { get; set; }
        public string PhoneNumber_Business { get; set; }
        public string PrimaryLanguage { get; set; }
        public string MaritalStaus { get; set; }
        public string Religion { get; set; }
        public string PatientAccountNumber { get; set; }
        public string PatientAccount_id { get; set; }
        public string checkdigit { get; set; }
        public string codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string SSNNumber_Patient { get; set; }
        public string DriverLicenseNumber_Patient { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string IssuingState_province_country { get; set; }
        public string MotherIdentifier { get; set; }
        public string EthnicGroup { get; set; }
        public string BirthPlace { get; set; }
        public string MultipleBirthIndicator { get; set; }
        public string BirthOther { get; set; }
        public string Citizenship { get; set; }
        public string VeteransMilitaryStatus { get; set; }
        public string NationalityCode { get; set; }
        public string PatientDeathDateTime { get; set; }
        public string PatientDeathIndicator { get; set; }
        public string PV1SetID { get; set; }
        public string PatientClass { get; set; }
        public string AssignedPatientLocation { get; set; }
        public string PointOfCare { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
        public string Facility { get; set; }
        public string LocationStatus { get; set; }
        public string PersonLocationType { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string LocationType { get; set; }
        public string AdmissionType { get; set; }
        public string PreadmitNumber { get; set; }
        public string PriorPatientLocation { get; set; }
        public string AttendingDoctor { get; set; }
        public string ReferringDoctor { get; set; }
        public string IDNumber { get; set; }
        public string Family_LastName { get; set; }
        public string GivenName { get; set; }
        public string ConsultingDoctor { get; set; }
        public string HospitalService { get; set; }
        public string TemporaryLocation { get; set; }
        public string PreadmitTestIndicator { get; set; }
        public string Re_AdmissionIndicator { get; set; }
        public string AdmitSource { get; set; }
        public string AmbulatoryStatus { get; set; }
        public string VIPIndicator { get; set; }
        public string AdmittingDoctor { get; set; }
        public string PatientType { get; set; }
        public string VisitNumber { get; set; }
        public string FinancialClass { get; set; }
        public string ChargePriceIndicator { get; set; }
        public string CourtesyCode { get; set; }
        public string CreditRating { get; set; }
        public string ContractCode { get; set; }
        public string ContractEffectiveDate { get; set; }
        public string ContractAmount { get; set; }
        public string ContractPeriod { get; set; }
        public string InterestCode { get; set; }
        public string TransfertoBadDebtCode { get; set; }
        public string TransfertoBadDebtDate { get; set; }
        public string BadDebtAgencyCode { get; set; }
        public string BadDebtTransferAmount { get; set; }
        public string BadDebtRecoveryAmount { get; set; }
        public string DeleteAccountIndicator { get; set; }
        public string DeleteAccountDate { get; set; }
        public string DischargeDisposition { get; set; }
        public string DischargedToLocation { get; set; }
        public string DietType { get; set; }
        public string ServicingFacility { get; set; }
        public string BedStatus { get; set; }
        public string AccountStatus { get; set; }
        public string PendingLocation { get; set; }
        public string PriorTemporaryLocation { get; set; }
        public string AdmitDatetime { get; set; }
        public string DischargeDatetime { get; set; }
        public string CurrentPatientBalance { get; set; }
        public string TotalCharges { get; set; }
        public string TotalAdjustments { get; set; }
        public string TotalPayments { get; set; }
        public string AlternateVisitID { get; set; }
        public string VisitIndicator { get; set; }
        public string OtherHealthcareProvider { get; set; }
        public string OrderControl { get; set; }
        public string PlacerOrderNumber { get; set; }
        public string FillerOrderNumber { get; set; }
        public string PlacerGroupNumber { get; set; }
        public string OrderStatus { get; set; }
        public string ResponseFlag { get; set; }
        public string Quantity_Timing { get; set; }
        public string Quantity { get; set; }
        public string Interval { get; set; }
        public string Duration { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string Priority { get; set; }
        public string Parent { get; set; }
        public string DateTimeOfTransaction { get; set; }
        public string EnteredBy { get; set; }
        public string IDNumber2 { get; set; }
        public string FamilyLastName { get; set; }
        public string GivenName2 { get; set; }
        public string VerifiedBy { get; set; }
        public string OrderingProvider { get; set; }
        public string ID_Number { get; set; }
        public string Family_LastName2 { get; set; }
        public string Given_Name { get; set; }
        public string EntererLocation { get; set; }
        public string PointOfCare2 { get; set; }
        public string Room2 { get; set; }
        public string Bed2 { get; set; }
        public string Facility2 { get; set; }
        public string LocationStatus2 { get; set; }
        public string PersonLocationType2 { get; set; }
        public string Building2 { get; set; }
        public string Floor2 { get; set; }
        public string LocationDescription { get; set; }
        public string CallBackPhoneNumber { get; set; }
        public string PhoneNumber999 { get; set; }
        public string TelecommunicationUseCode { get; set; }
        public string OrderEffectiveDatetime { get; set; }
        public string OrderControlCodeReason { get; set; }
        public string EnteringOrganization { get; set; }
        public string Identifier { get; set; }
        public string Text { get; set; }
        public string EnteringDevice { get; set; }
        public string ActionBy { get; set; }
        public string AdvancedBeneficiaryNoticeCode { get; set; }
        public string OrderingFacilityName { get; set; }
        public string OrderingFacilityAddress { get; set; }
        public string OrderingFacilityPhoneNumber { get; set; }
        public string OrderingProviderAddress { get; set; }
        public string StreetAddress { get; set; }
        public string OtherDesignation { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string ZipOrPostalCode { get; set; }
        public string Country { get; set; }
        public string AddressType { get; set; }
        public string OtherGeographicDesignation { get; set; }
        public string SetID { get; set; }
        public string PlacerOrderNumber2 { get; set; }
        public string FillerOrderNumber2 { get; set; }
        public string UniversalServiceID { get; set; }
        public string Identifier2 { get; set; }
        public string Text2 { get; set; }
        public string NameOfCodingSystem { get; set; }
        public string AlternateIdentifier { get; set; }
        public string AlternateText { get; set; }
        public string Priority_OBR { get; set; }
        public string RequestedDateTime { get; set; }
        public string ObservationDateTime { get; set; }
        public string ObservationEndDateTime { get; set; }
        public string CollectionVolume { get; set; }
        public string CollectorIdentifier { get; set; }
        public string SpecimenActionCode { get; set; }
        public string DangerCode { get; set; }
        public string RelevantClinicalInfo { get; set; }
        public string SpecimenReceivedDateTime { get; set; }
        public string SpecimenSource { get; set; }
        public string OrderingProvider2 { get; set; }
        public string IDNumber3 { get; set; }
        public string FamilyLastName2 { get; set; }
        public string GivenName3 { get; set; }
        public string OrderCallBackPhoneNumber { get; set; }
        public string PhoneNumber9992 { get; set; }
        public string TelecommunicationUseCode2 { get; set; }
        public string PlacerField1 { get; set; }
        public string PlacerField2 { get; set; }
        public string FillerField1 { get; set; }
        public string FillerField2 { get; set; }
        public string ResultsRpt_StatusChangeDateTime { get; set; }
        public string TimeOfAnEvent { get; set; }
        public string DegreeOfPrecision { get; set; }
        public string ChargeToPractice { get; set; }
        public string DollarAmount { get; set; }
        public string ChargeCode { get; set; }
        public string DiagnosticServSectID { get; set; }
        public string ResultStatus { get; set; }
        public string ParentResult { get; set; }
        public string Quantity_Timing2 { get; set; }
        public string Quantity2 { get; set; }
        public string Interval2 { get; set; }
        public string Duration2 { get; set; }
        public string StartDateTime2 { get; set; }
        public string EndDateTime2 { get; set; }
        public string Priority2 { get; set; }
        public string ResultCopiesTo { get; set; }
        public string Parent2 { get; set; }
        public string TransportationMode { get; set; }
        public string ReasonForStudy { get; set; }
        public string Identifier1 { get; set; }
        public string Text1 { get; set; }
        public string PrincipalResultInterpreter { get; set; }
        public string Name { get; set; }
        public string StartDateTime1 { get; set; }
        public string EndDateTime1 { get; set; }
        public string PointOfCare3 { get; set; }
        public string Room3 { get; set; }
        public string Bed3 { get; set; }
        public string Facility3 { get; set; }
        public string LocationStatus3 { get; set; }
        public string PersonLocationType3 { get; set; }
        public string Building3 { get; set; }
        public string Floor3 { get; set; }
        public string AssistantResultInterpreter { get; set; }
        public string Name2 { get; set; }
        public string StartDateTime4 { get; set; }
        public string EndDateTime4 { get; set; }
        public string PointOfCare4 { get; set; }
        public string Room4 { get; set; }
        public string Bed4 { get; set; }
        public string Facility4 { get; set; }
        public string LocationStatus4 { get; set; }
        public string PersonLocationType4 { get; set; }
        public string Building4 { get; set; }
        public string Floor4 { get; set; }
        public string Technician { get; set; }
        public string Name3 { get; set; }
        public string StartDateTime3 { get; set; }
        public string EndDateTime3 { get; set; }
        public string PointOfCare5 { get; set; }
        public string Room5 { get; set; }
        public string Bed5 { get; set; }
        public string Facility5 { get; set; }
        public string LocationStatus5 { get; set; }
        public string PersonLocationType5 { get; set; }
        public string Building5 { get; set; }
        public string Floor5 { get; set; }
        public string Transcriptionist { get; set; }
        public string Name4 { get; set; }
        public string StartDateTime6 { get; set; }
        public string EndDateTime6 { get; set; }
        public string PointOfCare6 { get; set; }
        public string Room6 { get; set; }
        public string Bed6 { get; set; }
        public string Facility6 { get; set; }
        public string LocationStatus6 { get; set; }
        public string PersonLocationType6 { get; set; }
        public string Building6 { get; set; }
        public string Floor6 { get; set; }
        public string ScheduledDateTime { get; set; }
        public string TimeOfAnEvent1 { get; set; }
        public string DegreeOfPrecision1 { get; set; }
        public string NumberOfSampleContainers { get; set; }
        public string TransportLogisticsOfCollectedSample { get; set; }
        public string Identifier3 { get; set; }
        public string Text3 { get; set; }
        public string NameOfCodingSystem2 { get; set; }
        public string AlternateIdentifier2 { get; set; }
        public string AlternateText2 { get; set; }
        public string NameOfAlternateCodingSystem { get; set; }
        public string CollectorComment { get; set; }
        public string TransportArrangementResponsibility { get; set; }
        public string TransportArranged { get; set; }
        public string EscortRequired { get; set; }
        public string PlannedPatientTransportComment { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureCodeModifier { get; set; }
    }

    public class MSHModel
    {
        /* MSH-3 SendingApplication, MSH-4 Sending Facility, MSH-5 Receiving Application, MSH-6 Receiving Facility, MSH-7 Date\Time of Message = 20230125124217
        MSH-8 Security, MSH-9 Message Type = ORM ^ 001, MSH-10 Message Control ID, MSH-11 Processing ID, MSH-12 Version ID
        MSH-13 Sequence Number, MSH-14 Continuation Pointer, MSH-15 Accept Acknowledgment Type, MSH-16 Application Acknowledgment Type
        MSH-17 Country Code, MSH-18 Character Set, MSH-19 Principal Language of Message*/

        public string SendingApplication { get; set; }
        public string SendingFacility { get; set; }
        public string ReceivingApplication { get; set; }
        public string ReceivingFacility { get; set; }
        public DateTime DateTimeofMessage { get; set; }
        public string Security { get; set; }
        public string MessageType { get; set; }
        public string messagetype { get; set; }
        public string triggerevent { get; set; }
        public int MessageControlID { get; set; }
        public int ProcessingID { get; set; }
        public string VersionID { get; set; }
        public string SequenceNumber { get; set; }
        public string ContinuationPointer { get; set; }
        public string AcceptAcknowledgmentType { get; set; }
        public string ApplicationAcknowledgmentType { get; set; }
        public string CountryCode { get; set; }
        public string CharacterSet { get; set; }
        public string PrincipalLanguageofMessage { get; set; }
        public string AlternateCharacterSetHandlingScheme { get; set; }

    }

    public class PIDModel
    {
        public int SetID { get; set; }
        public string PatientID_External { get; set; }
        public int External_ID { get; set; }
        public int External_checkdigit { get; set; }
        public string External_codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string External_assigningauthority { get; set; }
        public string External_identifiertypecode { get; set; }
        public string External_assigningfacility { get; set; }
        public string PatientID_Internal { get; set; }
        public int Internal_ID { get; set; }
        public int Internal_checkdigit { get; set; }
        public string Internal_codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string Internal_assigningauthority { get; set; }
        public string Internal_identifiertypecode { get; set; }
        public string Internal_assigningfacility { get; set; }

        public string PatientID_Alternate { get; set; }
        public int Alternate_ID { get; set; }
        public int Alternate_checkdigit { get; set; }
        public string Alternate_codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string Alternate_assigningauthority { get; set; }
        public string Alternate_identifiertypecode { get; set; }
        public string Alternate_assigningfacility { get; set; }
        public string PatientName { get; set; }
        public string familyname { get; set; }

        public string givenname { get; set; }
        public string middleinitial { get; set; }



        public string MotherMaidenName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Sex { get; set; }

        public string PatientAlias { get; set; }
        public string Race { get; set; }


        public string PatientAddress { get; set; }
        public string streetaddress { get; set; }
        public string otherdesignation { get; set; }
        public string city { get; set; }
        public string stateorprovince { get; set; }
        public string ziporpostalcode { get; set; }
        public string country { get; set; }
        public string addresstype { get; set; }
        public string othergeographicdesignation { get; set; }
        public string countrycode { get; set; }
        public string censustract { get; set; }

        public string addressrepresentationcode { get; set; }
        public string addressvalidityrange { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber_Home { get; set; }
        public string PhoneNumber_Business { get; set; }

        public string PrimaryLanguage { get; set; }
        public string MaritalStaus { get; set; }
        public string Religion { get; set; }
        public string PatientAccountNumber { get; set; }

        public int PatientAccount_id { get; set; }
        public int checkdigit { get; set; }
        public string codeidentifyingthecheckdigitschemeemployed { get; set; }

        public string SSNNumber_Patient { get; set; }


        public string DriverLicenseNumber_Patient { get; set; }

        public string DriverLicenseNumber { get; set; }

        public string IssuingState_province_country { get; set; }
        public string MotherIdentifier { get; set; }
        public string EthnicGroup { get; set; }
        public string BirthPlace { get; set; }
        public string MultipleBirthIndicator { get; set; }

        public string BirthOther { get; set; }
        public string Citizenship { get; set; }

        public string VeteransMilitaryStatus { get; set; }
        public string NationalityCode { get; set; }
        public DateTime PatientDeathDateTime { get; set; }

        public string PatientDeathIndicator { get; set; }

    }

    public class EVNModel
    {
        public string EventTypeCode { get; set; }
        public DateTime RecordedDateTime { get; set; }
        public DateTime DateTimePlannedEvent { get; set; }
        public string EventReasonCode { get; set; }
        public int OperatorID { get; set; }
        public DateTime EventOccured { get; set; }
        public string EventFacility { get; set; }
    }

    public class PV1Model
    {
        /* PV1-1 Set ID - PV1 = 1234,PV1-2 Patient Class,PV1-3 Assigned Patient Location,
         * PV1-3.1 point of care,PV1-3.2 room,PV1-3.3 bed,PV1-3.4 facility(HD),PV1-3.5 location status,PV1-3.6 person location type
         PV1-3.7 building,PV1-3.8 floor, PV1-3.9 Location description,
         PV1-4 Admission Type, PV1-5 Preadmit Number, PV1-6 Prior Patient Location, PV1-7 Attending Doctor,
         PV1-8 Referring Doctor, PV1-8.1 ID number(ST), PV1-8.2 family+last name, PV1-8.3 given name,
         PV1-9 Consulting Doctor, PV1-10 Hospital Service, PV1-11 Temporary Location, PV1-12 Preadmit Test Indicator,PV1-13 Re-admission Indicator
         PV1-14 Admit Source,PV1-15 Ambulatory Status,PV1-16 VIP Indicator,PV1-17 Admitting Doctor,PV1-18 Patient Type,PV1-19 Visit Number
         PV1-20 Financial Class,PV1-21 Charge Price Indicator,PV1-22 Courtesy Code,PV1-23 Credit Rating,PV1-24 Contract Code,
         PV1-25 Contract Effective Date,PV1-26 Contract Amount,PV1-27 Contract Period,PV1-28 Interest Code,PV1-29 Transfer to Bad Debt Code
        PV1-30 Transfer to Bad Debt Date,PV1-31 Bad Debt Agency Code,PV1-32 Bad Debt Transfer Amount,PV1-33 Bad Debt Recovery Amount
        PV1-34 Delete Account Indicator,PV1-35 Delete Account Date,PV1-36 Discharge Disposition,PV1-37 Discharged to Location,PV1-38 Diet Type
        PV1-39 Servicing Facility,PV1-40 Bed Status,PV1-41 Account Status,PV1-42 Pending Location,PV1-43 Prior Temporary Location,
        PV1-44 Admit Date/time,PV1-45 Discharge Date/time,PV1-46 Current Patient Balance,PV1-47 Total Charges,PV1-48 Total Adjustments,
        PV1-49 Total Payments,PV1-50 Alternate Visit ID,PV1-51 visit Indicator,PV1-52 Other Healthcare Provider*/


        public int SetID { get; set; }
        public string PatientClass { get; set; }
        public string AssignedPatientLocation { get; set; }
        public string PointOfCare { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
        public string Facility { get; set; }
        public string LocationStatus { get; set; }
        public string PersonLocationType { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string LocationType { get; set; }
        public string AdmissionType { get; set; }
        public string PreadmitNumber { get; set; }
        public string PriorPatientLocation { get; set; }
        public string AttendingDoctor { get; set; }
        public string ReferringDoctor { get; set; }
        public string IDNumber { get; set; }
        public string Family_LastName { get; set; }
        public string GivenName { get; set; }
        public string ConsultingDoctor { get; set; }
        public string HospitalService { get; set; }
        public string TemporaryLocation { get; set; }
        public string PreadmitTestIndicator { get; set; }
        public string Re_AdmissionIndicator { get; set; }
        public string AdmitSource { get; set; }
        public string AmbulatoryStatus { get; set; }
        public string VIPIndicator { get; set; }
        public string AdmittingDoctor { get; set; }
        public string PatientType { get; set; }
        public string VisitNumber { get; set; }
        public string FinancialClass { get; set; }
        public string ChargePriceIndicator { get; set; }
        public string CourtesyCode { get; set; }
        public string CreditRating { get; set; }
        public string ContractCode { get; set; }
        public DateTime ContractEffectiveDate { get; set; }
        public int ContractAmount { get; set; }
        public string ContractPeriod { get; set; }
        public string InterestCode { get; set; }
        public string TransfertoBadDebtCode { get; set; }
        public DateTime TransfertoBadDebtDate { get; set; }
        public string BadDebtAgencyCode { get; set; }
        public int BadDebtTransferAmount { get; set; }
        public int BadDebtRecoveryAmount { get; set; }
        public string DeleteAccountIndicator { get; set; }
        public DateTime DeleteAccountDate { get; set; }
        public string DischargeDisposition { get; set; }
        public string DischargedToLocation { get; set; }
        public string DietType { get; set; }
        public string ServicingFacility { get; set; }
        public string BedStatus { get; set; }
        public string AccountStatus { get; set; }
        public string PendingLocation { get; set; }
        public string PriorTemporaryLocation { get; set; }
        public DateTime AdmitDatetime { get; set; }
        public DateTime DischargeDatetime { get; set; }
        public int CurrentPatientBalance { get; set; }
        public int TotalCharges { get; set; }
        public int TotalAdjustments { get; set; }
        public int TotalPayments { get; set; }
        public int AlternateVisitID { get; set; }
        public string VisitIndicator { get; set; }
        public string OtherHealthcareProvider { get; set; }

    }


    public class GT1Model
    {
        public int SetID { get; set; }
        public int GuarantorNumber { get; set; }
        public string GuarantorName { get; set; }
        public string familyname { get; set; }

        public string givenname { get; set; }
        public string middleinitial { get; set; }
        public string GuarantorSpouseName { get; set; }
        public string GuarantorAddress { get; set; }
        public string streetaddress { get; set; }
        public string otherdesignation { get; set; }
        public string city { get; set; }
        public string stateorprovince { get; set; }
        public string ziporpostalcode { get; set; }
        public string country { get; set; }
        public string GuarantorPhNumHome { get; set; }
        public string GuarantorPhNumBusiness { get; set; }
        public DateTime GuarantorDateTimeofBirth { get; set; }
        public string GuarantorSex { get; set; }
        public string GuarantorType { get; set; }

        public string GuarantorRelationship { get; set; }
        public string GuarantorSSN { get; set; }
        public DateTime GuarantorDateBegin { get; set; }
        public DateTime GuarantorDateEnd { get; set; }
        public string GuarantorPriority { get; set; }
        public string GuarantorEmployerName { get; set; }
        public string GuarantorEmployerAddress { get; set; }
        public string employer_streetaddress { get; set; }
        public string employer_otherdesignation { get; set; }
        public string employer_city { get; set; }
        public string employer_stateorprovince { get; set; }
        public string employer_ziporpostalcode { get; set; }
        public string employer_country { get; set; }


        public int GuarantorEmployPhoneNumber { get; set; }
        public string GuarantorEmployeeIDNumber { get; set; }
        public string GuarantorEmployementStatus { get; set; }
        public string GuarantorOrganization { get; set; }
    }

    public class IN1Model
    {
        public int SetID { get; set; }
        public string InsurancePlanID { get; set; }
        public int InsuranceCompanyID { get; set; }
        public string InsuranceCompanyName { get; set; }

        public string InsuranceCompanyAddress { get; set; }
        public string InsuranceCoContactPpers { get; set; }
        public string InsuranceCoPhoneNuber { get; set; }
        public string GroupNumber { get; set; }
        public string GroupName { get; set; }
        public string InsuredGroupEmployerID { get; set; }
        public string InsuredGroupEmpName { get; set; }
        public DateTime PlanEffectiveDate { get; set; }
        public DateTime PlanExpirationDate { get; set; }
        public string AuthorizationInformation { get; set; }
        public string PlanType { get; set; }
        public string NameOfInsured { get; set; }
        public string familyName { get; set; }
        public string givenName { get; set; }
        public string middleInitialorName { get; set; }
        public string InsuredRelationshipToPatient { get; set; }

        public DateTime InsuredDateOfBirth { get; set; }
        public string InsuredAddress { get; set; }

        public string streetaddress { get; set; }
        public string otherdesignation { get; set; }
        public string city { get; set; }
        public string stateorprovince { get; set; }
        public string ziporpostalcode { get; set; }
        public string country { get; set; }
        public string AssignmentOfBenefits { get; set; }
        public string CoordinationOfBenefits { get; set; }
        public string CoordofBenPriority { get; set; }
        public string NoticeofAdmissionCode { get; set; }
        public DateTime NoticeofAdmissionDate { get; set; }
        public string ReptofEligibilityCode { get; set; }
        public DateTime ReptofEligibilityDate { get; set; }
        public string ReleaseInfoCode { get; set; }
        public string PreAdmitCert_PAC { get; set; }



        public DateTime VerificationDateTime { get; set; }
        public string VerificationBy { get; set; }
        public string TypeofAgreementCode { get; set; }
        public string BillingStatus { get; set; }
        public string LifeTimeReverseDays { get; set; }
        public string DelayBeforeLifeTimeReverseDays { get; set; }
        public string CompanyPlanCode { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyDeductible { get; set; }
        public string PolicyLimitAmount { get; set; }
        public string PolicyLimitDays { get; set; }
        public string RoomRate_SemiPrivate { get; set; }
        public string RoomRate_Private { get; set; }
        public string InsuredEmploymentStatus { get; set; }
        public string InsuredSex { get; set; }
        public string InsuredEmployerAddress { get; set; }
        public string Employer_streetaddress { get; set; }
        public string Employer_otherdesignation { get; set; }
        public string Employer_city { get; set; }
        public string Employer_stateorprovince { get; set; }
        public string Employer_ziporpostalcode { get; set; }
        public string VerificationStatus { get; set; }
        public string PriorInsurancePlanID { get; set; }

        public string CoverageType { get; set; }
        public string Handicap { get; set; }
        public string InsuredIDNumber { get; set; }



    }

    public class IN2Model
    {
        public int InsuredEmployeeID { get; set; }
        public string InsuredSocialSecurityNumber { get; set; }
        public string InsuredEmployerName { get; set; }
        public string EmployerInformationData { get; set; }
        public string MailClaimParty { get; set; }
        public string MedicareHealthInsCardNumber { get; set; }

        public string MedicaidCaseName { get; set; }
        public string MedicaidCaseNumber { get; set; }
        public string CampusSponsorName { get; set; }
        public string CampusIDNumber { get; set; }
        public string DependentofCampusRecipient { get; set; }
        public string CampusOrganization { get; set; }
        public string CampusStation { get; set; }
        public string CampusService { get; set; }
        public string CampusRank_Grade { get; set; }
        public string CampusStatus { get; set; }
        public DateTime CampusRetireDate { get; set; }
        public string CampusNonAvailCertonFile { get; set; }
        public string BabyCoverage { get; set; }
        public string CombineBabyBill { get; set; }
        public string BloodDeductile { get; set; }
        public string SpecialCoverageApprovalName { get; set; }
        public string SpecialCoverageApprovalTitle { get; set; }
        public string NonCoveredInsuranceCode { get; set; }
        public string PayorID { get; set; }
        public string PayorSubscriberID { get; set; }
        public string EligibilitySource { get; set; }

        public string RoomCoverageTypeAmount { get; set; }
        public string PolicyTypeAmount { get; set; }


        public string DailyDeductible { get; set; }
        public string LivingDependency { get; set; }

        public string AmbulatoryStatus { get; set; }
        public string Citizenship { get; set; }

        public string PrimaryLanguage { get; set; }
        public string LivingArrangement { get; set; }

        public string PublicityIndicator { get; set; }
        public string ProtectionIndicator { get; set; }

        public string StudentIndicator { get; set; }
        public string Religion { get; set; }
        public string MotherMaidenName { get; set; }

        public string NationalityCode { get; set; }


        public string EthnicGroup { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime EmploymentStartDate { get; set; }

        public DateTime EmploymentStopDate { get; set; }

        public string JobTitle { get; set; }
        public string JobCode_Class { get; set; }
        public string JobStatus { get; set; }

        public string EmployerContactPersonName { get; set; }
        public string EmployerContactPersonPhoneNumber { get; set; }



        public string EmployerContactReason { get; set; }
        public string InsuredContactPersonName { get; set; }
        public string InsuredContactPersonTeleNumber { get; set; }

        public string InsuredContactPersonReason { get; set; }
        public DateTime RelationshipToPatientStartDate { get; set; }
        public DateTime RelationshipToPatientStopDate { get; set; }

        public string InsuranceCoContactReason { get; set; }
        public string InsuranceCoContactPhoneNumber { get; set; }



        public string PolicyScope { get; set; }
        public string PolicySource { get; set; }
        public string PatientMemberNumber { get; set; }

        public string GuarantorRelationshipToInsured { get; set; }

        public string InsuredTelephoneNumber { get; set; }
        public string InsuredEmployerTelephoneNumber { get; set; }


    }


    public class NK1Model
    {
        /*NK1-1 Set ID - NK1 = 1234,NK1-2 Name,NK1-3 Relationship,NK1-4 Address,NK1-5 Phone Number,NK1-6 Business Phone Number
           NK1-7 Contact Role,NK1-8 Start Date = 20230125161507,NK1-9 End Date = 20230125161507,NK1-10 Next of Kin/Associated Parties Job Title
           NK1-11 Next of Kin/Associated Parties Job Code/Class,NK1-12 Next of Kin/Associated Parties Employee Number
           NK1-13 Organization Name - NK1,NK1-14 Marital Status,NK1-15 Administrative Sex,NK1-16 Date/Time of Birth,NK1-17 Living Dependency
           NK1-18 Ambulatory Status,NK1-19 Citizenship,NK1-20 Primary Language,NK1-21 Living Arrangement,NK1-22 Publicity Code
           NK1-23 Protection Indicator,NK1-24 Student Indicator,NK1-25 Religion,NK1-26 Mother's Maiden Name,NK1-27 Nationality
           NK1-28 Ethnic Group,NK1-29 Contact Reason,NK1-30 Contact Person's Name,NK1-31 Contact Person's Telephone Number
           NK1-32 Contact Person's Address,NK1-33 Next of Kin\Associated Party's Identifiers,NK1-34 Job Status,NK1-35 Race,NK1-36 Handicap,
           NK1-37 Contact Reason Social Secutity Number */


        public int SetID { get; set; }
        public string Name { get; set; }
        public string familyname { get; set; }
        public string givenname { get; set; }
        public string Relationship { get; set; }
        public string Address { get; set; }
        public string streetaddress { get; set; }
        public string otherdesignation { get; set; }
        public string city { get; set; }
        public string stateorprovince { get; set; }
        public string ziporpostalcode { get; set; }

        public int PhoneNumber { get; set; }
        public int BusinesPhoneNumber { get; set; }
        public string ContactRole { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string NextofKin_AssociatedPartiesJobTitle { get; set; }
        public string NextofKin_AssociatedPartiesJobCode_Class { get; set; }
        public string NextofKin_AssociatedPartiesEmployeeNumber { get; set; }
        public string OrganizationName { get; set; }
        public string MaritalStatus { get; set; }
        public string AdministrativeSex { get; set; }
        public DateTime Date_TimeofBirth { get; set; }
        public string LivingDependency { get; set; }
        public string AmbulatoryStatus { get; set; }
        public string Citizenship { get; set; }
        public string PrimaryLanguage { get; set; }
        public string LivingArrangement { get; set; }
        public string PublicityCode { get; set; }
        public string ProtectionIndicator { get; set; }
        public string StudentIndicator { get; set; }
        public string Religion { get; set; }
        public string MothersMaidenName { get; set; }
        public string Nationality { get; set; }
        public string EthnicGroup { get; set; }
        public string ContactReason { get; set; }
        public string ContactPersonName { get; set; }
        public int ContactPersonTelephoneNumber { get; set; }
        public string ContactPersonAddress { get; set; }
        public string NextofKin_AssociatedPartyIdentifiers { get; set; }
        public string JobStatus { get; set; }
        public string Race { get; set; }
        public string Handicap { get; set; }
        public int ContactPersonSocialSecutityNumber { get; set; }

    }


    public class PV2Model
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


        public string PriorPendingLocation { get; set; }
        public string AccommodationCode { get; set; }
        public string AdmitReason { get; set; }
        public string TransferReason { get; set; }
        public string PatientValuables { get; set; }
        public string PatientValuablesLocation { get; set; }
        public string VisitUserCode { get; set; }
        public DateTime ExpectedAdmitDate { get; set; }
        public DateTime ExpectedDischargeDate { get; set; }

        public string ActualLengthofInpatientStay { get; set; }
        public string EstimatedLengthofInpatientStay { get; set; }
        public string VisitDescription { get; set; }
        public string ReferralSourceCode { get; set; }
        public DateTime PreviousServiceDate { get; set; }
        public string EmploymentIllnessRelatedIndicator { get; set; }
        public string PurgeStatusCode { get; set; }
        public DateTime PurgeStatusDate { get; set; }
        public string SpecialProgramCode { get; set; }
        public string RetentionIndicator { get; set; }
        public string ExpectedNumberofInsurancePlan { get; set; }
        public string VisitPublicityCode { get; set; }
        public string VisitProtectionIndicator { get; set; }
        public string ClinicOrganizationName { get; set; }
        public string PatientStatusCode { get; set; }
        public string VisitPriorityCode { get; set; }
        public DateTime PreviousTreatmentDate { get; set; }
        public string ExpectedDischargeDisposition { get; set; }
        public DateTime SignatureOnFileDate { get; set; }
        public DateTime FirstSimilarIllnessDate { get; set; }
        public string PatientChargeAdjustmentCode { get; set; }
        public string RecurringServiceCode { get; set; }
        public string BillingMediaCode { get; set; }
        public DateTime ExpectedSurgeryDate { get; set; }
        public string MilitaryPartnershipCode { get; set; }
        public string MilitaryNon_availabilityCode { get; set; }
        public string NewbornBabyIndicator { get; set; }
        public string BabyDetainedIndicator { get; set; }
        public string ModeofArrivalCode { get; set; }
        public string RecreationalDrugUseCode { get; set; }
        public string AdmissionLevelofCareCode { get; set; }
        public string PrecautionCode { get; set; }
        public string PatientConditionCode { get; set; }
        public string LivingWillCode { get; set; }
        public string OrganDonorCode { get; set; }
        public string AdvanceDirectiveCode { get; set; }
        public DateTime PatientStatusEffectiveDate { get; set; }



        public DateTime ExpectedLOAReturnDate { get; set; }
        public DateTime ExpectedPre_admissionTestingDate { get; set; }
        public string NotifyClergyCode { get; set; }

    }

    public class AL1Model
    {
        public int SetID { get; set; }
        public int AllergenTypeCode { get; set; }
        public string AllergenCode { get; set; }
        public string AllergySeverityCode { get; set; }
        public int AllergyReactionCode { get; set; }
        public DateTime IdentificationDate { get; set; }

    }

    public class ROL1Model
    {
        public int RoleInstanceID { get; set; }
        public string ActionCode { get; set; }
        public string RoleROL { get; set; }
        public string RolePerson { get; set; }
        public DateTime RoleBeginDateTime { get; set; }
        public DateTime RoleEndDateTime { get; set; }
        public int RoleDuration { get; set; }
        public string RoleActionReason { get; set; }
        public string ProviderType { get; set; }
        public string OrganizationUnitType { get; set; }

        public string Office_HomeAddress_Birthplace { get; set; }
        public string Phone { get; set; }

    }

    public class DB1Model
    {
        public int SetID { get; set; }
        public string DisabledPersonCode { get; set; }
        public int DisabledPersonIdentifier { get; set; }
        public int DisabledIndicator { get; set; }
        public DateTime DisabilityStartDate { get; set; }
        public DateTime DisabilityEndDate { get; set; }
        public DateTime DisabilityReturntoWorkDate { get; set; }
        public DateTime DisabilityUnabletoWorkDate { get; set; }

    }

    public class OBXModel
    {
        public int SetID { get; set; }
        public string ValueType { get; set; }
        public int ObservationIdentifier { get; set; }
        public int ObservationSubID { get; set; }
        public string ObservationValue { get; set; }
        public string Units { get; set; }
        public string ReferencesRange { get; set; }
        public string AbnormalFlags { get; set; }
        public string Probability { get; set; }
        public string NatureofAbnormalTest { get; set; }

        public string ObservationResultStatus { get; set; }
        public DateTime EffectiveDateofReferenceRangeValues { get; set; }

        public string UserDefinedAccessChecks { get; set; }

        public DateTime DateTimeoftheObservation { get; set; }
        public string ProducersReference { get; set; }

        public string ResponsibleObserver { get; set; }
        public string ObservationMethod { get; set; }
        public string EquipmentInstanceIdentifier { get; set; }
        public DateTime DateTimeoftheAnalysis { get; set; }
        public string PerformingOrganizationName { get; set; }
        public string PerformingOrganizationAddress { get; set; }
        public string PerformingOrganizationMedicalDirector { get; set; }


    }

    public class DG1Model
    {
        /*DG1-1 Set ID - DG1,DG1-2 Diagnosis Coding Method,DG1-3 Diagnosis Code - DG1,DG1-4 Diagnosis Description,DG1-5 Diagnosis Date/Time
        DG1-6 Diagnosis Type,DG1-7 Major Diagnostic Category,DG1-8 Diagnostic Related Group,DG1-9 DRG Approval Indicator,DG1-10 DRG Grouper Review Code
        DG1-11 Outlier Type,DG1-12 Outlier Days,DG1-13 Outlier Cost,DG1-14 Grouper Version And Type,DG1-15 Diagnosis Priority
        DG1-16 Diagnosing Clinician,DG1-17 Diagnosis Classification,DG1-18 Confidential Indicator,DG1-19 Attestation Date/Time
        DG1-20 Diagnosis Identifier,DG1-21 Diagnosis Action Code */
        public int SetID { get; set; }
        public string DiagnosisCodingMethod { get; set; }
        public int DiagnosisCode { get; set; }
        public int DiagnosisDescription { get; set; }
        public DateTime DiagnosisDateTime { get; set; }
        public string DiagnosisType { get; set; }
        public string MajorDiagnosticCategory { get; set; }
        public string DiagnosticRelatedGroup { get; set; }
        public string DRGApprovalIndicator { get; set; }
        public string DRGGrouperReviewCode { get; set; }

        public string OutlierType { get; set; }
        public string Outlier { get; set; }
        public string OutlierDays { get; set; }

        public string OutlierCost { get; set; }

        public string GrouperVersionAndType { get; set; }
        public string DiagnosisPriority { get; set; }

        public string DiagnosingClinician { get; set; }
        public string DiagnosisClassification { get; set; }
        public string EquipmentInstanceIdentifier { get; set; }
        public string ConfidentialIndicator { get; set; }
        public DateTime AttestationDateTime { get; set; }
        public string DiagnosisIdentifier { get; set; }

        public string DiagnosisActionCode { get; set; }
    }

    public class PD1Model
    {       /*PD1-1 Living Dependency(C - Small Children Dependent, M - Medical Supervision Required, O - Other, S - Spouse Dependent, U - Unknown) = M,PD1-2 Living Arrangement(A - Alone,F - Family,I - Institution,R - Relative,S - Spouse Only,U - Unknown) = U,PD1-3 Patient Primary Facility
            PD1-4 Patient Primary Care Provider Name & ID No.,PD1-5 Student Indicator(F - Full-time student,N - Not a student,P - Part-time student) = N
            PD1-6 Handicap,PD1-7 Living Will Code(F - Yes patient has a living will but it is not on file, I - No patient does not have a living will but information was provided, N - No patient does not have a living will and no information was provided, U - Unknown, Y - Yes patient has a living will) = Y
            PD1-8 Organ Donor Code(F - Yes patient is a documented donor but documentation is not on file,I - No patient is not a documented donor but information was provided,N - No patient has not agreed to be a donor,P - Patient leaves organ donation decision to a specific person,R - Patient leaves organ donation decision to relatives,U - Unknown,Y - Yes patient is a documented donor and documentation is on file) = U
            PD1-9 Separate Bill(N - No, Y - Yes) = N,PD1-10 Duplicate Patient,PD1-11 Publicity Code(F - Family only,N - No Publicity,O - Other,U - Unknown) = U
            PD1-12 Protection Indicator(N - No, Y - Yes) = N,PD1-13 Protection Indicator Effective Date = 20230125154633
            PD1-14 Place of Workship,PD1-15 Advance Directive Code(DNR - Do not resuscitate,N - No directive) = N
            PD1-16 Immunization Registry Status(A - Active,I - Inactive,L -  Lost to follow-up (cancel contract),M -  Moved or gone elsewhere (cancel contract),O - Other,P -  Permanently inactive (Do not reactivate or add new entries to the record), U - Unknown) = U
            PD1-17 Immunization Registry Status Effective Date = 20230125154633,PD1-18 Publicity Code  Effective Date = 20230125154633
            PD1-19 Military Branch,PD1-20 Military Rank/Grade,PD1-21 Military Status(ACT - Active duty,DEC - Deceased,RET - Retired) = ACT */


        public string LivingDependency { get; set; }
        public string LivingArrangement { get; set; }
        public string PatientPrimaryFacility { get; set; }
        public string PatientPrimaryCareProviderName_ID_No { get; set; }
        public string StudentIndicator { get; set; }
        public string Handicap { get; set; }
        public string LivingWillCode { get; set; }
        public string OrganDonorCode { get; set; }
        public string SeparateBill { get; set; }
        public string DuplicatePatient { get; set; }
        public string PublicityCode { get; set; }
        public string ProtectionIndicator { get; set; }
        public DateTime ProtectionIndicatorEffectiveDate { get; set; }
        public string PlaceofWorkship { get; set; }
        public string AdvanceDirectiveCode { get; set; }
        public string ImmunizationRegistryStatus { get; set; }
        public DateTime ImmunizationRegistryStatusEffectiveDate { get; set; }
        public DateTime PublicityCodeEffectiveDate { get; set; }
        public string MilitaryBranch { get; set; }
        public string MilitaryRank_Grade { get; set; }
        public string MilitaryStatus { get; set; }
    }

    public class HL7Model
    {
        public string SendingApplication { get; set; }
        public string SendingFacility { get; set; }
        public string ReceivingApplication { get; set; }
        public string DateTimeofMessage { get; set; }
        public string Security { get; set; }
        public string MessageType { get; set; }
        public string messagetype { get; set; }
        public string triggerevent { get; set; }
        public string MessageControlID { get; set; }
        public string ProcessingID { get; set; }
        public string EventTypeCode { get; set; }
        public string VersionID { get; set; }
        public string SequenceNumber { get; set; }
        public string ContinuationPointer { get; set; }
        public string AcceptAcknowledgmentType { get; set; }
        public string ApplicationAcknowledgmentType { get; set; }
        public string CountryCode { get; set; }
        public string CharacterSet { get; set; }
        public string PrincipalLanguageofMessage { get; set; }
        public string AlternateCharacterSetHandlingScheme { get; set; }
        public string PIDSetID { get; set; }
        public string PatientID_External { get; set; }
        public string External_ID { get; set; }
        public string External_checkdigit { get; set; }
        public string External_codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string External_assigningauthority { get; set; }
        public string External_identifiertypecode { get; set; }
        public string External_assigningfacility { get; set; }
        public string PatientID_Internal { get; set; }
        public string Internal_ID { get; set; }
        public string Internal_checkdigit { get; set; }
        public string Internal_codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string Internal_assigningauthority { get; set; }
        public string Internal_identifiertypecode { get; set; }
        public string Internal_assigningfacility { get; set; }
        public string PatientID_Alternate { get; set; }
        public string Alternate_ID { get; set; }
        public string Alternate_checkdigit { get; set; }
        public string Alternate_codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string Alternate_assigningauthority { get; set; }
        public string Alternate_identifiertypecode { get; set; }
        public string Alternate_assigningfacility { get; set; }
        public string PatientName { get; set; }
        public string familyname { get; set; }
        public string givenname { get; set; }
        public string middleinitial { get; set; }
        public string MotherMaidenName { get; set; }
        public string DateofBirth { get; set; }
        public string Sex { get; set; }
        public string PatientAlias { get; set; }
        public string Race { get; set; }
        public string PatientAddress { get; set; }
        public string streetaddress { get; set; }
        public string otherdesignation { get; set; }
        public string city { get; set; }
        public string stateorprovince { get; set; }
        public string ziporpostalcode { get; set; }
        public string country { get; set; }
        public string addresstype { get; set; }
        public string othergeographicdesignation { get; set; }
        public string countrycode { get; set; }
        public string censustract { get; set; }
        public string addressrepresentationcode { get; set; }
        public string addressvalidityrange { get; set; }
        public string CountryCode1 { get; set; }
        public string PhoneNumber_Home { get; set; }
        public string PhoneNumber_Business { get; set; }
        public string PrimaryLanguage { get; set; }
        public string MaritalStaus { get; set; }
        public string Religion { get; set; }
        public string PatientAccountNumber { get; set; }
        public string PatientAccount_id { get; set; }
        public string checkdigit { get; set; }
        public string codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string SSNNumber_Patient { get; set; }
        public string DriverLicenseNumber_Patient { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string IssuingState_province_country { get; set; }
        public string MotherIdentifier { get; set; }
        public string EthnicGroup { get; set; }
        public string BirthPlace { get; set; }
        public string MultipleBirthIndicator { get; set; }
        public string BirthOther { get; set; }
        public string Citizenship { get; set; }
        public string VeteransMilitaryStatus { get; set; }
        public string NationalityCode { get; set; }
        public string PatientDeathDateTime { get; set; }
        public string PatientDeathIndicator { get; set; }
        public string PV1SetID { get; set; }
        public string PatientClass { get; set; }
        public string AssignedPatientLocation { get; set; }
        public string PointOfCare { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
        public string Facility { get; set; }
        public string LocationStatus { get; set; }
        public string PersonLocationType { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string LocationType { get; set; }
        public string AdmissionType { get; set; }
        public string PreadmitNumber { get; set; }
        public string PriorPatientLocation { get; set; }
        public string AttendingDoctor { get; set; }
        public string ReferringDoctor { get; set; }
        public string IDNumber { get; set; }
        public string Family_LastName { get; set; }
        public string GivenName { get; set; }
        public string ConsultingDoctor { get; set; }
        public string HospitalService { get; set; }
        public string TemporaryLocation { get; set; }
        public string PreadmitTestIndicator { get; set; }
        public string Re_AdmissionIndicator { get; set; }
        public string AdmitSource { get; set; }
        public string AmbulatoryStatus { get; set; }
        public string VIPIndicator { get; set; }
        public string AdmittingDoctor { get; set; }
        public string PatientType { get; set; }
        public string VisitNumber { get; set; }
        public string FinancialClass { get; set; }
        public string ChargePriceIndicator { get; set; }
        public string CourtesyCode { get; set; }
        public string CreditRating { get; set; }
        public string ContractCode { get; set; }
        public string ContractEffectiveDate { get; set; }
        public string ContractAmount { get; set; }
        public string ContractPeriod { get; set; }
        public string InterestCode { get; set; }
        public string TransfertoBadDebtCode { get; set; }
        public string TransfertoBadDebtDate { get; set; }
        public string BadDebtAgencyCode { get; set; }
        public string BadDebtTransferAmount { get; set; }
        public string BadDebtRecoveryAmount { get; set; }
        public string DeleteAccountIndicator { get; set; }
        public string DeleteAccountDate { get; set; }
        public string DischargeDisposition { get; set; }
        public string DischargedToLocation { get; set; }
        public string DietType { get; set; }
        public string ServicingFacility { get; set; }
        public string BedStatus { get; set; }
        public string AccountStatus { get; set; }
        public string PendingLocation { get; set; }
        public string PriorTemporaryLocation { get; set; }
        public string AdmitDatetime { get; set; }
        public string DischargeDatetime { get; set; }
        public string CurrentPatientBalance { get; set; }
        public string TotalCharges { get; set; }
        public string TotalAdjustments { get; set; }
        public string TotalPayments { get; set; }
        public string AlternateVisitID { get; set; }
        public string VisitIndicator { get; set; }
        public string OtherHealthcareProvider { get; set; }
    }


    public class HL7ORMModel
    {
        public string SendingApplication { get; set; }
        public string SendingFacility { get; set; }
        public string ReceivingApplication { get; set; }
        public string ReceivingFacility { get; set; }
        public string DateTimeofMessage { get; set; }
        public string Security { get; set; }
        public string MessageType { get; set; }
        public string messagetype { get; set; }
        public string triggerevent { get; set; }
        public string MessageControlID { get; set; }
        public string ProcessingID { get; set; }
        public string VersionID { get; set; }
        public string SequenceNumber { get; set; }
        public string ContinuationPointer { get; set; }
        public string AcceptAcknowledgmentType { get; set; }
        public string ApplicationAcknowledgmentType { get; set; }
        public string CountryCode { get; set; }
        public string CharacterSet { get; set; }
        public string PrincipalLanguageofMessage { get; set; }
        public string AlternateCharacterSetHandlingScheme { get; set; }
        public string PIDSetID { get; set; }
        public string PatientID_External { get; set; }
        public string External_ID { get; set; }
        public string External_checkdigit { get; set; }
        public string External_codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string External_assigningauthority { get; set; }
        public string External_identifiertypecode { get; set; }
        public string External_assigningfacility { get; set; }
        public string PatientID_Internal { get; set; }
        public string Internal_ID { get; set; }
        public string Internal_checkdigit { get; set; }
        public string Internal_codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string Internal_assigningauthority { get; set; }
        public string Internal_identifiertypecode { get; set; }
        public string Internal_assigningfacility { get; set; }
        public string PatientID_Alternate { get; set; }
        public string Alternate_ID { get; set; }
        public string Alternate_checkdigit { get; set; }
        public string Alternate_codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string Alternate_assigningauthority { get; set; }
        public string Alternate_identifiertypecode { get; set; }
        public string Alternate_assigningfacility { get; set; }
        public string PatientName { get; set; }
        public string familyname { get; set; }
        public string givenname { get; set; }
        public string middleinitial { get; set; }
        public string MotherMaidenName { get; set; }
        public string DateofBirth { get; set; }
        public string Sex { get; set; }
        public string PatientAlias { get; set; }
        public string Race { get; set; }
        public string PatientAddress { get; set; }
        public string streetaddress { get; set; }
        public string otherdesignation { get; set; }
        public string city { get; set; }
        public string stateorprovince { get; set; }
        public string ziporpostalcode { get; set; }
        public string country { get; set; }
        public string addresstype { get; set; }
        public string othergeographicdesignation { get; set; }
        public string countrycode { get; set; }
        public string censustract { get; set; }
        public string addressrepresentationcode { get; set; }
        public string addressvalidityrange { get; set; }
        public string CountryCode2 { get; set; }
        public string PhoneNumber_Home { get; set; }
        public string PhoneNumber_Business { get; set; }
        public string PrimaryLanguage { get; set; }
        public string MaritalStaus { get; set; }
        public string Religion { get; set; }
        public string PatientAccountNumber { get; set; }
        public string PatientAccount_id { get; set; }
        public string checkdigit { get; set; }
        public string codeidentifyingthecheckdigitschemeemployed { get; set; }
        public string SSNNumber_Patient { get; set; }
        public string DriverLicenseNumber_Patient { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string IssuingState_province_country { get; set; }
        public string MotherIdentifier { get; set; }
        public string EthnicGroup { get; set; }
        public string BirthPlace { get; set; }
        public string MultipleBirthIndicator { get; set; }
        public string BirthOther { get; set; }
        public string Citizenship { get; set; }
        public string VeteransMilitaryStatus { get; set; }
        public string NationalityCode { get; set; }
        public string PatientDeathDateTime { get; set; }
        public string PatientDeathIndicator { get; set; }
        public string PV1SetID { get; set; }
        public string PatientClass { get; set; }
        public string AssignedPatientLocation { get; set; }
        public string PointOfCare { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
        public string Facility { get; set; }
        public string LocationStatus { get; set; }
        public string PersonLocationType { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string LocationType { get; set; }
        public string AdmissionType { get; set; }
        public string PreadmitNumber { get; set; }
        public string PriorPatientLocation { get; set; }
        public string AttendingDoctor { get; set; }
        public string ReferringDoctor { get; set; }
        public string IDNumber { get; set; }
        public string Family_LastName { get; set; }
        public string GivenName { get; set; }
        public string ConsultingDoctor { get; set; }
        public string HospitalService { get; set; }
        public string TemporaryLocation { get; set; }
        public string PreadmitTestIndicator { get; set; }
        public string Re_AdmissionIndicator { get; set; }
        public string AdmitSource { get; set; }
        public string AmbulatoryStatus { get; set; }
        public string VIPIndicator { get; set; }
        public string AdmittingDoctor { get; set; }
        public string PatientType { get; set; }
        public string VisitNumber { get; set; }
        public string FinancialClass { get; set; }
        public string ChargePriceIndicator { get; set; }
        public string CourtesyCode { get; set; }
        public string CreditRating { get; set; }
        public string ContractCode { get; set; }
        public string ContractEffectiveDate { get; set; }
        public string ContractAmount { get; set; }
        public string ContractPeriod { get; set; }
        public string InterestCode { get; set; }
        public string TransfertoBadDebtCode { get; set; }
        public string TransfertoBadDebtDate { get; set; }
        public string BadDebtAgencyCode { get; set; }
        public string BadDebtTransferAmount { get; set; }
        public string BadDebtRecoveryAmount { get; set; }
        public string DeleteAccountIndicator { get; set; }
        public string DeleteAccountDate { get; set; }
        public string DischargeDisposition { get; set; }
        public string DischargedToLocation { get; set; }
        public string DietType { get; set; }
        public string ServicingFacility { get; set; }
        public string BedStatus { get; set; }
        public string AccountStatus { get; set; }
        public string PendingLocation { get; set; }
        public string PriorTemporaryLocation { get; set; }
        public string AdmitDatetime { get; set; }
        public string DischargeDatetime { get; set; }
        public string CurrentPatientBalance { get; set; }
        public string TotalCharges { get; set; }
        public string TotalAdjustments { get; set; }
        public string TotalPayments { get; set; }
        public string AlternateVisitID { get; set; }
        public string VisitIndicator { get; set; }
        public string OtherHealthcareProvider { get; set; }
        public string OrderControl { get; set; }
        public string PlacerOrderNumber { get; set; }
        public string FillerOrderNumber { get; set; }
        public string PlacerGroupNumber { get; set; }
        public string OrderStatus { get; set; }
        public string ResponseFlag { get; set; }
        public string Quantity_Timing { get; set; }
        public string Quantity { get; set; }
        public string Interval { get; set; }
        public string Duration { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string Priority { get; set; }
        public string Parent { get; set; }
        public string DateTimeOfTransaction { get; set; }
        public string EnteredBy { get; set; }
        public string IDNumber2 { get; set; }
        public string FamilyLastName { get; set; }
        public string GivenName2 { get; set; }
        public string VerifiedBy { get; set; }
        public string OrderingProvider { get; set; }
        public string ID_Number { get; set; }
        public string Family_LastName2 { get; set; }
        public string Given_Name { get; set; }
        public string EntererLocation { get; set; }
        public string PointOfCare2 { get; set; }
        public string Room2 { get; set; }
        public string Bed2 { get; set; }
        public string Facility2 { get; set; }
        public string LocationStatus2 { get; set; }
        public string PersonLocationType2 { get; set; }
        public string Building2 { get; set; }
        public string Floor2 { get; set; }
        public string LocationDescription { get; set; }
        public string CallBackPhoneNumber { get; set; }
        public string PhoneNumber999 { get; set; }
        public string TelecommunicationUseCode { get; set; }
        public string OrderEffectiveDatetime { get; set; }
        public string OrderControlCodeReason { get; set; }
        public string EnteringOrganization { get; set; }
        public string Identifier { get; set; }
        public string Text { get; set; }
        public string EnteringDevice { get; set; }
        public string ActionBy { get; set; }
        public string AdvancedBeneficiaryNoticeCode { get; set; }
        public string OrderingFacilityName { get; set; }
        public string OrderingFacilityAddress { get; set; }
        public string OrderingFacilityPhoneNumber { get; set; }
        public string OrderingProviderAddress { get; set; }
        public string StreetAddress { get; set; }
        public string OtherDesignation { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string ZipOrPostalCode { get; set; }
        public string Country { get; set; }
        public string AddressType { get; set; }
        public string OtherGeographicDesignation { get; set; }
        public string SetID { get; set; }
        public string PlacerOrderNumber2 { get; set; }
        public string FillerOrderNumber2 { get; set; }
        public string UniversalServiceID { get; set; }
        public string Identifier2 { get; set; }
        public string Text2 { get; set; }
        public string NameOfCodingSystem { get; set; }
        public string AlternateIdentifier { get; set; }
        public string AlternateText { get; set; }
        public string Priority_OBR { get; set; }
        public string RequestedDateTime { get; set; }
        public string ObservationDateTime { get; set; }
        public string ObservationEndDateTime { get; set; }
        public string CollectionVolume { get; set; }
        public string CollectorIdentifier { get; set; }
        public string SpecimenActionCode { get; set; }
        public string DangerCode { get; set; }
        public string RelevantClinicalInfo { get; set; }
        public string SpecimenReceivedDateTime { get; set; }
        public string SpecimenSource { get; set; }
        public string OrderingProvider2 { get; set; }
        public string IDNumber3 { get; set; }
        public string FamilyLastName2 { get; set; }
        public string GivenName3 { get; set; }
        public string OrderCallBackPhoneNumber { get; set; }
        public string PhoneNumber9992 { get; set; }
        public string TelecommunicationUseCode2 { get; set; }
        public string PlacerField1 { get; set; }
        public string PlacerField2 { get; set; }
        public string FillerField1 { get; set; }
        public string FillerField2 { get; set; }
        public string ResultsRpt_StatusChangeDateTime { get; set; }
        public string TimeOfAnEvent { get; set; }
        public string DegreeOfPrecision { get; set; }
        public string ChargeToPractice { get; set; }
        public string DollarAmount { get; set; }
        public string ChargeCode { get; set; }
        public string DiagnosticServSectID { get; set; }
        public string ResultStatus { get; set; }
        public string ParentResult { get; set; }
        public string Quantity_Timing2 { get; set; }
        public string Quantity2 { get; set; }
        public string Interval2 { get; set; }
        public string Duration2 { get; set; }
        public string StartDateTime2 { get; set; }
        public string EndDateTime2 { get; set; }
        public string Priority2 { get; set; }
        public string ResultCopiesTo { get; set; }
        public string Parent2 { get; set; }
        public string TransportationMode { get; set; }
        public string ReasonForStudy { get; set; }
        public string Identifier1 { get; set; }
        public string Text1 { get; set; }
        public string PrincipalResultInterpreter { get; set; }
        public string Name { get; set; }
        public string StartDateTime1 { get; set; }
        public string EndDateTime1 { get; set; }
        public string PointOfCare3 { get; set; }
        public string Room3 { get; set; }
        public string Bed3 { get; set; }
        public string Facility3 { get; set; }
        public string LocationStatus3 { get; set; }
        public string PersonLocationType3 { get; set; }
        public string Building3 { get; set; }
        public string Floor3 { get; set; }
        public string AssistantResultInterpreter { get; set; }
        public string Name2 { get; set; }
        public string StartDateTime4 { get; set; }
        public string EndDateTime4 { get; set; }
        public string PointOfCare4 { get; set; }
        public string Room4 { get; set; }
        public string Bed4 { get; set; }
        public string Facility4 { get; set; }
        public string LocationStatus4 { get; set; }
        public string PersonLocationType4 { get; set; }
        public string Building4 { get; set; }
        public string Floor4 { get; set; }
        public string Technician { get; set; }
        public string Name3 { get; set; }
        public string StartDateTime3 { get; set; }
        public string EndDateTime3 { get; set; }
        public string PointOfCare5 { get; set; }
        public string Room5 { get; set; }
        public string Bed5 { get; set; }
        public string Facility5 { get; set; }
        public string LocationStatus5 { get; set; }
        public string PersonLocationType5 { get; set; }
        public string Building5 { get; set; }
        public string Floor5 { get; set; }
        public string Transcriptionist { get; set; }
        public string Name4 { get; set; }
        public string StartDateTime6 { get; set; }
        public string EndDateTime6 { get; set; }
        public string PointOfCare6 { get; set; }
        public string Room6 { get; set; }
        public string Bed6 { get; set; }
        public string Facility6 { get; set; }
        public string LocationStatus6 { get; set; }
        public string PersonLocationType6 { get; set; }
        public string Building6 { get; set; }
        public string Floor6 { get; set; }
        public string ScheduledDateTime { get; set; }
        public string TimeOfAnEvent1 { get; set; }
        public string DegreeOfPrecision1 { get; set; }
        public string NumberOfSampleContainers { get; set; }
        public string TransportLogisticsOfCollectedSample { get; set; }
        public string Identifier3 { get; set; }
        public string Text3 { get; set; }
        public string NameOfCodingSystem2 { get; set; }
        public string AlternateIdentifier2 { get; set; }
        public string AlternateText2 { get; set; }
        public string NameOfAlternateCodingSystem { get; set; }
        public string CollectorComment { get; set; }
        public string TransportArrangementResponsibility { get; set; }
        public string TransportArranged { get; set; }
        public string EscortRequired { get; set; }
        public string PlannedPatientTransportComment { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureCodeModifier { get; set; }
    }

    public class ORCModel
    {
        public string OrderControl { get; set; }
        public string PlacerOrderNumber { get; set; }
        public string FillerOrderNumber { get; set; }
        public string PlacerGroupNumber { get; set; }
        public string OrderStatus { get; set; }
        public string ResponseFlag { get; set; }
        public string Quantity_Timing { get; set; }
        public int Quantity { get; set; }
        public int Interval { get; set; }
        public string Duration { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Priority { get; set; }
        public string Parent { get; set; }
        public DateTime DateTimeOfTransaction { get; set; }
        public string EnteredBy { get; set; }
        public int IDNumber { get; set; }
        public string FamilyLastName { get; set; }
        public string GivenName { get; set; }
        public string VerifiedBy { get; set; }
        public string OrderingProvider { get; set; }
        public int ID_Number { get; set; }
        public string Family_LastName { get; set; }
        public string Given_Name { get; set; }
        public string EntererLocation { get; set; }
        public string PointOfCare { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
        public string Facility { get; set; }
        public string LocationStatus { get; set; }
        public string PersonLocationType { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string LocationDescription { get; set; }
        public string CallBackPhoneNumber { get; set; }
        public string PhoneNumber999 { get; set; }
        public string TelecommunicationUseCode { get; set; }
        public DateTime OrderEffectiveDatetime { get; set; }
        public string OrderControlCodeReason { get; set; }
        public string EnteringOrganization { get; set; }
        public string Identifier { get; set; }
        public string Text { get; set; }
        public string EnteringDevice { get; set; }
        public string ActionBy { get; set; }
        public string AdvancedBeneficiaryNoticeCode { get; set; }
        public string OrderingFacilityName { get; set; }
        public string OrderingFacilityAddress { get; set; }
        public int OrderingFacilityPhoneNumber { get; set; }
        public string OrderingProviderAddress { get; set; }
        public string StreetAddress { get; set; }
        public string OtherDesignation { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string ZipOrPostalCode { get; set; }
        public string Country { get; set; }
        public string AddressType { get; set; }
        public string OtherGeographicDesignation { get; set; }

    }

    public class OBRModel
    {
        public int SetID { get; set; }
        public string PlacerOrderNumber { get; set; }
        public string FillerOrderNumber { get; set; }
        public string UniversalServiceID { get; set; }
        public string Identifier { get; set; }
        public string Text { get; set; }
        public string NameOfCodingSystem { get; set; }
        public string AlternateIdentifier { get; set; }
        public string AlternateText { get; set; }
        public DateTime RequestedDateTime { get; set; }
        public string Priority_OBR { get; set; }

        public DateTime ObservationDateTime { get; set; }
        public DateTime ObservationEndDateTime { get; set; }
        public string CollectionVolume { get; set; }
        public string CollectorIdentifier { get; set; }

        public string SpecimenActionCode { get; set; }
        public string DangerCode { get; set; }
        public string RelevantClinicalInfo { get; set; }
        public DateTime SpecimenReceivedDateTime { get; set; }
        public string SpecimenSource { get; set; }




        public string OrderingProvider { get; set; }
        public int IDNumber { get; set; }
        public string FamilyLastName { get; set; }
        public string GivenName { get; set; }
        public string OrderCallBackPhoneNumber { get; set; }

        public string PhoneNumber999 { get; set; }
        public string TelecommunicationUseCode { get; set; }


        public string PlacerField1 { get; set; }
        public string PlacerField2 { get; set; }
        public string FillerField1 { get; set; }


        public string FillerField2 { get; set; }
        public DateTime ResultsRpt_StatusChangeDateTime { get; set; }
        public DateTime TimeOfAnEvent { get; set; }
        public string DegreeOfPrecision { get; set; }

        public string ChargeToPractice { get; set; }
        public string DollarAmount { get; set; }
        public string ChargeCode { get; set; }
        public string DiagnosticServSectID { get; set; }
        public string ResultStatus { get; set; }
        public string ParentResult { get; set; }
        public string OBX3_Observation { get; set; }
        public string OBX4SubIDOfParentResult { get; set; }
        public string PartOfOBX5_ObservationResultFromParent { get; set; }
        public string Quantity_Timing { get; set; }

        public int Quantity { get; set; }
        public int Interval { get; set; }
        public string Duration { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Priority { get; set; }

        public string ResultCopiesTo { get; set; }
        public string Parent { get; set; }
        public string TransportationMode { get; set; }
        public string ReasonForStudy { get; set; }
        public string Identifier1 { get; set; }
        public string Text1 { get; set; }
        public string PrincipalResultInterpreter { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime1 { get; set; }
        public DateTime EndDateTime1 { get; set; }
        public string PointOfCare { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
        public string Facility { get; set; }
        public string LocationStatus { get; set; }
        public string PersonLocationType { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }

        public string AssistantResultInterpreter { get; set; }
        public string Name2 { get; set; }
        public DateTime StartDateTime2 { get; set; }
        public DateTime EndDateTime2 { get; set; }
        public string PointOfCare2 { get; set; }
        public string Room2 { get; set; }
        public string Bed2 { get; set; }
        public string Facility2 { get; set; }
        public string LocationStatus2 { get; set; }
        public string PersonLocationType2 { get; set; }
        public string Building2 { get; set; }
        public string Floor2 { get; set; }


        public string Technician { get; set; }
        public string Name3 { get; set; }
        public DateTime StartDateTime3 { get; set; }
        public DateTime EndDateTime3 { get; set; }
        public string PointOfCare3 { get; set; }
        public string Room3 { get; set; }
        public string Bed3 { get; set; }
        public string Facility3 { get; set; }
        public string LocationStatus3 { get; set; }
        public string PersonLocationType3 { get; set; }
        public string Building3 { get; set; }
        public string Floor3 { get; set; }

        public string Transcriptionist { get; set; }
        public string Name4 { get; set; }
        public DateTime StartDateTime4 { get; set; }
        public DateTime EndDateTime4 { get; set; }
        public string PointOfCare4 { get; set; }
        public string Room4 { get; set; }
        public string Bed4 { get; set; }
        public string Facility4 { get; set; }
        public string LocationStatus4 { get; set; }
        public string PersonLocationType4 { get; set; }
        public string Building4 { get; set; }
        public string Floor4 { get; set; }

        public DateTime ScheduledDateTime { get; set; }
        public DateTime TimeOfAnEvent1 { get; set; }
        public string DegreeOfPrecision1 { get; set; }

        public string NumberOfSampleContainers { get; set; }

        public string TransportLogisticsOfCollectedSample { get; set; }
        public string Identifier2 { get; set; }
        public string Text2 { get; set; }
        public string NameOfCodingSystem2 { get; set; }
        public string AlternateIdentifier2 { get; set; }
        public string AlternateText2 { get; set; }
        public string NameOfAlternateCodingSystem { get; set; }
        public string CollectorComment { get; set; }
        public string TransportArrangementResponsibility { get; set; }
        public string TransportArranged { get; set; }
        public string EscortRequired { get; set; }
        public string PlannedPatientTransportComment { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureCodeModifier { get; set; }

    }




}




