using AutoMapper;
using Queue.Application.Interfaces;
using Queue.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Infrastructure.Services
{
    public class QueueService : BaseCrudService<Domain.Entities.Queue>, IQueueService
    {
        public QueueService(IQueueDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
