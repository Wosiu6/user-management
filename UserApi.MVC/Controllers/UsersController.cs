using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UserManagement.UserApi.Models;
using UserManagement.UserApi.Services.Contracts;

namespace UserManagement.UserApi.MVC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet(Name = nameof(GetUsers))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<UserEntity>> GetUsers()
    {
        var users = await _service.GetAllAsync();
        return users;
    }

    [HttpGet("{id:guid}", Name = "UserById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<Results<NotFound, Ok<UserEntity>>> GetUserById(Guid id)
    {
        var user = await _service.GetByIdAsync(id);

        return user == null ? TypedResults.NotFound() :
                               TypedResults.Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] UserEntity newUser)
    {
        var createdUser = await _service.AddAsync(newUser);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }


    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put(Guid id, [FromBody] UserEntity user)
    {
        user.Id = id;
        var result = await _service.UpdateAsync(user);
        return result == 1 ? Ok() : NotFound();
    }

    // DELETE api/sauces/5
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var result = await _service.DeleteAsync(id);
            return result == 1 ? Ok() : NotFound();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
        catch
        {
            return BadRequest();
        }
    }
}
