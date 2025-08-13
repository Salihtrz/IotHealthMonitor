using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.AboutDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListAbout()
        {
            var values = _aboutService.TGetAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(values));
        }
        [HttpGet("changeToStatusTrue")]
        public IActionResult changeToStatusTrue(int id)
        {
            _aboutService.TchangeToStatusTrue(id);
            return Ok();
        }
        [HttpGet("changeToStatusFalse")]
        public IActionResult changeToStatusFalse(int id)
        {
            _aboutService.TchangeToStatusFalse(id);
            return Ok();
        }
        [HttpGet("getAboutWithStatusTrue")]
        public IActionResult getAboutWithStatusTrue()
        {
            var value = _aboutService.TgetAboutWithStatusTrue();
            return Ok(_mapper.Map<List<ResultAboutDto>>(value));
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(_mapper.Map<GetAboutDto>(value));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return Ok();
        }
    }
}
