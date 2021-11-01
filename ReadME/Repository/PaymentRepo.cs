using ReadME.Database;
using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public class PaymentRepo : IPaymentRepo
    {

        private readonly DataContext _dataContext;

        public PaymentRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool hasBook(int userId, int SourceId)
        {
            return _dataContext.Payments.Where(payment => payment.UserId == userId && payment.SourceId == SourceId && payment.Source!="Course").Any();
        }

        public bool hasCourse(int userId, int courseId)
        {
            return _dataContext.Payments.Where(payment => payment.UserId == userId && payment.SourceId == courseId && payment.Source=="Course").Any();
        }

        public async Task<bool> Payment(Payment payment)
        {
            await _dataContext.Payments.AddAsync(payment);
            _dataContext.SaveChanges();
            return true;
        }

        public List<Payment> GetPaymentByUser(int id)
        {
            return _dataContext.Payments.Where(payment => payment.UserId == id).ToList();
        }

        public List<int> GetFreeBookIdByUser(int id)
        {
            List<int> result = new List<int>();
            foreach(Payment enrols in _dataContext.Payments.Where(payment => payment.UserId == id && payment.Source=="Free").ToList())
            {
                result.Add(enrols.SourceId);
            }
            return result;
        }


        public List<int> GetPremiumBookIdByUser(int id)
        {
            List<int> result = new List<int>();
            foreach (Payment enrols in _dataContext.Payments.Where(payment => payment.UserId == id && payment.Source != "Free" && payment.Source!="Course").ToList())
            {
                result.Add(enrols.SourceId);
            }
            return result;
        }

        public List<int> GetCoursedByUser(int id)
        {
            List<int> result = new List<int>();
            foreach (Payment enrols in _dataContext.Payments.Where(payment => payment.UserId == id && payment.Source == "Course").ToList())
            {
                result.Add(enrols.SourceId);
            }
            return result;
        }




    }
}
