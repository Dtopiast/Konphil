using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Konphil.Core.Models
{
    public enum Market
    {
        [Description("Walmart")] Walmart,
        [Description("Chedraui")] Chedraui,
        [Description("Soriana")] Soriana,
        [Description("All")] All,

    }
}
