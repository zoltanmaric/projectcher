using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using System.Data.SqlClient;
using Lastfm.Services;
using System.Configuration;
using System.Xml.Linq;

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

            //string connstring = @"Data Source=(local)\SQL2008;Initial Catalog=CherDB;Integrated Security=True;";
            //string connstring = "Data Source=LENOVOSTROJ;AttachDbFilename=\"C:\\Users\\Miroslav\\Documents\\My FER Documents\\9. Semestar\\Strojno Ucenje\\Projekt\\Baza_30_usera\\CherDB.mdf\";Initial Catalog=CherDB2;Integrated Security=True;User Instance=False";
            conn = new SqlConnection(HardcodedNames.ConnString);
        }

        #region Publics

        public void FillDBWithoutTaste(int numUsers, string startUserName)
        {
            User startUser = new User(startUserName, session);

            List<User> usersWT = FetchUsersWT(numUsers, startUser);
            int actualUserCount = usersWT.Count;

            FillDBUserWT(usersWT);
        }

        public string FillDBWithoutTasteRandFirstUser(int numUsers)
        {
            string result = "";

            ClearCherDB();

            DateTime startTime = DateTime.Now;

            User startUser = GetRandBaseUser();

            List<User> usersWT = FetchUsersWT(numUsers, startUser);
            int actualUserCount = usersWT.Count;

            TimeSpan ts1 = DateTime.Now - startTime;

            FillDBUserWT(usersWT);

            List<Artist> artistsWT = FetchArtistsWT(usersWT);
            
            TimeSpan ts2 = DateTime.Now - startTime;

            //FillDBArtistWT(artistsWT);
            //List<Tag> tagsWT = FetchTagsWT(artistsWT);
            //FillDBTagWT(tagsWT);
            //FillDBOtherWT(usersWT);

            DateTime endTime = DateTime.Now;
            TimeSpan ts = endTime - startTime;

            //WriteTagExceptions();
            //result = "U: " + usersWT.Count.ToString() + ", A: " + artistsWT.Count.ToString() + ", T: " + tagsWT.Count.ToString();
            
            return result;
        }

        private void WriteException(Exception ex)
        {
            TextReader tr = new StreamReader("exceptions.txt");
            string oldText = tr.ReadToEnd();
            tr.Close();

            TextWriter tw = new StreamWriter("exceptions.txt");
            tw.WriteLine(oldText);
            tw.WriteLine("########## New Exception##########");
            tw.WriteLine(DateTime.Now.ToString());
            tw.WriteLine(ex.Message);
            tw.WriteLine(ex.Source);
            tw.Close();
        }

        private void ClearCherDB()
        {
            string cmdText = @"delete from [dbo].[artisttags]; ";
            cmdText += @"delete from [dbo].[tag]; ";
            cmdText += @"delete from [dbo].[userartists]; ";
            cmdText += @"delete from [dbo].[artist]; ";
            cmdText += @"delete from [dbo].[user]; ";

            SqlCommand command = new SqlCommand(cmdText, conn);

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void FillDBWithTaste(int numUsers, string startUserName, float tomHigh, int numUserBase)
        {
        }

        #endregion

        #region Privates

        List<UserArtistPair> userArtistsDone = new List<UserArtistPair>();
        List<ArtistTagPair> artistTagDone = new List<ArtistTagPair>();

        private List<Artist> FetchArtistsWT(List<User> usersWT)
        {
            List<Artist> artistsWT = new List<Artist>();
            foreach (User userWT in usersWT)
            {
                TopArtist[] topArtists;
                try
                {
                    topArtists = userWT.GetTopArtists();
                }
                catch (Exception ex)
                {
                    topArtists = userWT.GetTopArtists();                
                }

                int userID = GetUserIDByName(userWT.Name);

                foreach (TopArtist ta in topArtists)
                {
                    //string artistName = ta.Item.Name.Replace("'", "¯");

                    // ako ne postoji
                    //if (!artistsWT.Where(a => a.Name == artistName).Any())
                    // ovdje mozemo provjeravati satara imena sa ', jer su takva u listi
                    if (!artistsWT.Where(a => a.Name == ta.Item.Name).Any())
                    {
                        artistsWT.Add(ta.Item);
                        // u ovoj metodi ce ubaciti artista sa zamijenjenim ' u ¯
                        InsertArtist(ta.Item);
                    }

                    // moze usporedba po starom sa ' jer su tako i dodavani
                    if (!userArtistsDone.Where(uad => (uad.ArtistName == ta.Item.Name) && (uad.UserName == userWT.Name)).Any())
                    {
                        string artistNewName = ta.Item.Name.Replace("'", "¯");
                        //int artistID = GetArtistIDByName(ta.Item.Name);
                        int artistID = GetArtistIDByName(artistNewName);
                        InsertUsersArtist(userID, artistID, ta.Weight);
                        userArtistsDone.Add(new UserArtistPair(userWT.Name, ta.Item.Name));
                    }
                }
            }

            return artistsWT;
        }

        private List<Tag> FetchTagsWT(List<Artist> artistsWT)
        {
            List<Tag> tagsWT = new List<Tag>();
            int tagLimit = 15;

            foreach (Artist artistWT in artistsWT)
            {
                try
                {
                    TopTag[] topTags = artistWT.GetTopTags(tagLimit);
                    int artistID = GetArtistIDByName(artistWT.Name);

                    foreach (TopTag tt in topTags)
                    {
                        // ako ne postoji
                        if (!tagsWT.Where(t => t.Name == tt.Item.Name).Any())
                        {
                            tagsWT.Add(tt.Item);
                            InsertTag(tt.Item);
                        }
                        if (!artistTagDone.Where(atd => (atd.TagName == tt.Item.Name) && (atd.ArtistName == artistWT.Name)).Any())
                        {
                            int tagID = GetTagIDByName(tt.Item.Name);
                            InsertArtistsTags(artistID, tagID, tt.Weight);
                            artistTagDone.Add(new ArtistTagPair(artistWT.Name, tt.Item.Name));
                        }
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    tagExs.Add(artistWT.Name);
                }
            }

            return tagsWT;
        }

        private List<User> FetchUsersWT(int numUsers, User startUser)
        {
            List<User> usersWT = new List<User>();
            
            // za svakog pocetnog prijatelja, 
            while (usersWT.Count < numUsers)
            {
                User[] startUserFriends = startUser.GetFriends();
                foreach (User startFriend in startUserFriends)
                {
                    if (usersWT.Count >= numUsers) break;

                    User[] fofs = startFriend.GetFriends();

                    foreach (User fof in fofs)
                    {
                        if (usersWT.Count >= numUsers) break;

                        if ((!usersWT.Where(bu => bu.Name == fof.Name).Any())
                            && (!fof.Name.Contains("'")))
                        {
                            usersWT.Add(fof);
                        }
                    }
                }

                startUser = usersWT.Last();
            }

            return usersWT;           
        }

        private void FillDBUserWT(List<User> usersWT)
        {
            //conn.Open();
            foreach (User user in usersWT)
            {
                InsertUser(user);
            }
            //conn.Close();
        }

        private void InsertUser(User user)
        {
            try
            {
                conn.Open();

                //string userName = user.Name.Replace("'", "¯");
                //string cmdText = @"insert into [CherDB].[dbo].[User](username) values('" + userName + "');";
                string cmdText = @"insert into [CherDB].[dbo].[User](username, url) values('" + user.Name + "', '" + user.URL + "');";

                SqlCommand command = new SqlCommand(cmdText, conn);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
            finally
            {
                conn.Close();
            }
        }

        
        private void InsertUsersArtist(int userID, int artistID, int weight)
        {
            try
            {
                string cmdText = @"insert into [CherDB].[dbo].[UserArtists] values(" + userID.ToString() + ", " + artistID.ToString() + ", " + weight.ToString() + ");";

                SqlCommand command = new SqlCommand(cmdText, conn);

                conn.Open();
                command.ExecuteNonQuery();
                //conn.Close();
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
            finally
            {
                conn.Close();
            }
        }

        private int GetArtistIDByName(string artistName)
        {
            int artistID;
            try
            {
                artistName = artistName.Replace("'", "¯");
                //if (artistName == "Ivana_Brkic")
                //    artistName = "Ivana Brkic";
                string cmdTextUser = "select artistID from [CherDB].[dbo].[Artist] where artistname = '" + artistName + "';";
                SqlCommand userCommand = new SqlCommand(cmdTextUser, conn);

                conn.Open();
                SqlDataReader reader = userCommand.ExecuteReader();
                reader.Read();
                artistID = Convert.ToInt32(reader[0]);
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
            return artistID;
        }

        private void InsertArtist(Artist artist)
        {
            try
            {
                //string cmdText = @"insert into [CherDB].[dbo].[Artist](artistname, bio, url) values('" + artistWT.Name + "', '" + artistWT.URL + "', '" + artistWT.Bio + "');";
                string artistName = artist.Name.Replace("'", "¯");
                string cmdText = @"insert into [CherDB].[dbo].[Artist](artistname) values('" + artistName + "');";

                SqlCommand command = new SqlCommand(cmdText, conn);

                conn.Open();
                command.ExecuteNonQuery();
                //conn.Close();
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
            finally
            {
                conn.Close();            
            }
        }

        private int GetUserIDByName(string userName)
        {
            userName = userName.Replace("'", "¯");
            string cmdTextUser = "select userID from [CherDB].[dbo].[User] where UserName = '" + userName + "';";
            SqlCommand userCommand = new SqlCommand(cmdTextUser, conn);
            conn.Open();
            SqlDataReader reader = userCommand.ExecuteReader();
            reader.Read();
            int userID = Convert.ToInt32(reader[0]);
            conn.Close();

            return userID;
        }

        private void FillDBTagWT(List<Tag> tagsWT)
        {
            conn.Open();
            foreach (Tag tagWT in tagsWT)
            {
                string tagName = tagWT.Name.Replace("'", "¯");
                //string cmdText = @"insert into [CherDB].[dbo].[Tag](tagname, url) values('" + tagWT.Name + "', '" + tagWT.URL + "');";
                string cmdText = @"insert into [CherDB].[dbo].[Tag](tagname) values('" + tagName + "');";

                SqlCommand command = new SqlCommand(cmdText, conn);

                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        List<string> tagExs = new List<string>();
        
        private void InsertArtistsTags(int artistID, int tagID, int weight)
        {
            string cmdText = @"insert into [CherDB].[dbo].[ArtistTags] values(" + artistID.ToString() + ", " + tagID.ToString() + ", " + weight.ToString() + ");";

            SqlCommand command = new SqlCommand(cmdText, conn);

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        private int GetTagIDByName(string tagName)
        {
            tagName = tagName.Replace("'", "¯");
            string cmdText = "select tagID from [CherDB].[dbo].[Tag] where TagName = '" + tagName + "';";
            SqlCommand userCommand = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = userCommand.ExecuteReader();
            reader.Read();
            int tagID = Convert.ToInt32(reader[0]);
            conn.Close();

            return tagID;
        }

        private void InsertTag(Tag tag)
        {
            string tagName = tag.Name.Replace("'", "¯");
            string cmdText = @"insert into [CherDB].[dbo].[Tag](tagname) values('" + tagName + "');";

            SqlCommand command = new SqlCommand(cmdText, conn);

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public User GetRandBaseUser()
        {
            List<string> usersForBase = GetUsersForBase();
            Random randomUser = new Random(DateTime.Now.Millisecond);

            string baseUserName = usersForBase[randomUser.Next(0, usersForBase.Count)];
            User baseUser = new User(baseUserName, session);

            return baseUser;
        }

        public List<string> GetUsersForBase()
        {
            List<string> users = new List<string>();

            string cmdText = "select * from baseusers";

            SqlCommand command = new SqlCommand(cmdText, conn);
            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(reader[0].ToString());
            }

            conn.Close();

            return users;
        }

        private void FillDBArtistWT(List<Artist> artistsWT)
        {
            conn.Open();
            foreach (Artist artistWT in artistsWT)
            {
                //string cmdText = @"insert into [CherDB].[dbo].[Artist](artistname, bio, url) values('" + artistWT.Name + "', '" + artistWT.URL + "', '" + artistWT.Bio + "');";
                string artistName = artistWT.Name.Replace("'", "¯");
                string cmdText = @"insert into [CherDB].[dbo].[Artist](artistname) values('" + artistName + "');";

                SqlCommand command = new SqlCommand(cmdText, conn);

                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        private void WriteTagExceptions()
        {
            TextWriter tw = new StreamWriter("tagExs.txt");
            foreach (string tagEx in tagExs)
            {
                tw.WriteLine(DateTime.Now);
            }
            tw.Close();
        }
        
        

        #endregion

        #region Others


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

            Period p = Period.Overall;

            //TopArtist[] topArtists = user.GetTopArtists();
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

        #endregion

        #region Test

        public string QuickTest()
        {
            Tasteometer tom = new Tasteometer(new User("HankChinaskii", session), new User("cik-cak", session), session);


            return tom.GetScore().ToString();
        }

        public void TestDB()
        {
            string cmdText = @"insert into test(UserName, URL) values('b', 'r')";
            SqlCommand command = new SqlCommand(cmdText, conn);

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();

            
            //conn.Open();
            //string cmdText = "insert into test values(12, 'mamic')";
            //SqlCommand command = new SqlCommand(cmdText, conn);
            //command.ExecuteNonQuery();
            //conn.Close();
            

        }



        List<string> resultUsers = new List<string>();
        List<UserPair> compared = new List<UserPair>();
        float tomValue = 5;

        public string FillDBUsersTest(int numUsers, string inBaseUser, float inTomValue)
        {
            tomValue = inTomValue;
            try
            {
                User baseUser = new User(inBaseUser, session);

                DateTime startTime = DateTime.Now;

                GetUserRec(numUsers, baseUser);
                
                DateTime stopTime = DateTime.Now;

                TimeSpan timeSpan = stopTime - startTime;

                int sec = timeSpan.Seconds;

                //User[] baseFriends = baseUser.GetFriends();
                
                //User[] friendsOfFriends;


                /*
                string cmdText = @"insert into test(UserName, URL) values('b', 'r')";
                SqlCommand command = new SqlCommand(cmdText, conn);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                */

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "oke je";
        }

        private void GetUserRec(int numUsers, User user)
        {
            // ako broj usera nije postignut
            if (resultUsers.Count < numUsers)
            {
                User[] friends = user.GetFriends();

                foreach (User u in friends)
                {
                    if (resultUsers.Count >= numUsers) break;

                    
                    // ako user i njegov frend nisu vec usporedivani
                    if (!compared.Where(up => (up.FirstUser == user.Name && up.SecondUser == u.Name)
                                                || (up.FirstUser == u.Name && up.SecondUser == user.Name)).Any())
                    {
                        /*
                        Tasteometer tom = new Tasteometer(user, u, session);
                        float tomResult = tom.GetScore();
                        //string baba = tomResult.ToString();
                        compared.Add(new UserPair(user.Name, u.Name, tomResult));

                        // ako je taste-o-meter manji
                        if ((tomResult < tomValue) && (tomResult > 1.0F))
                        {
                            // ako se user vec ne nalazi u globalnom rezultatu
                            //if (!resultUsers.Where(ru => ru == u.Name).Any())
                            if (!resultUsers.Contains(u.Name))
                            {
                                resultUsers.Add(u.Name);
                            }                        
                        }
                        // ako nije
                        else
                        {
                            //
                        }
                        */

                        // u svakom slucaju, ako vec nisu usporedivani, pozovi rekurziju za usera
                        if (resultUsers.Count < numUsers)
                        {
                            GetUserRec(numUsers, u);
                        }
                    }
                }
            }
        }

        List<User> usersSample = new List<User>();
        private void GetUserSampleRec(int numUsers, User user)
        {
            // ako broj usera nije postignut
            if (usersSample.Count < numUsers)
            {
                User[] friends = user.GetFriends();

                foreach (User u in friends)
                {
                    // ako vec nije dodan
                    if (!usersSample.Any(us => us.Name == u.Name))
                    {
                        if (usersSample.Count < numUsers)
                        {
                            usersSample.Add(u);
                        }
                    }
                }

                // ovdje bi se mogao primijeniti tasteometer sa svim prijateljima, 
                // pa u rekurziju predati onaj s njamanjim
                //    foreach (User u in friends)
                //    {
                //        GetUserRec(numUsers, u);
                //    }                        
                Random rand = new Random(DateTime.Now.Millisecond);
                int nextUserNum = rand.Next(0, friends.Length);
                User nextUser = friends[nextUserNum];
                GetUserSampleRec(numUsers, nextUser);
            }
        }


        public void FillUsersTestTwo(int numUsers, float tomResultHigh)
        {
            //User cmicma = GetBaseUser();

            //GetUserSampleRec(numUsers, cmicma);

            //FillUserSampleDB();

            FillUserDB(numUsers, tomResultHigh);
        }

        private void FillUserDB(int numUsers, float tomResultHigh)
        {
            List<string> stringSampleUsers = new List<string>();

            string cmdText = "select * from sampleusers";
            SqlCommand command = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                stringSampleUsers.Add(reader[0].ToString());
            }
            conn.Close();

            List<User> sampleUsers = new List<User>();
            foreach (string ssu in stringSampleUsers)
            {
                sampleUsers.Add(new User(ssu, session));                
            }

            List<User> resultUsersDB = new List<User>();
            List<float> tomResults = new List<float>();
            resultUsersDB.Add(sampleUsers.First());
            foreach (User sampleUser in sampleUsers)
            {
                if (resultUsersDB.Count >= numUsers) break;

                int sampleUserIndex = sampleUsers.IndexOf(sampleUser);
                List<User> usersToCompare = sampleUsers.GetRange(sampleUserIndex + 1, sampleUsers.Count - sampleUserIndex - 1);

                foreach (User userToCompare in usersToCompare)
                {
                    if (resultUsersDB.Count >= numUsers) break;

                    Tasteometer tom = new Tasteometer(sampleUser, userToCompare, session);
                    float tomResult = tom.GetScore();
                    if (tomResult <= tomResultHigh)
                    {
                        // ako korisnik nije vec dodan
                        if (!resultUsersDB.Where(rudb => rudb.Name == userToCompare.Name).Any())
                        {
                            resultUsersDB.Add(userToCompare);
                            tomResults.Add(tomResult);
                        }
                    }
                }            
            }

            conn.Open();
            foreach (User user in resultUsersDB)
            {
                string cmdTxt = @"insert into dbo.[User](username, url) values ('" + user.Name + "', '" + user.URL + "');";
                SqlCommand cmd = new SqlCommand(cmdTxt, conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        private void FillUserSampleDB()
        {
            string cmdText = "";

            conn.Open();
            foreach (User user in usersSample)
            {
                cmdText = @"insert into sampleusers values('" + user.Name + "');";
                SqlCommand command = new SqlCommand(cmdText, conn);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }



        private void FillDBForBaseUser()
        {
            string startUserName = "Oblachica"; // 129 prijatelja
            int numUsers = 500;

            User startUser = new User(startUserName, session);

            User[] baseFriends = startUser.GetFriends();
            //User[] baseUsers = new User[baseFriends.Length];
            //List<User> baseUsers = baseFriends.ToList();
            List<User> baseUsers = new List<User>();

            //Array.Copy(baseFriends, baseUsers, baseFriends.Length);

            foreach (User baseFriend in baseFriends)
            {
                if (baseUsers.Count >= numUsers) break;

                User[] fofs = baseFriend.GetFriends();

                foreach (User fof in fofs)
                {
                    if (baseUsers.Count >= numUsers) break;
                    if (!baseUsers.Where(bu => bu.Name == fof.Name).Any())
                    {
                        baseUsers.Add(fof);
                    }
                }
            }

            foreach (User bu in baseUsers)
            {
                string cmdText = "insert into baseusers values('" + bu.Name + "');";
                SqlCommand command = new SqlCommand(cmdText, conn);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        #endregion  
    
        public string FillOneUser(string username)
        {
            string result = "";

            User oneUser = new User(username, session);
            
            if (oneUser == null)
            {
                return username + " ne postoji";
            }

            TopArtist[] topArtists;
            try
            {
                topArtists = oneUser.GetTopArtists(Period.ThreeMonths);
            }
            catch (Exception ex)
            {
                if (ex.Message == "InvalidParameters: No user with that name")  return "korisnika nema na last.fmu";
                topArtists = oneUser.GetTopArtists(Period.ThreeMonths);
            }
            
            InsertUser(oneUser);

            int userID = GetUserIDByName(oneUser.Name);

            foreach (TopArtist ta in topArtists)
            {
                // ako artist ne postoji u bazi
                if (!ArtistExistsInDB(ta.Item.Name))
                {
                    InsertArtist(ta.Item);
                }

                string artistNewName = ta.Item.Name.Replace("'", "¯");
                //int artistID = GetArtistIDByName(ta.Item.Name);
                int artistID = GetArtistIDByName(artistNewName);
                InsertUsersArtist(userID, artistID, ta.Weight);                
            }

            return "success";
        }

        public bool ArtistExistsInDB(string artistName)
        {
            try
            {
                string artistNewName = artistName.Replace("'", "¯");
                        
                string cmdText = @"select * from [dbo].[artist] where artistName like '" + artistNewName + "';";
                
                SqlCommand command = new SqlCommand(cmdText, conn);
                
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
            finally
            {
                conn.Close();
            }

            return false;
        }

        public bool UserExistsInDB(string username)
        {
            try
            {
                string userNewName = username.Replace("'", "¯");

                string cmdText = @"select * from [dbo].[user] where userName like '" + userNewName + "';";

                SqlCommand command = new SqlCommand(cmdText, conn);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
            finally
            {
                conn.Close();
            }

            return false;
        }

        public void InsertFromXML()
        {
            //string file = "lastfm_29.xml";
            string file = "lastfm_35.xml";
            
            XDocument xfm = XDocument.Load(file);

            var xmlUsers = from u in xfm.Descendants("user")
                           select u.Attribute("name").Value.ToString();

            List<string> users = xmlUsers.ToList();

            
            foreach (string user in users)
            {
                if (!UserExistsInDB(user))
                {
                    string result = FillOneUser(user);                    
                }
            } 
            
        }
    }

    public class UserPair
    {
        string firstUser = "";
        public string FirstUser
        {
          get { return firstUser; }
          set { firstUser = value; }
        }
        string secondUser = "";

        public string SecondUser
        {
          get { return secondUser; }
          set { secondUser = value; }
        }

        float tomResult = 0F;

        public float TomResult
        {
            get { return tomResult; }
            set { tomResult = value; }
        }
        public UserPair(string firstUser, string secondUser, float tomResult)
        {
            this.firstUser = firstUser;
            this.secondUser = secondUser;
            this.tomResult = tomResult;
        }
    }

    public class UserArtistPair
    {
        string userName = "";

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        string artistName = "";

        public string ArtistName
        {
            get { return artistName; }
            set { artistName = value; }
        }
        public UserArtistPair(string userName, string artistName)
        {
            this.userName = userName;
            this.artistName = artistName;
        }

    }

    public class ArtistTagPair
    {
        string tagName = "";

        public string TagName
        {
            get { return tagName; }
            set { tagName = value; }
        }
        string artistName = "";

        public string ArtistName
        {
            get { return artistName; }
            set { artistName = value; }
        }
        public ArtistTagPair(string artistName, string tagName)
        {
            this.artistName = artistName;
            this.tagName = tagName;
        }

    }
}
