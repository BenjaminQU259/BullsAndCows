using System;
using System.Collections.Generic;

namespace BullsAndCows
{
  public class SecretGenerator
  {
    private readonly Random random;

    public SecretGenerator()
    {
      random = new Random();
    }

    public SecretGenerator(Random random)
    {
      this.random = random;
    }

    public virtual string GenerateSecret()
    {
      var secretDigits = new List<int>();

      while (secretDigits.Count < 4)
      {
        var digit = random.Next(10);
        if (!secretDigits.Contains(digit))
        {
          secretDigits.Add(digit);
        }
      }

      return string.Join(" ", secretDigits);
    }
  }
}