using Company.Application.DTO;

namespace Company.Clients.Interfaces
{
    public interface IAccountClient
    {
        Task<ResponseLogin> Login(RequestLogin request);
    }
}
