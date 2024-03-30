using DafWarden.Domain.Adapters;

namespace DafWarden.Application;

public class Executor(IPassphraseGenerator passphraseGenerator)
{
    private readonly IPassphraseGenerator _passphraseGenerator = passphraseGenerator;

    public void Execute()
    {
        Console.WriteLine("Enter passphrase length as a number.");
        var passphraseLengthString = Console.ReadLine();
        while (!int.TryParse(passphraseLengthString, out _))
        {
            Console.WriteLine("This is not a number, please type a number for your passwordLength.");
            passphraseLengthString = Console.ReadLine();
        }

        int passphraseLength  = int.Parse(passphraseLengthString);
        var passwordPhraseResult = _passphraseGenerator.Generate(passphraseLength);
        if (passwordPhraseResult.IsSuccess)
            Console.WriteLine(passwordPhraseResult.Value);
        else
            Console.WriteLine("Sorry there was an issue, please try again.");
    }
}
