using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FoodCourtManagement.DAL;
using FoodCourtManagement.Models;
using System.Web.Http.Cors;
using System.Security.Claims;

namespace FoodCourtManagement.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FoodOrdersController : ApiController
    {
        private FoodCourtContext db = new FoodCourtContext();

        // GET: api/FoodOrders
        public IQueryable<FoodOrder> GetFoodOrders()
        {
            return db.FoodOrders;
        }

        // GET: api/FoodProducts
        public IQueryable<FoodProduct> GetFoodProducts()
        {
            return db.FoodProducts;
        }

        // GET: api/All Restaurants
        public IQueryable<Restaurant> GetRestaurants()
        {
            return db.Restaurants;
        }
        // GET: api/FoodProduct/5
      
        public IHttpActionResult GetFoodProduct(int id)
        {
            //FoodProduct foodProduct = db.FoodProducts.Find(id);
            
            var RespectiveFoodItems = db.FoodProducts.Where(p => p.fProductCatId == id) ;
            if (RespectiveFoodItems == null)
            {
                return NotFound();
            }
            
            return Ok(RespectiveFoodItems);
        }

        // GET: api/FoodOrders/5
        [ResponseType(typeof(FoodOrder))]
        public IHttpActionResult GetFoodOrder(int id)
        {
            FoodOrder foodOrder = db.FoodOrders.Find(id);
            if (foodOrder == null)
            {
                return NotFound();
            }

            return Ok(foodOrder);
        }

        // PUT: api/FoodOrders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFoodOrder(int id, List<OrderProduct> orderproduct)
        {
            FoodOrder foodorder = db.FoodOrders.Find(id);
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foodorder.Order_ID)
            {
                return BadRequest("Invalid OrdeID");
            }

            var products = db.OrderProducts.Where(p => p.OrderId == id);
            foreach (var foodproductitem in products)
                db.OrderProducts.Remove(foodproductitem);

            foreach (var addfoodproduct in orderproduct)
                db.OrderProducts.Add(addfoodproduct);

            if (db.ChangeTracker.HasChanges())
            {
                db.SaveChanges();
                int totalOrderPrice = 0;
                var updatedOrderProduct = (from orderP1 in db.OrderProducts
                                           where orderP1.OrderId == id
                                           select new
                                           {
                                               opKey = orderP1.orderProductKey,
                                               opID = orderP1.OrderId,
                                               opFoodpID = orderP1.fProductid,
                                               tProductPrice = orderP1.productQuantity * orderP1.productPrice
                                           });
                foreach(var orderprodprice in updatedOrderProduct)
                {
                     totalOrderPrice = totalOrderPrice + orderprodprice.tProductPrice;
                }

                foodorder.OrderPrice = totalOrderPrice;
                
            }

            //db.Entry(foodOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FoodOrders
        [ResponseType(typeof(FoodOrder))]
        public IHttpActionResult PostFoodOrder(FoodOrder foodOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FoodOrders.Add(foodOrder);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FoodOrderExists(foodOrder.Order_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = foodOrder.Order_ID }, foodOrder);
        }

        // DELETE: api/FoodOrders/5
        [ResponseType(typeof(FoodOrder))]
        public IHttpActionResult DeleteFoodOrder(int id)
        {
            FoodOrder foodOrder = db.FoodOrders.Find(id);
            if (foodOrder == null)
            {
                return NotFound();
            }

            db.FoodOrders.Remove(foodOrder);
            db.SaveChanges();

            return Ok(foodOrder);
        }

        // DELETE: api/FoodOrders/DeleteRestaurant/5
       public IHttpActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurnt = db.Restaurants.Find(id);
            if (restaurnt == null)
            {
                return NotFound();
            }

            db.Restaurants.Remove(restaurnt);
            db.SaveChanges();

            return Ok(restaurnt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoodOrderExists(int id)
        {
            return db.FoodOrders.Count(e => e.Order_ID == id) > 0;
        }

        //To Generatre orderProductKey
        private int orderIDGenerator()
        {
            Random OrderRandomID = new Random();
            int orderProductKey = OrderRandomID.Next(1000);
            return orderProductKey;
        }

    }
}