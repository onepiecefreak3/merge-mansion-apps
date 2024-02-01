using Metaplay.Core.Model;
using Metaplay.Core.Forms;
using System;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public abstract class GameConfigBuildSource
    {
        [MetaFormDontCaptureDefault]
        public abstract string DisplayName { get; }

        protected GameConfigBuildSource()
        {
        }
    }
}