using System.ComponentModel.DataAnnotations;

namespace MegaDesk3._0.Models
{
    public class Desk
    {
        public int Id { get; set; }
        [StringLength(40, MinimumLength = 4)]
        [Required]
        public string? Name { get; set; } 
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [Range(24, 96)]
        [Required]
        public int Width { get; set; }
       
        [Range(12, 48)]
        [Required]
        public int Height { get; set; }

        [Range(0, 7)]
        [Required]
        public int Drawers {  get; set; }
        public string? Material { get; set; }
        public int Rush {  get; set; }
        public decimal Price { get; set; }

    }
}
