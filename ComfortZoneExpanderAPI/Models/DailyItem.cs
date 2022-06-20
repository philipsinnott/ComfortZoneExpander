using System.ComponentModel.DataAnnotations;

namespace ComfortZoneExpanderAPI.Models
{
    public class DailyItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int Rating { get; set; }
    }
}
