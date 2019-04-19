using System;

namespace DataModel
{
    public class EmployeeListViewModel
    {
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string EmployeeMobile { get; set; }
        public string EmployeeName { get; set; }
        public byte sex { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? Duedate { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string EmergencyContact { get; set; }
        public int BaseSalary { get; set; }
        public string ID { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAddress { get; set; }
        public string eMail { get; set; }
        public string LineId { get; set; }
    }
}