using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Konphil.Models.MarketModels
{
    public enum Market
    {
        [Description("Walmart")] Walmart,
        [Description("Chedraui")] Chedraui,
        [Description("Soriana")] Soriana,
        [Description("All")] All,

    }
}
