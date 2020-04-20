using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDWork.Models
{
    public class GainLossViewModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "收入/支出")]
        public string gain_or_loss { get; set; }
        [Display(Name = "项目")]
        public string item { get; set; }
        [Display(Name = "金额")]
        public double price { get; set; }
        [Display(Name = "日期")]
        public string date { get; set; }
    }
}
