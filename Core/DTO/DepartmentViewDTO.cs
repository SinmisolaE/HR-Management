using HRService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Core.DTO
{
    public class DepartmentViewDTO
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
