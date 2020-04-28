using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCourtManagement.Models
{
    public class OrderProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int orderProductKey { get; set; }
        public int OrderId { get; set; }
        public int fProductid { get; set; }
        public int productQuantity { get; set; }
        public int productPrice { get; set; }

    }
}