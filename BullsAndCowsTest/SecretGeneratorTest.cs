using BullsAndCows;
using Moq;
using System;
using Xunit;

namespace BullsAndCowsTest
{
  public class SecretGeneratorTest
  {
    [Fact]
    public void Should_return_4_length_when_generate_secret()
    {
      // given
      var secretGenerator = new SecretGenerator();
      // when
      var secret = secretGenerator.GenerateSecret();
      // then
      Assert.Equal(4, secret.Split(" ").Length);
    }

    [Fact]
    public void Should_return_4_different_digits_string_when_generate_secret()
    {
      // given
      var mockRandom = new Mock<Random>();
      mockRandom.SetupSequence(_ => _.Next(It.IsAny<int>())).Returns(1).Returns(1).Returns(1).Returns(5).Returns(4).Returns(5).Returns(3);
      var secretGenerator = new SecretGenerator(mockRandom.Object);
      // when
      var secret = secretGenerator.GenerateSecret();
      // then
      Assert.Equal("1 5 4 3", secret);
    }
  }
}
