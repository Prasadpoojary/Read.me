using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReadME.Repository;
using Microsoft.AspNetCore.Http;
using ReadME.Models;
using ReadME.Database;

namespace ReadME.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookRepo _bookRepo;
        private readonly ICourseRepo _courseRepo;
        private readonly ISpecificationRepo _specificationRepo;
        private readonly IUserRepo _userRepo;
        private readonly IPaymentRepo _paymentRepo;
        private readonly ISavedRepo _savedRepo;
        private readonly IAdminRepo _adminRepo;
        private readonly IReportRepo _reportdRepo;
        private readonly ITicketRepo _ticketRepo;
        private readonly INotificationRepo _notificationRepo;
        private readonly DataContext _dataContext;

        public AdminController(DataContext dataContext, INotificationRepo notificationRepo, ITicketRepo ticketRepo, IReportRepo reportdRepo, IAdminRepo adminRepo, IBookRepo bookRepo, ICourseRepo courseRepo, ISpecificationRepo specificationRepo, IUserRepo userRepo, IPaymentRepo paymentRepo, ISavedRepo savedRepo)
        {

           
            _bookRepo = bookRepo;
            _courseRepo = courseRepo;
            _userRepo = userRepo;
            _specificationRepo = specificationRepo;
            _paymentRepo = paymentRepo;
            _savedRepo = savedRepo;
            _adminRepo = adminRepo;
            _reportdRepo = reportdRepo;
            _ticketRepo = ticketRepo;
            _notificationRepo = notificationRepo;
            _dataContext=dataContext;
        }


        
        [HttpGet]
        [Route("/admin")]
        public IActionResult Admin(string table,string id)
        {
            if (TempData["success"] == null && TempData["error"] == null)
            {
                ViewBag.message = false;
            }
            else
            {
                ViewBag.message = true;

                ViewBag.success = TempData["success"] == null ? null : TempData["success"];
                ViewBag.error = TempData["error"] == null ? null : TempData["error"];
            }

            try
            {
                bool superUserCreated = _adminRepo.GetAllAdmins().Where(admin => admin.isSuperuser == true).Any();
                if (superUserCreated == false)
                {
                    User user = new User();
                    user.Name = "Read.me";
                    user.Email = "readme.udupi@gmail.com";
                    user.Password = "Readme123@";
                    user.isVerified = true;
                    user.Earnings = 0;

                    _userRepo.AddUser(user);

                    Admin superuser = new Admin();

                    superuser.Name = "Read.me";
                    superuser.email = "readme.udupi@gmail.com";
                    superuser.password = "Readme123@";
                    superuser.isSuperuser = true;
                    superuser.earning = 0;
                    superuser.access_book = true;
                    superuser.access_comment = true;
                    superuser.access_course = true;
                    superuser.access_payment = true;
                    superuser.access_report = true;
                    superuser.access_subscriber = true;
                    superuser.access_ticket = true;
                    superuser.access_user = true;

                    _adminRepo.AddAdmin(superuser);

                }



                if (GetAdminAuth() > 0)
                {
                    Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                    ViewBag.admin = admin;

                    if (table != null && id != null)
                    {
                        if (table == "User")
                        {
                            return Redirect("admin/users?uniqueSort=" + id);
                        }

                        if (table == "Book")
                        {
                            return Redirect("admin/books?uniqueSort=" + id);
                        }

                        if (table == "Course")
                        {
                            return Redirect("admin/courses?uniqueSort=" + id);
                        }

                        if (table == "Category")
                        {
                            return Redirect("admin/category?uniqueSort=" + id);
                        }

                        if (table == "Subscriber")
                        {
                            return Redirect("admin/subscribers?uniqueSort=" + id);
                        }

                        if (table == "Comment")
                        {
                            return Redirect("admin/comments?uniqueSort=" + id);
                        }

                        if (table == "Payment")
                        {
                            return Redirect("admin/payments?uniqueSort=" + id);
                        }
                    }

                    return View("Views/Home/AdminView/AdminHome.cshtml");
                }


                return View("Views/Home/AdminView/AdminLogin.cshtml");
            }
            catch
            {
                ViewBag.message = true;
                ViewBag.error = "Unauthorized access";
                return View("Views/Home/AdminView/AdminLogin.cshtml");
            }
         
        }



        [HttpPost]
        [Route("/admin")]
        public async Task<IActionResult> AdminLoginAsync(string email, string password)
        {
            User user = await _userRepo.GetUserByEmail(email);
            Admin admin = _adminRepo.GetAllAdmins().Where(admin => admin.email == email).Single();
            user.Name = admin.Name;
            user.Email = admin.email;
            admin.password = user.Password;
            _dataContext.SaveChanges();

            if(admin!=null && admin?.password==password)
            {
                HttpContext.Session.SetString("AdminId", admin.Id.ToString());
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                return Redirect("/admin");
            }
            else
            {
                TempData["error"] = "Invalid Credentials";
                return Redirect("/admin");
            }


        }


        
      [HttpGet]
        [Route("/admin/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/admin");
        }


        [HttpGet]
        [Route("/admin/manage")]
        public IActionResult AdminManage()
        {
            if (GetAdminAuth() > 0)
            {

                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;

                if(!admin.isSuperuser)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }

                List<Admin> admins = _adminRepo.GetAllAdmins();
                ViewBag.admins = admins;

                if(admin.isSuperuser==true)
                {
                    return View("Views/Home/AdminView/AdminManage.cshtml");
                }
            }

            
                TempData["error"] = "Unauthorized access";
                return Redirect("/admin");
           

        }

        [HttpGet]
        [Route("/admin/delete/{id}")]
        public IActionResult AdminDelete(int id)
        {
            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;

               
                

                if (admin.isSuperuser == true)
                {
                   

                    Admin targetAdmin = _adminRepo.GetAdmin(id);
                    _dataContext.Admins.Remove(targetAdmin);
                    _dataContext.SaveChanges();

                    List<Admin> admins = _adminRepo.GetAllAdmins();
                    ViewBag.admins = admins;
                    ViewBag.message = true;
                    ViewBag.success = "Adim deleted";

                    return View("Views/Home/AdminView/AdminManage.cshtml");
                }
            }

            TempData["error"] = "Unauthorized access";
            return Redirect("/admin");

        }



        [HttpGet]
        [Route("/admin/edit/{id}")]
        public IActionResult EditAdminForm(int id)
        {
            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;

                Admin targetAdmin= _adminRepo.GetAdmin(id);
                ViewBag.targetAdmin = targetAdmin;

                if (admin.isSuperuser == true)
                {
                    return View("Views/Home/AdminView/EditAdmin.cshtml");
                }
            }

            TempData["error"] = "Unauthorized access";
            return Redirect("/admin");

        }

        [HttpPost]
        [Route("/admin/edit/{id}")]
        public async Task<IActionResult> EditAdminAsync(int id, string username, string email)
        {
            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;

                
                

                if (admin.isSuperuser == true)
                {
                    Admin targetAdmin = _adminRepo.GetAdmin(id);

                    User user = await _userRepo.GetUserByEmail(targetAdmin.email);

                    if (username != null)
                    {
                        user.Name = username;
                        targetAdmin.Name = username;

                    }

                    if (email != null)
                    {
                        user.Email = email;
                        targetAdmin.email = email;
                    }
                   
                        
               

                    _dataContext.SaveChanges();
                    List<Admin> admins = _adminRepo.GetAllAdmins();
                    ViewBag.admins = admins;
                    ViewBag.message = true;
                    ViewBag.success = "Adim details edited";
                    return View("Views/Home/AdminView/AdminManage.cshtml");
                }
            }

            TempData["error"] = "Unauthorized access";
            return Redirect("/admin");

        }



        [HttpGet]
        [Route("/admin/add")]
        public IActionResult AddAdmin()
        {
            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;

               
               

                if (admin.isSuperuser == true)
                {
                    return View("Views/Home/AdminView/AddAdmin.cshtml");
                }
            }

            TempData["error"] = "Unauthorized access";
            return Redirect("/admin");

        }




        [HttpPost]
        [Route("/admin/add")]
        public IActionResult AddAmin(string username, string email, string password)
        {
            if (GetAdminAuth() > 0)
            {
                User user = new User();
                user.Name = username;
                user.Email = email;
                user.Password = password;
                user.isVerified = true;
                user.Earnings = 0;

                _userRepo.AddUser(user);


                Admin newAdmin = new Admin();
                newAdmin.Name = username;
                newAdmin.email = email;
                newAdmin.password = password;
                newAdmin.isSuperuser = false;
                newAdmin.earning = 0;
                newAdmin.access_book = false;
                newAdmin.access_comment = false;
                newAdmin.access_course = false;
                newAdmin.access_payment = false;
                newAdmin.access_report = false;
                newAdmin.access_subscriber = false;
                newAdmin.access_ticket = false;
                newAdmin.access_user = false;

                _adminRepo.AddAdmin(newAdmin);
                _dataContext.SaveChanges();


                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;



                List<Admin> admins = _adminRepo.GetAllAdmins();
                ViewBag.admins = admins;
                ViewBag.message = true;
                ViewBag.success = "Added. Provide Access";
                if (admin.isSuperuser == true)
                {
                    return View("Views/Home/AdminView/AdminManage.cshtml");
                }
            }

            TempData["error"] = "Invalid Credentials";
            return Redirect("/admin");

        }


        [HttpPost]
        [Route("/admin/edit-access/{id}")]
        public IActionResult AdminEditAccess(int id, Permission permission)
        {
            if (GetAdminAuth() > 0)
            {

               

                Admin targetAdmin=  _adminRepo.GetAdmin(id);

                if(permission?.user ==true)
                {
                    targetAdmin.access_user = true;
                }
                if (permission?.user == false)
                {
                    targetAdmin.access_user = false;
                }

                if (permission?.book == true)
                {
                    targetAdmin.access_book = true;
                }

                if (permission?.book == false)
                {
                    targetAdmin.access_book = false;
                }

                if (permission?.course == true)
                {
                    targetAdmin.access_course = true;
                }
                if (permission?.course == false)
                {
                    targetAdmin.access_course = false;
                }


                if (permission?.report == true)
                {
                    targetAdmin.access_report = true;
                }
                if (permission?.report == false)
                {
                    targetAdmin.access_report = false;
                }

                if (permission?.ticket == true)
                {
                    targetAdmin.access_ticket = true;
                }
                if (permission?.ticket == false)
                {
                    targetAdmin.access_ticket = false;
                }

                if (permission?.subscriber == true)
                {
                    targetAdmin.access_subscriber = true;
                }
                if (permission?.subscriber == false)
                {
                    targetAdmin.access_subscriber = false;
                }

                if (permission?.payment == true)
                {
                    targetAdmin.access_payment = true;
                }
                if (permission?.payment == false)
                {
                    targetAdmin.access_payment = false;
                }

                if (permission?.comment == true)
                {
                    targetAdmin.access_comment = true;
                }
                if (permission?.comment == false)
                {
                    targetAdmin.access_comment = false;
                }

              

               
                _dataContext.SaveChanges();


                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;



                List<Admin> admins = _adminRepo.GetAllAdmins();
                ViewBag.admins = admins;
                ViewBag.message = true;
                ViewBag.success = "Access modified";
              
                return Redirect("/admin/manage");
                
            }

            TempData["error"] = "Invalid Credentials";
            return Redirect("/admin");

        }



        //----------------------------------------------------------------------


        [HttpGet]
        [Route("/admin/users")]
        public IActionResult UserTable(string search, int uniqueSort)
        {
            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;

                if (!admin.access_user)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }

                List<User> users = _dataContext.Users.ToList();

                //search

                if(search!=null && search.Length>3)
                {
                    List<User> result = new List<User>();

                    try
                    {
                        string[] keywords = search.ToLower().Split(" ");

                        foreach(string key in keywords)
                        {
                            if(key.Length>3)
                            {
                                foreach (User user in users)
                                {
                                    if (!result.Contains(user) && user.Name.ToLower().Contains(key))
                                    {
                                        result.Add(user);
                                    }
                                    else if (!result.Contains(user) && user.Email.ToLower().Contains(key))
                                    {
                                        result.Add(user);
                                    }
                                }
                            }
                               
                        }

                        
                        
                    }
                    catch
                    {
                        foreach (User user in users)
                        {
                            if (!result.Contains(user) && user.Name.ToLower().Contains(search.ToLower()))
                            {
                                result.Add(user);
                            }
                            else if (!result.Contains(user) && user.Email.ToLower().Contains(search.ToLower()))
                            {
                                result.Add(user);
                            }
                        }
                    }

                    ViewBag.users = result;

                    return View("Views/Home/AdminView/AdminUser.cshtml");
                }

               
                // Unique sort
                if(uniqueSort > 0)
                {
                    users = users.Where(user => user.Id == uniqueSort).ToList();
                }
               



                ViewBag.users = users;

                return View("Views/Home/AdminView/AdminUser.cshtml");
            }
            else
            {
                return Redirect("/admin");
            }
        }

        [HttpGet]
        [Route("/admin/books")]
        public IActionResult BookTable(string search, int uniqueSort)
        {

            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;
                if (!admin.access_book)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                List<Book> books = _bookRepo.AllBooks();

                //search
                if(search!=null)
                {
                    books = SearchBook(search, books);
                }

                
                // Unique sort
                if (uniqueSort > 0)
                {
                    books = books.Where(book => book.Id == uniqueSort).ToList();
                }



                ViewBag.books = books;

                return View("Views/Home/AdminView/AdminBook.cshtml");
            }
            else
            {
                return Redirect("/admin");
            }
        }

        [HttpGet]
        [Route("/admin/courses")]
        public IActionResult CourseTable(string search, int uniqueSort)
        {
            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;
                if (!admin.access_course)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                List<Course> courses = _courseRepo.AllCourses();

                //search
                if (search != null)
                {
                    courses = SearchCourse(search, courses);
                }


                // Unique sort
                if (uniqueSort > 0)
                {
                    courses = courses.Where(course => course.Id == uniqueSort).ToList();
                }


                ViewBag.courses = courses;

                return View("Views/Home/AdminView/AdminCourse.cshtml");
            }
            else
            {
                return Redirect("/admin");
            }
        }

        [HttpGet]
        [Route("/admin/comments")]
        public IActionResult CommentTable(string search, int uniqueSort)
        {
            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;
                if (!admin.access_comment)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                List<Comment> comments = _dataContext.Comments.ToList();

                //search

                if (search != null && search.Length > 3)
                {
                    List<Comment> result = new List<Comment>();

                    try
                    {
                        string[] keywords = search.ToLower().Split(" ");

                        foreach (string key in keywords)
                        {
                            if (key.Length > 3)
                            {
                                foreach (Comment comment in comments)
                                {
                                    if (!result.Contains(comment) && comment.Review.ToLower().Contains(key))
                                    {
                                        result.Add(comment);
                                    }
                                    else if (!result.Contains(comment) && comment.Name.ToLower().Contains(key))
                                    {
                                        result.Add(comment);
                                    }
                                }
                            }

                        }



                    }
                    catch
                    {
                        foreach (Comment comment in comments)
                        {
                            if (!result.Contains(comment) && comment.Review.ToLower().Contains(search.ToLower()))
                            {
                                result.Add(comment);
                            }
                            else if (!result.Contains(comment) && comment.Name.ToLower().Contains(search.ToLower()))
                            {
                                result.Add(comment);
                            }
                        }
                    }

                    ViewBag.comments = result;

                    return View("Views/Home/AdminView/AdminComment.cshtml");
                }


                // Unique sort
                if (uniqueSort > 0)
                {
                    comments = comments.Where(comment => comment.Id == uniqueSort).ToList();
                }

                ViewBag.comments = comments;

                return View("Views/Home/AdminView/AdminComment.cshtml");
            }
            else
            {
                return Redirect("/admin");
            }
        }


        [HttpGet]
        [Route("/admin/payments")]
        public IActionResult PaymentTable(string search, int uniqueSort)
        {
            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;
                if (!admin.access_payment)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                List<Payment> payments = _dataContext.Payments.ToList();


              
                // Unique sort
                if (uniqueSort > 0)
                {
                    payments = payments.Where(payment => payment.Id == uniqueSort).ToList();
                }

                ViewBag.payments = payments;

                return View("Views/Home/AdminView/AdminPayment.cshtml");
            }
            else
            {
                return Redirect("/admin");
            }
        }

        [HttpGet]
        [Route("/admin/subscribers")]
        public IActionResult SubscriberTable(string search, int uniqueSort)
        {
            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;
                if (!admin.access_subscriber)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                List<Subscription> subscriptions = _dataContext.Subscriptions.ToList();

                // Unique sort
                if (uniqueSort > 0)
                {
                    subscriptions = subscriptions.Where(subscription => subscription.Id == uniqueSort).ToList();
                }


                ViewBag.subscriptions = subscriptions;

                return View("Views/Home/AdminView/AdminSubscriber.cshtml");
            }
            else
            {
                return Redirect("/admin");
            }
        }


        [HttpGet]
        [Route("/admin/category")]
        public IActionResult CategoryTable(string search, string category)
        {
            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;
               
                if (category!=null)
                {
                    bool isExist = _dataContext.Categories.Where(cat=>cat.Name.ToLower()==category.ToLower()).Any();
                    
                    if(isExist==true)
                    {
                        ViewBag.message = true;
                        ViewBag.error = "Category already exist";
                    }
                    else
                    {
                        _bookRepo.AddCategory(category);
                        _dataContext.SaveChanges();
                        ViewBag.message = true;
                        ViewBag.success = "Category Added";
                    }

                }

                List<Category> categories = _dataContext.Categories.ToList();

                // Unique sort
                if (search!=null)
                {
                    categories = categories.Where(category => category.Name.ToLower().Contains(search.ToLower())).ToList();
                }


                ViewBag.categories = categories;

                return View("Views/Home/AdminView/AdminCategory.cshtml");
            }
            else
            {
                return Redirect("/admin");
            }
        }

        [HttpGet]
        [Route("/admin/category/edit/{id}")]
        public IActionResult CategoryTable(int id, string category)
        {
            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;

                if (category != null)
                {
                    bool isExist = _dataContext.Categories.Where(cat => cat.Name.ToLower() == category.ToLower()).Any();

                    if (isExist == true)
                    {
                        ViewBag.message = true;
                        ViewBag.error = "Category already exist";
                    }
                    else
                    {
                        Category changableCategory =_bookRepo.AllCategories().Where(cat => cat.Id == id).Single();
                        changableCategory.Name = category;
                        _dataContext.SaveChanges();
                        ViewBag.message = true;
                        ViewBag.success = "Category edited";
                    }

                }

                Category targetCategory = _bookRepo.AllCategories().Where(cat => cat.Id == id).Single();
                ViewBag.targetCategory = targetCategory;

                List<Category> categories = _dataContext.Categories.ToList();

                // Unique sort
              


                ViewBag.categories = categories;

                return View("Views/Home/AdminView/AdminCategory.cshtml");
            }
            else
            {
                return Redirect("/admin");
            }
        }






        [HttpGet]
        [Route("/admin/edit/free/{id}")]
        public IActionResult EditFreeBook(int id)
        {
            if (GetAdminAuth() < 0)
            {
                return Redirect("/admin");
            }

           

            Book targetBook = _bookRepo.GetBookById(id);

            Admin admin = _adminRepo.GetAdmin(GetAdminAuth());

            if (admin != null && admin.access_book == true)
            {
              

                List<Category> categories = _bookRepo.AllCategories();
                ViewBag.categories = categories;


              
                if (TempData["success"] == null && TempData["error"] == null)
                {
                    ViewBag.message = false;
                }
                else
                {
                    ViewBag.message = true;

                    ViewBag.success = TempData["success"] == null ? null : TempData["success"];
                    ViewBag.error = TempData["error"] == null ? null : TempData["error"];
                }
            
                ViewBag.targetBook = targetBook;
                ViewBag.admin = admin;
               
                return View("Views/Home/AdminView/UploadFreeEdit.cshtml");
            }
            else
            {
                TempData["error"] = "Unauthorized access";
                return Redirect("/admin");
            }





        }




        [HttpGet]
        [Route("/admin/edit/premium/{id}")]
        public IActionResult EditPremiumBook(int id)
        {
            if (GetAdminAuth() < 0)
            {
                return Redirect("/admin");
            }
            Book targetBook = _bookRepo.GetBookById(id);


            Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
            if (admin != null && admin.access_book == true)
            {
               

                List<Category> categories = _bookRepo.AllCategories();
                ViewBag.categories = categories;
             
                if (TempData["success"] == null && TempData["error"] == null)
                {
                    ViewBag.message = false;
                }
                else
                {
                    ViewBag.message = true;

                    ViewBag.success = TempData["success"] == null ? null : TempData["success"];
                    ViewBag.error = TempData["error"] == null ? null : TempData["error"];
                }
               
                ViewBag.targetBook = targetBook;
                ViewBag.admin = admin;
                
                return View("Views/Home/AdminView/UploadPremiumEdit.cshtml");
            }
            else
            {
                TempData["error"] = "Unauthorized access";
                return Redirect("/admin");
            }


        }






        [HttpGet]
        [Route("/admin/edit/course/{id}")]
        public IActionResult EditCourseAtAdmin(int id)
        {
            if (GetAdminAuth() < 0)
            {
                return Redirect("/admin");
            }

            Course targetCourse = _courseRepo.GetCourseById(id);
            Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
            if (admin!=null && admin.access_course==true)
            {
               

                List<Category> categories = _bookRepo.AllCategories();
                ViewBag.categories = categories;


                if (TempData["success"] == null && TempData["error"] == null)
                {
                    ViewBag.message = false;
                }
                else
                {
                    ViewBag.message = true;

                    ViewBag.success = TempData["success"] == null ? null : TempData["success"];
                    ViewBag.error = TempData["error"] == null ? null : TempData["error"];
                }

                ViewBag.admin = admin;
                ViewBag.targetCourse = targetCourse;
                return View("Views/Home/AdminView/UploadCourseEdit.cshtml");
            }
            else
            {
                TempData["error"] = "Unauthorized access";
                return Redirect("/admin");
            }

        }



       

        [HttpGet]
        [Route("/admin/reports")]
        public IActionResult ReportTable(bool isBook, int resource)
        {
            if (GetAdminAuth() > 0)
            {
                if (TempData["success"] == null && TempData["error"] == null)
                {
                    ViewBag.message = false;
                }
                else
                {
                    ViewBag.message = true;

                    ViewBag.success = TempData["success"] == null ? null : TempData["success"];
                    ViewBag.error = TempData["error"] == null ? null : TempData["error"];
                }

                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;
                if (!admin.access_report)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                List<Report> reports = _dataContext.Reports.ToList();
                List<ReportCount> reportCounts = new List<ReportCount>();
                if (reports.Any())
                {
                    foreach(Report report in reports )
                    {
                       
                                  ReportCount newreportCount = new ReportCount();
                                    newreportCount.reportId = "REPORT" + report.Id.ToString();

                                    newreportCount.firstDate = report.TimeStamp;
                                    newreportCount.IsBook = report.IsBook;
                                    newreportCount.ResourceId = report.ResourceId;
                                    newreportCount.Count = 1;
                                    reportCounts.Add(newreportCount);
                           
                    }
                }


                List<ReportCount> finalreportCounts = new List<ReportCount>();
                List<int> bookReports = reportCounts.Where(report => report.IsBook == true).Select(report => report.ResourceId).Distinct().ToList();
                List<int> courseReports = reportCounts.Where(report => report.IsBook == false).Select(report => report.ResourceId).Distinct().ToList();
            
                foreach(int bookId in bookReports)
                {
                    ReportCount rc = reportCounts.Where(r => r.IsBook == true && r.ResourceId == bookId).ToList().FirstOrDefault();
                    rc.Count = reportCounts.Where(r => r.IsBook == true && r.ResourceId == bookId).Count();
                    finalreportCounts.Add(rc);
                }

                foreach (int courseId in courseReports)
                {
                    ReportCount rc = reportCounts.Where(r => r.IsBook == false && r.ResourceId == courseId).ToList().FirstOrDefault();
                    rc.Count = reportCounts.Where(r => r.IsBook == false && r.ResourceId == courseId).Count();
                    finalreportCounts.Add(rc);
                }






                ViewBag.reportCounts = finalreportCounts;

                if (resource>0)
                {
                    List<Report> allReportsOfTarget = _dataContext.Reports.Where(report => report.IsBook == isBook && report.ResourceId == resource).ToList();

                    ViewBag.allReportsOfTarget = allReportsOfTarget;
                    ViewBag.isBook = isBook;
                    if(isBook)
                    {
                        ViewBag.resource = _bookRepo.GetBookById(resource);
                    }
                    else
                    {
                        ViewBag.resource = _courseRepo.GetCourseById(resource);
                    }
                }

                return View("Views/Home/AdminView/AdminReport.cshtml");
            }
            else
            {
                return Redirect("/admin");
            }
        }




        [HttpGet]
        [Route("/admin/report/solved")]
        public IActionResult SolvedReport(bool isBook, int resource)
        {

            Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
           
            if (!admin.access_report)
            {
                TempData["error"] = "Unauthorized access";
                return Redirect("/admin");
            }

            List<Report> reports = _dataContext.Reports.Where(report => report.IsBook == isBook && report.ResourceId == resource).ToList();
            reports.ForEach(report =>
            {
                _dataContext.Reports.Remove(report);
            });

            _dataContext.SaveChanges();

            TempData["success"] = "Reports Deleted";
            return Redirect("/admin/reports");
        }



        [HttpGet]
        [Route("/admin/tickets")]
        public IActionResult TicketTable(int ticketId,int pending,int solved)
        {
            if (GetAdminAuth() > 0)
            {
                Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
                ViewBag.admin = admin;
                if (!admin.access_ticket)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                List<Ticket> tickets = _dataContext.Tickets.ToList();
                ViewBag.tickets = tickets;

               

                if(ticketId>0)
                {
                    

                    if (pending == 1)
                    {
                        Ticket currentticket = tickets.Where(ticket => ticket.Id == ticketId).FirstOrDefault();
                        string[] desc = currentticket.Description.Split("::"); 
                        currentticket.Description = desc[0] + "::" + desc[1] + "::" + desc[2]; 
                        _dataContext.Tickets.Update(currentticket);
                        _dataContext.SaveChanges();
                    }

                    if (solved == 1)
                    {
                        Ticket currentticket = tickets.Where(ticket => ticket.Id == ticketId).FirstOrDefault();
                        string[] desc = currentticket.Description.Split("::");
                        desc[0] = "solved";
                        currentticket.Description = desc[0] + "::" + desc[1] + "::" + desc[2];
                        _dataContext.Tickets.Update(currentticket);
                        _dataContext.SaveChanges();
                    }
                    else if(solved==2)
                    {
                        Ticket currentticket = tickets.Where(ticket => ticket.Id == ticketId).FirstOrDefault();
                        string[] desc = currentticket.Description.Split("::");
                        desc[0] = "new";
                        currentticket.Description = desc[0] + "::" + desc[1] + "::" + desc[2];
                        _dataContext.Tickets.Update(currentticket);
                        _dataContext.SaveChanges();
                    }

                    Ticket finalticket = tickets.Where(ticket => ticket.Id == ticketId).FirstOrDefault();
                    User user = _dataContext.Users.Where(user => user.Id == finalticket.UserId).FirstOrDefault();

                    ViewBag.currentTicket = finalticket;
                    ViewBag.user = user;

                }


                return View("Views/Home/AdminView/AdminTicket.cshtml");
            }
            else
            {
                TempData["error"] = "Unauthorized access";
                return Redirect("/admin");
            }
        }




        [HttpGet]
        [Route("/admin/delete/{table}/{id}")]
        public IActionResult DeleteValue(string table,int id,string redirect)
        {

            Admin admin = _adminRepo.GetAdmin(GetAdminAuth());
           
         

            if (table== "user")
            {
                if (!admin.access_user)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                _dataContext.Users.Remove(_dataContext.Users.Where(data => data.Id == id).Single());
                _dataContext.SaveChanges();

            }
            
            if(table=="ticket")
            {
                if (!admin.access_ticket)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                _dataContext.Tickets.Remove(_dataContext.Tickets.Where(data => data.Id == id).Single());
                _dataContext.SaveChanges();
            }
            if (table == "subscription")
            {
                if (!admin.access_subscriber)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                _dataContext.Subscriptions.Remove(_dataContext.Subscriptions.Where(data => data.Id == id).Single());
                _dataContext.SaveChanges();

            }

            if (table == "report")
            {
                if (!admin.access_report)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                _dataContext.Reports.Remove(_dataContext.Reports.Where(data => data.Id == id).Single());
                _dataContext.SaveChanges();
            }
            if (table == "payment")
            {
                if (!admin.access_payment)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                _dataContext.Payments.Remove(_dataContext.Payments.Where(data => data.Id == id).Single());
                _dataContext.SaveChanges();

            }

            if (table == "course")
            {
                if (!admin.access_course)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                _dataContext.Courses.Remove(_dataContext.Courses.Where(data => data.Id == id).Single());
                _dataContext.SaveChanges();
            }

            if (table == "book")
            {
                if (!admin.access_book)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                _dataContext.Books.Remove(_dataContext.Books.Where(data => data.Id == id).Single());
                _dataContext.SaveChanges();
            }
            if (table == "comment")
            {
                if (!admin.access_comment)
                {
                    TempData["error"] = "Unauthorized access";
                    return Redirect("/admin");
                }
                
                Comment comment= _dataContext.Comments.Where(data => data.Id == id).Single();
                if(comment.IsBook)
                {
                    Book book=_dataContext.Books.Where(data => data.Id==comment.ResourceId).Single();
                    book.Comments--;
                    _dataContext.SaveChanges();
                }
                else 
                {
                    Course course=_dataContext.Courses.Where(data => data.Id==comment.ResourceId).Single();
                    course.Comments--;
                    _dataContext.SaveChanges();
                }

                _dataContext.Comments.Remove(comment);
                
                _dataContext.SaveChanges();
            }

            if (table == "category")
            {
                _dataContext.Categories.Remove(_dataContext.Categories.Where(data => data.Id == id).Single());
                _dataContext.SaveChanges();

            }

            return Redirect(redirect);
        }






        public int GetAdminAuth()
        {
            string sessiondata = HttpContext.Session.GetString("AdminId");

            if (sessiondata != null)
            {
                return Convert.ToInt32(sessiondata);
            }
            else
            {
                return -1;
            }
        }



        //---------------------------------------------------------------------------


        public List<Book> SearchBook(string keyword, List<Book> targetbooks)
        {
            List<Book> result = new List<Book>();
            List<Book> books = targetbooks;
            try
            {
                string[] keywords = keyword.ToLower().Split(" ");
                foreach (string key in keywords)
                {
                    if (key.Length > 3)
                    {
                        foreach (Book book in books)
                        {
                            if (!result.Contains(book) && book.Name.ToLower().Contains(key))
                            {
                                result.Add(book);
                            }
                            else if (!result.Contains(book) && book.Author.ToLower().Contains(key))
                            {
                                result.Add(book);
                            }
                            else if (!result.Contains(book) && book.Category.ToLower().Contains(key))
                            {
                                result.Add(book);
                            }
                            else if (!result.Contains(book) && book.Language.ToLower().Contains(key))
                            {
                                result.Add(book);
                            }

                        }
                    }

                }


            }
            catch 
            {
               
                if (keyword.Length > 3)
                {
                    keyword = keyword.ToLower();
                    foreach (Book book in books)
                    {
                        if (!result.Contains(book) && book.Name.ToLower().Contains(keyword))
                        {
                            result.Add(book);
                        }
                        else if (!result.Contains(book) && book.Author.ToLower().Contains(keyword))
                        {
                            result.Add(book);
                        }
                        else if (!result.Contains(book) && book.Category.ToLower().Contains(keyword))
                        {
                            result.Add(book);
                        }
                        else if (!result.Contains(book) && book.Language.ToLower().Contains(keyword))
                        {
                            result.Add(book);
                        }

                    }

                }

            }

            return result;
        }


        public List<Course> SearchCourse(string keyword, List<Course> targetcourses)
        {
            List<Course> result = new List<Course>();
            List<Course> courses = targetcourses;
            try
            {
                string[] keywords = keyword.ToLower().Split(" ");
                foreach (string key in keywords)
                {
                    if (key.Length > 3)
                    {
                        foreach (Course course in courses)
                        {
                            if (!result.Contains(course) && course.Name.ToLower().Contains(key))
                            {
                                result.Add(course);
                            }
                            else if (!result.Contains(course) && course.Source.ToLower().Contains(key))
                            {
                                result.Add(course);
                            }
                            else if (!result.Contains(course) && course.Category.ToLower().Contains(key))
                            {
                                result.Add(course);
                            }
                            else if (!result.Contains(course) && course.Language.ToLower().Contains(key))
                            {
                                result.Add(course);
                            }

                        }
                    }

                }


            }
            catch
            {
               
                if (keyword.Length > 3)
                {
                    keyword = keyword.ToLower();
                    foreach (Course course in courses)
                    {
                        if (!result.Contains(course) && course.Name.ToLower().Contains(keyword))
                        {
                            result.Add(course);
                        }
                        else if (!result.Contains(course) && course.Source.ToLower().Contains(keyword))
                        {
                            result.Add(course);
                        }
                        else if (!result.Contains(course) && course.Category.ToLower().Contains(keyword))
                        {
                            result.Add(course);
                        }
                        else if (!result.Contains(course) && course.Language.ToLower().Contains(keyword))
                        {
                            result.Add(course);
                        }

                    }

                }

            }

            return result;
        }



    }
}
