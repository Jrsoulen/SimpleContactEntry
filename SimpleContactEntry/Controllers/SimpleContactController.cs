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
        [CustomExceptionFilter]
        [Route("contact")]
        public IEnumerable<Contact> GetAllContacts()
        {
            var repo = new LiteDBRepo();
            var allContacts = repo.GetAllContacts();
            return allContacts;
        }

        [HttpGet]
        [CustomExceptionFilter]
        [Route("contact/{id}")]
        public Contact GetContactById(int id)
        {
            var repo = new LiteDBRepo();
            var contact = repo.GetContactById(id);
            return contact;
        }

        [HttpPost]
        [CustomExceptionFilter]
        [Route("contact")]
        public string CreateNewContact([FromBody]Contact contact)
        {
            var repo = new LiteDBRepo();
            var response = repo.CreateNewContact(contact);
            return $"Created contact with id: {response}";
        }
        [HttpPut]
        [CustomExceptionFilter]
        [Route("contact/{id}")]
        public string UpdateExistingContact(int id, [FromBody] Contact contact)
        {
            var repo = new LiteDBRepo();
            var response = repo.UpdateExistingContact(id, contact);
            return $"Updated: {response}";
        }

        [HttpDelete]
        [CustomExceptionFilter]
        [Route("contact/{id}")]
        public ActionResult<string> DeleteExistingContact(int id)
        {
            var repo = new LiteDBRepo();
            var response = repo.DeleteExistingContact(id);
            return $"Deleted: {response}";
        }
    }
}
