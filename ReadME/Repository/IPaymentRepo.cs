using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public interface IPaymentRepo
    {
        public Task<bool> Payment(Payment payment);

        public bool hasBook(int userId, int bookId);

        public bool hasCourse(int userId, int courseId);
        public List<Payment> GetPaymentByUser(int id);

        public List<int> GetFreeBookIdByUser(int id);

        public List<int> GetPremiumBookIdByUser(int id);
        public List<int> GetCoursedByUser(int id);

    }
}
