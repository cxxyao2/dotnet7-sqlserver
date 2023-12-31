using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet7_sqlserver.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class CharacterController : ControllerBase
  {


    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
      _characterService = characterService;
    }

    [AllowAnonymous]
    [HttpGet("HighScore")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> HighScore()
    {
      return Ok(await _characterService.HighScore());

    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
    {
      return Ok(await _characterService.GetAllCharacters());

    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
    {

      return Ok(await _characterService.GetCharacterById(id));

    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
    {


      return Ok(await _characterService.AddCharacter(newCharacter));

    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
      var response = await _characterService.UpdateCharacter(updatedCharacter);
      if (response.Data is null) return NotFound();

      return Ok(response);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Delete(int id)
    {

      var response = await _characterService.DeleteCharacter(id);

      return Ok(response);

    }

    [HttpPost("Skill")]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
    {
      return Ok(await _characterService.AddCharacterSkill(newCharacterSkill));
    }
  }
}