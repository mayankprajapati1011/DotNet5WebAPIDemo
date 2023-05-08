using BusinessLayer.Dtos;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IReportRepository
    {
         Task<ReportZoneWiseBinCollectionResponse> ZoneWiseBinCollection(ReportZoneWiseBinCollectionRequest zoneWiseBinCollectionRequest);
    }
}
