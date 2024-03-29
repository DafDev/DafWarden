using DafWarden.Domain.Adapters;

namespace DafWarden.Infrastructure;

public class PasswordFragmentRepository : IPassphraseFragementRepository
{
    public Task<string> GetPassphraseFragment(int FragementId)
    {
        throw new NotImplementedException();
    }
}
