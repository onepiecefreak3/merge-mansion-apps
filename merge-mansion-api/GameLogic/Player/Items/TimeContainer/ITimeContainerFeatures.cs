using System;
using Metaplay.Core;

namespace GameLogic.Player.Items.TimeContainer
{
    public interface ITimeContainerFeatures
    {
        bool StoresTime { get; set; }

        MetaDuration DefaultInitialTime { get; set; }

        TimeContainerMergeBehavior MergeBehavior { get; set; }
    }
}