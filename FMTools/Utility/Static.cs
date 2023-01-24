using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using FMTools.Models;

namespace FMTools.Utility
{
    /// <summary>
    /// Static Variables for application wide useage
    /// </summary>
    public class Static
    {
        /// <summary>
        /// Options (true / false)
        /// </summary>

        public static bool RandomFusions = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool GlitchFusions = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool RandomAttributes = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool RandomGuardianStars = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool RandomCardDrops = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool RandomTypes = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool RandomStarchips = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool GlitchGuardianStars = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool RandomDecks = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool GlitchAttributes = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool RandomEquips = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool HighId = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool RandomAtkdef = false;
        /// <summary>
        /// 
        /// </summary>
        public static bool Spoiler = true;

        /// <summary>
        /// Count of Cards as Integer
        /// </summary>
        public static int CardCount;

        /// <summary>
        /// Card Array for all the 722 Cards in the game
        /// </summary>
        public static Card[] Cards = new Card[722];

        /// <summary>
        /// 
        /// </summary>
        public static Duelist[] Duelist = new Duelist[39];

        /// <summary>
        /// Method to set the Card Count
        /// </summary>
        /// <param name="c">Card Count as Integer</param>
        public static void SetCardCount(int c)
        {
            CardCount = c;
        }

        /// <summary>
        /// Path to the Game Folder
        /// </summary>
        public static string GameBinPath = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public static string SlusPath;
        /// <summary>
        /// 
        /// </summary>
        public static string WaPath;
        /// <summary>
        /// 
        /// </summary>
        public static string IsoPath;

        /// <summary>
        /// 
        /// </summary>
        public static bool UsedIso = false;
        /// <summary>
        /// 
        /// </summary>
        public static string RandomizerFileName;

        /// <summary>
        /// Helper - Dictionary to map chars from data to readable chars
        /// </summary>
        public static Dictionary<byte, char> Dict = new Dictionary<byte, char>();
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<char, byte> RDict = new Dictionary<char, byte>();

        public static void SetOptions(Options options)
        {
            RandomFusions = options.RandomFusions;
            GlitchFusions = options.GlitchFusions;
            RandomAttributes = options.RandomAttributes;
            RandomGuardianStars = options.RandomGuardianStars;
            RandomCardDrops = options.RandomCardDrops;
            RandomTypes = options.RandomTypes;
            RandomStarchips = options.RandomStarchips;
            GlitchGuardianStars = options.GlitchGuardianStars;
            RandomDecks = options.RandomDecks ;
            GlitchAttributes = options.GlitchAttributes;
            RandomEquips = options.RandomEquips;
            HighId = options.HighId;
            RandomAtkdef = options.RandomAtkdef;
            Spoiler = options.Spoiler;
            
            RandomizerFileName = options.RandomizerFileName ?? "FM_Patched";

            CardCount = GlitchFusions ? 1400 : 722;
            IsoPath = options.IsoPath;

        }

        public static void InitCharTable()
        {
            var table_path = @"./CharacterTable.txt";

            if (!File.Exists(table_path))
            {
                throw new Exception("CharacterTable.txt not found! Provide it!");
            }

            StringReader strReader = new StringReader(File.ReadAllText(table_path));

            string input;

            while ((input = strReader.ReadLine()) != null)
            {
                Match match = Regex.Match(input, "^([A-Fa-f0-9]{2})\\=(.*)$");

                if (!match.Success)
                {
                    continue;
                }

                char k1 = Convert.ToChar(match.Groups[2].ToString());
                byte k2 = (byte)int.Parse(match.Groups[1].ToString(), NumberStyles.HexNumber);

                Static.Dict.Add(k2, k1);

                if (!Static.RDict.ContainsKey(k1))
                {
                    Static.RDict.Add(k1, k2);
                }
            }
            //There should be 85 entries otherwise file got corrupted, misread or user manually provided a bad file
            if (Static.Dict.Values.Count != 85)
            {
                throw new Exception("Provided CharacterTable.txt is incorrect or incomplete!");
            }
        }
    }
}