using AutoMapper;
using QueuePerson.Application.Generic.Handlers;
using QueuePerson.Application.Generic.Interfaces;
using QueuePerson.Application.Interfaces;
using QueuePerson.Application.QueuePerson.Dto;
using QueuePerson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuePerson.Application.QueuePerson.Handlers
{
    public interface IQueuePersonHandler : IBaseCrudHandler<QueuePersonDto, Domain.Entities.QueuePerson>
    {
        Task<List<QueuePersonDto>> GetByQueueId(int queueId);
        Task Put (QueuePersonDto dto);
        Task<Task> Push(int queueId);
    }


    public class QueuePersonHandler : BaseCrudHandler<QueuePersonDto, Domain.Entities.QueuePerson>, IQueuePersonHandler
    {
        private readonly IQueuePersonService _crudService;
        private readonly IMapper _mapper;

        public QueuePersonHandler(IQueuePersonService crudService, IMapper mapper) : base(crudService, mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }


        public async Task<List<QueuePersonDto>> GetByQueueId(int queueId)
        {
            return _mapper.Map<List<QueuePersonDto>>(_crudService.Query().Where(QueuePerson => QueuePerson.QueueId == queueId)
                                                           .OrderBy(QueuePerson => QueuePerson.Created)
                                                           .ToList());
        }

        public async Task Put(QueuePersonDto dto)
        {
            var queue = _crudService.Query().Where(QueuePerson => QueuePerson.QueueId == dto.QueueId)
                                               .OrderBy(QueuePerson => QueuePerson.Created).ToList();

            if (queue.Any(x => x.PersonId == dto.PersonId))
                throw new Exception("No se puede agregar la persona a la fila más de una vez.");

            QueuePersonDto entity = new QueuePersonDto
            {
                Created = DateTime.Now,
                PersonId = dto.PersonId,
                QueueId = dto.QueueId,
                Status = Domain.Enums.Status.OnStandby
            };
            await _crudService.Put(entity);
           
        }

        public async Task<Task> Push(int queueId)
        {
            var queueValuesQueryable = _crudService.Query().Where(QueuePerson => QueuePerson.QueueId == queueId && QueuePerson.Status != Domain.Enums.Status.Inactive)
                                            .OrderBy(QueuePerson => QueuePerson.Created);

            var current = queueValuesQueryable.FirstOrDefault();

            if (current != null)
            {
                if (current.Status == Domain.Enums.Status.OnStandby)
                {
                    current.Status = Domain.Enums.Status.Active;
                    _crudService.Update(current);
                }
                else if (current.Status == Domain.Enums.Status.Active)
                {
                    current.Status = Domain.Enums.Status.Inactive;
                    _crudService.Update(current);
                    var next = queueValuesQueryable.Skip(1).FirstOrDefault();
                    if (next != null)
                    {
                        next.Status = Domain.Enums.Status.Active;
                        _crudService.Update(next);
                    }
                }
            }
            _crudService.Push(queueId);
            return Task.CompletedTask;


        }
    }



}
