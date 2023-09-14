using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PracticeCoreMVC.Models
{
    public class EmployeeValidator
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Employee Salary")]
        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "Joining Date")]
        public decimal JoiningDate { get; set; }
    }

    [ModelMetadataType(typeof(EmployeeValidator))]
    public partial class Employee
    {
    }
}
