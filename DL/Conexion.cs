using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DL
{
    public class Conexion
    {
        public static string getCadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["Cadena"].ToString();
        }

        public static SqlCommand CreateCommand(string Query,SqlConnection context)
        {
            context.Open();
            SqlCommand cmd = new SqlCommand(Query,context);
            return cmd;
        }

        public static int ExecuteComand(SqlCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        public static DataTable ExecuteCommandSelect(SqlCommand cmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
            
        }
    }
}
