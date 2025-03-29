using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.UseCases.Auth.ChangePassword;

public class ChangePasswordUseCase
{
    private readonly IAuthRepository _repository;

    public ChangePasswordUseCase(IAuthRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Executar(int userId, String oldPassword, String newPassword)
    {
        if (!(String.IsNullOrEmpty(oldPassword) || String.IsNullOrEmpty(newPassword)) && (newPassword != oldPassword))
        {
            return await _repository.TrocarSenha(userId, newPassword);
        }
        throw new Exception("A sua senha não é válida ");  
    }
}