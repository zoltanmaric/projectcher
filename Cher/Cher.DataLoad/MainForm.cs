using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cher.DataLoad
{
    public partial class MainForm : Form
    {
        Loader loader;

        public MainForm()
        {
            InitializeComponent();

            loader = new Loader();
        }

        private void btnQuick_Click(object sender, EventArgs e)
        {
            int numTags = 0;
            int numArtists = 0;
            int numTracks = 0;
            int numUsers = 5;

            float tomValue = 45545687937024.0F;
            string baseUser = "HankChinaskii";

            //loader.FillDBUsersTest(numUsers, baseUser, tomValue);
            //loader.FillUsersTestTwo(200);
            //loader.FillUsersTestTwo(40);
            //loader.FillUsersTestTwo(10, tomValue);

            DateTime startTime = DateTime.Now;
            string result = loader.FillDBWithoutTasteRandFirstUser(30);
            DateTime endTime = DateTime.Now;

            TimeSpan timeSpan = endTime - startTime;
            string time = timeSpan.ToString();

            int baba = 0;

            //rtbResult.Text = loader.QuickTest();

            //List<string> tk = new List<string>();
            //tk.Add("baba");
            //tk.Add("zaba");

            //rtbResult.Text = tk.ToString();



            //loader.TestDB();

            //rtbResult.Text = loader.GetTagsTopArtists("rock");
            
            //rtbResult.Text = loader.GetUsersTopArtists("HankChinaskii");


        }
    }
}
