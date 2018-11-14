using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using MyLibrarian.Data;

namespace MyLibrarian.Data
{
    public sealed class ControllerDB
    {
        public enum Table
        {
            Reader, Book, Copy
        }

        private readonly SqlConnection connection;
        private static readonly object padlock = new object();
        private static ControllerDB instance = null;

        public static ControllerDB Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ControllerDB();
                    }
                    return instance;
                }
            }
        }

        //Setup
        private ControllerDB()
        {   
            try
            {
                //connection = new SqlConnection(GetConnectionString());
                connection.Open();
            }
            catch (Exception ex)
            {
                // MessageManager.ShowMessageBox(ex);
            }
        }

        /*
        private string GetConnectionString()
        {
            return Constants.connectionString;
        }
        */



        //Skaitytojas
        public void InsertRow(DataItem item)
        {
            StringBuilder queryBuilder = new StringBuilder($"INSERT INTO db_owner.{item.GetTableName()} (", 500);
            for(int i = 0; i < item.ColumnCount; i++)
            {
                queryBuilder.Append(item.GetColumnNames()[i]);
                if(item.GetColumnNames().Count() != i + 1)
                {
                    queryBuilder.Append(", ");
                }
            }
            queryBuilder.Append(") VALUES (");
            for (int i = 0; i < item.ColumnCount; i++)
            {
                queryBuilder.Append(item.GetStringValues()[i]);
                if (item.GetColumnNames().Count() != i + 1)
                {
                    queryBuilder.Append(", ");
                }
            }
            queryBuilder.Append(')');

            string query = queryBuilder.ToString();
            SqlCommand command = new SqlCommand(query, connection);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public DataTable GetDataTable(Table tbl)
        {
            string tableName = Enum.GetName(tbl.GetType(), tbl);
            string query = "SELECT * FROM db_owner." + tableName;

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public void UpdateTable(Table tbl, string[] columns, string[] values, string[] conditions)
        {
            string tableName = Enum.GetName(tbl.GetType(), tbl);
            StringBuilder queryBuilder = new StringBuilder($"UPDATE db_owner.{tableName} SET ", 500);
            for(int i = 0; i < columns.Length && i < values.Length; i++)
            {
                queryBuilder.AppendFormat("{0} = {1}", columns[i], values[i]);
                if(i + 1 != columns.Length && i + 1 != values.Length)
                {
                    queryBuilder.Append(", ");
                }
            }
            queryBuilder.AppendFormat(" WHERE {0}", string.Join(" AND ", conditions));
            string query = queryBuilder.ToString();


            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void DeleteRow(DataItem item)
        {
            string query = $"DELETE FROM db_owner.{item.GetTableName()} WHERE {item.PrimaryKey} = {item.PrimaryKeyValue}";

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public bool SearchReader(int id, string password)
        {
            string query = "SELECT * FROM db_owner.Reader WHERE ID = @id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            Hashing hashing = new Hashing();
            reader.Read();
            if (reader.HasRows)
            {
                string hash = reader.GetString(3);

                if (hashing.Verify(password, hash))
                {
                    reader.Close();
                    command.Dispose();
                    return true;
                }
            }

            reader.Close();
            command.Dispose();
            return false;
        }

        //Close
        public void Close()
        {
            connection.Close();
        }


    }
}
