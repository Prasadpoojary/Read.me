using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public interface ISpecificationRepo
    {
      
        long GetSubscriberCountById(int id);

        List<User> AllSubscribers(int uploaderId);

        bool IsSubscribed(int userId, int uploaderId);

        bool Unsubscribe(int userId, int uploaderId);

        bool Subscribe(int userId, int uploaderId);


        bool IsLikedOnCourse(int userId, int courseId);

     

        bool IsLikedOnBook(int userId, int bookId);

        bool IsCommentedOnCourse(int userId, int courseId);



        bool IsCommentedOnBook(int userId, int bookId);


        public bool AddComment(Comment comment);

        public bool DisLike(Like like);

        public bool AddLike(Like like);


        public bool DeleteComment(int id);

        List<Comment> AllCommentsOfBook(int id);

        List<Comment> AllCommentsOfCourse(int id);


        List<int> AllLikesOfBook(int id);

        List<int> AllLikesOfCourse(int id);

        public Like GetBookLike(int userId, int bookId);
        public Like GetCourseLike(int userId, int courseId);



    }
}
