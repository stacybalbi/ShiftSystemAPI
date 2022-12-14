using QueuePerson.Application.Generic.Dto;
using QueuePerson.Domain.Enums;
using QueuePerson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueuePerson.Application.QueuePerson.Dto
{
    public class QueuePersonDto : BaseDto
    {
        public int QueueId { get; set; }
        public int PersonId { get; set; }
        public Status Status { get; set; }
        public DateTime Created { get; set; }
    }
}
