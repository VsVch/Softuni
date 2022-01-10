using BattleCards.Data;
using MyFirstMvcApp.ViewModels;
using SUS.HTTP;
using SUS.mvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttPost("/Cards/Add")]
        public HttpResponse DoAdd() 
        {
            var dbContext = new ApplicationDbContext();
            dbContext.Cards.Add(new Card 
            { 
                Attack = int.Parse(this.Request.FormDate["attack"]),
                Health = int.Parse(this.Request.FormDate["health"]),
                Description = this.Request.FormDate["description"],
                Name = this.Request.FormDate["name"],
                ImageUrl = this.Request.FormDate["image"],
                Keyword = this.Request.FormDate["keyword"],
                
            });

            dbContext.SaveChanges();

            return this.View();
        }

        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Collection()
        {
            return this.View();
        }
    }
}
