using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDWork.Models
{
    public class ExpenditrueViewModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "合伙人")]
        public string sharehloder_name { get; set; }
        [Display(Name = "原料费用")]
        public double material_count_price { get; set; }
        [Display(Name = "运输费用")]
        public double carriage_count_price { get; set; }
        [Display(Name = "车牌号")]
        public string car_no { get; set; }
        [Display(Name = "日期")]
        public string date { get; set; }
    }
}
