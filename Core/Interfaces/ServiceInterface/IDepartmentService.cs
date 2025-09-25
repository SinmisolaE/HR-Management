using HRService.Core.Entities;
using HRService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Infrastructure.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentByIdAsync(int id);

        Task<Department> GetDepartmentByNameAsync(DepartmentDTO departmentDTO);
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        //Task<Department> DeleteDepartmentByIdAsync(int id);

        Task<bool> DeleteDepartmentByNameAsync(string name);
        Task<string> GetDepartmentNameByIdAsync(int id);

        Task<Department> AddDepartmentAsync(DepartmentDTO departmentDTO);

    }
}
