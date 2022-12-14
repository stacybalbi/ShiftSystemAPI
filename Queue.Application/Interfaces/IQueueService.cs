using Queue.Application.Generic.Interfaces;
using Queue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Interfaces
{
    public interface IQueueService : IBaseCrudService<Domain.Entities.Queue>
    {

    }
}
