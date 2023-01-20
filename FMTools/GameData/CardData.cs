﻿using System;

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
            Attack =   10 * ((basicCardData & (int)CardBasicDataMask.Attack) >> (int)CardBasicDataOffset.Attack);
            Defense =  10 * ((basicCardData & (int)CardBasicDataMask.Defense) >> (int)CardBasicDataOffset.Defense);
            GuardianStar2 = ((basicCardData & (int)CardBasicDataMask.GuardianStar2) >> (int)CardBasicDataOffset.GuardianStar2);
            GuardianStar1 = ((basicCardData & (int)CardBasicDataMask.GuardianStar1) >> (int)CardBasicDataOffset.GuardianStar1);
            Type =          ((basicCardData & (int)CardBasicDataMask.GuardianStar1) >> (int)CardBasicDataOffset.GuardianStar1);

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
}