using DafWarden.Domain.Adapters;
using System.Reflection;

namespace DafWarden.Infrastructure;

public class PassphraseFragmentRepository : IPassphraseFragementRepository
{
    private readonly Dictionary<int, string> _inMemoryFragments;
    public PassphraseFragmentRepository()
    {
        var folder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        var filter = "diceware.csv";
        var pathFile = Directory.GetFiles(folder, filter);
        _inMemoryFragments = File.ReadLines(pathFile.First())
            .Select(line => line.Split(','))
            .ToDictionary(line => int.Parse(line[0]), line => line[1]);
    }

    public string  GetPassphraseFragment(int FragementId) => _inMemoryFragments[FragementId];
}

public record PassphraseFragement(int FragmentId, string Fragment);