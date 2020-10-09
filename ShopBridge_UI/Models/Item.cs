using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBridge_UI.Models
{
    public class Item
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public long Price { get; set; }
        public DateTime AddedOn { get; set; }
        public string ItemImage { get; set; }
        [Display(Name = "Supported Files .png | .jpg |  .gif |  .jpeg")]
        public HttpPostedFileBase UploadedImageData { get; set; }
    }
}