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
            //rtbResult.Text = loader.GetTagsTopArtists("rock");
            
            rtbResult.Text = loader.GetUsersTopArtists("HankChinaskii");


        }
    }
}
