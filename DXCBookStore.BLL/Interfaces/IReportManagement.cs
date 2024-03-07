using DXCBookStore.COMMON.Models.RequestModels;
using DXCBookStore.COMMON.Models.ResponseModels;

namespace DXCBookStore.BLL.Interfaces
{
    public interface IReportManagement
    {
        public Task<IEnumerable<ReportReponseModel>> getAllReportByBrand(ReportRequestItem report);
        public Task<IEnumerable<ReportReponseModel>> getRevenueReportByPublisherId(RevenueReportRequest report);

        public Task<IEnumerable<ReportReponseModel>> getRevenueReportByDateRange(DateRangeRequestModel item);

    }
}
