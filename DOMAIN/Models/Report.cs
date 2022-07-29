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
        [Column(TypeName = "varchar(300)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Citation { get; set; }
        [Required]
        [Column(TypeName = "varchar(8000)")]
        public string Abstract { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string FinancialYear { get; set; }
        [Required]
        [Precision(3)]
        public DateTime PostDate { get; set; }
        [Required]
        public int DirectorateId { get; set; }
        public Directorate Directorate { get; set; }
        [Required]
        [Column(TypeName = "varchar(400)")]
        public String FileUrl { get; set; }
    }
}
