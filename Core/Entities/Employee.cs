using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRService.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace HRService.Core.Entity
{
    public enum EmpStatus
    {
        Active, InActive
    }
    public class Employee
    {
        public Employee(string firstName, string lastName, string email, string dOB, string address, int jobId, int departmentId, string grade, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DOB = dOB;
            Address = address;
            JobId = jobId;
            DepartmentId = departmentId;
            Grade = grade;
            Salary = salary;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName {  get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string DOB { get; set; } = string.Empty;

        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        public int JobId { get; set; }

        public Job Job { get; set; }

        [Precision(18, 2)]
        public decimal Salary { get; set; }

        [Required]
        public string Grade { get; set; } = string.Empty;



        public EmpStatus Status {  get; set; } = EmpStatus.Active;
    }
}
