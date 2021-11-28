using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for MyGeoLocation
/// </summary>
public class MyGeoLocation
{
	public MyGeoLocation()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static string GetLocationCSV(string ipAddress)
    {
        string strURL = "http://ip-api.com/csv/";
        WebRequest rssReq = WebRequest.Create(strURL + ipAddress);

        rssReq.Timeout = 2000;
        try
        {
            //Get the WebResponse
            WebResponse rep = rssReq.GetResponse();

            Encoding enc = Encoding.GetEncoding(1252);  // Windows default Code Page
            StreamReader loResponseStream = new StreamReader(rep.GetResponseStream(), enc);
            string CSV_Response = loResponseStream.ReadToEnd();
            rep.Close();
            loResponseStream.Close();

            return CSV_Response;

        }
        catch
        {
            return null;
        }


    }

    public static DataTable GetLocation(string ipaddress)
    {

        string strURL = "http://ip-api.com/xml/";

        //Create a WebRequest
        WebRequest rssReq = WebRequest.Create(strURL + ipaddress);
        //Set the timeout in Seconds for the WebRequest
        rssReq.Timeout = 2000;
        try
        {
            //Get the WebResponse
            WebResponse rep = rssReq.GetResponse();
            //Read the Response in a XMLTextReader
            XmlTextReader xtr = new XmlTextReader(rep.GetResponseStream());
            //Create a new DataSet
            DataSet ds = new DataSet();
            //Read the Response into the DataSet
            ds.ReadXml(xtr);
            return ds.Tables[0];
        }
        catch
        {
            return null;
        }
    }

    public static string GetUserIP()
    {
        string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipList))
        {
            return ipList.Split(',')[0];
        }

        return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
    }

    public static String GetCountryCodeFromIP()
    {

        string tmpCountryCode = string.Empty;
        //return tmpCountryCode; 
        //String tmpIP = GetUserIP();
        String tmpIP = GetIP4Address();
        newDBS objnewDBS = new newDBS();
        string tmpCCode = objnewDBS.ip_getCountryCode(tmpIP);
        
        if (tmpCCode == null)
        {
            tmpCCode = "";
        }
        return tmpCountryCode = tmpCCode;
    }

    public static string GetIP4Address()
    {
        string IP4Address = String.Empty;

        foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        if (IP4Address != String.Empty)
        {
            return IP4Address;
        }

        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        return IP4Address;
    }

    public static bool isSMSPurchaseOpenForCountry(String vCountryCode)
    {
        String cc = GetCountryCodeFromIP();
       
        if(cc == vCountryCode)
        {
            return true; 
        }
        return false; 

    }
}