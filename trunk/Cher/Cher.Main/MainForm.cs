using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;


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

        CUser mainFrameUser;
        List<CArtist> recommendedArtists;
        List<string> lfmRecommendedArtists;

        public MainForm()
        {
            InitializeComponent();
            btnRecommend.Enabled = false;

            factory = new CherFactory();

            txtArtistSize.Text = "30";
            txtNeighSize.Text = "30";
            txtWk.Text = "0.5";
            txtWe.Text = "0.5";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;

            lblDBLoadStatus.Text = "Učitavam bazu...";
            lblDBLoadStatus.Show();
            this.Update();
            
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
            btnRecommend.Enabled = true;

            lblDBLoadStatus.Text = "Gotovo!";
        }

        private void btnRecommend_Click(object sender, EventArgs e)
        {
            Recommend();

            Evaluate();

            GenerateXMLForUser();
        }

        private void GenerateXMLForUser()
        {
                
        }

        private void Evaluate()
        {
            if (lfmRecommendedArtists == null)
            {
                lblEvaluation.Text = "No Last.FM recommendations found";
                return;
            }

            Evaluator evaluator = new Evaluator();
            evaluator.AddUserWithRecommendations(mainFrameUser, recommendedArtists, lfmRecommendedArtists);
            Results resultsA = evaluator.CalculateResultsA();

            if (resultsA != null)
            {
                txtMacroPrecision.Text = resultsA.MacroPrecision.ToString();
                txtMacroRecall.Text = resultsA.MacroRecall.ToString();
                txtMacroF1.Text = resultsA.MacroF1.ToString();
                txtMicroPrecision.Text = resultsA.MicroPrecision.ToString();
                txtMicroRecall.Text = resultsA.MicroRecall.ToString();
                txtMicroF1.Text = resultsA.MicroF1.ToString();
            }
                
        }

        private void Recommend()
        {
            int neighSize = 20;
            int numOfRecArtists = 10;
            decimal wk = 0.5M;
            decimal we = 0.5M;

            if (txtNeighSize.Text != "")
            {
                neighSize = Convert.ToInt32(txtNeighSize.Text);
            }

            if (txtArtistSize.Text != "")
            {
                numOfRecArtists = Convert.ToInt32(txtArtistSize.Text);
            }

            if (txtWk.Text != "")
            {
                wk = Convert.ToDecimal(txtWk.Text);
            }

            if (txtWe.Text != "")
            {
                we = Convert.ToDecimal(txtWe.Text);
            }

            mainFrameUser = usersLstBox.SelectedItem as CUser;

            mainFrameUser.FindNeighbours(sm, users, neighSize);

            lsbNeigh.DisplayMember = "UserName";
            lsbNeigh.DataSource = mainFrameUser.Neighbours;

            recommendedArtists = mainFrameUser.Suggestions(numOfRecArtists, wk, we);


            lsbRecArtists.DisplayMember = "ArtistName";
            //lsbRecArtists.DataSource = suggs;
            lsbRecArtists.DataSource = recommendedArtists.OrderBy(s => s.ArtistName).ToList();

            XUser xMainFrameUser = xusers.Find(u => u.UserName == mainFrameUser.UserName);
            if (xMainFrameUser != null)
            {
                lfmRecommendedArtists = xMainFrameUser.XArtists;
                //lsbLastFMArtists.DataSource = xMainFrameUser.XArtists.Sort();
                lfmRecommendedArtists.Sort();
                lsbLastFMArtists.DataSource = xMainFrameUser.XArtists;
            }
            else
            {
                lfmRecommendedArtists = null;
                lsbLastFMArtists.DataSource = null;
            }
        }

        private void btnEval_Click(object sender, EventArgs e)
        {
            CalcAverageScores();

            GenXMLForWeb();
        }

        private void CalcAverageScores()
        {
            //throw new NotImplementedException();
        }

        private void GenXMLForWeb()
        {
            IEnumerable<CUser> cFriendUsers = from u in users
                               where xusers.Where(xu => xu.UserName == u.UserName).Any()
                               select u;

            

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
