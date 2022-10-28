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
            int sameValuesCount = guessDigits.Where((t, index) => secretDigits.Contains(t)).Count();
            int countBulls = CountBulls(guessDigits, secretDigits);
            int countCows = sameValuesCount - countBulls;

            return $"{countBulls}A{countCows}B";
        }

        private static int CountBulls(string[] guessDigits, string[] secretDigits)
        {
            return secretDigits.Where((t, index) => t == guessDigits[index]).Count();
        }
    }
}