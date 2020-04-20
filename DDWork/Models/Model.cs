using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DDWork.Models;

namespace DDWork.Models
{
    public class Model : DbContext
    {
        public Model(DbContextOptions<Model> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;database=ddwork;uid=root;pwd=;");
        //}

        public DbSet<User> user { get; set; }
        public DbSet<Contract> contract { get; set; }
        public DbSet<Material> material { get; set; }
        public DbSet<MaterialUnitPrice> material_unit_price { get; set; }
        public DbSet<Supply> supply { get; set; }
        public DbSet<Car> car { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Shareholder> shareholder { get; set; }
        public DbSet<Expenditure> expenditure { get; set; }
        public DbSet<Transportation> transportation { get; set; }
        public DbSet<Income> income { get; set; }
        public DbSet<DDWork.Models.ExpenditrueViewModel> ExpenditrueViewModel { get; set; }
        public DbSet<DDWork.Models.GainLossViewModel> GainLossViewModel { get; set; }
        public DbSet<DDWork.Models.TransportationViewModel> TransportationViewModel { get; set; }
        public DbSet<DDWork.Models.ShareholderViewModel> ShareholderViewModel { get; set; }
    }

    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name ="用户名")]
        public string name { get; set; }
        [Display(Name = "权限")]
        public string privileges { get; set; }
        public string ding_id { get; set; }
        [Display(Name = "创建时间")]
        public string create_time { get; set; }
    }

    public class Contract
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "重量")]
        public double weight { get; set; }
        [Display(Name = "开票重量")]
        public double print_weight { get; set; }
        [Display(Name = "开票金额")]
        public double print_price { get; set; }
        [Display(Name = "罚款")]
        public double fine { get; set; }
        [Display(Name = "合同总价")]
        public double contract_price { get; set; }
        [Display(Name = "交货日期")]
        public string delivery_date { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Material material { get; set; }
        [Display(Name = "创建时间")]
        public string create_time { get; set; }

    }

    public class Material
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "原料名称")]
        public string name { get; set; }
        [Display(Name = "单位")]
        public string unit { get; set; }
        [Display(Name = "创建时间")]
        public string create_time { get; set; }
    }

    public class MaterialUnitPrice
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "单价")]
        public double price { get; set; }
        [Display(Name = "创建时间")]
        public string create_time { get; set; }
        public virtual Material material { get; set; }
    }

    public class Supply
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "供应商名称")]
        public string name { get; set; }
        [Display(Name = "地址")]
        public string address { get; set; }
        [Display(Name = "联系人")]
        public string contact { get; set; }
        [Display(Name = "电话")]
        public string phone { get; set; }
        [Display(Name = "创建时间")]
        public string create_time { get; set; }

    }

    public class Car
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "司机名称")]
        public string name { get; set; }
        [Display(Name = "车牌号")]
        public string car_no { get; set; }
        [Display(Name = "载重")]
        public string car_load { get; set; }
        [Display(Name = "银行卡号")]
        public string bank_no { get; set; }
        [Display(Name = "银行名称")]
        public string bank_name { get; set; }
        [Display(Name = "创建时间")]
        public string create_time { get; set; }
    }

    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "顾客名称")]
        public string name { get; set; }
        [Display(Name = "地址")]
        public string address { get; set; }
        [Display(Name = "联系人")]
        public string contact { get; set; }
        [Display(Name = "电话")]
        public string phone { get; set; }
        [Display(Name = "创建时间")]
        public string create_time { get; set; }
    }

    public class Shareholder
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "合伙人名称")]
        public string name { get; set; }
        [Display(Name = "电话")]
        public string phone { get; set; }
        [Display(Name = "创建时间")]
        public string create_time { get; set; }
    }

    public class Expenditure
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "原料总价")]
        public double material_count_price { get; set; }
        [Display(Name = "运输总价")]
        public double carriage_count_price { get; set; }
        [Display(Name = "创建时间")]
        public string create_time { get; set; }
        public virtual Shareholder shareholder { get; set; }
        public virtual Transportation transportation { get; set; }

    }

    public class Transportation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "原料重量")]
        public double material_weight { get; set; }
        [Display(Name = "运输重量")]
        public double carriage_weight { get; set; }
        [Display(Name = "原料单价")]
        public double material_unit_price { get; set; }
        [Display(Name = "运输单价")]
        public double carriage_unit_price { get; set; }
        [Display(Name = "原料总价")]
        public double material_count_price { get; set; }
        [Display(Name = "运输总价")]
        public double carriage_count_price { get; set; }
        [Display(Name = "发货日期")]
        public string start_date { get; set; }
        [Display(Name = "收货日期")]
        public string end_date { get; set; }
        [Display(Name = "创建时间")]
        public string create_time { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Shareholder shareholder { get; set; }
        public virtual Car car { get; set; }
        public virtual Supply supply { get; set; }
        public virtual Material material { get; set; }
    }

    public class Income
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "收入金额")]
        public double count_price { get; set; }
        [Display(Name = "创建时间")]
        public string create_time { get; set; }
        public virtual Customer customer { get; set; }
    }
}

