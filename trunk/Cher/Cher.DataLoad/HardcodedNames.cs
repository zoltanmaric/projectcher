using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Cher.DataLoad
{
    public static class HardcodedNames
    {
        const string CONN_STRING_NAME = "CherDBConnString";

        public static string ConnString
        {
            get
            {
                //return ConfigurationManager.ConnectionStrings[CONN_STRING_NAME].ConnectionString;
                return "Data Source=LENOVOSTROJ;AttachDbFilename=C:\\Users\\Miroslav\\Documents\\My FER Documents\\9. Semestar\\Strojno Ucenje\\Projekt\\Baza_30_usera\\CherDB.mdf;Initial Catalog=CherDB2;Integrated Security=True;User Instance=False";
            }
        }

    }
}
