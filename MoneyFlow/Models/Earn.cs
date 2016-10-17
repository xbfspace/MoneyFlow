using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyFlow.Models
{
    public class Earn
    {
        public long Id { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 收入说明
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 收入时间
        /// </summary>
        public DateTime EarnDate { get; set; }

    }
}