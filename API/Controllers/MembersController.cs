using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //localhost:5001/api/members
    public class MembersController(AppDbContext appDbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers() //localhost:5001/api/members
        {
            var members = await appDbContext.Users.ToListAsync();
            return members;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetMember(string id) //localhost:5001/api/members/bob-id
        {
            var member = await appDbContext.Users.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return member;
        }
    }
}