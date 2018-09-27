using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MyLibrarian
{
    public class ControllerDB
    {
        SqlConnection connection;


        //Setup
        public ControllerDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings
                [GetConnectionString()].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private string GetConnectionString()
        {
            return "MyLibrarian.Properties.Settings.LibraryDatabaseConnectionString";
        }




        //Skaitytojas
        public void InsertToSkaitytojas(int id, String firstName, String lastName)
        {
            string query = "INSERT INTO Skaitytojas (ID, Vardas, Pavarde) VALUES (@id, @vardas, @pavarde)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@id", id);
            command.Parameters.Add("@vardas", firstName);
            command.Parameters.Add("@pavarde", lastName);

            command.ExecuteNonQuery();

            command.Dispose();
        }

        public DataTable GetDataTableSkaitytojas()
        {
            string output = "";
            string query = "SELECT ID, Vardas, Pavarde FROM Skaitytojas";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            command.Dispose();

            return dt;
        }

        public void DeleteFromSkaitytojas(int id)
        {
            string query = "DELETE FROM Skaitytojas WHERE ID = @id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@id", id);
            command.ExecuteNonQuery();

            command.Dispose();
        }




        //Knyga
        internal void InsertToKnyga(string isbn, string title, string author, DateTime date)
        {
            string query = "INSERT INTO Knyga (ISBN, Pavadinimas, Autorius, Isleista) " +
                "VALUES (@isbn, @pavadinimas, @autorius, @isleista)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@isbn", isbn);
            command.Parameters.Add("@pavadinimas", title);
            command.Parameters.Add("@autorius", author);
            command.Parameters.Add("@isleista", date);


            command.ExecuteNonQuery();

            command.Dispose();
        }

        public DataTable GetDataTableKnyga()
        {
            string output = "";
            string query = "SELECT ISBN, Pavadinimas, Autorius, Isleista FROM Knyga";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            command.Dispose();

            return dt;
        }

        internal void DeleteFromKnyga(string isbn)
        {
            string query = "DELETE FROM Knyga WHERE ISBN = @isbn";

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
