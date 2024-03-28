namespace DafWarden.Domain.Adapters;
public interface IPasswordFragementRepository
{
    Task<string> GetPasswordFragment(int FragementId);
}
