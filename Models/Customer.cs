using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCourtManagement.Models
{
    public class Customer
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int customer_ID { get; set; }
        public string first_Name { get; set; }
        public string last_Name { get; set; }
        public string cust_ContactNo { get; set; }
        public string cust_MailID { get; set; }
        public string cust_Address { get; set; }
        public string Cust_city { get; set; }
        public string Cust_password { get; set; }
        public string Cust_gender { get; set; }

        public ICollection<FoodOrder> foodOrder { get; set; }

    }
}
