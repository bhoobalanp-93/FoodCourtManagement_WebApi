using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FoodCourtManagement.Models;

namespace FoodCourtManagement.DAL
{
    public class FoodCourtiInitializer : DropCreateDatabaseIfModelChanges<FoodCourtContext>
    {
        protected override void Seed(FoodCourtContext context)
        {
            

        }
    }
}