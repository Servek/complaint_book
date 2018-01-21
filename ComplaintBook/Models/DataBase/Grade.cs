using System.ComponentModel.DataAnnotations;

namespace ComplaintBook.Models.DataBase
{
    public class Grade // Оценка сотрудника
    {
        public int Id { get; set; }

        [Required]
        public int Score { get; set; } // Оценка

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } // Сотрудник
    }
}
