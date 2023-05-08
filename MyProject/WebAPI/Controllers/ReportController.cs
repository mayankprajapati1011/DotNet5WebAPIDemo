using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.IRepository;
using BusinessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ReportController : BaseApiController
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;
        public ReportController(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        [HttpGet("ZoneWiseBinCollection")]
        public async Task<ActionResult<IEnumerable<ZoneWiseBinCollectionReport>>> ZoneWiseBinCollection([FromQuery] ReportZoneWiseBinCollectionRequest zoneWiseBinCollectionRequest)
        {
            var zoneWiseBinCollectionDetailsFromRepo = await _reportRepository.ZoneWiseBinCollection(zoneWiseBinCollectionRequest);
            return Ok(zoneWiseBinCollectionDetailsFromRepo);
        }

    }
}

