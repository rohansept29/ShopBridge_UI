using Newtonsoft.Json;
using ShopBridge_UI.Models;
using ShopBridge_UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace ShopBridge_UI.BLL
{
    public class ItemBLL
    {
        ApiService apiService = new ApiService();
        public static readonly string SaveItemAction = "/api/Items/SaveItem";
        public static readonly string GetItemsAction = "/api/Items/GetItems";
        public static readonly string GetItemByIdAction = "/api/Items/GetItemById?id={0}";
        public static readonly string DeleteItemByIdAction = "/api/Items/DeleteItemById?id={0}";
        public Item GetItemById(long id)
        {
            Item item = null;
            HttpResponseMessage res = apiService.GetMethod(string.Format(GetItemByIdAction, id));
            string result = res.Content.ReadAsStringAsync().Result;
            if (!string.IsNullOrEmpty(result))
            {
                item = JsonConvert.DeserializeObject<Item>(result);
            }
            return item;
        }
        public List<Item> GetItems()
        {
            List<Item> items = null;
            HttpResponseMessage res = apiService.GetMethod(GetItemsAction);
            string result = res.Content.ReadAsStringAsync().Result;
            if (!string.IsNullOrEmpty(result))
            {
                items = JsonConvert.DeserializeObject<List<Item>>(result);
            }
            return items;
        }
        public string SaveItem(Item item)
        {
            string result = string.Empty;
            string json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage res = apiService.PostMethod(SaveItemAction, content);
            if (res.IsSuccessStatusCode)
            {
                result = res.Content.ReadAsStringAsync().Result;
            }
            return result;
        }
        public string DeleteItemById(long id)
        {
            HttpResponseMessage res = apiService.DeleteMethod(string.Format(DeleteItemByIdAction, id));
            string result = res.Content.ReadAsStringAsync().Result;
            return result;
        }

    }
}