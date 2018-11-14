using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MyLibrarian.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Newtonsoft.Json;
using MyLibrarian.Forms.Utils;

namespace MyLibrarian
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            /*
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59538/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Kazkas2(client);
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.AuthWindow());
        }

        /*
        static async Task<Reader> Kazkas(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("api/readers/1500000");
            Reader reader = null;

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                MessageManager.ShowMessageBox(data);
                reader = JsonConvert.DeserializeObject<Reader>(data);
            }

            return reader;
        }

        static async void Kazkas2(HttpClient client)
        {
            Reader reader = await Kazkas(client);
            MessageManager.ShowMessageBox(reader.ID + "");
        }
        */

    }
}