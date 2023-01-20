using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMTools.GameData
{
    internal static class SlugDataLocation
    {
        internal static class Cards
        {
            internal const long BasicDataStart = 0x1C4A44L;
            internal const long LevelAndAttributeDataStart = 0x1C5B33L;
            internal const long NameHeaderStart = 0x1C6002L;
            internal const long NameDataStart = 0x1C0800L;
            internal const long DescriptionHeaderStart = 0x1B0A02L;
            internal const long DescriptionDataStart = 0x1B0800;
        }

        internal static class Duelists
        {
            internal const long NameHeaderStart = 0x1C6652L;
            internal const long NameDataStart = 0x1C0800L;
        }
    }
}
