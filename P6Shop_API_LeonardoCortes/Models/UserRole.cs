using System;
using System.Collections.Generic;

namespace P6Shop_API_LeonardoCortes.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int IduserRole { get; set; }
        public string UserRoleDescription { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
