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
using System.Xml;


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
            IEnumerable<CUser> cFriendUsers = from u in users
                                              where xusers.Where(xu => xu.UserName == u.UserName).Any()
                                              select u;

            Evaluator eval = new Evaluator();
            XDocument xmlDoc = new XDocument();
            XElement root = new XElement("users");

            foreach (CUser user in cFriendUsers)
            {
                user.FindNeighbours(sm, users, int.Parse(txtNeighSize.Text));
                List<CArtist> suggs = user.Suggestions(int.Parse(txtArtistSize.Text), decimal.Parse(txtWk.Text), decimal.Parse(txtWe.Text));

                XUser xuser = (from xu in xusers
                               where xu.UserName == user.UserName
                               select xu).First();

                eval.AddUserWithRecommendations(user, suggs, xuser.XArtists);

                XElement xmluser = new XElement("user");
                XAttribute username = new XAttribute("username", user.UserName);
                xmluser.SetAttributeValue("username", user.UserName);

                foreach (CArtist sugg in suggs)
                {
                    XElement xmlsugg = new XElement("artist", sugg.ArtistName);
                    xmluser.Add(xmlsugg);
                }

                root.Add(xmluser);                
            }
            xmlDoc.Add(root);

            xmlDoc.Save("cher_preporuke.xml");

            Results resultsA = eval.CalculateResultsA();

            txtMacroPrecision.Text = resultsA.MacroPrecision.ToString();
            txtMacroRecall.Text = resultsA.MacroRecall.ToString();
            txtMacroF1.Text = resultsA.MacroF1.ToString();
            txtMicroPrecision.Text = resultsA.MicroPrecision.ToString();
            txtMicroRecall.Text = resultsA.MicroRecall.ToString();
            txtMicroF1.Text = resultsA.MicroF1.ToString();


            CalcAverageScores();

            GenXMLForWeb();
        }

        private void CalcAverageScores()
        {

        }

        private void GenXMLForWeb()
        {
        }
    }
}
