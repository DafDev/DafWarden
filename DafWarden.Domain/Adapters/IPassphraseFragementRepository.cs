using FluentResults;

namespace DafWarden.Domain.Adapters;
public interface IPassphraseFragementRepository
{
    Result<string> GetPassphraseFragment(int FragementId);
}
