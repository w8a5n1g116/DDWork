using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDWork.Models
{
    public class TransportationViewModel
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "供应商")]
        public string supply_name { get; set; }
        [Display(Name = "原料")]
        public string material_name { get; set; }
        [Display(Name = "顾客")]
        public string customer_name { get; set; }
        
        [Display(Name = "车牌号")]
        public string car_no { get; set; }
        [Display(Name = "司机")]
        public string car_name { get; set; }
        [Display(Name = "司机电话")]
        public string car_phone { get; set; }
        [Display(Name = "发货日期")]
        public string start_date { get; set; }
        [Display(Name = "到场日期")]
        public string end_date { get; set; }
        
        [Display(Name = "出厂吨位")]
        public double material_weight { get; set; }
        [Display(Name = "实收吨位")]
        public double carriage_weight { get; set; }
        [Display(Name = "原料单价")]
        public double material_unit_price { get; set; }
        [Display(Name = "运输单价")]
        public double carriage_unit_price { get; set; }
        [Display(Name = "原料总价")]
        public double material_count_price { get; set; }
        [Display(Name = "应付运费")]
        public double carriage_should_count_price { get; set; }
        [Display(Name = "实付运费")]
        public double carriage_count_price { get; set; }
        [Display(Name = "扣手续费")]
        public double service_charge { get; set; }
        [Display(Name = "付款日期")]
        public string pay_time { get; set; }

        [Display(Name = "合伙人")]
        public string shareholder_name { get; set; }
        
        
        
    }
}
