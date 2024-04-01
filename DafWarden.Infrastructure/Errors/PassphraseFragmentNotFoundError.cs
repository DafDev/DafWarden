using FluentResults;

namespace DafWarden.Infrastructure.Errors;
public class PassphraseFragmentNotFoundError : Error
{
    public PassphraseFragmentNotFoundError(int fragmentId) 
        : base($"Passphrase fragment id {fragmentId} not found.") => Metadata.Add("ErrorCode", "2");
}
