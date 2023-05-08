using BusinessLayer.Data;
using BusinessLayer.Dtos;
using BusinessLayer.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class ReportRepository : IReportRepository, IDisposable
    {
        private DataContext _context;
        public ReportRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ReportZoneWiseBinCollectionResponse> ZoneWiseBinCollection(ReportZoneWiseBinCollectionRequest zoneWiseBinCollectionRequest)
        {
            var parameterTotalRecordCount = new SqlParameter
            {
                ParameterName = "@TotalRecords",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output,
            };

            ReportZoneWiseBinCollectionResponse zoneWiseBinCollectionResponse = new ReportZoneWiseBinCollectionResponse();

            SqlParameter[] sqlParameter =
            {
                 new SqlParameter { ParameterName = "@fromDate",Value = zoneWiseBinCollectionRequest.FromDate}
                ,new SqlParameter { ParameterName = "@toDate",Value = zoneWiseBinCollectionRequest.ToDate}

                ,new SqlParameter { ParameterName = "@zoneId",Value = zoneWiseBinCollectionRequest.ZoneId}
                ,new SqlParameter { ParameterName = "@areaId",Value = zoneWiseBinCollectionRequest.AreaId}
                ,new SqlParameter { ParameterName = "@SoceityId",Value = zoneWiseBinCollectionRequest.SocietyId}

                //Paging Parameters
                ,new SqlParameter { ParameterName = "@PageNumber",Value = zoneWiseBinCollectionRequest.PageNumber}
                ,new SqlParameter { ParameterName = "@PageSize",Value = zoneWiseBinCollectionRequest.PageSize}
                ,new SqlParameter { ParameterName = "@SearchTerm",Value = zoneWiseBinCollectionRequest.SearchTerm ?? string.Empty}
                ,new SqlParameter { ParameterName = "@SortingBy",Value = zoneWiseBinCollectionRequest.SortingBy ?? string.Empty}
                ,new SqlParameter { ParameterName = "@SortingDirection",Value = zoneWiseBinCollectionRequest.SortingDirection ?? string.Empty}
                ,parameterTotalRecordCount
            };

            zoneWiseBinCollectionResponse.ZoneWiseBinCollection = await _context.Set<ZoneWiseBinCollectionReport>().FromSqlRaw("EXEC GetReport @fromDate,@toDate,@zoneId,@areaId,@soceityId,@PageNumber,@PageSize,@SearchTerm,@SortingBy,@SortingDirection,@TotalRecords OUTPUT", sqlParameter).ToListAsync();
            zoneWiseBinCollectionResponse.TotalRecords = Convert.ToInt32(parameterTotalRecordCount.Value);
            return zoneWiseBinCollectionResponse;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;
            _context.Dispose();
            _context = null;
        }
    }
}
