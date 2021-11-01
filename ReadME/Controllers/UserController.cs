using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using ReadME.Models;
using ReadME.Repository;

namespace ReadME.Controllers
{

    public class UserController : Controller
    {
        private IWebHostEnvironment _webHostEvn;
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

        public UserController(IWebHostEnvironment webHostEvn, INotificationRepo notificationRepo, ITicketRepo ticketRepo, IReportRepo reportdRepo, IAdminRepo adminRepo, IBookRepo bookRepo, ICourseRepo courseRepo, ISpecificationRepo specificationRepo, IUserRepo userRepo, IPaymentRepo paymentRepo,ISavedRepo savedRepo)
        {
            
            _webHostEvn = webHostEvn;
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
        }

        [Route("/upload")]
        [HttpGet]
        public IActionResult UploadPage()
        {

            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/upload");
            }

            List<Book> uploadedFreeBooks = _bookRepo.AllFreeBooks().Where(book => book.Uploader == GetAuthId()).ToList();
            List<Book> uploadedPremiumBooks = _bookRepo.AllPremiumBooks().Where(book => book.Uploader == GetAuthId()).ToList();
            List<Course> uploadedCourses = _courseRepo.AllCourses().Where(course => course.Uploader == GetAuthId()).ToList();

            ViewBag.uploadedFreeBooks = uploadedFreeBooks;
            ViewBag.uploadedPremiumBooks = uploadedPremiumBooks;
            ViewBag.uploadedCourses = uploadedCourses;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();


            ViewBag.style = "AL_uploadStyle.css";
            ViewBag.search = false;

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
            ViewBag.activeUpload = true;
            ViewBag.layoutName = "_LoginLayout.cshtml";
            return View("Views/User/Upload.cshtml");
        }

        [Route("/upload/free")]
        [HttpGet]
        public IActionResult UploadFree()
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/upload/free");
            }


            List<Book> uploadedFreeBooks = _bookRepo.AllFreeBooks().Where(book => book.Uploader == GetAuthId()).ToList();
            ViewBag.uploadedFreeBooks = uploadedFreeBooks;

            List<Category> categories = _bookRepo.AllCategories();
            ViewBag.categories = categories;
          

            ViewBag.layoutName = "_LoginLayout.cshtml";
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

            ViewBag.style = "AL_uploadStyle.css";
            ViewBag.search = false;
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
            ViewBag.activeUpload = true;
            return View("Views/User/UploadFree.cshtml");
        }

        [Route("/upload/premium")]
        [HttpGet]
        public IActionResult UploadPremium()
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/upload/premium");
            }

            List<Book> uploadedPremiumBooks = _bookRepo.AllPremiumBooks().Where(book => book.Uploader == GetAuthId()).ToList();
            ViewBag.uploadedPremiumBooks = uploadedPremiumBooks;

            List<Category> categories = _bookRepo.AllCategories();
            ViewBag.categories = categories;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

            ViewBag.layoutName = "_LoginLayout.cshtml";

            ViewBag.style = "AL_uploadStyle.css";
            ViewBag.search = false;
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
            ViewBag.activeUpload = true;
            return View("Views/User/UploadPremium.cshtml");
        }

        [Route("/upload/course")]
        [HttpGet]
        public IActionResult UploadCourse()
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/upload/course");
            }

            List<Course> uploadedCourses = _courseRepo.AllCourses().Where(course => course.Uploader == GetAuthId()).ToList();
            ViewBag.uploadedCourses = uploadedCourses;

            List<Category> categories = _bookRepo.AllCategories();
            ViewBag.categories = categories;

            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

            ViewBag.layoutName = "_LoginLayout.cshtml";
            ViewBag.style = "AL_uploadStyle.css";
            ViewBag.search = false;
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
            ViewBag.activeUpload = true;
            return View("Views/User/UploadCourse.cshtml");
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

       

        [Route("/upload/premium")]
        [HttpPost]
        public async Task<IActionResult> UploadPremiumBook(BookData premiumBookData)
        {
            List<Category> categories = _bookRepo.AllCategories();

            if(!categories.Select(category=>category.Name).Contains(premiumBookData.Category))
            {
                TempData["error"] = "invalid Category";
                return Redirect("/upload/premium");
            }

            try
            {
                string Thumbnailfolder = "Books/Thumbnail/";
                string BookPDFfolder = "Books/BookPDF/";

                BookPDFfolder += "PremiumBook_" + GetAuthId() + "_" + Guid.NewGuid().ToString() + premiumBookData.BookFile.FileName;





                Book book = new Book();

                book.Name = premiumBookData.Name;
                book.Author = premiumBookData.Author;
                book.Description = premiumBookData.Description;
                book.Language = premiumBookData.Language;
                book.Uploader = GetAuthId();
                book.Category = premiumBookData.Category;
                book.Price = premiumBookData.Price;
                book.IsActive = true;
                book.IsPremium = true;
                book.UploadTime = DateTime.Now;
                book.Likes = 0;
                book.Readers = 0;
                book.Comments = 0;
                
                book.FilePath = BookPDFfolder;

                if(premiumBookData.ThumbnailFile?.FileName!=null)
                {
                    Thumbnailfolder += "Thumbnail_" + GetAuthId() + "_" + Guid.NewGuid().ToString() + premiumBookData.ThumbnailFile.FileName;

                    book.ThumbnailPath = Thumbnailfolder;

                    Thumbnailfolder = Path.Combine(_webHostEvn.WebRootPath, Thumbnailfolder);
                    premiumBookData.ThumbnailFile.CopyTo(new FileStream(Thumbnailfolder, FileMode.Create));

                }
                else
                {
                    book.ThumbnailPath = "assets/bg1.jpg";
                }


                BookPDFfolder = Path.Combine(_webHostEvn.WebRootPath, BookPDFfolder);

                premiumBookData.BookFile.CopyTo(new FileStream(BookPDFfolder, FileMode.Create));

                await _bookRepo.AddBook(book);

               
                
                TempData["success"] = "Book has been Uploaded";
                await NotifyAllAsync(GetAuthId(), premiumBookData.Name);
                return Redirect("/upload/premium");

                
            }
            catch 
            {
              
               TempData["error"] = "Something went wrong";
                return Redirect("/upload/premium");

            }

        }


        [Route("/upload/free")]
        [HttpPost]
        public async Task<IActionResult> UploadFree(BookData freeBookData)
        {

            List<Category> categories = _bookRepo.AllCategories();

            if (!categories.Select(category => category.Name).Contains(freeBookData.Category))
            {
                TempData["error"] = "invalid Category";
                return Redirect("/upload/free");
            }

            try
            {
                string Thumbnailfolder = "Books/Thumbnail/";
                string BookPDFfolder = "Books/BookPDF/";

                BookPDFfolder += "FreeBook__" + GetAuthId() + "_" + Guid.NewGuid().ToString() + freeBookData.BookFile.FileName;

                  

                Book book = new Book();

                book.Name = freeBookData.Name;
                book.Author = freeBookData.Author;
                book.Description = freeBookData.Description;
                book.Language = freeBookData.Language;
                book.Uploader = GetAuthId();
                book.Category = freeBookData.Category;
                book.Price = 0;
                book.IsActive = true;
                book.IsPremium = false;
                book.UploadTime = DateTime.Now;
                book.Likes = 0;
                book.Readers = 0;
                book.Comments = 0;
                
                book.FilePath = BookPDFfolder;

                BookPDFfolder = Path.Combine(_webHostEvn.WebRootPath, BookPDFfolder);

                if(freeBookData.ThumbnailFile?.FileName!=null)
                {
                    Thumbnailfolder += "Thumbnail_" + GetAuthId() + "_" + Guid.NewGuid().ToString() + freeBookData.ThumbnailFile.FileName;

                    book.ThumbnailPath = Thumbnailfolder;
                    Thumbnailfolder = Path.Combine(_webHostEvn.WebRootPath, Thumbnailfolder);
                    freeBookData.ThumbnailFile.CopyTo(new FileStream(Thumbnailfolder, FileMode.Create));

                }
                else
                {
                    book.ThumbnailPath = "assets/bg1.jpg";
                }


                freeBookData.BookFile.CopyTo(new FileStream(BookPDFfolder, FileMode.Create));

                await _bookRepo.AddBook(book);

               TempData["success"] = "Book has been Uploaded";
                await NotifyAllAsync(GetAuthId(), freeBookData.Name);
                return Redirect("/upload/free");
            }
            catch 
            {
             
                TempData["error"] = "Something went wrong";
                return Redirect("/upload/free");
            }

        }



        [Route("/upload/course")]
        [HttpPost]
        public async Task<IActionResult> UploadCourse(CourseData courseData)
        {

            List<Category> categories = _bookRepo.AllCategories();

            if (!categories.Select(category => category.Name).Contains(courseData.Category))
            {
                TempData["error"] = "invalid Category";
                return Redirect("/upload/course");
            }


            try
            {
                string Thumbnailfolder = "Books/Thumbnail/";



                 

                Course course = new Course();

                course.Name = courseData.Name;
                course.Source = courseData.Source;
                course.Description = courseData.Description;
                course.Language = courseData.Language;
                course.Uploader = GetAuthId();
                course.Category = courseData.Category;

                course.IsActive = true;

                course.UploadTime = DateTime.Now;
                course.Likes = 0;
                course.Readers = 0;
                course.Comments = 0;
                if(!courseData.URL.StartsWith("http"))
                {
                    course.URL = "https://"+courseData.URL;
                }
                else
                {
                    course.URL = courseData.URL;
                }
                

                if(courseData.ThumbnailFile?.FileName!=null)
                {
                    Thumbnailfolder += "Thumbnail_" + GetAuthId() + "_" + Guid.NewGuid().ToString() + courseData.ThumbnailFile.FileName;

                    course.ThumbnailPath = Thumbnailfolder;
                    Thumbnailfolder = Path.Combine(_webHostEvn.WebRootPath, Thumbnailfolder);
                    courseData.ThumbnailFile.CopyTo(new FileStream(Thumbnailfolder, FileMode.Create));

                }
                else
                {
                    course.ThumbnailPath = "assets/bg1.jpg";
                }


                await _courseRepo.AddCourse(course);

               TempData["success"] = "Course has been Uploaded";
                await  NotifyAllAsync(GetAuthId(), courseData.Name);
                return Redirect("/upload/course");
            }
            catch
            {
                TempData["error"] = "Something went wrong";
                return Redirect("/upload/course");
            }

        }

        public async Task NotifyAllAsync(int uploader,string ResourceName)
        {
            List<User> subscribers = _specificationRepo.AllSubscribers(uploader);
            User uploaderData = await _userRepo.GetUserById(uploader);
            foreach(User user in subscribers)
            {
                SendNotification(user.Id, uploaderData.Name+" Uploaded a new item "+ResourceName);
            }
        }

        [HttpGet]
        [Route("/checkout/book/{id}")]
        public async Task<IActionResult> Checkout(int id)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/checkout/book/" + id);
            }

            Book book = _bookRepo.GetBookById(id);
            User uploader = await _userRepo.GetUserById(book.Uploader);
            string uploaderName = uploader.Name;

            bool selfUpload = book.Uploader == GetAuthId() ? true : false;

            List<Comment> comments = _specificationRepo.AllCommentsOfBook(id);
            long subscriberCount = _specificationRepo.GetSubscriberCountById(book.Uploader);

            bool isLiked = _specificationRepo.IsLikedOnBook(GetAuthId(), id);
            bool isSubscribed = _specificationRepo.IsSubscribed(GetAuthId(), book.Uploader);

            bool isEnrolled = _paymentRepo.hasBook(GetAuthId(), id);
            bool isSaved = _savedRepo.isSaved(GetAuthId(), id, "book");

            if (isEnrolled && TempData["success"] ==null && TempData["error"] ==null)
            {
                TempData["success"] = "Book is already enrolled";
            }



            ViewBag.book = book;
            ViewBag.isOwnBook =  isEnrolled;
            ViewBag.selfUpload = selfUpload;
            ViewBag.comments = comments;
            ViewBag.isLiked = isLiked;
            ViewBag.isSaved = isSaved;
            ViewBag.isSubscribed = isSubscribed;
            ViewBag.UploaderName = uploaderName;
            ViewBag.subscriberCount = subscriberCount;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();



            ViewBag.style = "CheckOutStyle.css";
            ViewBag.search = false;
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

            
            ViewBag.activeHome = true;
            ViewBag.layoutName = "_LoginLayout.cshtml";

            return View("Views/User/CheckOutBook.cshtml");

        }

        [HttpGet]
        [Route("/checkout/course/{id}")]
        public async Task<IActionResult> CheckoutCourse(int id)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/checkout/course/" + id);
            }
            Course course = _courseRepo.GetCourseById(id);

            User uploader = await _userRepo.GetUserById(course.Uploader);
            string uploaderName = uploader.Name;

            bool selfUpload = course.Uploader == GetAuthId() ? true : false;
           

            List<Comment> comments = _specificationRepo.AllCommentsOfCourse(id);
            long subscriberCount = _specificationRepo.GetSubscriberCountById(course.Uploader);

            bool isLiked = _specificationRepo.IsLikedOnCourse(GetAuthId(), id);
            bool isSubscribed = _specificationRepo.IsSubscribed(GetAuthId(), course.Uploader);
            bool isEnrolled = _paymentRepo.hasCourse(GetAuthId(), id);
            bool isSaved = _savedRepo.isSaved(GetAuthId(), id, "course");


            if (isEnrolled)
            {
                TempData["success"] = "Course is already enrolled";
            }

            ViewBag.course = course;
            ViewBag.isOwnCourse =isEnrolled;
            ViewBag.selfUpload = selfUpload;
            ViewBag.comments = comments;
            ViewBag.isLiked = isLiked;
            ViewBag.isSaved = isSaved;
            ViewBag.isSubscribed = isSubscribed;
            ViewBag.UploaderName = uploaderName;
            ViewBag.subscriberCount = subscriberCount;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();


            ViewBag.style = "CheckOutStyle.css";
            ViewBag.search = false;
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
            ViewBag.activeHome = true;
            ViewBag.layoutName = "_LoginLayout.cshtml";

            return View("Views/User/CheckOutCourse.cshtml");

        }

        [HttpGet]
        [Route("/buy/{id}")]
        public async Task<IActionResult> Buy(int id)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/buy/" + id);
            }
            Book book = _bookRepo.GetBookById(id);

            bool hasBook = _paymentRepo.hasBook(GetAuthId(), id);

            if (hasBook)
            {
                if (book.IsPremium)
                {
                    TempData["error"] = "Book is already enrolled";
                    return Redirect("/myenrols/premium");
                }
                else
                {
                    TempData["error"] = "Book is already enrolled";
                    return Redirect("/myenrols/free");
                }
            }
            else
            {
                if (book.IsPremium)
                {
                    ViewBag.bookId = id;
                    ViewBag.price = book.Price;
                    return View("Views/User/Payment.cshtml");
                }
                else
                {
                    Payment payment = new Payment();
                    payment.SourceId = id;
                    payment.Source = "Free";
                    payment.Timestamp = DateTime.Now;
                    payment.UserId = GetAuthId();

                    bool status = await _paymentRepo.Payment(payment);
                    if (status)
                    {
                        book.Readers++;
                        _bookRepo.SaveChanges();
                        TempData["success"] = "Book Enrolled Successfully.";
                        return Redirect("/myenrols/free");
                    }
                    else
                    {
                        TempData["error"] = "Unable to Enroll. Please try again";
                        return Redirect("/checkout/book/" + id);
                    }
                }
            }


        }

        [HttpGet]
        [Route("/launch/{id}")]
        public async Task<IActionResult> Launch(int id)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/launch/" + id);
            }
            Course course = _courseRepo.GetCourseById(id);

            bool hasCourse = _paymentRepo.hasCourse(GetAuthId(), id);

            if (hasCourse)
            {
                TempData["success"] = "Course is already enrolled";
                return Redirect("/myenrols/course");

            }
            else
            {

                Payment payment = new Payment();
                payment.SourceId = id;
                payment.Source = "Course";
                payment.Timestamp = DateTime.Now;
                payment.UserId = GetAuthId();

                bool status = await _paymentRepo.Payment(payment);
                if (status)
                {
                    course.Readers++;
                    _courseRepo.SaveChanges();
                    TempData["success"] = "Course Enrolled Successfully.";
                    return Redirect("/myenrols/course");
                }
                else
                {
                    TempData["error"] = "Unable to Enroll. Please try again";
                    return Redirect("/checkout/course/" + id);
                }

            }


        }

      

        [HttpPost]
        [Route("/buy/{id}")]
        public async Task<IActionResult> Payment(int id, string firstFour, string secondFour, string thirdFour, string forthFour, string cvv)
        {                
            string card = firstFour + secondFour + thirdFour + forthFour + "-" + cvv;
            Payment payment = new Payment();
            payment.SourceId = id;
            payment.Source = card;
            payment.Timestamp = DateTime.Now;
            payment.UserId = GetAuthId();

            User user = await _userRepo.GetUserById(GetAuthId());

            bool status = false;
            
            try
            {

                // get the book price and split 5% for Admin and 95% for Uploader
                Book book = _bookRepo.GetBookById(id); 
                long price = book.Price; 

                long uploaderPrice = (long)Math.Round(price * 0.95); 
                long adminPrice = price - uploaderPrice; 

                // update earnings to uploader
                User uploader = await _userRepo.GetUserById(book.Uploader);
                uploader.Earnings += uploaderPrice;
                _userRepo.save();


                // update earnings to admin
                bool adminUpdated = _adminRepo.AddMoney(adminPrice);
                bool paymentCreated = false;
                if (adminUpdated)
                {
                    paymentCreated =  await _paymentRepo.Payment(payment);
                    book.Readers++;
                    _bookRepo.SaveChanges();
                    SendNotification(user.Id, "Awesome, The book '" + book.Name + "' is enrolled successfully for Rs." + book.Price + ".");

                    SendNotification(uploader.Id, "Hurray, " + user.Name + " has bought your book '" + book.Name + "' for Rs."+book.Price+" now.");
                }

                status = adminUpdated && paymentCreated;

            }
            catch
            {
               
                status = false;
            }

            

            
            if (status)
            {
                TempData["success"] = "Book Enrolled Successfully.";
                return Redirect("/myenrols/premium");
            }
            else
            {
                TempData["error"] = "Unable to Enroll.";
                return Redirect("/checkout/book/" + id);
            }


        }

        [HttpPost]
        [Route("/buy/upi/{id}")]
        public async Task<IActionResult> PaymentUPI(int id, string upiID)
        {

            Payment payment = new Payment();
            payment.SourceId = id;
            payment.Source = "UPI-" + upiID;
            payment.Timestamp = DateTime.Now;
            payment.UserId = GetAuthId();

            User user = await _userRepo.GetUserById(GetAuthId());

            bool status = false;

            try
            {

                // get the book price and split 5% for Admin and 95% for Uploader
                Book book = _bookRepo.GetBookById(id);
                long price = book.Price;

                long uploaderPrice = (long)Math.Round(price * 0.95);
                long adminPrice = price - uploaderPrice;

                // update earnings to uploader
                User uploader = await _userRepo.GetUserById(book.Uploader);
                uploader.Earnings += uploaderPrice;
                _userRepo.save();


                // update earnings to admin
                bool adminUpdated = _adminRepo.AddMoney(adminPrice);
                bool paymentCreated = false;
                if (adminUpdated)
                {
                    paymentCreated = await _paymentRepo.Payment(payment);
                    book.Readers++;
                    _bookRepo.SaveChanges();

                    SendNotification(user.Id, "Awesome, The book '" + book.Name + "' is enrolled successfully for Rs." + book.Price + ".");

                    SendNotification(uploader.Id, "Hurray, " + user.Name + " has bought your book '" + book.Name + "' for Rs." + book.Price + " now.");
                }

                status = adminUpdated && paymentCreated;

            }
            catch
            {
                status = false;
            }



            if (status)
            {
                TempData["success"] = "Book Enrolled Successfully.";
                return Redirect("/myenrols/premium");
            }
            else
            {
                TempData["error"] = "Unable to Enroll. ";
                return Redirect("/checkout/book/" + id);
            }


        }





        [HttpGet]
        [Route("/read/{id}")]
        public IActionResult ReadBook(int id)
        {
            int userId = GetAuthId();
            ViewBag.style = "PDFReaderStyle.css";
            ViewBag.layoutName = "_LoginLayout.cshtml";
            Book book = _bookRepo.GetBookById(id);
            ViewBag.bookPDFPath = book.FilePath;


            
            ViewBag.search = false ;
            if (userId>0)
            {
                ViewBag.reader = true;
                ViewBag.message = true;
                ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

                ViewBag.success = "Happy Reading...";
            }
            else
            {

                TempData["error"] = "Login before reading";

                return Redirect("/login?redirect=/read/"+id);
            }
            ViewBag.activeProfile = true;
            return View("Views/User/PDFReader.cshtml");


        }






       


        [HttpGet]
        [Route("/myenrols/premium")]
        public IActionResult MyEnrolsPremium(string search,string category,string sort)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/myenrols/premium");
            }
            int id = GetAuthId();
            List<int> BookIdList = _paymentRepo.GetPremiumBookIdByUser(id);
            List<Book> books = _bookRepo.AllPremiumBooks().Where(book => BookIdList.Contains(book.Id)).ToList();
            List<int> likedItems = _specificationRepo.AllLikesOfBook(GetAuthId());
            List<int> savedItems = _savedRepo.AllSavedId(GetAuthId(), "book");

            ViewBag.likedItems = likedItems;
            ViewBag.savedItems = savedItems;

            ViewBag.books = books;






            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

            ViewBag.style = "MyBooksPremiumStyle.css";
            ViewBag.layoutName = "_LoginLayout.cshtml";
            ViewBag.search = true;
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


            if (search != null)
            {
              

                List<Book> results = SearchBook(search, books);
                if (results.Count() == 0)
                {
                   

                    ViewBag.message = true;
                    ViewBag.error = "No books found";
                }
                else
                {
                    ViewBag.books = results;
                }


            }

            List<string> categories = books.Select(book => book.Category).Distinct().ToList();

            if (category != null || sort != null)
            {

                List<Book> result = books;

                if (category != null)
                {
                    if (categories.Contains(category))
                    {
                        result = books.Where(book => book.Category == category).ToList();
                    }
                    else
                    {
                        ViewBag.message = true;
                        ViewBag.error = "invalid selection";
                    }
                }

                if (sort != null)
                {
                    if (sort == "Price Up")
                    {
                        result = result.OrderByDescending(book => book.Price).ToList();
                    }
                    else if (sort == "Price Down")
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

                ViewBag.books = result;


            }

            ViewBag.categories = categories;

            ViewBag.activeProfile = true;
            return View("Views/User/MyBooksPremium.cshtml");






        }




        [HttpGet]
        [Route("/myenrols/free")]
        public IActionResult MyEnrolsFree(string search, string category, string sort)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/myenrols/free");
            }
            int id = GetAuthId();
            List<int> BookIdList = _paymentRepo.GetFreeBookIdByUser(id);
            List<Book> books = _bookRepo.AllFreeBooks().Where(book => BookIdList.Contains(book.Id)).ToList();
            List<int> likedItems = _specificationRepo.AllLikesOfBook(GetAuthId());
            List<int> savedItems = _savedRepo.AllSavedId(GetAuthId(), "book");

            ViewBag.likedItems = likedItems;
            ViewBag.savedItems = savedItems;
            ViewBag.books = books;
            ViewBag.style = "MyBooksFreeStyle.css";
            ViewBag.layoutName = "_LoginLayout.cshtml";
            ViewBag.search = true;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

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

            if (search != null)
            {


                List<Book> results = SearchBook(search, books);
                if (results.Count() == 0)
                {


                    ViewBag.message = true;
                    ViewBag.error = "No books found";
                }
                else
                {
                    ViewBag.books = results;
                }


            }

            List<string> categories = books.Select(book => book.Category).Distinct().ToList();

            if (category != null || sort != null)
            {

                List<Book> result = books;

                if (category != null)
                {
                    if (categories.Contains(category))
                    {
                        result = books.Where(book => book.Category == category).ToList();
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
                        result = result.OrderByDescending(book => book.UploadTime).ToList();
                    }
                    else if (sort == "Language")
                    {

                        result = result.OrderByDescending(book => book.Language).ToList();
                
                    }


                }

                ViewBag.books = result;


            }

            ViewBag.categories = categories;
            ViewBag.activeProfile = true;
            return View("Views/User/MyBooksFree.cshtml");



        }





        [HttpGet]
        [Route("/myenrols/course")]
        public IActionResult MyEnrolsCourse(string search, string category,string sort)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/myenrols/course");
            }
            int id = GetAuthId();
            List<int> courseIdList = _paymentRepo.GetCoursedByUser(id);
            List<Course> courses = _courseRepo.AllCourses().Where(course => courseIdList.Contains(course.Id)).ToList();
            List<int> likedItems = _specificationRepo.AllLikesOfCourse(GetAuthId());
            List<int> savedItems = _savedRepo.AllSavedId(GetAuthId(), "course");

            
            ViewBag.likedItems = likedItems;
            ViewBag.savedItems = savedItems;
            ViewBag.courses = courses;
            ViewBag.style = "MyCoursesStyle.css";
            ViewBag.layoutName = "_LoginLayout.cshtml";
            ViewBag.search = true;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

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


            if (search != null)
            {
               

                List<Course> results = SearchCourse(search, courses);
                if (results.Count() == 0)
                {
                    ViewBag.message = true;
                    ViewBag.error = "No courses found";
                }
                else
                {
                    ViewBag.courses = results;
                }


            }


            List<string> categories = courses.Select(course => course.Category).Distinct().ToList();

            if (category != null || sort != null)
            {

                List<Course> result = courses;

                if (category != null)
                {
                    if (categories.Contains(category))
                    {
                        result = courses.Where(course => course.Category == category).ToList();
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

                ViewBag.courses = result;


            }

            ViewBag.categories = categories;

            ViewBag.activeProfile = true;
            return View("Views/User/MyCourses.cshtml");

        }

        [HttpGet]
        [Route("/like/{id}")]
        public async Task<IActionResult> LikeBook(int id, string redirect)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/like/"+id+"?redirect="+redirect);
            }

            User user = await _userRepo.GetUserById(GetAuthId());

            if(_bookRepo.GetBookById(id)?.Uploader==GetAuthId())
            {
                TempData["error"] = "Its your own book";

                return Redirect(redirect);
            }

            if (_paymentRepo.hasBook(GetAuthId(), id))
            {
                bool isLiked = _specificationRepo.IsLikedOnBook(GetAuthId(), id);

                if (isLiked)
                {
                    Like like = _specificationRepo.GetBookLike(GetAuthId(), id);
                    bool status = _specificationRepo.DisLike(like);
                    if (status)
                    {
                        Book book = _bookRepo.GetBookById(id);
                        book.Likes--;
                        _bookRepo.SaveChanges();

                        SendNotification(book.Uploader, "Oops, " + user.Name + " disliked your book '" + book.Name + "'");

                    }


                    return Redirect(redirect);
                }
                else
                {
                    Like like = new Like();
                    like.IsBook = true;
                    like.ResourceId = id;
                    like.TimeStamp = DateTime.Now;
                    like.UserId = GetAuthId();

                    bool status = _specificationRepo.AddLike(like);
                    if (status)
                    {
                        Book book = _bookRepo.GetBookById(id);
                        book.Likes++;
                        _bookRepo.SaveChanges();
                        SendNotification(book.Uploader, "Yeah...," + user.Name + " liked your book '" + book.Name + "'");

                    }


                    return Redirect(redirect);
                }
            }
            else
            {
                TempData["error"] = "You haven't enrolled ";

                return Redirect(redirect);
            }

        }


        [HttpGet]
        [Route("/like/course/{id}")]
        public async Task<IActionResult> LikeCourse(int id, string redirect)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/like/course/" + id + "?redirect=" + redirect);
            }


            if (_courseRepo.GetCourseById(id)?.Uploader == GetAuthId())
            {
                TempData["error"] = "Its your own Course";

                return Redirect(redirect);
            }


            User user = await _userRepo.GetUserById(GetAuthId());
            if (_paymentRepo.hasCourse(GetAuthId(), id))
            {
                bool isLiked = _specificationRepo.IsLikedOnCourse(GetAuthId(), id);

                if (isLiked)
                {
                    Like like = _specificationRepo.GetCourseLike(GetAuthId(), id);
                    bool status = _specificationRepo.DisLike(like);
                    if (status)
                    {
                        Course course = _courseRepo.GetCourseById(id);
                        course.Likes--;
                        _courseRepo.SaveChanges();

                        SendNotification(course.Uploader, "Oops, " + user.Name + " disliked your course '" + course.Name + "'");

                    }


                    return Redirect(redirect);
                }
                else
                {
                    Like like = new Like();
                    like.IsBook = false;
                    like.ResourceId = id;
                    like.TimeStamp = DateTime.Now;
                    like.UserId = GetAuthId();

                    bool status = _specificationRepo.AddLike(like);
                    if (status)
                    {
                        Course course = _courseRepo.GetCourseById(id);
                        course.Likes++;
                        _courseRepo.SaveChanges();
                        SendNotification(course.Uploader, "Yeah..., " + user.Name + " liked your course '" + course.Name + "'");

                    }


                    return Redirect(redirect);
                }
            }
            else
            {
                TempData["error"] = "You haven't enrolled";

                return Redirect(redirect);
            }
        }


        [HttpGet]
        [Route("/comment/{item}/{id}")]
        public IActionResult CommentPage(string item, int id, string redirect)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/comment/"+item+"/" + id + "?redirect=" + redirect);
            }
            if (item == "book")
            {
                if (_paymentRepo.hasBook(GetAuthId(), id))
                {
                    if (_specificationRepo.IsCommentedOnBook(GetAuthId(), id))
                    {
                        TempData["success"] = "Already commented";

                        return Redirect("/checkout/book/" + id + "#commentSectionPoint");
                    }
                    ViewBag.id = id;
                    ViewBag.redirect = redirect;
                    ViewBag.book = _bookRepo.GetBookById(id);
                    ViewBag.isLiked = _specificationRepo.IsLikedOnBook(GetAuthId(), id);
                    ViewBag.activeHome = true;
                    ViewBag.search = false;
                    ViewBag.message = false;
                    ViewBag.style = "CommentStyle.css";
                    ViewBag.layoutName = "_LoginLayout.cshtml";
                    ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

                    return View("Views/User/Comment.cshtml");

                }
                else
                {
                    TempData["success"] = "Enroll this before comment";

                    return Redirect("/checkout/book/"+id+ "#commentSectionPoint");
                }
            }
            else
            {
                if (_paymentRepo.hasCourse(GetAuthId(), id))
                {
                    if(_specificationRepo.IsCommentedOnCourse(GetAuthId(),id))
                    {
                        TempData["success"] = "Already commented";

                        return Redirect("/checkout/course/" + id + "#commentSectionPoint");
                    }
                    ViewBag.id = id;
                    ViewBag.redirect = redirect;
                    ViewBag.course = _courseRepo.GetCourseById(id);
                    ViewBag.isLiked = _specificationRepo.IsLikedOnCourse(GetAuthId(), id);
                    ViewBag.activeHome = true;
                    ViewBag.search = false;
                    ViewBag.message = false;
                    ViewBag.style = "CommentStyle.css";
                    ViewBag.layoutName = "_LoginLayout.cshtml";
                    ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

                    return View("Views/User/CommentCourse.cshtml");

                }
                else
                {
                    TempData["success"] = "Enroll this before comment";

                    return Redirect("/checkout/course/" + id + "#commentSectionPoint");
                }
            }
        }


        [HttpPost]
        [Route("/comment/{item}/{id}")]
        public async Task<IActionResult> Comment(string item, int id, string redirect,string commenttext)
        {
            if (item == "book")
            {
               
               
                User user = await _userRepo.GetUserById(GetAuthId());

                Comment comment = new Comment();
                comment.IsBook = true;
                comment.ResourceId = id;
                comment.TimeStamp = DateTime.Now;
                comment.UserId = GetAuthId();
                comment.Review = commenttext;
                comment.Name = user.Name;
                
                bool status = _specificationRepo.AddComment(comment);
                    if (status)
                    {
                        Book book = _bookRepo.GetBookById(id);
                        book.Comments++;
                        _bookRepo.SaveChanges();

                    SendNotification(book.Uploader, "Yeah..., " + user.Name + " commented on your book '" + book.Name + "'");

                }

                TempData["success"] = "Comment added on book";
            }
            else
            {
               
                User user = await _userRepo.GetUserById(GetAuthId());

                Comment comment = new Comment();
                comment.IsBook = false;
                comment.ResourceId = id;
                comment.TimeStamp = DateTime.Now;
                comment.UserId = GetAuthId();
                comment.Review = commenttext;
                comment.Name = user.Name;

                bool status = _specificationRepo.AddComment(comment);
                if (status)
                {
                    Course course = _courseRepo.GetCourseById(id);
                    course.Comments++;
                    _courseRepo.SaveChanges();

                    SendNotification(course.Uploader, "Yeah..., " + user.Name + " commented on your course '" + course.Name + "'");

                }

                TempData["success"] = "Comment added on course";


            }


            return Redirect(redirect);
        }


        [HttpGet]
        [Route("/subscribe/{uploaderId}")]
        public async Task<IActionResult> SubscribeAsync(int uploaderId,string redirect)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/subscribe/"+ uploaderId + "?redirect=" + redirect);
            }

            User user = await _userRepo.GetUserById(GetAuthId());


            if (_specificationRepo.IsSubscribed(GetAuthId(),uploaderId))
            {
                bool status = _specificationRepo.Unsubscribe(GetAuthId(), uploaderId);
                if(status)
                {
                    TempData["error"] = "Unsubscribed";

                    SendNotification(uploaderId, "Oops, " + user.Name + " unsubscribed to you.");

                    return Redirect(redirect);
                }
                else
                {
                    TempData["error"] = "Unable to Unsubscribe";
                    return Redirect(redirect);
                }
            }
            else
            {
                bool status = _specificationRepo.Subscribe(GetAuthId(), uploaderId);
                if (status)
                {
                    TempData["success"] = "Subscribed";
                    SendNotification(uploaderId, "Hurray, " + user.Name + " subscribed to you.");

                    return Redirect(redirect);
                }
                else
                {
                    TempData["error"] = "Unable to Subscribe";
                    return Redirect(redirect);
                }
            }
        }



        [HttpGet]
        [Route("/save/{type}/{id}")]
        public IActionResult Save(string type, int id,string redirect)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/save/"+type+"/" + id + "?redirect=" + redirect);
            }
            if (type=="book")
            {
                if(_savedRepo.isSaved(GetAuthId(),id,"book"))
                {
                    TempData["error"] = "Book is already saved";
                    return Redirect(redirect);
                }
                else
                {
                    Saved saved = new Saved();
                    saved.isBook = true;
                    saved.SourceId = id;
                    saved.UserId = GetAuthId();
                    saved.SavedTime = DateTime.Now;

                    bool status = _savedRepo.Save(saved);
                    if(status)
                    {
                        TempData["success"] = "Book has been saved";
                        return Redirect(redirect);
                    }
                    else
                    {
                        TempData["error"] = "Unable to save book";
                        return Redirect(redirect);
                    }
                }
            }
            else
            {
                if (_savedRepo.isSaved(GetAuthId(), id, "course"))
                {
                    TempData["error"] = "Course is already saved";
                    return Redirect(redirect);
                }
                else
                {
                    Saved saved = new Saved();
                    saved.isBook = false;
                    saved.SourceId = id;
                    saved.UserId = GetAuthId();
                    saved.SavedTime = DateTime.Now;

                    bool status = _savedRepo.Save(saved);
                    if (status)
                    {
                        TempData["success"] = "Course has been saved";
                        return Redirect(redirect);
                    }
                    else
                    {
                        TempData["error"] = "Unable to save course";
                        return Redirect(redirect);
                    }
                }
            }
        }




        [HttpGet]
        [Route("/unsave/{type}/{id}")]
        public IActionResult Unsave(string type, int id, string redirect)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/unsave/" + type + "/" + id + "?redirect=" + redirect);
            }
            if (type == "book")
            {
                if (_savedRepo.isSaved(GetAuthId(), id, "book"))
                {
                    bool status = _savedRepo.Unsave(GetAuthId(), id, "book");
                    if (status)
                    {
                        TempData["success"] = "Book has been removed";
                        return Redirect(redirect);
                    }
                    else
                    {
                        TempData["error"] = "Unable to remove book";
                        return Redirect(redirect);
                    }
                   
                }
                else
                {

                    TempData["error"] = "Book is already removed";
                    return Redirect(redirect);

                }
            }
            else
            {
                if (_savedRepo.isSaved(GetAuthId(), id, "course"))
                {

                    bool status = _savedRepo.Unsave(GetAuthId(), id, "course");
                    if (status)
                    {
                        TempData["success"] = "Course has been removed";
                        return Redirect(redirect);
                    }
                    else
                    {
                        TempData["error"] = "Unable to remove course";
                        return Redirect(redirect);
                    }
                   
                }
                else
                {

                    TempData["error"] = "Course is already removed";
                    return Redirect(redirect);
                }
            }
        }


//------------------------------------------------------------------


        [HttpGet]
        [Route("/saved/premium")]
        public IActionResult SavedPremium(string search,string category,string sort)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/saved/premium");
            }
            int id = GetAuthId();
            List<int> BookIdList = _savedRepo.AllSavedId(id, "book");
            List<Book> books = _bookRepo.AllPremiumBooks().Where(book => BookIdList.Contains(book.Id) && book.IsPremium).ToList();
            List<int> likedItems = _specificationRepo.AllLikesOfBook(GetAuthId());

            ViewBag.likedItems = likedItems;
            ViewBag.books = books;

            ViewBag.style = "MyBooksPremiumStyle.css";
            ViewBag.layoutName = "_LoginLayout.cshtml";
            ViewBag.search = true;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

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


            if (search != null)
            {


                List<Book> results = SearchBook(search, books);
                if (results.Count() == 0)
                {


                    ViewBag.message = true;
                    ViewBag.error = "No books found";
                }
                else
                {
                    ViewBag.books = results;
                }


            }

            List<string> categories = books.Select(book => book.Category).Distinct().ToList();

            if (category != null || sort != null)
            {

                List<Book> result = books;

                if (category != null)
                {
                    if (categories.Contains(category))
                    {
                        result = books.Where(book => book.Category == category).ToList();
                    }
                    else
                    {
                        ViewBag.message = true;
                        ViewBag.error = "invalid selection";
                    }
                }

                if (sort != null)
                {
                    if (sort == "Price Up")
                    {
                        result = result.OrderByDescending(book => book.Price).ToList();
                    }
                    else if (sort == "Price Down")
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

                ViewBag.books = result;


            }

            ViewBag.categories = categories;
            ViewBag.activeProfile = true;
            return View("Views/User/SavedBooksPremium.cshtml");






        }




        [HttpGet]
        [Route("/saved/free")]
        public IActionResult SavedFree(string search, string category,string sort)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/saved/free");
            }
            int id = GetAuthId();
            List<int> BookIdList = _savedRepo.AllSavedId(id, "book");
            List<Book> books = _bookRepo.AllFreeBooks().Where(book => BookIdList.Contains(book.Id) && book.IsPremium==false).ToList();
            List<int> likedItems = _specificationRepo.AllLikesOfBook(GetAuthId());

            ViewBag.likedItems = likedItems;
            ViewBag.books = books;
            ViewBag.style = "MyBooksFreeStyle.css";
            ViewBag.layoutName = "_LoginLayout.cshtml";
            ViewBag.search = true;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

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

            if (search != null)
            {


                List<Book> results = SearchBook(search, books);
                if (results.Count() == 0)
                {


                    ViewBag.message = true;
                    ViewBag.error = "No books found";
                }
                else
                {
                    ViewBag.books = results;
                }


            }

            List<string> categories = books.Select(book => book.Category).Distinct().ToList();

            if (category != null || sort != null)
            {

                List<Book> result = books;

                if (category != null)
                {
                    if (categories.Contains(category))
                    {
                        result = books.Where(book => book.Category == category).ToList();
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
                        result = result.OrderByDescending(book => book.UploadTime).ToList();
                    }
                    else if (sort == "Language")
                    {

                        result = result.OrderByDescending(book => book.Language).ToList();

                    }


                }

                ViewBag.books = result;


            }

            ViewBag.categories = categories;
            ViewBag.activeProfile = true;
            return View("Views/User/SavedBooksFree.cshtml");



        }





        [HttpGet]
        [Route("/saved/course")]
        public IActionResult SavedCourse(string search,string category,string sort)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/saved/course");
            }

            int id = GetAuthId();
            List<int> courseIdList = _savedRepo.AllSavedId(id, "course");
            List<Course> courses = _courseRepo.AllCourses().Where(course => courseIdList.Contains(course.Id)).ToList();
            List<int> likedItems = _specificationRepo.AllLikesOfCourse(GetAuthId());


            ViewBag.likedItems = likedItems;
            ViewBag.courses = courses;
            ViewBag.style = "MyCoursesStyle.css";
            ViewBag.layoutName = "_LoginLayout.cshtml";
            ViewBag.search = true;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

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


            if (search != null)
            {


                List<Course> results = SearchCourse(search, courses);
                if (results.Count() == 0)
                {
                    ViewBag.message = true;
                    ViewBag.error = "No courses found";
                }
                else
                {
                    ViewBag.courses = results;
                }


            }


            List<string> categories = courses.Select(course => course.Category).Distinct().ToList();

            if (category != null || sort != null)
            {

                List<Course> result = courses;

                if (category != null)
                {
                    if (categories.Contains(category))
                    {
                        result = courses.Where(course => course.Category == category).ToList();
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

                ViewBag.courses = result;


            }

            ViewBag.categories = categories;
            ViewBag.activeProfile = true;
            return View("Views/User/SavedCourses.cshtml");

        }

        

        [HttpGet]
        [Route("/profile")]
        public async Task<IActionResult> Profile()
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/profile");
            }
            int id = GetAuthId();
            User user = await _userRepo.GetUserById(id);

            int myPremiumBooks = _bookRepo.AllPremiumBooks().Where(book => book.Uploader == id).ToList().Count();
            int myFreeBooks = _bookRepo.AllFreeBooks().Where(book => book.Uploader == id).ToList().Count();
            int myCourse = _courseRepo.AllCourses().Where(course => course.Uploader == id).ToList().Count();

            int enrolledPremiumBooks = _paymentRepo.GetPremiumBookIdByUser(id).ToList().Count();
            int enrolledFreeBooks = _paymentRepo.GetFreeBookIdByUser(id).ToList().Count();
            int enrolledCourse = _paymentRepo.GetCoursedByUser(id).ToList().Count();

            long subscribersCount = _specificationRepo.GetSubscriberCountById(id);

            ViewBag.user = user;
            ViewBag.myPremiumBooks = myPremiumBooks;
            ViewBag.myFreeBooks = myFreeBooks;
            ViewBag.myCourse = myCourse;
            ViewBag.enrolledPremiumBooks = enrolledPremiumBooks;
            ViewBag.enrolledFreeBooks = enrolledFreeBooks;
            ViewBag.enrolledCourse = enrolledCourse;
            ViewBag.subscribersCount = subscribersCount;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

            ViewBag.style = "ProfileStyle.css";
            ViewBag.layoutName = "_LoginLayout.cshtml";
            ViewBag.search = false;
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
            ViewBag.activeProfile = true;
            return View("Views/User/Profile.cshtml");

        }



        [HttpGet]
        [Route("/withdraw")]
        public IActionResult WithDraw()
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/withdraw");
            }

           
            return View("Views/User/Withdraw.cshtml");


        }



        [HttpPost]
        [Route("/withdraw")]
        public async Task<IActionResult> WithDrawBank(string bank,string ifsc)
        {
            int userId = GetAuthId();
            if (userId < 0)
            {
                return Redirect("/login?redirect=/withdraw");
            }
            User user = await _userRepo.GetUserById(userId);
            try
            {
                if (user.Earnings > 0)
                {


                    SendNotification(userId, "Hurray..., Bank Withdraw of amount Rs." + user.Earnings.ToString() + " is successfull on Account : " + bank + ", IFSC : " + ifsc);

                   

                    string body = "<!DOCTYPE html><html lang='en'><head><meta charset='UTF-8'><meta http-equiv='X-UA-Compatible' content='IE=edge'><meta name='viewport' content='width=device-width, initial-scale=1.0'><title>OTP</title><link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css'><style> *{ margin:0px;padding:0px; box-sizing: border-box; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; }.heading{text-align: center;background:#5708be;padding:15px;color:#fff;} h1 i{color:#cecece;} p i{color:#4c04d3; } b{color:#7300d1;} .content{padding:20px;}</style></head><body><div class='heading'><h1><span><i class='fa fa-dice-d6'></i> </span>Read.me</h1></div><div class='content'><p>Hi " + user.Name + "</p><br><p>Bank withdraw of amount <b>Rs." + user.Earnings.ToString() + "</b> is successfull on your account : " + bank + " and IFSC : " + ifsc + " . Keep reading, stay safe.</p><br><p>Thanks and Regards</p><p><i class='fa fa-dice-d6'></i> Read.me</p></div></body></html>";
                    Email.Send(user.Email, "Withdraw Successfull of Amount Rs." + user.Earnings.ToString(), body);

                    user.Earnings = 0;
                    _userRepo.save();
                    TempData["success"] = "Withdraw successfull";
                    return Redirect("/profile");
                }
                else
                {
                    SendNotification(userId, "Oops..., You don't have sufficient Balance to make withdraw.");


                    TempData["error"] = "Insufficient Balance";
                    return Redirect("/profile");
                }

            }
            catch
            {
                TempData["success"] = "Withdraw successfull";
                return Redirect("/profile");
            }



        }


        [HttpPost]
        [Route("/withdraw/upi")]
        public async Task<IActionResult> WithDrawUPI(string upiID)
        {
            int userId = GetAuthId();
            if (userId < 0)
            {
                return Redirect("/login?redirect=/withdraw");
            }
            User user = await _userRepo.GetUserById(userId);
            if (user.Earnings > 0)
            {

              

                SendNotification(userId, "Hurray..., Bank Withdraw of amount Rs." + user.Earnings.ToString() + " is successfull on your UPI : " + upiID);



                string body = "<!DOCTYPE html><html lang='en'><head><meta charset='UTF-8'><meta http-equiv='X-UA-Compatible' content='IE=edge'><meta name='viewport' content='width=device-width, initial-scale=1.0'><title>OTP</title><link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css'><style> *{ margin:0px;padding:0px; box-sizing: border-box; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; }.heading{text-align: center;background:#5708be;padding:15px;color:#fff;} h1 i{color:#cecece;} p i{color:#4c04d3; } b{color:#7300d1;} .content{padding:20px;}</style></head><body><div class='heading'><h1><span><i class='fa fa-dice-d6'></i> </span>Read.me</h1></div><div class='content'><p>Hi " + user.Name + "</p><br><p>Bank withdraw of amount <b>Rs." + user.Earnings.ToString() + "</b> is successfull on your UPI "+upiID+" . Keep reading, stay safe.</p><br><p>Thanks and Regards</p><p><i class='fa fa-dice-d6'></i> Read.me</p></div></body></html>";
                Email.Send(user.Email, "Withdraw Successfull of Amount Rs." + user.Earnings.ToString(), body);

                user.Earnings = 0;
                _userRepo.save();
                TempData["success"] = "Withdraw successfull";
                return Redirect("/profile");
            }
            else
            {
                SendNotification(userId, "Oops..., You don't have sufficient Balance to make withdraw.");


                TempData["error"] = "Insufficient Balance";
                return Redirect("/profile");
            }


        }


        [HttpGet]
        [Route("/portfolio/{uploaderId}/premium")]
        public  IActionResult PortfolioPremium(int uploaderId,string search,string category,string sort)
        {
            int id = GetAuthId();
            List<Book> books = _bookRepo.AllPremiumBooks().Where(book=>book.Uploader==uploaderId).ToList();
            List<int> likedItems = _specificationRepo.AllLikesOfBook(GetAuthId());
            List<int> savedItems = _savedRepo.AllSavedId(GetAuthId(), "book");
            ViewBag.savedItems = savedItems;

            ViewBag.likedItems = likedItems;
            ViewBag.books = books;

            ViewBag.style = "MyBooksPremiumStyle.css";
            if(id==-1)
            {
                ViewBag.layoutName = "_Layout.cshtml";
            }
            else
            {
                ViewBag.layoutName = "_LoginLayout.cshtml";
            }
            
            ViewBag.search = true;
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
            ViewBag.activeHome = true;
            ViewBag.uploaderId = uploaderId;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();



            if (search != null)
            {


                List<Book> results = SearchBook(search, books);
                if (results.Count() == 0)
                {


                    ViewBag.message = true;
                    ViewBag.error = "No books found";
                }
                else
                {
                    ViewBag.books = results;
                }


            }

            List<string> categories = books.Select(book => book.Category).Distinct().ToList();

            if (category != null || sort != null)
            {

                List<Book> result = books;

                if (category != null)
                {
                    if (categories.Contains(category))
                    {
                        result = books.Where(book => book.Category == category).ToList();
                    }
                    else
                    {
                        ViewBag.message = true;
                        ViewBag.error = "invalid selection";
                    }
                }

                if (sort != null)
                {
                    if (sort == "Price Up")
                    {
                        result = result.OrderByDescending(book => book.Price).ToList();
                    }
                    else if (sort == "Price Down")
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

                ViewBag.books = result;


            }

            ViewBag.categories = categories;
            return View("Views/User/PortfolioBooksPremium.cshtml");



        }




        [HttpGet]
        [Route("/portfolio/{uploaderId}/free")]
        public IActionResult PortfolioFree(int uploaderId,string search,string category, string sort)
        {
            int id = GetAuthId();
            List<Book> books = _bookRepo.AllFreeBooks().Where(book => book.Uploader == uploaderId).ToList();
            List<int> likedItems = _specificationRepo.AllLikesOfBook(GetAuthId());
            List<int> savedItems = _savedRepo.AllSavedId(GetAuthId(), "book");

            ViewBag.savedItems = savedItems;

            ViewBag.likedItems = likedItems;
            ViewBag.books = books;

            ViewBag.style = "MyBooksFreeStyle.css";
            if (id == -1)
            {
                ViewBag.layoutName = "_Layout.cshtml";
            }
            else
            {
                ViewBag.layoutName = "_LoginLayout.cshtml";
            }

            ViewBag.search = true;
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
            ViewBag.activeHome = true;
            ViewBag.uploaderId = uploaderId;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();


            if (search != null)
            {


                List<Book> results = SearchBook(search, books);
                if (results.Count() == 0)
                {


                    ViewBag.message = true;
                    ViewBag.error = "No books found";
                }
                else
                {
                    ViewBag.books = results;
                }


            }

            List<string> categories = books.Select(book => book.Category).Distinct().ToList();

            if (category != null || sort != null)
            {

                List<Book> result = books;

                if (category != null)
                {
                    if (categories.Contains(category))
                    {
                        result = books.Where(book => book.Category == category).ToList();
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
                        result = result.OrderByDescending(book => book.UploadTime).ToList();
                    }
                    else if (sort == "Language")
                    {

                        result = result.OrderByDescending(book => book.Language).ToList();

                    }


                }

                ViewBag.books = result;


            }

            ViewBag.categories = categories;
            return View("Views/User/PortfolioBooksFree.cshtml");



        }


        [HttpGet]
        [Route("/portfolio/{uploaderId}/course")]
        public IActionResult Portfolio(int uploaderId,string search,string category,string sort)
        {
            
            int id = GetAuthId();
            List<Course> courses = _courseRepo.AllCourses().Where(course =>course.Uploader==uploaderId).ToList();
            List<int> likedItems = _specificationRepo.AllLikesOfCourse(GetAuthId());
            List<int> savedItems = _savedRepo.AllSavedId(GetAuthId(), "course");

            ViewBag.savedItems = savedItems;

            ViewBag.likedItems = likedItems;
            ViewBag.courses = courses;
            ViewBag.uploaderId = uploaderId;
            ViewBag.style = "MyCoursesStyle.css";

            if (id == -1)
            {
                ViewBag.layoutName = "_Layout.cshtml";
            }
            else
            {
                ViewBag.layoutName = "_LoginLayout.cshtml";
            }


            ViewBag.search = true;
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

            if (search != null)
            {


                List<Course> results = SearchCourse(search, courses);
                if (results.Count() == 0)
                {
                    ViewBag.message = true;
                    ViewBag.error = "No courses found";
                }
                else
                {
                    ViewBag.courses = results;
                }


            }


            List<string> categories = courses.Select(course => course.Category).Distinct().ToList();

            if (category != null || sort != null)
            {

                List<Course> result = courses;

                if (category != null)
                {
                    if (categories.Contains(category))
                    {
                        result = courses.Where(course => course.Category == category).ToList();
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

                ViewBag.courses = result;


            }

            ViewBag.categories = categories;
            ViewBag.activeHome = true;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

            return View("Views/User/PortfolioMyCourses.cshtml");



        }


        

        [HttpGet]
        [Route("/subscribers")]
        public IActionResult Subscribers()
        {

            int id = GetAuthId();

            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/subscribers");
            }
            List<User> subscribers = _specificationRepo.AllSubscribers(id);

            ViewBag.search = false;
            ViewBag.layoutName = "_LoginLayout.cshtml";
            ViewBag.style = "SubscribersStyle.css";
            ViewBag.message = false;
            ViewBag.subscribers = subscribers;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

            ViewBag.ActiveProfile = true;
            return View("Views/User/Subscribers.cshtml");





        }




        [HttpGet]
        [Route("/report/{id}")]
        public IActionResult ReportBook(int id,string redirect)
        {

            int userId = GetAuthId();

            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/report/"+id);
            }

            if(_paymentRepo.hasBook(userId,id))
            {
                if(_reportdRepo.GetAllReportsBySourceId(true,id).Where(report=> report.UserId==userId).Any())
                {
                    TempData["success"] = "You already reported";
                    return Redirect(redirect);
                }
                ViewBag.search = false;
                ViewBag.layoutName = "_LoginLayout.cshtml";
                ViewBag.style = "ReportStyle.css";
                ViewBag.type = "book";
                ViewBag.resourceId = id;
                ViewBag.message = false;
                ViewBag.ActiveProfile = true;
                ViewBag.redirect = redirect;
                ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

                return View("Views/User/Report.cshtml");

            }
            else
            {
                TempData["error"] = "Book is not enrolled";
                return Redirect(redirect);
            }
        }


        [HttpGet]
        [Route("/report/course/{id}")]
        public IActionResult ReportCourse(int id, string redirect)
        {

            int userId = GetAuthId();

            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/report/course/" + id);
            }

            if (_paymentRepo.hasCourse(userId, id))
            {
                if (_reportdRepo.GetAllReportsBySourceId(false, id).Where(report => report.UserId == userId).Any())
                {
                    TempData["success"] = "You already reported";
                    return Redirect(redirect);
                }
                ViewBag.search = false;
                ViewBag.layoutName = "_LoginLayout.cshtml";
                ViewBag.style = "ReportStyle.css";
                ViewBag.type = "course";
                ViewBag.resourceId = id;
                ViewBag.message = false;
                ViewBag.ActiveProfile = true;
                ViewBag.redirect = redirect;
                ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

                return View("Views/User/Report.cshtml");

            }
            else
            {
                TempData["error"] = "Course is not enrolled";
                return Redirect(redirect);
            }
        }




        [HttpPost]
        [Route("/report/{type}/{id}")]
        public IActionResult Report(string type,int id, string redirect,string subject,string description)
        {

            int userId = GetAuthId();

            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect="+redirect);
            }

            try
            {
                Report report = new Report();
                report.UserId = userId;
                report.ResourceId = id;
                report.IsBook = type == "book" ? true : false;
                report.Description = subject + " :: " + description;
                report.TimeStamp = DateTime.Now;

               int count = _reportdRepo.GetAllReportsBySourceId(report.IsBook, report.ResourceId).Count();

                if(count==4)
                {
                    if(type=="book")
                    {
                        
                        _bookRepo.DeleteBook(id);

                        Book book = _bookRepo.GetBookById(id);
                        SendNotification(book.Uploader, "Oops, Your book '" + book.Name + "'  is Deleted by the Admin based on user Reports. Please upload valid Books.");
                    }
                    else
                    {
                        _courseRepo.DeleteCourse(id);
                        Course course = _courseRepo.GetCourseById(id);
                        SendNotification(course.Uploader, "Oops, Your course '" + course.Name + "'  is Deleted by the Admin based on user Reports. Please upload valid Courses.");


                    }
                }
                else
                {
                    _reportdRepo.AddReport(report);
                }
               
                

                TempData["success"] = type+" has been reported";
                SendNotification(userId, "Awesome, "+type+" reported. Thanks for helping us to keep our platform clean.");

                return Redirect(redirect);

            }
            catch
            {
                TempData["error"] = "Unable to report "+type;
                return Redirect(redirect);
            }
        }



        [HttpGet]
        [Route("/ticket/{id}")]
        public IActionResult Ticket(int id, string redirect)
        {

            int userId = GetAuthId();

            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/ticket/" + id);
            }

           
                ViewBag.search = false;
                ViewBag.layoutName = "_LoginLayout.cshtml";
                ViewBag.style = "TicketStyle.css";
                ViewBag.resourceId = id;
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
                ViewBag.ActiveProfile = true;
                ViewBag.redirect = redirect;
                ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

            return View("Views/User/Ticket.cshtml");

           
        }


        [HttpPost]
        [Route("/ticket/{id}")]
        public async Task<IActionResult> TicketAsync(int id, string redirect,string description)
        {

            int userId = GetAuthId();


            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/ticket/" + id);
            }

            try
            {
                Ticket ticket = new Ticket();
                ticket.UserId = userId;
                ticket.BookId = id;
                
                ticket.TimeStamp = DateTime.Now;

               


                User user = await _userRepo.GetUserById(userId);

                
       
                     string ticketNumber= "INC" + DateTime.Now.Day.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Second.ToString()+user.Id.ToString();
                    ticket.Description ="new::"+ticketNumber+"::"+description;
                    await _ticketRepo.AddTicket(ticket);
                     SendNotification(userId, "Awesome,  We received your ticket "+ticketNumber+" . We will get back to you with a proper resolution.");

                string body = "<!DOCTYPE html><html lang='en'><head><meta charset='UTF-8'><meta http-equiv='X-UA-Compatible' content='IE=edge'><meta name='viewport' content='width=device-width, initial-scale=1.0'><title>OTP</title><link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css'><style> *{ margin:0px;padding:0px; box-sizing: border-box; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; }.heading{text-align: center;background:#5708be;padding:15px;color:#fff;} h1 i{color:#cecece;} p i{color:#4c04d3; } b{color:#7300d1;} .content{padding:20px;}</style></head><body><div class='heading'><h1><span><i class='fa fa-dice-d6'></i> </span>Read.me</h1></div><div class='content'><p>Hi " + user.Name + "</p><br><p>Your Ticket raised successfully with Reference ID <b>" + ticketNumber + "</b> to investigate on your issue. We will get back to you once we get the solution. Keep reading, stay safe.</p><br><p>Thanks and Regards</p><p><i class='fa fa-dice-d6'></i> Read.me</p></div></body></html>";
                Email.Send(user.Email, "Ticket Raised "+ticketNumber,body);
             
               

               
                

                TempData["success"] = "Ticket has been raised";
                return Redirect(redirect);

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                TempData["error"] = "Unable to raise ticket";
                return Redirect(redirect);
            }
        }

        [HttpGet]
        [Route("/notification")]
        public IActionResult Notification()
        {

            int userId = GetAuthId();

            if (userId < 0)
            {
                return Redirect("/login?redirect=/notification");
            }

            List<Notification> notifications = _notificationRepo.GetAllNotification(userId);
            notifications.Reverse();
            List<int> newNotificationsId = new List<int>();

            notifications.ForEach(notification => {
                if(notification.IsNew)
                {
                    newNotificationsId.Add(notification.Id);
                }
                });

            ViewBag.search = false;
            ViewBag.layoutName = "_LoginLayout.cshtml";
            ViewBag.style = "NotificationStyle.css";
            ViewBag.notifications = notifications;
            ViewBag.newNotificationsId = newNotificationsId;
            ViewBag.ActiveProfile = true;
            ViewBag.message=false;
            ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();


            _notificationRepo.MaskAsRead(userId);

            return View("Views/User/Notification.cshtml");


        }

        [HttpGet]
        [Route("/similar/{id}")]
        public IActionResult SimilarBook(int id)
        {
            Book book = _bookRepo.GetBookById(id);
            return Redirect("/?category=" + book.Category);
        }


        [HttpGet]
        [Route("/similar/free/{id}")]
        public IActionResult SimilarFree(int id)
        {
            Book book = _bookRepo.GetBookById(id);
            return Redirect("/free?category=" + book.Category);
        }

        [HttpGet]
        [Route("/similar/course/{id}")]
        public IActionResult SimilarCourse(int id)
        {
            Course course = _courseRepo.GetCourseById(id);
            return Redirect("/edu-hub?category=" + course.Category);
        }



        [HttpGet]
        [Route("/edit/book/free/{id}")]
        public IActionResult EditFreeBook(int id)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/upload/free");
            }


            Book targetBook = _bookRepo.GetBookById(id);
           if(targetBook.Uploader==GetAuthId())
           {
                List<Book> uploadedFreeBooks = _bookRepo.AllFreeBooks().Where(book => book.Uploader == GetAuthId()).ToList();
                ViewBag.uploadedFreeBooks = uploadedFreeBooks;

                List<Category> categories = _bookRepo.AllCategories();
                ViewBag.categories = categories;


                ViewBag.layoutName = "_LoginLayout.cshtml";
                ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

                ViewBag.style = "AL_uploadStyle.css";
                ViewBag.search = false;
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
                ViewBag.activeUpload = true;
                ViewBag.targetBook = targetBook;
                return View("Views/User/UploadFreeEdit.cshtml");
            }
           else
            {
                TempData["error"] = "Unauthorized access";
                return Redirect("/");
            }
            
           


           
        }




        [HttpGet]
        [Route("/edit/book/premium/{id}")]
        public IActionResult EditPremiumBook(int id)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/upload/premium");
            }
            Book targetBook = _bookRepo.GetBookById(id);


            if (targetBook.Uploader == GetAuthId())
            {
                List<Book> uploadedPremiumBooks = _bookRepo.AllPremiumBooks().Where(book => book.Uploader == GetAuthId()).ToList();
                ViewBag.uploadedPremiumBooks = uploadedPremiumBooks;

                List<Category> categories = _bookRepo.AllCategories();
                ViewBag.categories = categories;
                ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

                ViewBag.layoutName = "_LoginLayout.cshtml";

                ViewBag.style = "AL_uploadStyle.css";
                ViewBag.search = false;
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
                ViewBag.activeUpload = true;
                ViewBag.targetBook = targetBook;
                return View("Views/User/UploadPremiumEdit.cshtml");
            }
            else
            {
                TempData["error"] = "Unauthorized access";
                return Redirect("/");
            }


        }



        [HttpGet]
        [Route("/edit/course/{id}")]
        public IActionResult EditCourse(int id)
        {
            if (GetAuthId() < 0)
            {
                return Redirect("/login?redirect=/upload/course");
            }

            Course targetCourse = _courseRepo.GetCourseById(id);

            if (targetCourse.Uploader == GetAuthId())
            {
                List<Course> uploadedCourses = _courseRepo.AllCourses().Where(course => course.Uploader == GetAuthId()).ToList();
                ViewBag.uploadedCourses = uploadedCourses;

                List<Category> categories = _bookRepo.AllCategories();
                ViewBag.categories = categories;

                ViewBag.notificationCount = _notificationRepo.GetAllNotification(GetAuthId()).Where(notification => notification.IsNew == true).Count();

                ViewBag.layoutName = "_LoginLayout.cshtml";
                ViewBag.style = "AL_uploadStyle.css";
                ViewBag.search = false;
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
                ViewBag.activeUpload = true;
                ViewBag.targetCourse = targetCourse;
                return View("Views/User/UploadCourseEdit.cshtml");
            }
            else
            {
                TempData["error"] = "Unauthorized access";
                return Redirect("/");
            }

        }


        //-----------------------------------------------------------------------------------

        [Route("/edit/premium/{id}")]
        [HttpPost]
        public  IActionResult EditPremiumBook(BookData premiumBookData,int id,string redirect)
        {
            List<Category> categories = _bookRepo.AllCategories();

           

            try
            {
                string Thumbnailfolder = "Books/Thumbnail/";
                string BookPDFfolder = "Books/BookPDF/";

              



                Book book = _bookRepo.GetBookById(id);

                book.Name = premiumBookData.Name;
                book.Author = premiumBookData.Author;
                if(premiumBookData.Description?.Trim().Length >0 ) 
                {
                    book.Description = premiumBookData.Description;
                }

                
                book.Language = premiumBookData.Language;

                if (categories.Select(category => category.Name).Contains(premiumBookData.Category))
                {
                    book.Category = premiumBookData.Category;
                }
                book.Price = premiumBookData.Price;
             
                book.UploadTime = DateTime.Now;




                if (premiumBookData.ThumbnailFile?.FileName!= "HiddenValue.jpg" && premiumBookData.ThumbnailFile?.FileName !=null)
                {
                    Thumbnailfolder += "Thumbnail_" + GetAuthId() + "_" + Guid.NewGuid().ToString() + premiumBookData.ThumbnailFile.FileName;

                    book.ThumbnailPath = Thumbnailfolder;
                        Thumbnailfolder = Path.Combine(_webHostEvn.WebRootPath, Thumbnailfolder);
                        premiumBookData.ThumbnailFile.CopyTo(new FileStream(Thumbnailfolder, FileMode.Create));
                }

                if (premiumBookData.BookFile?.FileName != "HiddenValue.pdf" && premiumBookData.BookFile?.FileName != null)
                {
                    BookPDFfolder += "PremiumBook_" + GetAuthId() + "_" + Guid.NewGuid().ToString() + premiumBookData.BookFile.FileName;

                    book.FilePath = BookPDFfolder;
                    BookPDFfolder = Path.Combine(_webHostEvn.WebRootPath, BookPDFfolder);
                    premiumBookData.BookFile.CopyTo(new FileStream(BookPDFfolder, FileMode.Create));
                }


                _bookRepo.SaveChanges();



                TempData["success"] = "Book has been Edited";

                if (redirect != null)
                {
                    return Redirect(redirect);

                }


                return Redirect("/upload/premium");


            }
            catch
            {
              
                TempData["error"] = "Something went wrong";

                if (redirect != null)
                {
                    return Redirect(redirect);
                }

                return Redirect("/upload/premium");

            }

        }


        [Route("/edit/free/{id}")]
        [HttpPost]
        public IActionResult EditFreeBook(BookData freeBookData,int id, string redirect)
        {
            List<Category> categories = _bookRepo.AllCategories();

            try
            {
                string Thumbnailfolder = "Books/Thumbnail/";
                string BookPDFfolder = "Books/BookPDF/";




                Book book = _bookRepo.GetBookById(id);

                book.Name = freeBookData.Name;
                book.Author = freeBookData.Author;
                if (freeBookData.Description?.Trim().Length > 0)
                {
                    book.Description = freeBookData.Description;
                }
                book.Language = freeBookData.Language;

                if (categories.Select(category => category.Name).Contains(freeBookData.Category))
                {
                    book.Category = freeBookData.Category;
                }


                book.UploadTime = DateTime.Now;

                
               


                if (freeBookData.ThumbnailFile?.FileName != "HiddenValue.jpg" && freeBookData.ThumbnailFile?.FileName !=null)
                {
                    Thumbnailfolder += "Thumbnail_" + GetAuthId() + "_" + Guid.NewGuid().ToString() + freeBookData.ThumbnailFile.FileName;

                    book.ThumbnailPath = Thumbnailfolder;
                    Thumbnailfolder = Path.Combine(_webHostEvn.WebRootPath, Thumbnailfolder);
                    freeBookData.ThumbnailFile.CopyTo(new FileStream(Thumbnailfolder, FileMode.Create));

                }

                if (freeBookData.BookFile?.FileName != "HiddenValue.pdf" && freeBookData.BookFile?.FileName != null)
                {
                    BookPDFfolder += "FreeBook__" + GetAuthId() + "_" + Guid.NewGuid().ToString() + freeBookData.BookFile.FileName;

                    book.FilePath = BookPDFfolder;
                    BookPDFfolder = Path.Combine(_webHostEvn.WebRootPath, BookPDFfolder);
                    freeBookData.BookFile.CopyTo(new FileStream(BookPDFfolder, FileMode.Create));
                }




                _bookRepo.SaveChanges();

                TempData["success"] = "Book has been Edited";

                if (redirect != null)
                {
                    return Redirect(redirect);
                }

                return Redirect("/upload/free");
            }
            catch
            {
                TempData["error"] = "Something went wrong";

                if(redirect!=null)
                {
                    return Redirect(redirect);
                }
                return Redirect("/upload/free");
            }

        }



        [Route("/edit/course/{id}")]
        [HttpPost]
        public IActionResult EditCourse(CourseData courseData,int id, string redirect)
        {

            List<Category> categories = _bookRepo.AllCategories();


            try
            {
                string Thumbnailfolder = "Books/Thumbnail/";





                Course course = _courseRepo.GetCourseById(id);

                course.Name = courseData.Name;
                course.Source = courseData.Source;

                if (courseData.Description?.Trim().Length > 0)
                {
                    course.Description = courseData.Description;
                }

                course.Language = courseData.Language;

                if (categories.Select(category => category.Name).Contains(courseData.Category))
                {
                    course.Category = courseData.Category;
                }

                course.UploadTime = DateTime.Now;

                if (!courseData.URL.StartsWith("http"))
                {
                    course.URL = "https://" + courseData.URL;
                }
                else
                {
                    course.URL = courseData.URL;
                }

                if (courseData.ThumbnailFile?.FileName != "HiddenValue.jpg" && courseData.ThumbnailFile?.FileName !=null)
                {
                    Thumbnailfolder += "Thumbnail_" + GetAuthId() + "_" + Guid.NewGuid().ToString() + courseData.ThumbnailFile.FileName;

                    course.ThumbnailPath = Thumbnailfolder;
                    Thumbnailfolder = Path.Combine(_webHostEvn.WebRootPath, Thumbnailfolder);
                    courseData.ThumbnailFile.CopyTo(new FileStream(Thumbnailfolder, FileMode.Create));

                }



                _courseRepo.SaveChanges();

                TempData["success"] = "Course has been Edited";

                if(redirect!=null)
                {
                    return Redirect(redirect);
                }

                return Redirect("/upload/course");
            }
            catch 
            {
               
                TempData["error"] = "Something went wrong";
                if (redirect != null)
                {
                    return Redirect(redirect);
                }
                return Redirect("/upload/course");
            }

        }


        [Route("/delete/book/{id}")]
        [HttpGet]
        public IActionResult DeleteBook(int id)
        {
           if(GetAuthId()<0)
            {
                TempData["error"] = "Please Login";
                return Redirect("/login?redirect=/delete/book/"+id);
            }

            Book book = _bookRepo.GetBookById(id);

            if(book.Uploader==GetAuthId())
            {
                _bookRepo.DeleteBook(id);
                _bookRepo.SaveChanges();
                TempData["success"] = "Book Deleted";
                return Redirect("/upload");
            }
            else
            {
                TempData["error"] = "Unauthorized access";
                return Redirect("/upload");
            }
        }

        [Route("/delete/course/{id}")]
        [HttpGet]
        public IActionResult DeleteCourse(int id)
        {
            if (GetAuthId() < 0)
            {
                TempData["error"] = "Please Login";
                return Redirect("/login?redirect=/delete/course/" + id);
            }

            Course course = _courseRepo.GetCourseById(id);

            if (course.Uploader == GetAuthId())
            {
                _courseRepo.DeleteCourse(id);
                _courseRepo.SaveChanges();
                TempData["success"] = "Course Deleted";
                return Redirect("/upload");
            }
            else
            {
                TempData["error"] = "Unauthorized access";
                return Redirect("/upload");
            }
        }


        private void SendNotification(int to, string description)
        {
            Notification notification = new Notification();
            notification.IsNew = true;
            notification.UserId = to;
            notification.Description = description;
            notification.TimeStamp = DateTime.Now;

            try
            {
               
                _notificationRepo.Notify(notification);
            }
            catch
            {
               try
                {
                     
                    _notificationRepo.Notify(notification);
                }
                catch
                {
                   
                }
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