<%@ Import namespace="System.Data" %>
<%@ Import namespace="System.Data.SqlClient" %>
<%@ Import namespace="System.IO" %>
<%@ Import namespace="System.IO.Compression" %>
<%@ Import namespace="CMSv3.Entities" %>
<%@ Application Language="C#" %>



<script runat="server">

    public void Application_OnStart(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        
        Hashtable ht = (Hashtable)Application["SESSION_LIST"];
        if (ht == null)
        {
            ht = new Hashtable();
            lock (Application)
            {
                Application["SESSION_LIST"] = ht;
                Application["APP_START_TIME"] = DateTime.Now;
                Application["TOTAL_SESSIONS"] = 0;
            }
        }
        
        

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        
   
        
        CMSv3.BAL.AdminSettings objBL_AdSettings = new CMSv3.BAL.AdminSettings();

        #region Commented EMAIL code 
        
        
        //string ErrorDetails = CurrentException.ToString();
           // Response.Write(ErrorDetails);

            //StringBuilder sbError = new StringBuilder();
            //sbError.Append("<table border='1'>");
            //sbError.Append("<tr><td>&nbsp;</td><td>&nbsp;</td></tr>"); //blank line
            //sbError.Append("<tr>");
            //sbError.Append("<td><b>Offending URL </b></td>");
            //sbError.Append("<td>" + ctx.Request.Url.ToString()  + "</td>");
            //sbError.Append("</tr>");
        
            //sbError.Append("<tr>");
            //sbError.Append("<td><b>Source </b></td>");
            //sbError.Append("<td>" + CurrentException.Source + "</td>");
            //sbError.Append("</tr>");

            //sbError.Append("<tr>");
            //sbError.Append("<td><b>Message </b></td>");
            //sbError.Append("<td>" + CurrentException.Message + "</td>");
            //sbError.Append("</tr>");

            //sbError.Append("<tr>");
            //sbError.Append("<td><b>StackTrace </b></td>");
            //sbError.Append("<td>" + CurrentException.StackTrace + "</td>");
            //sbError.Append("</tr>");

            //sbError.Append("<tr>");
            //sbError.Append("<td><b>GetBaseException </b></td>");
            //sbError.Append("<td>" + CurrentException.GetBaseException() + "</td>");
            //sbError.Append("</tr>");

            //sbError.Append("</table>");

        // MyMail.CommonSendEmail("msri_hari@hotmail.com", "ErrorLog@1SmsBusiness.com", sbError.ToString() , "Error At 1SmsWebSite.com - " + DateTime.Now, "Administrator", "", "");

        #endregion



        string ShowGenericErrorPage = ConfigurationManager.AppSettings["ShowGenericErrorPage"].ToString();

        if (ShowGenericErrorPage.ToUpper() == "TRUE")
        {
            // Get current exception 
            HttpContext ctx = HttpContext.Current;
            Exception CurrentException = ctx.Server.GetLastError();

            String tmpURL = ctx.Request.Url.ToString();
            String tmpSource = CurrentException.Source;
            String tmpMessage = CurrentException.Message;
            String tmpStackTrace = CurrentException.StackTrace;
            String tmpBaseException = CurrentException.GetBaseException().ToString();

            int status = objBL_AdSettings.Insert_WEB_ErrorLog(tmpURL, tmpSource, tmpMessage, tmpStackTrace, tmpBaseException);
            ctx.Server.ClearError();
            Response.Redirect("~/ErrorGenericPage.aspx");
        }

    }

    public void Session_OnStart(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        //set english as default startup language
       // Session["defLanguage"] = "en-US";

        //Session["IsAuthorized"] = true;
        //Session["AuthUser"] = "harifdr";

        LoggedUserInfo ui = new LoggedUserInfo();
        ui.LoginUserID = Convert.ToInt32(Session["UserID"]);
        ui.SessionStartTime = DateTime.Now;
        Session["USER_INFO_MAP"] = ui;

        Hashtable ht = (Hashtable)Application["SESSION_LIST"];
        if (ht.ContainsKey(Session.SessionID) == false)
        {
            ht.Add(Session.SessionID, Session);
        }

        lock (Application)
        {
            int i = (int)Application["TOTAL_SESSIONS"];
            i++;
            Application["TOTAL_SESSIONS"] = i;
        }

    }

   public void Session_OnEnd(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

        Session.Clear();
        Hashtable ht = (Hashtable)Application["SESSION_LIST"];
        ht.Remove(Session.SessionID);

        String tmpSessionTimedOutURL = ConfigurationManager.AppSettings["SessionTimedOutPage"].ToString();
        Response.Redirect(tmpSessionTimedOutURL); 
       

    }

   public void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
   {
       ////InitializeMultiSessionFactoryNHibernate();

       //HttpApplication app = sender as HttpApplication;
       //string acceptEncoding = app.Request.Headers["Accept-Encoding"];
       //Stream prevUncompressedStream = app.Response.Filter;

       //if (!(app.Context.CurrentHandler is Page ||
       //    app.Context.CurrentHandler.GetType().Name == "SyncSessionlessHandler") ||
       //    app.Request["HTTP_X_MICROSOFTAJAX"] != null)
       //    return;

       //if (acceptEncoding == null || acceptEncoding.Length == 0)
       //    return;

       //acceptEncoding = acceptEncoding.ToLower();

       //if (acceptEncoding.Contains("deflate") || acceptEncoding == "*")
       //{
       //    // defalte
       //    app.Response.Filter = new DeflateStream(prevUncompressedStream,
       //        CompressionMode.Compress);
       //    app.Response.AppendHeader("Content-Encoding", "deflate");
       //}
       //else if (acceptEncoding.Contains("gzip"))
       //{
       //    // gzip
       //    app.Response.Filter = new GZipStream(prevUncompressedStream, CompressionMode.Compress);
       //    app.Response.AppendHeader("Content-Encoding", "gzip");
       //}
       
       
   }

   //private void InitializeMultiSessionFactoryNHibernate()
   //{
   //    if (Session["NHibernateConfiguration"] == null)
   //    {
   //        Session["NHibernateConfiguration"] = "UiDesignForTestability";
   //    }

       
   //    //SessionFacade.ConfigurationName = Session["NHibernateConfiguration"] as string;
   //}
    
    

    public void Application_OnPostRequestHandlerExecute(Object sender, EventArgs e)
    {


        if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
        {
            try
            {
                LoggedUserInfo ui = (LoggedUserInfo)Session["USER_INFO_MAP"];
                if (ui != null && Session.IsNewSession)
                {
                    try
                    {
                        if (Request.UrlReferrer != null)
                        {
                            ui.urlReferrer = Request.UrlReferrer.ToString();
                        }

                        ui.userAgent = Request.UserAgent;
                        ui.hostAddress = Request.UserHostAddress;
                        ui.hostName = Request.UserHostName;
                       
                        
                    }
                    catch (Exception)
                    {
                    }
                }
                
                
                //.. Check to see if the URL needs to be monitered 
                //Pages to be monitored...

                string[] PagesArr = new string[2];
                PagesArr[0] = "default";
        
                
                string tmpRawUrl = Request.RawUrl;

                if (tmpRawUrl.ToString().Contains(PagesArr[0]))
                {


                    if (ui != null)
                    {
                        ui.urlViews.Add(Request.RawUrl);

                        if (ui.userAgent == null)
                        {
                            if (Request.UserAgent == null)
                                ui.userAgent = DBNull.Value.ToString();
                            else
                                ui.userAgent = Request.UserAgent;
                        }

                        if (ui.hostAddress == null)
                            ui.hostAddress = Request.UserHostAddress;

                        if (ui.hostName == null)
                            ui.hostName = Request.UserHostName;


                        if (ui.LoginUserID == 0 )
                        {
                            if (Session["UserID"] != null)
                            {
                                ui.LoginUserID = Convert.ToInt32(Session["UserID"]);
                            }
                            else if (Session["ClientID"] != null)
                            {
                                ui.LoginUserID = Convert.ToInt32(Session["ClientID"]);
                            }
                            else if (Session["saUserID"] != null)
                            {
                                ui.LoginUserID = Convert.ToInt32(Session["saUserID"]);
                            }
                        }


                        Session["USER_INFO_MAP"] = ui;
                        /// storing into database
                        /// 

                        SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
                        SqlCommand dbCmd;

                        dbConn.Open();

                        dbCmd = new SqlCommand("usp_LogUserInfo", dbConn);
                        dbCmd.CommandType = CommandType.StoredProcedure;

                        dbCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = ui.LoginUserID;
                        dbCmd.Parameters.Add("@SessionID", SqlDbType.VarChar).Value = Session.SessionID.ToUpper();
                        dbCmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = Request.Url.AbsoluteUri;
                        dbCmd.Parameters.Add("@BrowserInfo", SqlDbType.VarChar).Value = ui.userAgent;
                        dbCmd.Parameters.Add("@BrowserType", SqlDbType.VarChar).Value = Request.Browser.Type;
                        dbCmd.Parameters.Add("@HostName", SqlDbType.VarChar).Value = ui.hostName;
                        dbCmd.Parameters.Add("@HostAddress", SqlDbType.VarChar).Value = ui.hostAddress;
                        dbCmd.Parameters.Add("@SessionStartTime", SqlDbType.VarChar).Value = ui.SessionStartTime;
                        dbCmd.Parameters.Add("@Pages", SqlDbType.VarChar).Value = Request.RawUrl;

                        dbCmd.ExecuteNonQuery();

                        dbConn.Close();



                    }
                }

                              
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
       
</script>
