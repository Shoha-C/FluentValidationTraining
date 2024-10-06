using FluentValidationTraining.Models;
using FluentValidationTraining.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationTraining.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    [HttpPost]
    public IActionResult Register([FromBody] CreateUserModel model)
    {
        var validator = new RegisterValidator();

        var result = validator.Validate(model);

        if (!result.IsValid)
            return BadRequest(result.Errors);

        //Logic here
        return Ok("Ok");
    }


}