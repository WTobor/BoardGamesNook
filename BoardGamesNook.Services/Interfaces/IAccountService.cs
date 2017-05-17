namespace BoardGamesNook.Services.Interfaces
{
    public interface IAccountRepository
    {
        bool Login(string login, string password);

        bool IsLoginAllowed(string login);
    }
}
