using HRService.Core.DTO;
using HRService.Core.Entities;
using HRService.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Management.Controllers
{
    public class JobController : Controller
    {
        private readonly ILogger<JobController> _logger;
        private readonly IJobService _jobService;
        private readonly IDepartmentService _departmentService;

        public JobController(IJobService jobService, ILogger<JobController> logger, IDepartmentService departmentService)
        {
            _jobService = jobService;
            _logger = logger;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Accessed Job Index Page");
            try
            {
                _logger.LogInformation("Getting all Jobs");

                var jobs = _jobService.GetAllJobsAsync().Result;

                var jobSent = jobs.Select(async job => new JobViewDTO
                {
                    JobName = job.Name,
                    DepartmentName = job.Department.Name,
                    Employees = job.Employees
                });

                var jobsView = await Task.WhenAll(jobSent);

                return View(jobsView);
                //return View();
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting jobs");
                return View("Error"); //, new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        public async Task<IActionResult> Department()
        {
            _logger.LogInformation("Accessed Department Page");
            try
            {
                _logger.LogInformation("Getting all Jobs");

                var depts = _departmentService.GetAllDepartmentsAsync().Result;

                var jobSent = depts.Select(async dept => new DepartmentViewDTO
                {
                    Name = dept.Name,
                    //Jobs = dept.Jobs
                });

                return View(jobSent);
                //return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting jobs");
                return View("Error"); //, new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
