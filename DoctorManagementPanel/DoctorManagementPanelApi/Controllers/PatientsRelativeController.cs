using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.PatientsRelativeDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsRelativeController : ControllerBase
    {
        private readonly IPatientsRelativeService _patientsRelativeService;
        private readonly IMapper _mapper;

        public PatientsRelativeController(IPatientsRelativeService patientsRelativeService, IMapper mapper)
        {
            _patientsRelativeService = patientsRelativeService;
            _mapper = mapper;
        }
        [HttpGet("GetPatientsRelativeIDByAppUserID/{id}")]
        public IActionResult GetPatientsRelativeIDByAppUserID(int id)
        {
            var value = _patientsRelativeService.TGetPatientsRelativeIDByAppUserID(id);
            return Ok(_mapper.Map<ResultPatientsRelativeDto>(value));
        }
    }
}
