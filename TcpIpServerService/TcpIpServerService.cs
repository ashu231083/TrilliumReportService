using HL7.Dotnetcore;
using HL7.Dotnetcore.Test;
using HttpManager;
//using HL7.Dotnetcore.HL7Test;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TcpIpServerService.Helper;
using TrilliumReportService.Helper;

namespace TcpIpServerService
{
    public partial class TcpIpServerService : ServiceBase
    {
        Logger Logger = LogManager.GetCurrentClassLogger();
        System.Timers.Timer timer = new System.Timers.Timer();
        private System.Threading.Timer IntervalTimer;
        //private bool isAvilApp = false;
        TcpListener server = new TcpListener(IPAddress.Any, 9999);
        TcpListener server2 = new TcpListener(IPAddress.Any, 9997);
        private TcpClient client;
        private TcpClient client2;
        public StreamReader STR;
        public StreamWriter STW;
        public StreamReader STR2;
        public StreamWriter STW2;
        public string recieve;
        public string recieve2;
        public String TextToSend;
        public String TextToSend2;
        public string MSGreceived = "";
        public string MSGreceived2 = "";
        private static readonly byte[] Localhost = { 127, 0, 0, 1 };
        private const int Port = 6161;


        public TcpIpServerService()
        {
            try
            {
                InitializeComponent();
                Logger.Info("TrilliumReportService InitializeComponent done.");
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at TrilliumReportService InitializeComponent. Message: " + ex.Message);
            }
        }

        protected override async void OnStart(string[] args)
        {
            try
            {
                RunBatfile();
                Logger.Info("TrilliumReportService is started with interval: " + ConfigurationManager.AppSettings["report_interval"]);
                TimeSpan tsInterval = new TimeSpan(0, Convert.ToInt32(ConfigurationManager.AppSettings["report_interval"]), 0);
                IntervalTimer = new System.Threading.Timer(new System.Threading.TimerCallback(OnElapsedTimeCall), null, tsInterval, tsInterval);



                TcpListener listener = new TcpListener(IPAddress.Any, 9999);
                Logger.Info("OnstartCallAsync starting IP: " + IPAddress.Any + ", and port: 9999");
                listener.Start();
                Logger.Info("After listener.start..");
                Listener2Async();
                Logger.Info("step1");
                string folderPath = @"C:\HL7";
                string folderPath2 = @"C:\HL7\ACK";
                string folderPath3 = @"C:\HL7\Connexion\";
                Logger.Info("step2");
                Directory.CreateDirectory(folderPath);
                Directory.CreateDirectory(folderPath2);
                Directory.CreateDirectory(folderPath3);
                Logger.Info("step3");


                client = await listener.AcceptTcpClientAsync();
                Logger.Info("step4");
                STR = new StreamReader(client.GetStream());
                Logger.Info("step5");
                STW = new StreamWriter(client.GetStream());
                Logger.Info("step6");
                STW.AutoFlush = true;
                Logger.Info("step7");
                backgroundWorker1.RunWorkerAsync();
                Logger.Info("step8");
                backgroundWorker2.WorkerSupportsCancellation = true;
                Logger.Info("step9");

            }
            catch (Exception ex)
            {
                Logger.Error("Exception at OnStart. Message: " + ex.Message);
            }
        }
        public void RunBatfile()
        {
            try
            {
                Logger.Info("At RunBatfile...step1");
                Process runBatchProcess = new System.Diagnostics.Process();
                runBatchProcess.StartInfo.FileName = @"C:\Program Files (x86)\SmartRxHub\TrilliumReport\encryptStart.bat";
                runBatchProcess.StartInfo.RedirectStandardError = false;
                runBatchProcess.StartInfo.CreateNoWindow = true;
                runBatchProcess.StartInfo.Verb = "runas";
                runBatchProcess.StartInfo.RedirectStandardOutput = false;
                runBatchProcess.StartInfo.UseShellExecute = false;
                runBatchProcess.Start();
                runBatchProcess.WaitForExit();
                Logger.Info("At RunBatfile...step2");

            }
            catch (Exception ex)
            {
                Logger.Error("Exception at RunBatfile. Message: " + ex.Message);
            }
        }
        public async Task Listener2Async()
        {
            try
            {
                Logger.Info("At Listener2...");
                int Port = int.Parse(ConfigurationManager.AppSettings["mirth_listening_port"].ToString());
                TcpListener listener2 = new TcpListener(IPAddress.Any, Port);
                Logger.Info("Listener2 starting IP: " + IPAddress.Any + ", and port: " + Port);
                listener2.Start();
                Logger.Info("client2 step1");
                client2 = await listener2.AcceptTcpClientAsync();
                Logger.Info("client2 step2");
                STR2 = new StreamReader(client2.GetStream());
                Logger.Info("client2 step3");
                STW2 = new StreamWriter(client2.GetStream());
                Logger.Info("client2 step4");
                STW2.AutoFlush = true;
                Logger.Info("client2 step5");
                backgroundWorker3.RunWorkerAsync();
                Logger.Info("step6");
                backgroundWorker4.WorkerSupportsCancellation = true;
                Logger.Info("step7");



            }
            catch (Exception ex)
            {
                Logger.Error("Exception at Listener2. Message: " + ex.Message);
            }
        }


        protected override void OnStop()
        {
            try
            {
                Logger.Info("TrilliumReportService is Stopped.");
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at OnStop. Message: " + ex.Message);
            }
        }

        private async Task OnstartCallAsync(string opt)
        {
            try
            {
                try
                {
                    int listeningPort = Convert.ToInt32(ConfigurationManager.AppSettings["listeningPort"]);
                    //Logger.Info("TcpIpServerService is starting to listen at port: " + listeningPort);
                    Logger.Info("TrilliumReportService is starting to listen at port: " + listeningPort);

                    IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
                    string IP = "";
                    foreach (IPAddress address in localIP)
                    {
                        if (address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            IP = address.ToString();
                            Logger.Info("OnstartCallAsync starting IP: " + IP + ", and port: " + listeningPort);
                        }
                    }

                    TcpListener listener = new TcpListener(IPAddress.Any, listeningPort);
                    listener.Start();
                    //var receivedByteBuffer = new byte[200];

                    //Logger.Info("TcpIpServerService is started listening at IP: " + IP + ", and port: " + listeningPort);
                    Logger.Info("TrilliumReportService is started listening at IP: " + IP + ", and port: " + listeningPort);
                    // receiveMSG();
                }
                catch (Exception ex)
                {
                    Logger.Error("Exception at OnstartCall. Message: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at OnstartCall. Message: " + ex.Message);
            }
        }

        private void receiveMSG()
        {
            try
            {
                Logger.Info("at receiveMSG.");
                var Directory = @"C:\QUEUE\";
                string LocalIP;

                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    Logger.Info("IP: 192.168.1.13 & PORT: 9999");
                    socket.Connect(IPAddress.Any, 9999);

                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;

                    LocalIP = endPoint.Address.ToString();
                }
                Logger.Info("WRITING TO " + Directory);
                Logger.Info("SYSTEM READY");
                int Count = 0;

                var Listener = new TcpListener(IPAddress.Any, 9999);
                Listener.Start();
                var Client = Listener.AcceptTcpClient();
                byte[] Bytes = new byte[4097];
                string Recived = "";
                do
                {
                    NetworkStream Stream = Client.GetStream();
                    byte[] Buffer = new byte[Client.ReceiveBufferSize + 1];
                    StringBuilder Message = new StringBuilder();
                    int Read = 0;
                    do
                    {

                        Read = Stream.Read(Buffer, 0, Buffer.Length);

                        Message.AppendFormat("{0}", Encoding.ASCII.GetString(Buffer, 0, Read));
                        Logger.Info("Message: " + Message.ToString());
                    }

                    while (Stream.DataAvailable);

                    Recived = Message.ToString();

                    if (Recived.Length > 10)

                    {

                        char[] Pipe = new char[] { '|' };

                        string[] Fields = Recived.Split(Pipe);

                        string MSH10 = Fields[9];

                        string MSH9 = Fields[8];

                        string ACKMSH = null;

                        for (int i = 0; i < 16; i++)

                        {

                            ACKMSH = ACKMSH + Fields[i] + "|";

                        }

                        ACKMSH = ACKMSH.Replace(MSH9, "ACK");

                        string ACK = ACKMSH + (Char)13 + "MSA|AA|" + MSH10 + "|";

                        ACK = (Char)11 + ACK + (Char)28 + (Char)13;

                        byte[] ACK_Bytes = System.Text.Encoding.ASCII.GetBytes(ACK);

                        Stream.Write(ACK_Bytes, 0, ACK_Bytes.Length);

                        ACK_Bytes = new byte[257];

                        Count++;

                        Logger.Info("");

                        Logger.Info("MESSAGE: " + Count + " CONTROL ID: " + MSH10);

                        Logger.Info("");

                        Logger.Info("BYTES");

                        Logger.Info("");

                        Logger.Info(Read);

                        Logger.Info("");

                        string HL7Clean = Regex.Replace(Recived, @"[^\u0020-\u007E]", string.Empty);

                        Logger.Info(HL7Clean);

                        Logger.Info("");

                        Logger.Info("ACK " + Count + " CONTROL ID: " + MSH10);

                        string ACKClean = Regex.Replace(ACK, @"[^\u0020-\u007E]", string.Empty);

                        Logger.Info("");

                        Logger.Info(ACKClean);

                        Logger.Info("");

                        if (!string.IsNullOrEmpty(Directory))

                        {

                            try

                            {

                                System.IO.File.WriteAllText(Directory + MSH10 + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt", Recived.ToString());

                            }

                            catch (Exception ex)

                            {

                                Logger.Error("Exception..:  " + ex.Message.ToString());

                            }

                        }

                    }

                    //else

                    //{

                    //    Console.WriteLine("HOST DISCONECTED");

                    //    Listener.Stop();

                    //    Main(args);

                    //}

                }
                while (true);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at receiveMSG. Message: " + ex.Message.ToString());
            }
        }

        private void OnElapsedTimeCall(object state)
        {
            try
            {
                Logger.Info("TrilliumReportService at OnElapsedTimeCall.");
                HL7_JSON_Helper hL7_ = new HL7_JSON_Helper();
                string metadata = hL7_.HL7ToJsonParser();
                Logger.Info("metadata: " + metadata);

                if (metadata != "")
                {
                    try
                    {
                        HttpClient httpManager = new HttpClient();
                        string url = ConfigurationManager.AppSettings["appurl"] + "/encounter/newreport";
                        Logger.Info("url: " + url);
                        NameValueCollection paramlist1 = new NameValueCollection();
                        paramlist1.Add("report_metadata", metadata);
                        var response = httpManager.PostReportRemoteUrl(url, null, paramlist1);

                        Logger.Info("response: " + response);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Exception at httpcall. Message: " + ex.Message);
                    }
                }
                Logger.Info("For TrilliumReportService at OnElapsedTimeCall.");
                //ConnectMirth();

                //Publisher Pub = new Publisher(Localhost, Port);
                //Logger.Info("At OnElapsedTimeCall STEP1. Localhost: " + Localhost + ", Port:" + Port);
                //Pub.Send();

                //Logger.Info("At OnElapsedTimeCall STEP2.");
                //Pub.SendACK();
                //Logger.Info("At OnElapsedTimeCall STEP2.1 before sleep for 10000");
                //Thread.Sleep(10000);
                //Logger.Info("At OnElapsedTimeCall STEP2.2 After sleep for 10000");
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at OnElapsedTimeCall. Message: " + ex.Message);
            }
        }


        private void server_start()
        {
            TcpListener ourTcpListener;
            try
            {
                // Create a TCPListener to accept client connections through port 9999
                ourTcpListener = new TcpListener(IPAddress.Any, 9999);
                //start listening
                ourTcpListener.Start();
                Logger.Info("Started TCP Listener...");
            }
            catch (Exception ex)
            {
                //if there was an error starting the listener then print the error and quit
                Logger.Error("Exception at server_start. Message:" + ex.Message);
                return;
            }
            var receivedByteBuffer = new byte[200];
        }
        private void accept_connection()
        {
            try
            {
                server.BeginAcceptTcpClient(handle_connection, server);  //this is called asynchronously and will run in a different thread

            }
            catch (Exception ex)
            {
                Logger.Error("Exception at accept_connection. Message: " + ex.Message);
            }
        }

        private void accept_connection2()
        {
            try
            {
                server2.BeginAcceptTcpClient(handle_connection2, server2);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at accept_connection2. Message: " + ex.Message);
            }
        }

        private void handle_connection(IAsyncResult result)  //the parameter is a delegate, used to communicate between threads
        {
            try
            {
                accept_connection();  //once again, checking for any other incoming connections
                TcpClient client = server.EndAcceptTcpClient(result);  //creates the TcpClient

                NetworkStream ns = client.GetStream();

                /* here you can add the code to send/receive data */
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at handle_connection. Message: " + ex.Message);
            }
        }

        private void handle_connection2(IAsyncResult result)  //the parameter is a delegate, used to communicate between threads
        {
            try
            {
                accept_connection2();  //once again, checking for any other incoming connections
                TcpClient client = server.EndAcceptTcpClient(result);  //creates the TcpClient

                NetworkStream ns = client.GetStream();
                Logger.Info("at handle_connection2 Stream: " + ns.ToString());
                /* here you can add the code to send/receive data */
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at handle_connection2. Message: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker2.RunWorkerAsync();
                //backgroundWorker2.WorkerSupportsCancellation = true;
                Logger.Info("At timer1_Tick");
                // ConnectMirth();
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at timer1_Tick. Message: " + ex.Message);
            }
        }
        public void ConnectMirth()
        {
            try
            {
                Logger.Info("At ConnectMirth");
                IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
                string IP = "";
                foreach (IPAddress address in localIP)
                {
                    if (address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        IP = address.ToString();
                    }
                }

                Logger.Info("Found IP :" + IP);
                client = new TcpClient();
                IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(IP), 6161);

                try
                {
                    client.Connect(IpEnd);

                    if (client.Connected)
                    {
                        //txtLogs.AppendText("\n" + "Connected to server" + "\n");
                        //txtLogs.AppendText(Environment.NewLine);
                        Logger.Info("At ConnectMirth Client. Connected to server");
                        STW = new StreamWriter(client.GetStream());
                        STR = new StreamReader(client.GetStream());
                        STW.AutoFlush = true;
                        backgroundWorker1.RunWorkerAsync();
                        backgroundWorker2.WorkerSupportsCancellation = true;
                        Logger.Info("At ConnectMirth Client. Client Connected");

                        string MSHmsg = "<VT> MSH|^~\\&|Velox||||20230209042040||ADT^A08|2302090420402040|P|2.3.1<FS><CR>";
                        Logger.Info("At ConnectMirth Client. MSGmsg: " + MSHmsg);
                        STW.WriteLine(MSHmsg);
                        Logger.Info("At ConnectMirth Client. After STW");
                    }
                    else
                    {
                        Logger.Info("At ConnectMirth Client did not connect");
                    }



                    if (client.Connected)
                    {


                    }
                    backgroundWorker2.CancelAsync();
                }
                catch (Exception ex)
                {
                    Logger.Error("Exception at ConnectMirth STEP1. Message: " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Exception at ConnectMirth STEP2. Message: " + ex.Message);
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Logger.Info("At backgroundWorker2_DoWork ");
                if (client.Connected)
                {
                    // Listener2();
                    Logger.Trace("At backgroundWorker2_DoWork,before sending msg to Server MSGreceived: " + MSGreceived);
                    string msg = "Response from server.";
                    STW.WriteLine(msg);
                    Logger.Info("At backgroundWorker2_DoWork, Server msg: " + msg);
                }
                backgroundWorker2.CancelAsync();
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at backgroundWorker2_DoWork. Message: " + ex.Message);
            }
        }


        private void msgfromServer()
        {
            try
            {
                backgroundWorker2.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at msgfromServer. Message: " + ex.Message);
            }
        }


        private void msgfromServer2()
        {
            try
            {
                backgroundWorker4.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at msgfromServer2. Message: " + ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Logger.Info("At backgroundWorker1_DoWork ");
                while (client.Connected)
                {
                    Logger.Info("STEP1 At backgroundWorker1_DoWork ");
                    try
                    {
                        Logger.Info("STEP2 At backgroundWorker1_DoWork ");

                        //Logger.Info("**strlen: " + int.Parse(strlen.ToString()));
                        recieve = STR.ReadLine();
                        Logger.Info("STEP2.1 At backgroundWorker1_DoWork ");
                        MSGreceived = recieve;
                        Logger.Info("STEP2.2 At backgroundWorker1_DoWork ");
                        // int strlen = STR.ReadLine().Length;
                        Logger.Info("STEP2.3 At backgroundWorker1_DoWork ");
                        //Logger.Info("backgroundWorker1_DoWork MSGreceived: " + MSGreceived);
                        recieve = "";
                        string data2 = MSGreceived;
                        //Logger.Info("**strlen: " + int.Parse(strlen.ToString()) +
                        Logger.Info("data2: " + data2);
                        Logger.Info("Message received successfully.");
                        Logger.Info("STEP3 At backgroundWorker1_DoWork ");

                        //backgroundWorker1.CancelAsync();
                        //Logger.Info("backgroundWorker1 CancelAsync successfully.");



                        //HL7Model ObjHL7 = Newtonsoft.Json.JsonSerializer.Deserialize<HL7Model>();
                        //string data3 = "{\"EventTypeCode\":\"A08\", \"SendingApplication\":\"Velox\", \"SendingFacility\":\"Fac1\", \"ReceivingApplication\":\"ReceiviedBy\", \"ReceivingFacility\":\"Fac2\", \"DateTimeofMessage\":\"\", \"Security\":\"OK\", \"MessageType\":\"\", \"messagetype\":\"ADT\", \"triggerevent\":\"A08\", \"MessageControlID\":\"2302090420402040\", \"ProcessingID\":\"P\", \"VersionID\":\"2.3.1\", \"SequenceNumber\":\"\", \"ContinuationPointer\":\"\", \"AcceptAcknowledgmentType\":\"\", \"ApplicationAcknowledgmentType\":\"\", \"CountryCode1\":\"\", \"CharacterSet\":\"\", \"PrincipalLanguageofMessage\":\"\", \"AlternateCharacterSetHandlingScheme\":\"\", \"PIDSetID\":\"1\", \"PatientID\":\"245662\", \"External_ID\":\"\", \"External_checkdigit\":\"\", \"External_codeidentifyingthecheckdigitschemeemployed\":\"\", \"External_assigningauthority\":\"\", \"External_identifiertypecode\":\"\", \"External_assigningfacility\":\"\", \"PatientID_Internal\":\"245662\", \"Internal_ID\":\"\", \"Internal_checkdigit\":\"66\", \"Internal_codeidentifyingthecheckdigitschemeemployed\":\"\", \"Internal_assigningauthority\":\"\", \"Internal_identifiertypecode\":\"\", \"Internal_assigningfacility\":\"\", \"PatientID_Alternate\":\"\", \"Alternate_ID\":\"\", \"Alternate_checkdigit\":\"\", \"Alternate_codeidentifyingthecheckdigitschemeemployed\":\"\", \"Alternate_assigningauthority\":\"\", \"Alternate_identifiertypecode\":\"\", \"Alternate_assigningfacility\":\"\", \"PatientName\":\"test patient\", \"familyname\":\"test family\", \"givenname\":\"test given name\", \"middleinitial\":\"\", \"MotherMaidenName\":\"mother name\", \"DateofBirth\":\"100220231345\", \"Sex\":\"M\", \"PatientAlias\":\"\", \"Race\":\"\", \"PatientAddress\":\"\", \"streetaddress\":\"\", \"otherdesignation\":\"\", \"city\":\"canada\", \"stateorprovince\":\"\", \"ziporpostalcode\":\"\", \"country\":\"canada\", \"addresstype\":\"\", \"othergeographicdesignation\":\"\", \"countrycode2\":\"\", \"censustract\":\"\", \"addressrepresentationcode\":\"\", \"addressvalidityrange\":\"\", \"CountryCode3\":\"\", \"PhoneNumber_Home\":\"1225655\", \"PhoneNumber_Business\":\"54615616\", \"PrimaryLanguage\":\"\", \"MaritalStaus\":\"\", \"Religion\":\"\", \"PatientAccountNumber\":\"512252\", \"PatientAccount_id\":\"12\", \"checkdigit\":\"11\", \"codeidentifyingthecheckdigitschemeemployed\":\"\", \"SSNNumber_Patient\":\"154456\", \"DriverLicenseNumber_Patient\":\"245621452\", \"DriverLicenseNumber\":\"245555\", \"IssuingState_province_country\":\"15653\", \"MotherIdentifier\":\"213\", \"EthnicGroup\":\"\", \"BirthPlace\":\"Canada\", \"MultipleBirthIndicator\":\"\", \"BirthOther\":\"\", \"Citizenship\":\"Canada\", \"VeteransMilitaryStatus\":\"666\", \"NationalityCode\":\"22\", \"PatientDeathDateTime\":\"\", \"PatientDeathIndicator\":\"\", \"PV1SetID\":\"122\", \"PatientClass\":\"O\", \"AssignedPatientLocation\":\"\", \"PointOfCare\":\"\", \"Room\":\"3\", \"Bed\":\"3\", \"Facility\":\"FAC3\", \"LocationStatus\":\"\", \"PersonLocationType\":\"55\", \"Building\":\"B1\", \"Floor\":\"\", \"LocationType\":\"AD\", \"AdmissionType\":\"A\", \"PreadmitNumber\":\"1641\", \"PriorPatientLocation\":\"\", \"AttendingDoctor\":\"\", \"ReferringDoctor\":\"Dr Dave\", \"IDNumber\":\"9659\", \"Family_LastName\":\"Lastname\", \"GivenName\":\"given name\", \"ConsultingDoctor\":\"Dr...\", \"HospitalService\":\"\", \"TemporaryLocation\":\"ServiceName\", \"PreadmitTestIndicator\":\"\", \"Re_AdmissionIndicator\":\"\", \"AdmitSource\":\"\", \"AmbulatoryStatus\":\"\", \"VIPIndicator\":\"\", \"AdmittingDoctor\":\"\", \"PatientType\":\"2\", \"VisitNumber\":\"55\", \"FinancialClass\":\"\", \"ChargePriceIndicator\":\"\", \"CourtesyCode\":\"144\", \"CreditRating\":\"\", \"ContractCode\":\"54\", \"ContractEffectiveDate\":\"\", \"ContractAmount\":\"16531\", \"ContractPeriod\":\"12\", \"InterestCode\":\"2\", \"TransfertoBadDebtCode\":\"SD\", \"TransfertoBadDebtDate\":\"\", \"BadDebtAgencyCode\":\"\", \"BadDebtTransferAmount\":\"65665\", \"BadDebtRecoveryAmount\":\"566467\", \"DeleteAccountIndicator\":\"\", \"DeleteAccountDate\":\"\", \"DischargeDisposition\":\"\", \"DischargedToLocation\":\"\", \"DietType\":\"\", \"ServicingFacility\":\"\", \"BedStatus\":\"\", \"AccountStatus\":\"\", \"PendingLocation\":\"\", \"PriorTemporaryLocation\":\"\", \"AdmitDatetime\":\"\", \"DischargeDatetime\":\"\", \"CurrentPatientBalance\":\"46564\", \"TotalCharges\":\"5645521\", \"TotalAdjustments\":\"2654\", \"TotalPayments\":\"855885\", \"AlternateVisitID\":\"6546\", \"VisitIndicator\":\"521\", \"OtherHealthcareProvider\":\"774\" }";
                        //string data4 = "{\"IDNumber2\":\"14\",\"SendingApplicationSendingFacility\":\"Velox\",\"ReceivingApplication\":\"RevApp\",\"ReceivingFacility\":\"RevFac\",\"DateTimeofMessage\":\"\",\"Security\":\"22\",\"MessageType\":\"\",\"messagetype\":\"ORM\",\"triggerevent\":\"001\",\"MessageControlID\":\"5\",\"ProcessingID\":\"44\",\"VersionID\":\"2.1\",\"SequenceNumber\":\"\",\"ContinuationPointer\":\"\",\"AcceptAcknowledgmentType\":\"\",\"ApplicationAcknowledgmentType\":\"\",\"CountryCode\":\"522\",\"CharacterSet\":\"\",\"PrincipalLanguageofMessage\":\"HL7\",\"AlternateCharacterSetHandlingScheme\":\"\",\"PIDSetID\":\"321\",\"PatientID_External\":\"61\",\"External_ID\":\"32\",\"External_checkdigit\":\"5\",\"External_codeidentifyingthecheckdigitschemeemployed\":\"\",\"External_assigningauthority\":\"\",\"External_identifiertypecode\":\"\",\"External_assigningfacility\":\"FAC\",\"PatientID_Internal\":\"542\",\"Internal_ID\":\"15\",\"Internal_checkdigit\":\"11\",\"Internal_codeidentifyingthecheckdigitschemeemployed\":\"\",\"Internal_assigningauthority\":\"\",\"Internal_identifiertypecode\":\"\",\"Internal_assigningfacility\":\"FAC2\",\"PatientID_Alternate\":\"511\",\"Alternate_ID\":\"15\",\"Alternate_checkdigit\":\"12\",\"Alternate_codeidentifyingthecheckdigitschemeemployed\":\"\",\"Alternate_assigningauthority\":\"\",\"Alternate_identifiertypecode\":\"\",\"Alternate_assigningfacility\":\"\",\"PatientName\":\"Name\",\"familyname\":\"FamilyName\",\"givenname\":\"GivenName\",\"middleinitial\":\"middlename\",\"MotherMaidenName\":\"mothername\",\"DateofBirth\":\"\",\"Sex\":\"M\",\"PatientAlias\":\"LOLO\",\"Race\":\"\",\"PatientAddress\":\"2lenv\",\"streetaddress\":\"st.firstlane\",\"otherdesignation\":\"\",\"city\":\"canada\",\"stateorprovince\":\"551\",\"ziporpostalcode\":\"1165\",\"country\":\"Canada\",\"addresstype\":\"\",\"othergeographicdesignation\":\"\",\"countrycode\":\"662\",\"censustract\":\"3\",\"addressrepresentationcode\":\"621\",\"addressvalidityrange\":\"\",\"CountryCode\":\"662\",\"PhoneNumber_Home\":\"61656146\",\"PhoneNumber_Business\":\"46351113\",\"PrimaryLanguage\":\"\",\"MaritalStaus\":\"O\",\"Religion\":\"\",\"PatientAccountNumber\":\"16516\",\"PatientAccount_id\":\"521\",\"checkdigit\":\"46\",\"codeidentifyingthecheckdigitschemeemployed\":\"25\",\"SSNNumber_Patient\":\"2152445\",\"DriverLicenseNumber_Patient\":\"1566412\",\"DriverLicenseNumber\":\"16\",\"IssuingState_province_country\":\"45\",\"MotherIdentifier\":\"63\",\"EthnicGroup\":\"\",\"BirthPlace\":\"\",\"MultipleBirthIndicator\":\"\",\"BirthOther\":\"\",\"Citizenship\":\"Canada\",\"VeteransMilitaryStatus\":\"\",\"NationalityCode\":\"32\",\"PatientDeathDateTime\":\"\",\"PatientDeathIndicator\":\"\",\"PV1SetID\":\"31\",\"PatientClass\":\"35\",\"AssignedPatientLocation\":\"\",\"PointOfCare\":\"\",\"Room\":\"12\",\"Bed\":\"2\",\"Facility\":\"FAC23\",\"LocationStatus\":\"\",\"PersonLocationType\":\"\",\"Building\":\"3\",\"Floor\":\"1\",\"LocationType\":\"\",\"AdmissionType\":\"\",\"PreadmitNumber\":\"52\",\"PriorPatientLocation\":\"\",\"AttendingDoctor\":\"Dr.SAM\",\"ReferringDoctor\":\"Dr.Alex\",\"IDNumber\":\"22\",\"Family_LastName\":\"LastName\",\"GivenName\":\"GivenName\",\"ConsultingDoctor\":\"Dr.Alesia\",\"HospitalService\":\"\",\"TemporaryLocation\":\"\",\"PreadmitTestIndicator\":\"\",\"Re_AdmissionIndicator\":\"\",\"AdmitSource\":\"\",\"AmbulatoryStatus\":\"\",\"VIPIndicator\":\"2\",\"AdmittingDoctor\":\"\",\"PatientType\":\"\",\"VisitNumber\":\"25\",\"FinancialClass\":\"\",\"ChargePriceIndicator\":\"\",\"CourtesyCode\":\"21\",\"CreditRating\":\"33\",\"ContractCode\":\"2\",\"ContractEffectiveDate\":\"\",\"ContractAmount\":\"12156\",\"ContractPeriod\":\"2\",\"InterestCode\":\"2\",\"TransfertoBadDebtCode\":\"32\",\"TransfertoBadDebtDate\":\"\",\"BadDebtAgencyCode\":\"2\",\"BadDebtTransferAmount\":\"1861\",\"BadDebtRecoveryAmount\":\"1343\",\"DeleteAccountIndicator\":\"5\",\"DeleteAccountDate\":\"\",\"DischargeDisposition\":\"\",\"DischargedToLocation\":\"\",\"DietType\":\"\",\"ServicingFacility\":\"Facility5\",\"BedStatus\":\"2\",\"AccountStatus\":\"5\",\"PendingLocation\":\"\",\"PriorTemporaryLocation\":\"\",\"AdmitDatetime\":\"\",\"DischargeDatetime\":\"\",\"CurrentPatientBalance\":\"245512\",\"TotalCharges\":\"154311\",\"TotalAdjustments\":\"2554\",\"TotalPayments\":\"5255\",\"AlternateVisitID\":\"65\",\"VisitIndicator\":\"2\",\"OtherHealthcareProvider\":\"\",\"OrderControl\":\"\",\"PlacerOrderNumber\":\"22\",\"FillerOrderNumber\":\"222\",\"PlacerGroupNumber\":\"111\",\"OrderStatus\":\"\",\"ResponseFlag\":\"\",\"Quantity_Timing\":\"\",\"Quantity\":\"12\",\"Interval\":\"1\",\"Duration\":\"\",\"StartDateTime\":\"\",\"EndDateTime\":\"\",\"Priority\":\"2\",\"Parent\":\"\",\"DateTimeOfTransaction\":\"\",\"EnteredBy\":\"MrCaliv\",\"IDNumber\":\"22\",\"FamilyLastName\":\"familyLastName\",\"GivenName\":\"givenName\",\"VerifiedBy\":\"\",\"OrderingProvider\":\"\",\"ID_Number\":\"1\",\"Family_LastName\":\"Lastname\",\"Given_Name\":\"givenname\",\"EntererLocation\":\"\",\"PointOfCare\":\"\",\"Room\":\"12\",\"Bed\":\"2\",\"Facility\":\"Fac22\",\"LocationStatus\":\"\",\"PersonLocationType\":\"\",\"Building\":\"2\",\"Floor\":\"3\",\"LocationDescription\":\"\",\"CallBackPhoneNumber\":\"214661113\",\"PhoneNumber999\":\"99992219999219\",\"TelecommunicationUseCode\":\"11245552\",\"OrderEffectiveDatetime\":\"\",\"OrderControlCodeReason\":\"\",\"EnteringOrganization\":\"\",\"Identifier\":\"\",\"Text\":\"\",\"EnteringDevice\":\"\",\"ActionBy\":\"\",\"AdvancedBeneficiaryNoticeCode\":\"\",\"OrderingFacilityName\":\"OrderFacility\",\"OrderingFacilityAddress\":\"OrderFacilityAddress\",\"OrderingFacilityPhoneNumber\":\"225544\",\"OrderingProviderAddress\":\"154214\",\"StreetAddress\":\"\",\"OtherDesignation\":\"\",\"City\":\"Canada\",\"StateOrProvince\":\"22\",\"ZipOrPostalCode\":\"233\",\"Country\":\"canada\",\"AddressType\":\"\",\"OtherGeographicDesignation\":\"\",\"SetID\":\"2222\",\"PlacerOrderNumber\":\"1886\",\"FillerOrderNumber\":\"331\",\"UniversalServiceID\":\"21\",\"Identifier\":\"74\",\"Text\":\"\",\"NameOfCodingSystem\":\"\",\"AlternateIdentifier\":\"\",\"AlternateText\":\"\",\"Priority_OBR\":\"\",\"RequestedDateTime\":\"\",\"ObservationDateTime\":\"\",\"ObservationEndDateTime\":\"\",\"CollectionVolume\":\"\",\"CollectorIdentifier\":\"\",\"SpecimenActionCode\":\"\",\"DangerCode\":\"\",\"RelevantClinicalInfo\":\"\",\"SpecimenReceivedDateTime\":\"\",\"SpecimenSource\":\"SourceName\",\"OrderingProvider\":\"Provider\",\"IDNumber\":\"23\",\"FamilyLastName\":\"LASTNAME\",\"GivenName\":\"GIVENAME\",\"OrderCallBackPhoneNumber\":\"244232\",\"PhoneNumber999\":\"9992315999541\",\"TelecommunicationUseCode\":\"3562153255\",\"PlacerField1\":\"\",\"PlacerField2\":\"\",\"FillerField1\":\"\",\"FillerField2\":\"\",\"ResultsRpt_StatusChangeDateTime\":\"\",\"TimeOfAnEvent\":\"\",\"DegreeOfPrecision\":\"\",\"ChargeToPractice\":\"\",\"DollarAmount\":\"22434\",\"ChargeCode\":\"55\",\"DiagnosticServSectID\":\"18\",\"ResultStatus\":\"\",\"ParentResult\":\"\",\"Quantity_Timing\":\"\",\"Quantity\":\"13\",\"Interval\":\"1\",\"Duration\":\"\",\"StartDateTime\":\"\",\"EndDateTime\":\"\",\"Priority\":\"\",\"ResultCopiesTo\":\"\",\"Parent\":\"\",\"TransportationMode\":\"\",\"ReasonForStudy\":\"\",\"Identifier1\":\"\",\"Text1\":\"text1\",\"PrincipalResultInterpreter\":\"\",\"Name\":\"name\",\"StartDateTime1\":\"\",\"EndDateTime1\":\"\",\"PointOfCare\":\"\",\"Room\":\"23\",\"Bed\":\"5\",\"Facility\":\"facilit5\",\"LocationStatus\":\"\",\"PersonLocationType\":\"\",\"Building\":\"3\",\"Floor\":\"2\",\"AssistantResultInterpreter\":\"\",\"Name2\":\"name2\",\"StartDateTime2\":\"\",\"EndDateTime2\":\"\",\"PointOfCare2\":\"\",\"Room2\":\"3\",\"Bed2\":\"2\",\"Facility2\":\"fac2\",\"LocationStatus2\":\"\",\"PersonLocationType2\":\"\",\"Building2\":\"32\",\"Floor2\":\"1\",\"Technician\":\"\",\"Name3\":\"name3\",\"StartDateTime3\":\"\",\"EndDateTime3\":\"\",\"PointOfCare3\":\"\",\"Room3\":\"2\",\"Bed3\":\"7\",\"Facility3\":\"Fac3\",\"LocationStatus3\":\"\",\"PersonLocationType3\":\"\",\"Building3\":\"2\",\"Floor3\":\"3\",\"Transcriptionist\":\"\",\"Name4\":\"Name4\",\"StartDateTime4\":\"\",\"EndDateTime4\":\"\",\"PointOfCare4\":\"\",\"Room4\":\"3\",\"Bed4\":\"9\",\"Facility4\":\"Fac4\",\"LocationStatus4\":\"\",\"PersonLocationType4\":\"\",\"Building4\":\"2\",\"Floor4\":\"3\",\"ScheduledDateTime\":\"\",\"TimeOfAnEvent1\":\"\",\"DegreeOfPrecision1\":\"\",\"NumberOfSampleContainers\":\"\",\"TransportLogisticsOfCollectedSample\":\"\",\"Identifier2\":\"\",\"Text2\":\"text2\",\"NameOfCodingSystem2\":\"\",\"AlternateIdentifier2\":\"\",\"AlternateText2\":\"textalternated\",\"NameOfAlternateCodingSystem\":\"\",\"CollectorComment\":\"comment\",\"TransportArrangementResponsibility\":\"\",\"TransportArranged\":\"\",\"EscortRequired\":\"No\",\"PlannedPatientTransportComment\":\"commenthere\",\"ProcedureCode\":\"156\",\"ProcedureCodeModifier\":\"35\"}";
                        //Logger.Info("data4: " + data4.Trim());
                        //JObject json = JObject.Parse(data4);
                        //string myString = JsonConvert.ToString(data4);
                        //Logger.Info("backgroundWorker1_DoWork myString: " + myString);

                        //Logger.Info("________________________________________");
                        //string str = "{\"IDNumber2\":\"14\",\"SendingApplicationSendingFacility\":\"Velox\",\"ReceivingApplication\":\"RevApp\",\"ReceivingFacility\":\"RevFac\",\"DateTimeofMessage\":\"\",\"Security\":\"22\",\"MessageType\":\"\",\"messagetype\":\"ORM\",\"triggerevent\":\"001\",\"MessageControlID\":\"5\",\"ProcessingID\":\"44\",\"VersionID\":\"2.1\",\"SequenceNumber\":\"\",\"ContinuationPointer\":\"\",\"AcceptAcknowledgmentType\":\"\",\"ApplicationAcknowledgmentType\":\"\",\"CountryCode\":\"522\",\"CharacterSet\":\"\",\"PrincipalLanguageofMessage\":\"HL7\",\"AlternateCharacterSetHandlingScheme\":\"\",\"PIDSetID\":\"321\",\"PatientID_External\":\"61\",\"External_ID\":\"32\",\"External_checkdigit\":\"5\",\"External_codeidentifyingthecheckdigitschemeemployed\":\"\",\"External_assigningauthority\":\"\",\"External_identifiertypecode\":\"\",\"External_assigningfacility\":\"FAC\",\"PatientID_Internal\":\"542\",\"Internal_ID\":\"15\",\"Internal_checkdigit\":\"11\",\"Internal_codeidentifyingthecheckdigitschemeemployed\":\"\",\"Internal_assigningauthority\":\"\",\"Internal_identifiertypecode\":\"\",\"Internal_assigningfacility\":\"FAC2\",\"PatientID_Alternate\":\"511\",\"Alternate_ID\":\"15\",\"Alternate_checkdigit\":\"12\",\"Alternate_codeidentifyingthecheckdigitschemeemployed\":\"\",\"Alternate_assigningauthority\":\"\",\"Alternate_identifiertypecode\":\"\",\"Alternate_assigningfacility\":\"\",\"PatientName\":\"Name\",\"familyname\":\"FamilyName\",\"givenname\":\"GivenName\",\"middleinitial\":\"middlename\",\"MotherMaidenName\":\"mothername\",\"DateofBirth\":\"\",\"Sex\":\"M\",\"PatientAlias\":\"LOLO\",\"Race\":\"\",\"PatientAddress\":\"2lenv\",\"streetaddress\":\"st.firstlane\",\"otherdesignation\":\"\",\"city\":\"canada\",\"stateorprovince\":\"551\",\"ziporpostalcode\":\"1165\",\"country\":\"Canada\",\"addresstype\":\"\",\"othergeographicdesignation\":\"\",\"countrycode\":\"662\",\"censustract\":\"3\",\"addressrepresentationcode\":\"621\",\"addressvalidityrange\":\"\",\"CountryCode\":\"662\",\"PhoneNumber_Home\":\"61656146\",\"PhoneNumber_Business\":\"46351113\",\"PrimaryLanguage\":\"\",\"MaritalStaus\":\"O\",\"Religion\":\"\",\"PatientAccountNumber\":\"16516\",\"PatientAccount_id\":\"521\",\"checkdigit\":\"46\",\"codeidentifyingthecheckdigitschemeemployed\":\"25\",\"SSNNumber_Patient\":\"2152445\",\"DriverLicenseNumber_Patient\":\"1566412\",\"DriverLicenseNumber\":\"16\",\"IssuingState_province_country\":\"45\",\"MotherIdentifier\":\"63\",\"EthnicGroup\":\"\",\"BirthPlace\":\"\",\"MultipleBirthIndicator\":\"\",\"BirthOther\":\"\",\"Citizenship\":\"Canada\",\"VeteransMilitaryStatus\":\"\",\"NationalityCode\":\"32\",\"PatientDeathDateTime\":\"\",\"PatientDeathIndicator\":\"\",\"PV1SetID\":\"31\",\"PatientClass\":\"35\",\"AssignedPatientLocation\":\"\",\"PointOfCare\":\"\",\"Room\":\"12\",\"Bed\":\"2\",\"Facility\":\"FAC23\",\"LocationStatus\":\"\",\"PersonLocationType\":\"\",\"Building\":\"3\",\"Floor\":\"1\",\"LocationType\":\"\",\"AdmissionType\":\"\",\"PreadmitNumber\":\"52\",\"PriorPatientLocation\":\"\",\"AttendingDoctor\":\"Dr.SAM\",\"ReferringDoctor\":\"Dr.Alex\",\"IDNumber\":\"22\",\"Family_LastName\":\"LastName\",\"GivenName\":\"GivenName\",\"ConsultingDoctor\":\"Dr.Alesia\",\"HospitalService\":\"\",\"TemporaryLocation\":\"\",\"PreadmitTestIndicator\":\"\",\"Re_AdmissionIndicator\":\"\",\"AdmitSource\":\"\",\"AmbulatoryStatus\":\"\",\"VIPIndicator\":\"2\",\"AdmittingDoctor\":\"\",\"PatientType\":\"\",\"VisitNumber\":\"25\",\"FinancialClass\":\"\",\"ChargePriceIndicator\":\"\",\"CourtesyCode\":\"21\",\"CreditRating\":\"33\",\"ContractCode\":\"2\",\"ContractEffectiveDate\":\"\",\"ContractAmount\":\"12156\",\"ContractPeriod\":\"2\",\"InterestCode\":\"2\",\"TransfertoBadDebtCode\":\"32\",\"TransfertoBadDebtDate\":\"\",\"BadDebtAgencyCode\":\"2\",\"BadDebtTransferAmount\":\"1861\",\"BadDebtRecoveryAmount\":\"1343\",\"DeleteAccountIndicator\":\"5\",\"DeleteAccountDate\":\"\",\"DischargeDisposition\":\"\",\"DischargedToLocation\":\"\",\"DietType\":\"\",\"ServicingFacility\":\"Facility5\",\"BedStatus\":\"2\",\"AccountStatus\":\"5\",\"PendingLocation\":\"\",\"PriorTemporaryLocation\":\"\",\"AdmitDatetime\":\"\",\"DischargeDatetime\":\"\",\"CurrentPatientBalance\":\"245512\",\"TotalCharges\":\"154311\",\"TotalAdjustments\":\"2554\",\"TotalPayments\":\"5255\",\"AlternateVisitID\":\"65\",\"VisitIndicator\":\"2\",\"OtherHealthcareProvider\":\"\",\"OrderControl\":\"\",\"PlacerOrderNumber\":\"22\",\"FillerOrderNumber\":\"222\",\"PlacerGroupNumber\":\"111\",\"OrderStatus\":\"\",\"ResponseFlag\":\"\",\"Quantity_Timing\":\"\",\"Quantity\":\"12\",\"Interval\":\"1\",\"Duration\":\"\",\"StartDateTime\":\"\",\"EndDateTime\":\"\",\"Priority\":\"2\",\"Parent\":\"\",\"DateTimeOfTransaction\":\"\",\"EnteredBy\":\"MrCaliv\",\"IDNumber\":\"22\",\"FamilyLastName\":\"familyLastName\",\"GivenName\":\"givenName\",\"VerifiedBy\":\"\",\"OrderingProvider\":\"\",\"ID_Number\":\"1\",\"Family_LastName\":\"Lastname\",\"Given_Name\":\"givenname\",\"EntererLocation\":\"\",\"PointOfCare\":\"\",\"Room\":\"12\",\"Bed\":\"2\",\"Facility\":\"Fac22\",\"LocationStatus\":\"\",\"PersonLocationType\":\"\",\"Building\":\"2\",\"Floor\":\"3\",\"LocationDescription\":\"\",\"CallBackPhoneNumber\":\"214661113\",\"PhoneNumber999\":\"99992219999219\",\"TelecommunicationUseCode\":\"11245552\",\"OrderEffectiveDatetime\":\"\",\"OrderControlCodeReason\":\"\",\"EnteringOrganization\":\"\",\"Identifier\":\"\",\"Text\":\"\",\"EnteringDevice\":\"\",\"ActionBy\":\"\",\"AdvancedBeneficiaryNoticeCode\":\"\",\"OrderingFacilityName\":\"OrderFacility\",\"OrderingFacilityAddress\":\"OrderFacilityAddress\",\"OrderingFacilityPhoneNumber\":\"225544\",\"OrderingProviderAddress\":\"154214\",\"StreetAddress\":\"\",\"OtherDesignation\":\"\",\"City\":\"Canada\",\"StateOrProvince\":\"22\",\"ZipOrPostalCode\":\"233\",\"Country\":\"canada\",\"AddressType\":\"\",\"OtherGeographicDesignation\":\"\",\"SetID\":\"2222\",\"PlacerOrderNumber\":\"1886\",\"FillerOrderNumber\":\"331\",\"UniversalServiceID\":\"21\",\"Identifier\":\"74\",\"Text\":\"\",\"NameOfCodingSystem\":\"\",\"AlternateIdentifier\":\"\",\"AlternateText\":\"\",\"Priority_OBR\":\"\",\"RequestedDateTime\":\"\",\"ObservationDateTime\":\"\",\"ObservationEndDateTime\":\"\",\"CollectionVolume\":\"\",\"CollectorIdentifier\":\"\",\"SpecimenActionCode\":\"\",\"DangerCode\":\"\",\"RelevantClinicalInfo\":\"\",\"SpecimenReceivedDateTime\":\"\",\"SpecimenSource\":\"SourceName\",\"OrderingProvider\":\"Provider\",\"IDNumber\":\"23\",\"FamilyLastName\":\"LASTNAME\",\"GivenName\":\"GIVENAME\",\"OrderCallBackPhoneNumber\":\"244232\",\"PhoneNumber999\":\"9992315999541\",\"TelecommunicationUseCode\":\"3562153255\",\"PlacerField1\":\"\",\"PlacerField2\":\"\",\"FillerField1\":\"\",\"FillerField2\":\"\",\"ResultsRpt_StatusChangeDateTime\":\"\",\"TimeOfAnEvent\":\"\",\"DegreeOfPrecision\":\"\",\"ChargeToPractice\":\"\",\"DollarAmount\":\"22434\",\"ChargeCode\":\"55\",\"DiagnosticServSectID\":\"18\",\"ResultStatus\":\"\",\"ParentResult\":\"\",\"Quantity_Timing\":\"\",\"Quantity\":\"13\",\"Interval\":\"1\",\"Duration\":\"\",\"StartDateTime\":\"\",\"EndDateTime\":\"\",\"Priority\":\"\",\"ResultCopiesTo\":\"\",\"Parent\":\"\",\"TransportationMode\":\"\",\"ReasonForStudy\":\"\",\"Identifier1\":\"\",\"Text1\":\"text1\",\"PrincipalResultInterpreter\":\"\",\"Name\":\"name\",\"StartDateTime1\":\"\",\"EndDateTime1\":\"\",\"PointOfCare\":\"\",\"Room\":\"23\",\"Bed\":\"5\",\"Facility\":\"facilit5\",\"LocationStatus\":\"\",\"PersonLocationType\":\"\",\"Building\":\"3\",\"Floor\":\"2\",\"AssistantResultInterpreter\":\"\",\"Name2\":\"name2\",\"StartDateTime2\":\"\",\"EndDateTime2\":\"\",\"PointOfCare2\":\"\",\"Room2\":\"3\",\"Bed2\":\"2\",\"Facility2\":\"fac2\",\"LocationStatus2\":\"\",\"PersonLocationType2\":\"\",\"Building2\":\"32\",\"Floor2\":\"1\",\"Technician\":\"\",\"Name3\":\"name3\",\"StartDateTime3\":\"\",\"EndDateTime3\":\"\",\"PointOfCare3\":\"\",\"Room3\":\"2\",\"Bed3\":\"7\",\"Facility3\":\"Fac3\",\"LocationStatus3\":\"\",\"PersonLocationType3\":\"\",\"Building3\":\"2\",\"Floor3\":\"3\",\"Transcriptionist\":\"\",\"Name4\":\"Name4\",\"StartDateTime4\":\"\",\"EndDateTime4\":\"\",\"PointOfCare4\":\"\",\"Room4\":\"3\",\"Bed4\":\"9\",\"Facility4\":\"Fac4\",\"LocationStatus4\":\"\",\"PersonLocationType4\":\"\",\"Building4\":\"2\",\"Floor4\":\"3\",\"ScheduledDateTime\":\"\",\"TimeOfAnEvent1\":\"\",\"DegreeOfPrecision1\":\"\",\"NumberOfSampleContainers\":\"\",\"TransportLogisticsOfCollectedSample\":\"\",\"Identifier2\":\"\",\"Text2\":\"text2\",\"NameOfCodingSystem2\":\"\",\"AlternateIdentifier2\":\"\",\"AlternateText2\":\"textalternated\",\"NameOfAlternateCodingSystem\":\"\",\"CollectorComment\":\"comment\",\"TransportArrangementResponsibility\":\"\",\"TransportArranged\":\"\",\"EscortRequired\":\"No\",\"PlannedPatientTransportComment\":\"commenthere\",\"ProcedureCode\":\"156\",\"ProcedureCodeModifier\":\"35\"}";

                        //JObject jsonObj = JObject.Parse(str);

                        //Logger.Info("**json: " + jsonObj);

                        //string jsonstr = JsonConvert.SerializeObject(jsonObj);
                        //Logger.Info("**jsonstr: " + jsonstr);

                        //Logger.Info("________________________________________");


                        if (data2.Contains("|"))
                        {
                            Logger.Info("STEP4.0 At backgroundWorker1_DoWork data2: " + data2);
                        }
                        else
                        {
                            Logger.Info("STEP4 At backgroundWorker1_DoWork ");
                            var model = JsonConvert.DeserializeObject<HL7Model>(data2);
                            Logger.Info("STEP5 At backgroundWorker1_DoWork ");
                            GetADTA08HL7PipeMessageNEW(model);
                            var orm_model = JsonConvert.DeserializeObject<HL7ORMModel>(data2);
                            GetORMMessageNEW(orm_model);
                            msgfromServer();
                        }
                    }
                    catch (Exception ex)
                    {
                        //client.Close();
                        //Logger.Info("client connection closed successfully.");
                        Logger.Error("Exception at backgroundWorker1_DoWork at msg Recived: " + ex.Message);
                        //Publisher Pub = new Publisher(Localhost, Port);
                        //Pub.SendACK();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at backgroundWorker1_DoWork. Message: " + ex.Message);
            }
        }


        private void GetADTA08HL7PipeMessageNEW(HL7Model ObjHL7)
        {
            try
            {
                // create the HL7 message
                // this AdtMessageFactory class is not from NHAPI but my own wrapper
                Logger.Info("At GetADTA08HL7PipeMessageNEW STEP1.");
                var adtMessage = ADTMessageFactory.CreateMessageNEW("A08", ObjHL7);
                // create these parsers for the file encoding operations

                Logger.Info("At GetADTA08HL7PipeMessageNEW STEP2. Done");

            }
            catch (Exception e)
            {
                Logger.Error($"Error occured while creating HL7 msg for GetADTA08HL7PipeMessageNEW {e.Message}");
            }
        }


        private void GetORMMessageNEW(HL7ORMModel aDTMessageModel)
        {
            try
            {
                Logger.Info("At GetORMMessageNEW STEP1.");
                var adtMessage = ORMMessageFactory.CreateMessageNEW("001", aDTMessageModel);

                // serialize the message to pipe delimited output file
                Logger.Info("At GetORMMessageNEW STEP2. Done");
            }
            catch (Exception ex)
            {
                Logger.Error($"Error occured while creating HL7 msg for GetORMMessageNEW {ex.Message}");
            }

        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Logger.Info("At backgroundWorker3_DoWork ==========");
                while (client2.Connected)
                {
                    Logger.Info("STEP1 At backgroundWorker3_DoWork ");
                    try
                    {
                        Logger.Info("STEP2 At backgroundWorker3_DoWork ");

                        //Logger.Info("**strlen: " + int.Parse(strlen.ToString()));
                        recieve2 = STR2.ReadToEnd();
                        Logger.Info("STEP2.1 At backgroundWorker3_DoWork ");
                        MSGreceived2 = recieve2;
                        Logger.Info("STEP2.2 At backgroundWorker3_DoWork ");
                        // int strlen = STR.ReadLine().Length;
                        Logger.Info("STEP2.3 At backgroundWorker3_DoWork ");
                        //Logger.Info("backgroundWorker1_DoWork MSGreceived: " + MSGreceived);
                        recieve = "";
                        string data2 = MSGreceived2;
                        //Logger.Info("**strlen: " + int.Parse(strlen.ToString()) +
                        Logger.Info("* data2: " + data2.Trim());
                        Logger.Info("Message received successfully.");
                        if (data2.Trim().Length > 0)
                        {
                            Logger.Info("for create connexfile...data2.Trim().Length: " + data2.Trim().Length);
                            CreateConnexResponseFile(data2);
                        }
                        Logger.Info("STEP3 At backgroundWorker3_DoWork");
                        client2.Dispose();
                        client2.Close();
                        //ack msg 
                        //Logger.Info("data2.string = null: " + data2 + ", Localhost: " + Localhost + ", port: 6262");
                        //Publisher Pub = new Publisher(Localhost, 6262);
                        //Pub.SendACK();

                        //msgfromServer2();//to ack msg

                        //if (data2.Contains("|"))
                        //{
                        //    Logger.Info("STEP4.0 At backgroundWorker3_DoWork data2: " + data2);
                        //}
                        //else
                        //{
                        //    Logger.Info("STEP4 At backgroundWorker3_DoWork ");
                        //    var model = JsonConvert.DeserializeObject<HL7Model>(data2);
                        //    Logger.Info("STEP5 At backgroundWorker3_DoWork ");
                        //    GetADTA08HL7PipeMessageNEW(model);
                        //    var orm_model = JsonConvert.DeserializeObject<HL7ORMModel>(data2);
                        //    GetORMMessageNEW(orm_model);
                        //    msgfromServer();
                        //}

                    }
                    catch (Exception ex)
                    {
                        //client.Close();
                        //Logger.Info("client connection closed successfully.");
                        Logger.Error("Exception at backgroundWorker3_DoWork at msg Recived: " + ex.Message);
                        //Publisher Pub = new Publisher(Localhost, Port);
                        //Pub.SendACK();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at backgroundWorker3_DoWork. Message: " + ex.Message);
            }
        }

        public void CreateConnexResponseFile(string LogMessage)
        {
            try
            {
                string path = @"C:\HL7\Connexion\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".hl7";
                using (var file = new StreamWriter(path, true))
                {
                    file.WriteLine(LogMessage + "\n ");
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at CreateConnexResponseFile. Message: " + ex.Message);
            }
        }



        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Logger.Info("At backgroundWorker4_DoWork ");
                if (client2.Connected)
                {
                    // Listener2();
                    Logger.Info("At backgroundWorker4_DoWork,before sending msg to Server MSGreceived2: " + MSGreceived2);
                    string msg = "MSH|^~&|T11|T11|MERGE RIS|TRILLIUM|201301011228||ACK^A01^ACK |HL7ACK00001|P|2.3 MSA|AA|HL7MSG00001";
                    STW2.WriteLine(msg);
                    Logger.Info("At backgroundWorker4_DoWork, Server msg: " + msg);

                    //Logger.Info("data2.string = null: " + data2 + ", Localhost: " + Localhost + ", port: 6262");
                    //Publisher Pub = new Publisher(Localhost, 6262);
                    //Pub.SendACK();
                }
                backgroundWorker4.CancelAsync();
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at backgroundWorker4_DoWork. Message: " + ex.Message);
            }
        }
    }
}

