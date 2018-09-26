using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace MyLibrarian
{
    public class ControllerDB
    {
        private string connectionString;
        SqlConnection connection;

        public ControllerDB(String connectionString)
        {
            this.connectionString = ConfigurationManager.ConnectionStrings
                [connectionString].ConnectionString;
        }

        //Skaitytojas
        public void AddItemsToSkaitytojas(int id, String firstName, String lastName)
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("INSERT INTO Skaitytojas (ID, Vardas, Pavarde) " +
                "VALUES ('"+id+"','"+firstName+"', '"+lastName+"');", connection))
            {

            }



        }




    }
}
