using System;
using System.Collections.Generic;

#nullable disable

namespace Comm.DB.Entities
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Udate { get; set; }
    }
}
