using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ebEntityNew
/// </summary>
public class ebEntityNew
{

    private static string _BookID;
    private static string _BookRefID;
    private static string _BookName;
    private static string _BookTitle;
    private static string _Description;

    private static decimal _Price;
    private static decimal _Discount;

    private static bool _isDisplay;
    private static bool _isFeatured;
    private static bool _isBestSeller;
    private static bool _isBuyPayPal;
    private static bool _isBuySMS;

    private static string _ImgFileName;
    private static string _ImgFilePath;

    private static string _EbookFileName;
    private static string _EbookFilePath;

    private static string _ReplySubject;
    private static string _ReplySMS;
    private static string _ReplyEmail;
    private static string _SenderEmailID;

    private static int _catID;
    private static string _categoryName;
    private static int _catMainID;

    private static string _CCmobile1;
    private static string _CCmobile2;
    private static string _CCmobile3;
    private static int _LaunchStatus;

    private static int _MerchantID;

    private static bool _isPrepaid;
    private static decimal _PrepaidPrice;


    public static int MerchantID
    {
        get { return _MerchantID; }
        set { _MerchantID = value; }

    }
    public static int LaunchStatus
    {
        get { return _LaunchStatus; }
        set { _LaunchStatus = value; }
    }


    public static string BookName
    {
        get { return _BookName; }
        set { _BookName = value; }
    }

    public static string BookTitle
    {
        get { return _BookTitle; }
        set { _BookTitle = value; }
    }


    public static string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }


    public static decimal Price
    {
        get { return _Price; }
        set { _Price = value; }
    }


    public static decimal Discount
    {
        get { return _Discount; }
        set { _Discount = value; }
    }


    public static bool isDisplay
    {
        get { return _isDisplay; }
        set { _isDisplay = value; }
    }

    public static bool isFeatured
    {
        get { return _isFeatured; }
        set { _isFeatured = value; }
    }



    public static bool isBestSeller
    {
        get { return _isBestSeller; }
        set { _isBestSeller = value; }
    }


    public static bool isBuyPayPal
    {
        get { return _isBuyPayPal; }
        set { _isBuyPayPal = value; }
    }

    public static bool isBuySMS
    {
        get { return _isBuySMS; }
        set { _isBuySMS = value; }
    }



    public static string ImgFileName
    {
        get { return _ImgFileName; }
        set { _ImgFileName = value; }
    }

    public static string ImgFilePath
    {
        get { return _ImgFilePath; }
        set { _ImgFilePath = value; }
    }


    public static int catID
    {
        get { return _catID; }
        set { _catID = value; }
    }

    public static int catMainID
    {
        get { return _catMainID; }
        set { _catMainID = value; }
    }

    public static string BookID
    {
        get { return _BookID; }
        set { _BookID = value; }
    }

    public static string BookRefID
    {
        get { return _BookRefID; }
        set { _BookRefID = value; }
    }


    public static string EbookFileName
    {
        get { return _EbookFileName; }
        set { _EbookFileName = value; }
    }


    public static string EbookFilePath
    {
        get { return _EbookFilePath; }
        set { _EbookFilePath = value; }
    }


    public static string ReplySubject
    {
        get { return _ReplySubject; }
        set { _ReplySubject = value; }
    }

    public static string ReplySMS
    {
        get { return _ReplySMS; }
        set { _ReplySMS = value; }
    }


    public static string SenderEmailID
    {
        get { return _SenderEmailID; }
        set { _SenderEmailID = value; }
    }



    public static string ReplyEmail
    {
        get { return _ReplyEmail; }
        set { _ReplyEmail = value; }
    }

    public static string categoryName
    {
        get { return _categoryName; }
        set { _categoryName = value; }
    }


    public static string CCmobile1
    {
        get { return _CCmobile1; }
        set { _CCmobile1 = value; }
    }

    public static string CCmobile2
    {
        get { return _CCmobile2; }
        set { _CCmobile2 = value; }
    }

    public static string CCmobile3
    {
        get { return _CCmobile3; }
        set { _CCmobile3 = value; }
    }

    public static bool isPrepaid
    {
        get { return _isPrepaid; }
        set { _isPrepaid = value; }
    }

    public static decimal PrepaidPrice
    {
        get { return _PrepaidPrice; }
        set { _PrepaidPrice = value; }
    }


}