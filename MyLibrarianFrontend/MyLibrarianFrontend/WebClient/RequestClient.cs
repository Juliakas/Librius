using MyLibrarianFrontend.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarianFrontend.WebClient
{
    class RequestClient
    {
        private readonly HttpClient client;
        private static readonly object padlock = new object();
        private static RequestClient instance = null;

        public static RequestClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RequestClient();
                    }
                    return instance;
                }
            }
        }

        private RequestClient()
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
            return "https://mylibrarianservice.azurewebsites.net/api/";
        }

        public async Task<string> PostItemAsync(IRequestItem item)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await client.PostAsync(GetUri() + item.GetTableName(), content);

            string primaryKey = null;

            if (message.IsSuccessStatusCode)
            {
                string data = await message.Content.ReadAsStringAsync();
                primaryKey = JsonConvert.DeserializeObject<string>(data);
            }

            return primaryKey;
        }

        public async Task<string> PostItemAsync(IRequestItem item, string route)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await client.PostAsync(GetUri() + item.GetTableName() + "/" + route, content);

            string primaryKey = null;

            if (message.IsSuccessStatusCode)
            {
                string data = await message.Content.ReadAsStringAsync();
                primaryKey = JsonConvert.DeserializeObject<string>(data);
            }

            return primaryKey;
        }

        public async Task<T> GetItemAsync<T>(string id, string tableName) where T : IRequestItem
        {
            HttpResponseMessage message = await client.GetAsync(GetUri() + tableName + "/" + id);

            T item = default(T);

            if (message.IsSuccessStatusCode)
            {
                string data = await message.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<T>(data);
            }

            return item;
        }

        public async Task<List<T>> GetAllItemsAsync<T>(string tableName) where T : IRequestItem
        {
            HttpResponseMessage message = await client.GetAsync(GetUri() + tableName);

            List<T> items = null;

            if (message.IsSuccessStatusCode)
            {
                string data = await message.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<T>>(data);
            }
            //return GetDataTable<DataItem>(items);
            return items;
        }

        public async void PutItemAsync(IRequestItem item)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await client.PostAsync(GetUri() + item.GetTableName() + "/" + "{item.Id}", content);
        }

        public async Task<HttpResponseMessage> DeleteItemAsync(string id, string tableName)
        {
            HttpResponseMessage message = await client.DeleteAsync(GetUri() + tableName + "/" + id);

            return message;
        }

    }
}
