using Company.Domain.Entities;

namespace Company.DAL.Interfaces
{
    public interface IAccountRepository
    {
        Task<EmployeeEntity> Login(string password, string email);
    }
}
