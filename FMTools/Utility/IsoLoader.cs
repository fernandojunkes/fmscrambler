using FMTools.Disc;

namespace FMTools.Utility
{
    public class IsoLoader
    {
        /*
        public SlugData Slug { get; set; }
        */
        public IsoLoader()
        {
        }


        public void LoadIso(string isoPath)
        {
            
            BinChunk chunker = new BinChunk();
            chunker.ExtractBin(isoPath);
        }
    }
}