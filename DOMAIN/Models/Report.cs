using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Citation { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Abstract { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string FinancialYear { get; set; }
        [Required]
        [Precision(3)]
        public DateTime PostDate { get; set; }
        [Required]
        public int DirectorateId { get; set; }
        public Directorate Directorate { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public String FileUrl { get; set; }
    }
}
