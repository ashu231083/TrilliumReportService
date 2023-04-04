using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHapi.Base.Parser;
using NHapi.Model.V23.Message;
using NHapi.Model.V251.Message;
using NLog;

namespace HL7.Dotnetcore.Test
{

    [TestClass]
    public class HL7Test
    {
        Logger Logger = LogManager.GetCurrentClassLogger();
        private string HL7_ORM;
        private string HL7_ADT;
        private string HL7_ORU;

        public static void Main(string[] args)
        {
            try
            {
                var test = new HL7Test();
                test.NHapi();
                test.HL7ToJson();
                test.ParseTest1();
                test.ReadSegmentTest();
                test.EmptyFieldsTest();
                test.EmptyAndNullFieldsTest();
                test.PresentButNull();
                //test.DecodedValue();
                //test.DecodedValue1();
                //test.AddRepeatingField();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception at main: " + ex.ToString());
            }
        }

        public void NHapi()
        {
            var ourPipeParser = new PipeParser();
            string messageString = "MSH|^~\\&|SENDING_APPLICATION|SENDING_FACILITY|RECEIVING_APPLICATION|RECEIVING_FACILITY|20110614075841||ACK|1407511|P|2.3||||";
            var hl7Message = ourPipeParser.Parse(messageString);
            var ackResponseMessage = hl7Message as NHapi.Model.V23.Message.ACK;

            string msgORU = "MSH|^~\\&|FLUENCY|FLUENCY|MERGE RIS|TRILLIUM|20230321065547||ORU^R01|20230321065547.2214029|P|2.3|\r\n" +
"PID|1||704369||Fakher^ Meenay||19870916 | F ||||||||||\r\n" +
"PV1|||MSCQ ^ ^^^^^^^MSCQ |||||||||||||||| 4574722 |||||||||||||||||||||||||| 2023 - 03 - 20 12:00:00 AM - 04:00 |\r\n" +
"ORC|RE||10488503 |||||| 20230321065547 |\r\n" +
"OBR|1|10488503 | 10488503 ^ Velox | J159 J166 ^ OB Routine ||| 20230321065547 |||||||||||||||||| F | ^^||||| ^AS PER REQUISITION| 8140 ^ Fraser ^ Lorna | ^^20230321105012 ||| 20230320080550 |\r\n" +
"OBX|1|FT|^^| EXAM : DESCRIPTION OB Routine anatomy scan~~CLINICAL HISTORY: Fetal anatomy~~COMPARISON:  Obstetrical ultrasound reports January 17 and January 30, 2023 which had indicated EDC August 6, 2023~~FINDINGS:  Based on EDD this pregnancy should now be at 20 weeks one day.~~There is a single live intrauterine gestation with measurements as follows:~BPD 44.2 mm, 19 weeks two days~Head circumference 162 mm, 19 weeks~Abdominal circumference 148.1 mm, 20 weeks~Humerus 30.8 mm, 20 weeks one day~Femur length 32 mm, 20 weeks~Mean age by today's ultrasound is 19 weeks five days.~~Estimated fetal weight is 320 g which corresponds to the 32.3 percentile for expected gestational age (Hadlock).~~Fetal heart rate measures 162 beats per minute.~~Fetal intracranial structures, orbits, lenses, nose and lips, profile view of the fetal face, spine in sagittal and transverse plane, chest, abdomen, diaphragm, kidneys, stomach, bladder, four-chamber cardiac view, right and left cardiac outflow tracts, cine crossover vessel view, one arm, both hands, both legs, three-vessel cord and abdominal cord insertion site are seen and are unremarkable.~~Distal fetal spine in coronal plane, three-vessel cardiac view, aortic arch, one arm and both feet and ankles are not well seen.~~Fetal sex has not been requested, but is probably female.~~The amniotic fluid volume is subjectively normal.~~The placenta is anterior/fundal and clear of the internal cervical os by approximately 8 cm.  Placental cord insertion site is approximately 3 cm from placental margin on sagittal images.~~A 4.2 x 3.5 x 3.1 cm lower posterior wall fibroid is noted.~~The cervix measures 5.2 cm in length and is closed.~~IMPRESSION:  Single live intrauterine gestation corresponding to 19 weeks five days, slightly smaller than expected according to the patient's dates.~~Estimated fetal weight corresponds to the 32.3 percentile for expected gestational age(Hadlock).~~No gross abnormality of fetal anatomy is demonstrated.~~However, distal fetal spine in coronal plane, three - vessel cardiac view, aortic arch, one arm and both feet and ankles are not well seen.~~Short - term follow - up ultrasound is recommended for reassessment.~|||||| F ||||| 8140 ||";
            var ORUhl7Message = ourPipeParser.Parse(msgORU);
            var ORUackResponseMessage = ORUhl7Message as NHapi.Model.V24.Message.ORU_R01;

            



            if (ackResponseMessage != null)
            {

                //access message data and display it
                //note that I am using encode method at the end to convert it back to string for display
                var mshSegmentMessageData = ackResponseMessage.MSH;
                LogToDebugConsole("----------------------");
                LogToDebugConsole("Message FieldSeparator is " + mshSegmentMessageData.FieldSeparator);
                LogToDebugConsole("Message EncodingCharacters is " + mshSegmentMessageData.EncodingCharacters);
                LogToDebugConsole("Message SendingApplication is " + mshSegmentMessageData.SendingApplication.NamespaceID.Description);
                LogToDebugConsole("Message SendingFacility is " + mshSegmentMessageData.SendingFacility.NamespaceID.Description);
                LogToDebugConsole("Message ReceivingApplication is " + mshSegmentMessageData.ReceivingApplication);
                LogToDebugConsole("Message ReceivingFacility is " + mshSegmentMessageData.ReceivingFacility);
                LogToDebugConsole("Message DateTimeOfMessage is " + mshSegmentMessageData.DateTimeOfMessage);
                LogToDebugConsole("Message Security is " + mshSegmentMessageData.Security);
                LogToDebugConsole("Message MessageType is " + mshSegmentMessageData.MessageType);
                LogToDebugConsole("Message MessageControlID is " + mshSegmentMessageData.MessageControlID);
                LogToDebugConsole("Message ProcessingID is " + mshSegmentMessageData.ProcessingID);
                LogToDebugConsole("Message VersionID is " + mshSegmentMessageData.VersionID);
                LogToDebugConsole("Message SequenceNumber is " + mshSegmentMessageData.SequenceNumber);
                LogToDebugConsole("Message ContinuationPointer is " + mshSegmentMessageData.ContinuationPointer);
                LogToDebugConsole("Message AcceptAcknowledgementType is " + mshSegmentMessageData.AcceptAcknowledgementType);
                LogToDebugConsole("Message ApplicationAcknowledgementType is " + mshSegmentMessageData.ApplicationAcknowledgementType);
                LogToDebugConsole("Message CountryCode is " + mshSegmentMessageData.CountryCode);
                LogToDebugConsole("Message CharacterSet is " + mshSegmentMessageData.CharacterSet);
                LogToDebugConsole("Message PrincipalLanguageOfMessage is " + mshSegmentMessageData.PrincipalLanguageOfMessage.ToString());
                LogToDebugConsole("----------------------");



                Dictionary<string, string> ORUmsg = new Dictionary<string, string>();

                ORUmsg.Add(mshSegmentMessageData.SendingApplication.Description, mshSegmentMessageData.SendingApplication.NamespaceID.Value);
                ORUmsg.Add(mshSegmentMessageData.SendingFacility.Description, mshSegmentMessageData.SendingFacility.NamespaceID.Value);
                ORUmsg.Add(mshSegmentMessageData.ReceivingApplication.Description, mshSegmentMessageData.ReceivingApplication.NamespaceID.Value);
                ORUmsg.Add(mshSegmentMessageData.ReceivingFacility.Description, mshSegmentMessageData.ReceivingFacility.NamespaceID.Value);
                ORUmsg.Add(mshSegmentMessageData.DateTimeOfMessage.Description, mshSegmentMessageData.DateTimeOfMessage.TimeOfAnEvent.ToString());
                ORUmsg.Add(mshSegmentMessageData.Security.Description, mshSegmentMessageData.Security.Value);
                ORUmsg.Add(mshSegmentMessageData.MessageType.Description, mshSegmentMessageData.MessageType.MessageType.Value);
                ORUmsg.Add(mshSegmentMessageData.MessageControlID.Description, mshSegmentMessageData.MessageControlID.Value);
                ORUmsg.Add(mshSegmentMessageData.ProcessingID.Description, mshSegmentMessageData.ProcessingID.ProcessingID.Value);
                ORUmsg.Add(mshSegmentMessageData.VersionID.Description, mshSegmentMessageData.VersionID.Value);
                ORUmsg.Add(mshSegmentMessageData.SequenceNumber.Description, mshSegmentMessageData.SequenceNumber.Value);
                ORUmsg.Add(mshSegmentMessageData.ContinuationPointer.Description, mshSegmentMessageData.ContinuationPointer.Value);
                ORUmsg.Add(mshSegmentMessageData.AcceptAcknowledgementType.Description, mshSegmentMessageData.AcceptAcknowledgementType.Value);
                ORUmsg.Add(mshSegmentMessageData.ApplicationAcknowledgementType.Description, mshSegmentMessageData.ApplicationAcknowledgementType.Value);
                ORUmsg.Add(mshSegmentMessageData.CountryCode.Description, mshSegmentMessageData.CountryCode.Value);
                ORUmsg.Add(mshSegmentMessageData.CharacterSet.Description, mshSegmentMessageData.CharacterSet.Value);
                ORUmsg.Add(mshSegmentMessageData.PrincipalLanguageOfMessage.Description, mshSegmentMessageData.PrincipalLanguageOfMessage.ToString());


                string ORUjson = MyDictionaryToJson(ORUmsg);

                //update message data in MSA segment
                ackResponseMessage.MSA.AcknowledgementCode.Value = "AR";
            }
        }
        private static void LogToDebugConsole(string informationToLog)
        {
            Debug.WriteLine(informationToLog);
        }

        public HL7Test()
        {
            try
            {
                var path = Path.GetDirectoryName(typeof(HL7Test).GetTypeInfo().Assembly.Location) + "/";
                Logger.Info("path: " + path);
                this.HL7_ORM = File.ReadAllText(path + "Sample-ORM.txt");
                this.HL7_ADT = File.ReadAllText(path + "Sample-ADT.txt");
                this.HL7_ORU = File.ReadAllText(path + "Sample-ORU.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception at HL7Test. Message: " + ex.Message);
            }
        }

        [TestMethod]
        public void SmokeTest()
        {
            Message message = new Message(this.HL7_ORM);
            Assert.IsNotNull(message);

            // message.ParseMessage();
            // File.WriteAllText("SmokeTestResult.txt", message.SerializeMessage(false));
        }

        [TestMethod]
        public void ParseTest1()
        {
            var message = new Message(this.HL7_ORM);

            var isParsed = message.ParseMessage();
            Assert.IsTrue(isParsed);
        }

        [TestMethod]
        public void ParseTest2()
        {
            var message = new Message(this.HL7_ADT);

            var isParsed = message.ParseMessage();
            Assert.IsTrue(isParsed);
        }


        [TestMethod]
        public void ReadSegmentTest()
        {
            var message = new Message(this.HL7_ORM);
            message.ParseMessage();

            Segment MSH_1 = message.Segments("MSH")[0];
            Assert.IsNotNull(MSH_1);
        }

        [TestMethod]
        public void ReadDefaultSegmentTest()
        {
            var message = new Message(this.HL7_ADT);
            message.ParseMessage();

            Segment MSH = message.DefaultSegment("MSH");
            Assert.IsNotNull(MSH);
        }

        [TestMethod]
        public void ReadFieldTest()
        {
            var message = new Message(this.HL7_ADT);
            message.ParseMessage();

            var MSH_9 = message.GetValue("MSH.9");
            Assert.AreEqual("ADT^O01", MSH_9);
        }

        [TestMethod]
        public void ReadFieldTestWithOccurrence()
        {
            var message = new Message(this.HL7_ADT);
            message.ParseMessage();

            var NK1_2_2 = message.GetValue("NK1(2).2");
            Assert.AreEqual("DOE^JHON^^^^", NK1_2_2);
        }

        [TestMethod]
        public void ReadComponentTest()
        {
            var message = new Message(this.HL7_ADT);
            message.ParseMessage();

            var MSH_9_1 = message.GetValue("MSH.9.1");
            Assert.AreEqual("ADT", MSH_9_1);
        }

        [TestMethod]
        public void AddComponentsTest()
        {
            var encoding = new HL7Encoding();

            // Create a Segment with name ZIB
            Segment newSeg = new Segment("ZIB", encoding);

            // Create Field ZIB_1
            Field ZIB_1 = new Field("ZIB1", encoding);
            // Create Field ZIB_5
            Field ZIB_5 = new Field("ZIB5", encoding);

            // Create Component ZIB.5.3
            Component com1 = new Component("ZIB.5.3_", encoding);

            // Add Component ZIB.5.3 to Field ZIB_5
            ZIB_5.AddNewComponent(com1, 3);

            // Overwrite the same field again
            ZIB_5.AddNewComponent(new Component("ZIB.5.3", encoding), 3);

            // Add Field ZIB_1 to segment ZIB, this will add a new filed to next field location, in this case first field
            newSeg.AddNewField(ZIB_1);

            // Add Field ZIB_5 to segment ZIB, this will add a new filed as 5th field of segment
            newSeg.AddNewField(ZIB_5, 5);

            // Add segment ZIB to message
            var message = new Message(this.HL7_ADT);
            message.AddNewSegment(newSeg);

            string serializedMessage = message.SerializeMessage(false);
            Assert.AreEqual("ZIB|ZIB1||||ZIB5^^ZIB.5.3\r", serializedMessage);
        }

        [TestMethod]
        public void EmptyFieldsTest()
        {
            var message = new Message(this.HL7_ADT);
            message.ParseMessage();

            var NK1 = message.DefaultSegment("NK1").GetAllFields();
            Assert.AreEqual(34, NK1.Count);
            Assert.AreEqual(string.Empty, NK1[33].Value);
        }

        [TestMethod]
        public void NotEncodingTest()
        {
            var enc = new HL7Encoding().Encode("<1");
            Assert.AreEqual(enc, "<1");
        }

        [TestMethod]
        public void EncodingForOutputTest()
        {
            const string oruUrl = "domain.com/resource.html?Action=1&ID=2";  // Text with special character (&)

            var obx = new Segment("OBX", new HL7Encoding());
            obx.AddNewField("1");
            obx.AddNewField("RP");
            obx.AddNewField("70030^Radiologic Exam, Eye, Detection, FB^CDIRadCodes");
            obx.AddNewField("1");
            obx.AddNewField(obx.Encoding.Encode(oruUrl));  // Encoded field
            obx.AddNewField("F", 11);
            obx.AddNewField(MessageHelper.LongDateWithFractionOfSecond(DateTime.Now), 14);

            var oru = new Message();
            oru.AddNewSegment(obx);

            var str = oru.SerializeMessage(false);

            Assert.IsFalse(str.Contains("&"));  // Should have \T\ instead
        }

        [TestMethod]
        public void AddFieldTest()
        {
            var enc = new HL7Encoding();
            Segment PID = new Segment("PID", enc);
            // Creates a new Field
            PID.AddNewField("1", 1);

            // Overwrites the old Field
            PID.AddNewField("2", 1);

            Message message = new Message();
            message.AddNewSegment(PID);
            var str = message.SerializeMessage(false);

            Assert.AreEqual("PID|2\r", str);
        }

        [TestMethod]
        public void GetMSH1Test()
        {
            var message = new Message(this.HL7_ADT);
            message.ParseMessage();

            var MSH_1 = message.GetValue("MSH.1");
            Assert.AreEqual("|", MSH_1);
        }

        [TestMethod]
        public void GetAckTest()
        {
            var message = new Message(this.HL7_ADT);
            message.ParseMessage();
            var ack = message.GetACK();

            var MSH_3 = message.GetValue("MSH.3");
            var MSH_4 = message.GetValue("MSH.4");
            var MSH_5 = message.GetValue("MSH.5");
            var MSH_6 = message.GetValue("MSH.6");
            var MSH_3_A = ack.GetValue("MSH.3");
            var MSH_4_A = ack.GetValue("MSH.4");
            var MSH_5_A = ack.GetValue("MSH.5");
            var MSH_6_A = ack.GetValue("MSH.6");

            Assert.AreEqual(MSH_3, MSH_5_A);
            Assert.AreEqual(MSH_4, MSH_6_A);
            Assert.AreEqual(MSH_5, MSH_3_A);
            Assert.AreEqual(MSH_6, MSH_4_A);

            var MSH_10 = message.GetValue("MSH.10");
            var MSH_10_A = ack.GetValue("MSH.10");
            var MSA_1_1 = ack.GetValue("MSA.1");
            var MSA_1_2 = ack.GetValue("MSA.2");

            Assert.AreEqual(MSA_1_1, "AA");
            Assert.AreEqual(MSH_10, MSH_10_A);
            Assert.AreEqual(MSH_10, MSA_1_2);
        }

        [TestMethod]
        public void AddSegmentMSHTest()
        {
            var message = new Message();
            message.AddSegmentMSH("test", "sendingFacility", "test", "test", "test", "ADR^A19", "test", "D", "2.5");
        }

        [TestMethod]
        public void GetNackTest()
        {
            var message = new Message(this.HL7_ADT);
            message.ParseMessage();

            var error = "Error message";
            var code = "AR";
            var ack = message.GetNACK(code, error);

            var MSH_3 = message.GetValue("MSH.3");
            var MSH_4 = message.GetValue("MSH.4");
            var MSH_5 = message.GetValue("MSH.5");
            var MSH_6 = message.GetValue("MSH.6");
            var MSH_3_A = ack.GetValue("MSH.3");
            var MSH_4_A = ack.GetValue("MSH.4");
            var MSH_5_A = ack.GetValue("MSH.5");
            var MSH_6_A = ack.GetValue("MSH.6");

            Assert.AreEqual(MSH_3, MSH_5_A);
            Assert.AreEqual(MSH_4, MSH_6_A);
            Assert.AreEqual(MSH_5, MSH_3_A);
            Assert.AreEqual(MSH_6, MSH_4_A);

            var MSH_10 = message.GetValue("MSH.10");
            var MSH_10_A = ack.GetValue("MSH.10");
            var MSA_1_1 = ack.GetValue("MSA.1");
            var MSA_1_2 = ack.GetValue("MSA.2");
            var MSA_1_3 = ack.GetValue("MSA.3");

            Assert.AreEqual(MSH_10, MSH_10_A);
            Assert.AreEqual(MSH_10, MSA_1_2);
            Assert.AreEqual(MSA_1_1, code);
            Assert.AreEqual(MSA_1_3, error);
        }

        [TestMethod]
        public void EmptyAndNullFieldsTest()
        {
            const string sampleMessage = "MSH|^~\\&|SA|SF|RA|RF|20110613083617||ADT^A04|123|P|2.7||||\r\nEVN|A04|20110613083617||\"\"\r\n";

            var message = new Message(sampleMessage);
            var isParsed = message.ParseMessage();
            Assert.IsTrue(isParsed);
            Assert.IsTrue(message.SegmentCount > 0);
            var evn = message.Segments("EVN")[0];
            var expectEmpty = evn.Fields(3).Value;
            Assert.AreEqual(string.Empty, expectEmpty);
            var expectNull = evn.Fields(4).Value;
            Assert.AreEqual(null, expectNull);
        }

        [TestMethod]
        public void MessageWithDoubleNewlineTest()
        {
            const string sampleMessage = "MSH|^~\\&|SA|SF|RA|RF|20110613083617||ADT^A04|123|P|2.7||||\n\nEVN|A04|20110613083617||\r\n";

            var message = new Message(sampleMessage);
            var isParsed = message.ParseMessage();
            Assert.IsTrue(isParsed);
            Assert.IsTrue(message.SegmentCount > 0);
        }

        [TestMethod]
        public void MessageWithDoubleCarriageReturnTest()
        {
            const string sampleMessage = "MSH|^~\\&|SA|SF|RA|RF|20110613083617||ADT^A04|123|P|2.7||||\n\nEVN|A04|20110613083617||\r\n";

            var message = new Message(sampleMessage);
            var isParsed = message.ParseMessage();
            Assert.IsTrue(isParsed);
            Assert.IsTrue(message.SegmentCount > 0);
        }

        [TestMethod]
        public void MessageWithNullsIsReversable()
        {
            const string sampleMessage = "MSH|^~\\&|SA|SF|RA|RF|20110613083617||ADT^A04|123|P|2.7||||\r\nEVN|A04|20110613083617||\"\"\r\n";
            var message = new Message(sampleMessage);
            message.ParseMessage();
            var serialized = message.SerializeMessage(false);
            Assert.AreEqual(sampleMessage, serialized);
        }

        [TestMethod]
        public void PresentButNull()
        {
            const string sampleMessage = "MSH|^~\\&|SA|SF|RA|RF|20110613083617||ADT^A04|123|P|2.7||||\r\nEVN|A04|20110613083617||\"\"\r\n";

            var message = new Message(sampleMessage);
            message.Encoding.PresentButNull = null;
            message.ParseMessage();

            var evn = message.Segments("EVN")[0];
            var expectDoubleQuotes = evn.Fields(4).Value;
            Assert.AreEqual("\"\"", expectDoubleQuotes);
        }

        [TestMethod]
        public void MessageWithSegmentNameOnly()
        {
            const string sampleMessage = "MSH|^~\\&|SA|SF|RA|RF|20110613083617||ADT^A04|123|P|2.7||||\r\nPID\r\nEVN|A04|20110613083617||\"\"\r\n";
            var message = new Message(sampleMessage);
            message.ParseMessage();
            var serialized = message.SerializeMessage(false);
            Assert.AreEqual(sampleMessage, serialized);
        }

        [TestMethod]
        public void MessageWithTabsIsReversable()
        {
            const string sampleMessage = "MSH|^~\\&|Sending\tApplication|Sending\tFacility|RA|RF|20110613083617||ADT^A04|123|P|2.7||||\r\nEVN|A04|20110613083617\r\n";
            var message = new Message(sampleMessage);
            message.ParseMessage();
            var serialized = message.SerializeMessage(false);
            Assert.AreEqual(sampleMessage, serialized);
        }

        [TestMethod]
        public void RemoveSegment()
        {
            var message = new Message(this.HL7_ADT);
            message.ParseMessage();
            Assert.AreEqual(message.Segments("NK1").Count, 2);
            Assert.AreEqual(message.SegmentCount, 5);

            message.RemoveSegment("NK1", 1);
            Assert.AreEqual(message.Segments("NK1").Count, 1);
            Assert.AreEqual(message.SegmentCount, 4);

            message.RemoveSegment("NK1");
            Assert.AreEqual(message.Segments("NK1").Count, 0);
            Assert.AreEqual(message.SegmentCount, 3);
        }

        [DataTestMethod]
        [DataRow("   20151231234500.1234+2358   ")]
        [DataRow("20151231234500.1234+2358")]
        [DataRow("20151231234500.1234-2358")]
        [DataRow("20151231234500.1234")]
        [DataRow("20151231234500.12")]
        [DataRow("20151231234500")]
        [DataRow("201512312345")]
        [DataRow("2015123123")]
        [DataRow("20151231")]
        [DataRow("201512")]
        [DataRow("2015")]
        public void ParseDateTime_Smoke_Positive(string dateTimeString)
        {
            var date = MessageHelper.ParseDateTime(dateTimeString);
            Assert.IsNotNull(date);
        }

        [DataTestMethod]
        [DataRow("   20151231234500.1234+23581")]
        [DataRow("20151231234500.1234+23")]
        [DataRow("20151231234500.12345")]
        [DataRow("20151231234500.")]
        [DataRow("2015123123450")]
        [DataRow("20151231234")]
        [DataRow("201512312")]
        [DataRow("2015123")]
        [DataRow("20151")]
        [DataRow("201")]
        public void ParseDateTime_Smoke_Negative(string dateTimeString)
        {
            var date = MessageHelper.ParseDateTime(dateTimeString);
            Assert.IsNull(date);
        }

        [TestMethod]
        public void ParseDateTime_Correctness()
        {
            TimeSpan offset;
            var date = MessageHelper.ParseDateTime("20151231234500.1234-2358", out offset).Value;
            // Assert.AreEqual(0, d
            Assert.AreEqual(date, new DateTime(2015, 12, 31, 23, 45, 00, 123));
            Assert.AreEqual(offset, new TimeSpan(-23, 58, 0));
        }

        [TestMethod]
        public void ParseDateTime_WithException()
        {
            try
            {
                var date = MessageHelper.ParseDateTime("201", true);
                Assert.Fail();
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void ParseDateTimeOffset_WithException()
        {
            try
            {
                var date = MessageHelper.ParseDateTime("201", out TimeSpan offset, true);
                Assert.Fail();
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch
            {
            }
        }

        [TestMethod]
        public void GetValueTest()
        {
            var sampleMessage =
                @"MSH|^~\&|EPIC||||20191107134803|ALEVIB01|ORM^O01|23|T|2.3|||||||||||
PID|1||MRN_123^^^IDX^MRN||Smith\F\\S\\R\\E\\T\^John||19600101|M";

            var message = new Message(sampleMessage);
            message.ParseMessage();

            string attendingDrId = message.GetValue("PID.5.1");
            Assert.AreEqual(@"Smith|^~\&", attendingDrId);
        }

        [TestMethod]
        public void SkipInvalidEscapeSequenceTest()
        {
            var sampleMessage =
                @"MSH|^~\&|TEST^TEST|TEST|||11111||ADT^A08|11111|P|2.4|||AL||D||||||
ZZ1|1|139378|20201230100000|ghg^ghgh-HA||s1^OP-Saal 1|gh^gjhg 1|ghg^ghjg-HA|BSV 4\5 re.||||||";

            var message = new Message(sampleMessage);
            message.ParseMessage();

            string serializedMessage = message.SerializeMessage(false);
        }

        [TestMethod]
        public void CustomDelimiterTest()
        {
            var encoding = new HL7Encoding
            {
                FieldDelimiter = '1',
                ComponentDelimiter = '2',
                SubComponentDelimiter = '3',
                RepeatDelimiter = '4',
                EscapeCharacter = '5'
            };

            var message = new Message();
            message.Encoding = encoding;
            message.AddSegmentMSH("FIRST", "SECOND", "THIRD", "FOURTH",
                "FIFTH", "ORU2R05F5", "SIXTH", "SEVENTH", "2.8");
            var result = message.SerializeMessage(false);

            Assert.AreEqual("MSH124531", result.Substring(0, 9));
        }

        [DataTestMethod]
        [DataRow("PV1.7.1", "1447312459")]
        [DataRow("PV1.7(1).1", "1447312459")]
        [DataRow("PV1.7[1].1", "1447312459")]
        [DataRow("PV1.7(2).1", "DOEM06")]
        [DataRow("PV1.7[2].1", "DOEM06")]
        [DataRow("PV1.7[2].3", "MICHAEL")]
        public void RepetitionTest(string index, string expected)
        {
            var sampleMessage =
                @"MSH|^~\&|EPIC||||20191107134803|ALEVIB01|ORM^O01|23|T|2.3|||||||||||
PID|1||1005555^^^NYU MRN^MRN||OSTRICH^DODUO||19820605|M||U|000 PARK AVE SOUTH^^NEW YORK^NY^10010^US^^^60|60|(555)555-5555^HOME^PH|||S|||999-99-9999|||U||N||||||||
PV1||O|NWSLED^^^NYULHLI^^^^^LI NW SLEEP DISORDER^^DEPID||||1447312459^DOE^MICHAEL^^^^^^EPIC^^^^PNPI~DOEM06^DOE^MICHAEL^^^^^^KID^^^^KID|1447312459^DOE^MICHAEL^^^^^^EPIC^^^^PNPI~DOEM06^DOE^MICHAEL^^^^^^KID^^^^KID|||||||||||496779945|||||||||||||||||||||||||20191107|||||||V";

            var message = new Message(sampleMessage);
            message.ParseMessage();

            string attendingDrId = message.GetValue(index);
            Assert.AreEqual(expected, attendingDrId);
        }

        [TestMethod]
        public void RepetitionTest1()
        {
            var sampleMessage =
                @"MSH|^~\&|IA PHIMS Stage^2.16.840.1.114222.4.3.3.5.1.2^ISO|IA Public Health Lab^2.16.840.1.114222.4.1.10411^ISO|IA.DOH.IDSS^2.16.840.1.114222.4.3.3.19^ISO|IADOH^2.16.840.1.114222.4.1.3650^ISO|201203312359||ORU^R01^ORU_R01|2.16.840.1.114222.4.3.3.5.1.2-20120314235954.325|T|2.5.1|||AL|NE|USA||||PHLabReport-Ack^^2.16.840.1.113883.9.10^ISO
PID|1||14^^^IA PHIMS Stage&2.16.840.1.114222.4.3.3.5.1.2&ISO^PI^IA Public Health Lab&2.16.840.1.114222.4.1.10411&ISO~145^^^IA PHIMS Stage&2.16.840.1.114222.4.3.3.5.1.2&ISO^PI^IA Public Health Lab&2.16.840.1.114222.4.1.10411&ISO||Finn^Huckleberry^^^^^L||19630815|M||2106-3^White^CDCREC^^^^04/24/2007~1002-5^American Indian or Alaska Native^CDCREC^^^^04/24/2007|721SPRING STREET^^GRINNELL^IA^50112^USA^H|||||M^Married^HL70002^^^^2.5.1||||||H^Hispanic orLatino^HL70189^^^^2.5.1";

            var message = new Message(sampleMessage);
            message.ParseMessage();

            Assert.IsTrue(message.HasRepetitions("PID.3"));
            Assert.IsTrue(message.Segments("PID")[0].Fields(3).HasRepetitions);
        }

        [TestMethod]
        public void InvalidRepetitionTest()
        {
            var sampleMessage =
                @"MSH|^~\&|SYSTEM1|ABC|SYSTEM2||201803262027||DFT^P03|20180326202737608457|P|2.3||||||8859/1
EVN|P03|20180326202540
PID|1|0002381795|0002381795||Supermann^Peter^^^Herr||19990101|M|||Hamburgerstrasse 123^^Mimamu^BL^12345^CH||123456~123456^^CP||D|2|02|321|8.2.24.||| 
PV1||A|00004620^00001318^1318||||000123456^Superfrau^Maria W.^|^Superarzt^Anton^L|00097012345^Superarzt^Herbert^~~0009723456^Superarzt^Markus^||||||||000998765^Assistent A^ONKO^D||0087123456||||||||||||||||||||2140||O|||201905220600|201908201100|||||";

            var message = new Message(sampleMessage);
            message.ParseMessage();

            // Check for invalid repetition number
            try
            {
                var value = message.GetValue("PV1.8(2).1");
                Assert.IsNull(value);
                value = message.GetValue("PV1.8(3).1");
                Assert.IsNull(value);

                Assert.Fail("Unexpected non-exception");
            }
            catch
            {
                // Pass
            }
        }

        [TestMethod]
        public void RemoveTrailingComponentsTest_OnlyTrailingComponentsRemoved()
        {
            var message = new Message();

            var orcSegment = new Segment("ORC", new HL7Encoding());
            for (int eachField = 1; eachField <= 12; eachField++)
            {
                orcSegment.AddEmptyField();
            }

            for (int eachComponent = 1; eachComponent < 8; eachComponent++)
            {
                orcSegment.Fields(12).AddNewComponent(new Component(new HL7Encoding()));
            }

            orcSegment.Fields(12).Components(1).Value = "should not be removed";
            orcSegment.Fields(12).Components(2).Value = "should not be removed";
            orcSegment.Fields(12).Components(3).Value = "should not be removed";
            orcSegment.Fields(12).Components(4).Value = string.Empty; // should not be removed because in between valid values
            orcSegment.Fields(12).Components(5).Value = "should not be removed";
            orcSegment.Fields(12).Components(6).Value = string.Empty; // should be removed because trailing
            orcSegment.Fields(12).Components(7).Value = string.Empty; // should be removed because trailing
            orcSegment.Fields(12).Components(8).Value = string.Empty; // should be removed because trailing

            orcSegment.Fields(12).RemoveEmptyTrailingComponents();
            message.AddNewSegment(orcSegment);

            string serializedMessage = message.SerializeMessage(false);
            Assert.AreEqual(orcSegment.Fields(12).Components().Count, 5);
            Assert.AreEqual("ORC||||||||||||should not be removed^should not be removed^should not be removed^^should not be removed\r", serializedMessage);
        }

        [TestMethod]
        public void RemoveTrailingComponentsTest_RemoveAllFieldComponentsIfEmpty()
        {
            var message = new Message();

            var orcSegment = new Segment("ORC", new HL7Encoding());
            for (int eachField = 1; eachField <= 12; eachField++)
            {
                orcSegment.AddEmptyField();
            }

            for (int eachComponent = 1; eachComponent < 8; eachComponent++)
            {
                orcSegment.Fields(12).AddNewComponent(new Component(new HL7Encoding()));
                orcSegment.Fields(12).Components(eachComponent).Value = string.Empty;
            }

            orcSegment.Fields(12).RemoveEmptyTrailingComponents();
            message.AddNewSegment(orcSegment);

            string serializedMessage = message.SerializeMessage(false);
            Assert.AreEqual(orcSegment.Fields(12).Components().Count, 0);
            Assert.AreEqual("ORC||||||||||||\r", serializedMessage);
        }


        [TestMethod]
        public void AddRepeatingField()
        {
            var enc = new HL7Encoding();
            Segment PID = new Segment("PID", enc);
            Field f = new Field(enc);
            Field f1 = new Field("A", enc);
            Field f2 = new Field("B", enc);

            f.HasRepetitions = true;
            f.AddRepeatingField(f1);
            f.AddRepeatingField(f2);

            // Creates a new Field
            PID.AddNewField(f, 1);

            Message message = new Message();
            message.AddNewSegment(PID);
            var str = message.SerializeMessage(false);

            Assert.AreEqual("PID|A~B\r", str);
        }

        [TestMethod]
        public void BypassValidationParseMessage()
        {
            string sampleMessage = @"MSH|^~\&|SCA|SCA|LIS|LIS|202107300000||ORU^R01||P|2.4|||||||
PID|1|1234|1234||JOHN^DOE||19000101||||||||||||||
OBR|1|1234|1234||||20210708|||||||||||||||20210708||||||||||
OBX|1|TX|SCADOCTOR||^||||||F";

            try
            {
                var msg = new Message(sampleMessage);
                msg.ParseMessage(true);

                Assert.IsNull(msg.MessageControlID, "MessageControlID should be null");

                //just to make sure we have actually parsed the invalid MSH
                string messageType = msg.GetValue("MSH.9");
                Assert.AreEqual("ORU^R01", messageType, "Unexpected Message Type");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception", ex);
            }
        }

        [TestMethod]
        public void BypassValidationGetACK()
        {
            string sampleMessage = @"MSH|^~\&|SCA|SCA|LIS|LIS|202107300000||ORU^R01||P|2.4|||||||
PID|1|1234|1234||JOHN^DOE||19000101||||||||||||||
OBR|1|1234|1234||||20210708|||||||||||||||20210708||||||||||
OBX|1|TX|SCADOCTOR||^||||||F";

            try
            {
                var msg = new Message(sampleMessage);
                msg.ParseMessage(true);

                var ack = msg.GetACK(true);
                string sendingApp = ack.GetValue("MSH.3");
                string sendingFacility = ack.GetValue("MSH.4");
                string receivingApp = ack.GetValue("MSH.5");
                string receivingFacility = ack.GetValue("MSH.6");
                string messageType = ack.GetValue("MSH.9");

                Assert.IsNull(ack.MessageControlID, "MessageControlID should be null");
                Assert.AreEqual("LIS", sendingApp, "Unexpected Sending Application");
                Assert.AreEqual("LIS", sendingApp, "Unexpected Sending Facility");
                Assert.AreEqual("SCA", receivingApp, "Unexpected Receiving Application");
                Assert.AreEqual("SCA", receivingFacility, "Unexpected Receiving Facility");
                Assert.AreEqual("ACK", messageType, "Unexpected Message Type");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception", ex);
            }
        }

        [TestMethod]
        public void BypassValidationGetNACK()
        {
            string sampleMessage = @"MSH|^~\&|SCA|SCA|LIS|LIS|202107300000||ORU^R01||P|2.4|||||||
PID|1|1234|1234||JOHN^DOE||19000101||||||||||||||
OBR|1|1234|1234||||20210708|||||||||||||||20210708||||||||||
OBX|1|TX|SCADOCTOR||^||||||F";

            try
            {
                var msg = new Message(sampleMessage);
                msg.ParseMessage(true);

                var nack = msg.GetNACK("AE", "Unit test", true);
                string sendingApp = nack.GetValue("MSH.3");
                string sendingFacility = nack.GetValue("MSH.4");
                string receivingApp = nack.GetValue("MSH.5");
                string receivingFacility = nack.GetValue("MSH.6");
                string messageType = nack.GetValue("MSH.9");
                string code = nack.GetValue("MSA.1");
                string errorMessage = nack.GetValue("MSA.3");

                Assert.IsNull(nack.MessageControlID, "MessageControlID should be null");
                Assert.AreEqual("LIS", sendingApp, "Unexpected Sending Application");
                Assert.AreEqual("LIS", sendingApp, "Unexpected Sending Facility");
                Assert.AreEqual("SCA", receivingApp, "Unexpected Receiving Application");
                Assert.AreEqual("SCA", receivingFacility, "Unexpected Receiving Facility");
                Assert.AreEqual("ACK", messageType, "Unexpected Message Type");

                Assert.AreEqual("AE", code, "Unexpected Error Code");
                Assert.AreEqual("Unit test", errorMessage, "Unexpected Error Message");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception", ex);
            }
        }

        [TestMethod]
        public void SetValueSingleSegment()
        {
            var strValueFormat = "PID.2.1";
            var unchangedValuePath = "PID.3.1";
            var newPatientId = "1234567";
            var message = new Message(HL7_ADT);
            message.ParseMessage();

            message.SetValue(strValueFormat, newPatientId);

            Assert.AreEqual(newPatientId, message.GetValue(strValueFormat));
            Assert.AreEqual("454721", message.GetValue(unchangedValuePath));
        }

        [TestMethod]
        public void SetValueRepeatingSegments()
        {
            var strValueFormat = "NK1.2.1";
            var unchangedValuePath = "NK1.2.2";
            var newFamilyName = "SCHMOE";
            var message = new Message(HL7_ADT);
            message.ParseMessage();

            message.SetValue(strValueFormat, newFamilyName);

            var firstNK1ChangedValue = message.GetValue(strValueFormat);
            var firstNK1UnchangedValue = message.GetValue(unchangedValuePath);
            Assert.IsTrue(message.RemoveSegment("NK1", 0));
            var secondNk1ChangedValue = message.GetValue(strValueFormat);
            var secondNk1UnchangedValue = message.GetValue(unchangedValuePath);

            Assert.AreEqual(newFamilyName, firstNK1ChangedValue);
            Assert.AreEqual(newFamilyName, secondNk1ChangedValue);
            Assert.AreEqual("MARIE", firstNK1UnchangedValue);
            Assert.AreEqual("JHON", secondNk1UnchangedValue);
        }

        [TestMethod]
        public void SetValueUnavailableComponents()
        {
            var sampleMessage = @"MSH|^~\&|SYSTEM1|ABC|SYSTEM2||201803262027||DFT^P03|20180326202737608457|P|2.3|||"
                                    + "\nPID|1|0002381795|0002381795||Supermann^Peter^^^Herr||19990101|M|||";
            var testValue = "test";
            var message = new Message(sampleMessage);
            message.ParseMessage();

            var invalidRequest = Assert.ThrowsException<HL7Exception>(() => message.SetValue(string.Empty, testValue));
            Assert.IsTrue(invalidRequest.Message.Contains("Request format"), "Should have thrown exception because of invalid request format");

            var unavailableSegment = Assert.ThrowsException<HL7Exception>(() => message.SetValue("OBX.1", testValue));
            Assert.IsTrue(unavailableSegment.Message.Contains("Segment name"), "Should have thrown exception because of unavailable Segment");

            var segmentLevel = Assert.ThrowsException<HL7Exception>(() => message.SetValue("PID.30", testValue));
            Assert.IsTrue(segmentLevel.Message.Contains("Field not available"), "Should have thrown exception because of unavailable Field");

            var componentLevel = Assert.ThrowsException<HL7Exception>(() => message.SetValue("PID.3.7", testValue));
            Assert.IsTrue(componentLevel.Message.Contains("Component not available"), "Should have thrown exception because of unavailable Component");

            var subComponentLevel = Assert.ThrowsException<HL7Exception>(() => message.SetValue("PID.3.1.2", testValue));
            Assert.IsTrue(subComponentLevel.Message.Contains("SubComponent not available"), "Should have thrown exception because of unavailable SubComponent");
        }

        [TestMethod]
        public void SetValueAvailableComponents()
        {
            var testValue = "test";
            var message = new Message(HL7_ADT);
            message.ParseMessage();

            Assert.IsTrue(message.SetValue("PID.1", testValue), "Should have successfully set value of Field");
            Assert.AreEqual(testValue, message.GetValue("PID.1"));

            Assert.IsTrue(message.SetValue("PID.2.2", testValue), "Should have successfully set value of Component");
            Assert.AreEqual(testValue, message.GetValue("PID.2.2"));

            Assert.IsTrue(message.SetValue("PID.2.4.1", testValue), "Should have successfully set value of SubComponent");
            Assert.AreEqual(testValue, message.GetValue("PID.2.4.1"));
        }

        [TestMethod]
        public void DecodedValue()
        {
            try
            {
                var msg = "MSH|^~\\&|SAP|aaa|JCAPS||20210330150502||ADT^A28|0000000111300053|P|2.5||||||UNICODE UTF-8\r\nPID|||704251200^^^SAP^PI^0001~XXXXXXX^^^SS^SS^066^20210330~\"\"^^^^PRC~\"\"^^^^DL~\"\"^^^^PPN~XXXXXXXX^^^Ministero finanze^NN~\"\"^^^^PNT^^^\"\"~\"\"^^^^NPI^^\"\"^^\"\"&&\"\"^\"\"&\"\"||TEST\\F\\TEST^TEST2^^^SIG.^\"\"||19610926|M|||^^SANTEUSANIO FORCONESE^^^IT^BDL^^066090~&VIA DELLA PIEGA 12 TRALLaae^\"\"^SANTEUSANIO FORCONESE^AQ^67020^IT^L^^066090^^^^20210330||^ORN^^^^^^^^^^349 6927621~^NET^^\"\"|||2||||||||||IT^^100^Italiana|||\"\"||||20160408\r\n";

                var message = new Message(msg);
                message.ParseMessage();

                List<Segment> segList = message.Segments();
                var field = message.Segments("MSH")[0].Fields(5).Value;
                var component = message.Segments("PID")[0].Fields(5).Components(1).Value;
                var subcomponent = message.Segments("PID")[0].Fields(5).Components(1).SubComponents(1).Value;


            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
        }


        public void HL7ToJson()
        {
            try
            {
                string HL7_ORU = File.ReadAllText("D:\\DMS_WORKSPACE\\HL7ReportingService\\HL7Decoder\\test\\" + "ORU.txt");
                var message2 = new Message(HL7_ORU);
                message2.ParseMessage();
                var msgORU = new Message(HL7_ORU);


                List<Segment> MSHList = message2.Segments("MSH");
                List<Segment> PIDList = message2.Segments("PID");
                List<Segment> PV1List = message2.Segments("PV1");
                List<Segment> ORCList = message2.Segments("ORC");
                List<Segment> OBRList = message2.Segments("OBR");
                List<Segment> OBXList = message2.Segments("OBX");
                Logger.Info("MSHList.count= " + MSHList.Count + ", PIDList.Count= " + PIDList.Count
                    + ", PV1List.Count= " + PV1List.Count + ", ORCList.Count= " + ORCList.Count
                    + ", OBRList.Count= " + OBRList.Count + ", OBXList.Count= " + OBXList.Count);
                var MSHFieldCount = MSHList[0].GetAllFields();
                var PIDFieldCount = PIDList[0].GetAllFields();
                var PV1FieldCount = PV1List[0].GetAllFields();
                var ORCFieldCount = ORCList[0].GetAllFields();
                var OBRFieldCount = OBRList[0].GetAllFields();
                var OBXFieldCount = OBXList[0].GetAllFields();

                Logger.Info("MSHFieldCount= " + MSHFieldCount + ", PIDFieldCount= " + PIDFieldCount
                   + ", PV1FieldCount= " + PV1FieldCount + ", ORCFieldCount= " + ORCFieldCount
                   + ", OBRFieldCount= " + OBRFieldCount + ", OBXFieldCount= " + OBXFieldCount);
                int msh = int.Parse(MSHFieldCount.Count().ToString());

                //#region MSH
                //Dictionary<string, string> MSHmsg = new Dictionary<string, string>();
                //for (int i = 0; i < int.Parse(MSHFieldCount.Count().ToString()); i++)
                //{
                //    MSHmsg.Add("key" + (i + 1), message2.GetValue("MSH." + (i + 1)));
                //}
                //string MSHjson = MyDictionaryToJson(MSHmsg);
                //#endregion MSH


                //#region PID
                //Dictionary<string, string> PIDmsg = new Dictionary<string, string>();
                //for (int i = 0; i < int.Parse(PIDFieldCount.Count().ToString()); i++)
                //{
                //    PIDmsg.Add("key" + (i + 1), message2.GetValue("PID." + (i + 1)));
                //}
                //string PIDjson = MyDictionaryToJson(PIDmsg);
                //#endregion PID


                //#region PV1
                //Dictionary<string, string> PV1msg = new Dictionary<string, string>();
                //for (int i = 0; i < int.Parse(PV1FieldCount.Count().ToString()); i++)
                //{
                //    PV1msg.Add("key" + (i + 1), message2.GetValue("PV1." + (i + 1)));
                //}
                //string PV1json = MyDictionaryToJson(PV1msg);
                //#endregion PV1


                //#region ORC
                //Dictionary<string, string> ORCmsg = new Dictionary<string, string>();
                //for (int i = 0; i < int.Parse(ORCFieldCount.Count().ToString()); i++)
                //{
                //    ORCmsg.Add("key" + (i + 1), message2.GetValue("ORC." + (i + 1)));
                //}
                //string ORCjson = MyDictionaryToJson(ORCmsg);
                //#endregion ORC


                //#region OBR
                //Dictionary<string, string> OBRmsg = new Dictionary<string, string>();
                //for (int i = 0; i < int.Parse(OBRFieldCount.Count().ToString()); i++)
                //{
                //    OBRmsg.Add("key" + (i + 1), message2.GetValue("OBR." + (i + 1)));
                //}
                //string OBRjson = MyDictionaryToJson(OBRmsg);
                //#endregion OBR


                //#region OBX
                //Dictionary<string, string> OBXmsg = new Dictionary<string, string>();
                //for (int i = 0; i < int.Parse(OBXFieldCount.Count().ToString()); i++)
                //{
                //    OBXmsg.Add("key" + (i + 1), message2.GetValue("OBX." + (i + 1)));
                //}
                //string OBXjson = MyDictionaryToJson(OBXmsg);
                //#endregion OBX
                var MSH = message2.DefaultSegment("MSH").GetAllFields();

                var a = MSH[10].UndecodedValue;

                Dictionary<string, string> ORUmsg = new Dictionary<string, string>();

                ORUmsg.Add("Sending Application", message2.GetValue("MSH.3"));
                ORUmsg.Add("Sending Facility", message2.GetValue("MSH.4"));
                ORUmsg.Add("Receiving Application", message2.GetValue("MSH.5"));
                ORUmsg.Add("Receiving Facility", message2.GetValue("MSH.6"));
                ORUmsg.Add("DateTime of Message", message2.GetValue("MSH.7"));
                ORUmsg.Add("Security", message2.GetValue("MSH.8"));
                ORUmsg.Add("Message Type", message2.GetValue("MSH.9"));
                ORUmsg.Add("Message Control ID", message2.GetValue("MSH.10"));
                ORUmsg.Add("Processing ID", message2.GetValue("MSH.11"));
                ORUmsg.Add("Version ID", message2.GetValue("MSH.12"));
                ORUmsg.Add("Sequence Number", message2.GetValue("MSH.13"));



                ORUmsg.Add("Patient ID", message2.GetValue("PID.1"));
                ORUmsg.Add("Patient ID(External ID)", message2.GetValue("PID.2"));
                ORUmsg.Add("Patient ID(Internal ID)", message2.GetValue("PID.3"));
                ORUmsg.Add("Alternate Patient ID", message2.GetValue("PID.4"));
                ORUmsg.Add("Patient Name", message2.GetValue("PID.5"));
                ORUmsg.Add("Mother's Maiden Name", message2.GetValue("PID.6"));

                ORUmsg.Add("Date of Birth", message2.GetValue("PID.7"));
                ORUmsg.Add("Sex", message2.GetValue("PID.8"));
                ORUmsg.Add("Patient Alias", message2.GetValue("PID.9"));
                ORUmsg.Add("Race", message2.GetValue("PID.10"));
                ORUmsg.Add("Pateint Address", message2.GetValue("PID.11"));
                ORUmsg.Add("County Code", message2.GetValue("PID.12"));

                ORUmsg.Add("Phone Number - Home", message2.GetValue("PID.13"));
                ORUmsg.Add("Phone Number - Business", message2.GetValue("PID.14"));
                ORUmsg.Add("Primary Language", message2.GetValue("PID.15"));
                ORUmsg.Add("Merital Status", message2.GetValue("PID.16"));
                ORUmsg.Add("Religion", message2.GetValue("PID.17"));
                ORUmsg.Add("Patient Account Number", message2.GetValue("PID.18"));


                ORUmsg.Add("Set ID - Patient Visit", message2.GetValue("PV1.1"));
                ORUmsg.Add("Patient Class", message2.GetValue("PV1.2"));
                ORUmsg.Add("Assigned Patient Location", message2.GetValue("PV1.3"));
                ORUmsg.Add("Admission Type", message2.GetValue("PV1.4"));
                ORUmsg.Add("Preadmit Number", message2.GetValue("PV1.5"));
                ORUmsg.Add("Prior Patient Location", message2.GetValue("PV1.6"));
                ORUmsg.Add("Attending Doctor", message2.GetValue("PV1.7"));
                ORUmsg.Add("Referring Doctor", message2.GetValue("PV1.8"));
                ORUmsg.Add("Consulting Doctor", message2.GetValue("PV1.9"));
                ORUmsg.Add("Hospital Service", message2.GetValue("PV1.10"));

                ORUmsg.Add("Temporary Location", message2.GetValue("PV1.11"));
                ORUmsg.Add("Preadmit Test Indicator", message2.GetValue("PV1.12"));
                ORUmsg.Add("Readmission Indicator", message2.GetValue("PV1.13"));
                ORUmsg.Add("Admit Source", message2.GetValue("PV1.14"));
                ORUmsg.Add("Ambulatory Status", message2.GetValue("PV1.15"));
                ORUmsg.Add("VIP Indicator", message2.GetValue("PV1.16"));
                ORUmsg.Add("Admitting Doctor", message2.GetValue("PV1.17"));
                ORUmsg.Add("Patient Type", message2.GetValue("PV1.18"));
                ORUmsg.Add("Visit Number", message2.GetValue("PV1.19"));
                ORUmsg.Add("Financial Class", message2.GetValue("PV1.20"));

                ORUmsg.Add("Charge Price Indicator", message2.GetValue("PV1.21"));
                ORUmsg.Add("Courtesy Code", message2.GetValue("PV1.22"));
                ORUmsg.Add("Credit Rating", message2.GetValue("PV1.23"));
                ORUmsg.Add("Contract Code", message2.GetValue("PV1.24"));
                ORUmsg.Add("Contract Effective Date", message2.GetValue("PV1.25"));
                ORUmsg.Add("Contract Amount", message2.GetValue("PV1.26"));
                ORUmsg.Add("Contract Period", message2.GetValue("PV1.27"));
                ORUmsg.Add("Interest Code", message2.GetValue("PV1.28"));
                ORUmsg.Add("Transfer to Bad Debt Code", message2.GetValue("PV1.29"));
                ORUmsg.Add("Transfer to Bad Debt Date", message2.GetValue("PV1.30"));

                ORUmsg.Add("Bad Debt Agency Code", message2.GetValue("PV1.31"));
                ORUmsg.Add("Bad Debt Transfer Amount", message2.GetValue("PV1.32"));
                ORUmsg.Add("Bad Debt Recovery Amount", message2.GetValue("PV1.33"));
                ORUmsg.Add("Delete Account Indicator", message2.GetValue("PV1.34"));
                ORUmsg.Add("Delete Account Date", message2.GetValue("PV1.35"));
                ORUmsg.Add("Discharge Disposition", message2.GetValue("PV1.36"));
                ORUmsg.Add("Discharged Location", message2.GetValue("PV1.37"));
                ORUmsg.Add("Diet Type", message2.GetValue("PV1.38"));
                ORUmsg.Add("Servicing Facility", message2.GetValue("PV1.39"));
                ORUmsg.Add("Bed Status", message2.GetValue("PV1.40"));

                ORUmsg.Add("Account Status", message2.GetValue("PV1.41"));
                ORUmsg.Add("Pending Location", message2.GetValue("PV1.42"));
                ORUmsg.Add("Prior Temporary Location", message2.GetValue("PV1.43"));
                ORUmsg.Add("Admit DateTime", message2.GetValue("PV1.44"));
                ORUmsg.Add("Discharge DateTime", message2.GetValue("PV1.45"));
                ORUmsg.Add("Current Patient Balance", message2.GetValue("PV1.46"));


                ORUmsg.Add("Order Control", message2.GetValue("ORC.1"));
                ORUmsg.Add("Placer Order Number", message2.GetValue("ORC.2"));
                ORUmsg.Add("Filler Order Number", message2.GetValue("ORC.3"));
                ORUmsg.Add("Placer Group Number", message2.GetValue("ORC.4"));
                ORUmsg.Add("Order Status", message2.GetValue("ORC.5"));
                ORUmsg.Add("Response Flag", message2.GetValue("ORC.6"));
                ORUmsg.Add("QuantityTiming", message2.GetValue("ORC.7"));
                ORUmsg.Add("Parent", message2.GetValue("ORC.8"));
                ORUmsg.Add("DateTime of Transaction", message2.GetValue("ORC.9"));
                ORUmsg.Add("Entered By", message2.GetValue("ORC.10"));


                ORUmsg.Add("Set ID Observation Request", message2.GetValue("OBR.1"));
                ORUmsg.Add("Placer Order Number2", message2.GetValue("OBR.2"));
                ORUmsg.Add("Filler Order Number2", message2.GetValue("OBR.3"));
                ORUmsg.Add("Universal Service Identifier", message2.GetValue("OBR.4"));
                ORUmsg.Add("Priority", message2.GetValue("OBR.5"));
                ORUmsg.Add("Requested DateTime", message2.GetValue("OBR.6"));
                ORUmsg.Add("Observation DateTime", message2.GetValue("OBR.7"));
                ORUmsg.Add("Observation End DateTime", message2.GetValue("OBR.8"));
                ORUmsg.Add("Collection Volume", message2.GetValue("OBR.9"));
                ORUmsg.Add("Collector Identifier", message2.GetValue("OBR.10"));

                ORUmsg.Add("Specimen Action Code", message2.GetValue("OBR.11"));
                ORUmsg.Add("Danger Code", message2.GetValue("OBR.12"));
                ORUmsg.Add("Relevant Clinical Information", message2.GetValue("OBR.13"));
                ORUmsg.Add("Specimen Received DateTime", message2.GetValue("OBR.14"));
                ORUmsg.Add("Specimen Source", message2.GetValue("OBR.15"));
                ORUmsg.Add("Ordering Provider", message2.GetValue("OBR.16"));
                ORUmsg.Add("Order Callback Phone Number", message2.GetValue("OBR.17"));
                ORUmsg.Add("Placer Field1", message2.GetValue("OBR.18"));
                ORUmsg.Add("Placer Field2", message2.GetValue("OBR.19"));
                ORUmsg.Add("Filler Field1", message2.GetValue("OBR.20"));

                ORUmsg.Add("Filler Field2", message2.GetValue("OBR.21"));
                ORUmsg.Add("Results Status Chng DateTime", message2.GetValue("OBR.22"));
                ORUmsg.Add("Charge To Practice", message2.GetValue("OBR.23"));
                ORUmsg.Add("Diagnostic Service Section ID", message2.GetValue("OBR.24"));
                ORUmsg.Add("Result Status", message2.GetValue("OBR.25"));
                ORUmsg.Add("Parent Result", message2.GetValue("OBR.26"));
                ORUmsg.Add("QuantityTiming2", message2.GetValue("OBR.27"));
                ORUmsg.Add("Result Copies To", message2.GetValue("OBR.28"));
                ORUmsg.Add("Parent Number", message2.GetValue("OBR.29"));
                ORUmsg.Add("Transportation Mode", message2.GetValue("OBR.30"));

                ORUmsg.Add("Reason For Study", message2.GetValue("OBR.31"));
                ORUmsg.Add("Principal Result Interpreter", message2.GetValue("OBR.32"));
                ORUmsg.Add("Assistant Result Interpreter", message2.GetValue("OBR.33"));
                ORUmsg.Add("Technician", message2.GetValue("OBR.34"));
                ORUmsg.Add("Transcriptionist", message2.GetValue("OBR.35"));
                ORUmsg.Add("Scheduled DateTime", message2.GetValue("OBR.36"));
                ORUmsg.Add("Number of Sample Containers", message2.GetValue("OBR.37"));


                ORUmsg.Add("Set ID - OBX", message2.GetValue("OBX.1"));
                ORUmsg.Add("Value Type", message2.GetValue("OBX.2"));
                ORUmsg.Add("Observation Identifier", message2.GetValue("OBX.3"));
                ORUmsg.Add("Observation Sub-ID", OBXList[0].Fields(4).Value);// ORUmsg.Add("Observation Sub-ID", message2.GetValue("OBX.4"));
                ORUmsg.Add("Observation Value", message2.GetValue("OBX.5"));
                ORUmsg.Add("Units", message2.GetValue("OBX.6"));
                ORUmsg.Add("References Range", message2.GetValue("OBX.7"));
                ORUmsg.Add("Abnormal Flags", message2.GetValue("OBX.8"));
                ORUmsg.Add("Probability", message2.GetValue("OBX.9"));
                ORUmsg.Add("Nature of Abnormal Test", message2.GetValue("OBX.10"));

                ORUmsg.Add("Observ Result Status", message2.GetValue("OBX.11"));
                ORUmsg.Add("Date Last Obs Normal Values", message2.GetValue("OBX.12"));
                ORUmsg.Add("User Defined Access Checks", message2.GetValue("OBX.13"));
                ORUmsg.Add("DateTime of the Observation", message2.GetValue("OBX.14"));
                ORUmsg.Add("Producer's ID", message2.GetValue("OBX.15"));
                ORUmsg.Add("Responsible Observer", message2.GetValue("OBX.16"));
                ORUmsg.Add("Observation Method", message2.GetValue("OBX.17"));

                string ORUjson = MyDictionaryToJson(ORUmsg);


                //#region OBX
                //string SetID = message2.GetValue("OBX.1");
                //string ValueType = message2.GetValue("OBX.2");
                //string ObservationIdentifier = message2.GetValue("OBX.3");
                //string ObservationSubID = message2.GetValue("OBX.4");
                //var data2 = OBXList[0].Fields(4).Value;
                //string ObservationValue = message2.GetValue("OBX.5");
                //string Units = message2.GetValue("OBX.6");
                //string ReferenceRange = message2.GetValue("OBX.7");
                //string AbnormalFlags = message2.GetValue("OBX.8");
                //string Probability = message2.GetValue("OBX.9");
                //string NatureOfAbnormalTest = message2.GetValue("OBX.10");
                //string ObservResultStatus = message2.GetValue("OBX.11");
                //string DateLastObsNormalValues = message2.GetValue("OBX.12");
                //string UserDefinedAccessChecks = message2.GetValue("OBX.13");
                //string DateOfObservation = message2.GetValue("OBX.14");
                //string ProducerID = message2.GetValue("OBX.15");
                //string ResponsibleObserver = message2.GetValue("OBX.16");
                //string ObservationMethod = message2.GetValue("OBX.17");

                //Dictionary<string, string> ORXmsg = new Dictionary<string, string>();
                //ORXmsg.Add("SetID", SetID);
                //ORXmsg.Add("ValueType", ValueType);
                //ORXmsg.Add("ObservationIdentifier", ObservationIdentifier);
                //ORXmsg.Add("ObservationSubID", ObservationSubID);
                //ORXmsg.Add("ObservationValue", ObservationValue);
                //ORXmsg.Add("Units", Units);
                //ORXmsg.Add("ReferenceRange", ReferenceRange);
                //ORXmsg.Add("AbnormalFlags", AbnormalFlags);
                //ORXmsg.Add("Probability", Probability);
                //ORXmsg.Add("NatureOfAbnormalTest", NatureOfAbnormalTest);
                //ORXmsg.Add("ObservResultStatus", ObservResultStatus);
                //ORXmsg.Add("DateLastObsNormalValues", DateLastObsNormalValues);
                //ORXmsg.Add("UserDefinedAccessChecks", UserDefinedAccessChecks);
                //ORXmsg.Add("DateOfObservation", DateOfObservation);
                //ORXmsg.Add("ProducerID", ProducerID);
                //ORXmsg.Add("ResponsibleObserver", ResponsibleObserver);
                //ORXmsg.Add("ObservationMethod", ObservationMethod);

                //string json = MyDictionaryToJson(ORXmsg);

                //#endregion OBX
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }
        }


        string MyDictionaryToJson(Dictionary<string, string> dict)
        {
            try
            {
                var entries = dict.Select(d =>
                    string.Format("\"{0}\": \"{1}\"", d.Key, string.Join(",", d.Value)));
                return "{" + string.Join(",", entries) + "}";
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception msg: " + e);
                return "";
            }
        }

        [TestMethod]
        public void DecodedValue1()
        {
            var msg = "MSH|^~\\&|SAP|aaa|JCAPS||20210330150502||ADT^A28|0000000111300053|P|2.5||||||UNICODE UTF-8\r\nPID|||704251200^^^SAP^PI^0001~XXXXXXX^^^SS^SS^066^20210330~\"\"^^^^PRC~\"\"^^^^DL~\"\"^^^^PPN~XXXXXXXX^^^Ministero finanze^NN~\"\"^^^^PNT^^^\"\"~\"\"^^^^NPI^^\"\"^^\"\"&&\"\"^\"\"&\"\"||TEST\\F\\TEST^TEST2^^^SIG.^\"\"||19610926|M|||^^SANTEUSANIO FORCONESE^^^IT^BDL^^066090~&VIA DELLA PIEGA 12 TRALLaae^\"\"^SANTEUSANIO FORCONESE^AQ^67020^IT^L^^066090^^^^20210330||^ORN^^^^^^^^^^349 6927621~^NET^^\"\"|||2||||||||||IT^^100^Italiana|||\"\"||||20160408\r\n";

            var message = new Message(msg);
            message.ParseMessage();

            var field = message.GetValue("PID.5");
            var component = message.GetValue("PID.5.1");
            var subcomponent = message.GetValue("PID.5.1.1");

            Assert.AreEqual(component, subcomponent);
            Assert.IsTrue(field.StartsWith(component));
        }

        [TestMethod]
        public void MessageIsComponentized()
        {
            string sampleMessage = this.HL7_ADT;
            var message = new Message(sampleMessage);
            message.ParseMessage();

            Assert.IsTrue(message.IsComponentized("PID.5"));
        }

        [TestMethod]
        public void FieldHasRepetitions()
        {
            string sampleMessage = this.HL7_ADT;
            var message = new Message(sampleMessage);
            message.ParseMessage();
            Console.WriteLine(message.Segments("PID")[0].Fields(18).Value);
            Assert.IsFalse(message.HasRepetitions("PID.3"));
            //Assert.IsTrue(message.HasRepetitions("PID.18")); // Possible bug in the upstream library
        }

        [TestMethod]
        public void SequenceNo()
        {
            string sampleMessage = @"MSH|^~\&|MEDAT|AESCU|IXZENT||20210714122713|MEDAT_KC|ORU^R01|6227281|P|2.3|||||||
PID|||||Kuh^Klarabella||19901224|F|||Bogus St^^Gotham^^42069^|||||||||||||
PV1||2|Jenkins||||||||||||||||AP0999923||P|||||||
ORC||0490000001|0490000001||CM||||202107141056
OBR|1|0490000001|0490000001|LH^LH^FN|||202107141056|20210714122713||||||202107141056|1||||||||||F|
OBX|1|NM|LH^LH^FN||20.00|mIU/ml|||||F||
NTE|1||      Follikelphase:    2.4 -  12.6 mIU/ml
NTE|2||      Ovulationsphase: 14.0 - 95.6 mIU/ml
NTE|3||      Lutealphase:      1.0 - 11.4 mIU/ml
NTE|4||      Postmenopause:    7.7 - 58.5 mIU/ml
OBR|2|0490000001|0490000001|FSH^FSH^FN|||202107141056|20210714122713||||||202107141056|1||||||||||F|
OBX|1|NM|FSH^FSH^FN||30.00|mIU/ml|||||F||
NTE|1||      Follikelphase:    3.5 - 12.5 mIU/ml
NTE|2||      Ovulationsphase:  4.7 - 21.5 mIU/ml
NTE|3||      Lutealphase:       1.7 - 7.7 mIU/ml
NTE|4||      Postmenopause:  25.8 - 134.8 mIU/ml";
            var message = new Message(sampleMessage);
            message.ParseMessage();

            var nte = message.Segments("NTE")[0];
            Assert.AreEqual(6, nte.GetSequenceNo());

            nte = message.Segments("NTE")[4];
            Assert.AreEqual(12, nte.GetSequenceNo());
        }

        [TestMethod]
        public void DecodeNonLatinChars()
        {
            var enconding = new HL7Encoding();

            Assert.AreEqual(enconding.Decode(@"T\XC3A4\glich 1 Tablette oral einnehmen"), "Täglich 1 Tablette oral einnehmen");
            Assert.AreEqual(enconding.Decode(@"\XE6AF8F\\XE5A4A9\\XE69C8D\\XE794A8\"), "每天服用");
        }
    }
}
