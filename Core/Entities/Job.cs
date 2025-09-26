using HRService.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Core.Entities
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int DepartmentId { get; set; }
        
        public Department Department { get; set; }

        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();

    }
}
