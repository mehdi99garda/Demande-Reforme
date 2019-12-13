using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demande_Reforme
{
    class ConnectionDB
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-740ARVG\SQLEXPRESS;Initial Catalog=gestion_ocp;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();
        public DataTable dt = new DataTable();
    }
}
