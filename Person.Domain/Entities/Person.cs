using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }

        public string dni { get; set; }
    }
}
