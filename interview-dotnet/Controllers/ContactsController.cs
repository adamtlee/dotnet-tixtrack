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

        /// <summary>
        /// Adds a new contact to the Contacts entity set in the database.
        /// </summary>
        /// <param name="contact">The contact to be added to the database.</param>
        /// <returns>
        /// A Created response with the newly added contact and a location header that
        /// contains the URL of the newly created contact, or a BadRequest response with
        /// an appropriate error message if an error occurs.
        /// </returns>
      
        [HttpPost]
        public async Task<ActionResult> AddContact(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Created("api/v1/contacts", contact);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while saving the contact: {ex.Message}");
            }
           
            return BadRequest("unable to save changes.");
        }


        /// <summary>
        /// Retrieves a list of all contacts from the Contacts entity set in the database.
        /// </summary>
        /// <returns>
        /// An Ok response with the list of contacts, or a StatusCode 500 response with an
        /// appropriate error message if an error occurs.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var contacts = await _context.Contacts.ToListAsync();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while getting contacts: {ex.Message}");
            }
        }
    }
}

