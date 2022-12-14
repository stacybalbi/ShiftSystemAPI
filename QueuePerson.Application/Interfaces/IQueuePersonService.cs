using QueuePerson.Application.Generic.Interfaces;
using QueuePerson.Application.QueuePerson.Dto;
using QueuePerson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuePerson.Application.Interfaces
{
    public interface IQueuePersonService : IBaseCrudService<Domain.Entities.QueuePerson>
    {
        Task Put(QueuePersonDto dto);
        Task Push(int queueId);
        void Put(int queueId);

    }
}
