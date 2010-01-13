﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cher.Main
{
    public partial class TestForm : Form
    {
        CherFactory factory;
        List<CUser> users;
        List<CArtist> artists;
        
        const int numberOfNeighbours = 7;
        const int numberOfSuggestions = 10;            

        public TestForm()
        {
            InitializeComponent();
        }

        private void btnQuick_Click(object sender, EventArgs e)
        {
            factory = new CherFactory();
            users = factory.LoadUsers();
            artists = factory.LoadArtists();
            factory.LoadUserArtists(users, artists);
            
            SimilarityMatrix sm = new SimilarityMatrix(users);
            //Neighbourhood.SimilarityMatrix = sm;

            decimal wk = 0.5M;
            decimal we = 0.5M;

            CUser mainFrameUser = (from u in users
                                   where (u.UserName == "Oblachica")
                                   select u).First();

            mainFrameUser.FindNeighbours(sm, users, numberOfNeighbours);
            List<CArtist> suggs = mainFrameUser.Suggestions(numberOfSuggestions, wk, we);

            int babetinga = 0;
        }

    }
}
