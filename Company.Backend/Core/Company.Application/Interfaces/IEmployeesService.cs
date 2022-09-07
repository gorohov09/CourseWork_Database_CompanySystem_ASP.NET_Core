using Company.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Application.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeVm>> GetEmployeeVm();
    }
}
