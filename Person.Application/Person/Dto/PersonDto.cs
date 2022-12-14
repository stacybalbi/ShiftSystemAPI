using Person.Application.Generic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Person.Dto
{
    public class PersonDto : BaseDto
    {
        public string Name { get; set; }

        public string dni { get; set; }
    }
}
