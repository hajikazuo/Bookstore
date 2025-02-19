using AutoMapper;
using Bookstore.Api.Extensions;
using Bookstore.Domain.DTOs;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Pagination;
using Bookstore.Infrastructure.Repositories;
using loanstore.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RT.Comb;

namespace Bookstore.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;
        private readonly ICombProvider _comb;

        public LoanController(ILoanRepository loanRepository, IMapper mapper, ICombProvider comb)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
            _comb = comb;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            var loans = await _loanRepository.GetAll(paginationParams.PageNumber, paginationParams.PageSize);
            var loansDTO = _mapper.Map<IEnumerable<LoanResponseDTO>>(loans);
            var response = new PagedList<LoanResponseDTO>(paginationParams.PageNumber, paginationParams.PageSize, loans.TotalCount, loansDTO);

            Response.AddPaginationHeader(new PaginationHeader(response.CurrentPage, response.PageSize, response.TotalCount, response.TotalPages));
            return Ok(loansDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var loan = await _loanRepository.GetById(id);

            if (loan == null)
            {
                return NotFound("Loan not found");
            }

            var loanDTO = _mapper.Map<LoanResponseDTO>(loan);

            return Ok(loanDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Add(LoanPostRequestDTO loanDTO)
        {
            var available = await _loanRepository.CheckAvailability(loanDTO.BookId);
            if(!available)
            {
                return BadRequest("Book not available");
            }

            var loan = _mapper.Map<Loan>(loanDTO);
            loan.Id = _comb.Create();
            loan.LendingDate = DateTime.Now;

            _loanRepository.Add(loan);
            return await _loanRepository.SaveAllAsync() ? Ok("Successfully registered") : BadRequest("Error when registering");
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, LoanPutRequestDTO loanPutDTO)
        {
            var loanDTO = await _loanRepository.GetById(id);

            if(loanDTO == null)
            {
                return NotFound();
            }

            loanDTO.DevolutionDate = loanPutDTO.DevolutionDate;
            loanDTO.IsReturned = loanPutDTO.IsReturned;

            _loanRepository.Update(loanDTO);
            return await _loanRepository.SaveAllAsync() ? Ok("Successfully changed") : BadRequest("Error when changing");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            var loan = await _loanRepository.GetById(id);

            if (loan == null)
            {
                return NotFound("Loan not found");
            }

            _loanRepository.Remove(loan);
            return await _loanRepository.SaveAllAsync() ? Ok("Successfully deleted") : BadRequest("Error when deleting");
        }
    }
}
