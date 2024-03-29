namespace DafWarden.Domain.Adapters;
public interface IPassphraseFragementRepository
{
    Task<string> GetPassphraseFragment(int FragementId);
}
