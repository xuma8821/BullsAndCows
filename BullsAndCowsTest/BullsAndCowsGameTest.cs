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
        public void Should_return_4A0B_when_guess_given_the_guess_digits_are_same_as_secret()
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns("1 2 3 4");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            var guessResult = game.Guess("1 2 3 4");
            //then
            Assert.Equal("4A0B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 2 5 6")]
        [InlineData("1 2 3 4", "5 2 3 6")]
        public void Should_return_2A0B_when_guess_given_the_guess_digits_having_2_digits_have_the_same_value_and_position_with_secret(string secret, string guessDigits)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            var guessResult = game.Guess(guessDigits);
            //then
            Assert.Equal("2A0B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 2 4 6")]
        [InlineData("1 2 3 4", "4 2 3 6")]
        public void Should_return_2A1B_when_guess_given_the_guess_digits_having_2_digits_have_the_same_value_and_position_with_secret_and_1_digit_have_the_same_value_but_diff_pos(string secret, string guessDigits)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            var guessResult = game.Guess(guessDigits);
            //then
            Assert.Equal("2A1B", guessResult);
        }
    }
}
