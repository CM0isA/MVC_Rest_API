using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Command{
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Link { get; set; }
    
    }
}