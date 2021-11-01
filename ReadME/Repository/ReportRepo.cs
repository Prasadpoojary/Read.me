using ReadME.Database;
using ReadME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Repository
{
    public class ReportRepo : IReportRepo
    {


        private readonly DataContext _dataContext;

        public ReportRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool AddReport(Report report)
        {
            try
            {
                _dataContext.Reports.Add(report);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Report> GetAllReports()
        {
            return _dataContext.Reports.ToList();
        }

        public List<Report> GetAllReportsBySourceId(bool isBook, int sourceId)
        {
            return _dataContext.Reports.Where(report => report.IsBook == isBook && report.ResourceId == sourceId).ToList();
        }
    }
}
