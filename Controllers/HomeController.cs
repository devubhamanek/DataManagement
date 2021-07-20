using Dm.BAL.UserManager;
using Dm.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace DataMangement.Controllers
{
    public class HomeController : Controller
    {

        public readonly ISession session;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor.HttpContext.Session;
        }

        public readonly UserManager UserManager = new UserManager();
        public IActionResult Index()
        {


            ViewData["Test"] = "";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Login View
        public IActionResult login()
        {
            return View();
        }
        /// <summary>
        /// Login 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult login(UserLogin login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            UserLogin users = new UserLogin();
            users = UserManager.AuthenticateUser(login.Email, login.Password);
            IActionResult response = Unauthorized();
            if (users != null && users.UserID > 0)
            {
                session.SetString("Test", users.UserName.ToString());
                session.SetString("roleId", users.roleId.ToString());
                //Request.Cookies = users.UserName.ToString();

                //CookieOptions option = new CookieOptions
                //{
                //    Expires = DateTime.Now.AddHours(24)
                //};
                var x = HttpContext.Session.GetString("Test");
                //Response.Cookies.Append("Test", users.UserName.ToString(), option);
                return RedirectToAction("Dashboard");

            }
            else
            {
                ViewBag.ErrorMessage = "Email or Password not found or matched";
                return View();
            }
        }
        /// <summary>
        ///AdminDashboard Deshboard View
        /// </summary>
        /// <returns></returns>
        public IActionResult AdminDashboard()
        {
            return View();
        }
        /// <summary>
        /// Registration 
        /// </summary>
        /// <returns></returns>
        public IActionResult Registration()
        {
            return View();
        }
        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Registration(Registration users)
        {
            if (!ModelState.IsValid)
            {
                return View(users);
            }
            UserManager userManager = new UserManager();

            if (UserManager.RegisterUser(users))
            {
                return RedirectToAction("login");
            }
            else
            {
                return new UnauthorizedResult();
            }

        }

        //Deshboard View 
        public IActionResult Dashboard()
        {
            return View();
        }

        /// <summary>
        /// forgot Password View
        /// </summary>
        /// <returns></returns>
        public IActionResult ForgotPassword()
        {
            return View();
        }

        /// <summary>
        /// forgot Password
        /// </summary>
        /// <param name="forgot"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPassword forgot)
        {
            if (!ModelState.IsValid)
            {
                return View(forgot);
            }
            UserManager userManager = new UserManager();
            if (userManager.ForgotPassword(forgot))
            {
                return RedirectToAction("login");
            }
            else
            {
                return BadRequest(new { Message = "User Not Exist" });
            }

        }
        /// <summary>
        /// Display Dropdown View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SubMenu()
        {
            List<SubMenu> SubMenuList = UserManager.SubMenu();
            SubMenu CategoryValues = new SubMenu();
            if (SubMenuList.Count > 0)
            {
                CategoryValues.listOfCategory = new SelectList(SubMenuList, "Id", "name");
            }
            return View(CategoryValues);
        }


        /// <summary>
        ///Get Dropdown List
        /// </summary>
        /// <param name="CategoryValues"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SubMenu(SubMenu CategoryValues)
        {
            List<SubMenu> SubMenuList = UserManager.SubMenu();
            if (SubMenuList.Count > 0)
            {
                ViewBag.obj = SubMenuList;
                return RedirectToAction("SubMenu");
            }
            else
            {
                return BadRequest(new { status = 401 });
            }

        }

        /// <summary>
        /// for Display Menu in Header
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult InBound()
        {
            List<SubMenu> categoryList = UserManager.InBound();
            SubMenu CategoryValues = new SubMenu();
            if (categoryList.Count > 0)
            {
                ViewBag.listOfCategory = categoryList;
            }
            return View(ViewBag.listOfCategory);
        }
        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }



        /// <summary>
        /// UserList View
        /// </summary>
        /// <returns></returns>
        public IActionResult UserList()
        {
            return View();
        }

        /// <summary>
        ///  UserList Get
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UserList(string Action)
        {
            List<Registration> returndata = UserManager.CategoryDetail(Action);

            if (returndata == null)
            {
                return NotFound();
            }

            return View(returndata);
        }
        /// <summary>
        /// Get User Profile
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public IActionResult GetProfile(int id)
        //{
        //    Registration List = UserManager.profile(id);
        //    if (id > 0)
        //    {
        //        return View(List);
        //    }
        //    else
        //    {
        //        return BadRequest(new { status = 401 });
        //    }

        //}
        /// <summary>
        /// Update Profile
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        //[HttpPost]
        //public IActionResult GetProfile(Registration Profile)
        //{
        //    UserManager UserManager = new UserManager();
        //    if (UserManager.editProfile(Profile))
        //    {
        //        return RedirectToAction("UserList");
        //    }
        //    else
        //    {
        //        return Ok(new { status = 200, message = " fail" });
        //    }
        //}

        /// <summary>
        /// Category View
        /// </summary>
        /// <returns></returns>
        public IActionResult Category()
        {
            List<Category> CategoryList = UserManager.Category();
            Category CategoryValues = new Category();
            if (CategoryList.Count > 0)
            {
                CategoryValues.listOfCategory = new SelectList(CategoryList, "Id", "name");
            }
            return View(CategoryValues);
        }

        /// <summary>
        /// Category1 View
        /// </summary>
        /// <returns></returns>
        public IActionResult Category1()
        {
            return View();
        }

        /// <summary>
        /// Category2 View
        /// </summary>
        /// <returns></returns>
        public IActionResult Category2()
        {
            return View();
        }

        /// <summary>
        /// Category3 View
        /// </summary>
        /// <returns></returns>
        public IActionResult Category3()
        {
            return View();
        }
    }
}
