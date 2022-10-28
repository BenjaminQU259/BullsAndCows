using BullsAndCows;
using Moq;
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
  }
}
