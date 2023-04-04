using FellowOakDicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgent.Lib
{
    public class DICOMJSONBuilder
    {
        private readonly DicomFile _dicomFile;
        private readonly Dictionary<string, object> _attributes = new Dictionary<string, object>();
        private const string _logName = "WebServer";

     
        private bool IsBase64(DicomVR vr)
        {
            if (vr == DicomVR.OB
                //|| vr == DicomVR.OD
                || vr == DicomVR.OF
                || vr == DicomVR.OW
                || vr == DicomVR.UN
                )
            {
                return true;
            }
            return false;
        }

        private bool IsSequence(DicomVR vr)
        {
            if (vr == DicomVR.SQ)
            {
                return true;
            }
            return false;
        }

        private bool IsString(DicomVR vr)
        {
            if (vr == DicomVR.AE
                || vr == DicomVR.AS
                || vr == DicomVR.AT
                || vr == DicomVR.CS
                || vr == DicomVR.DA
                || vr == DicomVR.DT
                || vr == DicomVR.AS
                || vr == DicomVR.LO
                || vr == DicomVR.LT
                || vr == DicomVR.SH
                || vr == DicomVR.ST
                || vr == DicomVR.TM
                || vr == DicomVR.UI
                || vr == DicomVR.UT
                )
            {
                return true;
            }
            return false;
        }

        private bool IsFloat(DicomVR vr)
        {
            if (vr == DicomVR.DS
                || vr == DicomVR.FL
                || vr == DicomVR.FD
                )
            {
                return true;
            }
            return false;
        }

        private bool IsInteger(DicomVR vr)
        {
            if (vr == DicomVR.IS
                || vr == DicomVR.SL
                || vr == DicomVR.SS
                || vr == DicomVR.UL
                || vr == DicomVR.US
                )
            {
                return true;
            }
            return false;
        }

        private bool IsName(DicomVR vr)
        {
            if (vr == DicomVR.PN
                )
            {
                return true;
            }
            return false;
        }

    }
}