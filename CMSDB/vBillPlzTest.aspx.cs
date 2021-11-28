using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;

public partial class vBillPlzTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string api_key = "dd9cedee-74f6-41cc-98f6-bf06caa9086b";
        string title = "sivaprasadreddy";

        //Collection collection = new Collection();

        //call the api to create collection id
        WebRequest req = WebRequest.Create(@"https://billplz-staging.herokuapp.com/api/v3/collections?title=" + title);
        req.Method = "POST";
        req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(api_key));
        HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

        if (resp.StatusCode == HttpStatusCode.OK)
        {
            // Read the response body as string
            Stream dataStream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string contents = reader.ReadToEnd();
            //collection = JsonConvert.DeserializeObject<Collection>(data);
            // collection.Id;
            resp.Close();
            Response.Write(contents.ToString());
        }
    }
}