using AutoMapper;
using Person.Application.Generic.Handlers;
using Person.Application.Generic.Interfaces;
using Person.Application.Interfaces;
using Person.Application.Person.Dto;
using Person.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Person.Handlers
{
    public interface IPersonHandler : IBaseCrudHandler<PersonDto, Domain.Entities.Person>
    {
        new Task<PersonDto> GetById(int id);
        new Task<PersonDto> Update(PersonDto dto);
        new Task<PersonDto> Update(int id, PersonDto dto);
        new Task<PersonDto> Create(PersonDto dto);
        new Task<List<PersonDto>> Get(int top);
    }
    public class PersonHandler : BaseCrudHandler<PersonDto, Domain.Entities.Person>, IPersonHandler
    {
        private readonly IPersonService _crudService;
        private readonly IMapper _mapper;

        public PersonHandler(IPersonService crudService, IMapper mapper) : base(crudService, mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public new async Task<PersonDto> GetById(int id)
        {
            var person = await base.GetById(id);
            
            if (person == null) throw new Exception("Person not found");

            return person;

        }

        public new async Task<PersonDto> Update(PersonDto dto)
        {
            return await base.Update(dto);
        }

        public new async Task<PersonDto> Update(int id, PersonDto dto)
        {
            return await base.Update(id, dto);
        }

        public new async Task<PersonDto> Create(PersonDto dto)
        {
            return await base.Create(dto);

        }

        public async Task<List<PersonDto>> Get(int top = 50)
        {
            return await base.Get(top);
        }
    }
}
