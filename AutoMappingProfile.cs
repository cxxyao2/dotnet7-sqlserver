using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet7_sqlserver
{
  public class AutoMappingProfile : Profile
  {
    public AutoMappingProfile()
    {
      CreateMap<Character, GetCharacterDto>();
      CreateMap<AddCharacterDto, Character>();
      CreateMap<UpdateCharacterDto, Character>();
    }
  }
}