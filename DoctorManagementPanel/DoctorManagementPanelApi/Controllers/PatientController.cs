using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.PatientDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListPatient()
        {
            var values = _patientService.TGetAll();
            return Ok(_mapper.Map<List<ResultPatientDto>>(values));
        }
        [HttpGet("getPatientsWithStatusTrue")]
        public IActionResult getPatientsWithStatusTrue()
        {
            var values = _patientService.TgetPatientsWithStatusTrue();
            return Ok(_mapper.Map<List<ResultPatientDto>>(values));
        }
        [HttpGet("changePatientStatusToFalse")]
        public IActionResult changePatientStatusToFalse(int id)
        {
            _patientService.TchangePatientStatusToFalse(id);
            return Ok();
        }
        [HttpGet("PatientCountByStatusTrue")]
        public IActionResult PatientCountByStatusTrue()
        {
            var value = _patientService.TPatientCountByStatusTrue();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreatePatient(CreatePatientDto createPatientDto)
        {
            var value = _mapper.Map<Patient>(createPatientDto);
            _patientService.TAdd(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdatePatient(UpdatePatientDto updatePatientDto)
        {
            var value = _mapper.Map<Patient>(updatePatientDto);
            _patientService.TUpdate(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetPatient(int id)
        {
            var value = _patientService.TGetByID(id);
            return Ok(_mapper.Map<GetPatientDto>(value));
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var value = _patientService.TGetByID(id);
            _patientService.TDelete(value);
            return Ok();
        }
    }
}
