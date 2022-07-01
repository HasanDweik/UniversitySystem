using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Interfaces;
using UniversitySystem.Models;
using UniversitySystem.Persistences.Entities.Roles.Queries.GetRoles;

namespace UniversitySystem.Controllers;


[ApiController]
[Route("[controller]")]
public class RoleController : Controller
{
    private readonly IRoleHelper _roleHelper;
    private readonly IMediator _mediator;

    public RoleController(IRoleHelper roleHelper, IMediator mediator)
    {
        _roleHelper = roleHelper;
        _mediator = mediator;
    }

    [HttpGet()]
    public async Task<List<Role>> GetRoles()
    {
        var result = await _mediator.Send(new GetRolesQuery());
        return  result;
    }
    
    [HttpPost("AddRole")]
    public IActionResult AddRole([Required]String name)
    {
        if (_roleHelper.AddRole(name))
        {
            return Ok("Role Added!");
        }
        return BadRequest();
    }
    [HttpDelete("DeleteRole")]
    public IActionResult DeleteRole([Required]int id)
    {
        if (_roleHelper.DeleteRole(id))
        {
            return Ok("Role Deleted!");
        }
        return BadRequest();
    }
    [HttpPost("UpdateRole")]
    public IActionResult UpdateRole([Required]int id,[FromBody]string name)
    {
        if (_roleHelper.UpdateRole(id,name))
        {
            return Ok("Role Updated!");
        }
        return BadRequest();
    }
    
}