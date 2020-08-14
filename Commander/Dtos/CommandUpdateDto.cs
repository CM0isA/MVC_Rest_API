using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Link { get; set; }
    
    }
}