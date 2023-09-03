using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAProjects.EuchreScorer
{
    public enum Suite
    {
        SPADES,
        CLUBS,
        HEARTS,
        DIAMONDS
    }

    public enum Face
    {
        EIGHT = 8,
        NINE = 9,
        JACK = 10,
        QUEEN = 11,
        KING = 12,
        ACE = 13
    }

    public class Card
    {
        public Face Face { get; set; }

        public Suite Suite { get; set; }
    }
}
