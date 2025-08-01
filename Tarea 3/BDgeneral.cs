using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tarea_3
{
    public class BDgeneral
    {
        public static SqlConnection ObtnerConexion() {

            SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Tarea3;Data Source=DESKTOP-MR00KK7");
            conn.Open();


            return conn;
        }
    }
} 
