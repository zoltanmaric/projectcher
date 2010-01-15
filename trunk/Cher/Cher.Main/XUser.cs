using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cher.Main
{
    public class XUser
    {
        string userName = "";
        List<string> xArtists;

        public XUser(string username)
        {
            userName = username;
            xArtists = new List<string>();
        }

        public XUser(string username, List<string> xartists)
        {
            userName = username;
            xArtists = xartists;
        }

        public List<string> XArtists
        {
            get { return xArtists; }
            set { xArtists = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}
