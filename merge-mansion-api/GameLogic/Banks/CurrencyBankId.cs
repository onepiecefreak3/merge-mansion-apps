using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Banks
{
    [MetaSerializable]
    public class CurrencyBankId : StringId<CurrencyBankId>
    {
        public static CurrencyBankId DefaultId;
        public CurrencyBankId()
        {
        }
    }
}