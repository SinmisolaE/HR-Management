using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Core.Interfaces.ServiceInterface
{
    public class EmployeeSalaryDTO
    {
        public string Email { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
