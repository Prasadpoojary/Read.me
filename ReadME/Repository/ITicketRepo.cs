using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public interface ITicketRepo
    {
        public List<Ticket> GetAllTickets();
        public List<Ticket> GetAllTicketBySourceId(int bookId);

        public Task<bool> AddTicket(Ticket ticket);

    


    }
}
