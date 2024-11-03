using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum OrderStatusEnum
    {
        [Description("Failed")]
        Failed = 0,

        [Description("Pending")]
        Pending = 1,

        [Description("Successful")]
        Successful = 2
    }
}
