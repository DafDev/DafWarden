using FluentResults;

namespace DafWarden.Domain.Adapters;
public interface IPassphraseFragementRepository
{
    Result<string> GetPassphraseFragment(int fragementId);
    Result<string> GetRandomDigitOrSpecialCharacter(int specialCharacterId);
}
