using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;

namespace School.Domain.ModelsDto
{
    public class UserDto
    {
        [Key]
        [Required]
        [Ignore]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Surname { get; set; } = "";

        [Ignore]
        public List<int> Groups { get; set; } = new List<int>();

        public string GetFullName()
        {
            return $"{Name} {Surname}";
        }
    }
}
