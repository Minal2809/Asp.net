using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore ;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(DataContext context) : ControllerBase
{
  [HttpGet]
  public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
  {
    var users =  await context.Users.ToListAsync() ;
    return users;
  }

  [HttpGet("{id:int}")]  // /api/user/2
  public async Task <ActionResult<ICollection<AppUser>>> GetUsers(int id)
  {
    var getusers = await context.Users.ToListAsync() ;

    if (getusers == null) return NotFound() ;

    return getusers;
  }

}