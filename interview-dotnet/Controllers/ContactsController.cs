using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using interview_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace interview_dotnet.Controllers
{
    [Route("api/v1/contacts")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly ContactsContext _context;

        public ContactsController(ContactsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            var result = await _context.SaveChangesAsync();
            
            if (result > 0)
            {
                return Created("api/v1/contacts", contact);
            }

            return BadRequest("unable to save changes.");
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return Ok(contacts);
        }
    }
}

