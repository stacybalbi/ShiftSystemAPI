using AutoMapper;
using Person.Application.Person.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Person.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Domain.Entities.Person, PersonDto>();
            CreateMap<PersonDto, Domain.Entities.Person>();
        }
    }
}
