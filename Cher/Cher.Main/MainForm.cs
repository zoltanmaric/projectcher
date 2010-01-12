using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cher.Main
{
    public partial class MainForm : Form
    {
        CherFactory factory;
        List<CUser> users;
        List<CUser> orderedUsers;
        List<CArtist> artists;

        SimilarityMatrix sm;

        public MainForm()
        {
            InitializeComponent();

            factory = new CherFactory();

            txtArtistSize.Text = "20";
            txtNeighSize.Text = "20";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            users = factory.LoadUsers();
            artists = factory.LoadArtists();
            factory.LoadUserArtists(users, artists);

            orderedUsers = (from u in users
                           orderby u.UserName
                           select u).ToList();

            
            usersLstBox.DisplayMember = "UserName";
            usersLstBox.DataSource = orderedUsers;

            sm = new SimilarityMatrix(users);            
        }

        private void btnRecommend_Click(object sender, EventArgs e)
        {
            int neighSize = 20;
            int numOfRecArtists = 10;

            if (txtNeighSize.Text != "")
            {
                neighSize = Convert.ToInt32(txtNeighSize.Text);
            }
            
            if (txtArtistSize.Text != "")
            {
                numOfRecArtists = Convert.ToInt32(txtArtistSize.Text);
            }

            CUser mainFrameUser = usersLstBox.SelectedItem as CUser;

            Neighbourhood.SimilarityMatrix = sm;
            
            List<CUser> neigh = Neighbourhood.GetNeighbourhood(mainFrameUser, users, neighSize);

            lsbNeigh.DisplayMember = "UserName";
            lsbNeigh.DataSource = neigh;            

            mainFrameUser.Neighbours = neigh;
            List<CArtist> suggs = mainFrameUser.Suggestions(numOfRecArtists);

            lsbRecArtists.DisplayMember = "ArtistName";
            lsbRecArtists.DataSource = suggs;            

        }

        private void btnXMLTest_Click(object sender, EventArgs e)
        {
            List<XUser> xusers = new List<XUser>();
            
            XDocument xfm = XDocument.Load("lastfm.xml");

            var xmlUsers = from u in xfm.Descendants("user")
                           select u;
            
            foreach (var user in xmlUsers)
            {
                XUser xuser = new XUser(user.Attribute("name").Value);

                var xartists = from a in user.Descendants("preporuka_benda")
                               select a.Value;

                xuser.XArtists = xartists.ToList();

                xusers.Add(xuser);
            }


        }
    }

    public class XUser
    {
        string userName = "";

        List<string> xArtists;

        public XUser(string username)
        {
            userName = username;
            xArtists = new List<string>();
        }

        public XUser(string username, List<string> xartists)
        {
            userName = username;
            xArtists = xartists;
        }

        public List<string> XArtists
        {
            get { return xArtists; }
            set { xArtists = value; }
        }
    }
}
