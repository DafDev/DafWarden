namespace DafWarden.Domain.Adapters;

public interface IPasswordGenerator
{
    Task<string> Generate(int passwordLength);
}