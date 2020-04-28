
namespace FoodCourtManagement.Migrations
{
    using FoodCourtManagement.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FoodCourtManagement.DAL.FoodCourtContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(FoodCourtManagement.DAL.FoodCourtContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var FoodCategorys = new List<FoodCategory>
            {
              new FoodCategory{categoryId=100,categoryType="Vegetarian"},
              new FoodCategory{categoryId=101,categoryType="Non-Vegetarian"}
            };
            FoodCategorys.ForEach(s => context.FoodCategories.Add(s));
            context.SaveChanges();

            var customers = new List<Customer>
            {
              new Customer{customer_ID=500,first_Name="Raj",last_Name = "Kumar", cust_ContactNo="9874563210",cust_MailID="RKumar@gmail.com",cust_Address="50 /st Floor,Krishna Niwas,Yusuf Mehrali Rd,Mandvi", Cust_city="chennai", Cust_password="123456", Cust_gender ="Male"},
              new Customer{customer_ID=501,first_Name="Alex",last_Name = "Vetri", cust_ContactNo="9874563211",cust_MailID="Alexv@gmail@gmail.com",cust_Address="2,Pearly Shellapartments,Junction Of Tank Rd", Cust_city="chennai", Cust_password="123456", Cust_gender ="Male"},
              new Customer{customer_ID=502,first_Name="Alford",last_Name = "John", cust_ContactNo="9874563212",cust_MailID="Alfordj@gmail@gmail.com",cust_Address="Nimesh Apartment, S.v Patel Road, Borivli(w)", Cust_city="chennai", Cust_password="123456", Cust_gender ="Male"},
              new Customer{customer_ID=503,first_Name="Ravi",last_Name = "Raj", cust_ContactNo="9874563213",cust_MailID="Ravir@gmail.com",cust_Address="348  Yogeshwar,  Kazi Syed Street, Mandvi", Cust_city="chennai", Cust_password="123456", Cust_gender ="Male"},
              new Customer{customer_ID=504,first_Name="Anderson",last_Name = "James", cust_ContactNo="9874563214",cust_MailID="Andersonj@gmail.com",cust_Address="A-60, Midc,additional Ambernath, Ambernath", Cust_city="chennai", Cust_password="123456", Cust_gender ="Male"},
              new Customer{customer_ID=505,first_Name="Raja",last_Name = "Krishnan", cust_ContactNo="9874563215",cust_MailID="Rajak@gmail.com",cust_Address="264 , Balchandra Road, Prembaug, Matunga", Cust_city="chennai", Cust_password="123456", Cust_gender ="Male"},
              new Customer{customer_ID=506,first_Name="Mukesh",last_Name = "Kumar", cust_ContactNo="9874563216",cust_MailID="Mukeshk@gmail.com",cust_Address="Gr Flr, Acropolish Bldg, 3rd Cross Road, Lokhandwala Complex,nr 4 Bungalows, Andheri", Cust_city="chennai", Cust_password="123456", Cust_gender ="Male"},
              new Customer{customer_ID=507,first_Name="Benjamin",last_Name = "Franklin", cust_ContactNo="9874563217",cust_MailID="Benjaminf@gmail.com",cust_Address="81 , Tantanpura Street, Chinch Bunder", Cust_city="chennai", Cust_password="123456", Cust_gender ="Male"},
              new Customer{customer_ID=508,first_Name="Priya",last_Name = "Kumar", cust_ContactNo="9874563218",cust_MailID="Priyak@gmail.com",cust_Address="190, labour colony, guindy industrial estate", Cust_city="chennai", Cust_password="123456", Cust_gender ="Female"},
              new Customer{customer_ID=509,first_Name="Lakshmi",last_Name = "Ram", cust_ContactNo="9874563219",cust_MailID="Lakshmir@gmail.com",cust_Address="140, GST Road Kumaran nagar, Tambaramm west",Cust_city="chennai", Cust_password="123456", Cust_gender ="Female"},
              new Customer{customer_ID=510,first_Name="Jayashree",last_Name = "Jegan", cust_ContactNo="9874563290",cust_MailID="Jayashreej@gmail.com",cust_Address="30/120, GST Road R.S puram, Royapuram",Cust_city="chennai", Cust_password="123456", Cust_gender ="Female"},
            };
            customers.ForEach(s => context.customers.Add(s));
            context.SaveChanges();

            var foodProducts = new List<FoodProduct>
            {
              new FoodProduct{foodProductID=300,foodProductName="Chicken Biryani",foodProductPrice=200,foodProductImage="http://localhost:4200/assets/FoodProductsImages/ChickenBiryani.jpg",fProductCatId=101},
              new FoodProduct{foodProductID=301,foodProductName="Mutton Biryani",foodProductPrice=250,foodProductImage="http://localhost:4200/assets/FoodProductsImages/MuttonBiryani.webp",fProductCatId=101},
              new FoodProduct{foodProductID=302,foodProductName="Vegetable Biryani",foodProductPrice=150,foodProductImage="http://localhost:4200/assets/FoodProductsImages/vegbiryani.jpg",fProductCatId=100},
              new FoodProduct{foodProductID=303,foodProductName="Tandoori Chicken",foodProductPrice=220,foodProductImage="http://localhost:4200/assets/FoodProductsImages/TandooriChicken.jpg",fProductCatId=101},
              new FoodProduct{foodProductID=304,foodProductName="Grill chicken",foodProductPrice=230,foodProductImage="http://localhost:4200/assets/FoodProductsImages/GrillChicken.jfif",fProductCatId=101},
              new FoodProduct{foodProductID=305,foodProductName="Mutton Pepper Fry",foodProductPrice=300,foodProductImage="http://localhost:4200/assets/FoodProductsImages/Mutton_Pepper_Fry.jpg",fProductCatId=101},
              new FoodProduct{foodProductID=306,foodProductName="Veg Meals",foodProductPrice=120,foodProductImage="http://localhost:4200/assets/FoodProductsImages/VegMeals.jpg",fProductCatId=100},
              new FoodProduct{foodProductID=307,foodProductName="Chicken Fry",foodProductPrice=180,foodProductImage="http://localhost:4200/assets/FoodProductsImages/ChickenFry.jpg",fProductCatId=101},
              new FoodProduct{foodProductID=308,foodProductName="Mutton Fry",foodProductPrice=290,foodProductImage="http://localhost:4200/assets/FoodProductsImages/MuttonFry.jfif",fProductCatId=101},
              new FoodProduct{foodProductID=309,foodProductName="Prawn Fry",foodProductPrice=285,foodProductImage="http://localhost:4200/assets/FoodProductsImages/PrawnFry.jpg",fProductCatId=101},
              new FoodProduct{foodProductID=310,foodProductName="Soda",foodProductPrice=20,foodProductImage="http://localhost:4200/assets/FoodProductsImages/lemonSoda.jpg",fProductCatId=100},
              new FoodProduct{foodProductID=311,foodProductName="Chicken Gravy",foodProductPrice=210,foodProductImage="http://localhost:4200/assets/FoodProductsImages/chickenGravy.jpg",fProductCatId=101},
              new FoodProduct{foodProductID=312,foodProductName="Mutton Gravy",foodProductPrice=240,foodProductImage="http://localhost:4200/assets/FoodProductsImages/muttonGravy.jpg",fProductCatId=101},
              new FoodProduct{foodProductID=313,foodProductName="Falooda",foodProductPrice=60,foodProductImage="http://localhost:4200/assets/FoodProductsImages/falooda.jfif",fProductCatId=100},
              new FoodProduct{foodProductID=314,foodProductName="Stawberry Icecream",foodProductPrice=50,foodProductImage="http://localhost:4200/assets/FoodProductsImages/StrawberryIcecream.jpg",fProductCatId=100},
              new FoodProduct{foodProductID=315,foodProductName="Lemon Juice",foodProductPrice=60,foodProductImage="http://localhost:4200/assets/FoodProductsImages/Lemon-Juice.jpg",fProductCatId=100},
              new FoodProduct{foodProductID=316,foodProductName="Mango Juice",foodProductPrice=40,foodProductImage="http://localhost:4200/assets/FoodProductsImages/mango-juice.jpg",fProductCatId=100}
            };
            foodProducts.ForEach(s => context.FoodProducts.Add(s));
            context.SaveChanges();
            var restaurantType = new System.Collections.Generic.List<RestaurantType>
            {
               new RestaurantType{restType_id=100,rest_TypeDescription="Veg"},
               new RestaurantType{restType_id=101,rest_TypeDescription="Non-Veg"},
            };
            restaurantType.ForEach(s => context.RestaurantTypes.Add(s));
            context.SaveChanges();

            var restaurants = new List<Restaurant>
            {
               new Restaurant{restaurantId=01,restaurantName="Sangeetha",rest_MailID="RestaurantSangeetha@sangeetha.com", rest_Contactno="7896541230", rest_Website="www.SangeethaRestaurant.com",rest_loaction="chennai",rest_Address="Old 110/1 New 138, Habibullah Road, T. Nagar", rest_DeliveryTime="30 Minutes",restaurantType_id=100, rest_Rating= 4.0, rest_image="http://localhost:4200/assets/images/sangeetha-vegetarian.jpg"},
               new Restaurant{restaurantId=02,restaurantName="Bishmillah",rest_MailID="RestaurantBishmillah@Bishmillah.com", rest_Contactno="7896841230", rest_Website="www.RestaurantBishmillah.com",rest_loaction="chennai",rest_Address="New 14/11 Kundrathur Main Road, T. Nagar", rest_DeliveryTime="40 Minutes",restaurantType_id=101,rest_Rating= 4.5,rest_image="http://localhost:4200/assets/images/BismillahRestaurant.jpeg"},
               new Restaurant{restaurantId=03,restaurantName="Thalapakatti",rest_MailID="RestaurantThalapakatti@Thalapakatti.com", rest_Contactno="7896441230", rest_Website="www.RestaurantThalapakatti.com",rest_loaction="chennai",rest_Address="/1, Prakasam Road, Parthasarathi Puram, T Nagar", rest_DeliveryTime="20 Minutes",restaurantType_id=101,rest_Rating= 4.0,rest_image="http://localhost:4200/assets/images/dindugalThalapakkati.jpg"},
               new Restaurant{restaurantId=04,restaurantName="Sukkubai",rest_MailID="RestaurantSukkubai@Sukkubai.com", rest_Contactno="7896540230", rest_Website="www.RestaurantSukkubai.com",rest_loaction="chennai",rest_Address="1/293, Mariamman Koil Street, Mugalivakkam", rest_DeliveryTime="50 Minutes",restaurantType_id=101,rest_Rating= 4.5,rest_image="http://localhost:4200/assets/images/sukkubai.gif"},
               new Restaurant{restaurantId=05,restaurantName="Ya Mohaideen",rest_MailID="RestaurantYaMohaideen@YaMohaideen.com", rest_Contactno="7896541130", rest_Website="www.RestaurantYaMohaideen.com",rest_loaction="chennai",rest_Address="28, Kundrathur Main Road, Porur", rest_DeliveryTime="45 Minutes",restaurantType_id=101, rest_Rating= 4.7,rest_image="http://localhost:4200/assets/images/Yamohaideen.jfif"},
               new Restaurant{restaurantId=06,restaurantName="Ambur biryani",rest_MailID="RestaurantAmburbiryani@Amburbiryani.com", rest_Contactno="7896591230", rest_Website="www.RestaurantAmburbiryani.com",rest_loaction="chennai",rest_Address="New 2, Old 1, Venu Reddy Street, Guindy", rest_DeliveryTime="35 Minutes",restaurantType_id=101,rest_Rating= 5.0,rest_image="http://localhost:4200/assets/images/AbmurStar.jfif"},
               new Restaurant{restaurantId=07,restaurantName="Aasif",rest_MailID="RestaurantSAasif@AasifBiryaani.com", rest_Contactno="7836541230", rest_Website="www.RestaurantSAasif.com",rest_loaction="chennai",rest_Address="634, Near Maduvankarai, MKN Road, Guindy", rest_DeliveryTime="30 Minutes",restaurantType_id=101,rest_Rating= 5.0,rest_image="http://localhost:4200/assets/images/Aasife-Biriyani.jpg"},
               new Restaurant{restaurantId=08,restaurantName="KFC",rest_MailID="RestaurantKFC@KFC.com", rest_Contactno="7896541730", rest_Website="www.RestaurantKFC.com",rest_loaction="chennai",rest_Address="65, Anna Salai, Guindy", rest_DeliveryTime="60 Minutes",restaurantType_id=101,rest_Rating= 3.5,rest_image="http://localhost:4200/assets/images/KFC.png"},
               new Restaurant{restaurantId=09,restaurantName="Mc Donalds",rest_MailID="RestaurantMcDonalds@McDonalds.com", rest_Contactno="7866541230", rest_Website="www.RestaurantMcDonalds.com",rest_loaction="chennai",rest_Address="4/223, Thiruvalluvar Salai, Ramapuram", rest_DeliveryTime="35 Minutes",restaurantType_id=101,rest_Rating= 3.0,rest_image="http://localhost:4200/assets/images/mcdonaldsRest.jpg"},
               new Restaurant{restaurantId=10,restaurantName="Pizza Hut",rest_MailID="RestaurantSPizzaHut@PizzaHut.com", rest_Contactno="7896741230", rest_Website="www.RestaurantSPizzaHut.com",rest_loaction="chennai",rest_Address="DLF IT Park, Mount Poonamallee Road, Manapakkam", rest_DeliveryTime="25 Minutes",restaurantType_id=101, rest_Rating= 4.0,rest_image="http://localhost:4200/assets/images/Pizzahut.jpg"}
            };

            restaurants.ForEach(s => context.Restaurants.Add(s));
            context.SaveChanges();



            var foodOrders = new List<FoodOrder>() {
               new FoodOrder{Order_ID=800,RestaurantID=1,orderCustomerId=500,OrderPrice=420,paymentMode="Online"},
               new FoodOrder{Order_ID=801,RestaurantID=2,orderCustomerId=502,OrderPrice=470,paymentMode="Online"},
               new FoodOrder{Order_ID=802,RestaurantID=3,orderCustomerId=501,OrderPrice=305,paymentMode="Cash"}
            };
            foodOrders.ForEach(s => context.FoodOrders.Add(s));
            context.SaveChanges();


            var orderedProduct = new List<OrderProduct>() {
               new OrderProduct{orderProductKey=1000,OrderId=800,fProductid=302,productQuantity=2,productPrice=300},
               new OrderProduct{orderProductKey=1001,OrderId=800,fProductid=306,productQuantity=1,productPrice=120},
               new OrderProduct{orderProductKey=1002,OrderId=801,fProductid=307,productQuantity=1,productPrice=180},
               new OrderProduct{orderProductKey=1003,OrderId=801,fProductid=308,productQuantity=1,productPrice=290},
               new OrderProduct{orderProductKey=1004,OrderId=802,fProductid=309,productQuantity=1,productPrice=285},
               new OrderProduct{orderProductKey=1005,OrderId=802,fProductid=310,productQuantity=1,productPrice=20}
            };
            orderedProduct.ForEach(s => context.OrderProducts.Add(s));
            context.SaveChanges();
        }
    }
}
