using System;
using System.Collections.Generic;

namespace BusinessLayer.Dtos
{
    public class ReportZoneWiseBinCollectionRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int ZoneId { get; set; }
        public int AreaId { get; set; }
        public int SocietyId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }
        public string SortingBy { get; set; }
        public string SortingDirection { get; set; }
    }
    public  class ReportZoneWiseBinCollectionResponse
    {
        public IEnumerable<ZoneWiseBinCollectionReport> ZoneWiseBinCollection { get; set; }
        public int TotalRecords { get; set; }
    }
    public class ZoneWiseBinCollectionReport
    {
        public DateTime CollectionDate { get; set; }
        public string BinName { get; set; }
        public string BinTypeName { get; set; }
        public string ZoneName { get; set; }
        public string AreaName { get; set; }
        public string SocietyName { get; set; }
    }
}
