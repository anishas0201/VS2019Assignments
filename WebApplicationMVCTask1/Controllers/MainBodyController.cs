using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using WebApplicationMVCTask1.DAL;
using WebApplicationMVCTask1.Interface;
using WebApplicationMVCTask1.Models;

namespace WebApplicationMVCTask1.Controllers
{
    public class MainBodyController : Controller
    {
        BodyInterface IBody = new BodyCls();
        AdmissionFormInterface IForm = new AdmissionFormClass();
        DropDownClass ddcls = new DropDownClass();
        public IActionResult Dashboard()
        {
            ViewBag.sess = HttpContext.Session.GetString("text");
            return View();
            //  return View();
        }

        public IActionResult RoleMaster()
        {
            return View();
        }

        public IActionResult RoleList()
        {
            List<RoleUser> result = IBody.GetRoleList();
            return View(result);
        }


        public IActionResult DepartmentMaster()
        {
            return View();
        }

        public IActionResult DepartmentList()
        {
            List<DepartmentUser> result = IBody.GetDepartmentList();
            return View(result);
        }

        public IActionResult StudentMaster()
        {
            return View();
        }

        public IActionResult StudentList()
        {
            List<StudentUser> result = IBody.GetStudenttList();
            return View(result);
        }

        public IActionResult AdmissionForm()
        {
            var designation = ddcls.GetDesignationList();
            ViewBag.desig = new SelectList(designation, "RoleId", "RoleDesignation");

            var branch = ddcls.GetBranchList();
            ViewBag.branch = new SelectList(branch, "BranchId", "BranchName");

            var name = ddcls.GetNameList();
            ViewBag.name = new SelectList(name, "StudentId", "FirstName");

            return View();
        }

        public IActionResult AdmissionList()
        {
            List<AdmissionFormData> result = IForm.AdmissionList();
            return View(result);
        }


        public JsonResult SearchByDate(string fromDate, string toDate)
        {
            List<AdmissionFormData> result = IForm.SearchByDate(fromDate, toDate);
            try
            {
               
                return Json(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred during date search." });
            }
        }




        public JsonResult SaveForm(AdmissionFormData form)
        {
            return Json(IForm.SaveForm(form));
        }

        public ActionResult GetCollegebyId(int AdmissionId)
        {
            AdmissionFormData result = IForm.GetCollegebyId(AdmissionId);

            var designation = ddcls.GetDesignationList();
            ViewBag.desig = new SelectList(designation, "RoleId", "RoleDesignation");

            var branch = ddcls.GetBranchList();
            ViewBag.branch = new SelectList(branch, "BranchId", "BranchName");

            var name = ddcls.GetNameList();
            ViewBag.name = new SelectList(name, "StudentId", "FirstName");

            return View(result);
        }

        public JsonResult UpdateCollegeDetail(AdmissionFormData form)
        {
            return Json(IForm.UpdateCollegeDetail(form));
        }

        public JsonResult DeleteCollegeDetail(int AdmissionId)
        {
            return Json(IForm.DeleteCollegeDetail(AdmissionId));
        }


        public JsonResult SaveRole(RoleUser roleuser)
        {
            return Json(IBody.SaveRole(roleuser));
        }

        public ActionResult GetRolebyId(int RoleId)
        {
            RoleUser result = IBody.GetRolebyId(RoleId);
            return View(result);
        }

        public JsonResult DeleteRole(int RoleId)
        {
            return Json(IBody.DeleteRole(RoleId));
        }

        public JsonResult UpdateRole(RoleUser roleuser)
        {
            return Json(IBody.UpdateRole(roleuser));
        }



        public JsonResult SaveDepartment(DepartmentUser depuser)
        {
            return Json(IBody.SaveDepartment(depuser));
        }

        public ActionResult GetDepartmentbyId(int BranchId)
        {
            DepartmentUser result = IBody.GetDepartmentbyId(BranchId);
            return View(result);
        }

        public JsonResult DeleteDepartment(int BranchId)
        {
            return Json(IBody.DeleteDepartment(BranchId));
        }

        public JsonResult UpdateDepartment(DepartmentUser depuser)
        {
            return Json(IBody.UpdateDepartment(depuser));
        }



        public JsonResult SaveStudent(StudentUser stuser)
        {
            return Json(IBody.SaveStudent(stuser));
        }

        public ActionResult GetStudentbyId(int StudentId)
        {
            StudentUser result = IBody.GetStudentbyId(StudentId);
            return View(result);
        }

        public JsonResult DeleteStudent(int StudentId)
        {
            return Json(IBody.DeleteStudent(StudentId));
        }

        public JsonResult UpdateStudent(StudentUser stuser)
        {
            return Json(IBody.UpdateStudent(stuser));
        }

    }
}
