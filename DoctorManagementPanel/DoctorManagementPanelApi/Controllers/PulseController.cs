using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.Dtos.PulseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorManagementPanelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PulseController : ControllerBase
    {
        private readonly IPulseService _pulseService;
        private readonly IMapper _mapper;
        public PulseController(IPulseService pulseService, IMapper mapper)
        {
            _pulseService = pulseService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListPulseWithPatientName()
        {
            var values = _pulseService.TGetPulsesWithPatientName();
            return Ok(_mapper.Map<List<ResultPulseDto>>(values));
        }
        [HttpGet("{id}")]
        public IActionResult GetPulseByDeviceID(int id)
        {
            var values = _pulseService.TGetPulsesByDeviceID(id);
            return Ok(values);
        }
    }
}
