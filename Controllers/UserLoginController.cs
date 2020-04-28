using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FoodCourtManagement.Models;
using AngularJwt_Api.Business;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Web.Http.Cors;
using FoodCourtManagement.DAL;

namespace AngularJwt_Api.Controllers
{

    [EnableCors("*", "*", "*")]
    public class LoginController : ApiController
    {
        private FoodCourtContext db = new FoodCourtContext();

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Authenticate([FromBody]UserLogin login)
        {
            
            bool isUsernamePasswordValid = false;
           Customer logedUser = new Customer();
            if (login != null)
            {
                logedUser = db.customers.SingleOrDefault(p => p.cust_MailID == login.userEmail) as Customer;
                isUsernamePasswordValid = logedUser != null ? true : false;
            }
            if (isUsernamePasswordValid)
            {
                string token = Jwt_Authentication.GenerateToken(logedUser);

                return Ok(token);
            }
            else
            {
                return BadRequest("Login failed, invalid Username or Password.");
            }
        }
        [AuthorizeJwt]
        [HttpGet]
        public HttpResponseMessage GetSecureValues()
        {
            return this.Request.CreateResponse(HttpStatusCode.OK,
                        new { content = "Secure Content Returned" });
        }
    }
}