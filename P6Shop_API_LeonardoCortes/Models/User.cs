using System;
using System.Collections.Generic;

namespace P6Shop_API_LeonardoCortes.Models
{
    public partial class User
    {
        public User()
        {
            Invoices = new HashSet<Invoice>();
            UserStores = new HashSet<UserStore>();
        }

        public int Iduser { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string BackUpEmail { get; set; } = null!;
        public string? SecurityCode { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public bool? Active { get; set; }
        public int IduserRole { get; set; }
        public int Idcountry { get; set; }

        public virtual Country? IdcountryNavigation { get; set; } = null!;
        public virtual UserRole? IduserRoleNavigation { get; set; } = null!;
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<UserStore> UserStores { get; set; }
    }
}
