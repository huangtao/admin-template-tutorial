using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapAdmin.Models
{
    public class FkPay
    {
        public String TradeNo { get; set; }
        public String UserId { get; set; }
        public int PayPrice { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class FkDayPay
    {
        public DateTime CreateDate { get; set; }
        public int SumPrice { get; set; }
    }
}
