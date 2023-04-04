using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpIpServerService.Helper
{
    public class Subscriber
    {
        Logger Logger = LogManager.GetCurrentClassLogger();
        private System.Net.Sockets.Socket listener;
        private IPEndPoint endPoint;
        public Subscriber(IPEndPoint endPoint)
        {
            try
            {
                Logger.Info("At Subscriber..");
                this.endPoint = endPoint;
                Logger.Info("At Subscriber..endpoint: " + endPoint + ", InterNetwork: " + AddressFamily.InterNetwork);
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(endPoint);
                Logger.Info("Listening to port {0}", endPoint);
                listener.Listen(3);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at Subscriber. Message: " + ex.Message);
                
            }
        }

        public void Listen()
        {
            Logger.Info("At Listen STEP1");
            // Declare your variables.
            // Do not declare variables inside loops like for, foreach, while etc.
            // Because with every iteration, a new variable will be created.
            // If your loop iterates 1000 times, you will end up creating 1000 variables instead of just one variable.
            byte[] buffer;
            int count;
            string data;
            string tempData;
            string response = String.Empty;
            int start;
            int end;
            try
            {
                // true here make sure that the thread keep listening to the port.
                Logger.Info("At Listen STEP2");
                while (true)
                {
                    Logger.Info("At Listen STEP3");
                    buffer = new byte[4096];

                    // Take care of incoming connection ...
                    Socket receiver = listener.Accept();
                    Logger.Info("Taking care of incoming connection.");
                    Logger.Info("At Listen STEP4");
                    // Handle the message if one is received.
                    while (true)
                    {
                        Logger.Info("At Listen STEP5");
                        count = receiver.Receive(buffer);
                        data = Encoding.UTF8.GetString(buffer, 0, count);

                        // Search for a Vertical Tab (VT) character to find start of MLLP frame.
                        start = data.IndexOf((char)0x0b);
                        Logger.Info("At Listen STEP6");
                        if (start >= 0)
                        {
                            Logger.Info("At Listen STEP7");
                            // Search for a File Separator (FS) character to find the end of the frame.
                            end = data.IndexOf((char)0x1c);
                            Logger.Info("At Listen STEP8");
                            if (end > start)
                            {
                                try
                                {
                                    Logger.Info("At Listen STEP9");
                                    // Remove the MLLP charachters
                                    tempData = Encoding.UTF8.GetString(buffer, 4, count - 12);
                                    Logger.Info("At Listen STEP9.1, tempData: " + tempData.ToString());
                                    // Do what you want with the received message
                                    response = HandleMessage(tempData);
                                    Logger.Info("At Listen STEP9.2, response: " + response.ToString());

                                    // Send response
                                    receiver.Send(Encoding.UTF8.GetBytes(response));
                                    Logger.Info("At Listen STEP10");
                                    Logger.Info("Acknowledgment sent: " + response);
                                    break;
                                }catch (Exception ex)
                                {
                                    Logger.Error("Exception at Listen: " + ex.Message);
                                }
                            }
                        }
                    }

                    // close connection
                    receiver.Shutdown(SocketShutdown.Both);
                    receiver.Close();

                    Logger.Info("Connection closed STEP11");
                }
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                Logger.Error("Exception at Listen. Message: " + ex.Message);
            }
        }

        private string HandleMessage(string data)
        {
            string responseMessage = String.Empty;
            try
            {
                Logger.Info("Message received.");

                Message msg = new Message();
                msg.DeSerializeMessage(data);

                // You can do what you want with the message here as per your appliation requirements.
                // For eg: read patient ID, patient last name, age etc.

                // Create a response message
                //
                responseMessage = CreateRespoonseMessage(msg.MessageControlId());
                Logger.Info("responseMessage : " + responseMessage);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception at HandleMessage. Message: " + ex.Message);
            }
            return responseMessage;
        }

        private string CreateRespoonseMessage(string messageControlID)
        {
            try
            {
                Logger.Info("At CreateRespoonseMessage");
                Message response = new Message();

                Segment msh = new Segment("MSH");
                msh.Field(2, "^~\\&");
                msh.Field(7, DateTime.Now.ToString("yyyyMMddhhmmsszzz"));
                msh.Field(9, "ACK");
                msh.Field(10, Guid.NewGuid().ToString());
                msh.Field(11, "P");
                msh.Field(12, "2.5.1");
                response.Add(msh);

                Segment msa = new Segment("MSA");
                msa.Field(1, "AA");
                msa.Field(2, messageControlID);
                response.Add(msa);


                // Create a Minimum Lower Layer Protocol (MLLP) frame.
                // For this, just wrap the data lik this: <VT> data <FS><CR>
                StringBuilder frame = new StringBuilder();
                frame.Append((char)0x0b);
                frame.Append(response.SerializeMessage());
                frame.Append((char)0x1c);
                frame.Append((char)0x0d);
                Console.WriteLine("frame: " + frame.ToString());
                return frame.ToString();
            }
            catch (Exception ex)
            {
                Logger.Info("Exception at CreateRespoonseMessage. Message: " + ex.Message);

                return String.Empty;
            }
        }
    }
}
