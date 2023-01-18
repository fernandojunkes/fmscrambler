using System;

namespace FMTools.GameData
{
    internal class CardData
    {
        public CardData(int basicCardData, byte cardLevelAndAttribute)
        {
            Attack = (basicCardData & 0x1FF) * 10;
            Defense = (basicCardData >> 9 & 0x1FF) * 10;
            GuardianStar2 = basicCardData >> 18 & 0xF;
            GuardianStar1 = basicCardData >> 22 & 0xF;
            Type = basicCardData >> 26 & 0x1F;

            Level = cardLevelAndAttribute & 0xF;
            Attribute = cardLevelAndAttribute >> 4 & 0xF;
        }

        public int Attack { get; }
        public int Defense { get; }
        public int GuardianStar2 { get; }
        public int GuardianStar1 { get; }
        public int Type { get; }
        public int Level { get; }
        public int Attribute { get; }
    }

    internal static class SlugPositions
    {
        internal const long CardLevelAndAttributes = 0x1C5B33;
        internal const long BasicCardData = 0x1C4A44;
        internal const long CardNameHeader = 0x1C6002;
        internal const long CardDescriptionHeader = 0x1B0A02;
        internal const long CardTexts = 0x1C0800;
        internal const long DuelistNameHeader = 0x1C6652;
    }
}
