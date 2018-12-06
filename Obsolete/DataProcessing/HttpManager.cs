using MyLibrarian.Data;
using MyLibrarian.Forms.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
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

        public async Task<String> PostItemAsync(DataItem item)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await client.PostAsync(GetUri() + item.GetTableName(), content);

            string primaryKey = null;

            if (message.IsSuccessStatusCode)
            {
                string data = await message.Content.ReadAsStringAsync();
                primaryKey = JsonConvert.DeserializeObject<String>(data);
            }

            return primaryKey;
        }

        public async Task<String> PostItemAsync(DataItem item, string route)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            
            HttpResponseMessage message = await client.PostAsync(GetUri() + item.GetTableName() + "/" + route, content);

            string primaryKey = null;
            
            if (message.IsSuccessStatusCode)
            {
                string data = await message.Content.ReadAsStringAsync();
                primaryKey = JsonConvert.DeserializeObject<String>(data);
            }

            return primaryKey;
        }

        public async Task<T> GetItemAsync<T>(string id, string tableName) where T: DataItem
        {
            HttpResponseMessage message = await client.GetAsync(GetUri() + tableName + "/" + id);
            
            T item = null;

            if (message.IsSuccessStatusCode)
            {
                string data = await message.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<T>(data);
            }

            return item;
        }

        public async Task<List<T>> GetAllItemsAsync<T>(string tableName) where T: DataItem
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

        public async void PutItemAsync(DataItem item)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await client.PostAsync(GetUri() + item.GetTableName() + "/" + "{item.Id}", content);
        }

        public async Task<HttpResponseMessage> DeleteItemAsync(string id, string tableName)
        {
            HttpResponseMessage message = await client.DeleteAsync(GetUri() + tableName + "/" + id);

            return message;
        }

        public async Task<String> PostImageAsync(Image image, string tableName, string route)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(ToByteArray(image)), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await client.PostAsync(GetUri() + tableName + "/" + route, content);
            string result = "";

            if (message.IsSuccessStatusCode)
            {
                string data = await message.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<string>(data) + "1";
                Console.WriteLine();
            }
            
            return result;
        }

        private DataTable GetDataTable<T>(List<T> list)
        {
            DataTable dt = new DataTable(typeof(T).Name);
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach(PropertyInfo info in properties)
            {
                dt.Columns.Add(info.Name);
            }

            foreach(T item in list)
            {
                var values = new object[properties.Length];
                for(int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

        private static byte[] ToByteArray(Image image)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] imageBytes = (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
            return imageBytes;
        }

    }
}
