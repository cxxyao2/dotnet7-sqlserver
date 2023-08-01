using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet7_sqlserver.Dtos.Weapon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet7_sqlserver.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeaponController : Controller
    {
        private readonly IWeaponService _weaponservice;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponservice = weaponService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddWeapon(AddWeaponDto newWeapon)
        {
            return Ok(await _weaponservice.AddWeapon(newWeapon));
        }
    }
}