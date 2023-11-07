using Metaplay.Core.Model;
using Metaplay.Core.Player;
using Metaplay.Core.Math;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1037)]
    public class PlayerPropertyModeLastNTransactions : TypedPlayerPropertyId<F64>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int Transactions { get; set; }
        public override string DisplayName { get; }

        public PlayerPropertyModeLastNTransactions()
        {
        }

        public PlayerPropertyModeLastNTransactions(int transactions)
        {
        }
    }
}