using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Ad_EmailLogin : BasePage
{

    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    

    string strSQL= string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
            if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
            {
                Response.Redirect("~/SessionExpire.aspx");
            }
        #endregion 

        #region language Resources
        //LtrEmailList.Text = Resources.LangResources.Listing;
        LtrEmailLogin.Text = " Email" + Resources.LangResources.Login;

        LtrEmailNoteId.Text = "<b>NOTE : </b> Login Username must have full email address.";
        LtrEmailNoteId2.Text = "By default your first email address will be picked up for WebMail Login";
        #endregion

        //HypWebMail.NavigateUrl = "https://webmail.opentransfer.com/horde/imp/login.php?imapuser=support@smswebsite.com";
       
        //if (!IsPostBack)
        //{
        //    LoadExistingEmails();
        //}


    }

    //protected void LoadExistingEmails()
    //{


    //    dbConn = new SqlConnection(GlobalVar.GetDbConnString);

    //    try
    //    {
    //        dbConn.Open();
    //        //strSQL = "select top 3 EmId,EmailAddress,EmPassword,Status,StatusText,CreatedDate from tblUserEmails  where deleted=0 and UserID = " + Convert.ToInt32(Session["UserID"]);
    //        strSQL = "select EmId, EmailAddress,EmPassword,CreatedDate,Convert(bit,Status) as Status, ApprovedDate,UserID, " +
    //                    " Case When Status = 0 Then 'Pending' Else 'Approved' END as StatusTEXT " +
    //                    " from tblUserEmails " + 
    //                    " where deleted=0 and UserID = " + Convert.ToInt32(Session["UserID"]);
            
    //        dbCmd = new SqlCommand(strSQL, dbConn);
    //        dbReader = dbCmd.ExecuteReader();

    //        string strReqDate = string.Empty;
    //        DateTime dtReqDate;
    //        int i = 1;
    //        if (dbReader.HasRows)
    //        {
    //            while (dbReader.Read())
    //            {
    //                switch (i)
    //                {
    //                    case 1: txtEmail1.Text = dbReader["EmailAddress"].ToString();
    //                            hdEmail1.Value = dbReader["EmailAddress"].ToString();
    //                            txtPassword1.Text = dbReader["EmPassword"].ToString();
    //                            ltrPending1.Text = dbReader["StatusTEXT"].ToString();
    //                            //ltrDateRequested1.Text = dbReader["CreatedDate"].ToString();

    //                            strReqDate = dbReader["CreatedDate"].ToString();
    //                            dtReqDate = Convert.ToDateTime(strReqDate);
    //                            ltrDateRequested1.Text = dtReqDate.ToLongDateString();

    //                            if (dbReader["Status"].ToString() == "True")
    //                            {
    //                                strReqDate = dbReader["ApprovedDate"].ToString();
    //                                dtReqDate = Convert.ToDateTime(strReqDate);
    //                                ltrDateApproved1.Text = dtReqDate.ToLongDateString();
    //                            }

    //                            if ((txtEmail1.Text != null) || (txtEmail1.Text != ""))
    //                            {
    //                                txtEmail1.Enabled = false;
    //                                txtPassword1.Enabled = false;
    //                               // tRow1.BgColor = System.Drawing.Color.FromName("#DAD7D7");
    //                                tRow1.BgColor = "#DAD7D7";
    //                                txtEmail1.CssClass = "stdTextField1_disabled";
    //                                txtPassword1.CssClass = "stdTextField1_disabled";
    //                            }

    //                            break;
    //                    case 2: txtEmail2.Text = dbReader["EmailAddress"].ToString();
    //                            hdEmail2.Value = dbReader["EmailAddress"].ToString();
    //                            txtPassword2.Text = dbReader["EmPassword"].ToString();
    //                            ltrPending2.Text = dbReader["StatusTEXT"].ToString();
    //                            //ltrDateRequested2.Text = dbReader["CreatedDate"].ToString();

    //                             strReqDate = dbReader["CreatedDate"].ToString();
    //                             dtReqDate = Convert.ToDateTime(strReqDate);
    //                            ltrDateRequested2.Text = dtReqDate.ToLongDateString();

    //                            if (dbReader["Status"].ToString() == "True")
    //                            {
    //                                strReqDate = dbReader["ApprovedDate"].ToString();
    //                                dtReqDate = Convert.ToDateTime(strReqDate);
    //                                ltrDateApproved2.Text = dtReqDate.ToLongDateString();
    //                            }

    //                            if ((txtEmail2.Text != null) || (txtEmail2.Text != ""))
    //                            {
    //                                txtEmail2.Enabled = false;
    //                                txtPassword2.Enabled = false;
    //                                tRow2.BgColor = "#DAD7D7";
    //                                txtEmail2.CssClass = "stdTextField1_disabled";
    //                                txtPassword2.CssClass = "stdTextField1_disabled";
    //                            }
    //                             break;
    //                    case 3: txtEmail3.Text = dbReader["EmailAddress"].ToString();
    //                            hdEmail3.Value = dbReader["EmailAddress"].ToString();
    //                            txtPassword3.Text = dbReader["EmPassword"].ToString();
    //                            ltrPending3.Text = dbReader["StatusTEXT"].ToString();
    //                            //ltrDateRequested3.Text = dbReader["CreatedDate"].ToString();

    //                            strReqDate = dbReader["CreatedDate"].ToString();
    //                            dtReqDate = Convert.ToDateTime(strReqDate);
    //                            ltrDateRequested3.Text = dtReqDate.ToLongDateString();


    //                            if (dbReader["Status"].ToString() == "True")
    //                            {
    //                                strReqDate = dbReader["ApprovedDate"].ToString();
    //                                dtReqDate = Convert.ToDateTime(strReqDate);
    //                                ltrDateApproved3.Text = dtReqDate.ToLongDateString();
    //                            }

    //                            if ((txtEmail3.Text != null) || (txtEmail3.Text != ""))
    //                            {
    //                                txtEmail3.Enabled = false;
    //                                txtPassword3.Enabled = false;
    //                                tRow3.BgColor = "#DAD7D7";
    //                                txtEmail3.CssClass = "stdTextField1_disabled";
    //                                txtPassword3.CssClass = "stdTextField1_disabled";
    //                            }
    //                            break;
    //                }
    //                i++;

    //            }

    //        }

    //        if ((txtEmail1.Enabled == false) && (txtEmail2.Enabled == false) && (txtEmail3.Enabled == false))
    //            BtnSave.Enabled = false;

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        dbConn.Close();
    //    }


    //}


    //protected void BtnSave_Click(object sender, EventArgs e)
    //{


    //    //int inStatus = objBAL_Homepage.Insert_LanguageItem(objNewLangCode.Text, objNewLangName.Text);
    //    int inStatus = 0;

    //    //getting old email values 

    //    string mOld_Email1;
    //    string mOld_Email2;
    //    string mOld_Email3;

    //    if (hdEmail1.Value != "")
    //        mOld_Email1 = hdEmail1.Value;
    //    else
    //        mOld_Email1 = "0";

    //    if (hdEmail2.Value != "")
    //        mOld_Email2 = hdEmail2.Value;
    //    else
    //        mOld_Email2 = "0";

    //    if (hdEmail3.Value != "")
    //        mOld_Email3 = hdEmail3.Value;
    //    else
    //        mOld_Email3 = "0";



    //    //if (txtPassword1.Text == "")
    //    //    txtPassword1.Text = "0";

    //    //if (txtPassword2.Text == "")
    //    //    txtPassword2.Text = "0";

    //    //if (txtPassword3.Text == "")
    //    //    txtPassword3.Text = "0";


    //    dbConn = new SqlConnection(GlobalVar.GetDbConnString);

    //    try
    //    {
    //        dbConn.Open();
    //        if ((txtEmail1.Text != "") && (txtEmail1.Text != mOld_Email1))
    //        {
    //           // strSQL = "Insert into tblUserEmails (UserID,EmailAddress) values (" + Convert.ToInt32(Session["UserID"]) + ",'" + txtEmail1.Text + "')";
    //            strSQL = "EXEC usp_Emails_insert " + Convert.ToInt32(Session["UserID"]) + ",'" + txtEmail1.Text + "','" + mOld_Email1 + "','" + txtPassword1.Text + "'";
    //        }

    //        if ((txtEmail2.Text != "") && (txtEmail2.Text != mOld_Email2))
    //        {
    //            strSQL = strSQL + "; ";
    //            //strSQL = "Insert into tblUserEmails (UserID,EmailAddress) values (" + Convert.ToInt32(Session["UserID"]) + ",'" + txtEmail2.Text + "')";
    //            strSQL = strSQL + "EXEC usp_Emails_insert " + Convert.ToInt32(Session["UserID"]) + ",'" + txtEmail2.Text + "','" + mOld_Email2 + "','" + txtPassword2.Text + "'";
    //        }

    //        if ((txtEmail3.Text != "") && (txtEmail3.Text != mOld_Email3))
    //        {
    //            strSQL = strSQL + "; ";
    //            //strSQL = "Insert into tblUserEmails (UserID,EmailAddress) values (" + Convert.ToInt32(Session["UserID"]) + ",'" + txtEmail3.Text + "')";
    //            strSQL = strSQL + "EXEC usp_Emails_insert " + Convert.ToInt32(Session["UserID"]) + ",'" + txtEmail3.Text + "','" + mOld_Email3 + "','" + txtPassword3.Text + "'";
    //        }

    //        if ((strSQL != "") && (strSQL != string.Empty))
    //        {
    //            dbCmd = new SqlCommand(strSQL, dbConn);
    //            inStatus = dbCmd.ExecuteNonQuery();
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        dbConn.Close();
    //    }


    //    Response.Redirect("Ad_EmailList.aspx");

    //    //if (inStatus >= 1)
    //    //{
    //    //    tblMessageBar.Visible = true;
    //    //    MessageImage.Src = "~/Images/inf_Sucess.gif";
    //    //    lblErrMessage.Text = "Email Items successfully added";
    //    //    lblErrMessage.CssClass = "font_12Msg_Success";
    //    //}
    //    //else
    //    //{
    //    //    tblMessageBar.Visible = true;
    //    //    MessageImage.Src = "~/Images/inf_Error.gif";
    //    //    //  lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the record. Please contant Administrator";
    //    //    lblErrMessage.Text = "Entered language Code already exists. Please enter another language code";
    //    //    lblErrMessage.CssClass = "font_12Msg_Error";
    //    //}




    //}
}
