using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMVCTask1.Models
{
    public class RoleUser
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }       
        public string RoleDesignation { get; set; }
        public DateTime CreatedDate { get; set; }
        public Boolean IsActive { get; set; }
    }

    public class RoleList
    {
        public int RoleId { get; set; }
        public string RoleDesignation { get; set; }
    }

    public class DepartmentUser
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string HODName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Boolean IsActive { get; set; }
    }
    public class DepartmentList
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }


    public class StudentUser
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Session { get; set; }
        public string Email { get; set; }
        public int ContactNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
    }

    public class StudentList
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
    }


    public class AdmissionFormData
    {
        public int AdmissionId { get; set; }
        public string CollegeName { get; set; }
        public string StudentName { get; set; }
        public string BranchName { get; set; }
        public string RoleDesignation { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int CollegeFees { get; set; }
        public Boolean IsPaymentDone { get; set; }
        public Boolean IsActive { get; set; }
    }
}
