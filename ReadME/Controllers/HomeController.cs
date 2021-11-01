using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReadME.Models;
using ReadME.Repository;
using Microsoft.AspNetCore.Http;

namespace ReadME.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserRepo _iuserRepo;
        private readonly IBookRepo _bookRepo;
        private readonly ICourseRepo _courseRepo;
        private readonly ISpecificationRepo _specificationRepo;
        private readonly ISavedRepo _savedRepo;
        private readonly INotificationRepo _notificationRepo;

        public HomeController(INotificationRepo notificationRepo,IUserRepo userRepo, IBookRepo bookRepo, ICourseRepo courseRepo, ISpecificationRepo specificationRepo, ISavedRepo savedRepo)
        {
            _iuserRepo = userRepo;
            _bookRepo = bookRepo;
            _courseRepo = courseRepo;
            _specificationRepo = specificationRepo;
            _savedRepo = savedRepo;
            _notificationRepo = notificationRepo;
        }


        [Route("/error/{statusCode}")]
        public IActionResult ErrorPage(int statusCode)
        {
            if(statusCode==404)
            {
                ViewBag.code = "404";
                ViewBag.message = "Page Not Found...";
            }
            else
            {
                ViewBag.code = "500";
                ViewBag.message = "Things went wrong...";
            }

            return View("Views/Shared/ErrorPage.cshtml");
        }



        [Route("/")]
        public IActionResult Index(string search, string category, string sort)
        {
            ViewBag.style="homeStyle.css";

            if (GetAuthId() > 0)
            {
                ViewBag.layoutName = "_LoginLayout.cshtml";
                ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

                List<Book> suggestions = _bookRepo.GetSuggestionsById(GetAuthId());
           
                List<Book> TopThreePremium = _bookRepo.TopThreePremiumBooks(GetAuthId());

                if (suggestions.Count()>0)
                {
                    suggestions.Union(TopThreePremium);
                    suggestions.Reverse();
                   
                
                }
                else
                {
                    suggestions = TopThreePremium;
                  
                }
                
                suggestions = suggestions.Where(book=>book.IsPremium==true).ToList();
             
              
                ViewBag.suggestions = suggestions;
            }
            else
            {
                List<Book> TopThreePremium = _bookRepo.TopThreePremiumBooks(GetAuthId());



                ViewBag.suggestions = TopThreePremium;
                ViewBag.layoutName = "_Layout.cshtml";
            }

            

            List<int> likedItems = _specificationRepo.AllLikesOfBook(GetAuthId());
            ViewBag.likedItems = likedItems;

            List<int> savedItems = _savedRepo.AllSavedId(GetAuthId(), "book");
            ViewBag.savedItems = savedItems;

            List<string> categories = _bookRepo.AllExistingCategoriesPremium();

            ViewBag.categories = categories;

            ViewBag.search=true;

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

            ViewBag.activeHome=true;

            if(search!=null)
            {
                List<Book> books= _bookRepo.AllPremiumBooks();

                List<Book> results = SearchBook(search, books);

                if (results.Count() == 0)
                {
                    ViewBag.AllBooks = _bookRepo.AllPremiumBooks();
                    ViewBag.message = true;
                    ViewBag.error = "No books found";
                }
                else
                {
                    ViewBag.AllBooks = results;
                }


            }
            else
            {
                ViewBag.AllBooks = _bookRepo.AllPremiumBooks();
            }


            if(category!=null || sort !=null)
            {

                List<Book> result = _bookRepo.AllPremiumBooks();

                if (category!=null)
                {
                   if(categories.Contains(category))
                   {
                        result = _bookRepo.AllPremiumBooks().Where(book => book.Category == category).ToList();
                   }
                   else
                    {
                        ViewBag.message = true;
                        ViewBag.error = "invalid selection";
                    }
                }

                if(sort!=null)
                {
                    
                    if(sort=="Price Up")
                    {

                        result = result.OrderByDescending(book => book.Price).ToList(); 
                    }
                    else if(sort=="Price Down")
                    {
                        result = result.OrderBy(book => book.Price).ToList();
                    }
                    else if (sort == "Popular")
                    {
                        result = result.OrderByDescending(book => book.Likes).ToList();
                    }
                    else if (sort == "Relevant")
                    {
                        result = result.OrderByDescending(book => book.UploadTime).ToList();
                    }
                    else if (sort == "Language")
                    {

                        result = result.OrderByDescending(book => book.Language).ToList();
                    }


                }

               
                ViewBag.AllBooks = result;


            }
            




          

            ViewBag.IsPremiumPage = true;


           
            



            return View("Views/Home/HomeView/Home.cshtml");
        }


        [Route("/about-us")]
        [HttpGet]
        public IActionResult AboutUs()
        {
            ViewBag.style = "aboutUsStyle.css";

            if (GetAuthId() > 0)
            {
                ViewBag.layoutName = "_LoginLayout.cshtml";
            }
            else
            {
                ViewBag.layoutName = "_Layout.cshtml";
            }



            ViewBag.message = false;
            ViewBag.search = false;

        

            ViewBag.activeAboutUs = true;


            return View("Views/Home/HomeView/AboutUs.cshtml");
        }

        [Route("/terms-and-condition")]
        [HttpGet]
        public IActionResult TermsAndCondition()
        {
            ViewBag.style = "aboutUsStyle.css";
            ViewBag.message = false;

            if (GetAuthId() > 0)
            {
                ViewBag.layoutName = "_LoginLayout.cshtml";
            }
            else
            {
                ViewBag.layoutName = "_Layout.cshtml";
            }




            ViewBag.search = false;



            ViewBag.activeLogin = true;


            return View("Views/Home/HomeView/TermsAndCond.cshtml");
        }


        [Route("/logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["success"] = "You have been logged out";
            return Redirect("/login");
        }

        [Route("/login")]
        [HttpGet]
        public IActionResult Login(string redirect)
        {
            ViewBag.activeLogin=true;
            ViewBag.style="loginStyle.css";
            ViewBag.search=false;
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

            if(redirect!=null)
            {
                ViewBag.redirect = redirect;
            }
            else
            {
                ViewBag.redirect = "/";
            }
            return View("Views/Home/HomeView/Login.cshtml");
            
        }


        [Route("/signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(AuthData authdata,string redirect)
        {
            User signUser =await _iuserRepo.GetUserByEmail(authdata.Email);
            if (signUser != null)
            {
                if(!signUser.isVerified)
                {
                    return await this.VerificationAsync(signUser.Email,redirect);
                }
                else
                {
                
                    TempData["error"] = "Email already exists";
                    if(redirect!=null)
                    {
                        return Redirect("/login?redirect="+ redirect); 
                    }
                    return Redirect("/login");
                }
            }

            User user = new User();
            user.Name = authdata.Username;
            user.Email = authdata.Email;
            user.Password = authdata.Password;
            user.isVerified = false;
            user.Earnings = 0;
            bool status = _iuserRepo.AddUser(user);

            if(status)
            {
                return await this.VerificationAsync(authdata.Email,redirect);
            }
            else
            {
                TempData["error"] = "Something went wrong";
                if (redirect != null)
                {
                    return Redirect("/login?redirect="+redirect);
                }
                return Redirect("/login");
            }
        }


        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login(AuthData authdata,string redirect)
        {
            User user =await _iuserRepo.GetUserByEmail(authdata.Email);
            if (user != null)
            {
                if (!user.isVerified)
                {
                    return await this.VerificationAsync(user.Email,redirect);
                }
                else
                {
                    if (user.Password == authdata.Password)
                    {
                        HttpContext.Session.SetString("UserId", user.Id.ToString());
                        return Redirect(redirect);
                    }
                    else
                    {
                        TempData["error"] = "Invalid Password";
                        return Redirect("/login?redirect="+redirect);
                    }
                }
            }

            TempData["error"] = "User does not exist";
            return Redirect("/login?redirect=" + redirect);


        }


       
        private async Task<IActionResult> VerificationAsync(string Email,string redirect)
        {
            User user = await _iuserRepo.GetUserByEmail(Email);

            await _iuserRepo.DeleteOTPByUserId(user.Id);



            if (user != null)
            {
                Random random = new Random();
                long otp = random.Next(100000, 1000000);//589565
              

                OTP otpObj = new OTP();
                otpObj.UserId = user.Id;
                otpObj.Otp = otp;
                otpObj.OtpTime = DateTime.Now;
                await _iuserRepo.GenerateOTPAsync(otpObj);
                try
                {
                    bool otpSent = SendOTPMail(Email, user.Name, otp.ToString());

                    if (otpSent)
                    {
                        ViewBag.style = "verificationStyle.css";
                        ViewBag.search = false;
                        ViewBag.message = true;
                        ViewBag.userId = user.Id;
                        ViewBag.redirect = redirect;
                        ViewBag.success = "OTP sent to your E-mail";
                        return View("Views/Home/HomeView/Verification.cshtml");
                    }
                    else
                    {

                        TempData["error"] = "Something went wrong";
                        if (redirect != null)
                        {
                            return Redirect("/login?redirect=" + redirect);
                        }
                        return Redirect("/login");
                    }
                }
                catch
                {
                    TempData["error"] = "Unable to send OTP";
                    if (redirect != null)
                    {
                        return Redirect("/login?redirect=" + redirect);
                    }
                    return Redirect("/login");
                }

            }
            else
            {
                return Redirect("/login");
            }
        }

        [Route("/verify/{UserId}")]
        [HttpPost]
        public async Task<IActionResult> VerifyOTP(OTPData otpdata,int UserId,string redirect)
        {

            await _iuserRepo.DeleteInvalidOTP();




            String userOTP = otpdata.dig1.ToString() + otpdata.dig2.ToString()+ otpdata.dig3.ToString() + otpdata.dig4.ToString()+ otpdata.dig5.ToString() + otpdata.dig6.ToString();
            OTP actualOtpObj = await _iuserRepo.GetOTPByUserId(UserId);
            String actualOTP = actualOtpObj.Otp.ToString();
            

            if(userOTP==actualOTP)
            {
                ViewBag.message = true;

                if(redirect=="/edit-profile")
                {
                    return Redirect(redirect);
                }

                User user=await _iuserRepo.GetUserById(UserId);
                user.isVerified = true;
                _iuserRepo.save();
;                TempData["success"] = "Verified! Please Login";
                if (redirect != null)
                {
                    return Redirect("/login?redirect=" + redirect);
                }
                return Redirect("/login");
            }
            else
            {
                ViewBag.style = "verificationStyle.css";
                ViewBag.search = false;
                ViewBag.message = true;
                ViewBag.userId = UserId;
                ViewBag.error = "Invalid OTP";
                ViewBag.redirect = redirect;
                return View("Views/Home/HomeView/Verification.cshtml");
            }
        }


        [HttpGet]
        [Route("/resend/{userId}")]
        public async Task<IActionResult> Resend(int userId,string redirect)
        {

            User user = await _iuserRepo.GetUserById(userId);
            if (redirect=="/edit-profile")
            {
                TempData["newUsername"] = TempData["newUsername"];
                TempData["newEmail"] = TempData["newEmail"];
                return await EditVerification(user.Email, TempData["newEmail"].ToString());
            }
            
            return await VerificationAsync(user.Email,redirect);
        }


        [HttpGet]
        [Route("/forgot")]
        public IActionResult Forgot(string redirect)
        {
            ViewBag.search = false;
            ViewBag.message = false;
            ViewBag.redirect = redirect;
            ViewBag.style = "verificationStyle.css";

            return View("Views/Home/HomeView/Forgot.cshtml");
        }



        [HttpPost]
        [Route("/forgot")]
        public async Task<IActionResult> Forgot(ForgotData forgotData,string redirect)
        {
            return await FVerification(forgotData.Email,redirect);
        }





        public async Task<IActionResult> FVerification(string femail,string redirect)
        {
            User user = await _iuserRepo.GetUserByEmail(femail);

            await _iuserRepo.DeleteOTPByUserId(user.Id);


            if (user != null)
            {
                Random random = new Random();
                long otp = random.Next(100000, 1000000);

                OTP otpObj = new OTP();
                otpObj.UserId = user.Id;
                otpObj.Otp = otp;
                otpObj.OtpTime = DateTime.Now;
                await _iuserRepo.GenerateOTPAsync(otpObj);

                try
                {


                    bool otpSent =  SendOTPMail(femail, user.Name, otp.ToString());
                    if (otpSent)
                    {
                        ViewBag.style = "verificationStyle.css";
                        ViewBag.search = false;
                        ViewBag.message = true;
                        ViewBag.userId = user.Id;
                        ViewBag.redirect = redirect;
                        ViewBag.success = "OTP sent to your E-mail";
                        return View("Views/Home/HomeView/FVerification.cshtml");
                    }
                    else
                    {

                        TempData["error"] = "Something went wrong";

                        if (redirect != null)
                        {
                            return Redirect("/login?redirect=" + redirect);
                        }
                        return Redirect("/login");
                    }
                }
                catch
                {

                    ViewBag.style = "verificationStyle.css";
                    ViewBag.search = false;
                    ViewBag.message = true;
                    ViewBag.userId = user.Id;
                    ViewBag.redirect = redirect;
                    ViewBag.error = "Unable to send OTP";
                    return View("Views/Home/HomeView/FVerification.cshtml");

                }

            }
            else
            {
                ViewBag.search = false;

                ViewBag.message = true;
                ViewBag.error = "User Does not exist";
                ViewBag.style = "verificationStyle.css";
                ViewBag.redirect = redirect;
                return View("Views/Home/HomeView/Forgot.cshtml");
            }
        }

      


        [Route("/fverify/{UserId}")]
        [HttpPost]
        public async Task<IActionResult> FVerifyOTP(OTPData otpdata, int UserId,string redirect)
        {

            await _iuserRepo.DeleteInvalidOTP();


            String userOTP = otpdata.dig1.ToString() + otpdata.dig2.ToString() + otpdata.dig3.ToString() + otpdata.dig4.ToString() + otpdata.dig5.ToString() + otpdata.dig6.ToString();
           
            OTP actualOtpObj = await _iuserRepo.GetOTPByUserId(UserId);
            String actualOTP = actualOtpObj.Otp.ToString();
          


            if (userOTP == actualOTP)
            {
         
                ViewBag.search = false;
                ViewBag.message = true;
                ViewBag.userId = UserId;
                ViewBag.success = "Please Change Password";
                ViewBag.style = "ChangePassStyle.css";
                ViewBag.redirect = redirect;
                return View("Views/Home/HomeView/ChangePass.cshtml");
            }
            else
            {
                ViewBag.style = "verificationStyle.css";
                ViewBag.search = false;
                ViewBag.message = true;
                ViewBag.userId = UserId;
                ViewBag.redirect = redirect;
                ViewBag.error = "Invalid OTP";
                return View("Views/Home/HomeView/FVerification.cshtml");
            }
        }


        [HttpGet]
        [Route("/fresend/{userId}")]
        public async Task<IActionResult> FResend(int userId,string redirect)
        {
            User user = await _iuserRepo.GetUserById(userId);
            return await FVerification(user.Email,redirect);
        }


        [HttpPost]
                
        [Route("/change/{userId}")]  
        public async Task<IActionResult> ChangePassword(ChangeData changeData, int userId,string redirect)
        {
            try
            {
                User user = await _iuserRepo.GetUserById(userId);
                user.Password = changeData.Password;
                _iuserRepo.save();
                TempData["success"] = "Password Changed";

                if (redirect != null)
                {
                    return Redirect("/login?redirect=" + redirect);
                }

                return Redirect("/login");
            }
            catch
            {
                ViewBag.search = false;
                ViewBag.message = true;
                ViewBag.userId = userId;
                ViewBag.error = "Something went wrong";
                ViewBag.style = "ChangePassStyle.css";
                ViewBag.redirect = redirect;
                return View("Views/Home/HomeView/ChangePass.cshtml");
            }
        }


        public bool SendOTPMail(string to, string name, string otp)
        {
            string body = "<!DOCTYPE html><html lang='en'><head><meta charset='UTF-8'><meta http-equiv='X-UA-Compatible' content='IE=edge'><meta name='viewport' content='width=device-width, initial-scale=1.0'><title>OTP</title><link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css'><style> *{ margin:0px;padding:0px; box-sizing: border-box; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; }.heading{text-align: center;background:#5708be;padding:15px;color:#fff;} h1 i{color:#cecece;} p i{color:#4c04d3; } b{color:#7300d1;} .content{padding:20px;}</style></head><body><div class='heading'><h1><span><i class='fa fa-dice-d6'></i> </span>Read.me</h1></div><div class='content'><p>Hi "+name+"</p><br><p>Please use this OTP <b>"+otp+"</b> for your Verification</p><br><p>Thanks and Regards</p><p><i class='fa fa-dice-d6'></i> Read.me</p></div></body></html>";
            string subject = "Verify ReadME OTP";
            return  Email.Send(to, subject, body);

        
        }



        [HttpGet]
        [Route("/free")]
        public IActionResult FreeBooks(string search, string category,string sort)
        {
            ViewBag.style = "homeStyle.css";
            ViewBag.search = true;

            if (GetAuthId() > 0)
            {
                ViewBag.layoutName = "_LoginLayout.cshtml";

                List<Book> suggestions = _bookRepo.GetSuggestionsById(GetAuthId());
                List<Book> TopThreeFree = _bookRepo.TopThreeFreeBooks(GetAuthId());
                ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();


                if (suggestions.Count() > 0)
                {
                    suggestions.Union(TopThreeFree);
                    suggestions.Reverse();
                }
                else
                {
                    suggestions = TopThreeFree;
                }

                suggestions = suggestions.Where(book => book.IsPremium == false).ToList();

                ViewBag.suggestionsFree = suggestions;
            }
            else
            {
                List<Book> TopThreeFree = _bookRepo.TopThreeFreeBooks(GetAuthId());



                ViewBag.suggestionsFree = TopThreeFree;
                ViewBag.layoutName = "_Layout.cshtml";
            }


            List<int> likedItems = _specificationRepo.AllLikesOfBook(GetAuthId());
            ViewBag.likedItems = likedItems;

            List<int> savedItems = _savedRepo.AllSavedId(GetAuthId(), "book");
            ViewBag.savedItems = savedItems;

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


            ViewBag.AllBooks = _bookRepo.AllFreeBooks();


            if (search != null)
            {
                List<Book> books = _bookRepo.AllFreeBooks();

                List<Book> results = SearchBook(search, books);
                if (results.Count() == 0)
                {
                    ViewBag.AllBooks = _bookRepo.AllFreeBooks();
                    ViewBag.message = true;
                    ViewBag.error = "No books found";
                }
                else
                {
                    ViewBag.AllBooks = results;
                }


            }
            else
            {
                ViewBag.AllBooks = _bookRepo.AllFreeBooks();
            }

            List<string> categories = _bookRepo.AllExistingCategoriesFree();

            if (category != null || sort != null)
            {

                List<Book> result = _bookRepo.AllFreeBooks();

                if (category != null)
                {
                    if (categories.Contains(category))
                    {
                        result = _bookRepo.AllFreeBooks().Where(book => book.Category == category).ToList();
                    }
                    else
                    {
                        ViewBag.message = true;
                        ViewBag.error = "invalid selection";
                    }
                }

                if (sort != null)
                {
                   
                    if (sort == "Popular")
                    {
                        result = result.OrderByDescending(book => book.Likes).ToList();
                    }
                    else if (sort == "Relevant")
                    {
                        result=result.OrderByDescending(book => book.UploadTime).ToList();
                    }
                    else if (sort == "Language")
                    {

                        result=result.OrderByDescending(book => book.Language).ToList();
                    }


                }

                ViewBag.AllBooks = result;


            }

            ViewBag.categories = _bookRepo.AllExistingCategoriesFree();
            ViewBag.IsPremiumPage = false;
            return View("Views/Home/HomeView/Home.cshtml");
        }


        [HttpGet]
        [Route("/edu-hub")]
        public IActionResult EduHub(string search, string category,string sort)
        {
            ViewBag.style = "homeStyle.css";
            ViewBag.search = true;


            if (GetAuthId() > 0)
            {
                ViewBag.layoutName = "_LoginLayout.cshtml";

                List<Course> suggestions = _courseRepo.GetSuggestionsById(GetAuthId());
                List<Course> TopThreeCourses = _courseRepo.TopThreeCourses(GetAuthId());
                ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

                if (suggestions.Count()>0)
                {
                    suggestions.Union(TopThreeCourses);
                    suggestions.Reverse();
                }
                else
                {
                    suggestions = TopThreeCourses;
                }
                
                

                ViewBag.suggestions = suggestions;

            }
            else
            {
                List<Course> TopThreeCourses = _courseRepo.TopThreeCourses(GetAuthId());



                ViewBag.suggestions = TopThreeCourses;
                ViewBag.layoutName = "_Layout.cshtml";
            }


            List<int> likedItems = _specificationRepo.AllLikesOfCourse(GetAuthId());
            ViewBag.likedItems = likedItems;

            List<int> savedItems = _savedRepo.AllSavedId(GetAuthId(), "course");
            ViewBag.savedItems = savedItems;

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

            ViewBag.AllCourses = _courseRepo.AllCourses();

            if (search != null)
            {
                List<Course> courses = _courseRepo.AllCourses();

                List<Course> results = SearchCourse(search, courses);
                if (results.Count() == 0)
                {
                    ViewBag.AllCourses = _courseRepo.AllCourses();
                    ViewBag.message = true;
                    ViewBag.error = "No courses found";
                }
                else
                {
                    ViewBag.AllCourses = results;
                }


            }
            else
            {
                ViewBag.AllCourses = _courseRepo.AllCourses();
            }

            List<string> categories = _courseRepo.AllExistingCategoriesCourse();

            if (category != null || sort != null)
            {

                List<Course> result = _courseRepo.AllCourses();

                if (category != null)
                {
                    if (categories.Contains(category))
                    {
                        result = _courseRepo.AllCourses().Where(course => course.Category == category).ToList();
                    }
                    else
                    {
                        ViewBag.message = true;
                        ViewBag.error = "invalid selection";
                    }
                }

                if (sort != null)
                {

                    if (sort == "Popular")
                    {
                        result = result.OrderByDescending(course => course.Likes).ToList();
                    }
                    else if (sort == "Relevant")
                    {
                        result = result.OrderByDescending(course => course.UploadTime).ToList();
                    }
                    else if (sort == "Language")
                    {

                        result = result.OrderByDescending(course => course.Language).ToList();
                    }


                }

                ViewBag.AllCourses = result;


            }

            ViewBag.activeEduHub = true;
        
            ViewBag.categories = _courseRepo.AllExistingCategoriesCourse();
            return View("Views/Home/HomeView/EduHub.cshtml");
        }

     

        [HttpGet]
        [Route("/edit-suggestion")]
        public IActionResult EditSuggestionPage(string redirect)
        {
            if(GetAuthId()<0)
            {
                return Redirect("/login?redirect=/edit-suggestion?redirect="+redirect);
            }

            List<Category> categories = _bookRepo.AllCategories();

            ViewBag.style = "verificationStyle.css";
            ViewBag.layoutName = "_LoginLayout.cshtml";
            ViewBag.search = false;
            ViewBag.message = false;
            if (redirect == "/free")
            {
                ViewBag.activeFree = true;
            }
            else if (redirect == "/")
            {
                ViewBag.activeHome = true;
            }
            else
            {

                ViewBag.activeEduHub = true;

            }
            ViewBag.redirect = redirect;
            ViewBag.categories = categories;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

            return View("Views/Home/HomeView/EditSuggestion.cshtml");
        }
        

        [HttpPost]
        [Route("/edit-suggestion")]
        public async Task<IActionResult> EditSuggestion(string redirect,string suggestion)

        {
            

            try
            {
                string suggestions = "";
                foreach(string sug in suggestion.Split("|")) 
                {
                    if(sug.Length>0)
                    {
                        suggestions += sug+";";
                    }
                }

                User user= await _iuserRepo.GetUserById(GetAuthId());
                user.Suggestions = suggestions;
                _iuserRepo.save();

                TempData["success"] = "Suggestions saved";
            }
            catch
            {
               
                TempData["error"] = "Unable to edit suggestions";
            }
            
            if(redirect=="/free")
            {
                return Redirect("/free");
            }
            else if(redirect =="/")
            {
                return Redirect("/");
            }
            else
            {
               
               return Redirect("/edu-hub");
               
            }
            
        }


        [HttpGet]
        [Route("/change-password")]
        public async Task<IActionResult> ChangePassword(string redirect)
        {
            User user = await _iuserRepo.GetUserById(GetAuthId());

            return await FVerification(user.Email,redirect);
        }



        [HttpPost]
        [Route("/edit-user")]
        public async Task<IActionResult> EditUser(string username, string email)
        {
            TempData["newUsername"] = username;
            TempData["newEmail"] = email;
            User user = await _iuserRepo.GetUserById(GetAuthId());

            return await EditVerification(user.Email, email);
        }

        [HttpGet]
        [Route("/edit-profile")]
        public async Task<IActionResult> EditedUser()
        {

            if (TempData["error"] !=null)
            {
                return Redirect("/profile");
            }

            User user = await _iuserRepo.GetUserById(GetAuthId());
            user.Name = TempData["newUsername"].ToString();
            user.Email = TempData["newEmail"].ToString();
         
            _iuserRepo.save();

            TempData["success"] = "Profile Updated";

            return Redirect("/profile");
        }





        public async Task<IActionResult> EditVerification(string email,string newEmail)
        {
            User user = await _iuserRepo.GetUserByEmail(email);

            await _iuserRepo.DeleteOTPByUserId(user.Id);
            TempData["newUsername"] = TempData["newUsername"];
            TempData["newEmail"] = TempData["newEmail"];

            if (user != null)
            {
                Random random = new Random();
                long otp = random.Next(100000, 1000000);

                OTP otpObj = new OTP();
                otpObj.UserId = user.Id;
                otpObj.Otp = otp;
                otpObj.OtpTime = DateTime.Now;
                await _iuserRepo.GenerateOTPAsync(otpObj);

                try
                {


                    bool otpSent = SendOTPMail(newEmail, user.Name, otp.ToString());
                    if (otpSent)
                    {
                        ViewBag.style = "verificationStyle.css";
                        ViewBag.search = false;
                        ViewBag.message = true;
                        ViewBag.userId = user.Id;
                        ViewBag.redirect = "/edit-profile";
                        ViewBag.success = "OTP sent to your E-mail";
                        return View("Views/Home/HomeView/Verification.cshtml");
                    }
                    else
                    {

                        TempData["error"] = "Something went wrong";

                       
                        return Redirect("/edit-profile");
                    }
                }
                catch
                {

                    ViewBag.style = "verificationStyle.css";
                    ViewBag.search = false;
                    ViewBag.message = true;
                    ViewBag.userId = user.Id;
                    ViewBag.redirect = "/edit-profile";
                    ViewBag.error = "Unable to send OTP";
                    return View("Views/Home/HomeView/Verification.cshtml");

                }

            }
            else
            {
                ViewBag.search = false;

                ViewBag.message = true;
                ViewBag.error = "User Does not exist";
                ViewBag.style = "verificationStyle.css";
                ViewBag.redirect = "/edit-profile";
                return View("Views/Home/HomeView/Forgot.cshtml");
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
                foreach(string key in keywords)
                {
                    if(key.Length > 3)
                    {
                        foreach (Book book in books)
                        {
                            if (!result.Contains(book) && book.Name.ToLower().Contains(key))
                            {
                                result.Add(book);
                            }
                            else if(!result.Contains(book) && book.Author.ToLower().Contains(key))
                            {
                                result.Add(book);
                            }
                            else if (!result.Contains(book) && book.Category.ToLower().Contains(key))
                            {
                                result.Add(book);
                            }
                            else if(!result.Contains(book) && book.Language.ToLower().Contains(key))
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


        public int GetAuthId()
        {
            string sessiondata = HttpContext.Session.GetString("UserId");  
            
          
            if (sessiondata != null)
            {
                return Convert.ToInt32(sessiondata); 
            }
            else
            {
                return -1;
            }
        }


    }
}