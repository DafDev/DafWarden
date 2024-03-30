using FluentResults;

namespace DafWarden.Domain.Adapters;

public interface IPassphraseGenerator
{
    Result<string> Generate(int passwordLength);
}