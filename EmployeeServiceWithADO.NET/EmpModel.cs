using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceWithADO.NET
{
    public class EmpModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Salary is Required.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        public decimal Pay { get; set; }
        public decimal Deduction { get; set; }
        public decimal TaxablePay { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetPay { get; set; }
    }
}
