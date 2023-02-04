using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMTools.GameData
{
    public class SlugData
    {
        public ReadOnlySpan<CardData> Cards => cards;
        private CardData[] cards;
        public SlugData()
        {
            cards = new CardData[GameConstants.NormalNumberOfCards];
        }
        internal void AddCard(int i, CardData cardData)
        {
            cards[i] = cardData;
        }
    }
}
