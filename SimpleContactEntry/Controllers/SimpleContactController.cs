using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace SimpleContactEntry.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimpleContactController : ControllerBase
    {

        private readonly ILogger<SimpleContactController> _logger;

        public SimpleContactController(ILogger<SimpleContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Contact> Contacts()
        {
            var repo = new LiteDBRepo();
            return repo.GetAllContacts();
        }
    }
}
