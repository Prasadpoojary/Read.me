using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public interface IAdminRepo
    {
        public bool AddMoney(long amount);

        public bool DeductMoney(long amount);

        public bool AddAdmin(Admin admin);
        public Admin GetAdmin(int adminId);
        public List<Admin> GetAllAdmins();

    }
}
