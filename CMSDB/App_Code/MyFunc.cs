using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for MyFunc
/// </summary>
public class MyFunc
{
	public MyFunc()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    /// <summary> 
    /// Shows a client-side JavaScript alert in the browser. 
    /// </summary> 
    /// <param name="message">The message to appear in the alert.</param> 
    public static void AlertMessage(string message)
    {
        // Cleans the message to allow single quotation marks 
        string cleanMessage = message.Replace("'", "\'");

        string script = "<script type='text/javascript'>alert('" + cleanMessage + "');</script>";

        // Gets the executing web page 
        Page page = HttpContext.Current.CurrentHandler as Page;

        // Checks if the handler is a Page and that the script isn't allready on the Page 
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        {
            page.ClientScript.RegisterClientScriptBlock(typeof(MyFunc), "alert", script);
        }
    }


    /// <summary> 
    /// Shows a client-side JavaScript alert in the browser and redirects to the give page. 
    /// </summary> 
    /// <param name="message">The message to appear in the alert.</param> 
    public static void AlertMessageAndRedirect(string message, string PageURL)
    {
        // Cleans the message to allow single quotation marks 
        string cleanMessage = message.Replace("'", "\'");
        string script = "<script type='text/javascript'>alert('" + cleanMessage + "');window.location.href='" + PageURL + "';</script>";

        // Gets the executing web page 
        Page page = HttpContext.Current.CurrentHandler as Page;

        // Checks if the handler is a Page and that the script isn't allready on the Page 
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        {
            page.ClientScript.RegisterClientScriptBlock(typeof(MyFunc), "alert", script);
        }
    }

    /// <summary> 
    /// Handles the newline for all environments.
    /// </summary> 
    /// <param name="strContent">The content to handle</param> 
    public static string HandleNewLines(string strContent, string strUserAgent)
    {

        if ((strUserAgent.Contains("Chrome")) || (strUserAgent.Contains("Firefox")))
        {
            strContent = strContent.Trim().Replace("\n", Environment.NewLine);
            strContent = strContent.Replace(Environment.NewLine, "<br/>");
        }
        else
        {
            strContent = strContent.Trim().Replace(Environment.NewLine, "<br/>");
        }
        return strContent;

    }


    public static Boolean IsNumeric(string stringToTest)
    {
        int result;
        return int.TryParse(stringToTest, out result);
    }



    public static void ftpfileupload(String vImgFilePath, string vImgFtpFileName)
    {
        //string ftpBaseAddress = @"ftp://210.5.45.8/ImageRepository";
        string ftpBaseAddress = @"ftp://192.168.29.29/ImageRepository";
        string username = "1worldimgftp";
        string password = "global88";

        FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ftpBaseAddress + "/" + vImgFtpFileName);

        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Credentials = new NetworkCredential(username, password);
        request.UsePassive = true;
        request.UseBinary = true;
        request.KeepAlive = false;

        //using (Stream destination = request.GetRequestStream())
        //{
        //   vFileUploadImg.PostedFile.InputStream.CopyTo(destination);
        //    destination.Flush();
        //}

        FileStream stream = File.OpenRead(vImgFilePath + vImgFtpFileName);

        byte[] buffer = new byte[stream.Length];


        stream.Read(buffer, 0, buffer.Length);
        stream.Close();

        Stream reqStream = request.GetRequestStream();
        reqStream.Write(buffer, 0, buffer.Length);
        reqStream.Close();

    }


    public static void InitialiseGridViewPagerRowWithImages(GridViewRow gridViewRow, GridView objGridView)
    {
        if (gridViewRow != null)
        {
            // Check the page index so that we can :
            //  1. Disable the 'First' and 'Previous' paging image buttons if paging index is at 0
            //  2. Disable the 'Last' and 'Next' paging image buttons if paging index is at the end
            //  3. Enable all image buttons if the conditions of 1 and 2 are not satisfied
            //Button firstbutton = gridViewRow.FindControl("btnFirst") as Button;
            //Button Prevbutton = gridViewRow.FindControl("btnPrevious") as Button;
            //Button Nextbutton = gridViewRow.FindControl("btnNext") as Button;
            //Button Lastbutton = gridViewRow.FindControl("btnLast") as Button;

            ImageButton firstbutton = gridViewRow.FindControl("btnFirst") as ImageButton;
            ImageButton Prevbutton = gridViewRow.FindControl("btnPrevious") as ImageButton;
            ImageButton Nextbutton = gridViewRow.FindControl("btnNext") as ImageButton;
            ImageButton Lastbutton = gridViewRow.FindControl("btnLast") as ImageButton;




            if (objGridView.PageIndex == 0)
            {
                // Disable 'First' and 'Previous' Paging image buttons

                if (firstbutton != null && Prevbutton != null)
                {
                    firstbutton.Enabled = false;
                    Prevbutton.Enabled = false;
                    firstbutton.Visible = false;
                    Prevbutton.Visible = false;
                }
            }
            else if ((objGridView.PageIndex + 1) == objGridView.PageCount)
            {
                // Disable 'Last' and 'Next' Paging image buttons

                if (Lastbutton != null && Nextbutton != null)
                {
                    Lastbutton.Enabled = false;
                    Nextbutton.Enabled = false;
                    Lastbutton.Visible = false;
                    Nextbutton.Visible = false;
                }
            }
            else
            {
                // Enable the Paging image buttons

                if (firstbutton != null && Lastbutton != null &&
                     Prevbutton != null && Nextbutton != null)
                {
                    firstbutton.Enabled = true;
                    Lastbutton.Enabled = true;
                    Nextbutton.Enabled = true;
                    Prevbutton.Enabled = true;

                    Lastbutton.Enabled = true;
                    Nextbutton.Enabled = true;
                    Lastbutton.Visible = true;
                    Nextbutton.Visible = true;

                }
            }

            // Get the DropDownList found as part of the Pager Row. 
            // One can then initialise the DropDownList to contain
            // the appropriate page settings. Eg. Page Number and number of Pages

            DropDownList pageNumberDropDownList = gridViewRow.FindControl("PageNumberDropDownList") as DropDownList;
            Label pageCountLabel = gridViewRow.FindControl("PageCountLabel") as Label;
            if (pageNumberDropDownList != null && pageCountLabel != null)
            {
                for (int i = 0; i < objGridView.PageCount; i++)
                {
                    int page = i + 1;
                    pageNumberDropDownList.Items.Add(new ListItem(page.ToString(), i.ToString()));
                }
                pageNumberDropDownList.SelectedIndex = objGridView.PageIndex;
                pageCountLabel.Text = objGridView.PageCount.ToString();
            }
        }
    }


    public static void InitialiseGridViewPagerWithRowCountImages(int PageSize, int TotalRecord, int PageIndex, GridViewRow gridViewRow, GridView objGridView)
    {
        int PageCount = TotalRecord / PageSize;
        if (TotalRecord > PageSize)
        {
            if (TotalRecord % PageSize > 0)
                PageCount++;
        }

        if (PageCount > 0)
        {
            // Check the page index so that we can :
            //  1. Disable the 'First' and 'Previous' paging image buttons if paging index is at 0
            //  2. Disable the 'Last' and 'Next' paging image buttons if paging index is at the end
            //  3. Enable all image buttons if the conditions of 1 and 2 are not satisfied
            //Button firstbutton = gridViewRow.FindControl("btnFirst") as Button;
            //Button Prevbutton = gridViewRow.FindControl("btnPrevious") as Button;
            //Button Nextbutton = gridViewRow.FindControl("btnNext") as Button;
            //Button Lastbutton = gridViewRow.FindControl("btnLast") as Button;
            objGridView.BottomPagerRow.Visible = true;


            ImageButton firstbutton = gridViewRow.FindControl("btnFirst") as ImageButton;
            ImageButton Prevbutton = gridViewRow.FindControl("btnPrevious") as ImageButton;
            ImageButton Nextbutton = gridViewRow.FindControl("btnNext") as ImageButton;
            ImageButton Lastbutton = gridViewRow.FindControl("btnLast") as ImageButton;

            if (PageIndex == 1)
            {
                // Disable 'First' and 'Previous' Paging image buttons

                if (firstbutton != null && Prevbutton != null)
                {
                    firstbutton.Enabled = false;
                    Prevbutton.Enabled = false;
                    firstbutton.Visible = false;
                    Prevbutton.Visible = false;
                }
            }
            else if (PageIndex == PageCount)
            {
                // Disable 'Last' and 'Next' Paging image buttons

                if (Lastbutton != null && Nextbutton != null)
                {
                    Lastbutton.Enabled = false;
                    Nextbutton.Enabled = false;
                    Lastbutton.Visible = false;
                    Nextbutton.Visible = false;
                }
            }
            else
            {
                // Enable the Paging image buttons

                if (firstbutton != null && Lastbutton != null &&
                     Prevbutton != null && Nextbutton != null)
                {
                    firstbutton.Enabled = true;
                    Lastbutton.Enabled = true;
                    Nextbutton.Enabled = true;
                    Prevbutton.Enabled = true;

                    Lastbutton.Enabled = true;
                    Nextbutton.Enabled = true;
                    Lastbutton.Visible = true;
                    Nextbutton.Visible = true;

                }
            }
            // Get the DropDownList found as part of the Pager Row. 
            // One can then initialise the DropDownList to contain
            // the appropriate page settings. Eg. Page Number and number of Pages


            DropDownList pageNumberDropDownList = gridViewRow.FindControl("PageNumberDropDownList") as DropDownList;
            Label pageCountLabel = gridViewRow.FindControl("PageCountLabel") as Label;
            if (pageNumberDropDownList != null && pageCountLabel != null)
            {
                for (int i = 1; i <= PageCount; i++)
                {
                    pageNumberDropDownList.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                pageNumberDropDownList.SelectedValue = PageIndex.ToString();
                pageCountLabel.Text = PageCount.ToString();
            }
        }
    }


    public static void InitialiseGridViewPagerRow(GridViewRow gridViewRow, GridView objGridView)
    {
        if (gridViewRow != null)
        {
            // Check the page index so that we can :
            //  1. Disable the 'First' and 'Previous' paging image buttons if paging index is at 0
            //  2. Disable the 'Last' and 'Next' paging image buttons if paging index is at the end
            //  3. Enable all image buttons if the conditions of 1 and 2 are not satisfied
            Button firstbutton = gridViewRow.FindControl("btnFirst") as Button;
            Button Prevbutton = gridViewRow.FindControl("btnPrevious") as Button;
            Button Nextbutton = gridViewRow.FindControl("btnNext") as Button;
            Button Lastbutton = gridViewRow.FindControl("btnLast") as Button;



            if (objGridView.PageIndex == 0)
            {
                // Disable 'First' and 'Previous' Paging image buttons

                if (firstbutton != null && Prevbutton != null)
                {
                    firstbutton.Enabled = false;
                    Prevbutton.Enabled = false;
                }
            }
            else if ((objGridView.PageIndex + 1) == objGridView.PageCount)
            {
                // Disable 'Last' and 'Next' Paging image buttons

                if (Lastbutton != null && Nextbutton != null)
                {
                    Lastbutton.Enabled = false;
                    Nextbutton.Enabled = false;
                }
            }
            else
            {
                // Enable the Paging image buttons

                if (firstbutton != null && Lastbutton != null &&
                     Prevbutton != null && Nextbutton != null)
                {
                    firstbutton.Enabled = true;
                    Lastbutton.Enabled = true;
                    Nextbutton.Enabled = true;
                    Prevbutton.Enabled = true;
                }
            }

            // Get the DropDownList found as part of the Pager Row. 
            // One can then initialise the DropDownList to contain
            // the appropriate page settings. Eg. Page Number and number of Pages

            DropDownList pageNumberDropDownList = gridViewRow.FindControl("PageNumberDropDownList") as DropDownList;
            Label pageCountLabel = gridViewRow.FindControl("PageCountLabel") as Label;
            if (pageNumberDropDownList != null && pageCountLabel != null)
            {
                for (int i = 0; i < objGridView.PageCount; i++)
                {
                    int page = i + 1;
                    pageNumberDropDownList.Items.Add(new ListItem(page.ToString(), i.ToString()));
                }
                pageNumberDropDownList.SelectedIndex = objGridView.PageIndex;
                pageCountLabel.Text = objGridView.PageCount.ToString();
            }
        }
    }


}