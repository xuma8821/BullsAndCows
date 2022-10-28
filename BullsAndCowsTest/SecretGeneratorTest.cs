using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class SecretGeneratorTest
    {
        [Fact]
        public void Should_return_secret_with_4_characters_when_generate_secret()
        {
            var secretGenerator = new SecretGenerator();
            var secret = secretGenerator.GenerateSecret();
            Assert.Equal(4, secret.Split(" ").Length);
        }

    }
}
