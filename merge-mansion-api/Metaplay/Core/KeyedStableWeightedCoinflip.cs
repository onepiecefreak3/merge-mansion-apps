namespace Metaplay.Core
{
    public static class KeyedStableWeightedCoinflip
    {
        public static bool FlipACoin(uint key, uint rollId, int trueWeightPermille = 500)
        {
            key = (uint) (rollId * -0x61c8864f ^ key);
            var step = (key ^ (key >> 16)) * 0x5bd1e995;
            return (step ^ (step >> 16)) * 0x5bd1e995 % 1000 < trueWeightPermille;
        }
    }
}
