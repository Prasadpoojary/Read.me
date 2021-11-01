using ReadME.Database;
using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ReadME.Repository
{
    public class SpecificationRepo : ISpecificationRepo
    {


        private readonly DataContext _dataContext;

        public SpecificationRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

       

        public long GetSubscriberCountById(int id)
        {
            return _dataContext.Subscriptions.Where(subscription => subscription.UploaderId == id).Count();
        }

        public  bool IsSubscribed(int userId, int uploaderId)
        {
            return _dataContext.Subscriptions.Where(subscription => subscription.UploaderId == uploaderId && subscription.UserId == userId).Any();

        }


        public bool IsLikedOnBook(int userId, int bookId)
        {
            return _dataContext.Likes.Where(like => like.ResourceId == bookId && like.IsBook == true && like.UserId == userId).Any();
        }



      

        public bool IsLikedOnCourse(int userId, int courseId)
        {
            return _dataContext.Likes.Where(like => like.ResourceId == courseId && like.IsBook == false && like.UserId == userId).Any();
        }



        public bool IsCommentedOnBook(int userId, int bookId)
        {
            return _dataContext.Comments.Where(comment => comment.ResourceId == bookId && comment.IsBook == true && comment.UserId == userId).Any();
        }





        public bool IsCommentedOnCourse(int userId, int courseId)
        {
            return _dataContext.Comments.Where(comment => comment.ResourceId == courseId && comment.IsBook == false && comment.UserId == userId).Any();
        }


        public bool AddLike(Like like)
        {
            _dataContext.Likes.Add(like);
            _dataContext.SaveChanges();
            return true;
        }

        public bool DisLike(Like like)
        {
            _dataContext.Likes.Remove(like);
            _dataContext.SaveChanges();
            return true;
        }

        public bool AddComment(Comment comment)
        {
            _dataContext.Comments.Add(comment);
            _dataContext.SaveChanges();
            return true;
        }

        public bool DeleteComment(int id)
        {
            _dataContext.Comments.Remove(_dataContext.Comments.Where(comment => comment.Id == id).Single());
            _dataContext.SaveChanges();
            return true;
        }


         

        public List<Comment> AllCommentsOfBook(int id)
        {
            return _dataContext.Comments.Where(comment => comment.IsBook == true && comment.ResourceId == id).ToList();
        }

        public List<Comment> AllCommentsOfCourse(int id)
        {
            return _dataContext.Comments.Where(comment => comment.IsBook == false && comment.ResourceId == id).ToList();
        }


        public List<int> AllLikesOfBook(int userId)
        {
            List<int> result = new List<int>();
            List<Like> likes=_dataContext.Likes.Where(like => like.IsBook == true && like.UserId==userId).ToList();
            
            foreach(Like like in likes)
            {
                result.Add(like.ResourceId);
            }

            return result;
        
        }

        public List<int> AllLikesOfCourse(int userId)
        {
            List<int> result = new List<int>();
            List<Like> likes = _dataContext.Likes.Where(like => like.IsBook == false && like.UserId == userId).ToList();

            foreach (Like like in likes)
            {
                result.Add(like.ResourceId);
            }

            return result;
        }


        public Like GetBookLike(int userId,int bookId)
        {
            return _dataContext.Likes.Where(like => like.ResourceId == bookId && like.IsBook == true && like.UserId == userId).Single();

        }

        public Like GetCourseLike(int userId, int courseId)
        {
            return _dataContext.Likes.Where(like => like.ResourceId == courseId && like.IsBook == false && like.UserId == userId).Single();

        }



        public bool Unsubscribe(int userId, int uploaderId)
        {
            try
            {
                _dataContext.Subscriptions.Remove(_dataContext.Subscriptions.Where(subscription => subscription.UserId == userId && subscription.UploaderId == uploaderId).Single());
                _dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Subscribe(int userId, int uploaderId)
        {
            try
            {

                Subscription subscription = new Subscription();
                subscription.UserId = userId;
                subscription.UploaderId = uploaderId;
                subscription.TimeStamp = DateTime.Now;
                _dataContext.Subscriptions.Add(subscription);
                _dataContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<User> AllSubscribers(int userId)
        {
            List<User> result = new List<User>();
            List<Subscription> subscriptions = _dataContext.Subscriptions.Where(subscription => subscription.UploaderId == userId).ToList();
            foreach(Subscription subscription in subscriptions)
            {
                User user = _dataContext.Users.Where(user => user.Id == subscription.UserId).Single();
                result.Add(user);
            }

            return result;
        
        }
    }
}
