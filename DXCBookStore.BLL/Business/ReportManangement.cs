using DXCBookStore.BLL.Interfaces;
using DXCBookStore.BLL.Mapper;
using DXCBookStore.COMMON.Helpers;
using DXCBookStore.COMMON.Models.RequestModels;
using DXCBookStore.COMMON.Models.ResponseModels;
using DXCBookStore.DAL.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

namespace DXCBookStore.BLL.Business
{
    public class ReportManangement : IReportManagement
    {
        private readonly DataContext _db;
        public ReportManangement(DataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ReportReponseModel>> getRevenueReportByDateRange(DateRangeRequestModel item)
        {
            DateTime startDate;
            DateTime endDate;
            if (DateTime.TryParseExact(item.StartDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out startDate))
            {
                if (DateTime.TryParseExact(item.EndDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out endDate))
                {
                    return await _db.ReportResponseModels.FromSqlRaw($"sp_getRevenueReportByDateRange '{item.PublisherId}', '{startDate}', '{endDate}' ").ToListAsync();
                }
                else
                {
                    Debug.WriteLine("Parse fail");
                }
            }
            else
            {
                Debug.WriteLine("Parse fail");

            }
            return null;

        }

        async Task<IEnumerable<ReportReponseModel>> IReportManagement.getAllReportByBrand(ReportRequestItem report)
        {
            return await _db.ReportResponseModels.FromSqlRaw($"sp_DrillDownBrandReport '{report.option1}', '{report.option2}' ").ToListAsync();
        }

        async Task<IEnumerable<ReportReponseModel>> IReportManagement.getRevenueReportByPublisherId(RevenueReportRequest item)
        {
            try
            {
                var result = await _db.ReportResponseModels.FromSqlRaw($"sp_PublisherRevenueReport '{item.PublisherId}', '{item.Year}' ").ToListAsync();
                return result.ToFullMonth();
            }
            catch (SystemException e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }
    }
}
