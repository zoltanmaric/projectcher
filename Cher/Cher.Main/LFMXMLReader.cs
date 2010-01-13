using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace Cher.Main
{
    public static class LFMXMLReader
    {
        public static List<XUser> ReadXUsersFromXML()
        {
            List<XUser> xusers = new List<XUser>();

            XDocument xfm = XDocument.Load("lastfm_29.xml");

            var xmlUsers = from u in xfm.Descendants("user")
                           select u;

            foreach (var user in xmlUsers)
            {
                XUser xuser = new XUser(user.Attribute("name").Value);

                var xartists = from a in user.Descendants("preporuka_benda")
                               select a.Value.Replace("'", "¯");

                xuser.XArtists = xartists.ToList();

                xusers.Add(xuser);
            }

            return xusers;
        }

    }
}
