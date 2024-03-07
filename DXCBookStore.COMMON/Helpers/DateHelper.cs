using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Helpers
{
    public static class DateHelper
    {
        public static string[] months = DateTimeFormatInfo.CurrentInfo.MonthNames;
        public static List<ReportReponseModel> ToFullMonth(this IEnumerable<ReportReponseModel> items)
        {
            var reportFullMonths = new List<ReportReponseModel>();
            var result = items.ToList();

            for (int i = 0; i < months.Length -1; i++)
            {
                var reportReponseModel = new ReportReponseModel();
                reportReponseModel.Total = 0;
                reportReponseModel.Title = months[i];
                foreach (var item in result)
                {
                    if(int.Parse(item.Title) == i +1)
                    {
                        reportReponseModel.Total = item.Total; 
                        break;
                    }
                }

                reportFullMonths.Add(reportReponseModel);
            }
            return reportFullMonths;
        }

        public static List<ReportReponseModel> ToFullDate(this IEnumerable<ReportReponseModel> items, string sDate, string eDate)
        {
            DateTime startDate;
            DateTime endDate;
            if (DateTime.TryParseExact(sDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out startDate))
            {
                if (DateTime.TryParseExact(eDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out endDate))
                {
                    var fullDates = GetDateRange(startDate, endDate);
                    var result = new List<ReportReponseModel>();
                    for (int i = 0; i < fullDates.Length; i++)
                    {
                        var item = new ReportReponseModel();
                        item.Title = fullDates[i].ToString();
                        item.Total = 0;

                        foreach (var report in items)
                        {
                            DateTime dateInResult;

                            if (DateTime.TryParseExact(report.Title, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateInResult))
                            {
                                if (DateTime.Compare(fullDates[i].Date, dateInResult) == 0)
                                {
                                    item.Total = report.Total;
                                    break;
                                }
                            }
                        }
                        result.Add(item);
                    }
                    return result;
                }
            }

            return null;
        }

        static DateTime[] GetDateRange(DateTime startDate, DateTime endDate)
        {
            int totalDays = (int)(endDate - startDate).TotalDays + 1;
            DateTime[] dateArray = new DateTime[totalDays];

            for (int i = 0; i < totalDays; i++)
            {
                dateArray[i] = startDate.AddDays(i);
            }

            return dateArray;
        }
    }
}
