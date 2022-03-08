using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateThesisSystem.Entity;

namespace GraduateThesisSystem.Classes
{
    public static class DBConnection
    {
        public static SqlConnection con = new SqlConnection("Data Source=GEOPC\\SQLEXPRESS;Initial Catalog=TezDB;Integrated Security=True;MultipleActiveResultSets=True;");

        public static TezDBEntities db = new TezDBEntities();

    }
}
