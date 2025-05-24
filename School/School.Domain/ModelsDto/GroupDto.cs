using System.ComponentModel.DataAnnotations;

namespace School.Domain.ModelsDto
{
    public class GroupDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public List<int> Permissions { get; set; } = new List<int>();
    }
}
