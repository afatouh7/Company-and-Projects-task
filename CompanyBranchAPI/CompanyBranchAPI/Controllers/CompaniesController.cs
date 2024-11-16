using AutoMapper;
using CompanyBranchAPI.Dtos;
using CompanyBranchAPI.Helper;
using CompanyBranchCore.Entities;
using CompanyBranchCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CompanyBranchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CompaniesController> _logger;
        private readonly IMapper _mapper;


        public CompaniesController(IUnitOfWork unitOfWork, ILogger<CompaniesController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;

        }
        [HttpPost("add-new-company")]
        public async Task<IActionResult> Post([FromBody] CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                _logger.LogWarning("Received null company data.");
                return BadRequest("Company data is required.");
            }

            var company = _mapper.Map<Company>(companyDto);
            await _unitOfWork.CompanyRepository.AddAsync(company);
            _logger.LogInformation($"Company with ID {company.Id} created.");

            return CreatedAtAction(nameof(GetAll), new { id = company.Id }, company);
        }
        [HttpGet("get-all-companies")]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _unitOfWork.CompanyRepository.GetAllAsync(pageNumber, pageSize);
                IEnumerable<Company> companies = result.Items;
                int totalCount = result.TotalCount;

                var pagedResult = new PagedResult<Company>(
                    companies,
                    totalCount,
                    pageNumber,
                    pageSize
                );

                return Ok(pagedResult);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while fetching branches.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        
        }
        [HttpGet("get-company/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(id);
            if (company == null)
            {
                _logger.LogWarning($"Company with ID {id} not found.");
                return NotFound();
            }

            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(companyDto);
        }
        [HttpPut("update-company/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCompanyDto companyDto)
        {
            if (companyDto == null || companyDto.Id != id)
            {
                _logger.LogWarning("Invalid company data for update.");
                return BadRequest();
            }

            var company = _mapper.Map<Company>(companyDto);
            await _unitOfWork.CompanyRepository.UpdateAsync(company);
            _logger.LogInformation($"Company with ID {id} updated.");

            return NoContent();
        }
        [HttpDelete("delete-company/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.CompanyRepository.DeleteAsync(id);
            _logger.LogInformation($"Company with ID {id} deleted.");

            return NoContent();
        }
    }
}
