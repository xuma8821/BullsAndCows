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
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var guessDigits = guess.Split(' ');
            var secretDigits = secret.Split(' ');
            int countBulls = 0;
            countBulls = CountBulls(guessDigits, secretDigits, countBulls);

            return $"{countBulls}A0B";
        }

        private static int CountBulls(string[] guessDigits, string[] secretDigits, int countBulls)
        {
            for (int i = 0; i < secretDigits.Length; i++)
            {
                if (secretDigits[i] == guessDigits[i])
                {
                    countBulls++;
                }
            }

            return countBulls;
        }
    }
}