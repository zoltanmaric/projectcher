using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Lastfm.Services;

namespace Cher.DataLoad
{
    public class Loader
    {
        string API_KEY = String.Empty;
        string API_SECRET = String.Empty;        
        Session session;

        SqlConnection conn;

        public Loader()
        {
            API_KEY = "e41e31146afb3131b076f683089dbe5f";
            API_SECRET = "a6c608de15628e3b335d461e18bc471b";

            session = new Session(API_KEY, API_SECRET);

            string connstring = @"Data Source=(local)\SQL2008;Initial Catalog=CherDB;Integrated Security=True;";

            conn = new SqlConnection(connstring);
        }

        public string GetTagsTopArtists(string tagName)
        {
            Tag tag = new Tag(tagName, session);

            TopArtist[] topArtists = tag.GetTopArtists();

            string strTopArtists = String.Empty;
            foreach (TopArtist ta in topArtists)
            {
                strTopArtists += ta.Item.Name;
                strTopArtists += "\n";
            }

            return strTopArtists;
        }

        public string GetUsersTopArtists(string userName)
        {
            User user = new User(userName, session);

            TopArtist[] topArtists = user.GetTopArtists();

            string strTopArtists = String.Empty;
            foreach (TopArtist ta in topArtists)
            {
                strTopArtists += ta.Item.Name;
                strTopArtists += "\n";
            }

            return strTopArtists;
        }

        // metoda za punjenje baze podataka sa podacima dobivenim
        // od podataka prijatelja i njihovih prijatelja dok se ne dostigne
        // jedna od granicnih brojki, koje su dane ulaznim varijablama
        public void FillDBFriendsOfFriends(int numTags, int numArtists, int numTracks, int numUsers)
        {

        }




        public string Temp()
        {
            ArtistSearch ass = Artist.Search("Kings of Leon", session);
            Artist artist = new Artist("dinamo", session);
            User user = new User("dinamo", session);
            Track track = new Track(artist, "dinamo", session);
            Tag tag = new Tag("dinamo", session);
   

            //rtbResult.Text = ass.GetFirstMatch().Bio.GetSummary();
            //ass.GetFirstMatch().GetTags().First().ToString();


            // tag search
            /*
            Lastfm.Services.TagSearch ts = new TagSearch("indie", session);
            Lastfm.Services.Tag tag = ts.GetFirstMatch();
            rtbResult.Text = tag.Name;
            TopArtist[] tas = tag.GetTopArtists();
            foreach (TopArtist topar in tas)
            {
                rtbResult.Text += "\n";            
                rtbResult.Text += topar.Item.Name;
            }
            */

            /*
            // user search
            User us = new User("HankChinaskii", session);

            foreach (User usr in us.GetFriends())
            {
                foreach (TopArtist tar in usr.GetTopArtists())
                {
                    foreach (Lastfm.Services.Tag tg in tar.Item.GetTags())
                    {
                        rtbResult.Text += "\n";
                        rtbResult.Text += tg.Name;
                    }
                }
            }
            */
            /*
            rtbResult.Text += "\n";
            rtbResult.Text += usr.Name;
            */

            /*
            foreach (User usr2 in usr.GetFriends())
            {
                rtbResult.Text += "\n";
                rtbResult.Text += usr2.Name;                    
            }
            */

            return "temparica";
        }

        #region Test

        public void TestDB()
        {
            conn.Open();
            string cmdText = "insert into test values(12, 'mamic')";
            SqlCommand command = new SqlCommand(cmdText, conn);
            command.ExecuteNonQuery();
            conn.Close();
            

        }

        #endregion  
    }
}
