using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var guessDigits = guess.Split(' ');
            var secretDigits = secret.Split(' ');
            int countBulls = CountBulls(guessDigits, secretDigits);

            return $"{countBulls}A0B";
        }

        private static int CountBulls(string[] guessDigits, string[] secretDigits)
        {
            return secretDigits.Where((t, index) => t == guessDigits[index]).Count();
        }
    }
}