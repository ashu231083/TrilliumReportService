using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperHL7
{
    public class ORMMessageModel
    {

    }


    public class ORM_MSHModel
    {
        /* MSH-3 SendingApplication, MSH-4 Sending Facility, MSH-5 Receiving Application, MSH-6 Receiving Facility, MSH-7 Date\Time of Message = 20230125124217
        MSH-8 Security, MSH-9 Message Type = ORM ^ 001, MSH-10 Message Control ID, MSH-11 Processing ID, MSH-12 Version ID
        MSH-13 Sequence Number, MSH-14 Continuation Pointer, MSH-15 Accept Acknowledgment Type, MSH-16 Application Acknowledgment Type
        MSH-17 Country Code, MSH-18 Character Set, MSH-19 Principal Language of Message, MSH-20 Alternate Character Set Handling Scheme*/

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

    public class ORM_PIDModel
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



    public class ORM_PV1Model
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
        public string LocationDescription { get; set; }
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


    public class ORM_ORCModel
    {
        /* ORC-1 Order Control = XO,ORC-2 Placer Order Number,ORC-3 Filler Order Number,ORC-4 Placer Group Number,ORC-5 Order Status,ORC-6 Response Flag,
        ORC-7 Quantity/Timing,ORC-7.1 quantity,ORC-7.2 interval,ORC-7.3 duration,ORC-7.4 start date/time,ORC-7.5 end date/time,ORC-7.6 priority,
        ORC-8 Parent,ORC-9 Date/time of Transaction,ORC-10 Entered by,ORC-10.1 ID number(ST)ORC-10.2 family+last name,ORC-10.3 given name,
        ORC-11 Verified by,ORC-12 Ordering Provider,ORC-12.1 ID number(ST),ORC-12.2 family+last name,ORC-12.3 given name,
        ORC-13 Enterer's Location,ORC-13.1 point of care,ORC-13.2 room,ORC-13.3 bed,ORC-13.4 facility(HD),ORC-13.5 location status,ORC-13.6 person location type,
        ORC-13.7 building,ORC-13.8 floor,ORC-13.9 Location description
        ORC-14 Call Back Phone Number,ORC-14.1 [(999)]999-9999[X9999] [C any text], ORC-14.2 telecommunication use code,
        ORC-15 Order Effective Date/time,ORC-16 Order Control Code Reason,ORC-17 Entering Organization,ORC-17.1 identifier,ORC-17.2 text,
        ORC-18 Entering Device,ORC-19 Action by,ORC-20 Advanced Beneficiary Notice Code,ORC-21 Ordering Facility Name,ORC-22 Ordering Facility Address,
        ORC-23 Ordering Facility Phone Number,ORC-24 Ordering Provider Address,ORC-24.1 street address,ORC-24.2 other designation,ORC-24.3 city,
        ORC-24.4 state or province,ORC-24.5 zip or postal code,ORC-24.6 country,ORC-24.7 address type,ORC-24.8 other geographic designation */


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

    public class ORM_OBRModel
    {
        /*OBR-1 Set ID,OBR-2 Place Order Number,OBR-3 Filler Order Number,
         * OBR-4 Universal Service ID,OBR-4.1 identifier,OBR-4.2 test,OBR-4.3 name of coding system,OBR-4.4 alternate identifier,OBR-4.5 alternate text,
        OBR-5 Priority-OBR,OBR-6 Requested Date/time,OBR-7 Observation Date/time,OBR-8 Observation End Date/time,OBR-9 Collection Volume,OBR-10 Collector Identifier,
   OBR-11 Specimen Action Code,OBR-12 Danger Code,OBR-13 Relevant Clinical Info,OBR-14 Specimen Received Date/time,OBR-15 Specimen Source,
   OBR-16 Ordering Provider,OBR-16.1 ID number,OBR-16.2 family+last name,OBR-16.3 given name,OBR-17 Order Call Back Phone Number,OBR-17.1 [(999)]999-9999[X9999][C any text],OBR-17.2 telecommunication use code,
   OBR-18 Placer Field1,OBR-19 Placer Field2,OBR-20 Filler Field1+,OBR-21 Filler Field2+,
   OBR-22 Results Rpt/Status Change Date/time,OBR-22.1 time of an event,OBR-22.2 degree of precision,
   OBR-23 Charge to Practice+,OBR-23.1  dollar amount,OBR-23.2 charge code,OBR-24 Diagnostic Serv Sect ID,OBR-25 Result Status+,
   OBR-26 Parent Result+,OBR-26.1 OBX-3 observation identifier of parent result,OBR-26.2 OBX-4 sub-ID of parent result,OBR-26.3 part of OBX-5 observation result from parent,
   OBR-27 Quantity/Timing,OBR-27.1 quantity,OBR-27.2 interval,OBR-27.3 duration,OBR-27.4 start Date/time,OBR-27.5 end Date/time,OBR-27.6 priority,
   OBR-28 Result copies to,OBR-29 Parent,OBR-30 Transportation Mode,OBR-31 Reason for Study,OBR-31.1 identifier,OBR-31.2 text,
   OBR-32 Principal Result Interpreter+,OBR-32.1 name,OBR-32.2 start Date/time,OBR-32.3 end Date/time,OBR-32.4 point of care(IS),OBR-32.5 room,OBR-32.6 bed,
   OBR-32.7 facility(HD),OBR-32.8 location status,OBR-32.9 person location type,OBR-32.10 building,OBR-32.11 floor,
   OBR-33 Assistant Result Interpreter+,OBR-33.1 name,OBR-33.2 start Date/time,OBR-33.3 end Date/time,OBR-33.4 point of care(IS),OBR-33.5 room,
   OBR-33.6 bed,OBR-33.7 facility(HD),OBR-33.8 location status,OBR-33.9 person location type,OBR-33.10 building,OBR-33.11 floor,
   OBR-34 Technician+,OBR-34.1 name,OBR-34.2 start Date/time,OBR-34.3 end Date/time,OBR-34.4 point of care(IS),OBR-34.5 room,
   OBR-34.6 bed,OBR-34.7 facility(HD),OBR-34.8 location status,OBR-34.9 person location type,OBR-34.10 building,OBR-34.11 floor,
   OBR-35 Transcriptionist+,OBR-35.1 name,OBR-35.2 start Date/time,OBR-35.3 end Date/time,OBR-35.4 point of care(IS),OBR-35.5 room,
   OBR-35.6 bed,OBR-35.7 facility(HD),OBR-35.8 location status,OBR-35.9 person location type,OBR-35.10 building,OBR-35.11 floor,
   OBR-36 Scheduled Date/time+,OBR-36.1 time of an event,OBR-36.2 degree of precision,OBR-37 Number of Sample Containers,OBR-38 Transport Logistics of Collected Sample,
   OBR-38.1 Identifier2 ,OBR-38.2  Text2 ,OBR-38.3  NameOfCodingSystem2 ,OBR-38.4  AlternateIdentifier2,OBR-38.5  AlternateText2 ,OBR-38.6  NameOfAlternateCodingSystem ,
   OBR-39 Collector's Comment+,OBR-40 Transport Arrangement Responsibility,OBR-41 Transport Arranged,OBR-42 Escort Required,OBR-43 Planned Patient Transport Comment,                                                            
   OBR-44 Procedure Code,OBR-45 Procedure Code Modifier*/



        public int SetID { get; set; }
        public string PlacerOrderNumber { get; set; }
        public string FillerOrderNumber { get; set; }
        public string UniversalServiceID { get; set; }
        public string Identifier { get; set; }
        public string Text { get; set; }
        public string NameOfCodingSystem { get; set; }
        public string AlternateIdentifier { get; set; }
        public string AlternateText { get; set; }
        public string Priority_OBR { get; set; }
        public DateTime RequestedDateTime { get; set; }

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


        //public string OBX3_Observation { get; set; }
        //public string OBX4SubIDOfParentResult { get; set; }
        //public string PartOfOBX5_ObservationResultFromParent { get; set; }
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
