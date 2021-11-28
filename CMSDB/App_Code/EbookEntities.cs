using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for EbookEntities
/// </summary>
public class EbookEntities
{
    private string _BookID;
    private string _BookRefID; 
    private string _BookName;
    private string _BookTitle;
    private string _Description;

    private decimal _Price;
    private decimal _Discount;
    private decimal _PrepaidPrice;

    private bool _isDisplay;
    private bool _isFeatured;
    private bool _isBestSeller;
    private bool _isBuyPayPal;
    private bool _isBuySMS;
    private bool _isPrepaid;

    private string _ImgFileName;
    private string _ImgFilePath;

    private string _EbookFileName;
    private string _EbookFilePath;

    private string _ReplySubject;
    private string _ReplySMS;
    private string _ReplySMSch;

    private int _ReplySMStype;
    private string _ReplyEmail;
    private string _SenderEmailID;

    private int _catID;
    private int _CreatedBy;
    private string _categoryName;

    private int _catMainID;

    private string _CCmobile1;
    private string _CCmobile2;
    private string _CCmobile3;

    private int _MerchantID;
    private int _LaunchStatus;

    private int _position;


    public int ReplySMStype
    {
        get { return _ReplySMStype; }
        set { _ReplySMStype = value; }
    }


    public string BookName
    {
        get { return _BookName; }
        set { _BookName = value; }
    }

    public string BookTitle
    {
        get { return _BookTitle; }
        set { _BookTitle = value; }
    }


    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }


    public decimal Price
    {
        get { return _Price; }
        set { _Price = value; }
    }

    public decimal PrepaidPrice
    {
        get { return _PrepaidPrice; }
        set { _PrepaidPrice = value; }
    }

    

    public decimal Discount
    {
        get { return _Discount; }
        set { _Discount = value; }
    }


    public bool isDisplay
    {
        get { return _isDisplay; }
        set { _isDisplay = value; }
    }

    public int LaunchStatus
    {
        get { return _LaunchStatus; }
        set { _LaunchStatus = value; }
    }

    public int position
    {
        get { return _position; }
        set { _position = value; }
    }

    public bool isFeatured
    {
        get { return _isFeatured; }
        set { _isFeatured = value; }
    }


    public bool isBestSeller
    {
        get { return _isBestSeller; }
        set { _isBestSeller = value; }
    }


    public bool isBuyPayPal
    {
        get { return _isBuyPayPal; }
        set { _isBuyPayPal = value; }
    }

    public bool isBuySMS
    {
        get { return _isBuySMS; }
        set { _isBuySMS = value; }
    }

    public bool isPrepaid
    {
        get { return _isPrepaid; }
        set { _isPrepaid = value; }
    }



    public string ImgFileName
    {
        get { return _ImgFileName; }
        set { _ImgFileName = value; }
    }

    public string ImgFilePath
    {
        get { return _ImgFilePath; }
        set { _ImgFilePath = value; }
    }

    public int catMainID
    {
        get { return _catMainID; }
        set { _catMainID = value; }
    }

    public int catID
    {
        get { return _catID; }
        set { _catID = value; }
    }

    public int CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }



    public string BookID
    {
        get { return _BookID; }
        set { _BookID = value; }
    }

    public string BookRefID
    {
        get { return _BookRefID; }
        set { _BookRefID = value; }
    }


    public string EbookFileName
    {
        get { return _EbookFileName; }
        set { _EbookFileName = value; }
    }


    public string EbookFilePath
    {
        get { return _EbookFilePath; }
        set { _EbookFilePath = value; }
    }


    public string ReplySubject
    {
        get { return _ReplySubject; }
        set { _ReplySubject = value; }
    }

    public string ReplySMS
    {
        get { return _ReplySMS; }
        set { _ReplySMS = value; }
    }

    public string ReplySMSch
    {
        get { return _ReplySMSch; }
        set { _ReplySMSch = value; }
    }




    public string SenderEmailID
    {
        get { return _SenderEmailID; }
        set { _SenderEmailID = value; }
    }



    public string ReplyEmail
    {
        get { return _ReplyEmail; }
        set { _ReplyEmail = value; }
    }

    public string categoryName
    {
        get { return _categoryName; }
        set { _categoryName = value; }
    }



    public string CCmobile1
    {
        get { return _CCmobile1; }
        set { _CCmobile1 = value; }
    }

    public string CCmobile2
    {
        get { return _CCmobile2; }
        set { _CCmobile2 = value; }
    }

    public string CCmobile3
    {
        get { return _CCmobile3; }
        set { _CCmobile3 = value; }
    }


    public int MerchantID
    {
        get { return _MerchantID; }
        set { _MerchantID = value; }
    }

}