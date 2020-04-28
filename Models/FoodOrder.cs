using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCourtManagement.Models
{
    public class FoodOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order_ID { get; set; }
        public int RestaurantID { get; set; }
        public int orderCustomerId { get; set; }
        public int OrderPrice { get; set; }
        public string paymentMode { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }

    }
}


