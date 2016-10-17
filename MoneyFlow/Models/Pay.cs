using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyFlow.Models
{
    public class Pay
    {
        public long Id { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 支出说明
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 支出时间
        /// </summary>
        public DateTime PayDate { get; set; }

    }
}