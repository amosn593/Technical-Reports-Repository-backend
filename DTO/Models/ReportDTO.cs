using DOMAIN.Models;

namespace DTO.Models
{
    public class ReportDTO
    {
        public int ReportId { get; set; }
       
        public string Title { get; set; }
       
        public string Citation { get; set; }
        
        public string Abstract { get; set; }
        
        public string FinancialYear { get; set; }
        
        public Directorate Directorate { get; set; }
        
        public String FileUrl { get; set; }
    }
}
