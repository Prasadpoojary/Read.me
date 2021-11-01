using ReadME.Database;
using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public class BookRepo : IBookRepo
    {
        private readonly DataContext _dataContext;

        public BookRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public List<Book> AllBooks()
        {
            return _dataContext.Books.ToList();
        }


        public async Task<bool> AddBook(Book book)
        {
            await _dataContext.Books.AddAsync(book);
            _dataContext.SaveChanges();
            return true;
        }

        public bool DeleteBook(int id)
        {
            if(_dataContext.Payments.Where(payment=>payment.SourceId==id).Any())
            {
                Book book= GetBookById(id);
                book.IsActive = false;
                _dataContext.SaveChanges();
                return true;
            }

            _dataContext.Books.Remove(_dataContext.Books.Where(book=>book.Id==id).Single());
            return true;
        }

        public List<Book> AllPremiumBooks()
        {
            return _dataContext.Books.Where(book => book.IsActive==true && book.IsPremium == true).ToList();
                 // select * from Books where IsActive='1' and IsPremium='1';
        }

        public List<Book> TopThreePremiumBooks(int userId)
        {
            return _dataContext.Books.Where(book => book.IsActive == true &&  book.Uploader!=userId && book.IsPremium==true).OrderByDescending(book => book.Likes).Take(3).ToList();
        }

        public List<Book> AllFreeBooks()
        {
            return _dataContext.Books.Where(book => book.IsActive == true && book.IsPremium == false).ToList();
        }

        public List<Book> TopThreeFreeBooks(int userId)
        {
            return _dataContext.Books.Where(book => book.IsActive == true && book.Uploader!=userId && book.IsPremium==false).OrderByDescending(book => book.Likes).Take(3).ToList();
        }

        public Book GetBookById(int id)
        {
            return _dataContext.Books.Where(book => book.Id == id).Single();
        }


        public List<Book> GetSuggestionsById(int userId)
        {
            List<Book> result = new List<Book>();
            User user = _dataContext.Users.Where(user => user.Id == userId).Single();
                       
            if(user.Suggestions!=null)
            {
                                
                string[] interests = user.Suggestions.Split(";");
              
                foreach (string interest in interests)
                {
                    Book topitem = this.GetTopItem(interest, userId);
                    if(topitem!=null)
                    {
                        result.Add(topitem);
                    }
                    
                }

            }


            return result;
        }

        private Book GetTopItem(string category,int userId)
        {
            List<Book> books = _dataContext.Books.Where(book => book.IsActive == true && book.Uploader != userId && book.Category.ToLower() == category.ToLower()).ToList();
            if(books!=null && books.Count() >0)
            {
                return books.OrderByDescending(book => book.Likes).FirstOrDefault();
            }
            
            return null;
        }

        public List<string> AllExistingCategoriesPremium()
        {
            List<string> result = _dataContext.Books.Where(book => book.IsPremium == true && book.IsActive == true).Select(book => book.Category).Distinct().ToList() ; 
            return result;
        }

        public List<string> AllExistingCategoriesFree()
        {
            List<string> result = _dataContext.Books.Where(book => book.IsPremium == false && book.IsActive == true).Select(book => book.Category).Distinct().ToList(); 
            return result;
        }


        public List<Category> AllCategories()
        {
            return _dataContext.Categories.ToList();
        }

        public bool AddCategory(string categoryName)
        {
            try
            {
                Category category = new Category();
                category.Name = categoryName;
                _dataContext.Add(category);

                return true;
            }
            catch
            {
                return false;
            }
         
            
        }

        public bool RemoveCategory(string category)
        {
            try
            {
                _dataContext.Categories.Remove(_dataContext.Categories.Where(cat => cat.Name == category).Single());

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
