using ReadME.Database;
using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public class SavedRepo : ISavedRepo
    {
        private readonly DataContext _dataContext;

        public SavedRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Saved> AllSaved(int userId, string type)
        {
            bool isBook = type == "book" ? true : false;
            return _dataContext.Saved.Where(saved => saved.UserId == userId && saved.isBook == isBook).ToList();
        }

        public List<int> AllSavedId(int userId, string type)
        {
            bool isBook = type == "book" ? true : false;
            List<int> result = new List<int>();
            List<Saved> allSavedBook= _dataContext.Saved.Where(saved => saved.UserId == userId && saved.isBook == isBook).ToList();
            foreach(Saved saved in allSavedBook)
            {
                result.Add(saved.SourceId);
            }

            return result;
        }

        public bool isSaved(int userId, int sourceId, string type)
        {
            bool isBook = type == "book" ? true : false;
            return _dataContext.Saved.Where(saved => saved.UserId == userId && saved.isBook == isBook && saved.SourceId==sourceId).Any();

        }

        public bool Save(Saved saved)
        {
            try
            {
                _dataContext.Saved.Add(saved);
                _dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Unsave(int userId, int sourceId, string type)
        {
            try
            {
                bool isBook = type == "book" ? true : false;
                _dataContext.Saved.Remove(_dataContext.Saved.Where(saved => saved.UserId == userId && saved.isBook == isBook && saved.SourceId == sourceId).Single());
                _dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           

        }
    }
}
