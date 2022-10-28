using System;

namespace BullsAndCows
{
  public class BullsAndCowsGame
  {
    private readonly SecretGenerator secretGenerator;
    private string secret;

    public BullsAndCowsGame(SecretGenerator secretGenerator)
    {
      this.secretGenerator = secretGenerator;
      secret = secretGenerator.GenerateSecret();
    }

    public bool CanContinue => true;

    public string Guess(string guess)
    {
      int countBulls = CountBulls(guess);

      return $"{countBulls}A0B";
    }

    private int CountBulls(string guess)
    {
      var guessDigits = guess.Split(" ");
      var secretDigits = secret.Split(" ");
      int countBulls = 0;
      for (int index = 0; index < secretDigits.Length; index++)
      {
        if (guessDigits[index] == secretDigits[index])
        {
          countBulls++;
        }
      }

      return countBulls;
    }
  }
}