using System;
using System.Collections.Generic;

namespace P6Shop_API_LeonardoCortes.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int Idcurrency { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public string CurrencyName { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
