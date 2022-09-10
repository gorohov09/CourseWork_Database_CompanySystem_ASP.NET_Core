using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Entities
{
    public class EmployeeProjectEntity
    {
        public int EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }

        public int ProjectId { get; set; }
        public ProjectEntity Project { get; set; }


    }
}
