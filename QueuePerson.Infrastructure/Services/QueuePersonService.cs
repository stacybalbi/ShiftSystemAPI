using AutoMapper;
using QueuePerson.Application.Interfaces;
using QueuePerson.Application.QueuePerson.Dto;
using QueuePerson.Domain.Entities;
using QueuePerson.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuePerson.Infrastructure.Services
{
    public class QueuePersonService : BaseCrudService<Domain.Entities.QueuePerson>, IQueuePersonService
    {
        private readonly IMapper _mapper;
        public IQueuePersonDbContext _dbContext;
        public QueuePersonService(IQueuePersonDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }


        public Task Push(int queueId)
        {
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task Put(QueuePersonDto dto)
        {
            await _dbSet.AddAsync(_mapper.Map<Domain.Entities.QueuePerson>(dto));
            _dbContext.SaveChanges();
        }

        public void Put(int queueId)
        {
        }
    }
}
