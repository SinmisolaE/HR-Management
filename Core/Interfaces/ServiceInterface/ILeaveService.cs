using HRService.Core.Entities;
using HRService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Infrastructure.Interfaces
{
    public interface ILeaveService
    {
        Task<Leave> GetLeaveById(int leaveId);
        Task<IEnumerable<Leave>> GetAllLeaves();
        Task<Leave> AddLeave(LeaveDTO leaveDTO);
    }
}
