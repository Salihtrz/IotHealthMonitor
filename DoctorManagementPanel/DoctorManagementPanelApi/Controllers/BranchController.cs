using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.BranchDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;

        public BranchController(IBranchService branchService, IMapper mapper)
        {
            _branchService = branchService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListBranch()
        {
            var values = _branchService.TGetAll();
            return Ok(_mapper.Map<List<ResultBranchDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateBranch(CreateBranchDto createBranchDto)
        {
            var value = _mapper.Map<Branch>(createBranchDto);
            _branchService.TAdd(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBranch(UpdateBranchDto updateBranchDto)
        {
            var value = _mapper.Map<Branch>(updateBranchDto);
            _branchService.TUpdate(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBranch(int id)
        {
            var value = _branchService.TGetByID(id);
            return Ok(_mapper.Map<GetBranchDto>(value));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBranch(int id)
        {
            var value = _branchService.TGetByID(id);
            _branchService.TDelete(value);
            return Ok();
        }
    }
}
