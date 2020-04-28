using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCourtManagement.Models
{
    public class FoodProduct
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int foodProductID { get; set; }
        public string foodProductName { get; set; }
        public int foodProductPrice { get; set; }

        [ForeignKey("FoodCategory")]
        public int fProductCatId { get; set; }
        public virtual FoodCategory FoodCategory { get; set; }

    }
}

