namespace DafWarden.Domain.Adapters;
public interface IPassphraseFragementRepository
{
    string GetPassphraseFragment(int FragementId);
}
