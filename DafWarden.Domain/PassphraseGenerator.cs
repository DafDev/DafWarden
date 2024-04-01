using DafWarden.Domain.Adapters;
using DafWarden.Domain.Exceptions;
using FluentResults;

namespace DafWarden.Domain;

public class PassphraseGenerator(IPassphraseFragementRepository repository) : IPassphraseGenerator
{
    private readonly IPassphraseFragementRepository _repository = repository;
    private const int _maxNumberOfThrows = 5;
    private readonly Random _random = new();

    public Result<string> Generate(int passwordLength, bool addDigitOrSpecialCharacter = false)
    {
        Result<IEnumerable<string>> passphraseFragmentsResult = GetFragments(passwordLength) ;
        if (passphraseFragmentsResult.IsFailed)
            return Result.Fail<string>(passphraseFragmentsResult.Errors);

        List<string> passphraseFragments = passphraseFragmentsResult.Value.ToList();
        if (addDigitOrSpecialCharacter)
        {
            passphraseFragmentsResult = AddDigitOrSpecialCharacterToPassphrase(passphraseFragments);
            return passphraseFragmentsResult.IsSuccess
                ? Result.Ok(string.Join(" ", passphraseFragmentsResult.Value))
                : Result.Fail<string>(passphraseFragmentsResult.Errors);
        }

        return Result.Ok(string.Join(" ", passphraseFragments));
    }

    private Result<IEnumerable<string>> GetFragments(int passwordLength)
    {
        if (passwordLength <= 0)
            return Result.Fail<IEnumerable<string>>(new PassphraseEmptyError());
        List<string> passphraseFragments = [];
        for (int i = 0; i < passwordLength; i++)
        {
            var fragmentId = GenerateFragmentId();
            var passphraseFragment = _repository.GetPassphraseFragment(fragmentId);
            if (passphraseFragment.IsFailed)
                return Result.Fail<IEnumerable<string>>(passphraseFragment.Errors);
            passphraseFragments.Add(passphraseFragment.Value);
        }
        return passphraseFragments;
    }

    private int GenerateFragmentId()
    {
        List<int> diceThrowsList = GenerateThrowingSerie(_maxNumberOfThrows); 

        return int.Parse(string.Join(string.Empty, diceThrowsList));
    }

    private List<int> GenerateThrowingSerie(int numberOfThrow)
    {
        List<int> diceThrowsList = [];
        for (int i = 0; i < numberOfThrow; i++)
            diceThrowsList.Add(_random.Next(1, 7)); // returns an integer between 1 and 6
        return diceThrowsList;
    }

    private Result<IEnumerable<string>> AddDigitOrSpecialCharacterToPassphrase(List<string> passphraseFragments)
    {
        int wordToReplaceId = _random.Next(0, passphraseFragments.Count);
        string wordToReplace = passphraseFragments[wordToReplaceId];
        int charToReplaceId = _random.Next(0, wordToReplace.Length);
        int specialCharacterId = int.Parse(string.Join(string.Empty, GenerateThrowingSerie(2)));
        var specialCharacterResult = _repository.GetRandomDigitOrSpecialCharacter(specialCharacterId);
        if (specialCharacterResult.IsFailed)
            return Result.Fail<IEnumerable<string>>(specialCharacterResult.Errors);

        wordToReplace = wordToReplace.Replace(wordToReplace[charToReplaceId], specialCharacterResult.Value.First());
        passphraseFragments[wordToReplaceId] = wordToReplace;
        return passphraseFragments;
    }
}
