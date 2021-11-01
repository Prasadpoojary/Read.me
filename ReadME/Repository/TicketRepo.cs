using ReadME.Database;
using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public class TicketRepo : ITicketRepo
    {


        private readonly DataContext _dataContext;

        public TicketRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddTicket(Ticket ticket)
        {
          
              await _dataContext.Tickets.AddAsync(ticket);
              return true;
           
        }

      

     

        public List<Ticket> GetAllTicketBySourceId(int bookId)
        {
            return _dataContext.Tickets.Where(ticket =>ticket.BookId == bookId).ToList();
        }

        public List<Ticket> GetAllTickets()
        {
            return _dataContext.Tickets.ToList();
        }

     
    }
}
