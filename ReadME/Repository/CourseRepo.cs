using ReadME.Database;
using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public class CourseRepo : ICourseRepo
    {
     
        private readonly DataContext _dataContext;

        public CourseRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public async Task<bool> AddCourse(Course course)
        {
            await _dataContext.Courses.AddAsync(course);
            _dataContext.SaveChanges();
            return true;
        }

        public bool DeleteCourse(int id)
        {

            if (_dataContext.Payments.Where(payment => payment.SourceId == id).Any())
            {
                Course course = GetCourseById(id);
                course.IsActive = false;
                _dataContext.SaveChanges();
                return true;
            }
            _dataContext.Courses.Remove(_dataContext.Courses.Where(course => course.Id == id).Single());
            return true;
        }

        public List<Course> AllCourses()
        {
            return _dataContext.Courses.Where(course => course.IsActive == true).ToList();
        }

        public Course GetCourseById(int id)
        {
            return _dataContext.Courses.Where(course => course.Id == id).Single();
        }

        public List<Course> TopThreeCourses(int userId)
        {
            return _dataContext.Courses.Where(course=> course.IsActive==true && course.Uploader != userId).OrderByDescending(course=>course.Likes).Take(3).ToList();
        }


        public List<Course> GetSuggestionsById(int userId)
        {
            List<Course> result = new List<Course>();
            User user = _dataContext.Users.Where(user => user.Id == userId).Single();
            if (user.Suggestions != null)
            {
                string[] interests = user.Suggestions.Split(";");
                foreach (string interest in interests)
                {
                    Course topitem = this.GetTopItem(interest, userId);
                    if (topitem != null)
                    {
                        result.Add(topitem);
                    }
                }

            }


            return result;
        }

        private Course GetTopItem(string category,int userId)
        {
            List<Course> courses = _dataContext.Courses.Where(course => course.IsActive == true && course.Uploader != userId && course.Category.ToLower() == category.ToLower()).ToList();
            if (courses != null && courses.Count() > 0)
            {
                return courses.OrderByDescending(course => course.Likes).FirstOrDefault();
            }

            return null;
        }



        public List<string> AllExistingCategoriesCourse()
        {
            List<string> result = _dataContext.Courses.Where(course=>course.IsActive == true).Select(course => course.Category).Distinct().ToList();
            return result;
        }

    }
}
