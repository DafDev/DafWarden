using DafWarden.Domain;
using DafWarden.Domain.Adapters;
using DafWarden.Domain.Exceptions;
using FluentAssertions;
using Moq;

namespace DafWarden.Tests;

public class DomainTests
{
    private readonly Mock<IPassphraseFragementRepository> _repository = new();
    private readonly PassphraseGenerator  _sut;

    public DomainTests()
    {
        SetupRepository();    
        _sut = new(_repository.Object);
    }

    [Fact]
    public void GivenLengthGreaterThanZeroWhenGenerateShouldReturnPaswordWithNWords()
    {
        // Given
        var expected = "ciao ciao";
        var demandedLength = 2;

        // When
        var actual = _sut.Generate(demandedLength);

        // Should
        actual.IsSuccess.Should().BeTrue();
        actual.Value.Should().Be(expected);
    }

    [Fact]
    public void GivenLengthZeroWhenGenerateShouldReturnFailedResult()
    {
        // When
        var actual = _sut.Generate(0);

        // Should
        actual.IsFailed.Should().BeTrue();
        actual.HasError(error => error.GetType() == typeof(PassphraseEmptyError)).Should().BeTrue();
    }

    private void SetupRepository() => _repository.Setup(repo => repo.GetPassphraseFragment(It.IsAny<int>())).Returns("ciao");
}