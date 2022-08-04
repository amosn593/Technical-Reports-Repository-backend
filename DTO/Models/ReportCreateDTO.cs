using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models
{
    public class ReportCreateDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Citation { get; set; }
        [Required]
        public string Abstract { get; set; }
        [Required]
        public string FinancialYear { get; set; }
        [Required]
        public int DirectorateId { get; set; }
        [Required]
        public IFormFile PdfFile { get; set; }
    }
}
