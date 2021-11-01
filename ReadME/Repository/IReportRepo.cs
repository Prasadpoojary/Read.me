using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public interface IReportRepo
    {
        public List<Report> GetAllReports();
        public List<Report> GetAllReportsBySourceId(bool isBook,int sourceId);

        public bool AddReport(Report report);

        

    }
}
