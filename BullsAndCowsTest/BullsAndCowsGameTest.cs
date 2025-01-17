using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
  public class BullsAndCowsGameTest
  {
    [Fact]
    public void Should_create_BullsAndCowsGame()
    {
      var secretGenerator = new SecretGenerator();
      var game = new BullsAndCowsGame(secretGenerator);
      Assert.NotNull(game);
      Assert.True(game.CanContinue);
    }

    [Fact]
    public void Should_return_4A0B_when_guess_given_guess_digits_are_same_as_secret()
    {
      // given
      var mockSecretGenerator = new Mock<SecretGenerator>();
      mockSecretGenerator.Setup(_ => _.GenerateSecret()).Returns("1 2 3 4");
      var game = new BullsAndCowsGame(mockSecretGenerator.Object);
      //when
      string guessResult = game.Guess("1 2 3 4");
      //then
      Assert.Equal("4A0B", guessResult);
    }

    [Theory]
    [InlineData("1 2 3 4", "1 2 5 6")]
    [InlineData("1 2 3 4", "0 2 3 6")]
    [InlineData("1 2 3 4", "0 5 3 4")]
    public void Should_return_2A0B_when_guess_given_guess_having_only_2_digits_same_position_as_secret(string secret, string guess)
    {
      // given
      var mockSecretGenerator = new Mock<SecretGenerator>();
      mockSecretGenerator.Setup(_ => _.GenerateSecret()).Returns(secret);
      var game = new BullsAndCowsGame(mockSecretGenerator.Object);
      //when
      string guessResult = game.Guess(guess);
      //then
      Assert.Equal("2A0B", guessResult);
    }

    [Theory]
    [InlineData("1 2 3 4", "1 5 2 6")]
    [InlineData("1 2 3 4", "5 2 4 6")]
    [InlineData("1 2 3 4", "5 3 6 4")]
    public void Should_return_1A1B_when_guess_given_guess_having_1_digit_same_position_and_1_digit_same_number_as_secret(string secret, string guess)
    {
      // given
      var mockSecretGenerator = new Mock<SecretGenerator>();
      mockSecretGenerator.Setup(_ => _.GenerateSecret()).Returns(secret);
      var game = new BullsAndCowsGame(mockSecretGenerator.Object);
      //when
      string guessResult = game.Guess(guess);
      //then
      Assert.Equal("1A1B", guessResult);
    }

    [Theory]
    [InlineData("1 2 3 4", "1 4 2 3")]
    [InlineData("1 2 3 4", "4 2 1 3")]
    public void Should_return_1A1B_when_guess_given_guess_having_1_digit_same_position_and_3_digit_same_number_as_secret(string secret, string guess)
    {
      // given
      var mockSecretGenerator = new Mock<SecretGenerator>();
      mockSecretGenerator.Setup(_ => _.GenerateSecret()).Returns(secret);
      var game = new BullsAndCowsGame(mockSecretGenerator.Object);
      //when
      string guessResult = game.Guess(guess);
      //then
      Assert.Equal("1A3B", guessResult);
    }

    [Theory]
    [InlineData("1 2 3 4", "5 6 7 8")]
    public void Should_return_0A0B_when_guess_given_guess_having_0_digit_same_position_and_0_digit_same_number_as_secret(string secret, string guess)
    {
      // given
      var mockSecretGenerator = new Mock<SecretGenerator>();
      mockSecretGenerator.Setup(_ => _.GenerateSecret()).Returns(secret);
      var game = new BullsAndCowsGame(mockSecretGenerator.Object);
      //when
      string guessResult = game.Guess(guess);
      //then
      Assert.Equal("0A0B", guessResult);
    }
  }
}
