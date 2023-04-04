using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpIpServerService.Helper
{
    public class Publisher
    {
        Logger Logger = LogManager.GetCurrentClassLogger();
        private System.Net.Sockets.Socket sender;
        byte[] localhost;
        int port;
        public Publisher(byte[] localhost, int port)
        {
            this.localhost = localhost;
            this.port = port;
        }

        public void Send()
        {
            port = 6161;
            IPAddress address = new IPAddress(localhost);
            IPEndPoint endPoint = new IPEndPoint(address, port);
            Logger.Info("IP: " + address + ", port: " + endPoint);
            while (true)
            {
                Logger.Info("AT Send STEP1");
                try
                {
                    Logger.Info("AT Send STEP2");
                    sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Logger.Info("AT Send STEP2.1: sender: " + sender + ", endPoint: " + endPoint);
                    sender.Connect(endPoint);
                    Logger.Info("AT Send STEP2.2");
                    DirectoryInfo place = new DirectoryInfo(@"C:\HL7");
                    Logger.Info("AT Send STEP2.3");
                    FileInfo[] Files = place.GetFiles();
                    Logger.Info("AT Send STEP2.4 files array lenght: " + Files.Length.ToString());
                    if (int.Parse(Files.Length.ToString()) > 0)
                    {
                        Logger.Info("AT Send STEP3");
                        foreach (FileInfo i in Files)
                        {
                            Logger.Info("AT Send STEP4");
                            //Logger.Info("File Name - {0}", i.Name);
                            //Logger.Info("DirectoryName - {0}", i.DirectoryName);
                            //Logger.Info("Directory - {0}", i.Directory);
                            Logger.Info("FullName - {0}", i.FullName);
                            string[] hl7Data1 = System.IO.File.ReadAllLines(i.FullName);
                            byte[] hl7Data = System.IO.File.ReadAllBytes(i.FullName);
                            //string[] hl7Data1 = System.IO.File.ReadAllLines(@"C:\Users\user\Desktop\DicomServerSetup_V1.0.18\A08.hl7");
                            //byte[] hl7Data = System.IO.File.ReadAllBytes(@"C:\Users\user\Desktop\DicomServerSetup_V1.0.18\A08.hl7");
                            Logger.Info("hl7Data1 at 0 index: " + hl7Data1[0]);
                            Logger.Info("hl7Data1 at 1 index: " + hl7Data1[1]);
                            //Logger.Info("hl7Data1 at 2 index: " + hl7Data1[2]);
                            //Logger.Info("hl7Data1 at 3 index: " + hl7Data1[3]);
                            //Logger.Info("hl7Data1 at 4 index: " + hl7Data1[4]);
                            //Logger.Info("hl7Data1 at 5 index: " + hl7Data1[5]);
                            //Logger.Info("hl7Data1 at 6 index: " + hl7Data1[6]);
                            //Logger.Info("hl7Data1 at 7 index: " + hl7Data1[7]);
                            //Logger.Info("hl7Data1 at 8 index: " + hl7Data1[8]);
                            int dataLength = hl7Data.Length;
                            byte[] dataToSend = new byte[dataLength + 3];
                            dataToSend[0] = 0x0b; // Add a Vertical Tab (VT) character
                            Array.Copy(hl7Data, 0, dataToSend, 1, dataLength);
                            dataToSend[dataLength + 1] = 0x1c; // Add File Separator (FS) charachter
                            dataToSend[dataLength + 2] = 0x0d; // Add carriage return (CR) charachter
                            sender.SendBufferSize = 4096;
                            try
                            {
                                sender.Send(dataToSend);
                                Logger.Info("message: " + dataToSend.ToString());
                                Logger.Info("HL7 message sent.");
                            }
                            catch (System.Net.Sockets.SocketException ex)
                            {
                                Logger.Error("Exception at Message sender.Send: " + ex.Message);
                            }
                            byte[] Localhost = { 127, 0, 0, 1 };
                            int Port = 6161;
                            System.Net.IPAddress Hostaddress = new IPAddress(Localhost);
                            System.Net.IPEndPoint HostendPoint = new IPEndPoint(Hostaddress, Port);

                            System.Threading.Thread.Sleep(5000);
                            Logger.Info("After sleep..for 5000.");
                            try
                            {    //commented20022023 for send ACK msg to MIRTH
                                foreach (FileInfo j in Files)
                                {
                                    File.Delete(j.FullName);
                                    Logger.Info("File deleted successfully.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Error("Exception at File delete. Message: " + ex.Message);
                            }
                            Logger.Info("At OnElapsedTimeCall. address: " + Hostaddress + ", Port: " + Port + ", endPoint:" + HostendPoint);
                            Subscriber Sub = new Subscriber(HostendPoint);
                            Sub.Listen();
                            Logger.Info("After sleep..for 5000.");
                        }
                    }
                    else
                    {
                        Logger.Trace("No file available..");
                    }
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    Logger.Error("Exception Message2: " + ex.Message);
                }
                finally
                {

                    Logger.Info("At finally for Send...");
                    //byte[] Localhost = { 127, 0, 0, 1 };
                    //int Port = 6161;
                    //Publisher Pub = new Publisher(Localhost, Port);
                    //Pub.SendACK();
                    //sender.Close();
                    //Logger.Info("sender close");
                    //sender.Shutdown(SocketShutdown.Both);

                }
            }
        }


        public void SendACK()
        {
            Logger.Info("AT SendACK.. ");
            port = 6262;
            IPAddress address = new IPAddress(localhost);
            IPEndPoint endPoint = new IPEndPoint(address, port);
            Logger.Info("AT SendACK IP: " + address + ", port: " + endPoint);
            while (true)
            {
                Logger.Info("AT SendACK STEP1");
                try
                {
                    Logger.Info("AT SendACK STEP2");
                    sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Logger.Info("AT SendACK STEP2.1: sender: " + sender + ", endPoint: " + endPoint);
                    sender.Connect(endPoint);
                    Logger.Info("AT SendACK STEP2.2");
                    DirectoryInfo place = new DirectoryInfo(@"C:\HL7\ACK\");
                    Logger.Info("AT SendACK STEP2.3");
                    FileInfo[] Files = place.GetFiles();
                    Logger.Info("AT SendACK STEP2.4 files array lenght: " + Files.Length.ToString());
                    if (int.Parse(Files.Length.ToString()) > 0)
                    {
                        Logger.Info("AT SendACK STEP3");
                        foreach (FileInfo i in Files)
                        {
                            Logger.Info("AT SendACK STEP4");
                            //Logger.Info("File Name - {0}", i.Name);
                            //Logger.Info("DirectoryName - {0}", i.DirectoryName);
                            //Logger.Info("Directory - {0}", i.Directory);
                            Logger.Info("FullName - {0}", i.FullName);
                            string[] hl7Data1 = System.IO.File.ReadAllLines(i.FullName);
                            byte[] hl7Data = System.IO.File.ReadAllBytes(i.FullName);
                            //string[] hl7Data1 = System.IO.File.ReadAllLines(@"C:\Users\user\Desktop\DicomServerSetup_V1.0.18\A08.hl7");
                            //byte[] hl7Data = System.IO.File.ReadAllBytes(@"C:\Users\user\Desktop\DicomServerSetup_V1.0.18\A08.hl7");
                            Logger.Info("hl7Data1 at 0 index: " + hl7Data1[0]);

                            int dataLength = hl7Data.Length;
                            byte[] dataToSend = new byte[dataLength + 3];
                            dataToSend[0] = 0x0b; // Add a Vertical Tab (VT) character
                            Array.Copy(hl7Data, 0, dataToSend, 1, dataLength);
                            dataToSend[dataLength + 1] = 0x1c; // Add File Separator (FS) charachter
                            dataToSend[dataLength + 2] = 0x0d; // Add carriage return (CR) charachter
                            sender.SendBufferSize = 4096;
                            try
                            {
                                sender.Send(dataToSend);
                                Logger.Info("message: " + dataToSend.ToString());
                                Logger.Info("At SendACK HL7 message sent.");
                            }
                            catch (System.Net.Sockets.SocketException ex)
                            {
                                Logger.Error("Exception at SendACK Message sender.Send ex.Message: " + ex.Message);
                            }
                            //byte[] Localhost = { 127, 0, 0, 1 };
                            //int Port = int.Parse(ConfigurationManager.AppSettings["mirth_listening_port"].ToString());//6262;
                            //Logger.Info("new port opened: " + Port);
                            //System.Net.IPAddress Hostaddress = new IPAddress(Localhost);
                            //System.Net.IPEndPoint HostendPoint = new IPEndPoint(Hostaddress, Port);
                            //Logger.Info("At OnElapsedTimeCall. address: " + Hostaddress + ", Port: " + Port + ", endPoint:" + HostendPoint);
                            //Subscriber Sub = new Subscriber(HostendPoint);
                            //Sub.Listen();
                            //Logger.Info("After sleep..for 10000 STEP2.");


                            try
                            {    //commented20022023 for send ACK msg to MIRTH
                                foreach (FileInfo j in Files)
                                {
                                    File.Delete(j.FullName);
                                    Logger.Info("At SendACK File deleted successfully.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Error("Exception at File delete. Message: " + ex.Message);
                            }

                        }
                    }
                    else
                    {
                        Logger.Info("At SendACK No file available..");
                    }
                    //byte[] Localhost1 = { 127, 0, 0, 1 };
                    //int Port1 = 6262;
                    //System.Net.IPAddress Hostaddress1 = new IPAddress(Localhost1);
                    //System.Net.IPEndPoint HostendPoint1 = new IPEndPoint(Hostaddress1, Port1);
                    //Logger.Info("At OnElapsedTimeCall. address: " + Hostaddress1 + ", Port: " + Port1 + ", endPoint:" + HostendPoint1);
                    //Subscriber Sub1 = new Subscriber(HostendPoint1);
                    //Sub1.Listen();
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    Logger.Error("Exception Message2: " + ex.Message);
                }
                finally
                {
                    Logger.Info("At finally for SendACK...");
                    sender.Shutdown(SocketShutdown.Both);
                    Logger.Info("sender shutdown");
                    sender.Close();
                    Logger.Info("sender close");
                   
                }
            }

        }
    }
}
