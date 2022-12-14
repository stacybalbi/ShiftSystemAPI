using AutoMapper;
using Queue.Application.Queue.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Queue.Mappings
{
    public class QueueProfile : Profile
    {
       public QueueProfile(){
            CreateMap<Domain.Entities.Queue, QueueDto>();
            CreateMap<QueueDto, Domain.Entities.Queue>();
        }
    }
}
