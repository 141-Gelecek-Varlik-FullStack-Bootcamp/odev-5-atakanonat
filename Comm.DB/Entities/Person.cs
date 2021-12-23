using System;
using System.Collections.Generic;

#nullable disable

namespace Comm.DB.Entities
{
    public partial class Person
    {
        public Person()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Udate { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
