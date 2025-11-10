using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactAPI.Model;
using ContactAPI.Model.DTO;
using ContactAPI.Services.interfaces;

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _service;

        public GroupsController( IGroupService service)
        {
            _service = service;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var res = await _service.GetAllGroups();
            return Ok(res);
        }


        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostGroup([FromBody] GroupCreateDTO @group)
        {
            await _service.CreateGroup(@group);
            return Ok();
        }

        [HttpPost("add-to-group")]
        public async Task<IActionResult> AddContactToGroup(int ContactId, int GroupId)
        {
            var res = _service.AddContactToGroup(ContactId, GroupId);
            return Created(String.Empty, res);
        }

    }
}
