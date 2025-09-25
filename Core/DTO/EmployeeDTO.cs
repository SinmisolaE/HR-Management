using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Core.DTO
{
    public class EmployeeDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string DOB { get; set; } = string.Empty;

        public string DeptName { get; set; } = string.Empty ;
        public string JobName { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;

        public decimal Salary { get; set; }
    }
}
