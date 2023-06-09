﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpIpServerService
{
    public class ModelHelper
    {
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

        public string EventReasonCode { get; set; }
        public string VersionID { get; set; }

        public string EventFacility { get; set; }
        public string OperatorID { get; set; }
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

        public string ProtectionIndicatorEffectiveDate { get; set; }
        public string PlaceofWorkship { get; set; }
        public string AdvanceDirectiveCode { get; set; }
        public string ImmunizationRegistryStatus { get; set; }
        public string ImmunizationRegistryStatusEffectiveDate { get; set; }
        public string PublicityCodeEffectiveDate { get; set; }
        public string MilitaryBranch { get; set; }
        public string MilitaryRank_Grade { get; set; }
        public string MilitaryStatus { get; set; }

        public string GTSetID { get; set; }
        public string GuarantorNumber { get; set; }
        public string GTfamilyname { get; set; }

        public string GTgivenname { get; set; }
        public string GTmiddleinitial { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorSpouseName { get; set; }

        public string GTstreetaddress { get; set; }
        public string GTotherdesignation { get; set; }
        public string GTcity { get; set; }
        public string GTstateorprovince { get; set; }
        public string GTziporpostalcode { get; set; }
        public string GTcountry { get; set; }
        public string GuarantorAddress { get; set; }

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

        public string GT1streetaddress { get; set; }
        public string GT1otherdesignation { get; set; }
        public string GT1city { get; set; }
        public string GT1stateorprovince { get; set; }
        public string GT1ziporpostalcode { get; set; }
        public string GT1country { get; set; }
        public string GuarantorEmployerAddress { get; set; }

        public string GuarantorEmployPhoneNumber { get; set; }
        public string GuarantorEmployeeIDNumber { get; set; }
        public string GuarantorEmployementStatus { get; set; }
        public string GuarantorOrganization { get; set; }

        public string NKSetID { get; set; }

        public string NKfamilyname { get; set; }

        public string NKgivenname { get; set; }

        public string Name { get; set; }

        public string NKRelationship { get; set; }

        public string NKstreetaddress { get; set; }
        public string NKotherdesignation { get; set; }
        public string NKcity { get; set; }
        public string NKstateorprovince { get; set; }
        public string NKziporpostalcode { get; set; }

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
        public string NKLivingDependency { get; set; }
        public string NKAmbulatoryStatus { get; set; }
        public string NKCitizenship { get; set; }
        public string NKPrimaryLanguage { get; set; }
        public string NKLivingArrangement { get; set; }
        public string NKPublicityCode { get; set; }
        public string NKProtectionIndicator { get; set; }
        public string NKStudentIndicator { get; set; }
        public string NKReligion { get; set; }
        public string MothersMaidenName { get; set; }
        public string Nationality { get; set; }
        public string NKEthnicGroup { get; set; }
        public string ContactReason { get; set; }
        public string ContactPersonName { get; set; }
        public int ContactPersonTelephoneNumber { get; set; }
        public string ContactPersonAddress { get; set; }
        public string NextofKin_AssociatedPartyIdentifiers { get; set; }
        public string JobStatus { get; set; }
        public string NKRace { get; set; }
        public string NKHandicap { get; set; }
        public int ContactPersonSocialSecutityNumber { get; set; }



        public int DGSetID { get; set; }
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
        public string OutlierDays { get; set; }
        public string OutlierCost { get; set; }
        public string GrouperVersionAndType { get; set; }
        public string DiagnosisPriority { get; set; }
        public string DiagnosingClinician { get; set; }
        public string DiagnosisClassification { get; set; }
        public string ConfidentialIndicator { get; set; }
        public DateTime AttestationDateTime = DateTime.Now;
        public string DiagnosisIdentifier { get; set; }
        public string DiagnosisActionCode { get; set; }



        public int IN1SetID { get; set; }
        public string InsurancePlanID { get; set; }
        public int InsuranceCompanyID { get; set; }
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


        public string familyName { get; set; }
        public string givenName { get; set; }
        public string middleInitialorName { get; set; }
        public string NameOfInsured { get; set; }


        public string InsuredRelationshipToPatient { get; set; }
        public DateTime InsuredDateOfBirth { get; set; }

        //InsuredAddress
        public string IN1streetaddress { get; set; }
        public string IN1otherdesignation { get; set; }
        public string IN1city { get; set; }
        public string IN1stateorprovince { get; set; }
        public string IN1ziporpostalcode { get; set; }
        public string IN1country { get; set; }

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
}
