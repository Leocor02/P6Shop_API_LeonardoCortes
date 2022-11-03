using System;
using System.Collections.Generic;

namespace P6Shop_API_LeonardoCortes.Models
{
    public partial class InvoiceInventory
    {
        public int InvoiceIdinvoice { get; set; }
        public int InventoryIdinventory { get; set; }
        public int ShoppingQuantity { get; set; }
        public decimal ItemPrice { get; set; }

        public virtual Inventory InventoryIdinventoryNavigation { get; set; } = null!;
        public virtual Invoice InvoiceIdinvoiceNavigation { get; set; } = null!;
    }
}
