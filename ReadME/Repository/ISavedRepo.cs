using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public interface ISavedRepo
    {
        public bool Save(Saved saved);
        public bool isSaved(int userId, int sourceId, string type);
        public List<Saved> AllSaved(int userId,string type);
        public List<int> AllSavedId(int userId, string type);
        public bool Unsave(int userId, int sourceId, string type);
    }
}
