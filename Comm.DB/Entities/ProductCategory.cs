using System;
using System.Collections.Generic;

#nullable disable

namespace Comm.DB.Entities
{
    public partial class ProductCategory
    {
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
