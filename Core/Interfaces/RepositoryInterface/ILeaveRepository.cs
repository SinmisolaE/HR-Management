using HRService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Core.Interfaces.RepositroyInterface
{
    public interface ILeaveRepository
    {
        Task<Leave> GetLeaveByIdAsync(int id);
        Task<IEnumerable<Leave>> GetAllLeavesAsync();
        Task<Leave> GetLeavesByLeaveTypeAsync(string leaveType);
        
    }
}
