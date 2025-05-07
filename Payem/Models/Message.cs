using System.ComponentModel.DataAnnotations;

namespace Payem.Models
{
    public class Message
    {
        [Key] // <-- Primary Key
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Content { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public int Likes { get; set; } 
    }
}
