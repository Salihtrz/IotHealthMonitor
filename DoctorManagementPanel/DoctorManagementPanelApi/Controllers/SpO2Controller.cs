using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.SpO2Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpO2Controller : ControllerBase
    {
        private readonly ISpO2Service _spO2Service;
        private readonly IMapper _mapper;

        public SpO2Controller(ISpO2Service spO2Service, IMapper mapper)
        {
            _spO2Service = spO2Service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListSpO2WithPatientName()
        {
            var values = _spO2Service.TGetSpO2WithPatientName();
            return Ok(_mapper.Map<List<ResultSpO2Dto>>(values));
        }
        [HttpGet("{id}")]
        public IActionResult GetSpO2ByDeviceID(int id)
        {
            var values = _spO2Service.TGetSpO2ByDeviceID(id);
            return Ok(values);
        }
    }
}
