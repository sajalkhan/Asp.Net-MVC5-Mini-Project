using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_2.Models
{
    public class EmployeeVm
    {
        public EmployeeVm()
        {

        }

        public EmployeeVm(EmployeeTbl row)
        {
            EmployeeId = row.EmployeeId;
            EmployeeName = row.EmployeeName;
            PresentAddress = row.PresentAddress;
            PermanentAddress = row.PermanentAddress;
            LocationId = row.LocationTbl.LocationId;
            LocationName = row.LocationTbl.LocationName;
            PositionName = row.PositionTbl.PositionName;
            PositionId = row.PositionTbl.PositionId;
            Gender = row.Gender;
            PhoneNumber =row.Phone;
            IsUserOfSystem = (int) row.IsUserOfSystem;
            DateOfBirth =(DateTime) row.DateOfBirth;
            JoiningDate = (DateTime) row.JoiningDate;
            MaritalStatus = row.MaritalStatus;
            Salary = (float) row.Salary;
        }

        

        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name:")]
        [Required(ErrorMessage = "Please Enter Employee Name")]
        [StringLength(20, MinimumLength = 3)]
        public string EmployeeName { get; set; }


        [Required(ErrorMessage = "Please Enter Employee Present Address")]
        [StringLength(20, MinimumLength = 2)]
        public string PresentAddress { get; set; }


        [Required(ErrorMessage = "Please Enter Employee Permanent Address")]
        [StringLength(20, MinimumLength = 2)]
        public string PermanentAddress { get; set; }


        [Required(ErrorMessage = "Please Enter Employee Location Name")]
        public long LocationId { get; set; }

        public string LocationName { get; set; }
        public string PositionName { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Position Name")]
        public long PositionId { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Phone Number")]
        [DataType(DataType.PhoneNumber)]

        public string PhoneNumber { get; set; }

        public int IsUserOfSystem { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Birth Date")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Joining Date")]
        public DateTime JoiningDate { get; set; }

        public string MaritalStatus { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Present Salary")]
        public float Salary { get; set; }
    }
}