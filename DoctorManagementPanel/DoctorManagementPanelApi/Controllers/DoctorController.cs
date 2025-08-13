using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.DoctorDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListDoctor()
        {
            var values = _doctorService.TGetAll();
            return Ok(_mapper.Map<List<ResultDoctorDto>>(values));
        }
        [HttpGet("GetDoctorsWithBranchName")]
        public IActionResult GetDoctorsWithBranchName()
        {
            var values = _doctorService.TGetDoctorsWithBranchName();
            return Ok(_mapper.Map<List<ResultDoctorDto>>(values));
        }
        [HttpGet("GetDoctorsStatusTrueWithBranchName")]
        public IActionResult GetDoctorsStatusTrueWithBranchName()
        {
            var values = _doctorService.TGetDoctorsStatusTrueWithBranchName();
            return Ok(_mapper.Map<List<ResultDoctorDto>>(values));
        }
        [HttpGet("GetDoctorsStatusFalseWithBranchName")]
        public IActionResult GetDoctorsStatusFalseWithBranchName()
        {
            var values = _doctorService.TGetDoctorsStatusFalseWithBranchName();
            return Ok(_mapper.Map<List<ResultDoctorDto>>(values));
        }
        [HttpGet("GetDoctorsStatusNullWithBranchName")]
        public IActionResult GetDoctorsStatusNullWithBranchName()
        {
            var values = _doctorService.TGetDoctorsStatusNullWithBranchName();
            return Ok(_mapper.Map<List<ResultDoctorDto>>(values));
        }
        [HttpGet("ChangeDoctorStatusToTrue")]
        public IActionResult ChangeDoctorStatusToTrue(int id)
        {
            _doctorService.TChangeDoctorStatusToTrue(id);
            return Ok();
        }
        [HttpGet("ChangeDoctorStatusToFalse")]
        public IActionResult ChangeDoctorStatusToFalse(int id)
        {
            _doctorService.TChangeDoctorStatusToFalse(id);
            return Ok();
        }
        [HttpGet("ChangeDoctorStatusToNull")]
        public IActionResult ChangeDoctorStatusToNull(int id)
        {
            _doctorService.TChangeDoctorStatusToNull(id);
            return Ok();
        }
        [HttpGet("SetDoctorIsExistToFalse")]
        public IActionResult SetDoctorIsExistToFalse(int id)
        {
            _doctorService.TSetDoctorIsExistToFalse(id);
            return Ok();
        }
        [HttpGet("DoctorCountByIsStatusTrue")]
        public IActionResult DoctorCountByIsStatusTrue()
        {
            var value = _doctorService.TDoctorCountByIsStatusTrue();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDoctor(CreateDoctorDto createDoctorDto)
        {
            var value = _mapper.Map<Doctor>(createDoctorDto);
            _doctorService.TAdd(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateDoctor(UpdateDoctorDto updateDoctorDto)
        {
            var value = _mapper.Map<Doctor>(updateDoctorDto);
            _doctorService.TUpdate(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            var value = _doctorService.TGetByID(id);
            return Ok(_mapper.Map<GetDoctorDto>(value));
        }
        [HttpGet("GetDoctorIDByAppUserID/{id}")]
        public IActionResult GetDoctorIDByAppUserID(int id)
        {
            var value = _doctorService.TGetDoctorIDByAppUserID(id);
            return Ok(_mapper.Map<GetDoctorDto>(value));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var value = _doctorService.TGetByID(id);
            _doctorService.TDelete(value);
            return Ok();
        }
    }
}
