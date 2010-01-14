using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lastfm.Services;

public partial class _Default : System.Web.UI.Page 
{
    AuthenticatedUser authUser;
        
    protected void Page_Load(object sender, EventArgs e)
    {
            
        if (!Request.QueryString.AllKeys.Contains("token"))
        {
            btnGrantPermission.Visible = true;
            litText.Text =
                "This site is made by couple students from Faculty of Electrical Engineering and Computing in Zagreb, Croatia. " +
                    "Site is intended for educational use only and none of your credentials will be stored or used, " +
                "this is a standard procedure of Last.fm to allow developers to access your data such as reccommended artists." +
                "Your reccommended artists are needed for a research in our college project. " +
                "Please press the link below and allow us to store your reccommended artists! :) " +
                "<br/>Thank you!";
            litIHaveHeardAbout.Visible = false;
            ddlFirst.Visible = false;
            ddlSecond.Visible = false;
            btnSubmit.Visible = false;
        }
        else if(Request.QueryString.AllKeys.Contains("token"))
        {
            litIHaveHeardAbout.Visible = true;
            ddlFirst.Visible = true;
            ddlFirst.Items.Add("1");
            ddlFirst.Items.Add("2");
            ddlFirst.Items.Add("3");
            ddlFirst.Items.Add("4");
            ddlFirst.Items.Add("5");
            ddlSecond.Visible = true;
            ddlSecond.Items.Add("1");
            ddlSecond.Items.Add("2");
            ddlSecond.Items.Add("3");
            ddlSecond.Items.Add("4");
            ddlSecond.Items.Add("5");
            btnSubmit.Visible = true;
            litText.Text = "";
            btnGrantPermission.Visible = false;
            string token = Request.QueryString.Get("token");

            RecommendedArtists recArtists = ReccommendedArtist.GetReccommendedArtists(token, Server.MapPath("~/RecArtists.xml"), out authUser);
            //Response.Write("last.fm recommends you these Artists:<br/>");

            Response.Write("The first recommendation is a list of artists that are recommended for you by last.fm.<br/>");
            Response.Write("The second list are recommendations based on our algorithm. Please tell us what you think about our(second) recommendation<br/>");

            Response.Write("<table>");
            Response.Write("<tr>");
            Response.Write("<td>");
            Response.Write("<br>First recommendation<br/><br>");
            Response.Write("</td");
            Response.Write("<td>");
            Response.Write("<br>Second recommendation<br/><br>");
            Response.Write("</td");
            Response.Write("</tr>");

            Response.Write("<tr>");
            Response.Write("<td>");
            int maxResults = 30;
            int j = 0;
            for (int i = 1; i < recArtists.GetPageCount(); i++)
            {
                Artist[] artists = recArtists.GetPage(i);

                foreach (Artist artist in artists)
                {
                    Response.Write(artist.Name + "<br/>");
                    j++;
                    if(j==maxResults)
                    {
                        break;
                    }
                }
                if(j==maxResults)
                {
                    break;
                }
            }
            Response.Write("</td");
            Response.Write("<td>");
            List<string> recArtistsByUs = ReccommendedArtist.GetRecommendedArtistsByUs(Server.MapPath("~/RecArtistsByUs.xml"), authUser.Name);
            int k = 0;
            if (recArtistsByUs != null)
            {
                foreach (string artistName in recArtistsByUs)
                {
                    Response.Write(artistName + "<br/>");
                    if (k == 30)
                    {
                        break;
                    }
                }
            }
            Response.Write("</td");
            Response.Write("</tr>");

            Response.Write("<tr>");
            Response.Write("<td>");
            Response.Write("</td");
            Response.Write("<td>");
            Response.Write("</td");
            Response.Write("</tr>");
            Response.Write("</table>");

            //LastfmXMLWriter.Write("RecArtists.xml", 
        }
    }

    protected void btnGrantPermission_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("http://www.last.fm/api/auth/?api_key=" + SessionInfo.ApiKey);
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("ThankYou.aspx?username=" + authUser.Name + "&r1=" + ddlFirst.SelectedValue + "&r2=" + ddlSecond.SelectedValue);
    }
}
