using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay
{
    public enum Currencies
    {
        None = 0,
        Coins = 1,
        Experience = 2,
        Diamonds = 3,
        [Obsolete]
        Screws = 4,
        Energy = 5,
        EventCurrency = 6
    }
}
