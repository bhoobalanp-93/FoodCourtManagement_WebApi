using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCourtManagement.Models
{
    [Table("RestaurantMaster")]
    public class Restaurant
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int restaurantId { get; set; }

        [Required]
        public string restaurantName { get; set; }
        public string rest_MailID { get; set; }
        public string rest_Contactno { get; set; }
        public string rest_Website { get; set; }
        public string rest_loaction { get; set; }
        public string rest_Address { get; set; }
        public string rest_DeliveryTime { get; set; }

        [ForeignKey("RestaurantType")]
        public int restaurantType_id { get; set; }
        public virtual RestaurantType RestaurantType { get; set; }
    }
}