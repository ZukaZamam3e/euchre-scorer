using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAProjects.EuchreScorer
{
    public enum Scores
    {
        RIGHT_BOWER = 13,
        LEFT_BOWER = 12,
        TRUMP_ACE = 11,
        TRUMP_KING = 10,
        TRUMP_QUEEN = 9,
        TRUMP_NINE = 8,
        TRUMP_EIGHT = 7,
        TRICK_ACE = 6,
        TRICK_KING = 5,
        TRICK_QUEEN = 4,
        TRICK_JACK = 3,
        TRICK_NINE = 2,
        TRICK_EIGHT = 1,
        OFF_SUITE = 0
    }

    public class EuchreTrickCardScorer
    {
        Suite GetRightBowerSuite(Suite suite) => suite switch
        {
            Suite.SPADES => Suite.CLUBS,
            Suite.CLUBS => Suite.SPADES,
            Suite.HEARTS => Suite.DIAMONDS,
            Suite.DIAMONDS => Suite.HEARTS,
            _ => throw new ArgumentOutOfRangeException(nameof(suite), $"Not expected suite value: {suite}")
        };

        public Scores GetCardValue(Suite roundTrump, Suite trickLead, Card card)
        {
            if (card.Suite == roundTrump)
            {
                if (card.Face == Face.JACK)
                    return Scores.RIGHT_BOWER;
                else
                    return (Scores)card.Face - 2;
            }
            else if (card.Suite == GetRightBowerSuite(roundTrump)
                && card.Face == Face.JACK)
                return Scores.LEFT_BOWER;
            else if (card.Suite == trickLead)
                return (Scores)card.Face - 7;
            else
                return Scores.OFF_SUITE;
        }
    }
}
