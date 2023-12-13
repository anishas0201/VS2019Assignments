using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVCTask1.DAL;
using WebApplicationMVCTask1.Interface;
using WebApplicationMVCTask1.Models;

namespace WebApplicationMVCTask1.Controllers
{
    public class LoginController : Controller
    {
        RegisterInterface IRegister = new RegisterCls();
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public JsonResult SignUpAction(RegisterUser objmodel)
        {
            var res = IRegister.SignUpAction(objmodel);

            return Json(res);
        }
        [HttpPost]
        public IActionResult CheckLogin(RegisterUser objmodel)
        {
            var res = IRegister.CheckLogin(objmodel);
            if (res.status == true)
            {
                HttpContext.Session.SetString("text", objmodel.Name);
                return RedirectToAction("Dashboard", "MainBody");
            }
            TempData["error"] = "invalid credetial";
            return RedirectToAction("Login", "Login");           
        }



    }
}
