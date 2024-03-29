using DafWarden.Domain.Adapters;
using DafWarden.Domain.Exceptions;
using FluentResults;

namespace DafWarden.Domain;

public class PassphraseGenerator(IPassphraseFragementRepository repository) : IPassphraseGenerator
{
    private readonly IPassphraseFragementRepository _repository = repository;
    private const int _maxNulmberOfThrows = 5;
    private readonly Random _random = new();

    public async Task<Result<string>> Generate(int passwordLength)
    {
        if (passwordLength <= 0) 
            return Result.Fail<string>(new PassphraseEmptyError());
        List<string> passphraseFragments = [];
        for (int i = 0; i < passwordLength; i++)
        {
            var fragmentId = GenerateFragmenId();
            passphraseFragments.Add(await _repository.GetPassphraseFragment(fragmentId));
        }
        return Result.Ok(string.Join(" ", passphraseFragments));
    }
    private int GenerateFragmenId()
    {
        List<int> diceThrowsList = [];
        for (int i = 0; i < _maxNulmberOfThrows; i++)
            diceThrowsList.Add(_random.Next(1, 7)); // returns an integer between 1 and 6

        return int.Parse(string.Join(string.Empty, diceThrowsList));
    }
}
