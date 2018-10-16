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

namespace MyLibrarian
{
    public class ControllerDB
    {
        public enum Table
        {
            Reader, Book, Copy
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
                // MessageManager.ShowMessageBox(ex);
            }
        }

        private string GetConnectionString()
        {
            return Constants.connectionString;
        }




        //Skaitytojas
        public void InsertToReader(Reader reader)
        {
            string query = "INSERT INTO db_owner.Reader (Name, Surname, Password) VALUES (@name, @surname, @hash)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@name", reader.Name);
            command.Parameters.Add("@surname", reader.Surname);
            command.Parameters.Add("@hash", reader.PasswordHash);

            command.ExecuteNonQuery();

            command.Dispose();
        }

        public DataTable GetDataTable(Table tbl)
        {
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
        internal void InsertToBook(Book book)
        {
            string query = "INSERT INTO db_owner.Book (ISBN, Title, Author, Date) " +
                "VALUES (@isbn, @title, @author, @date)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@isbn", book.ISBN);
            command.Parameters.Add("@title", book.Title);
            command.Parameters.Add("@author", book.Author);
            command.Parameters.Add("@date", book.Date);


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

        public void InsertToCopy(Copy copy)
        {
            string query = "INSERT INTO db_owner.Copy (ID, Reader, ISBN, Borrowed) VALUES (@id, null, @isbn, null)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@id", copy.ID);
            command.Parameters.Add("@isbn", copy.ISBN);

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
