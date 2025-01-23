using AutoMapper;
using Bookstore.Api.DTOs;
using Bookstore.Api.Interfaces;
using Bookstore.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            var clients = await _clientRepository.GetAll();
            var clientsDTO = _mapper.Map<IEnumerable<ClientDTO>>(clients);
            return Ok(clientsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetClient(Guid id)
        {
            var client = await _clientRepository.GetById(id);

            if (client == null)
            {
                return NotFound("Client not found");
            }

            var clientDto = _mapper.Map<ClientDTO>(client);

            return Ok(clientDto);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);
            _clientRepository.Add(client);
            return await _clientRepository.SaveAllAsync() ? Ok("Successfully registered") : BadRequest("Error when registering");
        }

        [HttpPut]
        public async Task<ActionResult> Update(ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);
            _clientRepository.Update(client);
            return await _clientRepository.SaveAllAsync() ? Ok("Successfully changed") : BadRequest("Error when changing");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            var client = await _clientRepository.GetById(id);

            if (client == null)
            {
                return NotFound("Client not found");
            }

            _clientRepository.Remove(client);
            return await _clientRepository.SaveAllAsync() ? Ok("Successfully deleted") : BadRequest("Error when deleting");
        }
    }
}
