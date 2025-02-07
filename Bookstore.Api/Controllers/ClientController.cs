using AutoMapper;
using Bookstore.Domain.DTOs;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RT.Comb;

namespace Bookstore.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly ICombProvider _comb;

        public ClientController(IClientRepository clientRepository, IMapper mapper, ICombProvider comb)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _comb = comb;
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
            client.Id = _comb.Create();

            _clientRepository.Add(client);
            return await _clientRepository.SaveAllAsync() ? Ok("Successfully registered") : BadRequest("Error when registering");
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid id,ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);
            client.Id = id;

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
