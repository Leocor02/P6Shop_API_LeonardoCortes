using System;
using System.Collections.Generic;

namespace P6Shop_API_LeonardoCortes.Models
{
    public partial class UserStore
    {
        public int Iduser { get; set; }
        public int Idstore { get; set; }
        public bool? IsStoreAdmin { get; set; }
        public bool? IsFollowedByUser { get; set; }

        public virtual Store IdstoreNavigation { get; set; } = null!;
        public virtual User IduserNavigation { get; set; } = null!;
    }
}
