using AutoMapper;
using CompanyBranchAPI.Dtos;
using CompanyBranchAPI.Helper;
using CompanyBranchCore.Entities;
using CompanyBranchCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyBranchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<BranchesController> _logger;

        public BranchesController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BranchesController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1,int pageSize = 10)
        {
            try
            {
                var result = await _unitOfWork.BranchRepository.GetAllWithIncludeAsync(
                     b => !b.IsDeleted,
                            pageNumber,
                             pageSize,
                                b => b.Company);

                
                IEnumerable<Branch> branches = result.Items;
                int totalCount = result.TotalCount;

                var pagedResult = new PagedResult<Branch>(
                    branches,
                      totalCount,
                          pageNumber,
                              pageSize);

                // Return response without $id and $values
                var results = new
                {
                    items = pagedResult.Items,
                    totalCount = pagedResult.TotalCount,
                    totalPages = pagedResult.TotalPages,
                    currentPage = pagedResult.CurrentPage,
                    pageSize = pagedResult.PageSize
                };

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching branches.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var branch = await _unitOfWork.BranchRepository.GetByIdWithIncludeAsync(id, query => query.Include(b => b.Company));
               // b => b.Id == id, b => b.Company);

            if (branch == null )
            {
                _logger.LogWarning($"Branch with ID {id} not found.");
                return NotFound();
            }

            var branchDto = _mapper.Map<GetBranchDto>(branch);
            return Ok(branchDto);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BranchDto branchDto)
        {
            if (branchDto == null)
            {
                _logger.LogWarning("Received null branch data.");
                return BadRequest("Branch data is required.");
            }

            var branch = _mapper.Map<Branch>(branchDto);

            await _unitOfWork.BranchRepository.AddAsync(branch);

            _logger.LogInformation($"Branch with ID {branch.Id} created.");
            return CreatedAtAction(nameof(Get), new { id = branch.Id }, branch);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBranchDto branchDto)
        {
            if (branchDto == null || branchDto.Id != id)
            {
                _logger.LogWarning("Invalid branch data for update.");
                return BadRequest();
            }

            var branch = _mapper.Map<Branch>(branchDto);

            await _unitOfWork.BranchRepository.UpdateAsync(branch);

            _logger.LogInformation($"Branch with ID {id} updated.");
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var branch = await _unitOfWork.BranchRepository.GetByIdAsync(id);

            if (branch == null)
            {
                _logger.LogWarning($"Branch with ID {id} not found.");
                return NotFound();
            }

            await _unitOfWork.BranchRepository.DeleteAsync(id);

            _logger.LogInformation($"Branch with ID {id} deleted.");
            return NoContent();
        }
    }
}
