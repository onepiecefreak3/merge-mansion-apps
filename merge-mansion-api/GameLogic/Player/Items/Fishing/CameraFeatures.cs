using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    public class CameraFeatures
    {
        public static CameraFeatures NoCameraFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsCamera { get; set; }

        private CameraFeatures()
        {
        }

        public CameraFeatures(bool isCamera)
        {
        }
    }
}