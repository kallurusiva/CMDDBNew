using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for TestWs
/// This a test webservice 
/// </summary>
[WebService(Namespace = "http://1smsbusiness.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TestWs : System.Web.Services.WebService
{

    private string[] movieList = { "The Godfather (1972)",
                                    "The Shawshank Redemption (1994)",
                                    "The Godfather: Part II (1974)",
                                    "The Lord of the Rings: The Return of the King (2003)",
                                    "Casablanca", "Schindler's List",
                                    "Shichinin no samurai (1954)",
                                    "Buono, il brutto, il cattivo, Il (1966)",
                                    "Pulp Fiction (1994)",
                                    "Star Wars: Episode V - The Empire Strikes Back (1980)"};

    [WebMethod]
    public string[] GetTop10()
    {
        return movieList;
    }


    [WebMethod]
    public string GetMovieAtNumber(int input)
    {
        return movieList[input];
    }



    public TestWs()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

}

