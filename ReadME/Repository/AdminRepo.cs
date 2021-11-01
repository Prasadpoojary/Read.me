using ReadME.Database;
using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public class AdminRepo : IAdminRepo
    {
        private readonly DataContext _dataContext;

        public bool AddAdmin(Admin admin)
        {
            _dataContext.Add(admin);
            _dataContext.SaveChanges();
            return true;
        }

        

        public Admin GetAdmin(int adminId)
        {
            Admin admin = _dataContext.Admins.Where(admin => admin.Id == adminId).Any() ? _dataContext.Admins.Where(admin => admin.Id == adminId).Single() : null;
           
            return admin;
        }


        public List<Admin> GetAllAdmins()
        {
            List<Admin> admins = _dataContext.Admins.ToList() ;
            return admins;
        }

        public AdminRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool AddMoney(long amount)
        {
            try
            {
                Admin admin = _dataContext.Admins.Where(admin => admin.isSuperuser == true).Any() ? _dataContext.Admins.Where(admin => admin.isSuperuser == true).Single() : null;
                if (admin == null)
                {
                    Admin superuser = new Admin();
                    superuser.Name = "ReadmeLeader";
                    superuser.email = "readme.udupi@gmail.com";
                    superuser.password = "Readme123@";
                    superuser.isSuperuser = true;
                    superuser.earning = amount;
                    superuser.access_book = true;
                    superuser.access_comment = true;
                    superuser.access_course = true;
                    superuser.access_payment = true;
                    superuser.access_report = true;
                    superuser.access_subscriber = true;
                    superuser.access_ticket = true;
                    superuser.access_user = true;

                    _dataContext.Admins.Add(superuser);
                }
                else
                {
                    admin.earning += amount;
                    _dataContext.SaveChanges();
                }

                return true;
            }
            catch
            {
              
                return false;
            }
           

            
        }

        public bool DeductMoney(long amount)
        {
            try
            {
                Admin admin = _dataContext.Admins.Where(admin => admin.isSuperuser == true).Single();
              
                admin.earning -= amount;
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
