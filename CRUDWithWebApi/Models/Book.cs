using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CRUDWithWebApi.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = "";
        [Required]
        public string Author { get; set; } = "";
        [Required]
        public int PublicationYear { get; set; }
        [Required]
        public string Genre { get; set; } = "";
    }
}
