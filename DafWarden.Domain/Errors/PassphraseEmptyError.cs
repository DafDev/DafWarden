using FluentResults;

namespace DafWarden.Domain.Exceptions;
public class PassphraseEmptyError : Error
{
    private const string ErrorMessage = "passphrase must contain at least one word";

    public PassphraseEmptyError() : base(ErrorMessage) => Metadata.Add("ErrorCode", "1");
}
