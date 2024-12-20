﻿using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DbModel.ModelDTO;
using WebApplication2.Repositories.IRepository;

namespace WebApplication2.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly IAuth _authServices;

    public AuthController(IAuth authServices)
    {
        _authServices = authServices;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrDTO model)
    {
        try
        {
            /*Cheking type body was arrived*/
            if (!ModelState.IsValid || model == null)
            {
                throw new Exception("Invalid data");
            }

            //Registrate user
            await _authServices.RegistrateUser(model);
            return Ok(new { message = "User was registrated succesfully. " });

        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO login)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var token = await _authServices.LoginUser(login);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { message = "Invalid credintal" });
            }

            return Ok(new { token });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
    
    


}