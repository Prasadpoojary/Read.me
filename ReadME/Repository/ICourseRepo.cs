using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public interface ICourseRepo
    {
        public void SaveChanges();
        Task<bool> AddCourse(Course course);

        bool DeleteCourse(int id);
        

        List<Course> AllCourses();

        List<Course> TopThreeCourses(int userId);

        Course GetCourseById(int id);

        List<Course> GetSuggestionsById(int userId);

         List<string> AllExistingCategoriesCourse();
    }
}
