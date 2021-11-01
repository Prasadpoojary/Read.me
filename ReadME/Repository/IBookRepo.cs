using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public interface IBookRepo
    {

        public void SaveChanges();
        
        Task<bool> AddBook(Book book);

        List<Book> AllBooks();

        bool DeleteBook(int id);

        List<Category> AllCategories();

        bool AddCategory(string category);

        bool RemoveCategory(string category);

        List<Book> AllPremiumBooks();

        List<Book> TopThreePremiumBooks(int userId);

        List<Book> AllFreeBooks();

        List<Book> TopThreeFreeBooks(int userId);

        Book GetBookById(int id);

        List<Book> GetSuggestionsById(int userId);

         List<string> AllExistingCategoriesPremium();

        List<string> AllExistingCategoriesFree();



    }
}
