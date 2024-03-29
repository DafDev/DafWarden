using FluentResults;

namespace DafWarden.Domain.Adapters;

public interface IPassphraseGenerator
{
    Task<Result<string>> Generate(int passwordLength);
}