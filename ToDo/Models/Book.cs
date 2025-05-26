using System.ComponentModel.DataAnnotations;
namespace ToDo.Models;
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Book Title")]
        public string Title { get; set; } = String.Empty;

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; } = String.Empty;

        [Display(Name = "ISBN")]
        public string ISBN { get; set; } = String.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 9999.99, ErrorMessage = "Price must be between 0.01 and 9999.99")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = String.Empty;

        [Display(Name = "Publication Date")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "In Stock")]
        public bool InStock { get; set; } = true;

        [Display(Name = "Stock Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be 0 or greater")]
        public int StockQuantity { get; set; } = 0;

        public string Genre { get; set; } = String.Empty;
    }

