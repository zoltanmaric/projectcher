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
    public partial class Form1 : Form
    {
        CherFactory factory;

        public Form1()
        {
            InitializeComponent();

            factory = new CherFactory();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            List<CUser> users = factory.LoadUsers();
            List<CArtist> artists = factory.LoadArtists();
            factory.LoadUserArtists(users, artists);
            int i = 0;
        }
    }
}
