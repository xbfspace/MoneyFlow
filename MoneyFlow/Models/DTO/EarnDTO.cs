using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyFlow.Models.DTO
{
    /// <summary>
    /// 使用新增dto的方式接收页面传递的值，以便后面进行服务端model校验
    /// </summary>
    public class EarnDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(0, 1000000, ErrorMessage = "范围0~1000")]
        public decimal Amount { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime EarnDate { get; set; }
    }
}