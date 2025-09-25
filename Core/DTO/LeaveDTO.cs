namespace HRService.Infrastructure.Services
{
    public class LeaveDTO
    {
        public string EmployeeEmail { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int NumDays { get; set; }
        public string LeaveType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}