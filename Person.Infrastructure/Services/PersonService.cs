using AutoMapper;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Person.Application.Interfaces;
using Person.Domain.Entities;
using Person.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure.Services
{
    public class PersonService : BaseCrudService<Domain.Entities.Person>, IPersonService
    {
        private readonly IPersonDbContext _dbContext;
        private readonly IMapper _mapper;

        public PersonService(IPersonDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Domain.Entities.Person> Create(Domain.Entities.Person person)
        {
            //await _dbContext.GetDbSet<Domain.Entities.Person>().AddAsync(person);
            //await _dbContext.SaveChangesAsync();
            return person;
        }

        

        public async Task<Domain.Entities.Person> GetPersonFromAnalyzeResult(AnalyzeResult analyzeResult)
        {
            var person = new Domain.Entities.Person();
            foreach (AnalyzedDocument document in analyzeResult.Documents)
            {
                foreach (KeyValuePair<string, DocumentField> fieldKvp in document.Fields)
                {
                    string fieldName = fieldKvp.Key;
                    DocumentField field = fieldKvp.Value;

                    if (fieldName == "nombre") person.Name = field.Content.ToString();
                    if (fieldName == "cedula") person.dni = field.Content.ToString();
                }
            }
            return await Task.FromResult(person);
        }


    }
}
