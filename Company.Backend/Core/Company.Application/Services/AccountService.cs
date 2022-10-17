using Company.Application.DTO;
using Company.Application.Interfaces;
using Company.DAL.Interfaces;

namespace Company.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository; 
        }

        public async Task<ResponseLogin> Login(RequestLogin request)
        {
            var employee = await _accountRepository.Login(request.Password, request.Email);

            if (employee == null)
                return new ResponseLogin { IsSuccessfully = false, Error = "Неверный логин или пароль"};

            return new ResponseLogin { IsSuccessfully = true, Email = employee.Email, RoleName = employee.Role.Name };
        }
    }
}
