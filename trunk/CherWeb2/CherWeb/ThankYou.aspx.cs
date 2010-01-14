using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ThankYou : System.Web.UI.Page
{
    string username;
    string r1;
    string r2;

    protected void Page_Load(object sender, EventArgs e)
    {
        username = Request.QueryString["username"];
        r1 = Request.QueryString["r1"];
        r2 = Request.QueryString["r2"];

        List<string> recArtistsByUs = ReccommendedArtist.GetRecommendedArtistsByUs(Server.MapPath("~/RecArtistsByUs.xml"), username);
        int k = 0;
        if (recArtistsByUs != null)
        {
            foreach (string artistName in recArtistsByUs)
            {
                litReccomendations.Text += artistName + "<br/>";
                if (k == 30)
                {
                    break;
                }
                k++;
            }
        }
        for (int i = 0; i < k + 1; i++)
        {
            ddlRemark.Items.Add(i.ToString());
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        LastfmXMLWriter.WriteEvaluations(Server.MapPath("~/Evaluations.xml"), username, r1, r2, ddlRemark.SelectedValue);

        Response.Redirect("ThankYouVeryMuch.aspx");
    }
}
