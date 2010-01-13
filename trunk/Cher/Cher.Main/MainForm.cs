using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cher.Main
{
    public partial class MainForm : Form
    {
        CherFactory factory;
        List<CUser> users;
        List<CUser> orderedUsers;
        List<CArtist> artists;

        List<XUser> xusers;
        
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
            xusers = LFMXMLReader.ReadXUsersFromXML();

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

            mainFrameUser.FindNeighbours(sm, users, neighSize);
            
            lsbNeigh.DisplayMember = "UserName";
            lsbNeigh.DataSource = mainFrameUser.Neighbours;            

            List<CArtist> suggs = mainFrameUser.Suggestions(numOfRecArtists);

            lsbRecArtists.DisplayMember = "ArtistName";
            //lsbRecArtists.DataSource = suggs;
            lsbRecArtists.DataSource = suggs.OrderBy(s => s.ArtistName).ToList();

            XUser xMainFrameUser = xusers.Find(u => u.UserName == mainFrameUser.UserName);
            if (xMainFrameUser != null)
            {
                //lsbLastFMArtists.DataSource = xMainFrameUser.XArtists.Sort();
                xMainFrameUser.XArtists.Sort();
                lsbLastFMArtists.DataSource = xMainFrameUser.XArtists;
            }
            else
            {
                lsbLastFMArtists.DataSource = null;            
            }
        }

        private void btnXMLTest_Click(object sender, EventArgs e)
        {
            List<XUser> xusers = LFMXMLReader.ReadXUsersFromXML();
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

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        
    }
}
