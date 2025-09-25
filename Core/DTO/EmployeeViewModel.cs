using HRService.Core.Entities;
using HRService.Core.Entity;
using HRService.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Core.DTO
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DOB { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Grade { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public IEnumerable<Employee_leave> employeeLeaves { get; set; }

        public EmployeeViewModel() { }
    }
}
