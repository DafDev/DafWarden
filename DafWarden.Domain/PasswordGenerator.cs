using DafWarden.Domain.Adapters;

namespace DafWarden.Domain;

public class PasswordGenerator(IPasswordFragementRepository repository) : IPasswordGenerator
{
    private readonly IPasswordFragementRepository _repository = repository;
    private const int _maxNulmberOfThrows = 5;
    private readonly Random _random = new();

    public async Task<string> Generate(int passwordLength)
    {
        List<string> passwordFragments = [];
        for (int i = 0; i < passwordLength; i++)
        {
            var fragmentId = GenerateFragmenId();
            passwordFragments.Add(await _repository.GetPasswordFragment(fragmentId));
        }
        return string.Join(" ", passwordFragments);
    }
    private int GenerateFragmenId()
    {
        List<int> diceThrowsList = [];
        for (int i = 0; i < _maxNulmberOfThrows; i++)
            diceThrowsList.Add(_random.Next(1, 7)); // returns an integer between 1 and 6

        return int.Parse(string.Join(string.Empty, diceThrowsList));
    }
}
