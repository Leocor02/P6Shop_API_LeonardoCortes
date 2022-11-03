using System;
using System.Collections.Generic;

namespace P6Shop_API_LeonardoCortes.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceInventories = new HashSet<InvoiceInventory>();
            Shippings = new HashSet<Shipping>();
        }

        public int Idinvoice { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; } = null!;
        public string? InvoiceNotes { get; set; }
        public bool? IsShoppingChart { get; set; }
        public int Iduser { get; set; }
        public int? IdpaymentMethod { get; set; }

        public virtual PaymentMethod? IdpaymentMethodNavigation { get; set; }
        public virtual User IduserNavigation { get; set; } = null!;
        public virtual ICollection<InvoiceInventory> InvoiceInventories { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
