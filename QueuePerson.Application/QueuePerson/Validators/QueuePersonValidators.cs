using FluentValidation;
using QueuePerson.Application.QueuePerson.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuePerson.Application.QueuePerson.Validators
{
    public class QueuePersonValidators : AbstractValidator<QueuePersonDto>
    {
        public QueuePersonValidators()
        {
            RuleFor(x => x.QueueId).NotEmpty().WithMessage("QueueId is required");
            RuleFor(x => x.PersonId).NotEmpty().WithMessage("QueueId is required");
            RuleFor(x => x.Status).NotEmpty().WithMessage("QueueId is required");
            RuleFor(x => x.Created).NotEmpty().WithMessage("QueueId is required");

        }
    }
}
