using DataMangement.Encryption;
using Dm.BAL.UserManager;
using Dm.Common.Models;
using Dm.Common.Models.Enum;
using log4net.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataMangement.Controllers
{

    public class HomeController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ILogger _logger;
        public readonly ISession session;

        public HomeController(IHttpContextAccessor httpContextAccessor, IHostingEnvironment environment)
        {
            session = httpContextAccessor.HttpContext.Session;
            hostingEnvironment = environment;

        }

        public readonly UserManager UserManager = new UserManager();


        public IActionResult Index()
        {
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
        /// <summary>
        /// Login View
        /// </summary>
        /// <returns></returns>

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
                session.SetString("UserName", users.UserName.ToString());
                session.SetString("roleId", users.roleId.ToString());

                log.Info("login");
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
        /// Registration View
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

        /// <summary>
        ///  Deshboard View 
        /// </summary>
        /// <returns></returns>
        public IActionResult Dashboard()
        {
            //Check Login 
            string data = session.GetString("UserName");
            if (data == null)
            {
                return RedirectToAction("login");
            }
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
        ///  AJEX Call Use Year_TreeView
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetYearData()
        {
            List<YearTree> yearList = UserManager.yearList();
            YearTree objUser = new YearTree();
            if (yearList.Count > 0)
            {

            }
            return Json(yearList);
        }

        /// <summary>
        ///  AJEX Call Use Month_TreeView
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetMonthData(int id)
        {
            List<YearTree> MonthList = UserManager.MonthList(id);
            YearTree objUser = new YearTree();
            if (MonthList.Count > 0)
            {

            }
            return Json(MonthList);
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
        /// <param name = "id" ></ param >
        /// < returns ></ returns >
        public IActionResult GetProfile(int id)
        {
            Registration List = UserManager.profile(id);
            if (id > 0)
            {
                return View(List);
            }
            else
            {
                return BadRequest(new { status = 401 });
            }

        }

        /// <summary>
        /// Update Profile
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetProfile(Registration Profile)
        {
            UserManager UserManager = new UserManager();
            if (UserManager.editProfile(Profile))
            {
                return RedirectToAction("UserList");
            }
            else
            {
                return Ok(new { status = 200, message = " fail" });
            }
        }

        /// <summary>
        /// MasterCategory View
        /// </summary>Get-Method
        /// <returns></returns>
        public IActionResult MasterCategory()
        {

            return View();
        }

        /// <summary>
        ///Add MasterCategory
        /// </summary>Post-Method
        /// <returns></returns>
        //[HttpPost]
        //public IActionResult MasterCategory(MasterCategory users)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(users);
        //    }
        //    UserManager UserManager = new UserManager();

        //    MasterMenu item = new MasterMenu
        //    {
        //        name = users.name
        //    };

        //    if (UserManager.CategoryAdd(item, LevelEnum.Level1))
        //    {
        //        return RedirectToAction("Category");
        //    }
        //    else
        //    {
        //        return new UnauthorizedResult();
        //    }
        //}

        /// <summary>
        /// Category View
        /// </summary>Get-Method
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
        ///Add New Category
        /// </summary>Post-Method
        /// <returns></returns>
        [HttpPost]
        public IActionResult Category(Category users)
        {
            UserManager UserManager = new UserManager();
            if (!ModelState.IsValid)
            {
                List<Category> CategoryList = UserManager.Category();
                Category CategoryValues = new Category();
                if (CategoryList.Count > 0)
                {
                    CategoryValues.listOfCategory = new SelectList(CategoryList, "Id", "name");
                }
                return View(CategoryValues);
            }


            MasterMenu item = new MasterMenu
            {
                parentCategoryId = users.mainCategory,
                name = users.name
            };

            if (UserManager.CategoryAdd(item, LevelEnum.Level2))
            {
                return RedirectToAction("Category1");
            }
            else
            {
                return new UnauthorizedResult();
            }
        }
        /// <summary>
        /// Category1 View
        /// </summary>
        /// <returns></returns>
        public IActionResult Category1()
        {
            List<Category> CategoryList = UserManager.Category();
            List<Category1> CategoryList1 = UserManager.Category1();
            Category1 CategoryValues = new Category1();
            if (CategoryList.Count > 0)
            {
                CategoryValues.listOfCategory = new SelectList(CategoryList, "Id", "name");
                CategoryValues.listOfCategory1 = new SelectList(CategoryList1, "Id", "name");
            }
            return View(CategoryValues);
        }

        /// <summary>
        /// Add New Category1
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Category1(Category1 users)
        {
            UserManager UserManager = new UserManager();
            if (!ModelState.IsValid)
            {
                List<Category> CategoryList = UserManager.Category();
                List<Category1> CategoryList1 = UserManager.Category1();
                Category1 CategoryValues = new Category1();
                if (CategoryList.Count > 0)
                {
                    CategoryValues.listOfCategory = new SelectList(CategoryList, "Id", "name");
                    CategoryValues.listOfCategory1 = new SelectList(CategoryList1, "Id", "name");
                }
                return View(CategoryValues);
            }


            MasterMenu item = new MasterMenu
            {
                parentCategoryId = users.mainCategory,
                name = users.name
            };

            if (UserManager.CategoryAdd(item, LevelEnum.Level3))
            {
                return RedirectToAction("Category2");
            }
            else
            {
                return new UnauthorizedResult();
            }

        }

        /// <summary>
        /// Category2 View
        /// </summary>
        /// <returns></returns>
        public IActionResult Category2()
        {
            List<Category> CategoryList = UserManager.Category();
            List<Category1> CategoryList1 = UserManager.Category1();
            List<Category2> CategoryList2 = UserManager.Category2();
            Category2 CategoryValues = new Category2();
            if (CategoryList.Count > 0)
            {
                CategoryValues.listOfCategory = new SelectList(CategoryList, "Id", "name");
                CategoryValues.listOfCategory1 = new SelectList(CategoryList1, "Id", "name");
                CategoryValues.listOfCategory2 = new SelectList(CategoryList2, "Id", "name");
            }
            return View(CategoryValues);
        }

        /// <summary>
        ///  Add New Category2
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Category2(Category2 users)
        {
            UserManager UserManager = new UserManager();
            if (!ModelState.IsValid)
            {

                List<Category> CategoryList = UserManager.Category();
                List<Category1> CategoryList1 = UserManager.Category1();
                List<Category2> CategoryList2 = UserManager.Category2();
                Category2 CategoryValues = new Category2();
                if (CategoryList.Count > 0)
                {
                    CategoryValues.listOfCategory = new SelectList(CategoryList, "Id", "name");
                    CategoryValues.listOfCategory1 = new SelectList(CategoryList1, "Id", "name");
                    CategoryValues.listOfCategory2 = new SelectList(CategoryList2, "Id", "name");
                }
                return View(CategoryValues);
            }


            MasterMenu item = new MasterMenu
            {
                parentCategoryId = users.mainCategory,
                name = users.name
            };

            if (UserManager.CategoryAdd(item, LevelEnum.Level4))
            {
                return RedirectToAction("Category3");
            }
            else
            {
                return new UnauthorizedResult();
            }

        }

        /// <summary>
        /// Category3 View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Category3(string InOut)
        {
            //Check Login 
            string data = session.GetString("UserName");
            if (data == null)
            {
                return RedirectToAction("login");
            }

            TempData["InOutPage"] = InOut;

            List<Category> CategoryList = UserManager.Category();
            List<Category1> CategoryList1 = UserManager.Category1();
            List<Category2> CategoryList2 = UserManager.Category2();
            List<Category3> CategoryList3 = UserManager.Category3();
            Category3 CategoryValues = new Category3();

            if (CategoryList.Count > 0)
            {
                CategoryValues.InOut = InOut;
                CategoryValues.listOfCategory = new SelectList(CategoryList, "Id", "name");
                CategoryValues.listOfCategory1 = new SelectList(CategoryList1, "Id", "name");
                CategoryValues.listOfCategory2 = new SelectList(CategoryList2, "Id", "name");
                CategoryValues.listOfCategory3 = new SelectList(CategoryList3, "Id", "name");
            }
            return View(CategoryValues);
        }

        /// <summary>
        ///  Category3 Submit
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Category3(Category3 users)
        {

            if (!ModelState.IsValid)
            {
                List<Category> CategoryList = UserManager.Category();
                List<Category1> CategoryList1 = UserManager.Category1();
                List<Category2> CategoryList2 = UserManager.Category2();
                List<Category3> CategoryList3 = UserManager.Category3();
                Category3 CategoryValues = new Category3();
                if (CategoryList.Count > 0)
                {
                    CategoryValues.listOfCategory = new SelectList(CategoryList, "Id", "name");
                    CategoryValues.listOfCategory1 = new SelectList(CategoryList1, "Id", "name");
                    CategoryValues.listOfCategory2 = new SelectList(CategoryList2, "Id", "name");
                    CategoryValues.listOfCategory3 = new SelectList(CategoryList3, "Id", "name");
                }

                return View(CategoryValues);
            }
            else
            {

                string queryString = users.mainCategory + "," + users.subCategory1 + "," + users.subCategory2 + "," + users.subCategory3;
                //if (users.InOut == "InWard")
                //{
                return RedirectToAction("InBound", new { id = CryptoEngine.Encrypt(queryString) });
                //}
                //else
                //{
                //    return RedirectToAction("OutBound", new { id = CryptoEngine.Encrypt(queryString) });
                //}
            }
        }

        /// <summary>
        /// for Display Category Step in Header
        /// </summary>InBound View
        /// <returns></returns>
        [HttpGet]
        public IActionResult InBound([FromRoute] string id)
        {
            TempData.Keep();
            if (id != null)
            {
                string decrypt = CryptoEngine.Decrypt(id);
                string[] ids = decrypt.Split(",");
                TempData["ids"] = ids;

                if (ids.Length > 0 && ids[0] != "")
                {

                    string Maincategory = UserManager.GetCategoryById(Convert.ToInt32(ids[0]));
                    string subCategory1 = UserManager.GetCategoryById(Convert.ToInt32(ids[1]));
                    string subCategory2 = UserManager.GetCategoryById(Convert.ToInt32(ids[2]));
                    string subCategory3 = UserManager.GetCategoryById(Convert.ToInt32(ids[3]));

                    //for Display Navigation

                    ViewBag.Maincategory = Maincategory;
                    ViewBag.subCategory1 = subCategory1;
                    ViewBag.subCategory2 = subCategory2;
                    ViewBag.subCategory3 = subCategory3;
                    ViewBag.FileMonth = TempData["month"];
                    ViewBag.FileYear = TempData["year"];
                    if (ViewBag.FileYear == null)
                    {
                        ViewBag.FileYear = "2018";
                    }

                    TempData["Cat1"] = Maincategory;
                    TempData["Cat2"] = subCategory1;
                    TempData["Cat3"] = subCategory2;
                    TempData["Cat4"] = subCategory3;
                    TempData.Keep();
                }
            }
            else
            {
                ViewBag.Maincategory = TempData["Cat1"];
                ViewBag.subCategory1 = TempData["Cat2"];
                ViewBag.subCategory2 = TempData["Cat3"];
                ViewBag.subCategory3 = TempData["Cat4"];
                ViewBag.FileMonth = TempData["month"];
                ViewBag.FileYear = TempData["year"];
                TempData.Keep();
            }

            return View();
        }

        /// <summary>
        /// Final Data Upload
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InBound(FinalDataUpload files, [FromRoute] string id)
        {

            string[] ids = TempData["ids"] as string[];
            TempData.Keep("ids");

            //ids = decrypt.Split(",");
            //TempData["ids"] = ids;

            string Maincategory = UserManager.GetCategoryById(Convert.ToInt32(ids[0]));
            string subCategory1 = UserManager.GetCategoryById(Convert.ToInt32(ids[1]));
            string subCategory2 = UserManager.GetCategoryById(Convert.ToInt32(ids[2]));
            string subCategory3 = UserManager.GetCategoryById(Convert.ToInt32(ids[3]));

            if (!ModelState.IsValid)
            {
                return View(files);
            }
            UserManager userManager = new UserManager();
            //Get decrypt Ids 
            //string decrypt = CryptoEngine.Decrypt(id);
            //string[] ids = decrypt.Split(",");

            string uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads/InWard/" + Maincategory + "/" + subCategory1 + "/" + subCategory2 + "/" + subCategory3 + "/" + files.year + "/" + files.month + "/");
            string filePath = Path.Combine(uploads, files.fileName.FileName);

            //Fill Id in Model 
            files.parentCategoryId = Convert.ToInt32(ids[0]);
            files.categoryId1 = Convert.ToInt32(ids[1]);
            files.categoryId2 = Convert.ToInt32(ids[2]);
            files.categoryId3 = Convert.ToInt32(ids[3]);

            //fill file name & path
            files.FileName = files.fileName.FileName;
            files.FilePath = filePath;
            files.createdBy = session.GetString("UserName");

            if (UserManager.FinalDataUpload(files))
            {
                if (files.fileName != null)
                {
                    string uniqueFileName = files.fileName.ToString();
                    //If Directory not exist it will create directory
                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        files.fileName.CopyToAsync(fileStream);
                    }
                }


                return RedirectToAction("InBound");
            }
            else
            {
                return new UnauthorizedResult();
            }
        }

        /// <summary>
        ///  GetInwardFileList Using AJAX
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetFinalDataList(GetFinalDataList Data, string month, string year)
        {
            if (year == null)
            {   //Fill Year Month
                TempData["year"] = "2018";
                TempData["month"] = month;
                Data.year = TempData["year"].ToString();
                Data.month = month;
            }
            if (year != null)
            {
                TempData["month"] = month;
                TempData["year"] = year;
                Data.year = year;
                Data.month = month;
            }
            //string draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            //// Skiping number of Rows count
            string start = HttpContext.Request.Form["start"].FirstOrDefault();
            //// Paging Length 10,20
            string length = Request.Form["length"].FirstOrDefault();

            //Paging Size (10,20,50,100)
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int index = Convert.ToInt32(start) / Convert.ToInt32(length);


            //Get Id 
            string[] ids = TempData["ids"] as string[];
            TempData.Keep();

            if (ids != null)
            {
                Data.parentCategoryId = Convert.ToInt32(ids[0]);
                Data.categoryId1 = Convert.ToInt32(ids[1]);
                Data.categoryId2 = Convert.ToInt32(ids[2]);
                Data.categoryId3 = Convert.ToInt32(ids[3]);

            }

            Data.pageIndex = index;
            Data.pageSize = pageSize;

            List<GetFinalDataList> GetFinalDataList = UserManager.GetFinalDataList(Data);
            GetFinalDataList objUser = new GetFinalDataList();

            if (GetFinalDataList.Count > 0)
            {

            }


            return Json(GetFinalDataList);
        }

        /// <summary>
        ///  AJAX Call EditInwardFile
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult EditInwardFile(int id)
        {
            List<GetFinalDataList> EditInwardFile = UserManager.EditInwardFile(id);
            GetFinalDataList objUser = new GetFinalDataList();
            if (EditInwardFile.Count > 0)
            {

            }
            return Json(EditInwardFile);
        }

        /// <summary>
        /// AJAX Call UpdateInwardFile
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateInwardFile(FinalDataUpload files)
        {

            if (!ModelState.IsValid)
            {
                return View(files);
            }

            UserManager UserManager = new UserManager();

            string[] ids = TempData["ids"] as string[];
            object month = TempData["month"];
            object year = TempData["year"];
            TempData.Keep("ids");

            //conver int to string for folder path
            string Maincategory = UserManager.GetCategoryById(Convert.ToInt32(ids[0]));
            string subCategory1 = UserManager.GetCategoryById(Convert.ToInt32(ids[1]));
            string subCategory2 = UserManager.GetCategoryById(Convert.ToInt32(ids[2]));
            string subCategory3 = UserManager.GetCategoryById(Convert.ToInt32(ids[3]));


            string filePath = string.Empty;
            string uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads/InWard/" + Maincategory + "/" + subCategory1 + "/" + subCategory2 + "/" + subCategory3 + "/" + year + "/" + month + "/");
            if (files.fileName != null)
            {

                filePath = Path.Combine(uploads, files.fileName.FileName);

                files.FileName = files.fileName.FileName;
                files.FilePath = filePath;

            }

            //Fill Id in Model 
            files.parentCategoryId = Convert.ToInt32(ids[0]);
            files.categoryId1 = Convert.ToInt32(ids[1]);
            files.categoryId2 = Convert.ToInt32(ids[2]);
            files.categoryId3 = Convert.ToInt32(ids[3]);
            files.year = year.ToString();
            files.month = month.ToString();

            //fill file name & path

            if (UserManager.UpdateInwardFile(files))
            {
                if (files.fileName != null)
                {
                    string uniqueFileName = files.fileName.ToString();
                    //If Directory not exist it will create directory
                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        files.fileName.CopyToAsync(fileStream);
                    }
                }

                return RedirectToAction("InBound");
            }
            else
            {
                return new UnauthorizedResult();
            }

        }

        /// <summary>
        /// AJAX Call DeleteInwardFile
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DeleteInwardFile(int Id)
        {
            UserManager UserManager = new UserManager();

            if (UserManager.DeleteInwardFile(Id))
            {
                return Json("Deleted");
            }
            else
            {
                return new UnauthorizedResult();
            }
        }


        /// <summary>
        /// DownloadInwardFile
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DownloadInwardFile(int Id)
        {
            {
                List<GetFinalDataList> EditInwardFile = UserManager.EditInwardFile(Id);
                GetFinalDataList objUser = new GetFinalDataList();

                string filePath = EditInwardFile[0].FilePath;
                string fileName = EditInwardFile[0].FileName;

                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                return File(fileBytes, "application/force-download", fileName);

            }
        }



        ///OutWard Code
        /// <summary>
        /// for Display Category Step in Header
        /// </summary>OutWard View
        /// <returns></returns>
        [HttpGet]
        public IActionResult OutWard()
        {
            //TempData.Keep();
            //if (id != null)
            //{
            //    string decrypt = CryptoEngine.Decrypt(id);
            //    string[] ids = decrypt.Split(",");
            //    TempData["ids"] = ids;

            //    string Maincategory = UserManager.GetCategoryById(Convert.ToInt32(ids[0]));
            //    string subCategory1 = UserManager.GetCategoryById(Convert.ToInt32(ids[1]));
            //    string subCategory2 = UserManager.GetCategoryById(Convert.ToInt32(ids[2]));
            //    string subCategory3 = UserManager.GetCategoryById(Convert.ToInt32(ids[3]));

            //    //for Display Navigation

            //    ViewBag.Maincategory = Maincategory;
            //    ViewBag.subCategory1 = subCategory1;
            //    ViewBag.subCategory2 = subCategory2;
            //    ViewBag.subCategory3 = subCategory3;
            //    ViewBag.FileMonth = TempData["month"];
            //    ViewBag.FileYear = TempData["year"];
            //    if (ViewBag.FileYear == null)
            //    {
            //        ViewBag.FileYear = "2018";
            //    }

            //    TempData["Cat1"] = Maincategory;
            //    TempData["Cat2"] = subCategory1;
            //    TempData["Cat3"] = subCategory2;
            //    TempData["Cat4"] = subCategory3;
            //    TempData.Keep();
            //}
            //else
            //{
            //    ViewBag.Maincategory = TempData["Cat1"];
            //    ViewBag.subCategory1 = TempData["Cat2"];
            //    ViewBag.subCategory2 = TempData["Cat3"];
            //    ViewBag.subCategory3 = TempData["Cat4"];
            //    ViewBag.FileMonth = TempData["month"];
            //    ViewBag.FileYear = TempData["year"];
            //    TempData.Keep();
            //}
            return View();
        }

        //[HttpPost]
        //public IActionResult OutWard(FinalDataUpload files, [FromRoute] string id)
        //{

        //    string[] ids = TempData["ids"] as string[];
        //    TempData.Keep("ids");

        //    //ids = decrypt.Split(",");
        //    //TempData["ids"] = ids;

        //    string Maincategory = UserManager.GetCategoryById(Convert.ToInt32(ids[0]));
        //    string subCategory1 = UserManager.GetCategoryById(Convert.ToInt32(ids[1]));
        //    string subCategory2 = UserManager.GetCategoryById(Convert.ToInt32(ids[2]));
        //    string subCategory3 = UserManager.GetCategoryById(Convert.ToInt32(ids[3]));

        //    if (!ModelState.IsValid)
        //    {
        //        return View(files);
        //    }
        //    UserManager userManager = new UserManager();
        //    //Get decrypt Ids 
        //    //string decrypt = CryptoEngine.Decrypt(id);
        //    //string[] ids = decrypt.Split(",");

        //    string uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads/OutWard/" + Maincategory + "/" + subCategory1 + "/" + subCategory2 + "/" + subCategory3 + "/" + files.year + "/" + files.month + "/");
        //    string filePath = Path.Combine(uploads, files.fileName.FileName);

        //    //Fill Id in Model 
        //    files.parentCategoryId = Convert.ToInt32(ids[0]);
        //    files.categoryId1 = Convert.ToInt32(ids[1]);
        //    files.categoryId2 = Convert.ToInt32(ids[2]);
        //    files.categoryId3 = Convert.ToInt32(ids[3]);

        //    //fill file name & path
        //    files.FileName = files.fileName.FileName;
        //    files.FilePath = filePath;
        //    files.createdBy = session.GetString("UserName");

        //    if (UserManager.FinalDataUpload(files))
        //    {
        //        if (files.fileName != null)
        //        {
        //            string uniqueFileName = files.fileName.ToString();
        //            //If Directory not exist it will create directory
        //            if (!Directory.Exists(uploads))
        //            {
        //                Directory.CreateDirectory(uploads);
        //            }
        //            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                files.fileName.CopyToAsync(fileStream);
        //            }
        //        }


        //        return RedirectToAction("OutWard");
        //    }
        //    else
        //    {
        //        return new UnauthorizedResult();
        //    }
        //}
    }
}




