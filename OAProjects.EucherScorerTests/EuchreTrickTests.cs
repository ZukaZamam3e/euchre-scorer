using OAProjects.EuchreScorer;
using Xunit;

namespace OAProjects.EucherScorerTests
{
    public class EuchreTrickTests
    {
        EuchreTrickCardScorer scorer;
        Card card;

        public EuchreTrickTests()
        {
            scorer = new EuchreTrickCardScorer();
            card = new Card();
        }


        [Theory]
        [InlineData(Suite.HEARTS, Suite.CLUBS, Suite.CLUBS, Face.NINE, Scores.TRICK_NINE)]
        [InlineData(Suite.SPADES, Suite.CLUBS, Suite.CLUBS, Face.JACK, Scores.LEFT_BOWER)]
        [InlineData(Suite.DIAMONDS, Suite.CLUBS, Suite.CLUBS, Face.JACK, Scores.TRICK_JACK)]
        [InlineData(Suite.CLUBS, Suite.DIAMONDS, Suite.CLUBS, Face.JACK, Scores.RIGHT_BOWER)]
        public void ScoreTest(Suite roundTrump, Suite trickLead, Suite cardSuite, Face cardFace, Scores expected)
        {
            // Arrange
            card.Suite = cardSuite;
            card.Face = cardFace;

            // Act
            Scores actual = scorer.GetCardValue(roundTrump, trickLead, card);

            // Assert
            Assert.True(roundTrump != trickLead, "Round Trump and Trick Lead can never be the same.");
            Assert.Equal(expected, actual);
        }
    }
}