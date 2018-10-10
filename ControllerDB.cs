using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MyLibrarian
{
    public class ControllerDB
    {
        public enum Table
        {
            Reader, Book
        }


        SqlConnection connection;

        //Setup
        public ControllerDB()
        {   
            try
            {
                connection = new SqlConnection(GetConnectionString());
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetConnectionString()
        {
            return Constants.connectionString;
        }




        //Skaitytojas
        public void InsertToReader(String firstName, String lastName, String hash)
        {
            string query = "INSERT INTO db_owner.Reader (Name, Surname, Password) VALUES (@name, @surname, @hash)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@name", firstName);
            command.Parameters.Add("@surname", lastName);
            command.Parameters.Add("@hash", hash);

            command.ExecuteNonQuery();

            command.Dispose();
        }

        public DataTable GetDataTable(Table tbl)
        {
            string output = "";
            string tableName = Enum.GetName(tbl.GetType(), tbl);
            string query = "SELECT * FROM db_owner." + tableName;
            

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            command.Dispose();

            return dt;
        }

        public void DeleteFromReader(int id)
        {
            string query = "DELETE FROM db_owner.Reader WHERE ID = @id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@id", id);
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





        //Knyga
        internal void InsertToBook(string isbn, string title, string author, DateTime date)
        {
            string query = "INSERT INTO db_owner.Book (ISBN, Title, Author, Date) " +
                "VALUES (@isbn, @title, @author, @date)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@isbn", isbn);
            command.Parameters.Add("@title", title);
            command.Parameters.Add("@author", author);
            command.Parameters.Add("@date", date);


            command.ExecuteNonQuery();

            command.Dispose();
        }

        internal void DeleteFromBook(string isbn)
        {
            string query = "DELETE FROM db_owner.Book WHERE ISBN = @isbn";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@isbn", isbn);
            command.ExecuteNonQuery();

            command.Dispose();
        }



        //Close
        public void Close()
        {
            connection.Close();
        }


    }
}
