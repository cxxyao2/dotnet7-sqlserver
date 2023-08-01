using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet7_sqlserver.Data;
using dotnet7_sqlserver.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet7_sqlserver.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _authRepository;

    public AuthController(IAuthRepository authRepository)
    {
      _authRepository = authRepository;
    }


    [HttpPost("Register")]
    public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
    {
      var response = await _authRepository.Register(
        new User { Name = request.Username }, request.Password
      );
      if (!response.Success) return BadRequest(response);

      return Ok(response);
    }

    [HttpPost("Login")]
    public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)
    {
      var response = await _authRepository.Login(
       request.Username, request.Password
      );
      if (!response.Success) return BadRequest(response);

      return Ok(response);
    }

  }
}