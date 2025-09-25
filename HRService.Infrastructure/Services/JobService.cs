using HRService.Core.Entities;
using HRService.Core.Interfaces.RepositoryInterface;
using HRService.Core.Interfaces.RepositroyInterface;
using HRService.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Infrastructure.Services
{
    public class JobService : IJobService, IDepartmentService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public JobService(IJobRepository jobRepository, IDepartmentRepository departmentRepository)
        {
            _jobRepository = jobRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> GetDepartmentByNameAsync(DepartmentDTO departmentDTO)
        {
            var department = await _departmentRepository.GetDepartmentByNameAsync(departmentDTO.Name);

            if (department == null) { throw new Exception("Department not found"); }

            return department;
        }
        public async Task<Department> AddDepartmentAsync(DepartmentDTO departmentDTO)
        {
            var department = await _departmentRepository.GetDepartmentByNameAsync(departmentDTO.Name);

            if (department == null) { throw new Exception("Department already exists"); }

            return await _departmentRepository.AddDepartmentAsync(department);
        }

        public async Task<bool> DeleteDepartmentByNameAsync(string name)
        {
            var department = await _departmentRepository.GetDepartmentByNameAsync(name);

            if (department == null) { throw new Exception("Department not found"); }

            var response = await _departmentRepository.DeleteDepartmentAsync(department);
            return response;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            var depts = await _departmentRepository.GetDepartmentListAsync();

            if (depts == null) { throw new Exception("No departments found"); }

            return depts;
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            var jobs = await _jobRepository.GetAllJobsAsync();

            if (jobs == null) { throw new Exception("No job found"); }
            return jobs;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id) ;
            if (department == null) { throw new Exception("Department not found"); }

            return department;
        }

        public async Task<string> GetDepartmentNameByIdAsync(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null) { throw new Exception("Department not found"); }

            return department.Name;
        }

        public async Task<IEnumerable<Job>> GetJobsByDepartmentIdAsync(int departmentId)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(departmentId);

            if (department == null) { throw new Exception("Department does not exist"); }

            return await _jobRepository.GetJobsByDepartmentAsync(department.Id) ;
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            var job = await _jobRepository.GetJobByIdAsync(id);
            if (job == null) { throw new Exception("Job doesn't exists "); }
            return job ;
        }

        public async Task<string> GetJobNameByIdAsync(int id)
        {
            var job = await _jobRepository.GetJobByIdAsync(id);
            if (job == null) { throw new Exception("Job doesn't exists "); }

            return job.Name;

        }

        public async Task<Job> GetJobByNameAsync(string name)
        {
            var job = await _jobRepository.GetJobByNameAsync(name);

            if (job == null) { throw new Exception("Job not found!"); }

            return job ;
        }
    }
}
