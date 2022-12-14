using AutoMapper;
using Person.Application.Generic.Handlers;
using Person.Application.Generic.Interfaces;
using Person.Application.Interfaces;
using Person.Application.Person.Dto;
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
        private readonly IPersonService _personService;
        //private readonly IAzureFormRecognizerService _azureFormRecognizedService;
        private readonly IMapper _mapper;
        public PersonHandler(IPersonService personService, IMapper mapper) : base((IBaseCrudService<Domain.Entities.Person>)personService, mapper)
        {
            _personService = personService;
            _mapper = mapper;
            //_azureFormRecognizedService = azureFormRecognizedService;
        }

        public new async Task<PersonDto> GetById(int id)
        {
            return await base.GetById(id);
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
            //var azureConfig = new AzureConfig
            //{
            //    endpoint = "https://validatorrr.cognitiveservices.azure.com/",
            //    key = "6e6fe3c8899d452ca8cc2902008fc812",
            //    modelId = "dni"
            //};

            var person = _mapper.Map<Domain.Entities.Person>(dto);

            //var analyzeResult = await _azureFormRecognizedService.GetAnalyzeResultValue(azureConfig, dto.fileUri);

            //var personFromAnalyzeResult = await _personService.GetPersonFromAnalyzeResult(analyzeResult);

            //person.Name = personFromAnalyzeResult.Name;

            //person.dni = personFromAnalyzeResult.dni;

            //person = await _personService.Create(person);

            return _mapper.Map(person, dto);

           
        }

        public async Task<List<PersonDto>> Get(int top)
        {
            return await base.Get(top);
        }
    }
}
