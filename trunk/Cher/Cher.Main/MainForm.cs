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

        SimilarityMatrix sm;

        public MainForm()
        {
            InitializeComponent();

            factory = new CherFactory();        
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
    }
}
