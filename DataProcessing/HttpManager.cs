using MyLibrarian.Data;
using MyLibrarian.Forms.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian.DataProcessing
{
    class HttpManager
    {
        private readonly HttpClient client;
        private static readonly object padlock = new object();
        private static HttpManager instance = null;

        public static HttpManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new HttpManager();
                    }
                    return instance;
                }
            }
        }
        
        private HttpManager()
        {
            try
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(GetUri());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (Exception ex)
            {
                // MessageManager.ShowMessageBox(ex);
            }
        }

        private string GetUri()
        {
            return Constants.Uri;
        }

        public async void PostItemAsync(DataItem item)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await client.PostAsync(GetUri() + item.GetTableName() + "s", content);

            MessageManager.ShowMessageBox(message.StatusCode.ToString());
            MessageManager.ShowMessageBox(GetUri() + item.GetTableName() + "s");
            if (message.IsSuccessStatusCode)
            {
                MessageManager.ShowMessageBox("Success");
            }
        }

        public async Task<List<DataItem>> GetAllItemsAsync(string tableName)
        {
            HttpResponseMessage message = await client.GetAsync(GetUri() + tableName);

            List<DataItem> items = null;

            if (message.IsSuccessStatusCode)
            {
                MessageManager.ShowMessageBox("Success");
                string data = await message.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<DataItem>>(data);
            }
            return items;
        }

    }
}
