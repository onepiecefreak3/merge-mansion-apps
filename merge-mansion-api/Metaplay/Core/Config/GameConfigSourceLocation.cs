namespace Metaplay.Core.Config
{
    public abstract class GameConfigSourceLocation
    {
        public GameConfigSourceInfo SourceInfo;
        protected GameConfigSourceLocation(GameConfigSourceInfo sourceInfo)
        {
        }
    }
}