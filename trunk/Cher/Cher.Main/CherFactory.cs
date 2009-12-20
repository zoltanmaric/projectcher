using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

namespace Cher.Main
{
    class CherFactory
    {
        SqlConnection conn;

        public CherFactory()
        {
            string connstring = @"Data Source=(local);Initial Catalog=CherDB;Integrated Security=True;";   
            conn = new SqlConnection(connstring);
        }

        public List<CUser> LoadUsers()
        {
            List<CUser> users = new List<CUser>();

            conn.Open();
            users = loadUserTable();
            conn.Close();

            return users;
        }

        public List<CArtist> LoadArtists()
        {
            List<CArtist> artists = new List<CArtist>();

            conn.Open();
            artists = loadArtistTable();
            conn.Close();

            return artists;
        }

        public void LoadUserArtists(List<CUser> users, List<CArtist> artists)
        {
            conn.Open();
            loadUserArtistsTable(users, artists);
            conn.Close();
        }

        #region privates
        private List<CUser> loadUserTable()
        {
            List<CUser> users = new List<CUser>();

            string cmdText = @"select * from [CherDB].[dbo].[User]";
            SqlCommand command = new SqlCommand(cmdText, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int userID = (int)reader["UserID"];
                string userName = (string)reader["UserName"];
                string url = null;
                if (reader["URL"] != System.DBNull.Value)
                {
                    url = (string)reader["URL"];
                }
                users.Add(new CUser(userID, userName, url));
            }

            return users;
        }

        private List<CArtist> loadArtistTable()
        {
            List<CArtist> artists = new List<CArtist>();

            string cmdText = @"select * from [CherDB].[dbo].[Artist]";
            SqlCommand command = new SqlCommand(cmdText, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int artistID = (int)reader["ArtistID"];
                string artistName = (string)reader["ArtistName"];

                string bio = null;
                if (reader["Bio"] != System.DBNull.Value)
                {
                    bio = (string)reader["URL"];
                }

                string url = null;
                if (reader["URL"] != System.DBNull.Value)
                {
                    url = (string)reader["URL"];
                }
                artists.Add(new CArtist(artistID, artistName, bio, url));
            }

            return artists;
        }

        /// <summary>
        /// Ažurira userovu listu artista i artistovu
        /// listu usera prema tablici UserArtists iz baze.
        /// </summary>
        /// <param name="users">Lista svih usera prethodno dobivena metodom LoadUsers().</param>
        /// <param name="artists">Lista svih artista prethodno dobivena metodom LoadArtists().</param>
        private void loadUserArtistsTable(List<CUser> users, List<CArtist> artists)
        {
            string cmdText = @"select * from [CherDB].[dbo].[UserArtists]";
            SqlCommand command = new SqlCommand(cmdText, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // pronađi usera čiji je ID u pročitanom retku
                CUser user = users.Where(x => x.UserID == (int) reader["UserID"]).First();
                // pronađi artista čiji je ID u pročitanom retku
                CArtist artist = artists.Where(x => x.ArtistIndex == (int)reader["ArtistID"]).First();
                // dodaj im reference
                user.AddArtist(artist);
                user.AddArtistScore((int)reader["Rank"]);
                artist.AddUser(user);
            }
        }
        #endregion
    }
}
