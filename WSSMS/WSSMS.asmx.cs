using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Web.Services.Protocols;
using System.Web.Security;
using System.Web.UI;
//using System.Web.UI.MasterPage;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Xml;
using System.Net;
//using System.Text.UTF8Encoding;
//using System.Text.UnicodeEncoding;
//using System.Text.UTF32Encoding;
using MSXML2;

namespace WSSMS
{
    /// <summary>
    /// Summary description for WSSMS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WSSMS : System.Web.Services.WebService
    {

        [WebMethod()]
        public string DataDetail(string numbersent, string bodysent, string lang,string AGRCODE)
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
            //Link UAT 
            //url = "http://203.170.230.170:3372/"
            //Link Production
            url = "http://http://corpsmsweb.dtac.co.th/servlet/com.iess.socket.SmsCorplink";
                //ConfigurationManager.AppSettings["AISURL"];

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
                strResult = "Error:"+ex.Message.ToString();
            }

            return strResult;
        }
        
        [WebMethod()]
        public string PostSMS(string numbersent, string bodysent, string lang,string AGRCODE)
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
            //Link UAT 
            //url = "http://203.170.230.170:3372/"
            //Link Production
            url = ConfigurationManager.AppSettings["AISURL"];
            //"http://203.170.228.190:3372/"
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
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(strresponse);
                    System.Data.DataSet ds = new System.Data.DataSet();

                    ds.ReadXml(new System.Xml.XmlNodeReader(xmlDoc));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strResult = InsertDATA(numbersent, ds.Tables[0].Rows[0]["STATUS"].ToString(), ds.Tables[0].Rows[0]["DETAIL"].ToString(), ds.Tables[0].Rows[0]["SMID"].ToString(), AGRCODE, bodysent);
                    }
                }
                else
                {
                    InsertDATA(numbersent, oResponse.StatusCode.ToString(),oResponse.StatusDescription.Trim().ToString() , "", AGRCODE, bodysent);
                }


            } catch (Exception Ex)
            {
                strResult = Ex.Message.ToString();
                InsertDATA(numbersent, "Error", Ex.Message.ToString(),"", AGRCODE, bodysent);
            }


            return strResult;
        }

        private string InsertDATA(string NumberSent, string Status, string Detail, string SMID, string AGRCODE, string BodySent)
        {
            ConDB.MISSQL C1 = new ConDB.MISSQL();
            string sqlstr = null;
            string tableName = ConfigurationManager.AppSettings["DBTableName"]; //NewLogAIS
            string strResult;

            sqlstr = " INSERT INTO " + tableName + " (Mobilenumber,SMSStatus,resultDetail,SMID,AGRCODE,modifidate,SMSMSG)";
            sqlstr += " VALUES ('" + NumberSent + "'";
            sqlstr += " ,'" + Status + "'";
            sqlstr += " ,'" + Detail + "'";
            sqlstr += " ,'" + SMID + "'";
            sqlstr += " ,'" + AGRCODE + "'";
            sqlstr += " ,GETDATE() ";
            sqlstr += " ,'" + BodySent + "'";
            sqlstr += ");";
            strResult = Status;
            try
            {
                C1.Execute(sqlstr, false);
            }
            catch (Exception ex)
            {
                strResult += "(" + ex.Message.ToString() + ")";
            }
            return strResult;

        }

        public static string String2Unicode(string st)
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
                uni = "Error:"+ex.Message.ToString();
            }
            return uni;

        }
    }
}
