using DafWarden.Domain.Adapters;

namespace DafWarden.Application;

public class Executor(IPassphraseGenerator passphraseGenerator)
{
    private readonly IPassphraseGenerator _passphraseGenerator = passphraseGenerator;

    public void Execute()
    {
        string? continueGeneration;
        do
        {
            Console.WriteLine("Enter passphrase length as a number.");
            var passphraseLengthString = Console.ReadLine();
            while (!int.TryParse(passphraseLengthString, out _))
            {
                Console.WriteLine("This is not a number, please type a number for your passwordLength.");
                passphraseLengthString = Console.ReadLine();
            }

            int passphraseLength = int.Parse(passphraseLengthString);
            var passwordPhraseResult = _passphraseGenerator.Generate(passphraseLength);
            if (passwordPhraseResult.IsSuccess)
                Console.WriteLine(passwordPhraseResult.Value);
            else
                Console.WriteLine("Sorry there was an issue, please try again.");

            do
            {
                Console.WriteLine("Do you want to continue (y/n)");
                continueGeneration = Console.ReadLine();
            }
            while (continueGeneration is not "y" and not "Y" and not "n" and not "n");
        } while (continueGeneration is "y" or "Y");


    }
}
