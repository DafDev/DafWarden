using DafWarden.Domain;
using DafWarden.Domain.Adapters;
using FluentAssertions;
using Moq;

namespace DafWarden.Tests;

public class DomainTests
{
    private readonly Mock<IPasswordFragementRepository> _repository = new();
    private readonly PasswordGenerator  _sut;

    public DomainTests()
    {
        SetupRepository();    
        _sut = new(_repository.Object);
    }

    [Fact]
    public async Task GivenLengthNReturnsWhenGenerateShoulReturnPaswordWithNWords()
    {
        // Given
        var expected = "ciao ciao";
        var demandedLength = 2;

        // When
        var actual = await _sut.Generate(demandedLength);

        // Should
        actual.Should().Be(expected);
    }


    private void SetupRepository() => _repository.Setup(repo => repo.GetPasswordFragment(It.IsAny<int>())).ReturnsAsync("ciao");
}