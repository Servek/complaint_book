using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintBook.Models.DataBase
{
    public class Grade // Оценка сотрудника
    {
        public int Id { get; set; }

        // Информация об отправителе
        [Display(Name = "Имя отправителя")]
        [Required]
        public string SenderName { get; set; }
        [Display(Name = "E-mail отправителя")]
        [Required]
        public string SenderEmail { get; set; }
        [Display(Name = "Принято")]
        [Required]
        public bool IsAccepted { get; set; }

        // Текст отправления
        [Display(Name = "Текст отправления")]
        [Required]
        public string Message { get; set; }

        // Тип отправления (жалоба или предложение)
        [Display(Name = "Тип отправления")]
        [Required]
        [Column("ReportType")]
        public int InternalReportType { get; set; }
        [NotMapped]
        public ReportType ReportType
        {
            get { return (ReportType)this.InternalReportType; }
            set { this.InternalReportType = (int)value; }
        }

        [Display(Name = "Оценка сотрудника")]
        public int? Score { get; set; } // Оценка

        [Display(Name = "Сотрудник")]
        public int? EmployeeId { get; set; }
        [Display(Name = "Сотрудник")]
        public Employee Employee { get; set; } // Сотрудник
    }
}
