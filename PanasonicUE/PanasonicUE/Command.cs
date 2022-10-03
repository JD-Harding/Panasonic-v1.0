using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Crestron.SimplSharp;

namespace PanasonicUE
{
    public class CameraCmd
    {
        private string _Control;
        private string _Request;
        private string _Response;

        public CameraCmd(string control, string request, string response)
        {
            this._Control = control;
            this._Request = request;;
            this._Response = response;;
        }

        public void SendControl(string data)
        {
            string toSend = String.Format("/cgi-bin/aw_cam?cmd={0}{1}&res=1", _Control, data);
            Core.Enqueue(toSend);
        }

        public void SendRequest(string data)
        {
            string toSend = String.Format("/cgi-bin/aw_cam?cmd={0}{1}&res=1", _Request, data);
            //CrestronConsole.PrintLine("\n Panasonic: CameraCmd: SendRequest: " + toSend);
            Core.Enqueue(toSend);
        }

        public string Response()
        {
            return _Response;
        }
    }

    public class PTZCmd
    {
        private string _Control;
        private string _Request;
        private string _Response;

        public PTZCmd(string control, string request, string response)
        {
            this._Control = Regex.Replace(control, "#", "%23");
            this._Request = Regex.Replace(request, "#", "%23"); ;
            this._Response = Regex.Replace(response, "#", "%23"); ;
        }

        public void SendControl(string data)
        {
            string toSend = String.Format("/cgi-bin/aw_ptz?cmd={0}{1}&res=1", _Control, data);
            Core.Enqueue(toSend);
        }

        public void SendRequest(string data)
        {
            string toSend = String.Format("/cgi-bin/aw_ptz?cmd={0}{1}&res=1", _Request, data);
            Core.Enqueue(toSend);
        }

        public string Response()
        {
            return _Response;
        }
    }

    public class Camera
    {
        public bool power;
        public bool position;

        public string modelNumber;
        public bool isUE40 = false;
        public bool isUE50 = false;
        public bool isUE80 = false;
        public bool isHE40 = false;
        public bool isHE130 = false;

        public byte format;
        public string title;
        public UInt16 scene;

        // PTV response
        public Int16 pan; // 0000h - 8000h - FFFFh
        public Int16 tilt; // 0000h - 8000h - FFFFh
        public Int16 zoom; // 555h - FFFh
        public Int16 focus; // 555h - FFFh
        public Int16 iris; // 555h - FFFh

        public Int16 digitalZoom = 100; //0100 - 9999
        public Int16 zoomSpeed = 25; // 01 - 49

        public Int16 irisFollow;

        public UInt16 WhiteBalanceMode = 0;
        public int[] WhiteBalanceArray = new int[] { 0, 1, 2, 3, 4, 5, 9 };
       
        public bool Supergain;
        public UInt16 Gain;
        public UInt16 ShutterMode = 0;

        public BitArray ErrorBitArray;       
    }
} 