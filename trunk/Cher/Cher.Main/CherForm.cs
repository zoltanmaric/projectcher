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
    public partial class CherForm : Form
    {
        CherFactory factory;
        List<CUser> users;
        List<CArtist> artists;

        public CherForm()
        {
            InitializeComponent();

            factory = new CherFactory();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            users = factory.LoadUsers();
            artists = factory.LoadArtists();
            factory.LoadUserArtists(users, artists);

            usersLstBox.BeginUpdate();
            usersLstBox.Items.Clear();
            usersLstBox.Items.AddRange(users.ToArray());
            usersLstBox.EndUpdate();
        }

        private void usersLstBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CUser user = (CUser)usersLstBox.SelectedItem;

            artistsLstBox.BeginUpdate();
            artistsLstBox.Items.Clear();
            artistsLstBox.Items.AddRange(user.Artists.ToArray());
            artistsLstBox.EndUpdate();

            scoresLstBox.BeginUpdate();
            scoresLstBox.Items.Clear();
            foreach (long numListen in user.ArtistNumListens)
            {
                scoresLstBox.Items.Add(numListen);
            }
            scoresLstBox.EndUpdate();
        }

        private void artistsLstBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            scoresLstBox.SelectedIndex = artistsLstBox.SelectedIndex;
        }
    }
}
