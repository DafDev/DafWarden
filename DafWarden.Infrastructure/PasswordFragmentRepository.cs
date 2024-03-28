using DafWarden.Domain.Adapters;

namespace DafWarden.Infrastructure;

public class PasswordFragmentRepository : IPasswordFragementRepository
{
    public Task<string> GetPasswordFragment(int FragementId)
    {
        throw new NotImplementedException();
    }
}
