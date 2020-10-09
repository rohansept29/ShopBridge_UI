using ShopBridge_UI.BLL;
using ShopBridge_UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBridge_UI.Controllers
{
    public class ItemsController : Controller
    {
        ItemBLL itemBLL = new ItemBLL();
        public ActionResult New()
        {
            GetItems();
            return View();
        }
        public PartialViewResult Save(Item item)
        {
            var allowedExtensions = new[] { ".png", ".gif", ".jpg", ".jpeg" };
            if (item.UploadedImageData == null)
            {
                
            }
            else
            {
                var extension = Path.GetExtension(item.UploadedImageData.FileName);
                if (allowedExtensions.Contains(extension))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        item.UploadedImageData.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                        item.ItemImage = Convert.ToBase64String(array);
                    }
                }
            }
            item.UploadedImageData = null;
            string x = itemBLL.SaveItem(item);
            GetItems();
            ModelState.Clear();
            return PartialView("ItemListView");
        }

        public void GetItems()
        {
            List<Item> items = itemBLL.GetItems();
            ViewBag.ItemList = items;
        }
        public ActionResult Details(long id)
        {
            Item item = itemBLL.GetItemById(id);
            return View(item);
        }
        public PartialViewResult Delete(long id)
        {
            itemBLL.DeleteItemById(id);
            GetItems();
            return PartialView("ItemListView");
        }
    }
}