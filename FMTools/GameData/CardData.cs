using System;

namespace FMTools.GameData
{
    internal class CardData
    {
        private enum CardBasicDataMask
        {
            Attack =                  0b00000000000000000000000111111111,
            Defense =                 0b00000000000000111111111000000000,
            GuardianStar2 =           0b00000000001111000000000000000000,
            GuardianStar1 =           0b00000011110000000000000000000000,
            Type =                    0b01111100000000000000000000000000,
            Unknown =  unchecked((int)0b10000000000000000000000000000000),
        }

        private enum CardBasicDataOffset
        {
            Attack = 0,
            Defense = 9,
            GuardianStar2 = 18,
            GuardianStar1 = 22,
            Type = 26
        }

        public CardData(int basicCardData, byte cardLevelAndAttribute)
        {
            Attack =                      10 * ((basicCardData & (int)CardBasicDataMask.Attack) >> (int)CardBasicDataOffset.Attack);
            Defense =                     10 * ((basicCardData & (int)CardBasicDataMask.Defense) >> (int)CardBasicDataOffset.Defense);
            SecondGuardianStar = (GuardianStar)((basicCardData & (int)CardBasicDataMask.GuardianStar2) >> (int)CardBasicDataOffset.GuardianStar2);
            FirstGuardianStar =  (GuardianStar)((basicCardData & (int)CardBasicDataMask.GuardianStar1) >> (int)CardBasicDataOffset.GuardianStar1);
            Type =                             ((basicCardData & (int)CardBasicDataMask.GuardianStar1) >> (int)CardBasicDataOffset.GuardianStar1);

            Level = cardLevelAndAttribute & 0xF;
            Attribute = cardLevelAndAttribute >> 4 & 0xF;
        }

        public int Attack { get; }
        public int Defense { get; }
        public GuardianStar SecondGuardianStar { get; }
        public GuardianStar FirstGuardianStar { get; }
        public int Type { get; }
        public int Level { get; }
        public int Attribute { get; }
    }

    internal enum GuardianStar
    {
        Mars = 1,
        Jupiter = 2,
        Saturn = 3,
        Uranus = 4,
        Pluto = 5,
        Neptune = 6,
        Mercury = 7,
        Sun = 8, 
        Moon = 9,
        Venus = 10

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
