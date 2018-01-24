using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoSerbisyo.Models;

namespace GoSerbisyo.AppServices
{
    public interface IServiceReportsAppService
    {
        List<ReportModel> GetServiceReports(int ServiceId);
        ReportModel GetServiceReport(int ReportId);
        void UpsertServiceReport(ReportModel input);
        void RemoveServiceReport(int ReportId);
    }
}
