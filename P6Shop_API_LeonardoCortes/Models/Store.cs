using System;
using System.Collections.Generic;

namespace P6Shop_API_LeonardoCortes.Models
{
    public partial class Store
    {
        public Store()
        {
            Inventories = new HashSet<Inventory>();
            UserStores = new HashSet<UserStore>();
        }

        public int Idstore { get; set; }
        public string StoreName { get; set; } = null!;
        public string? StoreWelcomeMessage { get; set; }
        public string StoreDescription { get; set; } = null!;
        public bool? Active { get; set; }
        public int Idcountry { get; set; }
        public int Iduser { get; set; }

        public virtual Country IdcountryNavigation { get; set; } = null!;
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<UserStore> UserStores { get; set; }
    }
}
