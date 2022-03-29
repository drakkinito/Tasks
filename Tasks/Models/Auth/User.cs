using System.ComponentModel.DataAnnotations;

namespace Tasks.Models.Auth
{
    public class User : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        public int Password { get; set; }
    }
}
