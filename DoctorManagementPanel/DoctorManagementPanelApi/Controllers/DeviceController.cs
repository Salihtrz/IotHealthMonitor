using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.DeviceDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;

        public DeviceController(IDeviceService deviceService, IMapper mapper)
        {
            _deviceService = deviceService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListDevice()
        {
            var values = _deviceService.TGetAll();
            return Ok(_mapper.Map<List<ResultDeviceDto>>(values));
        }
        [HttpGet("GetDeviceWithPatientName")]
        public IActionResult GetDeviceWithPatientName()
        {
            var values = _deviceService.TGetDeviceWithPatientName();
            return Ok(_mapper.Map<List<ResultDeviceDto>>(values));
        }
        [HttpGet("GetDeviceWithLastMeasurements")]
        public IActionResult GetDeviceWithLastMeasurements()
        {
            var values = _deviceService.TGetDeviceWithLastMeasurements();
            return Ok(_mapper.Map<List<DeviceMeasurementDto>>(values));
        }
        [HttpGet("GetDeviceWithLastMeasurementsByDeviceID/{id}")]
        public IActionResult GetDeviceWithLastMeasurementsByDeviceID(int id)
        {
            var values = _deviceService.TGetDeviceWithLastMeasurementsByDeviceID(id);
            return Ok(_mapper.Map<DeviceMeasurementDto>(values));
        }
        [HttpGet("GetDeviceWithAveragePulseByDeviceID/{id}")]
        public IActionResult GetDeviceWithAveragePulseByDeviceID(int id)
        {
            var values = _deviceService.TGetDeviceWithAveragePulseByDeviceID(id);
            return Ok(_mapper.Map<int>(values));
        }
        [HttpGet("GetDeviceWithAverageSpO2ByDeviceID/{id}")]
        public IActionResult GetDeviceWithAverageSpO2ByDeviceID(int id)
        {
            var values = _deviceService.TGetDeviceWithAverageSpO2ByDeviceID(id);
            return Ok(_mapper.Map<int>(values));
        }
        [HttpGet("GetDeviceWithLowestPulseByDeviceID/{id}")]
        public IActionResult GetDeviceWithLowestPulseByDeviceID(int id)
        {
            var values = _deviceService.TGetDeviceWithLowestPulseByDeviceID(id);
            return Ok(_mapper.Map<int>(values));
        }
        [HttpGet("GetDeviceWithHighestPulseByDeviceID/{id}")]
        public IActionResult GetDeviceWithHighestPulseByDeviceID(int id)
        {
            var values = _deviceService.TGetDeviceWithHighestPulseByDeviceID(id);
            return Ok(_mapper.Map<int>(values));
        }
        [HttpGet("GetDeviceIDByPatientID/{id}")]
        public IActionResult GetDeviceIDByPatientID(int id)
        {
            var values = _deviceService.TGetDeviceIDByPatientID(id);
            return Ok(_mapper.Map<GetDeviceDto>(values));
        }
        [HttpGet("GetDeviceWithHighestPulsePatientByDeviceID/{id}")]
        public IActionResult GetDeviceWithHighestPulsePatientByDeviceID(int id)
        {
            var values = _deviceService.TGetDeviceWithHighestPulsePatientByDeviceID(id);
            return Ok(_mapper.Map<HighestPulseValueDto>(values));
        }
        [HttpGet("GetDeviceWithLowestPulsePatientByDeviceID/{id}")]
        public IActionResult GetDeviceWithLowestPulsePatientByDeviceID(int id)
        {
            var values = _deviceService.TGetDeviceWithLowestPulsePatientByDeviceID(id);
            return Ok(_mapper.Map<LowestPulseValueDto>(values));
        }
        [HttpPost]
        public IActionResult CreateDevice(CreateDeviceDto createDeviceDto)
        {
            var value = _mapper.Map<Device>(createDeviceDto);
            _deviceService.TAdd(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateDevice(UpdateDeviceDto updateDeviceDto)
        {
            var value = _mapper.Map<Device>(updateDeviceDto);
            _deviceService.TUpdate(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetDevice(int id)
        {
            var value = _deviceService.TGetByID(id);
            return Ok(_mapper.Map<GetDeviceDto>(value));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDevice(int id)
        {
            var value = _deviceService.TGetByID(id);
            _deviceService.TDelete(value);
            return Ok();
        }
    }
}
