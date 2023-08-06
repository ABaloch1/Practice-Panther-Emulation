using Microsoft.AspNetCore.Mvc;
using Project.API.Database;
using Project.API.EC;
using Project_library.DTO;
using Project_library.Models;
using Project_library.Utilities;

namespace Project.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]

        public IEnumerable<ClientDTO> Get()
        {
            return new ClientEC().Search();
        }

        [HttpGet("/{id}")]
        public ClientDTO? GetId(int id)
        {
            return new ClientEC().Get(id);
        }

        [HttpDelete("Delete/{id}")]
        public ClientDTO? Delete(int id)
        {
           return new ClientEC().Delete(id);
        }
        [HttpPost]
        public ClientDTO AddorUpdate([FromBody] ClientDTO client)
        {
            return new ClientEC().AddorUpdate(client);
            
        }

        [HttpPost("Search")]
        public IEnumerable<ClientDTO> Search([FromBody] QueryMessage query)
        {
            return new ClientEC().Search(query.Query);
        }

    }
}
