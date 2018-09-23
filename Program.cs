using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyLibrarian
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //"Data Source =.\\SQLEXPRESS; Database = LibraryDatabase; Integrated Security = True"
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string connS = Properties.Settings.Default.LibraryDatabaseConnectionString;
            SqlConnection conn = new SqlConnection(connS);
            try
            {
                conn.Open();
                Console.WriteLine("Open");
                //SqlCommand comm = new SqlCommand("insert into skaitytojas (ID, Vardas, Pavarde) values (@id, @name, @surname)", conn);

                /*
                int i = 0;
                SqlCommand comm = new SqlCommand("delete from skaitytojas", conn);
                comm.ExecuteNonQuery();
                while(i < 3)
                {
                    comm = new SqlCommand("insert into skaitytojas (ID, Vardas, Pavarde) values (@id, @name, @surname)", conn);
                    comm.Parameters.AddWithValue("@id", Console.ReadLine());
                    comm.Parameters.AddWithValue("@name", Console.ReadLine());
                    comm.Parameters.AddWithValue("@surname", Console.ReadLine());
                    comm.ExecuteNonQuery();
                    i++;
                }
                */

                SqlCommand comm = new SqlCommand("select * from skaitytojas", conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                    Console.WriteLine(reader.GetString(1));
                    Console.WriteLine(reader.GetString(2));
                }
                conn.Close();
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Application.Run(new MainWindow());
        }
    }
}
