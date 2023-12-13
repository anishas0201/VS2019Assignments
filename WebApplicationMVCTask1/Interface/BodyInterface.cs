using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMVCTask1.Models;

namespace WebApplicationMVCTask1.Interface
{
    public interface BodyInterface
    {
        ResponseModel SaveRole(RoleUser roleuser);

        List<RoleUser> GetRoleList();

        RoleUser GetRolebyId(int RoleId);

        ResponseModel DeleteRole(int RoleId);

        ResponseModel UpdateRole(RoleUser roleuser);


        ResponseModel SaveDepartment(DepartmentUser depuser);

        List<DepartmentUser> GetDepartmentList();

        DepartmentUser GetDepartmentbyId(int BranchId);

        ResponseModel DeleteDepartment(int BranchId);

        ResponseModel UpdateDepartment(DepartmentUser depuser);


        ResponseModel SaveStudent(StudentUser stuser);

        List<StudentUser> GetStudenttList();

        StudentUser GetStudentbyId(int StudentId);

        ResponseModel DeleteStudent(int StudentId);

        ResponseModel UpdateStudent(StudentUser stuser);
    }
}
