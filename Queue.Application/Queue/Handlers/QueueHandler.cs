using AutoMapper;
using Queue.Application.Generic.Handlers;
using Queue.Application.Generic.Interfaces;
using Queue.Application.Interfaces;
using Queue.Application.Queue.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Queue.Handlers
{
    public interface IQueueHandler : IBaseCrudHandler<QueueDto, Domain.Entities.Queue>
    {
        new Task<QueueDto> GetById(int id);
        new Task<QueueDto> Update(QueueDto dto);
        new Task<QueueDto> Update(int id, QueueDto dto);
        new Task<QueueDto> Create(QueueDto dto);
        Task<List<QueueDto>> GetAll(int top = 50);
    }
    public class QueueHandler : BaseCrudHandler<QueueDto, Domain.Entities.Queue>, IQueueHandler
    {
        public QueueHandler(IQueueService crudService, IMapper mapper) : base(crudService, mapper)
        {
        }

        public new async Task<QueueDto> GetById(int id)
        {
            return await base.GetById(id);
        }

        public new async Task<QueueDto> Update(QueueDto dto)
        {
            return await base.Update(dto);
        }

        public new async Task<QueueDto> Update(int id, QueueDto dto)
        {
            return await base.Update(id, dto);
        }

        public new async Task<QueueDto> Create(QueueDto dto)
        {
            return await base.Create(dto);

           
        }

        public async Task<List<QueueDto>> GetAll(int top = 50)
        {
            return  await base.Get(top);
        }
    }
}
