using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactAPI.Model;
using ContactAPI.Services.interfaces;
using ContactAPI.Model.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data.Common;

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ExamDbContext _context;
        private readonly IContactServices _contactService;

        public ContactsController(ExamDbContext context, IContactServices service)
        {
            _context = context;
            _contactService = service;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var result = await _contactService.GetAllContacts();
            return Ok(result);
        }

        

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostContact(ContactCreateDTO contact)
        {
            var result = await _contactService.CreateContact(contact);


            //return CreatedAtAction("GetContact", new { id = result.Id }, result);
            return Created(string.Empty, result);
            //return CreatedResult(result);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                await _contactService.DeleteContact(id);
                return NoContent();
            } 
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
