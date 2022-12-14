using Queue.Application.Generic.Dto;
using Queue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Queue.Dto
{
    public class QueueDto : BaseDto
    {
        public string name { get; set; }
    }
}
