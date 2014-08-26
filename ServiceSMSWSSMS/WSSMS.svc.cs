using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net;
using ServiceSMS.Properties;
using ServiceSMS.Contract;
using ServiceSMS.BusinessLogic;
using System.Xml;
using log4net;
using System.Reflection;
using ServiceSMS.Helpers;
using Newtonsoft.Json;

namespace ServiceSMS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class WSSMS : IWSSMS
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public string PostSMS(string numbersent, string bodysent, string lang, string AGRCODE)
        {
            string strResult = null;
            string str = null;
            string strresponse;

            if (lang == "TH")
            {
                str = "TRANSID=BULK&CMD=SENDMSG&FROM=66899264547&TO=" + numbersent + "&REPORT=N&CHARGE=N&CODE=KTBLeasing_BulkSMS&CTYPE=LUNICODE&CONTENT=" + String2Unicode(bodysent).ToUpper().ToString() + "";
            }
            else
            {
                str = "TRANSID=BULK&CMD=SENDMSG&FROM=66899264547&TO=" + numbersent + "&REPORT=N&CHARGE=N&CODE=KTBLeasing_BulkSMS&CTYPE=LTEXT&CONTENT=" + bodysent + "";
            }

            string url = null;

            url = Settings.Default.AISURL;
            HttpWebRequest oRequest = (HttpWebRequest)WebRequest.Create(url);
            oRequest.Accept = "*/*";
            oRequest.AllowAutoRedirect = true;
            oRequest.UserAgent = "http_requester/0.1";
            oRequest.Timeout = 60000;
            oRequest.Method = "POST";
            oRequest.ContentType = "application/x-www-form-urlencoded";
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] postByteArray = encoding.GetBytes(str);
            oRequest.ContentLength = postByteArray.Length;

            try
            {
                System.IO.Stream postStream = oRequest.GetRequestStream();
                postStream.Write(postByteArray, 0, postByteArray.Length);
                postStream.Close();
                HttpWebResponse oResponse = (HttpWebResponse)oRequest.GetResponse();
                if (oResponse.StatusCode == HttpStatusCode.OK)
                {
                    System.IO.Stream responseStream = oResponse.GetResponseStream();
                    System.IO.StreamReader myStreamReader = new System.IO.StreamReader(responseStream);
                    strresponse = myStreamReader.ReadToEnd();




                    //XmlDocument xmlDoc = new XmlDocument();
                    //xmlDoc.LoadXml(strresponse);
                    //System.Data.DataSet ds = new System.Data.DataSet();

                    //ds.ReadXml(new System.Xml.XmlNodeReader(xmlDoc));
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //  //  strResult = InsertDATA(numbersent, ds.Tables[0].Rows[0]["STATUS"].ToString(), ds.Tables[0].Rows[0]["DETAIL"].ToString(), ds.Tables[0].Rows[0]["SMID"].ToString(), AGRCODE, bodysent);
                    //}
                }
                else
                {
                    //insert Case false
                    //InsertDATA(numbersent, oResponse.StatusCode.ToString(), oResponse.StatusDescription.Trim().ToString(), "", AGRCODE, bodysent);
                }


            }
            catch (Exception Ex)
            {
                strResult = Ex.Message.ToString();
                //InsertDATA(numbersent, "Error", Ex.Message.ToString(), "", AGRCODE, bodysent);
            }

            return strResult;
        }

        public string DataDetail(string numbersent, string bodysent, string lang, string AGRCODE)
        {
            string strResult = null;
            string str = null;

            if (lang == "TH")
            {
                str = "TRANSID=BULK&CMD=SENDMSG&FROM=66899264547&TO=" + numbersent + "&REPORT=N&CHARGE=N&CODE=KTBLeasing_BulkSMS&CTYPE=LUNICODE&CONTENT=" + String2Unicode(bodysent).ToUpper() + "";
            }
            else
            {
                str = "TRANSID=BULK&CMD=SENDMSG&FROM=66899264547&TO=" + numbersent + "&REPORT=N&CHARGE=N&CODE=KTBLeasing_BulkSMS&CTYPE=LTEXT&CONTENT=" + bodysent + "";
            }

            string url = null;

            //url = "http://http://corpsmsweb.dtac.co.th/servlet/com.iess.socket.SmsCorplink";
            //ConfigurationManager.AppSettings["AISURL"];
            url = Settings.Default.DTACURL;

            MSXML2.XMLHTTP xmlRequest = new MSXML2.XMLHTTP();
            xmlRequest.open("post", url);
            xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xmlRequest.setRequestHeader("charset", "utf-8");
            xmlRequest.setRequestHeader("Content-Length", Convert.ToString(str.Length));
            try
            {
                xmlRequest.setRequestHeader("Connection", "close");
                xmlRequest.send(str);
                strResult = "Send SMS Complete ";

            }
            catch (Exception ex)
            {
                strResult = "Error:" + ex.Message.ToString();
            }

            return strResult;
        }

        public SMSResult SMSAISNew(LogSMSNewData entity)
        {
            dynamic info = new MyExpando();

            info.start = DateTime.Now;
            info.LogSMSNewData = entity;
            info.method = "SMSAISNew";

            SMSResult SMSResult = new SMSResult();
            string strResult = null;
            string requestDetail = null;
            string strresponse;
            string responseDetail = null;
            ProcessNewSMS ps = new ProcessNewSMS();

            if (entity.Language == "TH")
            {
                requestDetail = "TRANSID=BULK&CMD=SENDMSG&FROM=66899264547&TO=" + entity.Mobilenumber + "&REPORT=N&CHARGE=N&CODE=KTBLeasing_BulkSMS&CTYPE=LUNICODE&CONTENT=" + String2Unicode(entity.SMSDetail).ToUpper().ToString() + "";
            }
            else
            {
                requestDetail = "TRANSID=BULK&CMD=SENDMSG&FROM=66899264547&TO=" + entity.Mobilenumber + "&REPORT=N&CHARGE=N&CODE=KTBLeasing_BulkSMS&CTYPE=LTEXT&CONTENT=" + entity.SMSDetail + "";
            }

            string url = null;

            url = Settings.Default.AISURL;
            HttpWebRequest oRequest = (HttpWebRequest)WebRequest.Create(url);
            oRequest.Accept = "*/*";
            oRequest.AllowAutoRedirect = true;
            oRequest.UserAgent = "http_requester/0.1";
            oRequest.Timeout = Settings.Default.Timeout;
            oRequest.Method = "POST";
            oRequest.ContentType = "application/x-www-form-urlencoded";

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] postByteArray = encoding.GetBytes(requestDetail);
            oRequest.ContentLength = postByteArray.Length;

            try
            {
                System.IO.Stream postStream = oRequest.GetRequestStream();
                postStream.Write(postByteArray, 0, postByteArray.Length);
                postStream.Close();

                HttpWebResponse oResponse = (HttpWebResponse)oRequest.GetResponse();

                Logger.Info(JsonConvert.SerializeObject(oRequest));
                Logger.Info(JsonConvert.SerializeObject(oResponse));
                
                if (oResponse.StatusCode == HttpStatusCode.OK)
                {
                    System.IO.Stream responseStream = oResponse.GetResponseStream();
                    System.IO.StreamReader myStreamReader = new System.IO.StreamReader(responseStream);
                    strresponse = myStreamReader.ReadToEnd();

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(strresponse);
                    System.Data.DataSet ds = new System.Data.DataSet();

                    ds.ReadXml(new System.Xml.XmlNodeReader(xmlDoc));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        entity.Smid = ds.Tables[0].Rows[0]["SMID"].ToString();
                        responseDetail = ds.Tables[0].Rows[0]["DETAIL"].ToString();
                        bool status = ps.InsetSMS(entity, true, requestDetail, responseDetail); 
                    }
                    SMSResult.IsCompleted = true;
                    SMSResult.Message = responseDetail;
                }
                else
                {
                    responseDetail = oResponse.StatusDescription.Trim().ToString();
                    ps.InsetSMS(entity, false, requestDetail, responseDetail);
                    SMSResult.IsCompleted = false;
                    SMSResult.Message = responseDetail;
                }


            }
            catch (Exception Ex)
            {
               
                strResult = Ex.Message.ToString();
                responseDetail = Ex.Message.ToString();
                ps.InsetSMS(entity, false, requestDetail, responseDetail);
                SMSResult.IsCompleted = false;
                SMSResult.Message = responseDetail;

                info.end = DateTime.Now;
                Logger.Error(JsonConvert.SerializeObject(info), Ex);
            }
            return SMSResult;
        }

        private string String2Unicode(string st)
        {
            string uni = "";
            try
            {
                System.Text.UnicodeEncoding u = new System.Text.UnicodeEncoding();
                byte[] ba = u.GetBytes(st);
                for (int n = 0; n <= ba.GetUpperBound(0); n += 2)
                {
                    uni += string.Format("%{0:X2}%{1:X2}", ba[n + 1], ba[n]);
                }
            }
            catch (Exception ex)
            {
                uni = "Error:" + ex.Message.ToString();
            }
            return uni;

        }

        public string TestService(string str)
        {
            return str;
        }
    }
}
