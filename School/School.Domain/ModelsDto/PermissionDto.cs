using System.ComponentModel.DataAnnotations;

namespace School.Domain.ModelsDto
{
    public class PermissionDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";
    }
}
