namespace FastFood.Core.ViewModels.Items
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class CreateItemInputModel
    {
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
