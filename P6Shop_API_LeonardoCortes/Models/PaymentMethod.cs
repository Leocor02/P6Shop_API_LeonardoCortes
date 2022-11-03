using System;
using System.Collections.Generic;

namespace P6Shop_API_LeonardoCortes.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int IdpaymentMethod { get; set; }
        public string PaymentMethodDescription { get; set; } = null!;

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
