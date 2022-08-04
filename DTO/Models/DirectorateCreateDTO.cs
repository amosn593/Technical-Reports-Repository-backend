using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models
{
    public class DirectorateCreateDTO
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
    }
}
