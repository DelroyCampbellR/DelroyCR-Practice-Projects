using FirstBlazorApp.Data;
using FirstBlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsController(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            return await _contactsRepository.GetAll();
        }

        // GET api/contacts/5
        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            return await _contactsRepository.GetDetails(id);
        }

        // POST api/contacts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            if (contact == null)
                return BadRequest();

            if (string.IsNullOrEmpty(contact.LastName))
                ModelState.AddModelError("Contact", "Last Name can't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactsRepository.Insert(contact);

            return NoContent();
        }

        // PUT api/contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contact contact)
        {
            if (contact == null)
                return BadRequest();

            if (string.IsNullOrEmpty(contact.LastName))
                ModelState.AddModelError("Contact", "Last Name can't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (contact.Id == 0)
                contact.Id = id;

            await _contactsRepository.Update(contact);

            return NoContent();
        }

        // DELETE api/contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactsRepository.Delete(id);

            return NoContent();
        }
    }
}
