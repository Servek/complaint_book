using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintBook.Models.DataBase
{
    public class Employee // Сотрудники
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required]
        public string Name { get; set; } // Имя

        [Display(Name = "Фамилия")]
        [Required]
        public string LastName { get; set; } // Фамилия

        // Связь с должностью
        [Display(Name = "Должность")]
        public int PostId { get; set; }
        [Display(Name = "Должность")]
        public Post Post { get; set; } // Должность

        // Связь с оценками
        public List<Grade> Grades { get; set; } // Оценки сотрудника

        // Средняя оценка
        [Display(Name = "Средняя оценка")]
        [NotMapped]
        public decimal AvgRating
        {
            get
            {
                decimal avg = 0;
                foreach (Grade item in Grades)
                {
                    avg += item.Score.HasValue ? item.Score.Value : 0;
                }
                avg = (Grades.Count>0) ? avg/Grades.Count : 0;
                return avg;
            }
        }
    }
}
