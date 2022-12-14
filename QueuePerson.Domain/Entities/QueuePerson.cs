using Person.Domain.Entities;
using Queue.Domain.Entities;
using QueuePerson.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuePerson.Domain.Entities
{
    public class QueuePerson : BaseEntity
    {
        public int QueueId { get; set; }
        public int PersonId { get; set; }
        public Status Status { get; set; }
        public Enums.Conditions Conditions { get; set; } = Enums.Conditions.Normal;
        public DateTime Created { get; set; }
        [ForeignKey("QueueId")]
        public virtual Queue.Domain.Entities.Queue Queue { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person.Domain.Entities.Person Person { get; set; }

    }
}
