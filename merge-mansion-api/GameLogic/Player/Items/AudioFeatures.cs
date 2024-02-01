using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items
{
    [MetaSerializable]
    public class AudioFeatures
    {
        public static AudioFeatures NoAudio;
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ActivationAutoSfx { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ActivationManualSfx { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string CollectableSfx { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string SinkProgressSfx { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string SinkCompletedSfx { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string SelectSfx { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string SpawnSfx { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public string MergeSfx { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public string DecaySfx { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public string FishingSfx { get; set; }

        private AudioFeatures()
        {
        }

        public AudioFeatures(string activationAutoSfx, string activationManualSfx, string collectableSfx, string sinkProgressSfx, string sinkCompletedSfx, string selectSfx, string spawnSfx, string mergeSfx, string decaySfx, string fishingSfx)
        {
        }
    }
}