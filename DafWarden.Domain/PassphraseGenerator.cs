using DafWarden.Domain.Adapters;
using DafWarden.Domain.Exceptions;
using FluentResults;

namespace DafWarden.Domain;

public class PassphraseGenerator(IPassphraseFragementRepository repository) : IPassphraseGenerator
{
    private readonly IPassphraseFragementRepository _repository = repository;
    private const int _maxNumberOfThrows = 5;
    private readonly Random _random = new();

    public Result<string> Generate(int passwordLength)
    {
        if (passwordLength <= 0) 
            return Result.Fail<string>(new PassphraseEmptyError());
        List<string> passphraseFragments = [];
        for (int i = 0; i < passwordLength; i++)
        {
            var fragmentId = GenerateFragmenId();
            passphraseFragments.Add(_repository.GetPassphraseFragment(fragmentId));
        }
        return Result.Ok(string.Join(" ", passphraseFragments));
    }
    private int GenerateFragmenId()
    {
        List<int> diceThrowsList = [];
        for (int i = 0; i < _maxNumberOfThrows; i++)
            diceThrowsList.Add(_random.Next(1, 7)); // returns an integer between 1 and 6

        return int.Parse(string.Join(string.Empty, diceThrowsList));
    }
}
