using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottory
{
    class Summary_CustomerInfo
    {
        public string sumPrice { get; set; }
        public string sumDiscount { get; set; }
        public string sumWinPrice { get; set; }
        public string sumNetPrice { get; set; }
    }
    class Summary_Buying
    {
        public string sumPrice { get; set; }
        public string sumdiscount { get; set; }
    }
    class Summary_Pay
    {
        public string sumWinPrice { get; set; }
        public string sumPayPrice { get; set; }
    }
}
