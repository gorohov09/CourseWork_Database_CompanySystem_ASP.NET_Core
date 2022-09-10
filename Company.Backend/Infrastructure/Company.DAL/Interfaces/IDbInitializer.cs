using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Interfaces
{
    public interface IDbInitializer
    {
        Task<bool> RemoveAsync(CancellationToken cancel = default);

        Task InitializeAsync(bool RemoveBefore = false, CancellationToken cancel = default);
    }
}
