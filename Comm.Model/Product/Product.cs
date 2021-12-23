using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comm.Model.Product
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide your name.")]
        [StringLength(maximumLength: 50, ErrorMessage = "Minimum 3 and maximum 50 characters allowed.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide product description.")]
        [StringLength(maximumLength: 250, ErrorMessage = "Minimum 30 and maximum 250 characters allowed.", MinimumLength = 30)]
        public string Description { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "9999999999999999.99", ErrorMessage = "Please provide a price in range 0.01 and 9999999999999999.99.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

    }
}