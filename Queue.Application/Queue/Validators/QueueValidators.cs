using FluentValidation;
using Queue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Queue.Validators
{
    public class QueueValidators : AbstractValidator<Domain.Entities.Queue>
    {

        public QueueValidators()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Name is required");
        }
    }
}
