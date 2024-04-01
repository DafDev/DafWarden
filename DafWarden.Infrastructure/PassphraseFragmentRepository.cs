using DafWarden.Domain.Adapters;
using DafWarden.Infrastructure.Errors;
using FluentResults;
using System.Reflection;

namespace DafWarden.Infrastructure;

public class PassphraseFragmentRepository : IPassphraseFragementRepository
{
    private readonly Dictionary<int, string> _inMemoryFragments;
    private readonly Dictionary<int, string> _inMemorySpecialCharacters;
    public PassphraseFragmentRepository()
    {
        var folder = string.Concat(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "\\Data");
        var fragmentFilter = "fragment.csv";
        var specialCharacterFilter = "specialCharacters.csv";
        var fragmentPathFile = Directory.GetFiles(folder, fragmentFilter);
        var specialCharacterFile = Directory.GetFiles(folder, specialCharacterFilter);
        _inMemoryFragments = File.ReadLines(fragmentPathFile.First())
            .Select(line => line.Split(','))
            .ToDictionary(line => int.Parse(line[0]), line => line[1]);
        _inMemorySpecialCharacters = File.ReadLines(specialCharacterFile.First())
            .Select(line => line.Split(','))
            .ToDictionary(line => int.Parse(line[0]), line => line[1]);
    }

    public Result<string> GetPassphraseFragment(int fragementId) 
        => _inMemoryFragments.TryGetValue(fragementId, out var fragment)
            ? fragment
            : Result.Fail<string>(new PassphraseFragmentNotFoundError(fragementId));

    public Result<string> GetRandomDigitOrSpecialCharacter(int specialCharacterId)
        => _inMemorySpecialCharacters.TryGetValue(specialCharacterId, out var fragment)
            ? fragment
            : Result.Fail<string>(new PassphraseFragmentNotFoundError(specialCharacterId));
}

public record PassphraseFragement(int FragmentId, string Fragment);