using BoardGamesNook.Repository.Interfaces;

namespace BoardGamesNook.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool Login(string login, string password)
        {
            return _accountRepository.Login(login, password);
        }

        public bool IsLoginAllowed(string login)
        {    
            return _accountRepository.IsLoginAllowed(login);
        }
    }
}
   