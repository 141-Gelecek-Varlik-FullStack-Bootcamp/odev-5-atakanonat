using System;
using System.Collections.Generic;

#nullable disable

namespace Comm.DB.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Udate { get; set; }
        public int? UserId { get; set; }

        public virtual Person User { get; set; }
    }
}
