using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for GlobalVar
/// </summary>
public class GlobalVar
{
    public GlobalVar()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetDbConnString
    {
        get
        {
            return ConfigurationManager.AppSettings["CMSdb"].ToString();
        }
    }


    public static string Get_IFM_DbConnString
    {
        get
        {
            return ConfigurationManager.AppSettings["IFMdb"].ToString();
        }
    }


    public static string GetWebsiteName
    {
        get
        {
            return ConfigurationManager.AppSettings["WebSiteName"].ToString();
        }
    }

    public static string GetAnchorDomainName
    {
        get
        {
            return ConfigurationManager.AppSettings["AnchorDomainName"].ToString();
        }
    }


    public static string GetEbookDomainName
    {
        get
        {
            return ConfigurationManager.AppSettings["EbookDomainName"].ToString();
        }
    }


    public static string GetEmailRecipientList1
    {
        get
        {
            return ConfigurationManager.AppSettings["EmailRcpList1"].ToString();
        }
    }

    public static string GetEmailRecipientList2
    {
        get
        {
            return ConfigurationManager.AppSettings["EmailRcpList2"].ToString();
        }
    }


    public static string GetSMSRecipientList
    {
        get
        {
            return ConfigurationManager.AppSettings["SMSRcpList"].ToString();
        }
    }


    public static string GetTestLoginUser
    {
        get
        {
            return ConfigurationManager.AppSettings["TestLoginUser"].ToString();
        }
    }


    public static string GetImgStoreFolder
    {
        get
        {
            return ConfigurationManager.AppSettings["ImgStoreFolder"].ToString();
        }
    }


    public enum ImageTypeEnums
    {
        UserImage = 1,              // User photo used to show user profile.
        TestimonialImage = 2,       // Could be Users photo to be shown along with Testimonial 
        LogoImage = 3,              // User's Company Logo image
        BannerImage = 4,            // HomePage Banner Img
        ProductImage = 5,           // Product Image
        OtherImage = 6,             // other Misc Image       
        AnchorImage = 7,             // Anchor Image, used to Mobile web Template 
        WP_BottomImage = 8,          // WebPicture Bottom Image, used to web Template 
        WP_SideImage = 9          // WebPicture Side Image, used to web Template 


    }

    public enum EnquiryTypes
    {
        ContactUs = 1,              // Enquiry from contact us Page
        FreeSMS = 2                 // Enquiry from Free SMS page
    }

    public enum ProductTypes
    {
        Product = 1,                // Defualt product type
        Entrepreneur = 2            // Entrepreneur program type
    }

    public enum ListingUserTypesEnums
    {
        USER = 0 , 
        ADMIN = 2
    }


    public enum UserLoginFrom
    {
        BizPartnerLogin = 1,        // Defualt main page login 
        CustSMSlogin = 2,            // Customer Logins -  SMS login 
        CustWeblogin = 3,            // Customer Logins -  Web Portal login 
        CustBizlogin = 4,            // Customer Logins -  Biz Partner login 
        webEmailSMSlogin = 5,        // Web Email SMS login 
        MobileSecLogin = 11,         // Mobile Secretary Login 
        Premium3way = 12,            // Premium SMS 3 way 
        eBiz3wayLogin = 13,           // eBiz Login www.smseBusiness.com 
        eBiz1wayLogin = 14           // www.smslogin.com
    }

    public class StringValueAttribute : System.Attribute
    {

        private string _value;

        public StringValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }


    public const string Lang_English = "en-US";
    public const string Lang_BahasaMalay = "ms-MY";
    public const string Lang_SimplifedChinese = "zh-CN";


    public enum LanguagueEnums
    {
        //Lang_English = "en-US",
        //Lang_BahasaMalay = "ms-MY",
        //Lang_SimplifedChinese = "zh-CN"
        
    [StringValue("en-US")] Lang_English = 1,
    [StringValue("ms-MY")] Lang_BahasaMalay = 2,
    [StringValue("zh-CN")] Lang_SimplifedChinese = 3

    }


    public enum EbookTypes
    {
        eBook    = 1,                // Defualt Ebook type
        FeatureBuy = 2,             // Feature Buy
        BestSeller = 3,             // Best Seller
        ValueBuy = 4,                // Value buy 
        FreeEbook = 5,                // Free Ebook
        NewRelease = 6                  // New Release
    }


    public enum EbookCategoryType
    {
        Admin = 1,               
        User = 2             
      
    }


}
