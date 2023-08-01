using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet7_sqlserver.Dtos.Skill;
using dotnet7_sqlserver.Dtos.Weapon;

namespace dotnet7_sqlserver
{
  public class AutoMappingProfile : Profile
  {
    public AutoMappingProfile()
    {
      CreateMap<Character, GetCharacterDto>();
      CreateMap<AddCharacterDto, Character>();
      CreateMap<UpdateCharacterDto, Character>();
      CreateMap<Weapon, GetWeaponDto>();
      CreateMap<Skill, GetSkillDto>();
    }
  }
}