using Company.Application.DTO;

namespace Company.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseLogin> Login(RequestLogin request);
    }
}
