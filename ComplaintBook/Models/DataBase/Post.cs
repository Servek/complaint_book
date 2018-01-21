using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComplaintBook.Models.DataBase
{
    public class Post // Должность
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required]
        public string Name { get; set; } // Название должности

        public List<Employee> Employees { get; set; } // Сотрудники, занимающие данную должность
    }
}
