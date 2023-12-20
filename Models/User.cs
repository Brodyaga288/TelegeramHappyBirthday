using System.ComponentModel.DataAnnotations;

namespace TelegeramHappyBirthday.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime HappyBirthday { get; set; }
        [Required]
        public string Post { get; set; }
    }
}
