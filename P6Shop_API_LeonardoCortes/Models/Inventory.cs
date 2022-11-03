using System;
using System.Collections.Generic;

namespace P6Shop_API_LeonardoCortes.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            InvoiceInventories = new HashSet<InvoiceInventory>();
            ItemPictures = new HashSet<ItemPicture>();
        }

        public int Idinventory { get; set; }
        public string ItemName { get; set; } = null!;
        public string ItemDescription { get; set; } = null!;
        public string ItemImageUrl { get; set; } = null!;
        public decimal ItemPrice { get; set; }
        public int ItemStock { get; set; }
        public string? ItemSku { get; set; }
        public string? ItemManufacturerNumber { get; set; }
        public string? ItemUpc { get; set; }
        public bool? Active { get; set; }
        public int Idstore { get; set; }
        public int Idcurrency { get; set; }
        public int? IditemPicture { get; set; }

        public virtual Currency IdcurrencyNavigation { get; set; } = null!;
        public virtual Store IdstoreNavigation { get; set; } = null!;
        public virtual ICollection<InvoiceInventory> InvoiceInventories { get; set; }
        public virtual ICollection<ItemPicture> ItemPictures { get; set; }
    }
}
