﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Player;

namespace Metaplay.GameLogic.Config
{
    [MetaSerializableDerived(1008)]
    public class PlayerPropertyMergeGoalVisible : TypedPlayerPropertyIdCustom<bool, HotspotId>
    {
    }
}