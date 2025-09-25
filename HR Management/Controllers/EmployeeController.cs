using HRService.Core.DTO;
using HRService.Core.Entities;
using HRService.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Diagnostics;

namespace HR_Management.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IJobService _jobService;
        private readonly IEmployeeLeaveService _employeeLeaveService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService, IJobService jobService, IEmployeeLeaveService employeeLeaveService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _jobService = jobService;
            _employeeLeaveService = employeeLeaveService;
            _logger = logger;
        }

        public async Task<IActionResult> Try()
        {
            ViewBag.Message = "hello";
            return View();
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("Getting all Employees");

                var employees = await _employeeService.GetAllEmployeesAsync();

                var employeeTasks = employees.Select(async emp => new EmployeeViewModel
                {
                    Id = emp.Id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Address = emp.Address,
                    Email = emp.Email,
                    DOB = emp.DOB,
                    DepartmentName = emp.Department.Name,
                    JobTitle = emp.Job.Name,
                    Salary = emp.Salary,
                    Grade = emp.Grade,
                    Status = emp.Status.ToString()
                });

                var employeeViewModels = await Task.WhenAll(employeeTasks);

                _logger.LogInformation("Returning all employees");

                return View(employeeViewModels);
            } catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Details(string email)
        {
            _logger.LogInformation($"Showing details for {email}");
            if (string.IsNullOrEmpty(email))
            {
                _logger.LogWarning("Email not passed");
                return BadRequest("Email is required");
            }
            var emp = await _employeeService.GetEmployeeByEmailAsync(email);

            var emp_leave = await _employeeLeaveService.GetAllLeavesForEmployee(emp.Id);

            var employeeView = new EmployeeViewModel
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Address = emp.Address,
                Email = emp.Email,
                DOB = emp.DOB,
                DepartmentName = emp.Department.Name,
                JobTitle = emp.Job.Name,
                Salary = emp.Salary,
                Grade = emp.Grade,
                Status = emp.Status.ToString(),
                employeeLeaves = emp_leave
            };

            return View(employeeView);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Creating new Employee");
                await _employeeService.AddEmployeeAsync(employeeDTO);

                return Redirect("Index");
            }
            return View(employeeDTO);
        }


    }
}
