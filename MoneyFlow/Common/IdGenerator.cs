using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snowflake;
namespace MoneyFlow.Common
{
    /// <summary>
    /// 分布式id生成器 Twitter  Snowflake 算法
    /// </summary>
    public class IdGenerator
    {
        private static readonly IdWorker worker = new IdWorker(1,1,0);//workerId:程序运行所在机器标识,dataCenterId:机器所属数据中心标识，sequence:起始序号。这里先写死workerid,datacenterid，实际使用需动态配置

        public static long GetId() {
            return worker.NextId();
        }
    }
}