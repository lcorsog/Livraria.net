using System.ComponentModel.DataAnnotations;

namespace ConsumeWebAPI.Models
{
    public class BookViewModel
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
