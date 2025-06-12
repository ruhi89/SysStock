using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysStock
{
    class DataAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private DataSet dataSet;

        private string connectionString = @"Server=SAKIBS-ZENBOOK\SQLEXPRESS;Database=SysStockDB;Trusted_Connection=True;";
        public DataAccess()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public DataSet ExecuteQuery(string query)
        {
            command = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            adapter.Fill(dataSet);  
            return dataSet;
        }
        public DataTable ExecuteQueryTable(string query)
        {
            command = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet.Tables[0];

        }

        public int ExecuteDMLQuery(string sql)
        {
            command = new SqlCommand(sql, connection);
            return command.ExecuteNonQuery();
        }

    }
}
