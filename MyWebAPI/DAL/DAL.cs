using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI
{
    public class DAL
    {
        private string ConnectionString = @"Data Source=WILL-NOTE\SQLEXPRESS;Initial Catalog=dbcliente;Integrated Security=True";
        private SqlConnection Connection;
        public DAL()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }
        //executa comandos como insert,update,delete
        public void ExecutarSQLCommand(string command)
        {
            SqlCommand sqlCommand = new SqlCommand(command, Connection);
            sqlCommand.ExecuteNonQuery();
        }
        public DataTable RetornarDataTable(string command)
        {
            SqlCommand sqlCommand = new SqlCommand(command, Connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
