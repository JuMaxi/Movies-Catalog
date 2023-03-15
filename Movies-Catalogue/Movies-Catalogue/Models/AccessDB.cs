using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace Movies_Catalogue.Models
{
    public class AccessDB
    {
        string ConnectionString = "Server=LAPTOP-P4GEIO8K\\SQLEXPRESS;Database=MoviesCatalogue;User Id=sa;Password=S4root;";

        public void AccessNonQuery(string Action)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            {
                SqlCommand Command = new SqlCommand(Action, Connection);
                Connection.Open();

                Command.ExecuteNonQuery();
            }
        }
        public SqlDataReader AccessReader(string Action)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);

            SqlCommand Command = new SqlCommand(Action, Connection);
            Connection.Open();

            SqlDataReader Reader = Command.ExecuteReader();

            return Reader;
        }
    }
}
