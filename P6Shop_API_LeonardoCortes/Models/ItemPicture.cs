using System;
using System.Collections.Generic;

namespace P6Shop_API_LeonardoCortes.Models
{
    public partial class ItemPicture
    {
        public int IditemPicture { get; set; }
        public string ItemPictureUrl { get; set; } = null!;
        public int Idinventory { get; set; }

        public virtual Inventory IdinventoryNavigation { get; set; } = null!;
    }
}
