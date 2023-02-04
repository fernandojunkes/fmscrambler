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

        public ReadOnlySpan<DuelistData> Duelists => duelists;
        private DuelistData[] duelists;
        public SlugData()
        {
            cards = new CardData[GameConstants.NormalNumberOfCards];
            duelists = new DuelistData[GameConstants.NumberOfDuelists];
        }
        internal void AddCard(int i, CardData cardData)
        {
            cards[i] = cardData;
        }

        internal void AddDuelist(int i, DuelistData duelistData)
        {
            duelists[i] = duelistData;
        }
    }
}
