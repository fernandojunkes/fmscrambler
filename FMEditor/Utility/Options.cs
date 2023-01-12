using FMTools.Models;

namespace FMTools.Utility
{
    public class Options
    {
        /// <summary>
        /// Options (true / false)
        /// </summary>
        public bool RandomFusions { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool GlitchFusions { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool RandomAttributes { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool RandomGuardianStars { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool RandomCardDrops { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool RandomTypes { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool RandomStarchips { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool GlitchGuardianStars { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool RandomDecks { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool GlitchAttributes { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool RandomEquips { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool HighId { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool RandomAtkdef { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public bool Spoiler { get; set; } = true;

        /// <summary>
        /// Count of Cards as Integer
        /// </summary>
        public int CardCount { get; set; } = 722;

        /// <summary>
        /// Path to the Game Folder
        /// </summary>
        public string GameBinPath { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SlusPath { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WaPath { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string IsoPath { get; set; } = string.Empty;

        public string RandomizerFileName { get; set; } = string.Empty;
    }
}