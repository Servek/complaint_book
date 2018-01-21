using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintBook.Models.DataBase
{
    public class Grade // Оценка сотрудника
    {
        public int Id { get; set; }

        // Информация об отправителе
        [Required]
        public string SenderName { get; set; }
        [Required]
        public string SenderEmail { get; set; }
        [Required]
        public bool IsAccepted { get; set; }

        // Текст отправления
        [Required]
        public string Message { get; set; }

        // Тип отправления (жалоба или предложение)
        [Required]
        [Column("ReportType")]
        public int InternalReportType { get; set; }
        [NotMapped]
        public ReportType ReportType
        {
            get { return (ReportType)this.InternalReportType; }
            set { this.InternalReportType = (int)value; }
        }
        
        public int? Score { get; set; } // Оценка

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; } // Сотрудник
    }
}
