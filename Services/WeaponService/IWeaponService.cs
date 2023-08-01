using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet7_sqlserver.Dtos.Weapon;

namespace dotnet7_sqlserver.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);

    }
}