using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDWork.Models
{
    public class ShareholderViewModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "合伙人")]
        public string shareholder_name { get; set; }
        [Display(Name = "支出总额")]
        public double out_count_price { get; set; }
        [Display(Name = "平均支出")]
        public double average_count_price { get; set; }
        [Display(Name = "差额")]
        public double difference_count_price { get; set; }
    }
}
