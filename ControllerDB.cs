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
        SqlConnection connection;

        //Setup
        public ControllerDB()
        {   
            try
            {
                string connectionString = "server=localhost\\SQLEXPRESS;database=LibraryDatabase;Trusted_connection=yes";
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetConnectionString()
        {
            return "server=localhost;database=LibraryDatabase;Trusted_connection=yes";
        }




        //Skaitytojas
        public void InsertToReader(int id, String firstName, String lastName)
        {
            string query = "INSERT INTO db_owner.Reader (ID, Name, Surname, Password) VALUES (@id, @name, @surname)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@id", id);
            command.Parameters.Add("@name", firstName);
            command.Parameters.Add("@surname", lastName);

            command.ExecuteNonQuery();

            command.Dispose();
        }

        public DataTable GetDataTableReader()
        {
            string output = "";
            string query = "SELECT ID, Name, Surname FROM db_owner.Reader";

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

        public DataTable GetDataTableBook()
        {
            string output = "";
            string query = "SELECT ISBN, Title, Author, Date FROM db_owner.Book";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            command.Dispose();

            return dt;
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
