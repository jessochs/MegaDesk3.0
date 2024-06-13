using System.ComponentModel.DataAnnotations;

namespace MegaDesk3._0.Models
{
    public class Desk
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Drawers {  get; set; }
        public string? Material { get; set; }
        public int Rush {  get; set; }
        public decimal Price { get; set; }

    }
}
