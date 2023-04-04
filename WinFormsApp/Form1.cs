using DannyBoyNg;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void cnvrtTojsonbtn_Click_1(object sender, EventArgs e)
        {
            string input = "MSH|^~&| MESA_ADT|XYZ_ADMITTING|1FW|ZYX_HOSPITAL|||ADT^A04|103102|P|2.4||||||||";
            var data = Hl7v2ToJson.Convert(input);
        }

        private void sndmsgBtn_Click(object sender, EventArgs e)
        {
            TcpClient ourTcpClient = null;
            NetworkStream networkStream = null;

            try
            {
                //initiate a TCP client connection to local loopback address at port 1080
                ourTcpClient = new TcpClient();

                ourTcpClient.Connect("192.168.1.13", 9999);

                Console.WriteLine("Connected to server....");

                //get the IO stream on this connection to write to
                networkStream = ourTcpClient.GetStream();

                //use UTF-8 and either 8-bit encoding due to MLLP-related recommendations
                var messageToTransmit = "Hello from Client";
                var byteBuffer = Encoding.UTF8.GetBytes(messageToTransmit);

                //send a message through this connection using the IO stream
                networkStream.Write(byteBuffer, 0, byteBuffer.Length);

                Console.WriteLine("Data was sent data to server successfully....");

                var bytesReceivedFromServer = networkStream.Read(byteBuffer, 0, byteBuffer.Length);

                // Our server for this example has been designed to echo back the message
                // keep reading from this stream until the message is echoed back
                while (bytesReceivedFromServer < byteBuffer.Length)
                {
                    bytesReceivedFromServer = networkStream.Read(byteBuffer, 0, byteBuffer.Length);
                    if (bytesReceivedFromServer == 0)
                    {
                        //exit the reading loop since there is no more data
                        break;
                    }
                }
                var receivedMessage = Encoding.UTF8.GetString(byteBuffer);

                Console.WriteLine("Received message from server: {0}", receivedMessage);

                Console.WriteLine("Press any key to exit program...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                //display any exceptions that occur to console
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //close the IO strem and the TCP connection
                networkStream?.Close();
                ourTcpClient?.Close();
            }

        }

        private void generateMsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[40];

            string MSH_message = "MSH|^~\\&";
            /*MSH - 3 Sending Application,MSH - 4 Sending Facility,MSH - 5 Receiving Application,MSH - 6 Receiving Facility
            MSH - 7 Date\Time of Message = 20230125124217,MSH - 8 Security,MSH - 9 Message Type = ADT ^ A04,MSH - 10 Message Control ID
            MSH - 11 Processing ID,MSH - 12 Version ID,MSH - 13 Sequence Number,MSH - 14 Continuation Pointer,MSH - 15 Accept Acknowledgment Type
            MSH - 16 Application Acknowledgment Type,MSH - 17 Country Code,MSH - 18 Character Set,MSH - 19 Principal Language of Message
            MSH - 20 Alternate Character Set Handling Scheme,MSH - 21 Message Profile Identifier */

            input[3] = "DEV1";
            input[4] = "SRH_1_Sending";
            input[5] = "DEV2";
            input[6] = "SRH_1_Receiving";
            input[7] = "270120231313";
            input[8] = "No";
            input[9] = "ADT ^ A04";
            input[10] = "01";
            input[11] = "1813";
            input[12] = "V1.1";
            input[13] = "7891";
            input[14] = "";
            input[15] = "ADT_A04";
            input[16] = "OK";
            input[17] = "91";
            input[18] = "700";
            input[19] = "HL7";
            input[20] = "SRH_1";
            input[21] = "Unkown";
            MSH_message = MSH_message + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|"
                + input[7] + "|" + input[8] + "|" + input[9] + "|" + input[10] + "|" + input[11] + "|"
                + input[12] + "|" + input[13] + "|" + input[14] + "|" + input[15] + "|" + input[16] + "|"
                + input[17] + "|" + input[18] + "|" + input[19] + "|" + input[20] + "|" + input[21];


            txtbox.Text = MSH_message;
        }

        private void generateSFTMsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[40];
            string SFT_message = "SFT|";
            /*SFT-1 Software Vendor Organization,SFT-2 Software Certified Version or Release Number,SFT-3 Software Product Name
            SFT-4 Software Binary ID,SFT-5 Software Product Information,SFT-6 Software Install Date */

            input[1] = "DEV1";
            input[2] = "SRH_1_Sending";
            input[3] = "DEV2";
            input[4] = "SRH_1_Receiving";
            input[5] = "270120231313";
            input[6] = "No";

            SFT_message = SFT_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|";


            txtbox.Text = SFT_message;

        }

        private void generateEVNMsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[40];

            string EVN_message = "EVN|";
            /*EVN-1 Event Type Code = A04,EVN-2 Recorded Date\Time = 20230125132644,EVN-3 Date\Time Planned Event = 20230125132644
            EVN-4 Event Reason Code = 1,EVN-5 Operator ID,EVN-6 Event Occured = 20230125132644,EVN-7 Event Facility */

            input[1] = "A04";
            input[2] = "20230125132644";
            input[3] = "20230128163436";
            input[4] = "1";
            input[5] = "";
            input[6] = "20230128132633";
            input[7] = "ABIYD";

            EVN_message = EVN_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|" + input[7];


            txtbox.Text = EVN_message;

        }

        private void generatePIDMsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[40];

            string PID_message = "PID|";
            /*PID-1 Set ID - PID = 1234,PID-2 Patient ID,PID-3 Patient Identifier List,PID-4 Alternate Patient ID - PID 
            PID-5 Patient Name,PID-6 Mother's Maiden Name,PID-7 Date\Time of Birth = 20230125145701,PID-8 Administrative Sex (A - Ambiguous, F - Female, M - Male, N - Not applicable, O - Other, U - Unknown) = M
            PID-9 Patient Alias,PID-10 Race,PID-11 Patient Address,PID-12 County Code,PID-13 Phone Number - Home,PID-14 Phone Number - Business
            PID-15 Primary Language,PID-16 Merital Status,PID-17 Religion,PID-18 Patient Account Number,PID-19 SSN Number - Patient
            PID-20 Driver's License Number - Patient,PID-21 Mother's Identifier,PID-22 Ethnic Group (H - Hispanic or Latino, N - Not Hispanic or Latino, U - Unknown) = U
            PID-23 Birth Place,PID-24 Multiple Birth Indicator (N - No, Y - Yes) = N,PID-25 Birth Order,PID-26 Citizenship
            PID-27 Veterans Military Status,PID-28 Nationality,PID-29 Patient Death Date\Time = 20230125151938,PID-30 Patient Death Indicator (N - No, Y - Yes) = N
            PID-31 Identity Unknown Indicator (N - No, Y - Yes) = N,PID-32 Identity Reliability Code (AL - Patient/Person Name is an Alias, UA - Unknown/Default Address, UD - Unknown/Default Date of Birth, US - Unknown/Default Social Security Number) = AL
            PID-33 Last Update Date\Time = 20230125151938,PID-34 Last Update Facility,PID-35 Species Code,PID-36 Breed Code
            PID-37 Strain,PID-38 Production Class Code (BR - Breeding/genetic stock,DA - Dairy,DU - Dual Purpose... ) = DA
            PID-39 Tribal Citizenship */

            input[1] = "1234";
            input[2] = "1";
            input[3] = "";
            input[4] = "";
            input[5] = "Johnson";
            input[6] = "Villy";
            input[7] = "20230128145701";
            input[8] = "U";
            input[9] = "Je";
            input[10] = "1002-5";

            input[11] = "Canada";
            input[12] = "73";
            input[13] = "1452496258";
            input[14] = "1452496258";
            input[15] = "English";
            input[16] = "B";
            input[17] = "ABC";
            input[18] = "145288";
            input[19] = "54215";
            input[20] = "1450444822482";

            input[21] = "1";
            input[22] = "U";
            input[23] = "Canada";
            input[24] = "N";
            input[25] = "1";
            input[26] = "1";
            input[27] = "";
            input[28] = "";
            input[29] = "20230130151938";
            input[30] = "N";

            input[31] = "N";
            input[32] = "AL";
            input[33] = "20230126174057";
            input[34] = "AC1";
            input[35] = "CODE";
            input[36] = "01";
            input[37] = "";
            input[38] = "DU";
            input[39] = "";


            PID_message = PID_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|" + input[7]
                + "|" + input[8] + "|" + input[9] + "|" + input[10] + "|" + input[11] + "|" + input[12] + "|" + input[13]
                + "|" + input[14] + "|" + input[15] + "|" + input[16] + "|" + input[17] + "|" + input[18] + "|" + input[19]
                + "|" + input[20] + "|" + input[21] + "|" + input[22] + "|" + input[23] + "|" + input[24] + "|" + input[25]
                + "|" + input[26] + "|" + input[27] + "|" + input[28] + "|" + input[29] + "|" + input[30] + "|" + input[31]
                + "|" + input[32] + "|" + input[33] + "|" + input[34] + "|" + input[35] + "|" + input[36] + "|" + input[37]
                + "|" + input[38] + "|" + input[39];


            txtbox.Text = PID_message;
        }

        private void generatePD1MsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[40];

            string PID_message = "PD1|";
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

            input[1] = "U";
            input[2] = "U";
            input[3] = "FAC1";
            input[4] = "16358";
            input[5] = "P";
            input[6] = "";
            input[7] = "Y";
            input[8] = "Y";
            input[9] = "N";
            input[10] = "0";

            input[11] = "U";
            input[12] = "N";
            input[13] = "20230129154633";
            input[14] = "Home";
            input[15] = "N";
            input[16] = "U";
            input[17] = "20230128183611";
            input[18] = "20230128183628";
            input[19] = "USA";
            input[20] = "E1... E9";
            input[21] = "RET";


            PID_message = PID_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|" + input[7]
                + "|" + input[8] + "|" + input[9] + "|" + input[10] + "|" + input[11] + "|" + input[12] + "|" + input[13]
                + "|" + input[14] + "|" + input[15] + "|" + input[16] + "|" + input[17] + "|" + input[18] + "|" + input[19]
                + "|" + input[20] + "|" + input[21];


            txtbox.Text = PID_message;
        }

        private void generateROLMsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[40];

            string PID_message = "ROL|";
            /*ROL-1 Role Instance ID,ROL-2 Action Code(AD - ADD,CO - CORRECT,DE - DELETE,LI - LINK,UC - UNCHANGED *,UN - UNLINK,UP - UPDATE) = AD
            ROL-3 Role-ROL,ROL-4 Role Person,ROL-5 Role Begin Date\Time,ROL-6 Role End Date\Time,ROL-7 Role Duration,ROL-8 Role Action Reason
            ROL-9 Provider Type,ROL-10 Organization Unit Type,ROL-11 Office/Home Address/Birthplace,ROL-12 Phone */

            input[1] = "142";
            input[2] = "UP";
            input[3] = "AD";
            input[4] = "1";
            input[5] = "20230127191004";
            input[6] = "20230128191005";
            input[7] = "2";
            input[8] = "03";
            input[9] = "4";
            input[10] = "1";

            input[11] = "Canada";
            input[12] = "485688247";


            PID_message = PID_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|" + input[7]
                + "|" + input[8] + "|" + input[9] + "|" + input[10] + "|" + input[11] + "|" + input[12];


            txtbox.Text = PID_message;

        }

        private void generateNK1MsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[40];

            string NK1_message = "NK1|";
            /*NK1-1 Set ID - NK1 = 1234,NK1-2 Name,NK1-3 Relationship,NK1-4 Address,NK1-5 Phone Number,NK1-6 Business Phone Number
            NK1-7 Contact Role,NK1-8 Start Date = 20230125161507,NK1-9 End Date = 20230125161507,NK1-10 Next of Kin/Associated Parties Job Title
            NK1-11 Next of Kin/Associated Parties Job Code/Class,NK1-12 Next of Kin/Associated Parties Employee Number
            NK1-13 Organization Name - NK1,NK1-14 Marital Status,NK1-15 Administrative Sex,NK1-16 Date/Time of Birth,NK1-17 Living Dependency
            NK1-18 Ambulatory Status,NK1-19 Citizenship,NK1-20 Primary Language,NK1-21 Living Arrangement,NK1-22 Publicity Code
            NK1-23 Protection Indicator,NK1-24 Student Indicator,NK1-25 Religion,NK1-26 Mother's Maiden Name,NK1-27 Nationality
            NK1-28 Ethnic Group,NK1-29 Contact Reason,NK1-30 Contact Person's Name,NK1-31 Contact Person's Telephone Number
            NK1-32 Contact Person's Address,NK1-33 Next of Kin\Associated Party's Identifiers,NK1-34 Job Status,NK1-35 Race,NK1-36 Handicap,
            NK1-37 Contact Reason Social Secutity Number,NK1-38 Next of Kin Birth Place,NK1-39 VIP Indicator */

            input[1] = "142";
            input[2] = "UP";
            input[3] = "AD";
            input[4] = "1";
            input[5] = "20230127191004";
            input[6] = "20230128191005";
            input[7] = "2";
            input[8] = "03";
            input[9] = "4";
            input[10] = "1";

            input[11] = "Canada";
            input[12] = "485688247";
            input[13] = "142";
            input[14] = "UP";
            input[15] = "AD";
            input[16] = "1";
            input[17] = "20230127191004";
            input[18] = "20230128191005";
            input[19] = "2";
            input[20] = "03";
            input[21] = "4";
            input[22] = "1";
            input[23] = "142";
            input[24] = "UP";
            input[25] = "AD";
            input[26] = "1";
            input[27] = "20230127191004";
            input[28] = "20230128191005";
            input[29] = "2";
            input[30] = "03";
            input[31] = "4";
            input[32] = "1";

            input[33] = "1";
            input[34] = "20230127191004";
            input[35] = "20230128191005";
            input[36] = "2";
            input[37] = "03";
            input[38] = "4";
            input[39] = "1";


            NK1_message = NK1_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|" + input[7]
                + "|" + input[8] + "|" + input[9] + "|" + input[10] + "|" + input[11] + "|" + input[12];


            txtbox.Text = NK1_message;
        }

        private void generatePV1MsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[55];

            string PV1_message = "PV1|";
            /*PV1-1 Set ID - PV1 = 1234,PV1-2 Patient Class,PV1-3 Assigned Patient Location,PV1-4 Admission Type,PV1-5 Preadmit Number 
            PV1-6 Prior Patient Location,PV1-7 Attending Doctor,PV1-8 Referring Doctor,PV1-9 Consulting Doctor,PV1-10 Hospital Service,,PV1-11 Temporary Location,
            PV1-12 Preadmit Test Indicator,PV1-13 Re-admission Indicator,PV1-14 Admit Source,PV1-15 Ambulatory Status,PV1-16 VIP Indicator
            PV1-17 Admitting Doctor,PV1-18 Patient Type,PV1-19 Visit Number,PV1-20 Financial Class,PV1-21 Charge Price Indicator,PV1-22 Courtesy Code
            PV1-23 Credit Rating,PV1-24 Contract Code,PV1-25 Contract Effective Date,PV1-26 Contract Amount,PV1-27 Contract Period,PV1-28 Interest Code,PV1-29 Transfer to Bad Debt Code,
            PV1-30 Transfer to Bad Debt Date,PV1-31 Bad Debt Agency Code,PV1-32 Bad Debt Transfer Amount,PV1-33 Bad Debt Recovery Amount,PV1-34 Delete Account Indicator,
            PV1-35 Delete Account Date,PV1-36 Discharge Disposition,PV1-37 Discharged to Location,PV1-38 Diet Type,PV1-39 Servicing Facility
            PV1-40 Bed Status,PV1-41 Account Status,PV1-42 Pending Location,PV1-43 Prior Temporary Location,PV1-44 Admit Date/time,PV1-45 Discharge Date/time
            PV1-46 Current Patient Balance,PV1-47 Total Charges,PV1-48 Total Adjustments,PV1-49 Total Payments,PV1-50 Alternate Visit ID
            PV1-51 visit Indicator,PV1-52 Other Healthcare Provider */

            input[1] = "22";
            input[2] = "B";
            input[3] = "Canada";
            input[4] = "A";
            input[5] = "123544";
            input[6] = "Canada";
            input[7] = "Dr. Sam";
            input[8] = "Dr. Joy";
            input[9] = "Dr. Joy";
            input[10] = "MED";

            input[11] = "Canada";
            input[12] = "";
            input[13] = "R";
            input[14] = "Admit Source";
            input[15] = "A0";
            input[16] = "VIP Indicator";
            input[17] = "Dr. Joy";
            input[18] = "Patient Type";
            input[19] = "2";
            input[20] = "Financial Class";
            input[21] = "Charge Price Indicator";
            input[22] = "Courtesy Code";
            input[23] = "6";
            input[24] = "Contract Code";
            input[25] = "20230131114257";
            input[26] = "Contract Amount";
            input[27] = "Contract Period";
            input[28] = "Interest Code";
            input[29] = "2";
            input[30] = "20230201114512";
            input[31] = "04";
            input[32] = "15542";

            input[33] = "20000";
            input[34] = "1";
            input[35] = "20230201114604";
            input[36] = "03";
            input[37] = "Canada";
            input[38] = "A";
            input[39] = "FAC1";

            input[40] = "C";
            input[41] = "1";
            input[42] = "Canada";
            input[43] = "Canada";
            input[44] = "20230131115107";
            input[45] = "20230202115126";
            input[46] = "12650";
            input[47] = "126500";
            input[48] = "25535";
            input[49] = "5";

            input[50] = "AM";
            input[51] = "A";
            input[52] = "SAMI";


            PV1_message = PV1_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|" + input[7]
                + "|" + input[8] + "|" + input[9] + "|" + input[10] + "|" + input[11] + "|" + input[12]

                + "|" + input[13] + "|" + input[14] + "|" + input[15] + "|" + input[16] + "|" + input[17] + "|" + input[18]
                + "|" + input[19] + "|" + input[20] + "|" + input[21] + "|" + input[22] + "|" + input[23]

                + "|" + input[24] + "|" + input[25] + "|" + input[26] + "|" + input[27] + "|" + input[28] + "|" + input[29]
                + "|" + input[30] + "|" + input[31] + "|" + input[32] + "|" + input[33] + "|" + input[34]

                + "|" + input[35] + "|" + input[36] + "|" + input[37] + "|" + input[38] + "|" + input[39] + "|" + input[40]
                + "|" + input[41] + "|" + input[42] + "|" + input[43] + "|" + input[44] + "|" + input[45]

                + "|" + input[46] + "|" + input[47] + "|" + input[48] + "|" + input[49] + "|" + input[50] + "|" + input[51]
                + "|" + input[52];


            txtbox.Text = PV1_message;

        }

        private void generatePV2MsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[55];

            string PV2_message = "PV2|";
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

            input[1] = "Canada";
            input[2] = "B";
            input[3] = "Emergency";
            input[4] = "Critical Condition";
            input[5] = "";
            input[6] = "Canada";
            input[7] = "HO";
            input[8] = "20230131123739";
            input[9] = "20230203123749";
            input[10] = "3";

            input[11] = "3";
            input[12] = "Ok";
            input[13] = "";
            input[14] = "20230126123828";
            input[15] = "N";
            input[16] = "D";
            input[17] = "20230201123858";
            input[18] = "ES";
            input[19] = "N";
            input[20] = "2";
            input[21] = "F";
            input[22] = "N";
            input[23] = "OCD";
            input[24] = "AI";
            input[25] = "2";
            input[26] = "20230127124307";
            input[27] = "Health Ok";
            input[28] = "20230128124333";
            input[29] = "20230129124410";
            input[30] = "15672";
            input[31] = "04";
            input[32] = "15542";

            input[33] = "20230129124535";
            input[34] = "N";
            input[35] = "N";
            input[36] = "N";
            input[37] = "N";
            input[38] = "C";
            input[39] = "C";

            input[40] = "AC";
            input[41] = "A";
            input[42] = "C";
            input[43] = "F";
            input[44] = "F";
            input[45] = "N";
            input[46] = "20230130125646";
            input[47] = "20230131125655";
            input[48] = "20230128125704";
            input[49] = "O";




            PV2_message = PV2_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|" + input[7]
                + "|" + input[8] + "|" + input[9] + "|" + input[10] + "|" + input[11] + "|" + input[12]

                + "|" + input[13] + "|" + input[14] + "|" + input[15] + "|" + input[16] + "|" + input[17] + "|" + input[18]
                + "|" + input[19] + "|" + input[20] + "|" + input[21] + "|" + input[22] + "|" + input[23]

                + "|" + input[24] + "|" + input[25] + "|" + input[26] + "|" + input[27] + "|" + input[28] + "|" + input[29]
                + "|" + input[30] + "|" + input[31] + "|" + input[32] + "|" + input[33] + "|" + input[34]

                + "|" + input[35] + "|" + input[36] + "|" + input[37] + "|" + input[38] + "|" + input[39] + "|" + input[40]
                + "|" + input[41] + "|" + input[42] + "|" + input[43] + "|" + input[44] + "|" + input[45]

                + "|" + input[46] + "|" + input[47] + "|" + input[48] + "|" + input[49];


            txtbox.Text = PV2_message;

        }

        private void generateROL2MsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[12];

            string ROL2_message = "ROL|";
            /*ROL[2]-1 Role Instance ID,ROL[2]-2 Action Code,ROL[2]-3 Role-ROL,ROL[2]-4 Role Person,ROL[2]-5 Role Begin Date/Time
            ROL[2]-6 Role End Date/Time,ROL[2]-7 Role Duration,ROL[2]-8 Role Action Reason,ROL[2]-9 Provider Type,ROL[2]-10 Organization Unit Type
            ROL[2]-11 Office/Home Address/Birthplace,ROL[2]-12 Phone */

            input[1] = "14242";
            input[2] = "AD";
            input[3] = "PI";
            input[4] = "Patient";
            input[5] = "20230129131000";
            input[6] = "20230131131040";
            input[7] = "2";
            input[8] = "Admited Patient";
            input[9] = "";
            input[10] = "1";

            input[11] = "Canada";
            input[12] = "2581588522";




            ROL2_message = ROL2_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|" + input[7]
                + "|" + input[8] + "|" + input[9] + "|" + input[10] + "|" + input[11] + "|" + input[12];


            txtbox.Text = ROL2_message;

        }

        private void generateDB1MsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[9];

            string DB1_message = "DB1|";
            /*DB1-1 Set ID - DB1,DB1-2 Disabled Person Code,DB1-3 Disabled Person Identifier,DB1-4 Disabled Indicator
DB1-5 Disability Start Date,DB1-6 Disability End Date,DB1-7 Disability Return to Work Date,DB1-8 Disability Unable to Work Date */

            input[1] = "14242";
            input[2] = "AP";
            input[3] = "SAM";
            input[4] = "N";
            input[5] = "20230128131807";
            input[6] = "20230129131814";
            input[7] = "20230131131830";
            input[8] = "20230130131838";



            DB1_message = DB1_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|" + input[7] + "|" + input[8];


            txtbox.Text = DB1_message;

        }

        private void generateOBXMsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[23];

            string OBX_message = "DB1|";
            /*OBX-1 Set ID - OBX,OBX-2 Value Type,OBX-3 Observation Identifier,OBX-4 Observation Sub-ID,OBX-5 Observation Value
            OBX-6 Units,OBX-7 References Range,OBX-8 Abnormal Flags,OBX-9 Probability,OBX-10 Nature of Abnormal Test,OBX-11 Observation Result Status
            OBX-12 Effective Date of Reference Range Values,OBX-13 User Defined Access Checks,OBX-14 Date/Time of the Observation,OBX-15 Producer's Reference
            OBX-16 Responsible Observer,OBX-17 Observation Method,OBX-18 Equipment Instance Identifier,OBX-19 Date/Time of the Analysis,OBX-20 Performing Organization Name
            OBX-21 Performing Organization Address,OBX-22 Performing Organization Medical Director */

            input[1] = "14242";
            input[2] = "AD";
            input[3] = "1";
            input[4] = "1.1";
            input[5] = "";
            input[6] = "Unit1";
            input[7] = "";
            input[8] = "A";
            input[9] = "";
            input[10] = "B";

            input[11] = "C";
            input[12] = "20230128144805";
            input[13] = "OK";
            input[14] = "20230129144838";
            input[15] = "";
            input[16] = "Dr. Sam";
            input[17] = "Observation1";
            input[18] = "";
            input[19] = "20230130145133";
            input[20] = "NKHOSPITAL";

            input[21] = "Canada";
            input[22] = "Dr. Maxwell";


            OBX_message = OBX_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|" + input[7] + "|" + input[8]
                + "|" + input[9] + "|" + input[10] + "|" + input[11] + "|" + input[12] + "|" + input[13] + "|" + input[14] + "|" + input[15]
                + "|" + input[16] + "|" + input[17] + "|" + input[18] + "|" + input[19] + "|" + input[20] + "|" + input[21] + "|" + input[22];


            txtbox.Text = OBX_message;


        }

        private void generateAL1MsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[7];

            string AL1_message = "AL1|";
            /*AL1-1 Set ID - AL1,AL1-2 Allergen Type Code,AL1-3 Allergen Code/Mnemonic/Description,AL1-4 Allergy Severity Code,AL1-5 Allergy Reaction Code
            AL1-6 Identification Date */

            input[1] = "59";
            input[2] = "AA";
            input[3] = "xadv";
            input[4] = "MI";
            input[5] = "03";
            input[6] = "20230130145932";

            AL1_message = AL1_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6];


            txtbox.Text = AL1_message;
        }

        private void generateDG1MsgBtn_Click(object sender, EventArgs e)
        {
            string[] input = new string[22];

            string DG1_message = "DG1|";
            /*DG1-1 Set ID - DG1,DG1-2 Diagnosis Coding Method,DG1-3 Diagnosis Code - DG1,DG1-4 Diagnosis Description,DG1-5 Diagnosis Date/Time
            DG1-6 Diagnosis Type,DG1-7 Major Diagnostic Category,DG1-8 Diagnostic Related Group,DG1-9 DRG Approval Indicator,DG1-10 DRG Grouper Review Code
            DG1-11 Outlier Type,DG1-12 Outlier Days,DG1-13 Outlier Cost,DG1-14 Grouper Version And Type,DG1-15 Diagnosis Priority
            DG1-16 Diagnosing Clinician,DG1-17 Diagnosis Classification,DG1-18 Confidential Indicator,DG1-19 Attestation Date/Time
            DG1-20 Diagnosis Identifier,DG1-21 Diagnosis Action Code */

            input[1] = "125";
            input[2] = "D01";
            input[3] = "1184";
            input[4] = "";
            input[5] = "20230128151754";
            input[6] = "A";
            input[7] = "";
            input[8] = "A";
            input[9] = "N";
            input[10] = "D07";

            input[11] = "C";
            input[12] = "2";
            input[13] = "15822";
            input[14] = "G4";
            input[15] = "0";
            input[16] = "";
            input[17] = "C";
            input[18] = "N";
            input[19] = "20230129152042";
            input[20] = "Dr. Sam";

            input[21] = "U";



            DG1_message = DG1_message + input[1] + "|" + input[2] + "|" + input[3] + "|" + input[4] + "|" + input[5] + "|" + input[6] + "|" + input[7] + "|" + input[8]
                + "|" + input[9] + "|" + input[10] + "|" + input[11] + "|" + input[12] + "|" + input[13] + "|" + input[14] + "|" + input[15]
                + "|" + input[16] + "|" + input[17] + "|" + input[18] + "|" + input[19] + "|" + input[20] + "|" + input[21];


            txtbox.Text = DG1_message;


        }
    }
}