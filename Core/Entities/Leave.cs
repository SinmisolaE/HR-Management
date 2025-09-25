using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Core.Entities
{
    public class Leave
    {
        public int Id { get; set; }
        public string LeaveType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
