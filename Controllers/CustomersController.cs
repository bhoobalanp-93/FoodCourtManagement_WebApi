using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AngularJwt_Api.Business;
using FoodCourtManagement.DAL;
using FoodCourtManagement.Models;

namespace FoodCourtManagement.Controllers
{

    public class CustomersController : ApiController
    {
        private FoodCourtContext db = new FoodCourtContext();

        // GET: api/Customers
        public IQueryable<Customer> Getcustomers()
        {
            return db.customers;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetloggedCustomer(string userEmail)
        {
            Customer customer = db.customers.SingleOrDefault(p => p.cust_MailID == userEmail) as Customer;
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.customer_ID)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            Customer isExistingcustomer = db.customers.Find(customer.customer_ID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (isExistingcustomer != null)
            {
                return BadRequest("Customer Already Exists");
            }

            customer.Cust_gender = customer.Cust_gender.Trim();
            if (customer.Cust_gender == "1")
                customer.Cust_gender = "Male";
            else if (customer.Cust_gender == "2")
            {
                customer.Cust_gender = "Female";
            }
            else
                customer.Cust_gender = "Others";

            db.customers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.customer_ID }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.customers.Count(e => e.customer_ID == id) > 0;
        }
    }
}